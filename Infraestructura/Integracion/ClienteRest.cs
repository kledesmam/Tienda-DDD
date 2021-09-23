using Domain.Entidades;
using Domain.Entidades.ObjetosExternos;
using Domain.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Integracion
{
        
    public class ClienteRest : IClienteRest
    {
        private HttpClient _httpClient;
        public ClienteRest()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Método encargado de consumir el servicio expuesto por la pasarela de pagos para crear un solicitud
        /// de pago y obtener el requestId y la url para el pago.
        /// </summary>
        /// <param name="orden">Orden a ser procesada</param>
        /// <param name="parametrosPasarela">Listado con los parametros necesarios para conectar con la pasarela</param>
        /// <returns>Objeto que contiene el estado de la petición, la url de pago y el requestId</returns>
        public RedirectResponse CrearPagoPasarela(Orden orden, List<ParametroDetalle> parametrosPasarela)
        {
            RedirectResponse redirectResponse = null;

            RedirectRequest redirectRequest = CrearRedirectRequest(orden, parametrosPasarela);

            string baseUrl = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_URL_BASE)).Valor;
            _httpClient.BaseAddress = new Uri(baseUrl);

            var postTask = _httpClient.PostAsJsonAsync("", redirectRequest);
            postTask.Wait();
            var result = postTask.Result;

            if (!result.IsSuccessStatusCode)
                throw new Exception("Se presento una novedad al crear la solicitud de pago, orden no procesada");

            var readTask = result.Content.ReadFromJsonAsync<RedirectResponse>();
            readTask.Wait();
            redirectResponse = readTask.Result;

            return redirectResponse;
        }

        /// <summary>
        /// Método encargado de obtener la información de una transacción en la pasarela de pagos a tráves del
        /// RequestId
        /// </summary>
        /// <param name="requestId">RequestId del cual se desea obtener la información</param>
        /// <param name="parametrosPasarela">Listado con los parametros necesarios para conectar con la pasarela</param>
        /// <returns></returns>
        public RedirectInformation ConsultarTransaccionPasarela(int requestId, List<ParametroDetalle> parametrosPasarela)
        {
            RedirectInformation redirectInformation = null;
            InformationRequest informationRequest = new InformationRequest();
            string login = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_LOGIN)).Valor;
            string tranKey = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_TRANKEY)).Valor;
            string baseUrl = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_URL_BASE)).Valor;
            _httpClient.BaseAddress = new Uri(baseUrl);



            informationRequest.auth = CrearAuth(login, tranKey);


            var postTask = _httpClient.PostAsJsonAsync(requestId.ToString(), informationRequest);
            postTask.Wait();
            var result = postTask.Result;

            if (!result.IsSuccessStatusCode)
                throw new Exception("Se presento una novedad al consultar la transacción en la pasarela");

            var readTask = result.Content.ReadFromJsonAsync<RedirectInformation>();
            readTask.Wait();
            redirectInformation = readTask.Result;
            return redirectInformation;
        }

        #region Metodos Privados

        /// <summary>
        /// Método que se encarga de crear el objeto requerido por el servicio de la pasarela de pagos
        /// para crear una solicitud de pago.
        /// </summary>
        /// <param name="orden">Orden a ser procesada</param>
        /// <param name="parametrosPasarela">Listado con los parametros necesarios para conectar con la pasarela</param>
        /// <returns></returns>
        private RedirectRequest CrearRedirectRequest(Orden orden, List<ParametroDetalle> parametrosPasarela)
        {
            RedirectRequest redirectRequest = new RedirectRequest();
            string login = string.Empty, tranKey = string.Empty, locale = string.Empty, currency = string.Empty, 
                diasExpira = string.Empty, agente = string.Empty, urlRetorno = string.Empty;

            login = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_LOGIN)).Valor;
            tranKey = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_TRANKEY)).Valor;
            locale = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_LOCALE)).Valor;
            currency = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_CURRENCY)).Valor;
            diasExpira = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_DIAS_EXPIRA)).Valor;
            agente = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_AGENTE)).Valor;
            urlRetorno = parametrosPasarela.Find(x => x.Etiqueta.ToUpper().Equals(Constantes.ETIQUETA_PARAMETRODETALLE_PASARELA_URL_RETORNO)).Valor;


            redirectRequest.Auth = CrearAuth(login, tranKey);
            redirectRequest.Buyer = CrearBuyer(orden.Cliente);
            redirectRequest.Payment = CrearPayment(orden, currency);
            redirectRequest.Expiration = (DateTime.Now.AddDays(int.Parse(diasExpira))).ToString("yyyy-MM-ddTHH:mm:sszzz");
            redirectRequest.IpAddress = "127.0.0.1";
            redirectRequest.Locale = locale;
            redirectRequest.ReturnUrl = urlRetorno;
            redirectRequest.UserAgent = agente;

            return redirectRequest;
        }

        /// <summary>
        /// Método encargado de crear el objeto auth que contiene la auntenticación para el consumo de 
        /// los servicios de la pasarela de pagos
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="tranKey">Trankey</param>
        /// <returns></returns>
        private Auth CrearAuth(string login, string tranKey)
        {
            Authentication authentication = new Authentication(login, tranKey);
            Auth auth = new()
            {
                Login = authentication.getLogin(), 
                Nonce = authentication.getNonce(), 
                Seed = authentication.getSeed(),
                TranKey = authentication.getTranKey()
            };
            return auth;
        }
        
        /// <summary>
        /// Método encargado de crear un comprador para enviarlo en la petición de crear una solicitud de pago
        /// en la pasarela
        /// </summary>
        /// <param name="cliente">Cliente registrado en la orden de pago</param>
        /// <returns></returns>
        private Buyer CrearBuyer(Cliente cliente)
        {
            int celular = 0;
            int.TryParse(cliente.Celular, out celular);

            return new Buyer()
            {
                Document = cliente.NumeroIdentificacion.ToString(),
                DocumentType = cliente.TipoIdentificacion.ValorExterno,
                Email = cliente.Email,
                Mobile = celular,
                Name = cliente.Nombre,
                Surname = cliente.Apellido
            };
        }

        /// <summary>
        /// Método encargado de crear el objeto de pago para enviarlo en la petición de crear una solicitud de pago
        /// en la pasarela
        /// </summary>
        /// <param name="orden">Orden a ser procesada</param>
        /// <param name="currency">Moneda</param>
        /// <returns></returns>
        private Payment CrearPayment(Orden orden, string currency)
        {
            return new Payment()
            {
                AllowPartial = false,
                Amount = new Amount() 
                {
                    Currency = currency,
                    Total = orden.Valor.ToString()
                },
                Description = "Orden de compra " + orden.IdOrden,
                Reference = orden.ReferenciaPago
            };
        }

        #endregion
    }

    /// <summary>
    /// Clase que permite generar el nonce y el trankey
    /// Clase tomada del repositorio de evertec para c#
    /// </summary>
    public class Authentication
    {
        string login;
        string tranKey;
        string seed;
        string nonce;

        public Authentication(string login, string tranKey)
        {
            this.login = login;
            this.tranKey = tranKey;
            Generate();
        }

        /**
         * Invoque this function each time that you use this class to generate a WS call
         * this will save the need to construct a new class every time
         */
        public Authentication Generate()
        {
            nonce = (new Random()).GetHashCode().ToString(); // Guid.NewGuid().ToString();
            seed = (DateTime.Now).ToString("yyyy-MM-ddTHH:mm:sszzz");
            return this;
        }

        public string getLogin()
        {
            return this.login;
        }

        public string getTranKey()
        {
            return Base64(ToSha1(nonce + seed + tranKey));
        }

        public string getSeed()
        {
            return this.seed;
        }

        public string getNonce()
        {
            return Base64(nonce);
        }

        public Authentication setNonce(string nonce)
        {
            this.nonce = nonce;
            return this;
        }

        public Authentication setSeed(string seed)
        {
            this.seed = seed;
            return this;
        }

        static public string Base64(byte[] input)
        {
            return System.Convert.ToBase64String(input);
        }

        static public string Base64(string input)
        {
            if (input != null)
            {
                return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
            }
            return "";
        }

        static public byte[] ToSha1(string text)
        {
            System.Security.Cryptography.SHA1 hashString = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            return hashString.ComputeHash(ToStream(text));
        }

        static public Stream ToStream(string text)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(stream);
            sw.Write(text);
            sw.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}

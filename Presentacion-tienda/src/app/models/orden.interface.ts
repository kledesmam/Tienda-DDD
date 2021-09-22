export interface OrdenI{
    IdOrden: number;
    IdCliente: number;
    IdProducto: number;
    IdParametroDetalle: number;
    Valor: number;
    RequestId: string;
    UrlPago: string;
    ReferenciaPago: string;
    FechaCreacion: string;
    FechaModificacion: string;
    EstadoOrden: string;
    NombreCliente: string;
    ApellidoCliente: string;
    IdentificacionCliente: string;
    TipoIdentificacionCliente: string;
    EmailCliente: string;
    CodigoProducto: string;
    NombreProducto: string;
    PermitePagar: boolean;
    PermiteRegenerarPago: boolean;
}
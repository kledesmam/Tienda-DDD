import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { crearCliente } from './../models/crear-cliente';
import { ClienteI } from '../models/cliente.interface';
import { ParametroDetalleI } from '../models/parametro-detalle.interface';
import { genericResponseI } from '../models/generic-response.interface';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url:string = "https://localhost:44342/api/";

  constructor(private httpClient: HttpClient) { }

  getAllDocumentsType(): Observable<ParametroDetalleI[]> {
    let requestUrl = this.url + "parametroDetalle/tipos-documentos";
    return this.httpClient.get<ParametroDetalleI[]>(requestUrl);
  }

  getClienteByEmail(email: string): Observable<ClienteI>{
    let requestUrl = this.url + "cliente/" + email;
    return this.httpClient.get<ClienteI>(requestUrl);
  }

  postCrearCliente(cliente: crearCliente): Observable<genericResponseI>{
    let requestUrl = this.url + "cliente";
    return this.httpClient.post<genericResponseI>(requestUrl, cliente);
  }
}

import { Injectable } from '@angular/core';
import { OrdenI } from './../models/orden.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { comprarRequest } from '../models/comprar-request';


@Injectable({
  providedIn: 'root'
})
export class OrdenService {

  url:string = "https://localhost:44342/api/";

  constructor(private httpClient: HttpClient) { }

  getAllOrdens(): Observable<OrdenI[]> {
    let requestUrl = this.url + "orden";
    return this.httpClient.get<OrdenI[]>(requestUrl);
  }

  getOrdenById(id: number): Observable<OrdenI>{
    let requestUrl = this.url + "orden/" + id;
    return this.httpClient.get<OrdenI>(requestUrl);
  }

  postCompar(comprarRequest: comprarRequest): Observable<OrdenI>{
    let requestUrl = this.url + "orden";
    return this.httpClient.post<OrdenI>(requestUrl, comprarRequest);
  }

  putRefrescarEstado(id: number): Observable<OrdenI>{
    let requestUrl = this.url + "orden/refresh-status-pay/" + id;
    return this.httpClient.put<OrdenI>(requestUrl, null);
  }

  putRegenerarLinkPago(id: number): Observable<OrdenI>{
    let requestUrl = this.url + "orden/regenerate-pay/" + id;
    return this.httpClient.put<OrdenI>(requestUrl, null);
  }

  getAllOrdensByIdCliente(id: number): Observable<OrdenI[]> {
    let requestUrl = this.url + "orden/cliente/" + id;
    return this.httpClient.get<OrdenI[]>(requestUrl);
  }
}

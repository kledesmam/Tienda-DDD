import { Injectable } from '@angular/core';
import { OrdenI } from './../models/orden.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


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
}

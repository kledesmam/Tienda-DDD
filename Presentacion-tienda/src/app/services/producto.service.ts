import { ProductoI } from './../models/producto.interface';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  url:string = "https://localhost:44342/api/";

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<ProductoI[]> {
    let requestUrl = this.url + "producto";
    return this.httpClient.get<ProductoI[]>(requestUrl);
  }
}

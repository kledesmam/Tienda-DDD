import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { OrdenI } from '../../models/orden.interface';

import { OrdenService } from '../../services/orden.service';

@Component({
  selector: 'app-resumen-orden',
  templateUrl: './resumen-orden.component.html',
  styleUrls: ['./resumen-orden.component.css']
})
export class ResumenOrdenComponent implements OnInit {

  orden: OrdenI;

  resumenForm = new FormGroup({
    idOrden: new FormControl(''),
    numeroIdentificacionCliente: new FormControl(''),
    nombreCliente: new FormControl(''),
    apellidoCliente: new FormControl(''),
    correoCliente: new FormControl(''),
    codigoProducto: new FormControl(''),
    nombreProducto: new FormControl(''),
    valorOrden: new FormControl(''),
    estadoOrden: new FormControl(''),
    referenciaPago: new FormControl(''),
    requestId: new FormControl(''),
    fechaCreacion: new FormControl(''),
    fechaModificacion: new FormControl(''),
    urlPago: new FormControl('')
  });

  constructor(private activeReouter: ActivatedRoute, private router: Router,
    private ordenService: OrdenService) { }

  ngOnInit(): void {
    let id = this.activeReouter.snapshot.paramMap.get('id');    
    if(id != null){
      this.cargarResumenOrden(parseInt(id));
    }
  }

  cargarResumenOrden(id: number){
    this.ordenService.getOrdenById(id).subscribe(
      data => {        
        this.orden = data;

        this.resumenForm.setValue({
          'idOrden': this.orden.IdOrden,
          'numeroIdentificacionCliente': this.orden.IdentificacionCliente,
          'nombreCliente': this.orden.NombreCliente,
          'apellidoCliente': this.orden.ApellidoCliente,
          'correoCliente': this.orden.EmailCliente,
          'codigoProducto': this.orden.CodigoProducto,
          'nombreProducto': this.orden.NombreProducto,
          'valorOrden': this.orden.Valor,
          'estadoOrden': this.orden.EstadoOrden,
          'referenciaPago': this.orden.ReferenciaPago,
          'requestId': this.orden.RequestId,
          'fechaCreacion': this.orden.FechaCreacion,
          'fechaModificacion': this.orden.FechaModificacion,
          'urlPago': this.orden.UrlPago
        });
      }
    )
  }

  pagarOrden(){

  }

  refrescarEstado(){
    
  }

  volverInicio(){
    this.router.navigate(['dashboard']);
  }

}

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

  permitePagar: boolean = false;
  permiteRegenerarPago: boolean = false;

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
    this.permitePagar = false;
    this.permiteRegenerarPago = false;
    
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
        this.permitePagar = this.orden.PermitePagar;
        this.permiteRegenerarPago = this.orden.PermiteRegenerarPago;
      },
      err => {
        console.log('Error ', err);
        
        this.router.navigate(['dashboard']);
      }
    )
  }

  pagarOrden(){
    if(this.orden != null && this.orden.UrlPago.length > 0){
      window.open(this.orden.UrlPago, "_blank");
    }
  }

  refrescarEstado(){
    if(this.orden != null && this.orden.IdOrden > 0){
      this.permitePagar = !this.permitePagar;
      this.permiteRegenerarPago = !this.permiteRegenerarPago;

      this.ordenService.putRefrescarEstado(this.orden.IdOrden)
      .subscribe(data => {
        this.cargarResumenOrden(data.IdOrden);
      },
      err=>{
        this.permitePagar = !this.permitePagar;
        this.permiteRegenerarPago = !this.permiteRegenerarPago;
      });
    }
  }

  volverInicio(){
    this.router.navigate(['dashboard']);
  }

  regenerarLinkPago(){
    if(this.orden != null && this.orden.IdOrden > 0){
      this.permitePagar = !this.permitePagar;
      this.permiteRegenerarPago = !this.permiteRegenerarPago;

      this.ordenService.putRefrescarEstado(this.orden.IdOrden)
      .subscribe(data => {
        this.cargarResumenOrden(data.IdOrden);
      },
      err=>{
        this.permitePagar = !this.permitePagar;
        this.permiteRegenerarPago = !this.permiteRegenerarPago;
      });
    }
  }

  ordenesPorCliente(){
    if(this.orden != null && this.orden.IdOrden > 0){
      this.router.navigate(['listado-orden-cliente/', this.orden.IdCliente]);
    }
  }

}

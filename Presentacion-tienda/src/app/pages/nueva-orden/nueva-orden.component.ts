import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { OrdenService } from './../../services/orden.service';
import { comprarRequest } from '../../models/comprar-request';
import { ClienteI } from './../../models/cliente.interface';
import { ProductoI } from './../../models/producto.interface';
import { OrdenI } from 'src/app/models/orden.interface';

@Component({
  selector: 'app-nueva-orden',
  templateUrl: './nueva-orden.component.html',
  styleUrls: ['./nueva-orden.component.css']
})
export class NuevaOrdenComponent implements OnInit {

  clienteI: ClienteI;
  productoI: ProductoI;
  ordenI: OrdenI
  comprarIsDisabled: boolean = true;

  constructor(private ordenService: OrdenService, private router: Router) { }

  ngOnInit(): void {
  }

  setCliente(cliente: any){
    this.clienteI = cliente ?? null;
    this.activarBotonCompra();
  }

  setProducto(producto: any){
    this.productoI = producto ?? null;
    this.activarBotonCompra();
  }

  activarBotonCompra(){
    this.comprarIsDisabled = !(this.clienteI != null && this.productoI != null);
  }

  comprar(){
    this.comprarIsDisabled = true;
    console.log('cliente ', this.clienteI );
    console.log('Prod ', this.productoI);
    let comprarRequest: comprarRequest;
    comprarRequest = {
      IdCliente: this.clienteI.IdCliente,
      IdProducto: this.productoI.IdProducto,
      Valor: this.productoI.ValorUnitario
    }

    this.ordenService.postCompar(comprarRequest)
    .subscribe(data =>{
      this.ordenI = data
      this.router.navigate(['resumen', this.ordenI.IdOrden]);
      this.comprarIsDisabled = false;
    },
    err => {
      console.log('Error ', err);
      this.comprarIsDisabled = false;      
    });
    
  }

  volverInicio(){
    this.router.navigate(['dashboard']);
  }
}

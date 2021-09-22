import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdenI } from 'src/app/models/orden.interface';
import { OrdenService } from 'src/app/services/orden.service';

@Component({
  selector: 'app-listado-orden-cliente',
  templateUrl: './listado-orden-cliente.component.html',
  styleUrls: ['./listado-orden-cliente.component.css']
})
export class ListadoOrdenClienteComponent implements OnInit {

  ordenes: OrdenI[] = [];
  
  constructor(private ordenService: OrdenService, 
              private router: Router,
              private activeReouter: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.activeReouter.snapshot.paramMap.get('id');    
    if(id != null){
      this.getAllOrdens(parseInt(id));
    }
  }

  getAllOrdens(id: number){
    this.ordenService.getAllOrdensByIdCliente(id).subscribe(
      data => {
        this.ordenes = data;
      }
    )
  }

  resumenOrden(id:number){
    this.router.navigate(['resumen', id]);
  }

  volverInicio(){
    this.router.navigate(['dashboard']);
  }
}

import { Component, OnInit } from '@angular/core';
import { OrdenService } from '../../services/orden.service';
import { Router } from '@angular/router';

import { OrdenI } from '../../models/orden.interface';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  ordenes: OrdenI[] = [];

  constructor(private ordenService: OrdenService, private router: Router) { }

  ngOnInit(): void {
    this.getAllOrdens();
  }

  getAllOrdens(){
    this.ordenService.getAllOrdens().subscribe(
      data => {
        this.ordenes = data;
      }
    )
  }

  crearOrden(){
    this.router.navigate(['nueva']);
  }

  resumenOrden(id:number){
    this.router.navigate(['resumen', id]);
  }

}

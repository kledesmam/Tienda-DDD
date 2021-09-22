import { FormGroup, FormControl } from '@angular/forms';
import { ProductoService } from './../../services/producto.service';
import { ProductoI } from './../../models/producto.interface';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  listaProductos: ProductoI[];
  selectedProduct: ProductoI;

  productoForm = new FormGroup({
    productoId: new FormControl(''),
    valorUnitario: new FormControl('')
  });

  @Output() productoSelectedEvent = new EventEmitter();

  constructor(private productoService: ProductoService) { }

  ngOnInit(): void {
    this.productoService.getAll().subscribe(
      data=>{        
        this.listaProductos = data;          
      }
    );
  }

  onProductSelected(){    
    this.productoSelectedEvent.emit(this.selectedProduct);
  }

}

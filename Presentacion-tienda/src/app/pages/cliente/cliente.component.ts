import { ValidateForm } from '../../validators/forms.validator';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { crearCliente } from './../../models/crear-cliente';
import { ClienteService } from '../../services/cliente.service';
import { ParametroDetalleI } from 'src/app/models/parametro-detalle.interface';
import { ClienteI } from 'src/app/models/cliente.interface';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  listaTipoIdentificacion: ParametroDetalleI[];
  crearIsDisable: boolean = true;

  @Output() clienteSelectedEvent = new EventEmitter();

  constructor(private clienteService: ClienteService) { }

  clienteForm = new FormGroup({
    IdCliente: new  FormControl(''),
    IdTipoIdentificacion: new FormControl('', Validators.required),
    NumeroIdentificacion: new FormControl('', Validators.required),
    Nombre: new FormControl('', Validators.required),
    Apellido: new FormControl('', Validators.required),
    Email: new FormControl('', Validators.required),
    Celular: new FormControl('', Validators.required),
    TipoIdentificacion: new FormControl('')
  });

  ngOnInit(): void {
    this.clienteService.getAllDocumentsType().subscribe(
      data =>{
        this.listaTipoIdentificacion = data;
      }
    )
  }

  buscar(event: any){
    if(event.target.value != null && event.target.value != ""){
      this.buscarClienteByEmail(event.target.value);
    }
    else{
      this.limpiarCampos();
    }
      
  }

  buscarClienteByEmail(email: string){
    this.clienteService.getClienteByEmail(email).subscribe(
      data =>{
        if(data.IdCliente > 0){
          this.clienteForm.setValue({
            'IdCliente': data.IdCliente,
            'IdTipoIdentificacion': data.IdTipoIdentificacion,
            'NumeroIdentificacion': data.NumeroIdentificacion,
            'Nombre': data.Nombre,
            'Apellido': data.Apellido,
            'Email': data.Email,
            'Celular': data.Celular,
            'TipoIdentificacion': data.TipoIdentificacion
          });
          this.clienteSelectedEvent.emit(data);
          this.crearIsDisable = true;
        }else{
          this.limpiarCampos();
        }
      }, err => {
        console.log(err);
        this.limpiarCampos();
      });
  }

  @ValidateForm("clienteForm")
  guardar(){
    console.log(this.clienteForm.value);
    let clienteI: ClienteI = this.clienteForm.value;
    let crearCliente: crearCliente;
    crearCliente = {
      Apellido: clienteI.Apellido,
      Celular: clienteI.Celular,
      Email: clienteI.Email,
      IdCliente: 0,
      IdTipoIdentificacion: clienteI.IdTipoIdentificacion,
      Nombre: clienteI.Nombre,
      NumeroIdentificacion: clienteI.NumeroIdentificacion
    }

    this.clienteService.postCrearCliente(crearCliente)
    .subscribe(data => {
      this.buscarClienteByEmail(clienteI.Email);
    },
    err =>{
      console.log('Error ', err);
    });
    
  }

  limpiarCampos(){
    this.clienteSelectedEvent.emit(null);
      this.crearIsDisable = false;

      this.clienteForm.setValue({
        'IdCliente': null,
        'IdTipoIdentificacion': null,
        'NumeroIdentificacion': null,
        'Nombre': null,
        'Apellido': null,
        'Email': this.clienteForm.get('Email')?.value,
        'Celular': null,
        'TipoIdentificacion': null
      });
  }
}

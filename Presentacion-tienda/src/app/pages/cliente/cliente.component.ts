import { ClienteService } from '../../services/cliente.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ParametroDetalleI } from 'src/app/models/parametro-detalle.interface';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  listaTipoIdentificacion: ParametroDetalleI[];

  constructor(private clienteService: ClienteService) { }

  clienteForm = new FormGroup({
    idCliente: new  FormControl(''),
    tipoIdentificacionCliente: new FormControl(''),
    numeroIdentificacionCliente: new FormControl(''),
    nombreCliente: new FormControl(''),
    apellidoCliente: new FormControl(''),
    correoCliente: new FormControl(''),
    celularCliente: new FormControl('')
  });

  ngOnInit(): void {
    this.clienteService.getAllDocumentsType().subscribe(
      data =>{
        this.listaTipoIdentificacion = data;
      }
    )
  }

  buscar(event: any){
    if(event.target.value != null && event.target.value != "")
      this.clienteService.getClienteByEmail(event.target.value).subscribe(
        data =>{
          console.log(data);
          console.log(data.IdCliente);
          
          this.clienteForm.setValue({
            'idCliente': data.IdCliente,
            'tipoIdentificacionCliente': data.IdTipoIdentificacion,
            'numeroIdentificacionCliente': data.NumeroIdentificacion,
            'nombreCliente': data.Nombre,
            'apellidoCliente': data.Apellido,
            'correoCliente': data.Email,
            'celularCliente': data.Celular
          });
        }
      );
  }

  guardar(){

  }
}

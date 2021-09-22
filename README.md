# Tienda-DDD
Repositorio para implementar una tienda que se conecta con la pasarela de pagos de PlacetoPay.
Este proyecto permite registrar una orden de compra, crear el link de pagos en la pasarela, consultar el estado del pago de la orden la pasarela, listar todas las orden en general y filtradas por un cliente.

### Implementación y tecnologias
* [Net Core 5](https://visualstudio.microsoft.com/es/)
* C#
* [Angular](https://angular.io/)
* [Node](https://nodejs.org/es/)
* [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) 

### Arquitectura Backend


## Setup
### Instrucciones

Clonar el repositorio: https://github.com/kledesmam/Tienda-DDD.git

### Backend
Lo primero es establecer como proyecto de inicio el proyecto Presentacion.
Restaurar los paquetes nuget de la solución. Generalmente este proceso es automatico, pero en caso que se requiera se debe seleccionar la solución, click derecho y seleccionar la opción restaurar paquetes de nuget.

Para compilar y ejecutar proyecto es necesario instalar el visual studio 2019, si se quiere una base de datos local hay que descargar el sql server y el sql server management. Modificar la cadena de conexión a la base de datos (archivo appsettings.json que se encuentra en el proyecto Presentacion).

El proyecto Presentacion es donde esta el api rest que permite el consumo y exposición de los servicios de la Tienda para que sean consumidos por la aplicación Front.

### Frontend
El proyecto front se encuentra en la carpeta Presentacion-tienda. Este proyecto fue creado usando Angular.
Lo primero que debemos hacer es tener instalado:
* Node
* npm
* angula/cli

Posteriormente desde una terminal o linea de comandos navegar hasta la ruta de la carpeta Presentacion-tienda (estar dentro de esta) y ejecutar el siguiente comando:
```
  npm install
```
Este comando descarga todos los paquetes y dependencias requeridas para que el proyecto funcione correctamente.

Una vez se cuente con todo los paquetes instalados, la aplicación se inicia con el siguiente comando (abre automaticamente el navegador)
```
  ng serve -o
```

Nota: Para que la aplicación front opere correctamente es necesario que el proyecto backend este corriendo.

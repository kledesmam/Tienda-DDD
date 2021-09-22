# Tienda-DDD
Repositorio para implementar una tienda que se conecta con la pasarela de pagos de PlacetoPay.
Este proyecto permite registrar una orden de compra, crear el link de pagos en la pasarela, consultar el estado del pago de la orden la pasarela, listar todas las orden en general y filtradas por un cliente.

Este proyecto se creo usando las siguientes tecnologias
* Net Core 5
* C#
* Angular
* Sql Server

Este proyecto se creo bajo una arquitectura limpia 

# Setup
Instrucciones

Clonar el repositorio: XXXX

Para compilar y ejecutar proyecto es necesario instalar el visual studio 2019 , si se quiere una base de datos local hay que descargar el sql server y el sql server management. Modificar la cadena de conexión a la base de datos (archivo appsettings.json que se encuentra en el proyecto Presentacion).
Establecer como proyecto de inicio el proyecto Presentacion.

El proyecto Presentacion es donde esta el api rest que permite el consumo y exposición de los servicios de la Tienda para que sean consumidos por la aplicación Front.


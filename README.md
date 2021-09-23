# Tienda-DDD
Repositorio para implementar una tienda que se conecta con la pasarela de pagos de PlacetoPay.
Este proyecto permite registrar una orden de compra, crear el link de pagos en la pasarela, consultar el estado del pago de la orden la pasarela, listar todas las orden en general y filtradas por un cliente.

### Implementación y tecnologias
* [Net Core 5](https://visualstudio.microsoft.com/es/)
* C#
* [Angular](https://angular.io/)
* [Node](https://nodejs.org/es/)
* [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) 

## Estructura del proyecto
### Estructura del Backend
#### Presentacion (Api)
En este proyecto se administran los servicios rest que se exponen para ser consumidos por los clientes. Este proyecto es el proyecto de inicio y aqui se configura la cadena de conexión a la base de datos (archivo appsettings.json)
#### Aplicacion
En este proyecto se establecen las clases que se comunican con el proyecto presentacion. En esta capa se realizan las validaciones necesarias de datos y tambien se establecen las transformaciones de la entidades a Dtos. En esta capa se maneja la transacción para confirmar los cambios en la base de datos.
#### Domain
En este proyecto se definen las interfaces (contratos) de nuestro repositorio. Esto con el fin de evitar acoplamiento a la tecnologia de nuestro repositorio y que si adelante deseamos cambiar por ejemplo el ORM sea transparente.
Tambien se establece los metodos u operaciones que tienen logica de negocio asociada. Si el método funciona como un CRUD, se puede acceder al repositorio desde el proyecto Aplicacion, dado que no tiene lógica propia de negocio asociada.
#### Domain.Entidades
Este proyecto es transveral a la solución. En este proyecto se manejan las entidades, dtos, objetos externos (representan In/Out de servicios externos). Asi como tambien las constantes. 
El objetivo de este proyecto es que contengo los objetos o clases que son transversales para toda la solución.
#### Infraestructura
En este proyecto se definen las clases que acceden a la base de datos a través de EntityFrameworkCore (Repositorios). Estos repositorios deben implementar los contratos de repositorios establecidos en el proyecto Domain.
Se estable el Context y DbSet requeridos.
Tambien se establecen los metodos o clases que se comunican con servicios externos (Integracion)
#### TestEvertec.xUnitTest
Proyecto encargado de administrar las pruebas unitarias.

### Estructura del Frontend

## Setup
### Instrucciones

Clonar el repositorio: https://github.com/kledesmam/Tienda-DDD.git

### Backend
Lo primero es establecer como proyecto de inicio el proyecto Presentacion.
Restaurar los paquetes nuget de la solución. Generalmente este proceso es automatico, pero en caso que se requiera se debe seleccionar la solución, click derecho y seleccionar la opción restaurar paquetes de nuget.

Para compilar y ejecutar proyecto es necesario instalar el visual studio 2019, si se quiere una base de datos local hay que descargar el sql server y el sql server management. Modificar la cadena de conexión a la base de datos (archivo appsettings.json que se encuentra en el proyecto Presentacion).

El proyecto Presentacion es donde esta el api rest que permite el consumo y exposición de los servicios de la Tienda para que sean consumidos por la aplicación Front.

Para el ambiente local se debe crear los objetos de base de datos mediante las siguientes instrucciones:
* Abril la consola de administración de paquetes (Menu -> Herramientas -> Admininistrador de paquetes nuget -> Consola de administracion de paquetes)
* Seleccionar como proyecto predeterminado el proyecto Infraestructura
* Ejecutar el comando add-migration nombre-de-la-migracion
* Si no se presentan errores, ejecutar el comando Update-Database para sincronizar los cambios con la base de datos.  

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

### Servicios Api

### Test

#### Automaticos

Para la ejecución de los test automáticos usar visual studio con el fin de evitar la ejecución por comandos.
En el proyecto de Service.Test dar click derecho y ejecutar pruebas unitarias.

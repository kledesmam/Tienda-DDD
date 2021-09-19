using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    IdParametro = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Etiqueta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.IdParametro);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ValorUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "ParametroDetalle",
                columns: table => new
                {
                    IdParametroDetalle = table.Column<int>(type: "int", nullable: false),
                    IdParametro = table.Column<int>(type: "int", nullable: false),
                    Etiqueta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ValorExterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroDetalle", x => x.IdParametroDetalle);
                    table.ForeignKey(
                        name: "FK_ParametroDetalle_Parametro_IdParametro",
                        column: x => x.IdParametro,
                        principalTable: "Parametro",
                        principalColumn: "IdParametro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdParametroDetalle = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumeroIdentificacion = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_ParametroDetalle_IdParametroDetalle",
                        column: x => x.IdParametroDetalle,
                        principalTable: "ParametroDetalle",
                        principalColumn: "IdParametroDetalle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    IdOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdParametroDetalle = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UrlPago = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferenciaPago = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.IdOrden);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_ParametroDetalle_IdParametroDetalle",
                        column: x => x.IdParametroDetalle,
                        principalTable: "ParametroDetalle",
                        principalColumn: "IdParametroDetalle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenLog",
                columns: table => new
                {
                    IdOrdenLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UrlPago = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferenciaPago = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenLog", x => x.IdOrdenLog);
                    table.ForeignKey(
                        name: "FK_OrdenLog_Orden_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "Orden",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parametro",
                columns: new[] { "IdParametro", "Etiqueta", "Nombre" },
                values: new object[,]
                {
                    { 1, "TIPOS-DOCUMENTOS", "Tipos de Documento de identidad" },
                    { 2, "ESTADOS-ORDEN", "Estado Orden" },
                    { 3, "PASARELA-PAGOS", "Parametros pasarela pagos" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Codigo", "Nombre", "ValorUnitario" },
                values: new object[] { 1, "001", "Producto Pruebas", 180000.0 });

            migrationBuilder.InsertData(
                table: "ParametroDetalle",
                columns: new[] { "IdParametroDetalle", "Etiqueta", "IdParametro", "Valor", "ValorExterno" },
                values: new object[,]
                {
                    { 1, "CC", 1, "Cédula Ciudadanía", "CC" },
                    { 2, "CE", 1, "Cédula Extranjería", "CE" },
                    { 3, "TI", 1, "Tarjeta de Identidad", "TI" },
                    { 4, "NIT", 1, "Número de Identificación Tributaria", "TI" },
                    { 5, "ESTADO-CREATED", 2, "CREATED", "CREATED" },
                    { 6, "ESTADO-PAYED", 2, "PAYED", "PAYED" },
                    { 7, "ESTADO-REJECTED", 2, "REJECTED", "REJECTED" },
                    { 8, "PASARELA-LOGIN", 3, "6dd490faf9cb87a9862245da41170ff2", "" },
                    { 9, "PASARELA-TRANKEY", 3, " 024h1IlD", "" },
                    { 10, "PASARELA-URL-BASE", 3, "https://test.placetopay.com/redirection/api/session/", "" },
                    { 11, "PASARELA-LOCALE", 3, "en_CO", "" },
                    { 12, "PASARELA-CURRENCY", 3, "COP", "" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "Apellido", "Celular", "Email", "IdParametroDetalle", "Nombre", "NumeroIdentificacion" },
                values: new object[] { 1, "Ledesma", "3002211445", "ingcaledesma@gmail.com", 1, "Carlos", 94557038.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdParametroDetalle",
                table: "Cliente",
                column: "IdParametroDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdCliente",
                table: "Orden",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdParametroDetalle",
                table: "Orden",
                column: "IdParametroDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdProducto",
                table: "Orden",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenLog_IdOrden",
                table: "OrdenLog",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroDetalle_IdParametro",
                table: "ParametroDetalle",
                column: "IdParametro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenLog");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "ParametroDetalle");

            migrationBuilder.DropTable(
                name: "Parametro");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructura.Migrations
{
    public partial class InsertRowsPasarela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParametroDetalle",
                columns: new[] { "IdParametroDetalle", "Etiqueta", "IdParametro", "Valor", "ValorExterno" },
                values: new object[] { 13, "PASARELA-DIAS-EXPIRA", 3, "5", "" });

            migrationBuilder.InsertData(
                table: "ParametroDetalle",
                columns: new[] { "IdParametroDetalle", "Etiqueta", "IdParametro", "Valor", "ValorExterno" },
                values: new object[] { 14, "PASARELA-AGENTE", 3, "PlacetoPay Sandbox", "" });

            migrationBuilder.InsertData(
                table: "ParametroDetalle",
                columns: new[] { "IdParametroDetalle", "Etiqueta", "IdParametro", "Valor", "ValorExterno" },
                values: new object[] { 15, "PASARELA-URL-RETORNO", 3, "https://localhost:44342/api/orden", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ParametroDetalle",
                keyColumn: "IdParametroDetalle",
                keyValue: 15);
        }
    }
}

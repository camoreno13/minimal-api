using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace minimal_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("8ed0cfd3-74af-4b87-9284-e87f209c892d"), null, "Categoria 1", 10 },
                    { new Guid("f2674df3-6801-42b5-9338-ec35da6cd307"), null, "Categoria 2", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("7f1fc391-32a1-4f0a-9958-488ae5c0ae43"), new Guid("f2674df3-6801-42b5-9338-ec35da6cd307"), null, new DateTime(2023, 3, 30, 1, 50, 15, 594, DateTimeKind.Local).AddTicks(8038), 2, "Tarea 2" },
                    { new Guid("fb21f0db-e31b-4ed3-92fa-4687dcfcfdcf"), new Guid("8ed0cfd3-74af-4b87-9284-e87f209c892d"), "tarea 1 ", new DateTime(2023, 3, 30, 1, 50, 15, 594, DateTimeKind.Local).AddTicks(8023), 0, "Tarea 1 " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("7f1fc391-32a1-4f0a-9958-488ae5c0ae43"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("fb21f0db-e31b-4ed3-92fa-4687dcfcfdcf"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("8ed0cfd3-74af-4b87-9284-e87f209c892d"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f2674df3-6801-42b5-9338-ec35da6cd307"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

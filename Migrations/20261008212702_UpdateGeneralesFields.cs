using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlEscolarWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGeneralesFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Alumnos");

            migrationBuilder.AddColumn<string>(
                name: "CalleNumero",
                table: "Alumnos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Alumnos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Alumnos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Alumnos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Alumnos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Alumnos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MunicipioEntidad",
                table: "Alumnos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalleNumero",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "MunicipioEntidad",
                table: "Alumnos");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Alumnos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}

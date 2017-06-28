using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrabalhoFinal.Migrations
{
    public partial class AjusteAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataHoraFim",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "DataHoraInicio",
                table: "Agendas",
                newName: "DataAgenda");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioEntrada",
                table: "Agendas",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorarioSaida",
                table: "Agendas",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioEntrada",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "HorarioSaida",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "DataAgenda",
                table: "Agendas",
                newName: "DataHoraInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraFim",
                table: "Agendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend5.Migrations
{
    public partial class AddPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyses_Labs_LabId",
                table: "Analyses");

            migrationBuilder.AlterColumn<int>(
                name: "LabId",
                table: "Analyses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LablId",
                table: "Analyses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Data = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_PatientId",
                table: "Analyses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Analyses_Labs_LabId",
                table: "Analyses",
                column: "LabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyses_Patients_PatientId",
                table: "Analyses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Analyses_Labs_LabId",
                table: "Analyses");

            migrationBuilder.DropForeignKey(
                name: "FK_Analyses_Patients_PatientId",
                table: "Analyses");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Analyses_PatientId",
                table: "Analyses");

            migrationBuilder.DropColumn(
                name: "LablId",
                table: "Analyses");

            migrationBuilder.AlterColumn<int>(
                name: "LabId",
                table: "Analyses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Analyses_Labs_LabId",
                table: "Analyses",
                column: "LabId",
                principalTable: "Labs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

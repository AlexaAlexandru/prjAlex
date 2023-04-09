using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchedulePlatform.Data.Migrations
{
    public partial class ServiceProvidedAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ServiceProvidedId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceProvidedId",
                table: "Appointments",
                column: "ServiceProvidedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Services_ServiceProvidedId",
                table: "Appointments",
                column: "ServiceProvidedId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Services_ServiceProvidedId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceProvidedId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceProvidedId",
                table: "Appointments");
        }
    }
}

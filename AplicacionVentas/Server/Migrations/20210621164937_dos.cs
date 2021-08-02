using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AplicacionVentas.Server.Migrations
{
    public partial class dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Evidencias",
                keyColumn: "EvidenciaId",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "VentasTotal",
                columns: table => new
                {
                    VentaTotalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaCaptura = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasTotal", x => x.VentaTotalId);
                    table.ForeignKey(
                        name: "FK_VentasTotal_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61895af9-efc1-4a0a-b054-7bd9c884c11f",
                column: "ConcurrencyStamp",
                value: "9d1332cc-69cb-44d7-9875-d2004313469f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c71df716-43f7-4d8d-9862-bb1e53bdeab5",
                column: "ConcurrencyStamp",
                value: "88152c9d-025a-40dc-941b-db07c3da7dd8");

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1,
                columns: new[] { "FechaCaptura", "FechaVenta" },
                values: new object[] { new DateTime(2021, 6, 21, 11, 49, 36, 896, DateTimeKind.Local).AddTicks(2801), new DateTime(2021, 6, 21, 11, 49, 36, 894, DateTimeKind.Local).AddTicks(1695) });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 2,
                columns: new[] { "FechaCaptura", "FechaVenta" },
                values: new object[] { new DateTime(2021, 6, 21, 11, 49, 36, 896, DateTimeKind.Local).AddTicks(3094), new DateTime(2021, 6, 21, 11, 49, 36, 896, DateTimeKind.Local).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 3,
                columns: new[] { "FechaCaptura", "FechaVenta" },
                values: new object[] { new DateTime(2021, 6, 21, 11, 49, 36, 896, DateTimeKind.Local).AddTicks(3100), new DateTime(2021, 6, 21, 11, 49, 36, 896, DateTimeKind.Local).AddTicks(3098) });

            migrationBuilder.CreateIndex(
                name: "IX_VentasTotal_EmpleadoId",
                table: "VentasTotal",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentasTotal");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61895af9-efc1-4a0a-b054-7bd9c884c11f",
                column: "ConcurrencyStamp",
                value: "57795459-2352-4255-a601-e6d7eeb3dd39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c71df716-43f7-4d8d-9862-bb1e53bdeab5",
                column: "ConcurrencyStamp",
                value: "3a1776c3-d73e-4774-9982-5ebe050a677b");

            migrationBuilder.InsertData(
                table: "Evidencias",
                columns: new[] { "EvidenciaId", "EmpleadoId", "FechaCaptura", "Foto" },
                values: new object[] { 1, 1, new DateTime(2021, 6, 14, 17, 40, 59, 42, DateTimeKind.Local).AddTicks(1423), "TestURL" });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1,
                columns: new[] { "FechaCaptura", "FechaVenta" },
                values: new object[] { new DateTime(2021, 6, 14, 17, 40, 59, 42, DateTimeKind.Local).AddTicks(207), new DateTime(2021, 6, 14, 17, 40, 59, 40, DateTimeKind.Local).AddTicks(482) });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 2,
                columns: new[] { "FechaCaptura", "FechaVenta" },
                values: new object[] { new DateTime(2021, 6, 14, 17, 40, 59, 42, DateTimeKind.Local).AddTicks(464), new DateTime(2021, 6, 14, 17, 40, 59, 42, DateTimeKind.Local).AddTicks(457) });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 3,
                columns: new[] { "FechaCaptura", "FechaVenta" },
                values: new object[] { new DateTime(2021, 6, 14, 17, 40, 59, 42, DateTimeKind.Local).AddTicks(470), new DateTime(2021, 6, 14, 17, 40, 59, 42, DateTimeKind.Local).AddTicks(467) });
        }
    }
}

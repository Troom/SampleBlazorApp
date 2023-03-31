using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "AdditionalInfo", "ClientName", "CreateDate", "OrderPrice", "Status" },
                values: new object[,]
                {
                    { 1L, "", "John", new DateTime(2023, 3, 31, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4350), 2m, 1 },
                    { 2L, "", "Client2", new DateTime(2023, 3, 30, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4411), 1m, 2 },
                    { 3L, "", "Client3", new DateTime(2023, 3, 29, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4416), 1m, 3 },
                    { 4L, "", "Client4", new DateTime(2023, 3, 28, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4418), 1m, 1 },
                    { 5L, "", "Client5", new DateTime(2023, 3, 27, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4420), 1m, 2 },
                    { 6L, "", "Client6", new DateTime(2023, 3, 26, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4422), 1m, 3 },
                    { 7L, "", "Client7", new DateTime(2023, 3, 25, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4424), 1m, 2 },
                    { 8L, "", "Client8", new DateTime(2023, 3, 24, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4426), 1m, 1 },
                    { 9L, "", "Client9", new DateTime(2023, 3, 23, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4427), 1m, 4 },
                    { 10L, "", "Client10", new DateTime(2023, 3, 22, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4429), 1m, 1 },
                    { 11L, "", "Client11", new DateTime(2023, 3, 21, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4432), 1m, 2 },
                    { 12L, "", "Client12", new DateTime(2023, 3, 20, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4433), 1m, 1 },
                    { 13L, "", "Client13", new DateTime(2023, 3, 19, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4435), 1m, 1 },
                    { 14L, "", "Client14", new DateTime(2023, 3, 18, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4437), 1m, 2 },
                    { 15L, "", "Client15", new DateTime(2023, 3, 17, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4438), 1m, 1 },
                    { 16L, "", "Client16", new DateTime(2023, 3, 16, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4440), 1m, 4 }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "OrderId", "Price", "Product" },
                values: new object[,]
                {
                    { 1, 1L, 1m, "P1" },
                    { 2, 1L, 1m, "P2" },
                    { 3, 2L, 1m, "P2" },
                    { 4, 3L, 1m, "P2" },
                    { 5, 4L, 1m, "P2" },
                    { 6, 5L, 1m, "P2" },
                    { 7, 6L, 1m, "P2" },
                    { 8, 7L, 1m, "P2" },
                    { 9, 8L, 1m, "P2" },
                    { 10, 9L, 1m, "P2" },
                    { 11, 10L, 1m, "P2" },
                    { 12, 11L, 1m, "P2" },
                    { 13, 12L, 1m, "P2" },
                    { 14, 13L, 1m, "P2" },
                    { 15, 14L, 1m, "P2" },
                    { 16, 15L, 1m, "P2" },
                    { 17, 16L, 1m, "P2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}

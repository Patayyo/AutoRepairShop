using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoRepairShop.Infrastructure.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    StateNumbers = table.Column<string>(type: "TEXT", nullable: false),
                    Engine = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Engine = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarWorkHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeOfWorkId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InWork = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    OutWork = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWorkHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWorkHistories_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarWorkHistories_TypeOfWorks_TypeOfWorkId",
                        column: x => x.TypeOfWorkId,
                        principalTable: "TypeOfWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Engine", "Model", "StateNumbers" },
                values: new object[,]
                {
                    { new Guid("14697994-81cd-4cc6-8883-be08faa58e1c"), "Audi", 0, "TT", "А047ЕВ66" },
                    { new Guid("53df9d76-1da1-4fe9-91a3-38ca179c1841"), "Toyota", 0, "Mark 2", "А002АС" },
                    { new Guid("742784a0-70c0-4004-820a-22b2c2670945"), "Opel", 1, "Astra", "М033ЕЕ" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfWorks",
                columns: new[] { "Id", "Engine", "Name" },
                values: new object[,]
                {
                    { new Guid("8989a114-77f2-4af5-8e6c-a04980a691a5"), 0, "Проверка компрессии в цилиндрах" },
                    { new Guid("d1414603-ea48-4bd4-b5bc-cb1d80994bf1"), 1, "Замена свечей накаливания" },
                    { new Guid("dbb5e317-e55f-4b84-ac7a-d6c8c43213d3"), 1, "Проверка компрессии в цилиндрах" },
                    { new Guid("dca90b74-0b77-47a0-88e9-141cfdb0b748"), 0, "Замена свечей зажигания" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_StateNumbers",
                table: "Cars",
                column: "StateNumbers",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarWorkHistories_CarId",
                table: "CarWorkHistories",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWorkHistories_TypeOfWorkId",
                table: "CarWorkHistories",
                column: "TypeOfWorkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarWorkHistories");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "TypeOfWorks");
        }
    }
}

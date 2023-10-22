using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prooductbrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prooductbrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prooducttype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prooducttype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prooduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    producttypeid = table.Column<int>(type: "INTEGER", nullable: false),
                    productbrandid = table.Column<int>(type: "INTEGER", nullable: false),
                    pictureurl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prooduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prooduct_prooductbrand_productbrandid",
                        column: x => x.productbrandid,
                        principalTable: "prooductbrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prooduct_prooducttype_producttypeid",
                        column: x => x.producttypeid,
                        principalTable: "prooducttype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prooduct_productbrandid",
                table: "prooduct",
                column: "productbrandid");

            migrationBuilder.CreateIndex(
                name: "IX_prooduct_producttypeid",
                table: "prooduct",
                column: "producttypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prooduct");

            migrationBuilder.DropTable(
                name: "prooductbrand");

            migrationBuilder.DropTable(
                name: "prooducttype");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaBP.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    INT_CLIECODIGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VCH_CLIENOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VCH_CLIEAPELLIDO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VCH_CLIECEDULA = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    VCH_CLIEDIRECCION = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    VCH_CLIETELEFONO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    VCH_CLIEEMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.INT_CLIECODIGO)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    INT_USUCODIGO = table.Column<int>(type: "int", nullable: false),
                    VCH_USUNOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VCH_USUAPELLIDO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VCH_USUCEDULA = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    VCH_USUDIRECCION = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    VCH_USUTELEFONO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    VCH_USUEMAIL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    VCH_USUUSUARIO = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    VCH_USUPASSWORD = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    VCH_ROL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.INT_USUCODIGO)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "CUENTA",
                columns: table => new
                {
                    INT_CUENCODIGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INT_CLIECODIGO = table.Column<int>(type: "int", nullable: false),
                    VCH_CUENNUMERO = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    VCH_CUENTIPO = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    DEC_CUENSALDO = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    DTT_CUENFECHACREACION = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUENTA", x => x.INT_CUENCODIGO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CUENTA_RELATIONS_CLIENTE",
                        column: x => x.INT_CLIECODIGO,
                        principalTable: "CLIENTE",
                        principalColumn: "INT_CLIECODIGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMIENTO",
                columns: table => new
                {
                    INT_MOVICODIGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INT_CUENCODIGO = table.Column<int>(type: "int", nullable: false),
                    DTT_MOVIFECHA = table.Column<DateTime>(type: "datetime", nullable: true),
                    VCH_MOVITIPO = table.Column<string>(type: "char(64)", unicode: false, fixedLength: true, maxLength: 64, nullable: true),
                    DEC_MOVIVALOR = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    DEC_MOVISALDOFINAL = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    VCH_MOVICUENTORIG = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    VCH_MOVICUENTDEST = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMIENTO", x => x.INT_MOVICODIGO)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_MOVIMIEN_RELATIONS_CUENTA",
                        column: x => x.INT_CUENCODIGO,
                        principalTable: "CUENTA",
                        principalColumn: "INT_CUENCODIGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_1_FK",
                table: "CUENTA",
                column: "INT_CLIECODIGO");

            migrationBuilder.CreateIndex(
                name: "RELATIONSHIP_2_FK",
                table: "MOVIMIENTO",
                column: "INT_CUENCODIGO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOVIMIENTO");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "CUENTA");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}

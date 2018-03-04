using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PVT.Money.Data.Migrations
{
    public partial class Homework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: false),
                    LocalCurrency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LangId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lang = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LangId);
                });

            migrationBuilder.CreateTable(
                name: "CountriesLangsEntity",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    LangId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesLangsEntity", x => new { x.CountryId, x.LangId });
                    table.ForeignKey(
                        name: "FK_CountriesLangsEntity_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountriesLangsEntity_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "LangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountriesLangsEntity_LangId",
                table: "CountriesLangsEntity",
                column: "LangId");


            //migrationBuilder.Sql("INSERT INTO dbo.UserRoles (Description, Role) VALUES   ('Admin','Admin')");
            //migrationBuilder.Sql("INSERT INTO dbo.UserRoles (Description, Role) VALUES   ('User','User')");
            //migrationBuilder.Sql("INSERT INTO dbo.UserRoles (Description, Role) VALUES   ('VIP','VIP')");
            //migrationBuilder.Sql("INSERT INTO dbo.Permissions (Rules) VALUES   ('Edit')");
            //migrationBuilder.Sql("INSERT INTO dbo.Permissions (Rules) VALUES   ('Add')");
            //migrationBuilder.Sql("INSERT INTO dbo.Permissions (Rules) VALUES   ('Delete')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountriesLangsEntity");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}

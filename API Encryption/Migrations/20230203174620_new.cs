using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEncryption.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loginclass");

            migrationBuilder.CreateTable(
                name: "LoginUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(150)", nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", nullable: false),
                    CreationTime = table.Column<DateTime>(name: "Creation_Time", type: "datetime2", nullable: false),
                    UpdationTime = table.Column<DateTime>(name: "Updation_Time", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUsers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginUsers");

            migrationBuilder.CreateTable(
                name: "loginclass",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(name: "Creation_Time", type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", nullable: false),
                    UpdationTime = table.Column<DateTime>(name: "Updation_Time", type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loginclass", x => x.id);
                });
        }
    }
}

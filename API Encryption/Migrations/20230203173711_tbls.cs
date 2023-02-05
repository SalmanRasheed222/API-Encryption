using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIEncryption.Migrations
{
    /// <inheritdoc />
    public partial class tbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_logintbl",
                table: "logintbl");

            migrationBuilder.RenameTable(
                name: "logintbl",
                newName: "loginclass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_loginclass",
                table: "loginclass",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_loginclass",
                table: "loginclass");

            migrationBuilder.RenameTable(
                name: "loginclass",
                newName: "logintbl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logintbl",
                table: "logintbl",
                column: "id");
        }
    }
}

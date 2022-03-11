using Microsoft.EntityFrameworkCore.Migrations;

namespace onlinebookstore.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "Zip",
            //    table: "Checkouts",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "TEXT");

            //migrationBuilder.AlterColumn<string>(
            //    name: "AddressLine2",
            //    table: "Checkouts",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "TEXT");

            migrationBuilder.AddColumn<bool>(
                name: "OrderShipped",
                table: "Checkouts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderShipped",
                table: "Checkouts");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Checkouts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Checkouts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

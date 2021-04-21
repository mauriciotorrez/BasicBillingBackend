using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicBilling.API.Migrations
{
    public partial class BasicBillingFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Period = table.Column<int>(maxLength: 25, nullable: false),
                    Category_Id = table.Column<int>(nullable: false),
                    BillStatus_Id = table.Column<int>(nullable: false),
                    Client_Id = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "BillStatuses",
                columns: table => new
                {
                    BillStatusId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatuses", x => x.BillStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PayId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Period = table.Column<int>(maxLength: 25, nullable: false),
                    Category_Id = table.Column<int>(nullable: false),
                    Client_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PayId);
                });

            migrationBuilder.InsertData(
                table: "BillStatuses",
                columns: new[] { "BillStatusId", "Status" },
                values: new object[] { 2, "Paid" });

            migrationBuilder.InsertData(
                table: "BillStatuses",
                columns: new[] { "BillStatusId", "Status" },
                values: new object[] { 1, "Pending" });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 1, 0.0, 2, 1, 1, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 34, 0.0, 2, 3, 3, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 35, 0.0, 1, 3, 3, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 36, 0.0, 1, 3, 3, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 37, 0.0, 2, 1, 4, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 38, 0.0, 2, 1, 4, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 39, 0.0, 1, 1, 4, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 40, 0.0, 1, 1, 4, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 41, 0.0, 2, 2, 4, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 42, 0.0, 2, 2, 4, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 43, 0.0, 1, 2, 4, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 44, 0.0, 1, 2, 4, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 45, 0.0, 2, 3, 4, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 46, 0.0, 2, 3, 4, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 47, 0.0, 1, 3, 4, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 48, 0.0, 1, 3, 4, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 49, 0.0, 2, 1, 5, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 51, 0.0, 1, 1, 5, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 52, 0.0, 1, 1, 5, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 53, 0.0, 2, 2, 5, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 54, 0.0, 2, 2, 5, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 55, 0.0, 1, 2, 5, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 56, 0.0, 1, 2, 5, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 57, 0.0, 2, 3, 5, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 58, 0.0, 2, 3, 5, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 59, 0.0, 1, 3, 5, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 60, 0.0, 1, 3, 5, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 33, 0.0, 2, 3, 3, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 32, 0.0, 1, 2, 3, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 50, 0.0, 2, 1, 5, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 30, 0.0, 2, 2, 3, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 2, 0.0, 2, 1, 1, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 3, 0.0, 1, 1, 1, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 4, 0.0, 1, 1, 1, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 5, 0.0, 2, 2, 1, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 6, 0.0, 2, 2, 1, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 7, 0.0, 1, 2, 1, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 8, 0.0, 1, 2, 1, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 9, 0.0, 2, 3, 1, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 10, 0.0, 2, 3, 1, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 11, 0.0, 1, 3, 1, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 12, 0.0, 1, 3, 1, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 13, 0.0, 2, 1, 2, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 31, 0.0, 1, 2, 3, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 15, 0.0, 1, 1, 2, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 14, 0.0, 2, 1, 2, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 24, 0.0, 1, 3, 2, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 17, 0.0, 2, 2, 2, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 18, 0.0, 2, 2, 2, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 19, 0.0, 1, 2, 2, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 20, 0.0, 1, 2, 2, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 21, 0.0, 2, 3, 2, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 22, 0.0, 2, 3, 2, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 23, 0.0, 1, 3, 2, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 16, 0.0, 1, 1, 2, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 25, 0.0, 2, 1, 3, 202101 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 26, 0.0, 2, 1, 3, 202102 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 27, 0.0, 1, 1, 3, 202103 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 28, 0.0, 1, 1, 3, 202104 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "BillId", "Amount", "BillStatus_Id", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 29, 0.0, 2, 2, 3, 202101 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "ELECTRICITY" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "WATER" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "SEWER" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[] { 5, " Charles Johnson" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[] { 4, "Jessica Phillips" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[] { 1, "Joseph Carlton" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[] { 2, "Maria Juarez" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[] { 3, "Albert Kenny" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 28, 2, 5, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 27, 2, 5, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 26, 1, 5, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 25, 1, 5, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 24, 3, 4, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 23, 3, 4, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 22, 2, 4, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 21, 2, 4, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 20, 1, 4, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 19, 1, 4, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 18, 3, 3, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 17, 3, 3, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 16, 2, 3, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 15, 2, 3, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 14, 1, 3, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 12, 3, 2, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 11, 3, 2, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 10, 2, 2, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 9, 2, 2, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 8, 1, 2, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 7, 1, 2, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 6, 3, 1, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 5, 3, 1, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 4, 2, 1, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 3, 2, 1, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 2, 1, 1, 202102 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 1, 1, 1, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 29, 3, 5, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 13, 1, 3, 202101 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PayId", "Category_Id", "Client_Id", "Period" },
                values: new object[] { 30, 3, 5, 202102 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "BillStatuses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}

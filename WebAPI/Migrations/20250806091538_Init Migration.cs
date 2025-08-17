using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrativeDivisions",
                columns: table => new
                {
                    AdministrativeDivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeDivisions", x => x.AdministrativeDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    AdministrativeDivisionId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bags",
                columns: table => new
                {
                    BagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bags", x => x.BagId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beds = table.Column<int>(type: "int", nullable: false),
                    UsedBeds = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BagId = table.Column<int>(type: "int", nullable: false),
                    AdministrativeDivisionId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateBeforeActoin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateAfterAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Capital", "Code", "Continent", "CreatedAt", "Currency", "FlagUrl", "Language", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Kabul", "AF", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AFN", "https://flagcdn.com/af.svg", "Pashto/Dari", "Afghanistan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Tirana", "AL", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALL", "https://flagcdn.com/al.svg", "Albanian", "Albania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Algiers", "DZ", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DZD", "https://flagcdn.com/dz.svg", "Arabic/Berber", "Algeria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Andorra la Vella", "AD", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/ad.svg", "Catalan", "Andorra", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Luanda", "AO", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AOA", "https://flagcdn.com/ao.svg", "Portuguese", "Angola", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "St. John's", "AG", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "https://flagcdn.com/ag.svg", "English", "Antigua and Barbuda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Buenos Aires", "AR", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARS", "https://flagcdn.com/ar.svg", "Spanish", "Argentina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Yerevan", "AM", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMD", "https://flagcdn.com/am.svg", "Armenian", "Armenia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Canberra", "AU", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "https://flagcdn.com/au.svg", "English", "Australia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Vienna", "AT", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/at.svg", "German", "Austria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Baku", "AZ", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AZN", "https://flagcdn.com/az.svg", "Azerbaijani", "Azerbaijan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Nassau", "BS", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BSD", "https://flagcdn.com/bs.svg", "English", "Bahamas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Manama", "BH", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BHD", "https://flagcdn.com/bh.svg", "Arabic", "Bahrain", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Dhaka", "BD", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BDT", "https://flagcdn.com/bd.svg", "Bengali", "Bangladesh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Bridgetown", "BB", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BBD", "https://flagcdn.com/bb.svg", "English", "Barbados", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Minsk", "BY", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BYN", "https://flagcdn.com/by.svg", "Belarusian/Russian", "Belarus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Brussels", "BE", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/be.svg", "Dutch/French/German", "Belgium", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Belmopan", "BZ", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BZD", "https://flagcdn.com/bz.svg", "English", "Belize", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Porto-Novo", "BJ", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/bj.svg", "French", "Benin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Thimphu", "BT", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BTN", "https://flagcdn.com/bt.svg", "Dzongkha", "Bhutan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "Sucre", "BO", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOB", "https://flagcdn.com/bo.svg", "Spanish/Aymara/Quechua", "Bolivia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "Sarajevo", "BA", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAM", "https://flagcdn.com/ba.svg", "Bosnian/Croatian/Serbian", "Bosnia and Herzegovina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "Gaborone", "BW", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BWP", "https://flagcdn.com/bw.svg", "English/Tswana", "Botswana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "Brasília", "BR", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRL", "https://flagcdn.com/br.svg", "Portuguese", "Brazil", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "Bandar Seri Begawan", "BN", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BND", "https://flagcdn.com/bn.svg", "Malay", "Brunei", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "Sofia", "BG", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BGN", "https://flagcdn.com/bg.svg", "Bulgarian", "Bulgaria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "Ouagadougou", "BF", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/bf.svg", "French", "Burkina Faso", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "Gitega", "BI", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIF", "https://flagcdn.com/bi.svg", "Kirundi/French/English", "Burundi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "Praia", "CV", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CVE", "https://flagcdn.com/cv.svg", "Portuguese", "Cabo Verde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "Phnom Penh", "KH", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KHR", "https://flagcdn.com/kh.svg", "Khmer", "Cambodia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, "Yaoundé", "CM", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "https://flagcdn.com/cm.svg", "French/English", "Cameroon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, "Ottawa", "CA", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAD", "https://flagcdn.com/ca.svg", "English/French", "Canada", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, "Bangui", "CF", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "https://flagcdn.com/cf.svg", "French/Sango", "Central African Republic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, "N'Djamena", "TD", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "https://flagcdn.com/td.svg", "French/Arabic", "Chad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, "Santiago", "CL", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLP", "https://flagcdn.com/cl.svg", "Spanish", "Chile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, "Beijing", "CN", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNY", "https://flagcdn.com/cn.svg", "Chinese", "China", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, "Bogotá", "CO", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "COP", "https://flagcdn.com/co.svg", "Spanish", "Colombia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "Moroni", "KM", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KMF", "https://flagcdn.com/km.svg", "Comorian/Arabic/French", "Comoros", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "Brazzaville", "CG", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "https://flagcdn.com/cg.svg", "French/Lingala", "Congo (Congo-Brazzaville)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "Kinshasa", "CD", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CDF", "https://flagcdn.com/cd.svg", "French/Lingala/Kikongo/Swahili/Tshiluba", "Congo (Congo-Kinshasa)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, "San José", "CR", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRC", "https://flagcdn.com/cr.svg", "Spanish", "Costa Rica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, "Yamoussoukro", "CI", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/ci.svg", "French", "Côte d'Ivoire", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "Zagreb", "HR", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/hr.svg", "Croatian", "Croatia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Havana", "CU", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CUP", "https://flagcdn.com/cu.svg", "Spanish", "Cuba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Nicosia", "CY", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/cy.svg", "Greek/Turkish", "Cyprus", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "Prague", "CZ", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CZK", "https://flagcdn.com/cz.svg", "Czech", "Czechia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Copenhagen", "DK", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DKK", "https://flagcdn.com/dk.svg", "Danish", "Denmark", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Djibouti", "DJ", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DJF", "https://flagcdn.com/dj.svg", "French/Arabic", "Djibouti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Roseau", "DM", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "https://flagcdn.com/dm.svg", "English", "Dominica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Santo Domingo", "DO", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOP", "https://flagcdn.com/do.svg", "Spanish", "Dominican Republic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Quito", "EC", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "https://flagcdn.com/ec.svg", "Spanish", "Ecuador", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "Cairo", "EG", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EGP", "https://flagcdn.com/eg.svg", "Arabic", "Egypt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "San Salvador", "SV", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "https://flagcdn.com/sv.svg", "Spanish", "El Salvador", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, "Malabo", "GQ", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "https://flagcdn.com/gq.svg", "Spanish/French/Portuguese", "Equatorial Guinea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, "Asmara", "ER", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERN", "https://flagcdn.com/er.svg", "Tigrinya/Arabic/English", "Eritrea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, "Tallinn", "EE", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/ee.svg", "Estonian", "Estonia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, "Mbabane", "SZ", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SZL", "https://flagcdn.com/sz.svg", "Swazi/English", "Eswatini", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, "Addis Ababa", "ET", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ETB", "https://flagcdn.com/et.svg", "Amharic", "Ethiopia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, "Suva", "FJ", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FJD", "https://flagcdn.com/fj.svg", "English/Fijian/Hindi", "Fiji", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, "Helsinki", "FI", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/fi.svg", "Finnish/Swedish", "Finland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, "Paris", "FR", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/fr.svg", "French", "France", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, "Libreville", "GA", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XAF", "https://flagcdn.com/ga.svg", "French", "Gabon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, "Banjul", "GM", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GMD", "https://flagcdn.com/gm.svg", "English", "Gambia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, "Tbilisi", "GE", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEL", "https://flagcdn.com/ge.svg", "Georgian", "Georgia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, "Berlin", "DE", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/de.svg", "German", "Germany", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, "Accra", "GH", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GHS", "https://flagcdn.com/gh.svg", "English", "Ghana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, "Athens", "GR", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/gr.svg", "Greek", "Greece", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, "St. George's", "GD", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "https://flagcdn.com/gd.svg", "English", "Grenada", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, "Guatemala City", "GT", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GTQ", "https://flagcdn.com/gt.svg", "Spanish", "Guatemala", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, "Conakry", "GN", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GNF", "https://flagcdn.com/gn.svg", "French", "Guinea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, "Bissau", "GW", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/gw.svg", "Portuguese", "Guinea-Bissau", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, "Georgetown", "GY", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GYD", "https://flagcdn.com/gy.svg", "English", "Guyana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, "Port-au-Prince", "HT", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTG", "https://flagcdn.com/ht.svg", "French/Haitian Creole", "Haiti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, "Tegucigalpa", "HN", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HNL", "https://flagcdn.com/hn.svg", "Spanish", "Honduras", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, "Budapest", "HU", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HUF", "https://flagcdn.com/hu.svg", "Hungarian", "Hungary", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, "Reykjavik", "IS", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISK", "https://flagcdn.com/is.svg", "Icelandic", "Iceland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, "New Delhi", "IN", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "INR", "https://flagcdn.com/in.svg", "Hindi/English", "India", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, "Jakarta", "ID", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IDR", "https://flagcdn.com/id.svg", "Indonesian", "Indonesia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, "Tehran", "IR", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IRR", "https://flagcdn.com/ir.svg", "Persian", "Iran", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, "Baghdad", "IQ", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IQD", "https://flagcdn.com/iq.svg", "Arabic/Kurdish", "Iraq", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, "Dublin", "IE", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/ie.svg", "Irish/English", "Ireland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, "Jerusalem", "IL", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ILS", "https://flagcdn.com/il.svg", "Hebrew/Arabic", "Israel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, "Rome", "IT", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/it.svg", "Italian", "Italy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, "Kingston", "JM", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JMD", "https://flagcdn.com/jm.svg", "English", "Jamaica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, "Tokyo", "JP", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPY", "https://flagcdn.com/jp.svg", "Japanese", "Japan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, "Amman", "JO", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JOD", "https://flagcdn.com/jo.svg", "Arabic", "Jordan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, "Astana", "KZ", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KZT", "https://flagcdn.com/kz.svg", "Kazakh/Russian", "Kazakhstan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, "Nairobi", "KE", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KES", "https://flagcdn.com/ke.svg", "English/Swahili", "Kenya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, "Tarawa", "KI", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "https://flagcdn.com/ki.svg", "English", "Kiribati", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, "Kuwait City", "KW", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KWD", "https://flagcdn.com/kw.svg", "Arabic", "Kuwait", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, "Bishkek", "KG", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KGS", "https://flagcdn.com/kg.svg", "Kyrgyz/Russian", "Kyrgyzstan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, "Vientiane", "LA", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LAK", "https://flagcdn.com/la.svg", "Lao", "Laos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, "Riga", "LV", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/lv.svg", "Latvian", "Latvia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, "Beirut", "LB", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LBP", "https://flagcdn.com/lb.svg", "Arabic", "Lebanon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, "Maseru", "LS", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LSL", "https://flagcdn.com/ls.svg", "English/Sesotho", "Lesotho", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, "Monrovia", "LR", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LRD", "https://flagcdn.com/lr.svg", "English", "Liberia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, "Tripoli", "LY", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LYD", "https://flagcdn.com/ly.svg", "Arabic", "Libya", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, "Vaduz", "LI", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHF", "https://flagcdn.com/li.svg", "German", "Liechtenstein", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, "Vilnius", "LT", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/lt.svg", "Lithuanian", "Lithuania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, "Luxembourg", "LU", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/lu.svg", "Luxembourgish/French/German", "Luxembourg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, "Antananarivo", "MG", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MGA", "https://flagcdn.com/mg.svg", "Malagasy/French", "Madagascar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, "Lilongwe", "MW", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MWK", "https://flagcdn.com/mw.svg", "English/Chichewa", "Malawi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, "Kuala Lumpur", "MY", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MYR", "https://flagcdn.com/my.svg", "Malay", "Malaysia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, "Malé", "MV", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MVR", "https://flagcdn.com/mv.svg", "Dhivehi", "Maldives", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, "Bamako", "ML", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/ml.svg", "French", "Mali", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, "Valletta", "MT", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/mt.svg", "Maltese/English", "Malta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, "Majuro", "MH", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "https://flagcdn.com/mh.svg", "Marshallese/English", "Marshall Islands", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, "Nouakchott", "MR", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MRU", "https://flagcdn.com/mr.svg", "Arabic", "Mauritania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, "Port Louis", "MU", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MUR", "https://flagcdn.com/mu.svg", "English/French", "Mauritius", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, "Mexico City", "MX", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MXN", "https://flagcdn.com/mx.svg", "Spanish", "Mexico", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, "Palikir", "FM", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "https://flagcdn.com/fm.svg", "English", "Micronesia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, "Chisinau", "MD", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MDL", "https://flagcdn.com/md.svg", "Romanian", "Moldova", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 113, "Monaco", "MC", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/mc.svg", "French", "Monaco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 114, "Ulaanbaatar", "MN", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MNT", "https://flagcdn.com/mn.svg", "Mongolian", "Mongolia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115, "Podgorica", "ME", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/me.svg", "Montenegrin", "Montenegro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 116, "Rabat", "MA", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAD", "https://flagcdn.com/ma.svg", "Arabic/Berber", "Morocco", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 117, "Maputo", "MZ", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MZN", "https://flagcdn.com/mz.svg", "Portuguese", "Mozambique", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 118, "Naypyidaw", "MM", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MMK", "https://flagcdn.com/mm.svg", "Burmese", "Myanmar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119, "Windhoek", "NA", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NAD", "https://flagcdn.com/na.svg", "English", "Namibia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 120, "Yaren", "NR", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "https://flagcdn.com/nr.svg", "Nauruan/English", "Nauru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 121, "Kathmandu", "NP", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NPR", "https://flagcdn.com/np.svg", "Nepali", "Nepal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 122, "Amsterdam", "NL", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/nl.svg", "Dutch", "Netherlands", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123, "Wellington", "NZ", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZD", "https://flagcdn.com/nz.svg", "English/Māori", "New Zealand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 124, "Managua", "NI", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NIO", "https://flagcdn.com/ni.svg", "Spanish", "Nicaragua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125, "Niamey", "NE", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/ne.svg", "French", "Niger", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 126, "Abuja", "NG", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NGN", "https://flagcdn.com/ng.svg", "English", "Nigeria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 127, "Pyongyang", "KP", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KPW", "https://flagcdn.com/kp.svg", "Korean", "North Korea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 128, "Skopje", "MK", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MKD", "https://flagcdn.com/mk.svg", "Macedonian", "North Macedonia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 129, "Oslo", "NO", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NOK", "https://flagcdn.com/no.svg", "Norwegian", "Norway", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 130, "Muscat", "OM", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OMR", "https://flagcdn.com/om.svg", "Arabic", "Oman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 131, "Islamabad", "PK", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PKR", "https://flagcdn.com/pk.svg", "Urdu/English", "Pakistan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132, "Ngerulmud", "PW", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "https://flagcdn.com/pw.svg", "Palauan/English", "Palau", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133, "East Jerusalem", "PS", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ILS", "https://flagcdn.com/ps.svg", "Arabic", "Palestine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 134, "Panama City", "PA", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAB/USD", "https://flagcdn.com/pa.svg", "Spanish", "Panama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 135, "Port Moresby", "PG", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PGK", "https://flagcdn.com/pg.svg", "English/Hiri Motu/Tok Pisin", "Papua New Guinea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 136, "Asunción", "PY", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PYG", "https://flagcdn.com/py.svg", "Spanish/Guarani", "Paraguay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 137, "Lima", "PE", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PEN", "https://flagcdn.com/pe.svg", "Spanish/Quechua/Aymara", "Peru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 138, "Manila", "PH", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PHP", "https://flagcdn.com/ph.svg", "Filipino/English", "Philippines", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139, "Warsaw", "PL", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLN", "https://flagcdn.com/pl.svg", "Polish", "Poland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140, "Lisbon", "PT", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/pt.svg", "Portuguese", "Portugal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141, "Doha", "QA", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "QAR", "https://flagcdn.com/qa.svg", "Arabic", "Qatar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 142, "Bucharest", "RO", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RON", "https://flagcdn.com/ro.svg", "Romanian", "Romania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 143, "Moscow", "RU", "Europe/Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RUB", "https://flagcdn.com/ru.svg", "Russian", "Russia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 144, "Kigali", "RW", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RWF", "https://flagcdn.com/rw.svg", "Kinyarwanda/French/English", "Rwanda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145, "Basseterre", "KN", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "https://flagcdn.com/kn.svg", "English", "Saint Kitts and Nevis", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 146, "Castries", "LC", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "https://flagcdn.com/lc.svg", "English", "Saint Lucia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 147, "Kingstown", "VC", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XCD", "https://flagcdn.com/vc.svg", "English", "Saint Vincent and the Grenadines", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 148, "Apia", "WS", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WST", "https://flagcdn.com/ws.svg", "Samoan/English", "Samoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149, "San Marino", "SM", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/sm.svg", "Italian", "San Marino", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150, "São Tomé", "ST", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "STN", "https://flagcdn.com/st.svg", "Portuguese", "Sao Tome and Principe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 151, "Riyadh", "SA", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAR", "https://flagcdn.com/sa.svg", "Arabic", "Saudi Arabia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 152, "Dakar", "SN", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/sn.svg", "French", "Senegal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 153, "Belgrade", "RS", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RSD", "https://flagcdn.com/rs.svg", "Serbian", "Serbia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 154, "Victoria", "SC", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SCR", "https://flagcdn.com/sc.svg", "Seychellois Creole/English/French", "Seychelles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 155, "Freetown", "SL", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLL", "https://flagcdn.com/sl.svg", "English", "Sierra Leone", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 156, "Singapore", "SG", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SGD", "https://flagcdn.com/sg.svg", "English/Malay/Mandarin/Tamil", "Singapore", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 157, "Bratislava", "SK", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/sk.svg", "Slovak", "Slovakia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 158, "Ljubljana", "SI", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/si.svg", "Slovene", "Slovenia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 159, "Honiara", "SB", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SBD", "https://flagcdn.com/sb.svg", "English", "Solomon Islands", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 160, "Mogadishu", "SO", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SOS", "https://flagcdn.com/so.svg", "Somali/Arabic", "Somalia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 161, "Pretoria", "ZA", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZAR", "https://flagcdn.com/za.svg", "English/Afrikaans/Zulu", "South Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 162, "Seoul", "KR", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KRW", "https://flagcdn.com/kr.svg", "Korean", "South Korea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 163, "Juba", "SS", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSP", "https://flagcdn.com/ss.svg", "English", "South Sudan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 164, "Madrid", "ES", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/es.svg", "Spanish", "Spain", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 165, "Sri Jayawardenepura Kotte", "LK", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LKR", "https://flagcdn.com/lk.svg", "Sinhala/Tamil", "Sri Lanka", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 166, "Khartoum", "SD", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SDG", "https://flagcdn.com/sd.svg", "Arabic/English", "Sudan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 167, "Paramaribo", "SR", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SRD", "https://flagcdn.com/sr.svg", "Dutch", "Suriname", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 168, "Stockholm", "SE", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEK", "https://flagcdn.com/se.svg", "Swedish", "Sweden", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 169, "Bern", "CH", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHF", "https://flagcdn.com/ch.svg", "German/French/Italian/Romansh", "Switzerland", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 170, "Damascus", "SY", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SYP", "https://flagcdn.com/sy.svg", "Arabic", "Syria", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 171, "Dushanbe", "TJ", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TJS", "https://flagcdn.com/tj.svg", "Tajik", "Tajikistan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 172, "Dodoma", "TZ", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TZS", "https://flagcdn.com/tz.svg", "Swahili/English", "Tanzania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 173, "Bangkok", "TH", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "THB", "https://flagcdn.com/th.svg", "Thai", "Thailand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 174, "Dili", "TL", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "https://flagcdn.com/tl.svg", "Tetum/Portuguese", "Timor-Leste", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 175, "Lomé", "TG", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XOF", "https://flagcdn.com/tg.svg", "French", "Togo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 176, "Nukuʻalofa", "TO", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOP", "https://flagcdn.com/to.svg", "Tongan/English", "Tonga", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 177, "Port of Spain", "TT", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TTD", "https://flagcdn.com/tt.svg", "English", "Trinidad and Tobago", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 178, "Tunis", "TN", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TND", "https://flagcdn.com/tn.svg", "Arabic", "Tunisia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 179, "Ankara", "TR", "Europe/Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRY", "https://flagcdn.com/tr.svg", "Turkish", "Turkey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 180, "Ashgabat", "TM", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TMT", "https://flagcdn.com/tm.svg", "Turkmen", "Turkmenistan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181, "Funafuti", "TV", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "https://flagcdn.com/tv.svg", "Tuvaluan/English", "Tuvalu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 182, "Kampala", "UG", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UGX", "https://flagcdn.com/ug.svg", "English/Swahili", "Uganda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 183, "Kyiv", "UA", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UAH", "https://flagcdn.com/ua.svg", "Ukrainian", "Ukraine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 184, "Abu Dhabi", "AE", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AED", "https://flagcdn.com/ae.svg", "Arabic", "United Arab Emirates", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 185, "London", "GB", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", "https://flagcdn.com/gb.svg", "English", "United Kingdom", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 186, "Washington, D.C.", "US", "North America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "https://flagcdn.com/us.svg", "English", "United States", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 187, "Montevideo", "UY", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UYU", "https://flagcdn.com/uy.svg", "Spanish", "Uruguay", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 188, "Tashkent", "UZ", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UZS", "https://flagcdn.com/uz.svg", "Uzbek", "Uzbekistan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 189, "Port Vila", "VU", "Oceania", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VUV", "https://flagcdn.com/vu.svg", "Bislama/English/French", "Vanuatu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 190, "Vatican City", "VA", "Europe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "https://flagcdn.com/va.svg", "Italian/Latin", "Vatican City", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 191, "Caracas", "VE", "South America", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VES", "https://flagcdn.com/ve.svg", "Spanish", "Venezuela", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 192, "Hanoi", "VN", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VND", "https://flagcdn.com/vn.svg", "Vietnamese", "Vietnam", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 193, "Sana'a", "YE", "Asia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YER", "https://flagcdn.com/ye.svg", "Arabic", "Yemen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 194, "Lusaka", "ZM", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZMW", "https://flagcdn.com/zm.svg", "English", "Zambia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 195, "Harare", "ZW", "Africa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZWL", "https://flagcdn.com/zw.svg", "English/Shona/Sindebele", "Zimbabwe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministrativeDivisions");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bags");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

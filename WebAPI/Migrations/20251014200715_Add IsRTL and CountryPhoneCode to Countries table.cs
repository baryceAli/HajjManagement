using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRTLandCountryPhoneCodetoCountriestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryPhoneCode",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRTL",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+93", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+355", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+213", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+376", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 5,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+244", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 6,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1-268", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 7,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+54", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 8,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+374", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 9,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+61", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 10,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+43", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 11,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+994", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 12,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1-242", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 13,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+973", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 14,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+880", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 15,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1-246", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 16,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+375", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 17,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+32", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 18,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+501", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 19,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+229", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 20,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+975", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 21,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+591", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 22,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+387", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 23,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+267", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 24,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+55", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 25,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+673", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 26,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+359", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 27,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+226", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 28,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+257", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 29,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+238", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 30,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+855", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 31,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+237", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 32,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 33,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+236", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 34,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+235", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 35,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+56", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 36,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+86", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 37,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+57", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 38,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+269", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 39,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+242", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 40,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+243", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 41,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+506", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 42,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+225", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 43,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+385", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 44,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+53", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 45,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+357", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 46,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+420", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 47,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+45", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 48,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+253", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 49,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1-767", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 50,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1-809", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 51,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+593", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 52,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+20", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 53,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+503", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 54,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+240", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 55,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+291", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 56,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+372", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 57,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+268", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 58,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+251", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 59,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+679", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 60,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+358", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 61,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+33", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 62,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+241", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 63,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+220", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 64,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+995", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 65,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+49", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 66,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+233", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 67,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+30", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 68,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1-473", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 69,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+502", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 70,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+224", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 71,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+245", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 72,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+592", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 73,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+509", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 74,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+504", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 75,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+36", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 76,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+354", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 77,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+91", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 78,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+62", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 79,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+98", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 80,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+964", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 81,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+353", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 82,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+972", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 83,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+39", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 84,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1-876", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 85,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+81", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 86,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+962", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 87,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+7", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 88,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+254", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 89,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+686", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 90,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+965", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 91,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+996", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 92,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+856", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 93,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+371", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 94,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+961", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 95,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+266", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 96,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+231", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 97,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+218", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 98,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+423", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 99,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+370", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 100,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+352", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 101,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+261", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 102,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+265", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 103,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+60", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 104,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+960", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 105,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+223", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 106,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+356", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 107,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+692", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 108,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+222", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 109,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+230", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 110,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+52", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 111,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+691", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 112,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+373", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 113,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+377", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 114,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+976", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 115,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+382", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 116,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+212", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 117,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+258", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 118,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+95", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 119,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+264", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 120,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+674", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 121,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+977", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 122,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+31", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 123,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+64", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 124,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+505", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 125,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+227", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 126,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+234", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 127,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+850", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 128,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+389", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 129,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+47", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 130,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+968", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 131,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+92", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 132,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+680", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 133,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+970", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 134,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+507", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 135,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+675", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 136,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+595", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 137,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+51", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 138,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+63", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 139,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+48", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 140,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+351", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 141,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+974", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 142,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+40", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 143,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+7", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 144,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+250", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 145,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1869", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 146,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1758", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 147,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+1784", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 148,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+685", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 149,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+378", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 150,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "+239", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 151,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "966", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 152,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "221", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 153,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "381", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 154,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "248", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 155,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "232", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 156,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "65", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 157,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "421", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 158,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "386", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 159,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "677", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 160,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "252", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 161,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "27", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 162,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "82", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 163,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "211", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 164,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "34", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 165,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "94", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 166,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "249", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 167,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "597", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 168,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "46", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 169,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "41", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 170,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "963", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 171,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "992", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 172,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "255", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 173,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "66", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 174,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "670", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 175,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "228", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 176,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "676", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 177,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "1-868", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 178,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "216", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 179,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "90", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 180,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "993", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 181,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "688", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 182,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "256", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 183,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "380", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 184,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "971", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 185,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "44", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 186,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "1", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 187,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "598", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 188,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "998", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 189,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "678", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 190,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "39", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 191,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "58", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 192,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "84", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 193,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "967", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 194,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "260", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 195,
                columns: new[] { "CountryPhoneCode", "IsRTL" },
                values: new object[] { "263", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryPhoneCode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "IsRTL",
                table: "Countries");
        }
    }
}

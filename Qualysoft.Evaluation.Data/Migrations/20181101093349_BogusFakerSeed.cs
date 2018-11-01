using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualysoft.Evaluation.Data.Migrations
{
    public partial class BogusFakerSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 1, 9, 33, 48, 745, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 10, 31, 22, 20, 23, 270, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Name", "Visits" },
                values: new object[] { new DateTime(2018, 3, 23, 18, 39, 54, 47, DateTimeKind.Local), "Tyler Jaskolski", 982484765 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Name" },
                values: new object[] { new DateTime(2018, 6, 4, 6, 15, 38, 436, DateTimeKind.Local), "Craig Adams" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Requests",
                columns: new[] { "Id", "Date", "Name", "Visits" },
                values: new object[,]
                {
                    { 0, new DateTime(2018, 2, 27, 0, 19, 30, 400, DateTimeKind.Local), "Raymond Krajcik", 1793900487 },
                    { 72, new DateTime(2016, 8, 29, 10, 52, 45, 88, DateTimeKind.Local), "Jaydon Beier", null },
                    { 71, new DateTime(2017, 7, 27, 20, 45, 52, 713, DateTimeKind.Local), "Anissa Konopelski", null },
                    { 70, new DateTime(2016, 2, 29, 6, 33, 45, 955, DateTimeKind.Local), "Magdalen Welch", null },
                    { 69, new DateTime(2016, 3, 6, 13, 10, 25, 308, DateTimeKind.Local), "Julianne Reilly", 1741602539 },
                    { 68, new DateTime(2018, 2, 19, 2, 11, 2, 553, DateTimeKind.Local), "Amelia Bode", -540988167 },
                    { 67, new DateTime(2016, 3, 31, 3, 36, 39, 457, DateTimeKind.Local), "Vincenza Greenholt", 1173485223 },
                    { 66, new DateTime(2016, 6, 24, 16, 50, 9, 217, DateTimeKind.Local), "Muhammad Considine", 1642996289 },
                    { 65, new DateTime(2017, 8, 19, 15, 42, 33, 218, DateTimeKind.Local), "Noe Nader", -409225655 },
                    { 64, new DateTime(2018, 2, 19, 12, 15, 33, 851, DateTimeKind.Local), "Erin Kilback", 1926974441 },
                    { 63, new DateTime(2018, 5, 16, 0, 48, 42, 663, DateTimeKind.Local), "Rex Sauer", null },
                    { 62, new DateTime(2017, 5, 7, 14, 20, 2, 543, DateTimeKind.Local), "Madilyn Gislason", null },
                    { 61, new DateTime(2018, 1, 28, 20, 42, 49, 262, DateTimeKind.Local), "Roman Rath", -763985458 },
                    { 60, new DateTime(2018, 6, 29, 3, 2, 12, 940, DateTimeKind.Local), "Carli Hammes", 1600110950 },
                    { 59, new DateTime(2017, 3, 18, 2, 54, 58, 213, DateTimeKind.Local), "Stanford Johnston", 1682122981 },
                    { 58, new DateTime(2018, 9, 13, 8, 15, 50, 293, DateTimeKind.Local), "Lynn Torphy", -158765137 },
                    { 57, new DateTime(2016, 12, 21, 21, 8, 13, 564, DateTimeKind.Local), "Sierra Thompson", null },
                    { 56, new DateTime(2016, 5, 28, 10, 24, 15, 348, DateTimeKind.Local), "Hassie Predovic", -2057014908 },
                    { 55, new DateTime(2017, 6, 28, 4, 18, 42, 4, DateTimeKind.Local), "Josianne Hamill", null },
                    { 54, new DateTime(2016, 12, 30, 4, 47, 19, 616, DateTimeKind.Local), "Leone Kris", null },
                    { 53, new DateTime(2016, 12, 25, 5, 22, 2, 293, DateTimeKind.Local), "Dallin Hoppe", 114750922 },
                    { 73, new DateTime(2018, 10, 4, 13, 19, 31, 293, DateTimeKind.Local), "Frida Sauer", -976221554 },
                    { 74, new DateTime(2016, 12, 26, 15, 31, 7, 472, DateTimeKind.Local), "Herman Lang", null },
                    { 76, new DateTime(2016, 12, 4, 6, 45, 39, 630, DateTimeKind.Local), "Lily Hilll", 1365831145 },
                    { 52, new DateTime(2016, 11, 22, 13, 51, 53, 210, DateTimeKind.Local), "Ezra Hirthe", 768053090 },
                    { 97, new DateTime(2017, 5, 3, 6, 43, 52, 5, DateTimeKind.Local), "Wilbert Johnston", 1992575015 },
                    { 96, new DateTime(2018, 6, 26, 21, 43, 26, 844, DateTimeKind.Local), "Beverly Torphy", -771501248 },
                    { 95, new DateTime(2017, 10, 5, 17, 36, 56, 492, DateTimeKind.Local), "Keara Bednar", -1566633350 },
                    { 94, new DateTime(2017, 2, 4, 21, 23, 39, 364, DateTimeKind.Local), "Randal O'Reilly", null },
                    { 93, new DateTime(2018, 8, 8, 21, 37, 0, 734, DateTimeKind.Local), "Maximus Orn", null },
                    { 92, new DateTime(2018, 3, 5, 19, 13, 42, 468, DateTimeKind.Local), "Derrick Schuppe", null },
                    { 91, new DateTime(2016, 10, 31, 0, 3, 52, 539, DateTimeKind.Local), "Suzanne Rohan", null },
                    { 90, new DateTime(2017, 8, 1, 8, 15, 2, 414, DateTimeKind.Local), "Marietta Donnelly", 116908294 },
                    { 89, new DateTime(2016, 7, 31, 23, 38, 24, 480, DateTimeKind.Local), "Felicia Stiedemann", -202617306 },
                    { 88, new DateTime(2018, 8, 4, 8, 13, 42, 870, DateTimeKind.Local), "Ettie Kovacek", 604327308 },
                    { 87, new DateTime(2018, 10, 24, 23, 43, 51, 442, DateTimeKind.Local), "Trystan Waters", 331288287 },
                    { 86, new DateTime(2017, 4, 19, 23, 52, 28, 953, DateTimeKind.Local), "Camren Wilkinson", -1799000837 },
                    { 85, new DateTime(2018, 4, 20, 4, 29, 58, 544, DateTimeKind.Local), "Tyshawn Gutkowski", null },
                    { 84, new DateTime(2017, 7, 8, 14, 56, 0, 764, DateTimeKind.Local), "Reid Nienow", -197645456 },
                    { 83, new DateTime(2016, 10, 24, 20, 50, 13, 84, DateTimeKind.Local), "Madilyn Dibbert", 1670074457 },
                    { 82, new DateTime(2018, 1, 6, 15, 23, 22, 648, DateTimeKind.Local), "Floy Reynolds", -161318018 },
                    { 81, new DateTime(2016, 3, 21, 11, 23, 12, 685, DateTimeKind.Local), "Efrain Dietrich", null },
                    { 80, new DateTime(2016, 8, 21, 17, 18, 13, 636, DateTimeKind.Local), "Lorenza Brakus", null },
                    { 79, new DateTime(2018, 7, 26, 18, 21, 10, 945, DateTimeKind.Local), "Karson Doyle", null },
                    { 78, new DateTime(2018, 2, 18, 11, 57, 7, 385, DateTimeKind.Local), "Marjolaine Will", 1961307603 },
                    { 77, new DateTime(2016, 2, 7, 8, 3, 43, 441, DateTimeKind.Local), "Eulah Bartell", -509485414 },
                    { 75, new DateTime(2016, 11, 3, 15, 7, 27, 576, DateTimeKind.Local), "Katlynn Walker", null },
                    { 51, new DateTime(2018, 7, 2, 8, 44, 37, 510, DateTimeKind.Local), "Emily Hansen", null },
                    { 49, new DateTime(2017, 2, 22, 15, 51, 15, 129, DateTimeKind.Local), "Dejah Friesen", 612448141 },
                    { 98, new DateTime(2018, 10, 11, 5, 44, 59, 482, DateTimeKind.Local), "Nasir Dibbert", -1020991058 },
                    { 23, new DateTime(2017, 8, 31, 5, 35, 4, 180, DateTimeKind.Local), "Sandrine Johnston", null },
                    { 22, new DateTime(2017, 4, 14, 13, 32, 54, 832, DateTimeKind.Local), "Vinnie Homenick", 727393510 },
                    { 21, new DateTime(2018, 9, 2, 14, 59, 33, 702, DateTimeKind.Local), "Joseph Considine", null },
                    { 20, new DateTime(2018, 5, 23, 0, 54, 51, 458, DateTimeKind.Local), "Maurice Little", -1581725793 },
                    { 19, new DateTime(2016, 8, 10, 7, 26, 6, 52, DateTimeKind.Local), "Randal Toy", null },
                    { 18, new DateTime(2016, 9, 3, 5, 10, 24, 977, DateTimeKind.Local), "Antonietta Crooks", -121786424 },
                    { 17, new DateTime(2016, 4, 7, 2, 47, 20, 530, DateTimeKind.Local), "Leonel Willms", null },
                    { 16, new DateTime(2018, 9, 7, 15, 18, 48, 867, DateTimeKind.Local), "Zora Krajcik", null },
                    { 15, new DateTime(2017, 4, 4, 13, 5, 10, 366, DateTimeKind.Local), "Shany Windler", 728841488 },
                    { 14, new DateTime(2016, 2, 23, 0, 46, 6, 196, DateTimeKind.Local), "Max Bashirian", null },
                    { 13, new DateTime(2017, 7, 13, 12, 52, 55, 279, DateTimeKind.Local), "Keaton Johnson", -1461088251 },
                    { 12, new DateTime(2018, 7, 13, 4, 1, 42, 19, DateTimeKind.Local), "Jazlyn Goodwin", null },
                    { 11, new DateTime(2018, 6, 26, 11, 35, 42, 749, DateTimeKind.Local), "Marian Hayes", null },
                    { 10, new DateTime(2018, 2, 20, 13, 2, 28, 575, DateTimeKind.Local), "Khalil Gutkowski", 330794662 },
                    { 9, new DateTime(2018, 8, 18, 3, 47, 35, 140, DateTimeKind.Local), "Maximilian Kuhlman", null },
                    { 8, new DateTime(2017, 10, 26, 10, 14, 55, 147, DateTimeKind.Local), "Candida Heidenreich", null },
                    { 7, new DateTime(2016, 6, 29, 20, 41, 12, 821, DateTimeKind.Local), "Logan Hoeger", -1134962077 },
                    { 6, new DateTime(2017, 2, 12, 17, 8, 6, 549, DateTimeKind.Local), "Pierre Kohler", null },
                    { 5, new DateTime(2017, 12, 21, 23, 13, 0, 864, DateTimeKind.Local), "Brendon Nolan", -1877654022 },
                    { 4, new DateTime(2017, 9, 8, 19, 0, 49, 72, DateTimeKind.Local), "Ubaldo Wilderman", null },
                    { 3, new DateTime(2016, 9, 2, 21, 27, 6, 817, DateTimeKind.Local), "Angel Wyman", 704568224 },
                    { 24, new DateTime(2016, 12, 13, 10, 39, 9, 258, DateTimeKind.Local), "Leanna Shanahan", null },
                    { 50, new DateTime(2018, 1, 16, 23, 9, 0, 398, DateTimeKind.Local), "Jannie Schultz", -1865070130 },
                    { 25, new DateTime(2018, 10, 13, 21, 10, 57, 4, DateTimeKind.Local), "Noah Lubowitz", null },
                    { 27, new DateTime(2017, 2, 13, 23, 40, 48, 375, DateTimeKind.Local), "Erling Lesch", -1213902140 },
                    { 48, new DateTime(2018, 5, 24, 4, 56, 55, 554, DateTimeKind.Local), "Heidi Veum", null },
                    { 47, new DateTime(2016, 9, 7, 7, 23, 19, 965, DateTimeKind.Local), "Kennedi Berge", null },
                    { 46, new DateTime(2018, 4, 6, 14, 25, 43, 354, DateTimeKind.Local), "Leila Kovacek", -1226128067 },
                    { 45, new DateTime(2017, 11, 9, 21, 55, 9, 522, DateTimeKind.Local), "Bridgette Grant", null },
                    { 44, new DateTime(2018, 8, 27, 17, 28, 58, 686, DateTimeKind.Local), "Karine Stoltenberg", -1378594139 },
                    { 43, new DateTime(2018, 8, 31, 11, 51, 43, 971, DateTimeKind.Local), "Ubaldo Terry", null },
                    { 42, new DateTime(2016, 12, 24, 10, 22, 48, 973, DateTimeKind.Local), "Oma Rogahn", 1798217645 },
                    { 41, new DateTime(2017, 1, 30, 11, 52, 42, 388, DateTimeKind.Local), "Jaclyn Quigley", -671372334 },
                    { 40, new DateTime(2018, 1, 13, 18, 32, 57, 781, DateTimeKind.Local), "Adrianna Fadel", -1122084939 },
                    { 39, new DateTime(2018, 4, 4, 3, 2, 38, 31, DateTimeKind.Local), "Neoma Windler", null },
                    { 38, new DateTime(2016, 7, 19, 13, 11, 18, 925, DateTimeKind.Local), "Garrison Tromp", null },
                    { 37, new DateTime(2018, 7, 15, 16, 59, 26, 691, DateTimeKind.Local), "Zachary Oberbrunner", null },
                    { 36, new DateTime(2016, 10, 9, 7, 58, 8, 439, DateTimeKind.Local), "Rosendo McLaughlin", -1374900390 },
                    { 35, new DateTime(2016, 10, 23, 1, 49, 37, 110, DateTimeKind.Local), "Reilly Shanahan", null },
                    { 34, new DateTime(2016, 3, 5, 12, 40, 56, 404, DateTimeKind.Local), "Jillian Kozey", null },
                    { 33, new DateTime(2016, 10, 29, 9, 30, 44, 396, DateTimeKind.Local), "Gilbert Bashirian", null },
                    { 32, new DateTime(2017, 1, 10, 4, 52, 5, 588, DateTimeKind.Local), "Sean Hirthe", -2065987253 },
                    { 31, new DateTime(2016, 5, 13, 19, 49, 36, 174, DateTimeKind.Local), "Constance Donnelly", null },
                    { 30, new DateTime(2017, 2, 22, 12, 20, 40, 677, DateTimeKind.Local), "Niko Jenkins", 1582089799 },
                    { 29, new DateTime(2017, 7, 3, 19, 46, 31, 55, DateTimeKind.Local), "Sabryna Bradtke", -319243176 },
                    { 28, new DateTime(2016, 8, 2, 6, 7, 40, 271, DateTimeKind.Local), "Sunny Kozey", null },
                    { 26, new DateTime(2017, 1, 18, 14, 56, 1, 514, DateTimeKind.Local), "Wellington Swift", 1057909330 },
                    { 99, new DateTime(2017, 8, 15, 6, 52, 53, 129, DateTimeKind.Local), "Nayeli Upton", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(2018, 10, 31, 22, 20, 23, 270, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 1, 9, 33, 48, 745, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Name", "Visits" },
                values: new object[] { new DateTime(2018, 10, 31, 22, 20, 23, 271, DateTimeKind.Utc), "William Shakespeare", 13 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Name" },
                values: new object[] { new DateTime(2018, 11, 1, 0, 20, 23, 272, DateTimeKind.Local), "io" });
        }
    }
}

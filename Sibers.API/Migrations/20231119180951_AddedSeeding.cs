using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sibers.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "2ad76e65-7c86-4f99-a114-71f31273b7c4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "081dcfd8-12d8-4388-b7b4-daaf5976354e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "08f5de56-c928-439d-8104-3f59dae51200");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac381681-2ee4-474f-ba5c-f359da39bd92", "AQAAAAEAACcQAAAAEC+H9NDVp77SJd7LdAx11rIlinqohK78JwFVNJpOBSRLUxJZzI5pWvAfzVZd02VL4g==", "977e39d0-b9fb-4705-b16d-b0aae24f2d85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89ca9276-7d66-4367-b455-cd67f3cd6d46", "AQAAAAEAACcQAAAAEAtnhnUQP2l5RApCFK1mAyfnTEqUdtnPSCRVzHOJeQKWPWXiStM25S00O5/ivQXvtg==", "afa67302-7b0e-4381-bbce-10e573cdb7b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "693eab96-10fc-4c92-96a8-ff06bfa51924", "AQAAAAEAACcQAAAAEL7VxFq3oT7w8JdQo5VoC4S9RzWLpuQjK2Al6WAwGTf9K82yqU2aSMTswtJsHOtxgw==", "2b417e84-0612-4be0-b70f-dc37540d9ff6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9b1e3f1-b1bd-423f-bafd-f1f0f3e7a828", "AQAAAAEAACcQAAAAEOAYi8sYYsW5IkCzGGxNhILuQf3+seM53uxfG58e69X+N/ZEtowdEm8+Hjttmip4pQ==", "abf6738e-80c8-43f0-af13-e735268bf3a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8c7c87a-ddec-492a-a5d4-e3d5f6dc5d36", "AQAAAAEAACcQAAAAENUqp7TB7pSJZ8dXOxd4aceB2TN9mjAydTaaXZkRIp+oofPs0YvQgWvbeY+mpiakBA==", "cf645e9f-36d6-4cbc-b239-e19405a09f0a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "2e8e097b-975d-4a9c-a587-30051fb066a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "92dace57-1b87-4a16-b837-f17622ac7748");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "ce3b633c-caa3-4535-b480-ac244a9eabcf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f85c25ea-679e-4b99-9c77-0f5209414f86", "AQAAAAEAACcQAAAAEA0MF1FTgB4EVlmaART4tLMe+Ser7k83BumTKyv+FljZuq33XJQP23j87Asy/9I2WQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e10eca1c-3d6a-4c5e-b405-ca69479d897f", "AQAAAAEAACcQAAAAEHtQ58EX/cZ9DOZDeO6r5n4tqpWXCqQQyhgdg7BkkeoVnIFUxNZa9ktkvu8MJ1xbzg==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26a873a2-473a-4609-a431-76d10f592fe9", "AQAAAAEAACcQAAAAEMEA/5wflqdsAMjIISGSs7ZIdgOK7LCfmBsgq6wJ+tsJ98/CIGCiwsDCoFU7k0PyvA==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfe0fb58-0502-495a-85d9-a995d381e833", "AQAAAAEAACcQAAAAEEfh1EK1U3OgOKYTI9+psh5P3SHBdqoUIopMSMph+MvzzeK7wa5gfKHVJOfw/5vmbQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dcb1737-f140-4bc0-b1ff-bb936f8d4314", "AQAAAAEAACcQAAAAEHSNiKPupx0iFzsGraEsuK8R++AUsCjQjDXRn7Erd/8n4ZdLXwnCXiPc6RUtKf0kXQ==", null });
        }
    }
}

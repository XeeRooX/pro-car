using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProCar.Migrations
{
    public partial class AddDefaultContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactDetails",
                columns: new[] { "Id", "Address", "Email", "MapPoint", "PhoneNumber" },
                values: new object[] { 1, "г. Оренбург, ул. Одесская, 23", "proavtooren@yandex.ru", "https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3Ae15ba2ef1d406f5e87f54c6717959fd2adddc1f41e48301d66d7136c56266532&amp;width=100%25&amp;height=600&amp;lang=ru_RU&amp;scroll=false", "+7 969 749 00-43" });

            migrationBuilder.InsertData(
                table: "SocialNetworks",
                columns: new[] { "Id", "Icon", "Link", "Name" },
                values: new object[,]
                {
                    { 1, "telegram", "https://t.me/yandex_taxi23", "Телеграм" },
                    { 2, "whatsapp", "https://wa.me/79697490043", "whats app" },
                    { 3, "instagram", "https://www.instagram.com/fgfdg", "instagram" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SocialNetworks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SocialNetworks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SocialNetworks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

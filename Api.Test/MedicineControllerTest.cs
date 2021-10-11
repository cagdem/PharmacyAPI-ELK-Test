using Microsoft.AspNetCore.Mvc.Testing;
using Pharmacy.Application.MedicineApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api.Test
{
    public class MedicineControllerTest : IClassFixture<PharmacyApiFactory>
    {
        private readonly WebApplicationFactory<TestStartup> _factory;

        public MedicineControllerTest(PharmacyApiFactory factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task Post_Add_Medicine()
        {
            var medicine = new MedicineDto
            {
                CompanyId = 1,
                Details = "Aciklama",
                ExpirationDate = DateTime.Now.AddDays(360),
                Name = "Ilac 1",
                UnitPrice = 4,
                UnitsInStock = 7,
                CompanyName="Company 0"
            };


            var content = new StringContent(JsonSerializer.Serialize(medicine), Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();

            var responsePost = await client.PostAsync("api/v1/ilaclar", content);

            responsePost.EnsureSuccessStatusCode();

            var responseGetAll = await client.GetAsync("/api/v1/ilaclar/List?");

            var medicineElement = await responseGetAll.Content.ReadAsStringAsync();

            var medicineList = JsonSerializer.Deserialize<List<MedicineDto>>
                (JsonSerializer.Deserialize<JsonElement>(medicineElement).GetProperty("data").GetRawText(),new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            Assert.NotNull(medicineList);
            Assert.NotNull(medicineList);
            var lastMedicine = medicineList.Last();
            Assert.Equal(medicine, lastMedicine);

            var contentSameName = new StringContent(JsonSerializer.Serialize(medicine), Encoding.UTF8, "application/json");
            //var responsePostSameName = await client.PostAsync("api/v1/ilaclar", content);

            var exception = await Assert.ThrowsAsync<ApplicationException>(async () => await client.PostAsync("api/v1/ilaclar", content));

            Assert.Equal("Ayni adda kayit var", exception.Message);
        }
    }
}

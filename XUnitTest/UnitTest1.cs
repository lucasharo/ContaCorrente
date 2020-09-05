using Xunit;
using API;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.DTO;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using System.IO;
using Xunit.Priority;

namespace XUnitTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context, conf) =>
                {
                    var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                    conf.AddJsonFile(configPath);
                });
            });

            _httpClient = _factory.CreateClient();
        }

        [Fact, Priority(0)]
        public async Task CadastrarContaCorrenteTest()
        {
            var contaCorrente = new ContaCorrenteDTO
            {
                Nome = "Teste 3",
                Saldo = 500000
            };

            var request = new HttpRequestMessage(new HttpMethod("POST"), "api/v1/ContaCorrente/CadastrarContaCorrrente")
            {
                Content = new StringContent(JsonConvert.SerializeObject(contaCorrente), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(1)]
        public async Task RealizarTransferenciaTest()
        {
            var tranferencia = new TransferenciaDTO {
                ContaCorrenteOrigem = 3,
                ContaCorrenteDestino = 4,
                Valor = 300
            };

            var request = new HttpRequestMessage(new HttpMethod("POST"), "api/v1/ContaCorrente/RealizarTransferencia")
            {
                Content = new StringContent(JsonConvert.SerializeObject(tranferencia), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }
    }
}
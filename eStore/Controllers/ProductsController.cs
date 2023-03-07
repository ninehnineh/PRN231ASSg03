using eStore.Contracts;
using eStore.Models.ProductVMs;
using eStore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private string apiUrl = "";

        public ProductsController(IHttpContextAccessor httpContextAccessor,
            ILocalStorageService localStorageService)
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _localStorageService = localStorageService;
        }

        public async Task<ActionResult> Index()
        {
            apiUrl = "https://localhost:7217/api/Products";

            var token = new BaseHttpService(_localStorageService, _httpClient);
            token.AddBearerToken();

            HttpResponseMessage response = await _httpClient.GetAsync($"{apiUrl}");
            var data = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var products = JsonSerializer.Deserialize<IEnumerable<ProductListVM>>(data, options);

            return View(products);
        }

        public async Task<ActionResult> Detail(int id)
        {
            apiUrl = "https://localhost:7217/api/Products";

            HttpResponseMessage response = await _httpClient.GetAsync($"{apiUrl}/{id}");
            var data = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var product = JsonSerializer.Deserialize<ProductDetailsVM>(data, options);

            return View(product);
        }
    }
}

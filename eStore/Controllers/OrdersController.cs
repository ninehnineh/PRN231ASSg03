using eStore.Contracts;
using eStore.Models.OrderVMs;
using eStore.Models.ProductVMs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace eStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HttpClient _httpClient;
        private string apiUrl = "";

        public OrdersController(IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> History()
        {
            apiUrl = "https://localhost:7217/api/Orders/GetOrderList";

            var authenticatedUser = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "uid").ToString();

            var userId = authenticatedUser.Contains("uid") ?
                authenticatedUser.Substring(authenticatedUser.IndexOf(":") + 1).TrimStart() : authenticatedUser;

            string strData = JsonSerializer.Serialize(userId);
            var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{apiUrl}",contentData);
            var data = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var orders = JsonSerializer.Deserialize<IEnumerable<OrderHistoryVM>>(data, options);

            return View(orders);
        }
    }
}

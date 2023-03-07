using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using eStore.Contracts;
using eStore.Models.CartVMs;
using eStore.Models.OrderDetailVMs;
using eStore.Models.OrderVMs;
using eStore.Models.ProductVMs;
using Microsoft.AspNetCore.Mvc;

namespace eStore.Controllers
{
    public class CartController : Controller
    {
        public const string CartSession = "CartSession";
        public const string CARTKEY = "cart";

        private readonly HttpClient _httpClient;
        private string ProductApiUrl = "";

        public CartController(ILocalStorageService localStorageService)
        {
            _httpClient = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7217/api/Products";
        }


        public IActionResult index()
        {
            return View(GetCartItems());
        }

        [HttpPost]
        public async Task<ActionResult> AddToCart(int id, int quantity = 1)
        {

            var authenticatedUser = GetAuthenticatedUser();

            var product = await GetProduct(id);
            if (product == null)
                return NotFound("Product does not exists");


            var cart = GetCartItems();
            var cartItem = cart.Find(p => p.Product.id == id);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem() { Quantity = quantity, Product = product , UserId = authenticatedUser });
            }

            SaveCartSession(cart);

            TempData["Message"] = $"Your product {product.ProductName} in your Cart.";

            return RedirectToAction("Index", "Products");
            
        }

        // private ActionResult GetUserId

        private async Task<ProductVM> GetProduct(int id) 
        {
            ProductApiUrl = "https://localhost:7217/api/Products";

            HttpResponseMessage response = await _httpClient.GetAsync($"{ProductApiUrl}/{id}");
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var product = JsonSerializer.Deserialize<ProductVM>(data, options);

            return product;
        }

        private List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsonCart = session.GetString(CARTKEY);
            if (jsonCart != null)
            {
                return JsonSerializer.Deserialize<List<CartItem>>(jsonCart);
            }

            return new List<CartItem>();
        }

        private void SaveCartSession (List<CartItem> cartItems)
        {
            var session = HttpContext.Session;
            string jsonCart = JsonSerializer.Serialize(cartItems);
            session.SetString(CARTKEY, jsonCart);
        }

        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public async Task<IActionResult> UpdateCart(int id, int quantity)
        {

            var existedProduct = await GetProduct(id);

            if (quantity > existedProduct.UnitslnStock)
            {
                TempData["Message"] = $"Your required product ({existedProduct.ProductName}) is not enough quantity (In Stock: {existedProduct.UnitslnStock})";
                //return RedirectToAction(nameof(Cart));
            }
            else
            {
                var cart = GetCartItems();
                var cartItem = cart.Find(p => p.Product.id == id);

                if (quantity <= 0)
                    cart.Remove(cartItem);


                if (cartItem != null)
                    cartItem.Quantity = quantity;

                SaveCartSession(cart);
            }

            return Ok();
        }

        [Route("/removecart", Name = "removecart")]
        public IActionResult RemoveCart(int id)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.Product.id == id);
            if (cartitem != null)
                cart.Remove(cartitem);

            SaveCartSession(cart);
            return RedirectToAction(nameof(index));
        }


        public async Task<IActionResult> Checkout()
        {
            var cart = GetCartItems();

            string authenticatedUserId = GetAuthenticatedUser();
            var userId = authenticatedUserId.Contains("uid") ?
                authenticatedUserId.Substring(authenticatedUserId.IndexOf(":") + 1).TrimStart() : authenticatedUserId;

            var order = new CreateOrderVM()
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now,
                ShippedDate = DateTime.Now,
                Freight = 10000,
            };
            var orderId =  CreateOrder(order).Result.Value.OrderId;

            foreach (var item in cart)
            {
                var orderDetail = new CreateOrderDetailVM()
                {
                    OrderId = orderId,
                    ProductId = item.Product.id,
                    UnitPrice = item.Product.UnitPrice,
                    Quantity = item.Quantity,
                };
                await CreateOrderDetail(orderDetail);

                var a = new UpdateStockProductVM { id = item.Product.id, UnitslnStock = (item.Product.UnitslnStock - item.Quantity) };
                await UpdateUnitlnStock(a);

            }

            TempData["Message"] = $"Checkout Successful. Please check your order!";
            ClearCart();
            return RedirectToAction("Index", "Products");
        }

        private string GetAuthenticatedUser()
        {
            return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "uid").ToString();
        }

        [HttpPost]
        private async Task<ActionResult<CreateOrderResponse>> CreateOrder(CreateOrderVM createOrderVM)
        {
            ProductApiUrl = "https://localhost:7217/api/Orders";
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(createOrderVM);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(ProductApiUrl, contentData);
                var data = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var orderId = JsonSerializer.Deserialize<CreateOrderResponse>(data, options).OrderId;

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Insert successfully!";
                }
                else
                {
                    TempData["Message"] = "Error while calling WebAPI!";
                    return View();
                }
                return new CreateOrderResponse { OrderId = orderId};
            }

            return BadRequest();
        }

        [HttpPost]
        private async Task<ActionResult> CreateOrderDetail(CreateOrderDetailVM createOrderDetailVM)
        {
            ProductApiUrl = "https://localhost:7217/api/OrderDetails";

            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(createOrderDetailVM);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(ProductApiUrl, contentData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Insert successfully!";
                }
                else
                {
                    TempData["Message"] = "Error while calling WebAPI!";
                    return View();
                }
            }
            return BadRequest();
        }

        private void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        public async Task UpdateUnitlnStock(UpdateStockProductVM updateStockProductVM)
        {
            ProductApiUrl = "https://localhost:7217/api/Products";
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(updateStockProductVM);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(ProductApiUrl, contentData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Update successfully!";
                }
                else
                {
                    TempData["Message"] = "Error while calling WebAPI!";
                    View();
                }
            }
        }
    }
}
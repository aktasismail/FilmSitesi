using EntitiesLayer;
using EntitiesLayer.DTO;
using EntitiesLayer.RequestFeature;
using Microsoft.AspNetCore.Mvc;
using MovieWebUi.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace MovieWebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7042/api/movie/GetLastMovie");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MovieDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> GetAllMovies(string param)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7042/api/movie?" + param);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MovieDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MovieDetail(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync($"https://localhost:7042/api/movie/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<DetailVM>(jsonData);
                    return View(values);
                }
            }
            return View();
        }
        public async Task<IActionResult> AddComment(int id, string name, string text)
        {
            CommentCreateDTO commentDto = new CommentCreateDTO();
            commentDto.MovieId = id;
            commentDto.FullName = name;
            commentDto.CommentText = text;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(commentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/Comment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(commentDto);
        }
    }
}

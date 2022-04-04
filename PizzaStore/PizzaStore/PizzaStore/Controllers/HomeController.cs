using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaStore.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace PizzaStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductContext _dbContext;

    
        public HomeController(ILogger<HomeController> logger, ProductContext DBContext)
        {
            _logger = logger;
            _dbContext = DBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Products()
        {
            // GetProducts();

            string Baseurl = "https://localhost:7110/";

            List<products> proobj = new List<products>();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetDepartments using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/API/GetProduct");
                
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {

                    var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                    proobj = JsonConvert.DeserializeObject<List<products>>(ObjResponse);

                }
                //returning the student list to view  
                return View(proobj);
            }

            //var _prolst = _dbContext.products.ToList(); 
            //  return View(_prolst);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
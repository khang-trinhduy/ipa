using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using MvcClient.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MvcClient.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult GetApi()
        {
            return View("api");
        }

        public async Task<IActionResult> GetAddress()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:89/api/address");
            //var grants = JsonConvert.DeserializeObject<List<Grant>>(content);
            return View("json", content);
            //return View("api");
        }

        public async Task<IActionResult> GetOffice()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:89/api/company");
            //var grants = JsonConvert.DeserializeObject<List<Grant>>(content);
            return View("json", content);
        }

        public async Task<IActionResult> GetProvince()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:89/api/province");
            //var grants = JsonConvert.DeserializeObject<List<Grant>>(content);
            return View("json", content);
        }

        public async Task<IActionResult> GetNation()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:89/api/nation");
            //var grants = JsonConvert.DeserializeObject<List<Grant>>(content);
            return View("json", content);
        }

        public async Task<IActionResult> GetReligion()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:89/api/religion");
            //var grants = JsonConvert.DeserializeObject<List<Grant>>(content);
            return View("json", content);
        }

        public async Task<IActionResult> GetPermission()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var sub = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:88/api/grants?sub=" + sub);
            if (content == null)
            {
                return NotFound();
            }
            ViewBag.Json = content;
            var grants = JsonConvert.DeserializeObject<List<Grant>>(content);
            return View("Grants", grants);
        }

        [HttpGet]
        public async Task<IActionResult> EditPermission(int? id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var sub = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:88/api/grants/" + id);
            if (content == null)
            {
                return NotFound();
            }
            var grant = JsonConvert.DeserializeObject<Grant>(content);
            return View("Edit", grant);
        }

        [HttpPost]
        public async Task<IActionResult> EditPermission([Bind("Id", "ResourceId", "UserId", "Permission", "Operation")] Grant grant)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var putResult = await client.PutAsJsonAsync("http://localhost:88/api/grants/" + grant.Id , grant);
            if (!putResult.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("GetPermission");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePermission(int? id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var sub = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("http://localhost:88/api/grants/" + id);
            if (content == null)
            {
                return NotFound();
            }
            var grant = JsonConvert.DeserializeObject<Grant>(content);
            return View("Delete", grant);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var sub = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var deleteResult = await client.DeleteAsync("http://localhost:88/api/grants/" + id);
            if (!deleteResult.IsSuccessStatusCode)
            {
                return NotFound();
            }
            return RedirectToAction("GetPermission");
        }

        [HttpGet]
        public IActionResult AddPermission()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> AddPermission([Bind("ResourceId", "UserId", "Permission", "Operation")] Grant grant)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var sub = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var postResult = client.PostAsJsonAsync("http://localhost:88/api/grants", grant);
            postResult.Wait();
            if (!postResult.Result.IsSuccessStatusCode)
            {
                return View("Error");
            }
            return RedirectToAction("GetPermission");
        }
    }
}
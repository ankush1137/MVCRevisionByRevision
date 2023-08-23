using ApiConsumeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ApiConsumeDemo.Controllers
{
    public class StateController : Controller
    {
        IConfiguration _config;
        HttpClient _client;
        String uri;
        public StateController(IConfiguration config)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = (hrm, cert, certChain, policyError) => true;

            _client = new HttpClient(handler);

            uri = config["ApiUri"];
             
        }

        public IActionResult Index()
        {
            var tocken = HttpContext.Session.GetString("Tocken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tocken);

            string result = _client.GetStringAsync(uri + "States").Result;
            var states = JsonSerializer.Deserialize<List<States>>(result);

            return View(states);
        }
        public IActionResult Details(int id)
        {
           string result =  _client.GetStringAsync(uri +"States/"+ id).Result;
            var states = JsonSerializer.Deserialize<States>(result);

            return View(states);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(States states)
        {
            string data = JsonSerializer.Serialize(states);
            StringContent content = new StringContent(data,System.Text.UTF8Encoding.UTF8,"application/json");
           HttpResponseMessage response = _client.PostAsync(uri + "States",content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(states);
            }
  
        }
        public IActionResult Edit(int id)
        {
            string result = _client.GetStringAsync(uri + "States/"+ id).Result;
            var states = JsonSerializer.Deserialize<States>(result);

            return View(states);
        }
        [HttpPost]
        public IActionResult Edit(States states)
        {
            string data = JsonSerializer.Serialize(states);
            StringContent content = new StringContent(data, System.Text.UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(uri + "States/"+ states.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(states);
            }
        }
        public IActionResult Delete(int id)
        {
            string result = _client.GetStringAsync(uri +"States/"+ id).Result;
            var states = JsonSerializer.Deserialize<States>(result);

            return View(states);
        }
        [HttpPost,ActionName("Delete")]
        //[ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            HttpResponseMessage result = _client.DeleteAsync(uri +"States/"+ id).Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

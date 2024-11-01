using DSCC.CW1._14039.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace TeamCoachMVC.Controllers
{
    public class CoachController : Controller
    {
        // GET: CoachController
        public async Task<ActionResult> Index()
        {
            // Hosted web API REST Service base URL
            string Baseurl = "https://localhost:7237"; // Adjust as necessary
            List<Coach> coachInfo = new List<Coach>();
            using (var client = new HttpClient())
            {
                // Passing service base URL
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Sending request to find web API REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Coach");

                // Checking the response is successful or not
                if (Res.IsSuccessStatusCode)
                {
                    // Storing the response details received from web API
                    var coachResponse = Res.Content.ReadAsStringAsync().Result;

                    // Deserializing the response received from web API and storing the coach list
                    coachInfo = JsonConvert.DeserializeObject<List<Coach>>(coachResponse);
                }

                // Returning the Coach list to the view
                return View(coachInfo);
            }
        }

        // GET: CoachController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Coach coach = null;
            string Baseurl = "https://localhost:7237"; // Adjust as necessary
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync($"api/Coach/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var coachResponse = Res.Content.ReadAsStringAsync().Result;
                    coach = JsonConvert.DeserializeObject<Coach>(coachResponse);
                }
            }
            return View(coach);
        }

        // GET: CoachController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoachController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Coach coach)
        {
            string Baseurl = "https://localhost:7237"; // Adjust as necessary
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var postTask = await client.PostAsJsonAsync("api/Coach", coach);
                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(coach);
        }

        // GET: CoachController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Coach coach = null;
            string Baseurl = "https://localhost:7237"; // Adjust as necessary
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync($"api/Coach/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var coachResponse = Res.Content.ReadAsStringAsync().Result;
                    coach = JsonConvert.DeserializeObject<Coach>(coachResponse);
                }
            }
            return View(coach);
        }

        // POST: CoachController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Coach coach)
        {
            string Baseurl = "https://localhost:7237"; // Adjust as necessary
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var putTask = await client.PutAsJsonAsync($"api/Coach/{id}", coach);
                if (putTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(coach);
        }

        // GET: CoachController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Coach coach = null;
            string Baseurl = "https://localhost:7237"; // Adjust as necessary
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync($"api/Coach/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var coachResponse = Res.Content.ReadAsStringAsync().Result;
                    coach = JsonConvert.DeserializeObject<Coach>(coachResponse);
                }
            }
            return View(coach);
        }

        // POST: CoachController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string Baseurl = "https://localhost:7237"; // Adjust as necessary
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var deleteTask = await client.DeleteAsync($"api/Coach/{id}");
                if (deleteTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
    }
}

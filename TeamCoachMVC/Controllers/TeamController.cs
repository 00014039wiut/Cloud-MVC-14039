using DSCC.CW1._14039.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace TeamCoachMVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly string Baseurl = "https://localhost:7237";

        // GET: TeamController
        public async Task<ActionResult> Index()
        {
            List<Team> TeamInfo = new List<Team>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Team");

                if (Res.IsSuccessStatusCode)
                {
                    var TeamResponse = await Res.Content.ReadAsStringAsync();
                    TeamInfo = JsonConvert.DeserializeObject<List<Team>>(TeamResponse);
                }
                return View(TeamInfo);
            }
        }

        // GET: TeamController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Team team = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"api/Team/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var TeamResponse = await Res.Content.ReadAsStringAsync();
                    team = JsonConvert.DeserializeObject<Team>(TeamResponse);
                }
                return View(team);
            }
        }

        // GET: TeamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Team team)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(team), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/Team", content);

                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(team);
            }
        }

        // GET: TeamController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Team team = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"api/Team/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var TeamResponse = await Res.Content.ReadAsStringAsync();
                    team = JsonConvert.DeserializeObject<Team>(TeamResponse);
                }
                return View(team);
            }
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Team team)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(team), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync($"api/Team/{id}", content);

                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(team);
            }
        }

        // GET: TeamController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Team team = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync($"api/Team/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    var TeamResponse = await Res.Content.ReadAsStringAsync();
                    team = JsonConvert.DeserializeObject<Team>(TeamResponse);
                }
                return View(team);
            }
        }

        // POST: TeamController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.DeleteAsync($"api/Team/{id}");

                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
        }
    }
}

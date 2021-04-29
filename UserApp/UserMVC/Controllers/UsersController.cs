using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using UserMVC.Models;

namespace UserMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _http;
        public UsersController(IConfiguration iConfig)
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(iConfig.GetSection("APIUrl").Value);
        }
        public async Task<ActionResult> Index()
        {
            var users = new List<User>();
            var responseString = await _http.GetAsync("Users");
            if (responseString.IsSuccessStatusCode)
            {
                users = await responseString.Content.ReadAsAsync<List<User>>();
            }
            return View(users);
        }


        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User model)
        {
            try
            {
                var responseString = await _http.PostAsJsonAsync("Users", model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = "Something went wrong" });
            }
        }
        [HttpGet]
        public async Task<ActionResult> Edit([FromRoute] int id)
        {
            var user = new User();
            var responseString = await _http.GetAsync($"Users/{id}");
            if (responseString.IsSuccessStatusCode)
            {
                user = await responseString.Content.ReadAsAsync<User>();
            }
            return PartialView("Edit", user);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(User model)
        {
            try
            {
                var responseString = await _http.PutAsJsonAsync("Users", model);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = "Something went wrong" });
            }
        }
        [HttpGet]
        public ActionResult DeleteView(int id)
        {
            return PartialView("Delete", id);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var responseString = await _http.DeleteAsync($"Users/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = "Something went wrong" });

            }
        }
    }
}
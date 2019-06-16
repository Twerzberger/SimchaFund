using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimchaFund.Web.Models;
using SimchaFund.Data;
using Microsoft.Extensions.Configuration;

namespace SimchaFund.Web.Controllers
{
    public class HomeController : Controller
    {

        private string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewSimcha(Simcha simcha)
        {
            var rep = new SimchaRepository(_connectionString);
            rep.AddSimcha(simcha);

            return Redirect("/");
        }
    }
}

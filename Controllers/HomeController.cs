using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("process")]
        public IActionResult Process(UserQuotes data)
        {   
            string query = $"INSERT INTO userquotes (name, quote) VALUES ('{data.Name}', '{data.Quote}')";
            DbConnector.Execute(query);
            ViewData["Message"] = "Quote added to the database!";
            return RedirectToAction("Index");
        }
        
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            ViewData["Message"] = "Your contact page.";
            string query = "SELECT * FROM userquotes";
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM userquotes");
            ViewBag.AllUsers = AllUsers;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

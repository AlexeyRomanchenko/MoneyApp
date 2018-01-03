﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PVT.Money.Shell.Web.Models;
using PVT.Money.Business;

namespace PVT.Money.Shell.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
          //  MoneyClass australian_dollar = new MoneyClass(100.5m, "EUR");         
          //  CurrExchange new_operation = new CurrExchange(australian_dollar, "USD");
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnimoteStaticWeb.Models;

namespace UnimoteStaticWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        // GET: Remote/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Remote/Edit/5
        public ActionResult Edit1(int id)
        {
            var remnote = defaultDebuggingREmote();
            return View(remnote);
        }

        // POST: Remote/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit1(int id, Remote remote)
        {
            try
            {
                remote.Name = "Mark was here";
                // TODO: Add update logic here

                //return RedirectToAction(nameof(Index));
                return View(remote);
            }
            catch
            {
                return View();
            }
        }

        // GET: Remote/Edit/5
        public ActionResult Edit(int id)
        {
            var remnote = defaultDebuggingREmote();
            return View(remnote);
        }

        public ActionResult Active(int id)
        {
           // var pw = Configuration.GetValue<string>("Password");
            string fileName="";
            string argument = "";
            string userName = "";
            SecureString password = new SecureString();
            string domain = "";
            Process.Start(fileName, argument, userName, password, domain);
            var remnote = defaultDebuggingREmote();
            return View(remnote);
        }

        // POST: Remote/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Remote remote)
        {
            try
            {
                remote.Name = "Mark was here";
                // TODO: Add update logic here

                //return RedirectToAction(nameof(Index));
                return View(remote);
            }
            catch
            {
                return View();
            }
        }

        // POST: Remote/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Remote remote)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(remote);
            }
        }
        public IActionResult Index()
        {
            Remote remote = defaultDebuggingREmote();
            return View(remote);
        }

        private static Remote defaultDebuggingREmote()
        {
            var buttons = new List<ButtonFunction>
            {
                new ButtonFunction { Id = 1, KeyName = "1" },
                new ButtonFunction { Id = 2, KeyName = "2" },
                new ButtonFunction { Id = 3, KeyName = "3" },
            };
            Remote remote = new Remote
            {
                Name = "Mic23000",
                Buttons = buttons,
            };
            return remote;
        }

        [HttpPost]
        public IActionResult Index(Remote remote)
        {
            return View(remote);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

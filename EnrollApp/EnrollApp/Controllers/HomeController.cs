using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EnrollApp.Models;
using EnrollApp.ViewModels;

namespace EnrollApp.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Offers = _context.Offers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(ClientRequestViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client() { Name = vm.Name, Email = vm.Email, Phone = vm.Phone };
                ClientRequest clientRequest = new ClientRequest()
                {
                    Question = vm.Question,
                    OfferId = vm.OfferId,
                    ClientRequestStateId = _context.ClientRequestStates.First(r => r.IsNewRequest == true).Id
                };

                client.ClientRequests = new List<ClientRequest>() { clientRequest };

                _context.Clients.Add(client);
                _context.SaveChanges();

                return RedirectToAction("Response");
            }
            else
            {
                ViewBag.Offers = _context.Offers.ToList();
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult Response()
        {
            return View();
        }
    }
}

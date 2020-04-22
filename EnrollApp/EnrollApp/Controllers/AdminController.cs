using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnrollApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EnrollApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EnrollApp.Controllers
{
    public class AdminController : Controller
    {
        private AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(int? requestState, int? offer)
        {
            AllRequestsViewModel allRequestsVM = new AllRequestsViewModel();

            allRequestsVM.CurrentOfferId = offer ?? 0;
            allRequestsVM.CurrentRequestStateId = requestState ?? 0;

            List<Offer> offers = _context.Offers.ToList();
            offers.Insert(0, new Offer { Id = 0, Title = "Все" });
            allRequestsVM.Offers = new SelectList(offers, "Id", "Title");

            List<ClientRequest> clientRequests = _context.ClientRequests.Include(cr => cr.Client).ToList();
            
            if (requestState != 0 && requestState != null)
            {
                clientRequests = clientRequests.Where(cr => cr.ClientRequestStateId == requestState).ToList();
            }

            if (offer != 0 && offer !=null)
            {
                clientRequests = clientRequests.Where(cr => cr.OfferId == offer).ToList();
            }

            allRequestsVM.ClientRequests = clientRequests;

            List <ClientRequestState> requestStates = _context.ClientRequestStates.ToList();
            requestStates.Insert(0, new ClientRequestState { Id = 0, Title = "Все" });
            allRequestsVM.ClientRequestStates = new SelectList(requestStates, "Id", "Title");

            return View(allRequestsVM);
        }

        public IActionResult Offers()
        {
            IEnumerable<Offer> offers = _context.Offers.ToList();
            return View(offers);
        }

        [HttpGet]
        public IActionResult EditRequest(int id)
        {
            ClientRequest clientRequest = _context.ClientRequests.Find(id);
            
            if (clientRequest == null)
            {
                return NotFound();
            }

            _context.Entry(clientRequest).Reference(cr => cr.Offer).Load();
            _context.Entry(clientRequest).Reference(cr => cr.Client).Load();

            List<ClientRequestState> clientRequestStates = _context.ClientRequestStates.ToList();

            EditRequestViewModel editRequestVM = new EditRequestViewModel()
            {
                ClientRequest = clientRequest,
                RequestStates = new SelectList(clientRequestStates, "Id", "Title")
            };

            return View(editRequestVM);
        }

        [HttpPost]
        public IActionResult EditRequest(ClientRequest clientRequest)
        {
            _context.ClientRequests.Update(clientRequest);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult CreateOffer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOffer(Offer offer)
        {
            if (offer == null)
                return NotFound();
            _context.Offers.Add(offer);
            _context.SaveChanges();
            return RedirectToAction("Offers", "Admin");
        }

        [HttpGet]
        public IActionResult EditOffer(int id)
        {
            var offer = _context.Offers.Find(id);
            if (offer == null)
                return NotFound();
            return View(offer);
        }

        [HttpPost]
        public IActionResult EditOffer(Offer offer)
        {
            _context.Offers.Update(offer);
            _context.SaveChanges();
            return RedirectToAction("Offers", "Admin");
        }

        [HttpGet]
        [ActionName("DeleteOffer")]
        public IActionResult Delete(int id)
        {
            var offer = _context.Offers.Find(id);
            if (offer == null)
                return NotFound();
            return View(offer);
        }

        [HttpPost]
        public IActionResult DeleteOffer(int id)
        {
            var offer = _context.Offers.Find(id);
            _context.Offers.Remove(offer);
            _context.SaveChanges();
            return RedirectToAction("Offers", "Admin");
        }
    }
}
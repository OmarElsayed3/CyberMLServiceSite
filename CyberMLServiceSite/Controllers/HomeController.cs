using CyberMLServiceSite.Data;
using CyberMLServiceSite.Core.Models;
using CyberMLServiceSite.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CyberMLServiceSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RequestForm()
        {
            return View("Form",new ServiceRequestViewModel());
        }

        [HttpPost]
        public IActionResult RequestForm(ServiceRequestViewModel serviceRequest)
        {
            if (ModelState.IsValid)
            {
                var request = new ServiceRequest()
                {
                    Name = serviceRequest.Name,
                    Position = serviceRequest.Position,
                    ServiceType = serviceRequest.ServicesRequested,
                    Email = serviceRequest.Email,
                    AdditionalNotes = serviceRequest.AdditionalNotes,
                };

                _context.serviceRequests.Add(request);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Your request has been submitted successfully!";
                return RedirectToAction("Index");
            }
            return View("Form",serviceRequest);
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
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


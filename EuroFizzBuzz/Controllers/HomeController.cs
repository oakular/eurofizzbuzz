using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EuroFizzBuzz.Models;

namespace EuroFizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly EuroFizzBuzzContext _context;

        public HomeController(EuroFizzBuzzContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var submission = CreateSubmissionModel(1, 100);

            _context.Submissions.Add(submission);
            _context.SaveChanges();

            return View(submission);
        }

        public IActionResult UpdateTable(int startNumber, int endNumber)
        {
            var submission = CreateSubmissionModel(startNumber, endNumber);

            TryValidateModel(submission);

            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/FizzBuzzTable/_FizzBuzzTableError.cshtml");
            }

            _context.Submissions.Add(submission);
            _context.SaveChanges();

            return PartialView("~/Views/FizzBuzzTable/_FizzBuzzTable.cshtml", submission);
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

        private Submission CreateSubmissionModel(int startNumber, int endNumber)
        {
            return new Submission
            {
                StartNumber = startNumber,
                EndNumber = endNumber,
                Timestamp = DateTime.Now
            };
        }
    }
}

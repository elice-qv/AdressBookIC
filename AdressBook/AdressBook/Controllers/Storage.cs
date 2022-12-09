using AdressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdressBook.Controllers
{
    public class Storage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
    }
}

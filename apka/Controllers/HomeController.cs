using System.Diagnostics;
using apka.Models;
using Microsoft.AspNetCore.Mvc;

namespace apka.Controllers
{
    public class HomeController : Controller
    {
       
   
            public ActionResult Index()
            {
                return View("~/Views/ZamowieniaView/Intro.cshtml");
            }
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

  
}

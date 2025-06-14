using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;


namespace bc.Controllers
{

        public class ZamowieniaController : Controller
        {
            public ActionResult Kiosk()
            {
                ViewBag.ActiveTab = "Kawa";
                // Jeśli widok jest w niestandardowym folderze ZamowieniaView, podaj pełną ścieżkę:
                return View("~/Views/ZamowieniaView/Kiosk.cshtml");
            }

            public ActionResult Kiosk2()
            {
                ViewBag.ActiveTab = "Herbata";
                return View("~/Views/ZamowieniaView/Kiosk2.cshtml");
            }

            public ActionResult Kiosk3()
            {
                ViewBag.ActiveTab = "Ciasta";
                return View("~/Views/ZamowieniaView/Kiosk3.cshtml");
            }
        }
    }




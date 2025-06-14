using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace bc.Controllers
{
    public class AdministratorController : Controller
    {
        public ActionResult Admin()
        {
            return View();
        }
       
    }

}
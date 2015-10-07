using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inteligencia_g1.Models;

namespace Inteligencia_g1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Arvore.RetornoMatriz();
            ViewBag.MatrizView = Arvore.matrizImg1;
            return View();
        }
    }
}
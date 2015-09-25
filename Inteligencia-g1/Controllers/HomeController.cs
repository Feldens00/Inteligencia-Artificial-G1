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
            List<float> retorno = new List<float>();
            Arvore.FotoWork();
            Arvore.Aprendizado();
       retorno =   Arvore.Retorno();
          float i=  Arvore.Teste(retorno);
            return View(retorno);
        }
    }
}
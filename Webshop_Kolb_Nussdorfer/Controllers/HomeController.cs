using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dataContext = new WebshopDataContext();
            var produkt = dataContext.Produkt.First();
                         
            //ViewBag.Message = produkt.Kurzbezeichnung;
            Console.WriteLine(produkt.Kurzbezeichnung);

            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ihre App-Beschreibungsseite.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ihre Kontaktseite.";

            return View();
        }
    }
}

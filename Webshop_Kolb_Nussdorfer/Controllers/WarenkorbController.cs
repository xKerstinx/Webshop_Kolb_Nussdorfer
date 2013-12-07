using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop;
using Webshop.Common.BL;
using Webshop.Common.DAL;
using Webshop_Kolb_Nussdorfer.BL;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    [Authorize(Roles = "Admin,Kunde")]
    public class WarenkorbController : Controller
    {
        private readonly IBL _bl;
        private readonly IWarenkorbService _warenkorb;
        public WarenkorbController(IBL bl, IWarenkorbService warenkorb)
        {
            _bl = bl;
            _warenkorb = warenkorb;
        }
         
        //
        // GET: /Warenkorb/
        public ActionResult Index()
        {
            return View(_warenkorb.GetItems());

        }

        public ActionResult Order(int id)
        {
            _warenkorb.AddItem(_bl.Produkt.GetProdukt(id));
            TempData["Msg"] = "Produkt wurde erfolgreich dem Warenkorb hinzugefügt";
            return RedirectToAction("Index", "Produkt");
        }

        [HttpPost]
        [HttpParamAction(Name = "action", Argument = "Update")]
        public ActionResult Update(List<WarenkorbItemViewModel> results)
        {
            _warenkorb.Update(results);
            return RedirectToAction("Index", "Warenkorb");
        }

        [HttpPost]
        [HttpParamAction(Name = "action", Argument = "CreateOrder")]
        public ActionResult CreateOrder(List <WarenkorbItemViewModel> results)
        {
            _warenkorb.Update(results);
            Bestellung newOrder=_bl.Bestellung.createOrder(_warenkorb.CreateBestellpositionen());
            return View("BestellungSuccess", newOrder);
        }
    }
}

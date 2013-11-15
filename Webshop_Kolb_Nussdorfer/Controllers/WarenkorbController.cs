using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop;
using Webshop.Common.BL;
using Webshop.Common.DAL;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    public class WarenkorbController : Controller
    {
        private readonly IBL _bl;
        public WarenkorbController(IBL bl)
        {
            _bl = bl;
        }
         
        //
        // GET: /Warenkorb/

        public ActionResult Index()
        {
            return View(WarenkorbViewModel.Instance.Items);

        }


        
        //
        // GET: /Warenkorb/Delete/5
       // [HttpPost]
        public ActionResult Delete(int id)
        {
            // To-DO funktioniert jetzt nicht mehr, seit View eine for Schleife verwendet
            WarenkorbViewModel.Instance.RemoveItem(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Warenkorb/Delete/5
        
        /*public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

      
        public ActionResult Order(int id)
        {
            WarenkorbViewModel.Instance.AddItem(id);
            //HttpContext.Session["Warenkorb"] = warenkorb;
            return RedirectToAction("Index", "Produkt");
        }

        [HttpPost]
        [HttpParamAction(Name = "action", Argument = "Update")]
        public ActionResult Update(List<WarenkorbItemViewModel> results)
        {
            foreach (var item in results)
            {
                WarenkorbViewModel.Instance.SetItemQuantity(item.Produkt.Produkt_ID, item.Menge);
            }
            
            return RedirectToAction("Index", "Warenkorb");
        }

        [HttpPost]
        [HttpParamAction(Name = "action", Argument = "CreateOrder")]
        public ActionResult CreateOrder(List <WarenkorbItemViewModel> results)
        {
            Bestellung newOrder=_bl.Bestellung.createOrder(WarenkorbViewModel.Instance.CreateBestellpositionen(results));
            return View("BestellungSuccess", newOrder);
        }
    }
}

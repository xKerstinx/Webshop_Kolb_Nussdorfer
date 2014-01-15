using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Common.BL;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BestellungController : Controller
    {
        
        private readonly IBL _bl;
        public BestellungController(IBL bl)
        {
            _bl = bl;
        }
        
        //
        // GET: /Bestellung/
        public ActionResult Index(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return View(_bl.Bestellung
                 .GetAllBestellungen(0)
                 .Select(i => new BestellungViewModel(i))
                 );
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                return View(_bl.Bestellung
                 .Search(searchString, 0)
                 .Select(i => new BestellungViewModel(i)));
            }

            return View();
        }

        //
        // GET: /Bestellung/Details/5

        public ActionResult Details(int id)
        {
            return View(new BestellungViewModel(_bl.Bestellung.GetBestellung(id)));
        }

        //
        // GET: /Bestellung/Edit/5

        public ActionResult Edit(int id)
        {
            return View(new BestellungViewModel(_bl.Bestellung.GetBestellung(id)));
        }

        //
        // POST: /Bestellung/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, BestellungViewModel bestellung)
        {
            if (ModelState.IsValid)
            {
                var bestellungToUpdate = _bl.Bestellung.GetBestellung(id);
                bestellung.ApplyChanges(bestellungToUpdate);
                _bl.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(bestellung);
        }

        //
        // GET: /Bestellung/Delete/5
        public ActionResult Delete(int id)
        {
            _bl.Bestellung.DeleteBestellung(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Bestellung/Delete/5
        public ActionResult DeleteAll()
        {
            _bl.Bestellung.DeleteAllBestellungen();
            return RedirectToAction("Index");
            
        }

        public ActionResult DeletePosition(int produktID, int bestellID)
        {
            _bl.Bestellung.DeletePosition(produktID, bestellID);
            if (_bl.Bestellung.GetBestellung(bestellID) == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details", new { id = bestellID });
            
        }

    }
}

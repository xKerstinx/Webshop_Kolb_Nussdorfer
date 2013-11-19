using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Common.BL;
using Webshop.Common.DAL;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    public class ProduktController : Controller
    {
        private readonly IBL _bl;
        public ProduktController(IBL bl)
        {
            _bl = bl;
        }

        //
        // GET: /Produkt/

        /*public ActionResult Index()
        {
            return View(_bl.Produkt
                .GetAllProdukte(0)
                .Select(i => new ProduktViewModel(i)));
        }*/

        public ActionResult Index(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return View(_bl.Produkt
                 .GetAllProdukte(0)
                 .Select(i => new ProduktViewModel(i))
                 );
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                return View(_bl.Produkt
                 .Search(searchString,0)
                 .Select(i => new ProduktViewModel(i)));
            }

            return View();
        }

        //
        // GET: /Produkt/Details/5

        /*public ActionResult Details(int id)
        {
            return View(new ProduktViewModel(_bl.Produkt.GetProdukt(id)));
        }*/

        //
        // GET: /Produkt/Details/5

        public ActionResult Details(string kurzbezeichnung)
        {
            return View(new ProduktViewModel(_bl.Produkt.GetProdukt(kurzbezeichnung)));
        }

        //
        // GET: /Produkt/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produkt/Create

        [HttpPost]
        public ActionResult Create(ProduktViewModel produkt)
        {
            if (ModelState.IsValid)
            {
                var newProdukt = _bl.Produkt.CreateProdukt();
                produkt.ApplyChanges(newProdukt);

                if (ModelState.IsValid)
                {
                    _bl.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(produkt);
        }

        //
        // GET: /Produkt/Edit/5

        public ActionResult Edit(int id)
        {
            return View(new ProduktViewModel(_bl.Produkt.GetProdukt(id)));
        }

        //
        // POST: /Produkt/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, ProduktViewModel produkt)
        {
            if (ModelState.IsValid)
            {
                var produktToUpdate = _bl.Produkt.GetProdukt(id);
                produkt.ApplyChanges(produktToUpdate);
                _bl.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(produkt);
        }

       

        //
        // POST: /Produkt/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                _bl.Produkt.DeleteProdukt(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AutoComplete(string term)
        {
            if (!string.IsNullOrEmpty(term) && term.Length >= 3)
            {
                var results = _bl.Produkt.Search(term, 0)
                    .Select(i => new { label = i.Kurzbezeichnung, id = i.Produkt_ID })
                    .Take(20);
                return Json(results.ToArray(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null);
            }
        }

        public ActionResult Order(int id)
        {
            //To-Do Warenkorb & Co
            return View();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Common.BL;
using Webshop.Common.DAL;
using Webshop_Kolb_Nussdorfer.BL;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    public class ProduktController : Controller
    {
        private readonly IBL _bl;
        private readonly IWarenkorbService _warenkorb;
        public ProduktController(IBL bl, IWarenkorbService warenkorb)
        {
            _bl = bl;
            _warenkorb = warenkorb;
        }

        //
        // GET: /Produkt/
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

       
        public ActionResult Details(int id)
        {
            return View(new ProduktViewModel(_bl.Produkt.GetProdukt(id)));
        }

        //
        // GET: /Produkt/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produkt/Create

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View(new ProduktViewModel(_bl.Produkt.GetProdukt(id)));
        }

        //
        // POST: /Produkt/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            try
            {
                _bl.Produkt.DeleteProdukt(id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Msg"]="Produkt kann nicht gelöscht werden, da eine zugehörige Bestellung vorhanden ist";
                return RedirectToAction("Index");
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
    }
}

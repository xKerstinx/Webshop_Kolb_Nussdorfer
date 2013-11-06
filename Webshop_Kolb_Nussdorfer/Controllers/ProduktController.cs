using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    public class ProduktController : Controller
    {
        //
        // GET: /Produkt/

        public ActionResult Index()
        {
            var dataContext = new WebshopDataContext();
            return View(dataContext.Produkt.Select(i => i).ToList());
        }

        //
        // GET: /Produkt/Details/5

        public ActionResult Details(int id)
        {
            var dataContext = new WebshopDataContext();
            return View(dataContext.Produkt.Select(i => i).Where(i=>i.Produkt_ID == id).ToList());
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produkt/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Produkt/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Produkt/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Produkt/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
        }
    }
}

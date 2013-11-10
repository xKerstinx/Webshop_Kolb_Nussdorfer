﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    public class WarenkorbController : Controller
    {
        //WarenkorbViewModel warenkorb;

        // WarenkorbController()
        //{
          // this.warenkorb = new WarenkorbViewModel();
       //}
         
        //
        // GET: /Warenkorb/

        public ActionResult Index()
        {
            return View(WarenkorbViewModel.Instance.Items);

        }

        //
        // GET: /Warenkorb/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Warenkorb/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Warenkorb/Create

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
        // GET: /Warenkorb/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Warenkorb/Edit/5

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

        public ActionResult Update(ICollection<WarenkorbItemViewModel> results)
        {
            //TO-DO ist es irgendwie möglich, dass ich alle Items der Liste zurückbekomm?
            
            //WarenkorbViewModel.Instance.AddItem(id);
            //HttpContext.Session["Warenkorb"] = warenkorb;
            return RedirectToAction("Index", "Produkt");
        }

        public ActionResult CreateOrder(List <WarenkorbItemViewModel> results)
        {
            //TO-DO Bestellung erstellen
            //link for multiple submitbuttons
        //http://stackoverflow.com/questions/442704/how-do-you-handle-multiple-submit-buttons-in-asp-net-mvc-framework


            return RedirectToAction("Index", "Produkt");
        }
    }
}

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
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IBL _bl;
        public UserController(IBL bl)
        {
            _bl = bl;
        }


        public ActionResult Index(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return View(_bl.User
                 .GetAllUsers(0)
                 .Select(i => new UserViewModel(i)));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                return View(_bl.User
                 .Search(searchString, 0)
                 .Select(i => new UserViewModel(i)));
            }

            return View();
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View(new UserViewModel(_bl.User.GetUser(id)));
        }


        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = _bl.User.CreateUser();
                user.ApplyChanges(newUser, ModelState);
                //user.ApplyPassword(newUser, ModelState);

                if (string.IsNullOrEmpty(user.Passwort))
                {
                    ModelState.AddModelError("password", "Password cannot be empty");
                }

                if (ModelState.IsValid)
                {
                    _bl.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View(new UserViewModel(_bl.User.GetUser(id)));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userToUpdate = _bl.User.GetUser(id);
                user.ApplyChanges(userToUpdate, ModelState);
                //user.ApplyPassword(userToUpdate, ModelState);

                if (ModelState.IsValid)
                {
                    _bl.SaveChanges();
                    return RedirectToAction("Index");
                }
               // _bl.SaveChanges();

               // return RedirectToAction("Index");
            }
            return View(user);
        }


        //
        // POST: /User/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                _bl.User.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Msg"] = "User kann nicht gelöscht werden, da eine zugehörige Bestellung vorhanden ist";
                return RedirectToAction("Index");
            }
        }

 
        public ActionResult AutoComplete(string term)
        {
            if (!string.IsNullOrEmpty(term) && term.Length >= 3)
            {
                var results = _bl.User.Search(term, 0)
                    .Select(i => new { label = i.Vorname+" "+i.Nachname, id = i.User_ID })
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

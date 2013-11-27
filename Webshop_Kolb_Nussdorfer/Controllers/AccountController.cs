using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Webshop_Kolb_Nussdorfer.Filters;
using Webshop_Kolb_Nussdorfer.Models;
using Webshop.Common.DAL;
using Webshop.Common.BL;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        private readonly IBL _bl;
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        public AccountController(IBL bl)
        {
            _bl = bl;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_bl.Authentication.userExists(model.Username,model.Password))
                {
                    // Wenn man bereits eingeloggt ist, zuerst ausloggen
                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        FormsService.SignOut();
                    }
                    FormsService.SignIn(model.Username, model.RememberMe);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Der angegebene Benutzername oder das angegebene Kennwort ist ungültig.");
                }
            }

            // Wurde dieser Punkt erreicht, ist ein Fehler aufgetreten; Formular erneut anzeigen.
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Versuch, den Benutzer zu registrieren
                var newProdukt=_bl.Authentication.CreateUser();
                
                
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model, "Kunde");


                if (createStatus == MembershipCreateStatus.Success)
                {
                    model.Success = true;
                    FormsService.SignIn(model.User.Benutzername, false /* createPersistentCookie */);
                    return View("RegisterSuccess",model);
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // Wurde dieser Punkt erreicht, ist ein Fehler aufgetreten; Formular erneut anzeigen.
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ForgotPassword
        // **************************************

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Versuch, das Passwort anzupassen
                MembershipCreateStatus forgotStatus = MembershipService.ForgotPassword(model.Username, model.Email);

                if (forgotStatus == MembershipCreateStatus.Success)
                {
                    model.Success = true;
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(forgotStatus));
                }
            }

            return View("ForgotPasswordSuccess");
        }
    }

}

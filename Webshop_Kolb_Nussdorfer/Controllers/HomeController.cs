using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Webshop.Common.BL;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBL _bl;
        
       // public IMembershipService MembershipService { get; set; }

        public HomeController(IBL bl)
        {
            _bl = bl;
            //String[] userRoles = _bl.User.getUserRoles(System.Web.HttpContext.Current.User.Identity.Name);
            //System.Web.HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(System.Web.HttpContext.Current.User.Identity.Name), userRoles);
            
        }

        public ActionResult Index()
        {
            String[] userRoles = _bl.User.getUserRoles(HttpContext.User.Identity.Name);
            HttpContext.User = new GenericPrincipal(new GenericIdentity(HttpContext.User.Identity.Name), userRoles);
            
            Boolean role = HttpContext.User.IsInRole("Admin");
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

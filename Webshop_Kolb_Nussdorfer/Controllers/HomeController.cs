﻿using System;
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
        

        public HomeController(IBL bl)
        {
            _bl = bl;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}

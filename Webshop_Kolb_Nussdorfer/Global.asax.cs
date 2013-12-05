using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Security.Principal;

namespace Webshop_Kolb_Nussdorfer
{
    // Hinweis: Anweisungen zum Aktivieren des klassischen Modus von IIS6 oder IIS7 
    // finden Sie unter "http://go.microsoft.com/?LinkId=9394801".

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) 
        { 
            filters.Add(new HandleErrorAttribute()); 
        } 
        
        public static void RegisterRoutes(RouteCollection routes) 
        { 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             "ProductByName",
             "P/{id}/{kurzbezeichnung}",
              new { controller = "Produkt", action = "Details", kurzbezeichnung = UrlParameter.Optional }
         );
            routes.MapRoute( "Default", // Route name 
                "{controller}/{action}/{id}", // URL with parameters 
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults 
                );

             

        } 
        
        protected void Application_Start() 
        { 
            CreateMasterContainer(); 
            AreaRegistration.RegisterAllAreas(); 
            RegisterGlobalFilters(GlobalFilters.Filters); 
            RegisterRoutes(RouteTable.Routes);
            this.AuthenticateRequest += MvcApplication_AuthenticateRequest;
        }

        void MvcApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(HttpContext.Current.User.Identity.Name), new[] { "Admin" });
            }
        } 
        
        private void CreateMasterContainer() 
        { 
            var builder = new ContainerBuilder(); 
            builder.RegisterControllers(typeof(MvcApplication).Assembly); // More registration here 
            builder.RegisterModule<Webshop.Common.Module>(); 
            var container = builder.Build(); 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); }
    }
}
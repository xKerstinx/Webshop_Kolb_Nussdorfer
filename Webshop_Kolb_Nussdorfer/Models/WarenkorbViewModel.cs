using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class WarenkorbViewModel
    {
        public List<WarenkorbItemViewModel> Items { get; set; }

        public static readonly WarenkorbViewModel Instance;

        static WarenkorbViewModel()
        {
            if (HttpContext.Current.Session["Warenkorb"] == null)
            {
                Instance = new WarenkorbViewModel();
                Instance.Items = new List<WarenkorbItemViewModel>();
                HttpContext.Current.Session["Warenkorb"] = Instance;
            }
            else 
            {
                Instance = (WarenkorbViewModel)HttpContext.Current.Session["Warenkorb"];
            }
        }

        // ensures that no object can be created from outside
        protected WarenkorbViewModel() { }

    }

    
}
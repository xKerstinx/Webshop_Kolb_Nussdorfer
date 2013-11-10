using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class WarenkorbItemViewModel : IEquatable<WarenkorbItemViewModel>
    {
        #region Properties
        public ProduktViewModel Produkt;
        public int Menge {get;set;}
        

        public System.Nullable<decimal> Preis_brutto
        {
            get
            {
                return Produkt.Preis_netto / 100 * (100+Produkt.Steuersatz);
            }
        }

        public System.Nullable<decimal> Gesamtpreis_brutto
        {
            get
            {
                return Preis_brutto*Menge;
            }
        }

        #endregion

        public WarenkorbItemViewModel()
        {
        }


        public WarenkorbItemViewModel(ProduktViewModel produkt)
        {
            this.Produkt = produkt;
            
        }

        public WarenkorbItemViewModel(int produkt_id) 
        {
            WebshopDataContext dataContext = new WebshopDataContext();
            Produkt produkt=dataContext.Produkt
                .Where(i => i.Produkt_ID == produkt_id).First();
            this.Produkt = new ProduktViewModel(produkt);
            
        }

      
        public bool Equals(WarenkorbItemViewModel item)
        {
            return item.Produkt.Produkt_ID == this.Produkt.Produkt_ID;
        } 
      
    }
}
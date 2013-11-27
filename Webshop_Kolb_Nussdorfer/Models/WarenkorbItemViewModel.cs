using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Webshop.Common.DAL;
using System.ComponentModel;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class WarenkorbItemViewModel : IEquatable<WarenkorbItemViewModel>
    {
        #region Properties
        public ProduktViewModel Produkt {get;set;}
        public int Menge {get;set;}
        

        [DisplayName("Bruttogesamtpreis")]
        public System.Nullable<decimal> Gesamtpreis_brutto
        {
            get
            {
                return Produkt.Preis_brutto*Menge;
            }
            set
            {
                this.Gesamtpreis_brutto = value;
            }
        }



        #endregion

        public WarenkorbItemViewModel()
        {

        }

        public WarenkorbItemViewModel(Produkt produkt)
        {
            this.Produkt = new ProduktViewModel(produkt);
            
        }

        public bool Equals(WarenkorbItemViewModel item)
        {
            return item.Produkt.Produkt_ID == this.Produkt.Produkt_ID;
        } 
      
    }
}
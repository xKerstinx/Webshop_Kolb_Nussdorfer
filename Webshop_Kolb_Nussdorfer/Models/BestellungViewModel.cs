using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class BestellungViewModel
    {
        #region Properties
        [DisplayName("Bestellnummer")]
        public int Bestellung_ID { get; set; }

		[DisplayName("Bestelldatum")]
        public System.DateTime Bestelldatum { get; set; }
		
        [DisplayName("Rechnungsbetrag brutto")]
        public System.Nullable<decimal> Rechnungsbetrag { 
            get {
                System.Nullable<decimal> rechnungssumme=null;

                foreach (var item in bestellpositionen)
                {
                    rechnungssumme += (item.Menge * (item.produkt.Preis_netto / 100 * (100 + item.produkt.Steuersatz)));
                }
                return rechnungssumme;
            }
            set { }
        }
		
        [DisplayName("Kundennummer")]
        public int User_ID { get; set; }

        public IList<BestellpositionViewModel> bestellpositionen = new List<BestellpositionViewModel>();

        public User User { get; set; }

        #endregion

        public BestellungViewModel()
        {
        }


        public BestellungViewModel(Bestellung bestellung)
        {
            this.Bestellung_ID = bestellung.Bestellung_ID;
            this.Bestelldatum = bestellung.Bestelldatum;
            this.Rechnungsbetrag = bestellung.Rechnungsbetrag;
            this.User_ID = bestellung.User_ID;
            
            foreach (var p in bestellung.Bestellposition){
                bestellpositionen.Add(new BestellpositionViewModel(p));
            }
            this.User = bestellung.User;
        }

        public void ApplyChanges (Bestellung bestellung)
        {
            bestellung.Bestellung_ID = this.Bestellung_ID;
            bestellung.Bestelldatum = this.Bestelldatum;
            bestellung.User_ID = this.User_ID;
            // bei den Bestellpositionen kann nix bearbeitet werden, daher können sich diese auch nicht ändern
            /*foreach (var p in bestellung.Bestellposition)
            {
                bestellpositionen.Where(i => i.Produkt_ID == p.Produkt_ID).FirstOrDefault().ApplyChanges(p);
            }*/

            bestellung.Rechnungsbetrag = this.Rechnungsbetrag;
        }
    }
}
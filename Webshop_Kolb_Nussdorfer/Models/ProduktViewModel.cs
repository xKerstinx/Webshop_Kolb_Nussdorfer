using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class ProduktViewModel
    {
        #region Properties
        public int Produkt_ID { get; private set; }
        [Required]
        public string Kurzbezeichnung { get; set; }
        public string Langbezeichnung { get; set; }
        [Required]
        public System.Nullable<int> Steuersatz { get; set; }
        [Required]
        public System.Nullable<decimal> Preis_netto { get; set; }
        public string Zutaten { get; set; }
        

        public System.Nullable<decimal> Preis_brutto
        {
            get
            {
                return Preis_netto / 100 * (100+Steuersatz);
            }
        }

        public Produkt produkt = null;
        #endregion

        public ProduktViewModel()
        {
        }


        public ProduktViewModel(Produkt produkt)
        {
            this.Produkt_ID = produkt.Produkt_ID;
            this.Kurzbezeichnung = produkt.Kurzbezeichnung;
            this.Langbezeichnung = produkt.Langbezeichnung;
            this.Steuersatz = produkt.Steuersatz;
            this.Preis_netto = produkt.Preis_netto;
            this.Zutaten = produkt.Zutaten;
        }

      

        public void ApplyChanges(Produkt produkt)
        {
            produkt.Kurzbezeichnung = this.Kurzbezeichnung;
            produkt.Langbezeichnung = this.Langbezeichnung;
            produkt.Steuersatz = this.Steuersatz;
            produkt.Preis_netto = this.Preis_netto;
            produkt.Zutaten = this.Zutaten;
        }
    }
}
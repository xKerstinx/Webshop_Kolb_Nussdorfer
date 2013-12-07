using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class BestellpositionViewModel
    {
        #region Properties
        [DisplayName("Artikelnummer")]
        public int Produkt_ID { get;set; }
        [DisplayName("Bestellnummer")]
        public int Bestellung_ID { get; set; }
        [DisplayName("Menge")]
        public int Menge { get; set; }

        public ProduktViewModel produkt = null;
        #endregion

        public BestellpositionViewModel()
        {
        }


        public BestellpositionViewModel(Bestellposition position)
        {
            this.Produkt_ID = position.Produkt_ID;
            this.Bestellung_ID = position.Bestellung_ID;
            this.Menge = position.Menge;
            this.produkt = new ProduktViewModel(position.Produkt);
        }

        public void ApplyChanges(Bestellposition position)
        {
            position.Produkt_ID = this.Produkt_ID;
            position.Bestellung_ID = this.Bestellung_ID;
            position.Menge = this.Menge;

        }

    }
}
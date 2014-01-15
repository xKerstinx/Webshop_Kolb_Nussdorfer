using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Webshop.Common.DAL;
using System.ComponentModel;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class ProduktViewModel
    {
        #region Properties
        [DisplayName("Artikelnr.")]
        public int Produkt_ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Die Kurzbezeichnung muss eine Länge von min. 5 und max. 40 Zeichen haben")]
        public string Kurzbezeichnung { get; set; }

        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Die Langbezeichnung muss eine Länge von min. 5 und max. 500 Zeichen haben")]
        public string Langbezeichnung { get; set; }

        [RegularExpression("([0-9]{1,2})", ErrorMessage = "Der Steuersatz muss auf min. 1 und max. 2 numerischen Zeichen bestehen")]
        [Required]
        public int Steuersatz { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        [DisplayName("Netto")]
        public decimal Preis_netto { get; set; }

        [StringLength(500, MinimumLength = 0, ErrorMessage = "Die Zutaten dürfen max. 500 Zeichen lang sein.")]
        public string Zutaten { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Brutto")]
        public decimal Preis_brutto
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
            this.produkt = produkt;
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
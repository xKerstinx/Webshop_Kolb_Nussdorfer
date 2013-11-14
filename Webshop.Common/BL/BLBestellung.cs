using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;
using System.Web;

namespace Webshop.Common.BL
{
    class BLBestellung : IBLBestellung
    {
        private readonly IDAL _dal; 
        public BLBestellung(IDAL dal)
        { 
            _dal = dal; 
        } 
        
        public Bestellung createOrder(List<Bestellposition> orderItems)
        {
            Bestellung neueBestellung = new Bestellung();
            neueBestellung.Bestelldatum = DateTime.Now;
            neueBestellung.User_ID = _dal
                                    .User
                                    .Where(i => i.Benutzername.Equals(HttpContext.Current.User.Identity.Name))
                                    .Select(i => i.User_ID)
                                    .First();
            // Brutto Rechnungssumme
            decimal rechnungssumme=0;
            foreach (var item in orderItems)
            {
                var produkt=_dal.Produkt
                                .Where (i=>i.Produkt_ID == item.Produkt_ID)
                                .First();
                rechnungssumme += (item.Menge * (produkt.Preis_netto/100*(100+produkt.Steuersatz)));
            }
            neueBestellung.Rechnungsbetrag = rechnungssumme;
            neueBestellung.Bestellposition.AddRange(orderItems);
            _dal.Bestellung.InsertOnSubmit(neueBestellung);
            _dal.SaveChanges();
            return null;
        }

        public void updateRechnungsbetrag()
        {
        }

    }
}

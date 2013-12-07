using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;
using System.Web;

namespace Webshop.Common.BL
{
    public class BLBestellung : IBLBestellung
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
            return neueBestellung;
        }

        public void updateRechnungsbetrag()
        {
        }

        public IQueryable<Bestellung> GetAllBestellungen(int startPage)
        {
            return _dal.Bestellung
                // .Where(i => Security Filter) 
                .Skip(startPage * Helper.Helper.PageSize)
                .Take(Helper.Helper.PageSize);
        }

        public Bestellung GetBestellung(int id)
        {
            var obj = _dal.Bestellung.Where(i => i.Bestellung_ID == id).FirstOrDefault(); 
            return obj;
        }

        public void DeleteBestellung(int id)
        {
            _dal.Bestellposition.DeleteAllOnSubmit(_dal.Bestellposition.Where(i => i.Bestellung_ID==id));
            _dal.Bestellung.DeleteOnSubmit(_dal.Bestellung.Where(i => i.Bestellung_ID == id).FirstOrDefault());
            _dal.SaveChanges();

        }

        public void DeleteAllBestellungen()
        {
            _dal.Bestellposition.DeleteAllOnSubmit(_dal.Bestellposition);
            _dal.Bestellung.DeleteAllOnSubmit(_dal.Bestellung);
            _dal.SaveChanges();

        }

        public void DeletePosition(int produktID, int bestellID)
        {
            _dal.Bestellposition.DeleteOnSubmit(_dal.Bestellposition.Where(i => i.Produkt_ID == produktID && i.Bestellung_ID==bestellID).FirstOrDefault());
            IEnumerable<Bestellposition> positionen=_dal.Bestellposition.Where(i => i.Bestellung_ID == bestellID).ToList();
            // Wenn die gerade behandelte Position die letzte Position zu diser Bestellung ist, dann lösche ganze Bestellung
            if (positionen.Count()==1 && positionen.First().Produkt_ID==produktID)
            {
                _dal.Bestellung.DeleteOnSubmit(_dal.Bestellung.Where(i => i.Bestellung_ID == bestellID).FirstOrDefault());
            }
            _dal.SaveChanges();

        }

    }
}

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
                                    .FirstOrDefault();
            // Brutto Rechnungssumme
            decimal rechnungssumme=RechnungsbetragBerechnen(orderItems);
          
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
            IEnumerable<Bestellposition> positionen=_dal.Bestellposition.Where(i => i.Bestellung_ID == bestellID && i.Produkt_ID!=produktID).ToList();
            // if actual position is the one and only for this order, dann delete order
            if (positionen.Count()==0)
            {
                _dal.Bestellung.DeleteOnSubmit(_dal.Bestellung.Where(i => i.Bestellung_ID == bestellID).FirstOrDefault());
            }
            //update ordersum
            decimal rechnungssumme = RechnungsbetragBerechnen(positionen);
            Bestellung bestellung = _dal.Bestellung.Where(i => i.Bestellung_ID == bestellID).FirstOrDefault();
            if (bestellung!=null)
            {
                bestellung.Rechnungsbetrag=rechnungssumme;
            }
            _dal.SaveChanges();
        }

        public decimal RechnungsbetragBerechnen(IEnumerable<Bestellposition> positionen)
        {
            decimal rechnungssumme = 0;
            foreach (var p in positionen)
            {
                rechnungssumme += (p.Menge * (p.Produkt.Preis_netto / 100 * (100 + p.Produkt.Steuersatz)));
            }
            return rechnungssumme;
        }

        public IQueryable<Bestellung> Search(string search, int startPage)
        {
            return _dal.Bestellung
                .Where(i => i.Bestellung_ID.ToString().StartsWith(search) || i.User.User_ID.ToString().StartsWith(search))
                .Skip(startPage * Helper.Helper.PageSize)
                .Take(Helper.Helper.PageSize);
        } 
    }
}

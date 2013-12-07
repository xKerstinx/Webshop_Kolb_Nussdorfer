using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public interface IBLBestellung
    {
        Bestellung createOrder(List<Bestellposition> orderItems);
        IQueryable<Bestellung> GetAllBestellungen(int startPage);
        Bestellung GetBestellung(int id);
        void DeleteBestellung(int id);
        void DeleteAllBestellungen();
        void DeletePosition(int produktID, int bestellID);
        IQueryable<Bestellung> Search(string search, int startPage);
    }
}

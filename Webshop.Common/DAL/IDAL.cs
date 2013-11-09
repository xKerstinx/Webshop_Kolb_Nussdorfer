using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Common.DAL
{
    public interface IDAL
    {
        System.Data.Linq.Table<Produkt> Produkt { get; }
        System.Data.Linq.Table<User> User { get; }
        System.Data.Linq.Table<Usergruppe> Usergruppe { get; }
        System.Data.Linq.Table<Bestellposition> Bestellposition { get; }
        System.Data.Linq.Table<Bestellung> Bestellung { get; }

        void SaveChanges();


    }
}

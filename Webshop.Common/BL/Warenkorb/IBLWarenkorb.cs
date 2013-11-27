using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Common.BL
{
    public interface IBLWarenkorb
    {
        IQueryable<Webshop.Common.DAL.Produkt> GetAllWarenkorbItems();
        Webshop.Common.DAL.Produkt GetWarenkorbItem(int id);
        Webshop.Common.DAL.Produkt GetWarenkorbItem(string kurzbezeichnung);
        Webshop.Common.DAL.Produkt CreateWarenkorbItem();

    }
}

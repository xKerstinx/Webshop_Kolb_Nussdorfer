using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Common.BL
{
    public class BLWarenkorb: IBLWarenkorb
    {
        
        
        public IQueryable<DAL.Produkt> GetAllWarenkorbItems()
        {
           // var Warenkorb = (List<WarenkorbItemViewModel>);
            return null;
        }

        public DAL.Produkt GetWarenkorbItem(int id)
        {
            throw new NotImplementedException();
        }

        public DAL.Produkt GetWarenkorbItem(string kurzbezeichnung)
        {
            throw new NotImplementedException();
        }

        public DAL.Produkt CreateWarenkorbItem()
        {
            throw new NotImplementedException();
        }
    }
}

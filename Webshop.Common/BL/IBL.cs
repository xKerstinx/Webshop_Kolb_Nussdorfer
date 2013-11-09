using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Common.BL
{
    public interface IBL
    {
        IBLProdukt Produkt { get; }
        //brauch ma dann später noch
        //IBLAuthentication Auth {get;}
        //IBLUser User {get;}
        void SaveChanges();

    }
}

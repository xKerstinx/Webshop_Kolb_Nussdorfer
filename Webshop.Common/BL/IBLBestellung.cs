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
    }
}

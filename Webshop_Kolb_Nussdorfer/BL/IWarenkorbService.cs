using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Common.DAL;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.BL
{
    public interface IWarenkorbService
    {
        List<WarenkorbItemViewModel> GetItems();
        void AddItem(Produkt productId);
        void Update(List<WarenkorbItemViewModel> results);
        void SetItemQuantity(Produkt productID, int quantity);
        void RemoveItem(Produkt productID);
        List<Bestellposition> CreateBestellpositionen();
        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Common.DAL;
using Webshop_Kolb_Nussdorfer.Models;

namespace Webshop_Kolb_Nussdorfer.BL
{
    public class WarenkorbService : IWarenkorbService
    {
        private readonly IDAL _dal; 
        public WarenkorbService(IDAL dal)
        { 
            _dal = dal; 
        } 
        
        WarenkorbViewModel warenkorb
        {
            get
            {
                return WarenkorbViewModel.Instance;
            }
        }
        
        public List<WarenkorbItemViewModel> GetItems()
        {
            return warenkorb.Items;
        }

        /** 
    * AddItem() - Adds an item to the shopping  
    */
        public void AddItem(Produkt product)
        {
            // if list is empty simply add new object
            if (warenkorb.Items.Count == 0)
            {
                // Create a new item to add to the cart  
                WarenkorbItemViewModel newItem = new WarenkorbItemViewModel(product);
                newItem.Menge = 1;
                warenkorb.Items.Add(newItem);
            }
            else
            {
                // if item with this productId already exists, just increase quantity
                foreach (WarenkorbItemViewModel item in warenkorb.Items)
                {
                    if (item.Produkt.Produkt_ID==product.Produkt_ID)
                    {
                        item.Menge++;
                        return;
                    }
                }
                WarenkorbItemViewModel newItem = new WarenkorbItemViewModel(product);
                newItem.Menge = 1;
                warenkorb.Items.Add(newItem);
            }
        }

        public void Update(List<WarenkorbItemViewModel> results)
        {
            foreach (var item in results)
            {
                Produkt product = _dal.Produkt.Where(i => i.Produkt_ID == item.Produkt.Produkt_ID).FirstOrDefault();
                SetItemQuantity(product, item.Menge);
            }
        }

        //Changes quantity of item
        public void SetItemQuantity(Produkt product, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely  
            if (quantity == 0)
            {
                RemoveItem(product);
                return;
            }

            // Find the item and update the quantity  
            //WarenkorbItemViewModel updateItem=new WarenkorbItemViewModel(productID)
            foreach (WarenkorbItemViewModel item in warenkorb.Items)
            {
                if (item.Produkt.Produkt_ID == product.Produkt_ID)
                {
                    item.Menge = quantity;
                    return;
                }
            }
        }

        //Removes an item from the shopping cart 
        public void RemoveItem(Produkt product)
        {
            WarenkorbItemViewModel removedItem = new WarenkorbItemViewModel(product);
            warenkorb.Items.Remove(removedItem);
        }


        public List<Bestellposition> CreateBestellpositionen()
        {
            List<Bestellposition> bestellposList = new List<Bestellposition>();
            foreach (var item in warenkorb.Items)
            {
               var bestellpos = new Bestellposition();
                bestellpos.Produkt_ID = item.Produkt.Produkt_ID;
                //bestellpos.Produkt = produkt;
                bestellpos.Menge = item.Menge;
                bestellposList.Add(bestellpos);
            }

            //Warenkorb löschen
            warenkorb.Items = new List<WarenkorbItemViewModel>();
            return bestellposList;
        }

        /*public decimal GetSumme()
        {
            decimal subTotal = 0;
            foreach (WarenkorbItemViewModel item in warenkorb.Items)
                subTotal += (decimal)item.Produkt.Preis_brutto;

            return subTotal;
        }*/
    }
}
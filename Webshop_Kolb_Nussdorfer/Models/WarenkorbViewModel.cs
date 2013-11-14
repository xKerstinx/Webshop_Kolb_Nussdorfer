using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class WarenkorbViewModel
    {
        public List<WarenkorbItemViewModel> Items { get; private set; }

        public static readonly WarenkorbViewModel Instance;

        static WarenkorbViewModel()
        {
            if (HttpContext.Current.Session["Warenkorb"] == null)
            {
                Instance = new WarenkorbViewModel();
                Instance.Items = new List<WarenkorbItemViewModel>();
                HttpContext.Current.Session["Warenkorb"] = Instance;
            }
            else 
            {
                Instance = (WarenkorbViewModel)HttpContext.Current.Session["Warenkorb"];
            }
        }

        // ensures that no object can be created from outside
        protected WarenkorbViewModel() { }

        #region Item Modification Methods
        /** 
     * AddItem() - Adds an item to the shopping  
     */
        public void AddItem(int productId)
        {
            // if list is empty simply add new object
            if (Items.Count == 0)
            {
                // Create a new item to add to the cart  
                WarenkorbItemViewModel newItem = new WarenkorbItemViewModel(productId);
                newItem.Menge = 1;
                Items.Add(newItem);
            }
            else
            {
                // if item with this productId already exists, just increase quantity
                foreach (WarenkorbItemViewModel item in Items)
                {
                    if (item.Produkt.Produkt_ID == productId)
                    {
                        item.Menge++;
                        return;
                    }
                }
                WarenkorbItemViewModel newItem = new WarenkorbItemViewModel(productId);
                newItem.Menge = 1;
                Items.Add(newItem);
            }
        }

       
        //Changes quantity of item
        public void SetItemQuantity(int productID, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely  
            if (quantity == 0)
            {
                RemoveItem(productID);
                return;
            }

            // Find the item and update the quantity  
            //WarenkorbItemViewModel updateItem=new WarenkorbItemViewModel(productID)
            foreach (WarenkorbItemViewModel item in Items)
            {
                if (item.Produkt.Produkt_ID==productID)
                {
                    item.Menge = quantity;
                    return;
                }
            }
        }

        //Removes an item from the shopping cart 
        public void RemoveItem(int productID)
        {
            WarenkorbItemViewModel removedItem = new WarenkorbItemViewModel(productID);
            Items.Remove(removedItem);
        }
        #endregion

        #region Reporting Methods
       
     
        public decimal GetSumme()
        {
            decimal subTotal = 0;
            foreach (WarenkorbItemViewModel item in Items)
                subTotal += (decimal)item.Preis_brutto;

            return subTotal;
        }
       
        public List<Bestellposition> CreateBestellpositionen (List<WarenkorbItemViewModel> warenkorbItems){
	        List<Bestellposition> bestellposList= new List<Bestellposition>();
	        foreach(var item in warenkorbItems){
                //WebshopDataContext dataContext= new WebshopDataContext();
                //ProduktViewModel produkt = (ProduktViewModel)dataContext.Produkt.Where(i => i.Produkt_ID == item.Produkt.Produkt_ID);
		        var bestellpos= new Bestellposition();
		        bestellpos.Produkt_ID=item.Produkt.Produkt_ID;
                //bestellpos.Produkt = produkt;
		        bestellpos.Menge=item.Menge;
		        bestellposList.Add(bestellpos);
	        }

	        //Warenkorb löschen
	        Items=new List<WarenkorbItemViewModel>();
	        return bestellposList;
        }
        #endregion 
    }

    
}
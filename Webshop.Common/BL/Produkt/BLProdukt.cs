using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public class BLProdukt : Webshop.Common.BL.IBLProdukt
    {

        private readonly IDAL _dal; 
        public BLProdukt(IDAL dal)
        { 
            _dal = dal; 
        } 
        
        public IQueryable<Produkt> GetAllProdukte(int startPage) 
        {
            return _dal.Produkt
                .Skip(startPage * Helper.Helper.PageSize) 
                .Take(Helper.Helper.PageSize) ; 
        } 
        
        public Produkt GetProdukt(int id) 
        { 
            var obj = _dal.Produkt.Single(i => i.Produkt_ID == id); 
            return obj; 
        } 
        
        public Produkt GetProdukt(string kurzbezeichnung) 
        { 
            var obj = _dal.Produkt.Single(i => i.Kurzbezeichnung.ToLower() == kurzbezeichnung.ToLower());
            return obj; 
        } 
        
        public Produkt CreateProdukt() 
        { 
            var obj = new Produkt(); 
            _dal.Produkt.InsertOnSubmit(obj); 
            return obj; 
        }

        public void DeleteProdukt(int id)
        {
            _dal.Produkt.DeleteOnSubmit(_dal.Produkt.Where(i => i.Produkt_ID==id).FirstOrDefault());
            _dal.SaveChanges();

        }
        
        public IQueryable<Produkt> Search(string search, int startPage) 
        { 
            return _dal.Produkt // .Where(i => Security Filter) 
                .Where(i => i.Kurzbezeichnung.Contains(search) || i.Langbezeichnung.Contains(search) ||i.Produkt_ID.ToString().Contains(search)) 
                .Skip(startPage * Helper.Helper.PageSize) 
                .Take(Helper.Helper.PageSize) ; 
        } 
    }
}

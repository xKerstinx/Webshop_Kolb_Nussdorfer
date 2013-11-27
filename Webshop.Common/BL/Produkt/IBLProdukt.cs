using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Common.BL
{
    public interface IBLProdukt
    {
        IQueryable<Webshop.Common.DAL.Produkt> GetAllProdukte(int startPage);
        Webshop.Common.DAL.Produkt GetProdukt(int id);
        Webshop.Common.DAL.Produkt GetProdukt(string kurzbezeichnung);
        Webshop.Common.DAL.Produkt CreateProdukt();
        void DeleteProdukt(int id);
        
        //IQueryable<Webshop.Common.DAL.Produkt> GetTopContacts(int id);
        //IQueryable<Webshop.Common.DAL.Produkt> GetTopPosts(int id);
        IQueryable<Webshop.Common.DAL.Produkt> Search(string search, int startPage);
        //Webshop.Common.DAL.Produkt AddContact(int userID, int contactID);
    }
}

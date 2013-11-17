using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public class BLUser : Webshop.Common.BL.IBLUser
    {

        private readonly IDAL _dal;
        public BLUser(IDAL dal)
        {
            _dal = dal;
        }

        public IQueryable<User> GetAllUsers(int startPage)
        {
            return _dal.User
                .Skip(startPage * Helper.Helper.PageSize)
                .Take(Helper.Helper.PageSize);
        }

        public User GetUser(int id)
        {
            var obj = _dal.User.Single(i => i.User_ID == id); // check access rights 
            return obj;
        }

       public User GetUser(string benutzername)
        {
            var obj = _dal.User.Single(i => i.Benutzername.ToLower() == benutzername.ToLower()); // check access rights 
            return obj;
        }
       
        
        public User CreateUser()
        {
            var obj = new User();
            _dal.User.InsertOnSubmit(obj);
            return obj;
        }

        

        public IQueryable<User> Search(string search, int startPage)
        {
            return _dal.User // .Where(i => Security Filter) 
                .Where(i => i.Vorname.Contains(search) || i.Nachname.Contains(search) || i.User_ID.ToString().Contains(search))
                .Skip(startPage * Helper.Helper.PageSize)
                .Take(Helper.Helper.PageSize);
        }
    }
}

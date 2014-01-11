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
            var obj = _dal.User.Single(i => i.User_ID == id);
            return obj;
        }

       public User GetUser(string benutzername)
        {
            var obj = _dal.User.Single(i => i.Benutzername.ToLower() == benutzername.ToLower());
            return obj;
        }
       
        
        public User CreateUser()
        {
            var obj = new User();
            _dal.User.InsertOnSubmit(obj);
            return obj;
        }

        public void DeleteUser(int id)
        {
            _dal.User.DeleteOnSubmit(_dal.User.Where(i => i.User_ID == id).FirstOrDefault());
            _dal.SaveChanges();

        }

        

        public IQueryable<User> Search(string search, int startPage)
        {
            return _dal.User // .Where(i => Security Filter) 
                .Where(i => i.Vorname.Contains(search) || i.Nachname.Contains(search) || (i.Vorname+" "+i.Nachname).Contains(search) || i.User_ID.ToString().Contains(search))
                .Skip(startPage * Helper.Helper.PageSize)
                .Take(Helper.Helper.PageSize);
        }

        public String[] getUserRoles(string benutzername)
        {
            var user = _dal.User.FirstOrDefault(i => i.Benutzername.Equals(benutzername));
            if (user != null)
            {
                String[] roles = { user.Usergruppe.Usergruppenbezeichnung };
                return roles;
            }
            return null;
        }

    }
}

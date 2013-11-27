using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public class BLAuthentication : IBLAuthentication
    {
        private readonly IDAL _dal;
        public BLAuthentication(IDAL dal)
        {
            _dal = dal;
        }

        public bool userExists(string username, string password)
        {
            try
            {
                var dataContext = new WebshopDataContext();


                int usersCount = dataContext
                                    .User
                                    .Where(i => i.Benutzername == username && i.Passwort == Webshop.Common.Helper.StringHelper.MD5(password))
                                    .Count();


                if (usersCount == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User CreateUser()
        {
            var obj = new User();
            _dal.User.InsertOnSubmit(obj);
            return obj;
        }


    }
}

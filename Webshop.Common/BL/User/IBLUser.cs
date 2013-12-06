using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Common.BL
{
    public interface IBLUser
    {
        IQueryable<Webshop.Common.DAL.User> GetAllUsers(int startPage);
        Webshop.Common.DAL.User GetUser(int id);
        Webshop.Common.DAL.User GetUser(string nachname);
        Webshop.Common.DAL.User CreateUser();
        void DeleteUser(int id);

        IQueryable<Webshop.Common.DAL.User> Search(string search, int startPage);
        String[] getUserRoles(string benutzername);

    }
}

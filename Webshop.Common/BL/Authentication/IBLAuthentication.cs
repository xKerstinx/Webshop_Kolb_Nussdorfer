using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public interface IBLAuthentication
    {
        int MinPasswordLength {get;}
        bool userExists(string username, string password);
        User CreateUser();
        MembershipCreateStatus ForgotPassword(string username, string email);
        void SignOut();
        void SignIn(string userName, bool createPersistentCookie);
        //bool IsAdmin(string username);

    }
}

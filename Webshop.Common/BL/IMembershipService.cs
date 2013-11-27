using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Security;

namespace Webshop.Common.BL
{
    interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(RegisterViewModel user, string usertype);
        MembershipCreateStatus ForgotPassword(string username, string email);
    }
}

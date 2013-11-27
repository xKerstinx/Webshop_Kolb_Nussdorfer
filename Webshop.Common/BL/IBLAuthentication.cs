using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public interface IBLAuthentication
    {
        bool userExists(string username, string password);
        User CreateUser();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Webshop.Common.DAL;

namespace Webshop.Common.BL
{
    public class BLAuthentication : IBLAuthentication
    {
        public int MinPasswordLength { get { return Membership.Provider.MinRequiredPasswordLength; } }
        //private readonly MembershipProvider _provider;
        private readonly IDAL _dal;
        private readonly IBLUser _blUser;
        
        public BLAuthentication(IDAL dal, IBLUser blUser)
        {
            _dal = dal;
            _blUser = blUser;
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
            //if (_dal.Users.SingleOrDefault(i => i.Mail.ToLower() == username.ToLower()) != null) return false;



            //var obj = new User();
            //_dal.User.InsertOnSubmit(obj);
           /* obj.Mail = username;
            obj.Password = GetHash(password);
            obj.FirstName = string.Empty;
            obj.LastName = string.Empty;
            _dal.SaveChanges();*/

            //return true;


            var obj = new User();
            _dal.User.InsertOnSubmit(obj);
            return obj;
        }


        public MembershipCreateStatus ForgotPassword(string username, string email)
        {
            MembershipCreateStatus status;
            try
            {
                User user = _dal
                                .User
                                .Where(i => i.Benutzername.Equals(username) && i.EMail.Equals(email))
                                .FirstOrDefault();

                if (user == null)
                {
                    return MembershipCreateStatus.UserRejected;
                }

                user.Passwort = Webshop.Common.Helper.StringHelper.MD5("1default2");
                _dal.SaveChanges();
                status = MembershipCreateStatus.Success;
            }
            catch (Exception)
            {
                //TODO: Status ist nicht immer ProdiverError
                status = MembershipCreateStatus.UserRejected;
            }
            return status;
        }

        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            // update identity
            //String[] userRoles = _blUser.getUserRoles(HttpContext.Current.User.Identity.Name);
            //HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(HttpContext.Current.User.Identity.Name), userRoles);
            
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

    }
}

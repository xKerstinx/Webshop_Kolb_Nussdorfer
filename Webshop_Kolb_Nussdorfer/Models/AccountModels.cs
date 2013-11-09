using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using Webshop.Common.DAL;
using System.ComponentModel;
using System.Linq;

namespace Webshop_Kolb_Nussdorfer.Models
{
    #region Modelle
    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessage = "Das neue Kennwort entspricht nicht dem Bestätigungskennwort.")]
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Aktuelles Kennwort")]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Neues Kennwort")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Neues Kennwort bestätigen")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [DisplayName("Benutzername")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort")]
        public string Password { get; set; }

        [DisplayName("Speichern?")]
        public bool RememberMe { get; set; }

        public bool userExists()
        {
            try
            {
                var dataContext = new WebshopDataContext();


                int usersCount = dataContext
                                    .User
                                    .Where(i => i.Benutzername == this.Username && i.Passwort == Webshop.Common.Helper.StringHelper.MD5(this.Password))
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
    }

    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "Das Kennwort entspricht nicht dem Bestätigungskennwort.")]
    public class RegisterModel
    {
        [Required]
        [DisplayName("Benutzername")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail-Adresse")]
        public string Email { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort bestätigen")]
        public string ConfirmPassword { get; set; }

        public bool Success = false;
    }

    public class ForgotPasswordModel
    {
        [Required]
        [DisplayName("Benutzername")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail-Adresse")]
        public string Email { get; set; }

        public bool Success = false;
    }
    #endregion

    #region Services
    // Der FormsAuthentication-Typ ist versiegelt und enthält statische Member, weshalb
    // Komponententests des Codes, von dem die Member aufgerufen werden, nicht ganz einfach sind. Von der Schnittstellen- und Helper-Klasse weiter unten wird veranschaulicht,
    // wie ein abstrakter Wrapper für einen solchen Typ erstellt wird, um dafür zu sorgen, dass für den AccountController-
    // Code Komponententests ausgeführt werden können.

    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email, string usertype);
        MembershipCreateStatus ForgotPassword(string username, string email);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "password");

            return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string username, string passwort, string email, string usergruppe)
        {
            if (String.IsNullOrEmpty(username)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "userName");
            if (String.IsNullOrEmpty(passwort)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "password");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "email");


           
            WebshopDataContext dataContext = new WebshopDataContext();
            

            MembershipCreateStatus status;
            try
            {
                User newuser = new User();
                newuser.Benutzername = username;
                newuser.Passwort = Webshop.Common.Helper.StringHelper.MD5(passwort);
                newuser.EMail = email;
                newuser.Usergruppe =dataContext
                                        .Usergruppe
                                        .Where(i => i.Usergruppenbezeichnung.Equals(usergruppe))
                                        .FirstOrDefault();
                    
                dataContext.User.InsertOnSubmit(newuser);
                dataContext.SubmitChanges();
                status = MembershipCreateStatus.Success;
            }
            catch (Exception e)
            {
                //TODO: Status ist nicht immer ProdiverError
                
                status = MembershipCreateStatus.ProviderError;
            }
            return status;
        }

        public MembershipCreateStatus ForgotPassword(string username, string email)
        {
            if (String.IsNullOrEmpty(username)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "userName");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "email");

            WebshopDataContext dataContext = new WebshopDataContext();

            MembershipCreateStatus status;
            try
            {
                User user = dataContext
                                .User
                                .Where(i => i.Benutzername.Equals(username) && i.EMail.Equals(email))
                                .FirstOrDefault();
                    
                user.Passwort = "default";

                dataContext.SubmitChanges();
                status = MembershipCreateStatus.Success;
            }
            catch (Exception)
            {
                //TODO: Status ist nicht immer ProdiverError
                status = MembershipCreateStatus.UserRejected;
            }
            return status;
        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion

    #region Validation
    public static class AccountValidation
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // Unter "http://go.microsoft.com/fwlink/?LinkID=177550" finden Sie
            // eine vollständige Liste mit Statuscodes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Der Benutzername ist bereits vorhanden. Geben Sie einen anderen Benutzernamen ein.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Für diese E-Mail-Adresse ist bereits ein Benutzername vorhanden. Geben Sie eine andere E-Mail-Adresse ein.";

                case MembershipCreateStatus.InvalidPassword:
                    return "Das angegebene Kennwort ist ungültig. Geben Sie einen gültigen Kennwortwert ein.";

                case MembershipCreateStatus.InvalidEmail:
                    return "Die angegebene E-Mail-Adresse ist ungültig. Überprüfen Sie den Wert, und wiederholen Sie den Vorgang.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "Die angegebene Kennwortabrufantwort ist ungültig. Überprüfen Sie den Wert, und wiederholen Sie den Vorgang.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "Die angegebene Kennwortabruffrage ist ungültig. Überprüfen Sie den Wert, und wiederholen Sie den Vorgang.";

                case MembershipCreateStatus.InvalidUserName:
                    return "Der angegebene Benutzername ist ungültig. Überprüfen Sie den Wert, und wiederholen Sie den Vorgang.";

                case MembershipCreateStatus.ProviderError:
                    return "Unbekannter Fehler. Überprüfen Sie die Eingabe, und wiederholen Sie den Vorgang. Sollte das Problem weiterhin bestehen, wenden Sie sich an den zuständigen Systemadministrator.";

                case MembershipCreateStatus.UserRejected:
                    return "Die Username/Email-Konstellation existiert nicht. Überprüfen Sie die Eingabe, und wiederholen Sie den Vorgang.";

                default:
                    return "Unbekannter Fehler. Überprüfen Sie die Eingabe, und wiederholen Sie den Vorgang. Sollte das Problem weiterhin bestehen, wenden Sie sich an den zuständigen Systemadministrator.";
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' und '{1}' stimmen nicht überein.";
        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' muss mindestens {1} Zeichen lang sein.";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }
    #endregion

}

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
    public class ChangePasswordViewModel
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

        /*public bool userExists()
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
        }*/
    }

    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "Das Kennwort entspricht nicht dem Bestätigungskennwort.")]
    public class RegisterViewModel
    {
       /* [Required]
        [DisplayName("Benutzername")]
        public string Benutzername { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail-Adresse")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Vorname")]
        public string Vorname { get; set; }

        [Required]
        [DisplayName("Nachname")]
        public string Nachname { get; set; }

        [Required]
        [DisplayName("Adresse")]
        public string Adresse { get; set; }

        [Required]
        [DisplayName("Ort")]
        public string Ort { get; set; }

        [Required]
        [DisplayName("PLZ")]
        public string Plz { get; set; }

        [Required]
        [DisplayName("Land")]
        public string Land { get; set; }

        [DisplayName("Telefonnummer")]
        public string Telefonnummer { get; set; }

        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort")]
        public string Password { get; set; }*/

        public UserViewModel User {get;set;}

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


        public void ApplyChanges(User newUser)
        {
            // ist nur notwendig, weil ich zusätzliches Password property hab, 
            //weil ich nicht weiß wie ich in das Password Property vom User komm für Properties must match
            User.Passwort = this.Password;
            User.ApplyChanges(newUser);
        }



    }

    public class ForgotPasswordViewModel
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


    public class AccountMembershipService 
    {
        public static bool IsAdmin(string username)
        {
            string userGruppe = "";
            WebshopDataContext dataContext = new WebshopDataContext();
            try
            {
                userGruppe = dataContext.User
                   .Where(i => i.Benutzername == username)
                   .Select(i => i.Usergruppe.Usergruppenbezeichnung)
                   .FirstOrDefault();
            }
            catch (Exception)
            {
                return false;
            }
            // neu hinzugefügt
            if (userGruppe!=null && userGruppe.Equals("Admin"))
            {
                return true;
            }

            return false;
        }

    }


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

}
    #endregion
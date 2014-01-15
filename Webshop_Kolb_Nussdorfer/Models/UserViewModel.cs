using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Webshop.Common.DAL;
using System.Web.Mvc;
using System.ComponentModel;
using System.Web.Security;

namespace Webshop_Kolb_Nussdorfer.Models
{
    [PropertiesMustMatch("Passwort", "PasswortRetype", ErrorMessage = "Das Kennwort stimmt nicht mit dem Bestätigungskennwort überein")]
    public class UserViewModel 
    {
        #region Properties
        private readonly IDAL _dal;

        public int User_ID { get; private set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Der Vorname muss eine Länge von min. 3 und max. 30 Zeichen haben")]
        [DisplayName("Vorname")]
        public string Vorname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Der Nachname muss eine Länge von min. 3 und max. 30 Zeichen haben")]
        [DisplayName("Nachname")]
        public string Nachname { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Die Adresse muss eine Länge von min. 6 und max. 30 Zeichen haben")]
        [DisplayName("Adresse")]
        public string Adresse { get; set; }

        [Required]
       // [RegularExpression("([0-9]{4})", ErrorMessage="Dies ist keine gültige Postleitzahl")]
        [DisplayName("PLZ")]
        public string PLZ { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Der Ort muss eine Länge von min. 3 und max. 30 Zeichen haben")]
        [DataType(DataType.Text)]
        [DisplayName("Ort")]
        public string Ort { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Das Land muss eine Länge von min. 3 und max. 30 Zeichen haben")]
        [DataType(DataType.Text)]
        [DisplayName("Land")]
        public string Land { get; set; }

        [Required]
        [RegularExpression("[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})", ErrorMessage="Dies ist keine gültige E-Mail-Adresse")]
        [DisplayName("E-Mail-Adresse")]
        public string EMail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("([0-9]*)", ErrorMessage = "Dies ist keine gültige Telefonnummer")]
        [DisplayName("Telefonnummer - zB 00430121354")]
        public string Telefonnummer { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Der Benutzername muss eine Länge von min. 3 und max. 30 Zeichen haben")]
        [DataType(DataType.Text)]
        [DisplayName("Benutzername")]
        public string Benutzername { get; set; }

        [Required]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort")]
        public string Passwort { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort wiederholen")]
        public string PasswortRetype { get; set; }

        
        public int Usergruppe_ID { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get { return Vorname + " " + Nachname; }
            set { }
        }

        [DisplayName("Plz+Ort")]
        public string PlzOrt
        {
            get { return PLZ + " " + Ort; }
            set { }
        }

        [DisplayName("Usergruppe")]
        public string Usergruppe
        {
            get
            {
                return Usergruppen.Where(i => i.Value == Usergruppe_ID.ToString()).First().Text;
            }
        }


        public IEnumerable<SelectListItem> Usergruppen
        {
            get
            {
                return new[]{
                    new SelectListItem() {Text = "Admin", Value = "1"}, 
                    new SelectListItem() {Text = "Kunde", Value = "2"},
                };
            }
        }

        public User user = null;
        #endregion

        public UserViewModel()
        {
            _dal = new Webshop.Common.DAL.WebshopDataContext();
        }

        public UserViewModel(User user)
        {
            //_dal = new Webshop.Common.DAL.WebshopDataContext();

            this.User_ID = user.User_ID;
            this.Vorname = user.Vorname;
            this.Nachname = user.Nachname;
            this.Adresse = user.Adresse;
            this.PLZ = user.PLZ;
            this.Ort = user.Ort;
            this.Land = user.Land;
            this.EMail = user.EMail;
            this.Telefonnummer = user.Telefonnummer;
            this.Benutzername = user.Benutzername;
            this.Passwort = user.Passwort;
            this.PasswortRetype = user.Passwort;
            this.Usergruppe_ID = user.Usergruppe_ID;
            this.user = user;

        }


        public void ApplyChanges(User user, ModelStateDictionary modelState)
        {
            MembershipCreateStatus createStatus;

            //check ob Benutzername schon vorhanden
            if (_dal.User.Where(i => i.Benutzername.Equals(this.Benutzername)).Count() != 0 && (user.Benutzername==null||!user.Benutzername.Equals(this.Benutzername)))
            {
                createStatus = MembershipCreateStatus.DuplicateUserName;
                modelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                return;
            }
            //Check ob EMail Adresse schon vorhanden
            if (_dal.User.Where(i => i.EMail.Equals(this.EMail)).Count() != 0 && (user.EMail==null||!user.EMail.Equals(this.EMail)))
            {
                createStatus = MembershipCreateStatus.DuplicateEmail;
                modelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                return;
            }

            user.Vorname = this.Vorname;
            user.Nachname = this.Nachname;
            user.Adresse = this.Adresse;
            user.PLZ = this.PLZ;
            user.Ort = this.Ort;
            user.Land = this.Land;
            user.EMail = this.EMail;
            user.Telefonnummer = this.Telefonnummer;
            user.Benutzername = this.Benutzername;
            if (user.Passwort != null)
            {
                // Es handelt sich um eine Bearbeitung und Passwort hat sich verändert
                if (!user.Passwort.Equals(this.Passwort))
                {
                    user.Passwort = Webshop.Common.Helper.StringHelper.MD5(this.Passwort);
                }
            }
            else
            {
                user.Passwort = Webshop.Common.Helper.StringHelper.MD5(this.Passwort);
            }
            user.Usergruppe_ID = this.Usergruppe_ID;
        }

    }
}
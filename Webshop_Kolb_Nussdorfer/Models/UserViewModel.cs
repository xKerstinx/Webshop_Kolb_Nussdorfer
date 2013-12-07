using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Webshop.Common.DAL;
using System.Web.Mvc;
using System.ComponentModel;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class UserViewModel 
    {
        #region Properties

        public int User_ID { get; private set; }
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
        [DisplayName("PLZ")]
        public string PLZ { get; set; }

        [Required]
        [DisplayName("Ort")]
        public string Ort { get; set; }

        [Required]
        [DisplayName("Land")]
        public string Land { get; set; }

        [Required]
        [DisplayName("E-Mail-Adresse")]
        public string EMail { get; set; }

        [DisplayName("Telefonnummer")]
        public string Telefonnummer { get; set; }

        [Required]
        [DisplayName("Benutzername")]
        public string Benutzername { get; set; }

        [DisplayName("Kennwort")]
        public string Passwort { get; set; }

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


        public IEnumerable<SelectListItem> Usergruppen
        {
            get
            {
                return new[]{
                    new SelectListItem(), 
                    new SelectListItem() {Text = "Administrator", Value = "1"}, 
                    new SelectListItem() {Text = "Kunde", Value = "2"},
                };
            }
        }

        public User user = null;
        #endregion

        public UserViewModel()
        {
        }

        public UserViewModel(User user)
        {
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
            this.Usergruppe_ID = user.Usergruppe_ID;

        }


        // TODO Passwort raus aus Apply Chances
        public void ApplyChanges(User user)
        {
            user.Vorname = this.Vorname;
            user.Nachname = this.Nachname;
            user.Adresse = this.Adresse;
            user.PLZ = this.PLZ;
            user.Ort = this.Ort;
            user.Land = this.Land;
            user.EMail = this.EMail;
            user.Telefonnummer = this.Telefonnummer;
            user.Benutzername = this.Benutzername;
            if (!string.IsNullOrEmpty(this.Passwort))
            {
                user.Passwort = Webshop.Common.Helper.StringHelper.MD5(this.Passwort);
            }
            user.Usergruppe_ID = this.Usergruppe_ID;
        }
    }
}
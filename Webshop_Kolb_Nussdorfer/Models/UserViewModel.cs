using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Webshop.Common.DAL;

namespace Webshop_Kolb_Nussdorfer.Models
{
    public class UserViewModel
    {
       #region Properties

        public int User_ID { get; private set; }
        [Required]
        public string Vorname { get; set; }
        [Required]
        public string Nachname { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string PLZ { get; set; }
        [Required]
        public string Ort { get; set; }
        [Required]
        public string Land { get; set; }
        [Required]
        public string EMail { get; set; }
        public string Telefonnummer { get; set; }
        [Required]
        public string Benutzername { get; set; }
        [Required]
        public string Passwort { get; set; }
        public int Usergruppe_ID { get; private set; }

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

        }
    }
}
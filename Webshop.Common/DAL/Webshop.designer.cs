﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18052
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webshop.Common.DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Webshop")]
	public partial class WebshopDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnCreated();
    partial void InsertBestellposition(Bestellposition instance);
    partial void UpdateBestellposition(Bestellposition instance);
    partial void DeleteBestellposition(Bestellposition instance);
    partial void InsertUsergruppe(Usergruppe instance);
    partial void UpdateUsergruppe(Usergruppe instance);
    partial void DeleteUsergruppe(Usergruppe instance);
    partial void InsertBestellung(Bestellung instance);
    partial void UpdateBestellung(Bestellung instance);
    partial void DeleteBestellung(Bestellung instance);
    partial void InsertProdukt(Produkt instance);
    partial void UpdateProdukt(Produkt instance);
    partial void DeleteProdukt(Produkt instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public WebshopDataContext() : 
				base(global::Webshop.Common.Properties.Settings.Default.WebshopConnectionString2, mappingSource)
		{
			OnCreated();
		}
		
		public WebshopDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebshopDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebshopDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebshopDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Bestellposition> Bestellposition
		{
			get
			{
				return this.GetTable<Bestellposition>();
			}
		}
		
		public System.Data.Linq.Table<Usergruppe> Usergruppe
		{
			get
			{
				return this.GetTable<Usergruppe>();
			}
		}
		
		public System.Data.Linq.Table<Bestellung> Bestellung
		{
			get
			{
				return this.GetTable<Bestellung>();
			}
		}
		
		public System.Data.Linq.Table<Produkt> Produkt
		{
			get
			{
				return this.GetTable<Produkt>();
			}
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Bestellposition")]
	public partial class Bestellposition : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Produkt_ID;
		
		private int _Bestellung_ID;
		
		private int _Menge;
		
		private EntityRef<Bestellung> _Bestellung;
		
		private EntityRef<Produkt> _Produkt;
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProdukt_IDChanging(int value);
    partial void OnProdukt_IDChanged();
    partial void OnBestellung_IDChanging(int value);
    partial void OnBestellung_IDChanged();
    partial void OnMengeChanging(int value);
    partial void OnMengeChanged();
    #endregion
		
		public Bestellposition()
		{
			this._Bestellung = default(EntityRef<Bestellung>);
			this._Produkt = default(EntityRef<Produkt>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Produkt_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Produkt_ID
		{
			get
			{
				return this._Produkt_ID;
			}
			set
			{
				if ((this._Produkt_ID != value))
				{
					if (this._Produkt.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProdukt_IDChanging(value);
					this.SendPropertyChanging();
					this._Produkt_ID = value;
					this.SendPropertyChanged("Produkt_ID");
					this.OnProdukt_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bestellung_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Bestellung_ID
		{
			get
			{
				return this._Bestellung_ID;
			}
			set
			{
				if ((this._Bestellung_ID != value))
				{
					if (this._Bestellung.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBestellung_IDChanging(value);
					this.SendPropertyChanging();
					this._Bestellung_ID = value;
					this.SendPropertyChanged("Bestellung_ID");
					this.OnBestellung_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Menge", DbType="Int NOT NULL")]
		public int Menge
		{
			get
			{
				return this._Menge;
			}
			set
			{
				if ((this._Menge != value))
				{
					this.OnMengeChanging(value);
					this.SendPropertyChanging();
					this._Menge = value;
					this.SendPropertyChanged("Menge");
					this.OnMengeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Bestellung_Bestellposition", Storage="_Bestellung", ThisKey="Bestellung_ID", OtherKey="Bestellung_ID", IsForeignKey=true)]
		public Bestellung Bestellung
		{
			get
			{
				return this._Bestellung.Entity;
			}
			set
			{
				Bestellung previousValue = this._Bestellung.Entity;
				if (((previousValue != value) 
							|| (this._Bestellung.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Bestellung.Entity = null;
						previousValue.Bestellposition.Remove(this);
					}
					this._Bestellung.Entity = value;
					if ((value != null))
					{
						value.Bestellposition.Add(this);
						this._Bestellung_ID = value.Bestellung_ID;
					}
					else
					{
						this._Bestellung_ID = default(int);
					}
					this.SendPropertyChanged("Bestellung");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Produkt_Bestellposition", Storage="_Produkt", ThisKey="Produkt_ID", OtherKey="Produkt_ID", IsForeignKey=true)]
		public Produkt Produkt
		{
			get
			{
				return this._Produkt.Entity;
			}
			set
			{
				Produkt previousValue = this._Produkt.Entity;
				if (((previousValue != value) 
							|| (this._Produkt.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Produkt.Entity = null;
						previousValue.Bestellposition.Remove(this);
					}
					this._Produkt.Entity = value;
					if ((value != null))
					{
						value.Bestellposition.Add(this);
						this._Produkt_ID = value.Produkt_ID;
					}
					else
					{
						this._Produkt_ID = default(int);
					}
					this.SendPropertyChanged("Produkt");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usergruppe")]
	public partial class Usergruppe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Usergruppe_ID;
		
		private string _Usergruppenbezeichnung;
		
		private EntitySet<User> _User;
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsergruppe_IDChanging(int value);
    partial void OnUsergruppe_IDChanged();
    partial void OnUsergruppenbezeichnungChanging(string value);
    partial void OnUsergruppenbezeichnungChanged();
    #endregion
		
		public Usergruppe()
		{
			this._User = new EntitySet<User>(new Action<User>(this.attach_User), new Action<User>(this.detach_User));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usergruppe_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Usergruppe_ID
		{
			get
			{
				return this._Usergruppe_ID;
			}
			set
			{
				if ((this._Usergruppe_ID != value))
				{
					this.OnUsergruppe_IDChanging(value);
					this.SendPropertyChanging();
					this._Usergruppe_ID = value;
					this.SendPropertyChanged("Usergruppe_ID");
					this.OnUsergruppe_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usergruppenbezeichnung", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Usergruppenbezeichnung
		{
			get
			{
				return this._Usergruppenbezeichnung;
			}
			set
			{
				if ((this._Usergruppenbezeichnung != value))
				{
					this.OnUsergruppenbezeichnungChanging(value);
					this.SendPropertyChanging();
					this._Usergruppenbezeichnung = value;
					this.SendPropertyChanged("Usergruppenbezeichnung");
					this.OnUsergruppenbezeichnungChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usergruppe_User", Storage="_User", ThisKey="Usergruppe_ID", OtherKey="Usergruppe_ID")]
		public EntitySet<User> User
		{
			get
			{
				return this._User;
			}
			set
			{
				this._User.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_User(User entity)
		{
			this.SendPropertyChanging();
			entity.Usergruppe = this;
		}
		
		private void detach_User(User entity)
		{
			this.SendPropertyChanging();
			entity.Usergruppe = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Bestellung")]
	public partial class Bestellung : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Bestellung_ID;
		
		private System.DateTime _Bestelldatum;
		
		private System.Nullable<decimal> _Versandkosten;
		
		private System.Nullable<decimal> _Rechnungsbetrag;
		
		private int _User_ID;
		
		private EntitySet<Bestellposition> _Bestellposition;
		
		private EntityRef<User> _User;
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBestellung_IDChanging(int value);
    partial void OnBestellung_IDChanged();
    partial void OnBestelldatumChanging(System.DateTime value);
    partial void OnBestelldatumChanged();
    partial void OnVersandkostenChanging(System.Nullable<decimal> value);
    partial void OnVersandkostenChanged();
    partial void OnRechnungsbetragChanging(System.Nullable<decimal> value);
    partial void OnRechnungsbetragChanged();
    partial void OnUser_IDChanging(int value);
    partial void OnUser_IDChanged();
    #endregion
		
		public Bestellung()
		{
			this._Bestellposition = new EntitySet<Bestellposition>(new Action<Bestellposition>(this.attach_Bestellposition), new Action<Bestellposition>(this.detach_Bestellposition));
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bestellung_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Bestellung_ID
		{
			get
			{
				return this._Bestellung_ID;
			}
			set
			{
				if ((this._Bestellung_ID != value))
				{
					this.OnBestellung_IDChanging(value);
					this.SendPropertyChanging();
					this._Bestellung_ID = value;
					this.SendPropertyChanged("Bestellung_ID");
					this.OnBestellung_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bestelldatum", DbType="DateTime NOT NULL")]
		public System.DateTime Bestelldatum
		{
			get
			{
				return this._Bestelldatum;
			}
			set
			{
				if ((this._Bestelldatum != value))
				{
					this.OnBestelldatumChanging(value);
					this.SendPropertyChanging();
					this._Bestelldatum = value;
					this.SendPropertyChanged("Bestelldatum");
					this.OnBestelldatumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Versandkosten", DbType="Decimal(5,2)")]
		public System.Nullable<decimal> Versandkosten
		{
			get
			{
				return this._Versandkosten;
			}
			set
			{
				if ((this._Versandkosten != value))
				{
					this.OnVersandkostenChanging(value);
					this.SendPropertyChanging();
					this._Versandkosten = value;
					this.SendPropertyChanged("Versandkosten");
					this.OnVersandkostenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rechnungsbetrag", DbType="Decimal(5,2)")]
		public System.Nullable<decimal> Rechnungsbetrag
		{
			get
			{
				return this._Rechnungsbetrag;
			}
			set
			{
				if ((this._Rechnungsbetrag != value))
				{
					this.OnRechnungsbetragChanging(value);
					this.SendPropertyChanging();
					this._Rechnungsbetrag = value;
					this.SendPropertyChanged("Rechnungsbetrag");
					this.OnRechnungsbetragChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_ID", DbType="Int NOT NULL")]
		public int User_ID
		{
			get
			{
				return this._User_ID;
			}
			set
			{
				if ((this._User_ID != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUser_IDChanging(value);
					this.SendPropertyChanging();
					this._User_ID = value;
					this.SendPropertyChanged("User_ID");
					this.OnUser_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Bestellung_Bestellposition", Storage="_Bestellposition", ThisKey="Bestellung_ID", OtherKey="Bestellung_ID")]
		public EntitySet<Bestellposition> Bestellposition
		{
			get
			{
				return this._Bestellposition;
			}
			set
			{
				this._Bestellposition.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Bestellung", Storage="_User", ThisKey="User_ID", OtherKey="User_ID", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Bestellung.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Bestellung.Add(this);
						this._User_ID = value.User_ID;
					}
					else
					{
						this._User_ID = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Bestellposition(Bestellposition entity)
		{
			this.SendPropertyChanging();
			entity.Bestellung = this;
		}
		
		private void detach_Bestellposition(Bestellposition entity)
		{
			this.SendPropertyChanging();
			entity.Bestellung = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Produkt")]
	public partial class Produkt : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Produkt_ID;
		
		private string _Kurzbezeichnung;
		
		private string _Langbezeichnung;
		
		private int _Steuersatz;
		
		private decimal _Preis_netto;
		
		private string _Zutaten;
		
		private EntitySet<Bestellposition> _Bestellposition;
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProdukt_IDChanging(int value);
    partial void OnProdukt_IDChanged();
    partial void OnKurzbezeichnungChanging(string value);
    partial void OnKurzbezeichnungChanged();
    partial void OnLangbezeichnungChanging(string value);
    partial void OnLangbezeichnungChanged();
    partial void OnSteuersatzChanging(int value);
    partial void OnSteuersatzChanged();
    partial void OnPreis_nettoChanging(decimal value);
    partial void OnPreis_nettoChanged();
    partial void OnZutatenChanging(string value);
    partial void OnZutatenChanged();
    #endregion
		
		public Produkt()
		{
			this._Bestellposition = new EntitySet<Bestellposition>(new Action<Bestellposition>(this.attach_Bestellposition), new Action<Bestellposition>(this.detach_Bestellposition));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Produkt_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Produkt_ID
		{
			get
			{
				return this._Produkt_ID;
			}
			set
			{
				if ((this._Produkt_ID != value))
				{
					this.OnProdukt_IDChanging(value);
					this.SendPropertyChanging();
					this._Produkt_ID = value;
					this.SendPropertyChanged("Produkt_ID");
					this.OnProdukt_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kurzbezeichnung", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Kurzbezeichnung
		{
			get
			{
				return this._Kurzbezeichnung;
			}
			set
			{
				if ((this._Kurzbezeichnung != value))
				{
					this.OnKurzbezeichnungChanging(value);
					this.SendPropertyChanging();
					this._Kurzbezeichnung = value;
					this.SendPropertyChanged("Kurzbezeichnung");
					this.OnKurzbezeichnungChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Langbezeichnung", DbType="VarChar(300)")]
		public string Langbezeichnung
		{
			get
			{
				return this._Langbezeichnung;
			}
			set
			{
				if ((this._Langbezeichnung != value))
				{
					this.OnLangbezeichnungChanging(value);
					this.SendPropertyChanging();
					this._Langbezeichnung = value;
					this.SendPropertyChanged("Langbezeichnung");
					this.OnLangbezeichnungChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Steuersatz", DbType="Int NOT NULL")]
		public int Steuersatz
		{
			get
			{
				return this._Steuersatz;
			}
			set
			{
				if ((this._Steuersatz != value))
				{
					this.OnSteuersatzChanging(value);
					this.SendPropertyChanging();
					this._Steuersatz = value;
					this.SendPropertyChanged("Steuersatz");
					this.OnSteuersatzChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Preis_netto", DbType="Decimal(5,2) NOT NULL")]
		public decimal Preis_netto
		{
			get
			{
				return this._Preis_netto;
			}
			set
			{
				if ((this._Preis_netto != value))
				{
					this.OnPreis_nettoChanging(value);
					this.SendPropertyChanging();
					this._Preis_netto = value;
					this.SendPropertyChanged("Preis_netto");
					this.OnPreis_nettoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Zutaten", DbType="VarChar(300)")]
		public string Zutaten
		{
			get
			{
				return this._Zutaten;
			}
			set
			{
				if ((this._Zutaten != value))
				{
					this.OnZutatenChanging(value);
					this.SendPropertyChanging();
					this._Zutaten = value;
					this.SendPropertyChanged("Zutaten");
					this.OnZutatenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Produkt_Bestellposition", Storage="_Bestellposition", ThisKey="Produkt_ID", OtherKey="Produkt_ID")]
		public EntitySet<Bestellposition> Bestellposition
		{
			get
			{
				return this._Bestellposition;
			}
			set
			{
				this._Bestellposition.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Bestellposition(Bestellposition entity)
		{
			this.SendPropertyChanging();
			entity.Produkt = this;
		}
		
		private void detach_Bestellposition(Bestellposition entity)
		{
			this.SendPropertyChanging();
			entity.Produkt = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _User_ID;
		
		private string _Vorname;
		
		private string _Nachname;
		
		private string _Adresse;
		
		private string _PLZ;
		
		private string _Ort;
		
		private string _Land;
		
		private string _EMail;
		
		private string _Telefonnummer;
		
		private string _Benutzername;
		
		private string _Passwort;
		
		private int _Usergruppe_ID;
		
		private EntitySet<Bestellung> _Bestellung;
		
		private EntityRef<Usergruppe> _Usergruppe;
		
    #region Definitionen der Erweiterungsmethoden
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUser_IDChanging(int value);
    partial void OnUser_IDChanged();
    partial void OnVornameChanging(string value);
    partial void OnVornameChanged();
    partial void OnNachnameChanging(string value);
    partial void OnNachnameChanged();
    partial void OnAdresseChanging(string value);
    partial void OnAdresseChanged();
    partial void OnPLZChanging(string value);
    partial void OnPLZChanged();
    partial void OnOrtChanging(string value);
    partial void OnOrtChanged();
    partial void OnLandChanging(string value);
    partial void OnLandChanged();
    partial void OnEMailChanging(string value);
    partial void OnEMailChanged();
    partial void OnTelefonnummerChanging(string value);
    partial void OnTelefonnummerChanged();
    partial void OnBenutzernameChanging(string value);
    partial void OnBenutzernameChanged();
    partial void OnPasswortChanging(string value);
    partial void OnPasswortChanged();
    partial void OnUsergruppe_IDChanging(int value);
    partial void OnUsergruppe_IDChanged();
    #endregion
		
		public User()
		{
			this._Bestellung = new EntitySet<Bestellung>(new Action<Bestellung>(this.attach_Bestellung), new Action<Bestellung>(this.detach_Bestellung));
			this._Usergruppe = default(EntityRef<Usergruppe>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_User_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int User_ID
		{
			get
			{
				return this._User_ID;
			}
			set
			{
				if ((this._User_ID != value))
				{
					this.OnUser_IDChanging(value);
					this.SendPropertyChanging();
					this._User_ID = value;
					this.SendPropertyChanged("User_ID");
					this.OnUser_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vorname", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Vorname
		{
			get
			{
				return this._Vorname;
			}
			set
			{
				if ((this._Vorname != value))
				{
					this.OnVornameChanging(value);
					this.SendPropertyChanging();
					this._Vorname = value;
					this.SendPropertyChanged("Vorname");
					this.OnVornameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nachname", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Nachname
		{
			get
			{
				return this._Nachname;
			}
			set
			{
				if ((this._Nachname != value))
				{
					this.OnNachnameChanging(value);
					this.SendPropertyChanging();
					this._Nachname = value;
					this.SendPropertyChanged("Nachname");
					this.OnNachnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Adresse", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Adresse
		{
			get
			{
				return this._Adresse;
			}
			set
			{
				if ((this._Adresse != value))
				{
					this.OnAdresseChanging(value);
					this.SendPropertyChanging();
					this._Adresse = value;
					this.SendPropertyChanged("Adresse");
					this.OnAdresseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PLZ", DbType="VarChar(6) NOT NULL", CanBeNull=false)]
		public string PLZ
		{
			get
			{
				return this._PLZ;
			}
			set
			{
				if ((this._PLZ != value))
				{
					this.OnPLZChanging(value);
					this.SendPropertyChanging();
					this._PLZ = value;
					this.SendPropertyChanged("PLZ");
					this.OnPLZChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ort", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Ort
		{
			get
			{
				return this._Ort;
			}
			set
			{
				if ((this._Ort != value))
				{
					this.OnOrtChanging(value);
					this.SendPropertyChanging();
					this._Ort = value;
					this.SendPropertyChanged("Ort");
					this.OnOrtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Land", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Land
		{
			get
			{
				return this._Land;
			}
			set
			{
				if ((this._Land != value))
				{
					this.OnLandChanging(value);
					this.SendPropertyChanging();
					this._Land = value;
					this.SendPropertyChanged("Land");
					this.OnLandChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMail", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string EMail
		{
			get
			{
				return this._EMail;
			}
			set
			{
				if ((this._EMail != value))
				{
					this.OnEMailChanging(value);
					this.SendPropertyChanging();
					this._EMail = value;
					this.SendPropertyChanged("EMail");
					this.OnEMailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Telefonnummer", DbType="VarChar(45)")]
		public string Telefonnummer
		{
			get
			{
				return this._Telefonnummer;
			}
			set
			{
				if ((this._Telefonnummer != value))
				{
					this.OnTelefonnummerChanging(value);
					this.SendPropertyChanging();
					this._Telefonnummer = value;
					this.SendPropertyChanged("Telefonnummer");
					this.OnTelefonnummerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Benutzername", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Benutzername
		{
			get
			{
				return this._Benutzername;
			}
			set
			{
				if ((this._Benutzername != value))
				{
					this.OnBenutzernameChanging(value);
					this.SendPropertyChanging();
					this._Benutzername = value;
					this.SendPropertyChanged("Benutzername");
					this.OnBenutzernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Passwort", DbType="VarChar(45) NOT NULL", CanBeNull=false)]
		public string Passwort
		{
			get
			{
				return this._Passwort;
			}
			set
			{
				if ((this._Passwort != value))
				{
					this.OnPasswortChanging(value);
					this.SendPropertyChanging();
					this._Passwort = value;
					this.SendPropertyChanged("Passwort");
					this.OnPasswortChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usergruppe_ID", DbType="Int NOT NULL")]
		public int Usergruppe_ID
		{
			get
			{
				return this._Usergruppe_ID;
			}
			set
			{
				if ((this._Usergruppe_ID != value))
				{
					if (this._Usergruppe.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUsergruppe_IDChanging(value);
					this.SendPropertyChanging();
					this._Usergruppe_ID = value;
					this.SendPropertyChanged("Usergruppe_ID");
					this.OnUsergruppe_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Bestellung", Storage="_Bestellung", ThisKey="User_ID", OtherKey="User_ID")]
		public EntitySet<Bestellung> Bestellung
		{
			get
			{
				return this._Bestellung;
			}
			set
			{
				this._Bestellung.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usergruppe_User", Storage="_Usergruppe", ThisKey="Usergruppe_ID", OtherKey="Usergruppe_ID", IsForeignKey=true)]
		public Usergruppe Usergruppe
		{
			get
			{
				return this._Usergruppe.Entity;
			}
			set
			{
				Usergruppe previousValue = this._Usergruppe.Entity;
				if (((previousValue != value) 
							|| (this._Usergruppe.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usergruppe.Entity = null;
						previousValue.User.Remove(this);
					}
					this._Usergruppe.Entity = value;
					if ((value != null))
					{
						value.User.Add(this);
						this._Usergruppe_ID = value.Usergruppe_ID;
					}
					else
					{
						this._Usergruppe_ID = default(int);
					}
					this.SendPropertyChanged("Usergruppe");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Bestellung(Bestellung entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Bestellung(Bestellung entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
}
#pragma warning restore 1591

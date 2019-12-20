﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLSBD
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="quanlysanbong")]
	public partial class QLSBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertadmin(admin instance);
    partial void Updateadmin(admin instance);
    partial void Deleteadmin(admin instance);
    partial void Insertbooking(booking instance);
    partial void Updatebooking(booking instance);
    partial void Deletebooking(booking instance);
    partial void Insertcategory(category instance);
    partial void Updatecategory(category instance);
    partial void Deletecategory(category instance);
    partial void Insertpitch(pitch instance);
    partial void Updatepitch(pitch instance);
    partial void Deletepitch(pitch instance);
    #endregion
		
		public QLSBDataContext() : 
				base(global::QLSBD.Properties.Settings.Default.quanlysanbongConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public QLSBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLSBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLSBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLSBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<admin> admins
		{
			get
			{
				return this.GetTable<admin>();
			}
		}
		
		public System.Data.Linq.Table<booking> bookings
		{
			get
			{
				return this.GetTable<booking>();
			}
		}
		
		public System.Data.Linq.Table<category> categories
		{
			get
			{
				return this.GetTable<category>();
			}
		}
		
		public System.Data.Linq.Table<pitch> pitches
		{
			get
			{
				return this.GetTable<pitch>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.admin")]
	public partial class admin : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _username;
		
		private string _password;
		
		private EntitySet<booking> _bookings;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    #endregion
		
		public admin()
		{
			this._bookings = new EntitySet<booking>(new Action<booking>(this.attach_bookings), new Action<booking>(this.detach_bookings));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="admin_booking", Storage="_bookings", ThisKey="id", OtherKey="id_user")]
		public EntitySet<booking> bookings
		{
			get
			{
				return this._bookings;
			}
			set
			{
				this._bookings.Assign(value);
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
		
		private void attach_bookings(booking entity)
		{
			this.SendPropertyChanging();
			entity.admin = this;
		}
		
		private void detach_bookings(booking entity)
		{
			this.SendPropertyChanging();
			entity.admin = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.bookings")]
	public partial class booking : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _id_user;
		
		private int _id_pitch;
		
		private string _start_time;
		
		private string _end_time;
		
		private int _time;
		
		private string _message;
		
		private double _price;
		
		private EntityRef<admin> _admin;
		
		private EntityRef<pitch> _pitch;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onid_userChanging(int value);
    partial void Onid_userChanged();
    partial void Onid_pitchChanging(int value);
    partial void Onid_pitchChanged();
    partial void Onstart_timeChanging(string value);
    partial void Onstart_timeChanged();
    partial void Onend_timeChanging(string value);
    partial void Onend_timeChanged();
    partial void OntimeChanging(int value);
    partial void OntimeChanged();
    partial void OnmessageChanging(string value);
    partial void OnmessageChanged();
    partial void OnpriceChanging(double value);
    partial void OnpriceChanged();
    #endregion
		
		public booking()
		{
			this._admin = default(EntityRef<admin>);
			this._pitch = default(EntityRef<pitch>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_user", DbType="Int NOT NULL")]
		public int id_user
		{
			get
			{
				return this._id_user;
			}
			set
			{
				if ((this._id_user != value))
				{
					if (this._admin.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_userChanging(value);
					this.SendPropertyChanging();
					this._id_user = value;
					this.SendPropertyChanged("id_user");
					this.Onid_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_pitch", DbType="Int NOT NULL")]
		public int id_pitch
		{
			get
			{
				return this._id_pitch;
			}
			set
			{
				if ((this._id_pitch != value))
				{
					if (this._pitch.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_pitchChanging(value);
					this.SendPropertyChanging();
					this._id_pitch = value;
					this.SendPropertyChanged("id_pitch");
					this.Onid_pitchChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_start_time", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string start_time
		{
			get
			{
				return this._start_time;
			}
			set
			{
				if ((this._start_time != value))
				{
					this.Onstart_timeChanging(value);
					this.SendPropertyChanging();
					this._start_time = value;
					this.SendPropertyChanged("start_time");
					this.Onstart_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_end_time", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string end_time
		{
			get
			{
				return this._end_time;
			}
			set
			{
				if ((this._end_time != value))
				{
					this.Onend_timeChanging(value);
					this.SendPropertyChanging();
					this._end_time = value;
					this.SendPropertyChanged("end_time");
					this.Onend_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time", DbType="Int NOT NULL")]
		public int time
		{
			get
			{
				return this._time;
			}
			set
			{
				if ((this._time != value))
				{
					this.OntimeChanging(value);
					this.SendPropertyChanging();
					this._time = value;
					this.SendPropertyChanged("time");
					this.OntimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_message", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string message
		{
			get
			{
				return this._message;
			}
			set
			{
				if ((this._message != value))
				{
					this.OnmessageChanging(value);
					this.SendPropertyChanging();
					this._message = value;
					this.SendPropertyChanged("message");
					this.OnmessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Float NOT NULL")]
		public double price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="admin_booking", Storage="_admin", ThisKey="id_user", OtherKey="id", IsForeignKey=true)]
		public admin admin
		{
			get
			{
				return this._admin.Entity;
			}
			set
			{
				admin previousValue = this._admin.Entity;
				if (((previousValue != value) 
							|| (this._admin.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._admin.Entity = null;
						previousValue.bookings.Remove(this);
					}
					this._admin.Entity = value;
					if ((value != null))
					{
						value.bookings.Add(this);
						this._id_user = value.id;
					}
					else
					{
						this._id_user = default(int);
					}
					this.SendPropertyChanged("admin");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="pitch_booking", Storage="_pitch", ThisKey="id_pitch", OtherKey="id", IsForeignKey=true)]
		public pitch pitch
		{
			get
			{
				return this._pitch.Entity;
			}
			set
			{
				pitch previousValue = this._pitch.Entity;
				if (((previousValue != value) 
							|| (this._pitch.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._pitch.Entity = null;
						previousValue.bookings.Remove(this);
					}
					this._pitch.Entity = value;
					if ((value != null))
					{
						value.bookings.Add(this);
						this._id_pitch = value.id;
					}
					else
					{
						this._id_pitch = default(int);
					}
					this.SendPropertyChanged("pitch");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.category")]
	public partial class category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _category1;
		
		private EntitySet<pitch> _pitches;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Oncategory1Changing(string value);
    partial void Oncategory1Changed();
    #endregion
		
		public category()
		{
			this._pitches = new EntitySet<pitch>(new Action<pitch>(this.attach_pitches), new Action<pitch>(this.detach_pitches));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="category", Storage="_category1", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string category1
		{
			get
			{
				return this._category1;
			}
			set
			{
				if ((this._category1 != value))
				{
					this.Oncategory1Changing(value);
					this.SendPropertyChanging();
					this._category1 = value;
					this.SendPropertyChanged("category1");
					this.Oncategory1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="category_pitch", Storage="_pitches", ThisKey="id", OtherKey="id_category")]
		public EntitySet<pitch> pitches
		{
			get
			{
				return this._pitches;
			}
			set
			{
				this._pitches.Assign(value);
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
		
		private void attach_pitches(pitch entity)
		{
			this.SendPropertyChanging();
			entity.category = this;
		}
		
		private void detach_pitches(pitch entity)
		{
			this.SendPropertyChanging();
			entity.category = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.pitch")]
	public partial class pitch : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _introduction;
		
		private string _address;
		
		private int _status;
		
		private int _id_category;
		
		private EntitySet<booking> _bookings;
		
		private EntityRef<category> _category;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnintroductionChanging(string value);
    partial void OnintroductionChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    partial void OnstatusChanging(int value);
    partial void OnstatusChanged();
    partial void Onid_categoryChanging(int value);
    partial void Onid_categoryChanged();
    #endregion
		
		public pitch()
		{
			this._bookings = new EntitySet<booking>(new Action<booking>(this.attach_bookings), new Action<booking>(this.detach_bookings));
			this._category = default(EntityRef<category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_introduction", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string introduction
		{
			get
			{
				return this._introduction;
			}
			set
			{
				if ((this._introduction != value))
				{
					this.OnintroductionChanging(value);
					this.SendPropertyChanging();
					this._introduction = value;
					this.SendPropertyChanged("introduction");
					this.OnintroductionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Int NOT NULL")]
		public int status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_category", DbType="Int NOT NULL")]
		public int id_category
		{
			get
			{
				return this._id_category;
			}
			set
			{
				if ((this._id_category != value))
				{
					if (this._category.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_categoryChanging(value);
					this.SendPropertyChanging();
					this._id_category = value;
					this.SendPropertyChanged("id_category");
					this.Onid_categoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="pitch_booking", Storage="_bookings", ThisKey="id", OtherKey="id_pitch")]
		public EntitySet<booking> bookings
		{
			get
			{
				return this._bookings;
			}
			set
			{
				this._bookings.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="category_pitch", Storage="_category", ThisKey="id_category", OtherKey="id", IsForeignKey=true)]
		public category category
		{
			get
			{
				return this._category.Entity;
			}
			set
			{
				category previousValue = this._category.Entity;
				if (((previousValue != value) 
							|| (this._category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._category.Entity = null;
						previousValue.pitches.Remove(this);
					}
					this._category.Entity = value;
					if ((value != null))
					{
						value.pitches.Add(this);
						this._id_category = value.id;
					}
					else
					{
						this._id_category = default(int);
					}
					this.SendPropertyChanged("category");
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
		
		private void attach_bookings(booking entity)
		{
			this.SendPropertyChanging();
			entity.pitch = this;
		}
		
		private void detach_bookings(booking entity)
		{
			this.SendPropertyChanging();
			entity.pitch = null;
		}
	}
}
#pragma warning restore 1591

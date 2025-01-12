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

namespace DAL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QL_Bida")]
	public partial class QL_BidaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBAN(BAN instance);
    partial void UpdateBAN(BAN instance);
    partial void DeleteBAN(BAN instance);
    partial void InsertBIENLAI(BIENLAI instance);
    partial void UpdateBIENLAI(BIENLAI instance);
    partial void DeleteBIENLAI(BIENLAI instance);
    partial void InsertCHITIETDV(CHITIETDV instance);
    partial void UpdateCHITIETDV(CHITIETDV instance);
    partial void DeleteCHITIETDV(CHITIETDV instance);
    partial void InsertDICHVU(DICHVU instance);
    partial void UpdateDICHVU(DICHVU instance);
    partial void DeleteDICHVU(DICHVU instance);
    partial void InsertKHACHHANG(KHACHHANG instance);
    partial void UpdateKHACHHANG(KHACHHANG instance);
    partial void DeleteKHACHHANG(KHACHHANG instance);
    partial void InsertNHANVIEN(NHANVIEN instance);
    partial void UpdateNHANVIEN(NHANVIEN instance);
    partial void DeleteNHANVIEN(NHANVIEN instance);
    partial void InsertDATBAN(DATBAN instance);
    partial void UpdateDATBAN(DATBAN instance);
    partial void DeleteDATBAN(DATBAN instance);
    #endregion
		
		public QL_BidaDataContext() : 
				base(global::DAL.Properties.Settings.Default.QL_BidaConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public QL_BidaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QL_BidaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QL_BidaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QL_BidaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BAN> BANs
		{
			get
			{
				return this.GetTable<BAN>();
			}
		}
		
		public System.Data.Linq.Table<BIENLAI> BIENLAIs
		{
			get
			{
				return this.GetTable<BIENLAI>();
			}
		}
		
		public System.Data.Linq.Table<CHITIETDV> CHITIETDVs
		{
			get
			{
				return this.GetTable<CHITIETDV>();
			}
		}
		
		public System.Data.Linq.Table<DICHVU> DICHVUs
		{
			get
			{
				return this.GetTable<DICHVU>();
			}
		}
		
		public System.Data.Linq.Table<KHACHHANG> KHACHHANGs
		{
			get
			{
				return this.GetTable<KHACHHANG>();
			}
		}
		
		public System.Data.Linq.Table<NHANVIEN> NHANVIENs
		{
			get
			{
				return this.GetTable<NHANVIEN>();
			}
		}
		
		public System.Data.Linq.Table<DATBAN> DATBANs
		{
			get
			{
				return this.GetTable<DATBAN>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BAN")]
	public partial class BAN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MABAN;
		
		private string _TENBAN;
		
		private System.Nullable<bool> _LOAIBAN;
		
		private System.Nullable<int> _KHUVUC;
		
		private System.Nullable<bool> _TINHTRANG;
		
		private System.Nullable<double> _GIATHUE;
		
		private EntitySet<BIENLAI> _BIENLAIs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMABANChanging(int value);
    partial void OnMABANChanged();
    partial void OnTENBANChanging(string value);
    partial void OnTENBANChanged();
    partial void OnLOAIBANChanging(System.Nullable<bool> value);
    partial void OnLOAIBANChanged();
    partial void OnKHUVUCChanging(System.Nullable<int> value);
    partial void OnKHUVUCChanged();
    partial void OnTINHTRANGChanging(System.Nullable<bool> value);
    partial void OnTINHTRANGChanged();
    partial void OnGIATHUEChanging(System.Nullable<double> value);
    partial void OnGIATHUEChanged();
    #endregion
		
		public BAN()
		{
			this._BIENLAIs = new EntitySet<BIENLAI>(new Action<BIENLAI>(this.attach_BIENLAIs), new Action<BIENLAI>(this.detach_BIENLAIs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MABAN", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MABAN
		{
			get
			{
				return this._MABAN;
			}
			set
			{
				if ((this._MABAN != value))
				{
					this.OnMABANChanging(value);
					this.SendPropertyChanging();
					this._MABAN = value;
					this.SendPropertyChanged("MABAN");
					this.OnMABANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENBAN", DbType="NVarChar(30)")]
		public string TENBAN
		{
			get
			{
				return this._TENBAN;
			}
			set
			{
				if ((this._TENBAN != value))
				{
					this.OnTENBANChanging(value);
					this.SendPropertyChanging();
					this._TENBAN = value;
					this.SendPropertyChanged("TENBAN");
					this.OnTENBANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LOAIBAN", DbType="Bit")]
		public System.Nullable<bool> LOAIBAN
		{
			get
			{
				return this._LOAIBAN;
			}
			set
			{
				if ((this._LOAIBAN != value))
				{
					this.OnLOAIBANChanging(value);
					this.SendPropertyChanging();
					this._LOAIBAN = value;
					this.SendPropertyChanged("LOAIBAN");
					this.OnLOAIBANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KHUVUC", DbType="Int")]
		public System.Nullable<int> KHUVUC
		{
			get
			{
				return this._KHUVUC;
			}
			set
			{
				if ((this._KHUVUC != value))
				{
					this.OnKHUVUCChanging(value);
					this.SendPropertyChanging();
					this._KHUVUC = value;
					this.SendPropertyChanged("KHUVUC");
					this.OnKHUVUCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TINHTRANG", DbType="Bit")]
		public System.Nullable<bool> TINHTRANG
		{
			get
			{
				return this._TINHTRANG;
			}
			set
			{
				if ((this._TINHTRANG != value))
				{
					this.OnTINHTRANGChanging(value);
					this.SendPropertyChanging();
					this._TINHTRANG = value;
					this.SendPropertyChanged("TINHTRANG");
					this.OnTINHTRANGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIATHUE", DbType="Float")]
		public System.Nullable<double> GIATHUE
		{
			get
			{
				return this._GIATHUE;
			}
			set
			{
				if ((this._GIATHUE != value))
				{
					this.OnGIATHUEChanging(value);
					this.SendPropertyChanging();
					this._GIATHUE = value;
					this.SendPropertyChanged("GIATHUE");
					this.OnGIATHUEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BAN_BIENLAI", Storage="_BIENLAIs", ThisKey="MABAN", OtherKey="MABAN")]
		public EntitySet<BIENLAI> BIENLAIs
		{
			get
			{
				return this._BIENLAIs;
			}
			set
			{
				this._BIENLAIs.Assign(value);
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
		
		private void attach_BIENLAIs(BIENLAI entity)
		{
			this.SendPropertyChanging();
			entity.BAN = this;
		}
		
		private void detach_BIENLAIs(BIENLAI entity)
		{
			this.SendPropertyChanging();
			entity.BAN = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BIENLAI")]
	public partial class BIENLAI : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MABIENLAI;
		
		private string _MANHANVIEN;
		
		private int _MABAN;
		
		private System.Nullable<int> _MAKH;
		
		private System.Nullable<System.DateTime> _NGAYLAP;
		
		private System.Nullable<System.DateTime> _GIOBD;
		
		private System.Nullable<System.DateTime> _GIOKT;
		
		private System.Nullable<double> _TONGTIEN;
		
		private EntitySet<CHITIETDV> _CHITIETDVs;
		
		private EntityRef<BAN> _BAN;
		
		private EntityRef<KHACHHANG> _KHACHHANG;
		
		private EntityRef<NHANVIEN> _NHANVIEN;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMABIENLAIChanging(int value);
    partial void OnMABIENLAIChanged();
    partial void OnMANHANVIENChanging(string value);
    partial void OnMANHANVIENChanged();
    partial void OnMABANChanging(int value);
    partial void OnMABANChanged();
    partial void OnMAKHChanging(System.Nullable<int> value);
    partial void OnMAKHChanged();
    partial void OnNGAYLAPChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYLAPChanged();
    partial void OnGIOBDChanging(System.Nullable<System.DateTime> value);
    partial void OnGIOBDChanged();
    partial void OnGIOKTChanging(System.Nullable<System.DateTime> value);
    partial void OnGIOKTChanged();
    partial void OnTONGTIENChanging(System.Nullable<double> value);
    partial void OnTONGTIENChanged();
    #endregion
		
		public BIENLAI()
		{
			this._CHITIETDVs = new EntitySet<CHITIETDV>(new Action<CHITIETDV>(this.attach_CHITIETDVs), new Action<CHITIETDV>(this.detach_CHITIETDVs));
			this._BAN = default(EntityRef<BAN>);
			this._KHACHHANG = default(EntityRef<KHACHHANG>);
			this._NHANVIEN = default(EntityRef<NHANVIEN>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MABIENLAI", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MABIENLAI
		{
			get
			{
				return this._MABIENLAI;
			}
			set
			{
				if ((this._MABIENLAI != value))
				{
					this.OnMABIENLAIChanging(value);
					this.SendPropertyChanging();
					this._MABIENLAI = value;
					this.SendPropertyChanged("MABIENLAI");
					this.OnMABIENLAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MANHANVIEN", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string MANHANVIEN
		{
			get
			{
				return this._MANHANVIEN;
			}
			set
			{
				if ((this._MANHANVIEN != value))
				{
					if (this._NHANVIEN.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMANHANVIENChanging(value);
					this.SendPropertyChanging();
					this._MANHANVIEN = value;
					this.SendPropertyChanged("MANHANVIEN");
					this.OnMANHANVIENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MABAN", DbType="Int NOT NULL")]
		public int MABAN
		{
			get
			{
				return this._MABAN;
			}
			set
			{
				if ((this._MABAN != value))
				{
					if (this._BAN.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMABANChanging(value);
					this.SendPropertyChanging();
					this._MABAN = value;
					this.SendPropertyChanged("MABAN");
					this.OnMABANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAKH", DbType="Int")]
		public System.Nullable<int> MAKH
		{
			get
			{
				return this._MAKH;
			}
			set
			{
				if ((this._MAKH != value))
				{
					if (this._KHACHHANG.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMAKHChanging(value);
					this.SendPropertyChanging();
					this._MAKH = value;
					this.SendPropertyChanged("MAKH");
					this.OnMAKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYLAP", DbType="DateTime")]
		public System.Nullable<System.DateTime> NGAYLAP
		{
			get
			{
				return this._NGAYLAP;
			}
			set
			{
				if ((this._NGAYLAP != value))
				{
					this.OnNGAYLAPChanging(value);
					this.SendPropertyChanging();
					this._NGAYLAP = value;
					this.SendPropertyChanged("NGAYLAP");
					this.OnNGAYLAPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIOBD", DbType="DateTime")]
		public System.Nullable<System.DateTime> GIOBD
		{
			get
			{
				return this._GIOBD;
			}
			set
			{
				if ((this._GIOBD != value))
				{
					this.OnGIOBDChanging(value);
					this.SendPropertyChanging();
					this._GIOBD = value;
					this.SendPropertyChanged("GIOBD");
					this.OnGIOBDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIOKT", DbType="DateTime")]
		public System.Nullable<System.DateTime> GIOKT
		{
			get
			{
				return this._GIOKT;
			}
			set
			{
				if ((this._GIOKT != value))
				{
					this.OnGIOKTChanging(value);
					this.SendPropertyChanging();
					this._GIOKT = value;
					this.SendPropertyChanged("GIOKT");
					this.OnGIOKTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TONGTIEN", DbType="Float")]
		public System.Nullable<double> TONGTIEN
		{
			get
			{
				return this._TONGTIEN;
			}
			set
			{
				if ((this._TONGTIEN != value))
				{
					this.OnTONGTIENChanging(value);
					this.SendPropertyChanging();
					this._TONGTIEN = value;
					this.SendPropertyChanged("TONGTIEN");
					this.OnTONGTIENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BIENLAI_CHITIETDV", Storage="_CHITIETDVs", ThisKey="MABIENLAI", OtherKey="MABIENLAI")]
		public EntitySet<CHITIETDV> CHITIETDVs
		{
			get
			{
				return this._CHITIETDVs;
			}
			set
			{
				this._CHITIETDVs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BAN_BIENLAI", Storage="_BAN", ThisKey="MABAN", OtherKey="MABAN", IsForeignKey=true)]
		public BAN BAN
		{
			get
			{
				return this._BAN.Entity;
			}
			set
			{
				BAN previousValue = this._BAN.Entity;
				if (((previousValue != value) 
							|| (this._BAN.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BAN.Entity = null;
						previousValue.BIENLAIs.Remove(this);
					}
					this._BAN.Entity = value;
					if ((value != null))
					{
						value.BIENLAIs.Add(this);
						this._MABAN = value.MABAN;
					}
					else
					{
						this._MABAN = default(int);
					}
					this.SendPropertyChanged("BAN");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KHACHHANG_BIENLAI", Storage="_KHACHHANG", ThisKey="MAKH", OtherKey="MAKH", IsForeignKey=true)]
		public KHACHHANG KHACHHANG
		{
			get
			{
				return this._KHACHHANG.Entity;
			}
			set
			{
				KHACHHANG previousValue = this._KHACHHANG.Entity;
				if (((previousValue != value) 
							|| (this._KHACHHANG.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._KHACHHANG.Entity = null;
						previousValue.BIENLAIs.Remove(this);
					}
					this._KHACHHANG.Entity = value;
					if ((value != null))
					{
						value.BIENLAIs.Add(this);
						this._MAKH = value.MAKH;
					}
					else
					{
						this._MAKH = default(Nullable<int>);
					}
					this.SendPropertyChanged("KHACHHANG");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NHANVIEN_BIENLAI", Storage="_NHANVIEN", ThisKey="MANHANVIEN", OtherKey="MANHANVIEN", IsForeignKey=true)]
		public NHANVIEN NHANVIEN
		{
			get
			{
				return this._NHANVIEN.Entity;
			}
			set
			{
				NHANVIEN previousValue = this._NHANVIEN.Entity;
				if (((previousValue != value) 
							|| (this._NHANVIEN.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._NHANVIEN.Entity = null;
						previousValue.BIENLAIs.Remove(this);
					}
					this._NHANVIEN.Entity = value;
					if ((value != null))
					{
						value.BIENLAIs.Add(this);
						this._MANHANVIEN = value.MANHANVIEN;
					}
					else
					{
						this._MANHANVIEN = default(string);
					}
					this.SendPropertyChanged("NHANVIEN");
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
		
		private void attach_CHITIETDVs(CHITIETDV entity)
		{
			this.SendPropertyChanging();
			entity.BIENLAI = this;
		}
		
		private void detach_CHITIETDVs(CHITIETDV entity)
		{
			this.SendPropertyChanging();
			entity.BIENLAI = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CHITIETDV")]
	public partial class CHITIETDV : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MABIENLAI;
		
		private int _MADV;
		
		private System.Nullable<int> _SOLUONG;
		
		private EntityRef<BIENLAI> _BIENLAI;
		
		private EntityRef<DICHVU> _DICHVU;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMABIENLAIChanging(int value);
    partial void OnMABIENLAIChanged();
    partial void OnMADVChanging(int value);
    partial void OnMADVChanged();
    partial void OnSOLUONGChanging(System.Nullable<int> value);
    partial void OnSOLUONGChanged();
    #endregion
		
		public CHITIETDV()
		{
			this._BIENLAI = default(EntityRef<BIENLAI>);
			this._DICHVU = default(EntityRef<DICHVU>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MABIENLAI", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MABIENLAI
		{
			get
			{
				return this._MABIENLAI;
			}
			set
			{
				if ((this._MABIENLAI != value))
				{
					if (this._BIENLAI.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMABIENLAIChanging(value);
					this.SendPropertyChanging();
					this._MABIENLAI = value;
					this.SendPropertyChanged("MABIENLAI");
					this.OnMABIENLAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MADV", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MADV
		{
			get
			{
				return this._MADV;
			}
			set
			{
				if ((this._MADV != value))
				{
					if (this._DICHVU.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMADVChanging(value);
					this.SendPropertyChanging();
					this._MADV = value;
					this.SendPropertyChanged("MADV");
					this.OnMADVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SOLUONG", DbType="Int")]
		public System.Nullable<int> SOLUONG
		{
			get
			{
				return this._SOLUONG;
			}
			set
			{
				if ((this._SOLUONG != value))
				{
					this.OnSOLUONGChanging(value);
					this.SendPropertyChanging();
					this._SOLUONG = value;
					this.SendPropertyChanged("SOLUONG");
					this.OnSOLUONGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BIENLAI_CHITIETDV", Storage="_BIENLAI", ThisKey="MABIENLAI", OtherKey="MABIENLAI", IsForeignKey=true)]
		public BIENLAI BIENLAI
		{
			get
			{
				return this._BIENLAI.Entity;
			}
			set
			{
				BIENLAI previousValue = this._BIENLAI.Entity;
				if (((previousValue != value) 
							|| (this._BIENLAI.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BIENLAI.Entity = null;
						previousValue.CHITIETDVs.Remove(this);
					}
					this._BIENLAI.Entity = value;
					if ((value != null))
					{
						value.CHITIETDVs.Add(this);
						this._MABIENLAI = value.MABIENLAI;
					}
					else
					{
						this._MABIENLAI = default(int);
					}
					this.SendPropertyChanged("BIENLAI");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DICHVU_CHITIETDV", Storage="_DICHVU", ThisKey="MADV", OtherKey="MADV", IsForeignKey=true)]
		public DICHVU DICHVU
		{
			get
			{
				return this._DICHVU.Entity;
			}
			set
			{
				DICHVU previousValue = this._DICHVU.Entity;
				if (((previousValue != value) 
							|| (this._DICHVU.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DICHVU.Entity = null;
						previousValue.CHITIETDVs.Remove(this);
					}
					this._DICHVU.Entity = value;
					if ((value != null))
					{
						value.CHITIETDVs.Add(this);
						this._MADV = value.MADV;
					}
					else
					{
						this._MADV = default(int);
					}
					this.SendPropertyChanged("DICHVU");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DICHVU")]
	public partial class DICHVU : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MADV;
		
		private string _TENDV;
		
		private System.Nullable<double> _DONGIA;
		
		private string _DONVITINH;
		
		private EntitySet<CHITIETDV> _CHITIETDVs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMADVChanging(int value);
    partial void OnMADVChanged();
    partial void OnTENDVChanging(string value);
    partial void OnTENDVChanged();
    partial void OnDONGIAChanging(System.Nullable<double> value);
    partial void OnDONGIAChanged();
    partial void OnDONVITINHChanging(string value);
    partial void OnDONVITINHChanged();
    #endregion
		
		public DICHVU()
		{
			this._CHITIETDVs = new EntitySet<CHITIETDV>(new Action<CHITIETDV>(this.attach_CHITIETDVs), new Action<CHITIETDV>(this.detach_CHITIETDVs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MADV", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MADV
		{
			get
			{
				return this._MADV;
			}
			set
			{
				if ((this._MADV != value))
				{
					this.OnMADVChanging(value);
					this.SendPropertyChanging();
					this._MADV = value;
					this.SendPropertyChanged("MADV");
					this.OnMADVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENDV", DbType="NVarChar(50)")]
		public string TENDV
		{
			get
			{
				return this._TENDV;
			}
			set
			{
				if ((this._TENDV != value))
				{
					this.OnTENDVChanging(value);
					this.SendPropertyChanging();
					this._TENDV = value;
					this.SendPropertyChanged("TENDV");
					this.OnTENDVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DONGIA", DbType="Float")]
		public System.Nullable<double> DONGIA
		{
			get
			{
				return this._DONGIA;
			}
			set
			{
				if ((this._DONGIA != value))
				{
					this.OnDONGIAChanging(value);
					this.SendPropertyChanging();
					this._DONGIA = value;
					this.SendPropertyChanged("DONGIA");
					this.OnDONGIAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DONVITINH", DbType="NVarChar(20)")]
		public string DONVITINH
		{
			get
			{
				return this._DONVITINH;
			}
			set
			{
				if ((this._DONVITINH != value))
				{
					this.OnDONVITINHChanging(value);
					this.SendPropertyChanging();
					this._DONVITINH = value;
					this.SendPropertyChanged("DONVITINH");
					this.OnDONVITINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DICHVU_CHITIETDV", Storage="_CHITIETDVs", ThisKey="MADV", OtherKey="MADV")]
		public EntitySet<CHITIETDV> CHITIETDVs
		{
			get
			{
				return this._CHITIETDVs;
			}
			set
			{
				this._CHITIETDVs.Assign(value);
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
		
		private void attach_CHITIETDVs(CHITIETDV entity)
		{
			this.SendPropertyChanging();
			entity.DICHVU = this;
		}
		
		private void detach_CHITIETDVs(CHITIETDV entity)
		{
			this.SendPropertyChanging();
			entity.DICHVU = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KHACHHANG")]
	public partial class KHACHHANG : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MAKH;
		
		private string _TENKH;
		
		private string _SDT;
		
		private EntitySet<BIENLAI> _BIENLAIs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMAKHChanging(int value);
    partial void OnMAKHChanged();
    partial void OnTENKHChanging(string value);
    partial void OnTENKHChanged();
    partial void OnSDTChanging(string value);
    partial void OnSDTChanged();
    #endregion
		
		public KHACHHANG()
		{
			this._BIENLAIs = new EntitySet<BIENLAI>(new Action<BIENLAI>(this.attach_BIENLAIs), new Action<BIENLAI>(this.detach_BIENLAIs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAKH", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MAKH
		{
			get
			{
				return this._MAKH;
			}
			set
			{
				if ((this._MAKH != value))
				{
					this.OnMAKHChanging(value);
					this.SendPropertyChanging();
					this._MAKH = value;
					this.SendPropertyChanged("MAKH");
					this.OnMAKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENKH", DbType="NVarChar(100)")]
		public string TENKH
		{
			get
			{
				return this._TENKH;
			}
			set
			{
				if ((this._TENKH != value))
				{
					this.OnTENKHChanging(value);
					this.SendPropertyChanging();
					this._TENKH = value;
					this.SendPropertyChanged("TENKH");
					this.OnTENKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SDT", DbType="NVarChar(50)")]
		public string SDT
		{
			get
			{
				return this._SDT;
			}
			set
			{
				if ((this._SDT != value))
				{
					this.OnSDTChanging(value);
					this.SendPropertyChanging();
					this._SDT = value;
					this.SendPropertyChanged("SDT");
					this.OnSDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="KHACHHANG_BIENLAI", Storage="_BIENLAIs", ThisKey="MAKH", OtherKey="MAKH")]
		public EntitySet<BIENLAI> BIENLAIs
		{
			get
			{
				return this._BIENLAIs;
			}
			set
			{
				this._BIENLAIs.Assign(value);
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
		
		private void attach_BIENLAIs(BIENLAI entity)
		{
			this.SendPropertyChanging();
			entity.KHACHHANG = this;
		}
		
		private void detach_BIENLAIs(BIENLAI entity)
		{
			this.SendPropertyChanging();
			entity.KHACHHANG = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NHANVIEN")]
	public partial class NHANVIEN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MANHANVIEN;
		
		private string _TENNV;
		
		private System.Nullable<bool> _CALAM;
		
		private string _PASSNV;
		
		private string _QUYEN;
		
		private EntitySet<BIENLAI> _BIENLAIs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMANHANVIENChanging(string value);
    partial void OnMANHANVIENChanged();
    partial void OnTENNVChanging(string value);
    partial void OnTENNVChanged();
    partial void OnCALAMChanging(System.Nullable<bool> value);
    partial void OnCALAMChanged();
    partial void OnPASSNVChanging(string value);
    partial void OnPASSNVChanged();
    partial void OnQUYENChanging(string value);
    partial void OnQUYENChanged();
    #endregion
		
		public NHANVIEN()
		{
			this._BIENLAIs = new EntitySet<BIENLAI>(new Action<BIENLAI>(this.attach_BIENLAIs), new Action<BIENLAI>(this.detach_BIENLAIs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MANHANVIEN", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MANHANVIEN
		{
			get
			{
				return this._MANHANVIEN;
			}
			set
			{
				if ((this._MANHANVIEN != value))
				{
					this.OnMANHANVIENChanging(value);
					this.SendPropertyChanging();
					this._MANHANVIEN = value;
					this.SendPropertyChanged("MANHANVIEN");
					this.OnMANHANVIENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENNV", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TENNV
		{
			get
			{
				return this._TENNV;
			}
			set
			{
				if ((this._TENNV != value))
				{
					this.OnTENNVChanging(value);
					this.SendPropertyChanging();
					this._TENNV = value;
					this.SendPropertyChanged("TENNV");
					this.OnTENNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CALAM", DbType="Bit")]
		public System.Nullable<bool> CALAM
		{
			get
			{
				return this._CALAM;
			}
			set
			{
				if ((this._CALAM != value))
				{
					this.OnCALAMChanging(value);
					this.SendPropertyChanging();
					this._CALAM = value;
					this.SendPropertyChanged("CALAM");
					this.OnCALAMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSNV", DbType="VarChar(100)")]
		public string PASSNV
		{
			get
			{
				return this._PASSNV;
			}
			set
			{
				if ((this._PASSNV != value))
				{
					this.OnPASSNVChanging(value);
					this.SendPropertyChanging();
					this._PASSNV = value;
					this.SendPropertyChanged("PASSNV");
					this.OnPASSNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QUYEN", DbType="Char(5)")]
		public string QUYEN
		{
			get
			{
				return this._QUYEN;
			}
			set
			{
				if ((this._QUYEN != value))
				{
					this.OnQUYENChanging(value);
					this.SendPropertyChanging();
					this._QUYEN = value;
					this.SendPropertyChanged("QUYEN");
					this.OnQUYENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NHANVIEN_BIENLAI", Storage="_BIENLAIs", ThisKey="MANHANVIEN", OtherKey="MANHANVIEN")]
		public EntitySet<BIENLAI> BIENLAIs
		{
			get
			{
				return this._BIENLAIs;
			}
			set
			{
				this._BIENLAIs.Assign(value);
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
		
		private void attach_BIENLAIs(BIENLAI entity)
		{
			this.SendPropertyChanging();
			entity.NHANVIEN = this;
		}
		
		private void detach_BIENLAIs(BIENLAI entity)
		{
			this.SendPropertyChanging();
			entity.NHANVIEN = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DATBAN")]
	public partial class DATBAN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MADATBAN;
		
		private string _TENKH;
		
		private string _SDT;
		
		private System.Nullable<bool> _LOAIBAN;
		
		private string _GHICHU;
		
		private System.Nullable<bool> _TRANGTHAI;
		
		private System.DateTime _THOIGIANDEN;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMADATBANChanging(int value);
    partial void OnMADATBANChanged();
    partial void OnTENKHChanging(string value);
    partial void OnTENKHChanged();
    partial void OnSDTChanging(string value);
    partial void OnSDTChanged();
    partial void OnLOAIBANChanging(System.Nullable<bool> value);
    partial void OnLOAIBANChanged();
    partial void OnGHICHUChanging(string value);
    partial void OnGHICHUChanged();
    partial void OnTRANGTHAIChanging(System.Nullable<bool> value);
    partial void OnTRANGTHAIChanged();
    partial void OnTHOIGIANDENChanging(System.DateTime value);
    partial void OnTHOIGIANDENChanged();
    #endregion
		
		public DATBAN()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MADATBAN", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MADATBAN
		{
			get
			{
				return this._MADATBAN;
			}
			set
			{
				if ((this._MADATBAN != value))
				{
					this.OnMADATBANChanging(value);
					this.SendPropertyChanging();
					this._MADATBAN = value;
					this.SendPropertyChanged("MADATBAN");
					this.OnMADATBANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENKH", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string TENKH
		{
			get
			{
				return this._TENKH;
			}
			set
			{
				if ((this._TENKH != value))
				{
					this.OnTENKHChanging(value);
					this.SendPropertyChanging();
					this._TENKH = value;
					this.SendPropertyChanged("TENKH");
					this.OnTENKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SDT", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string SDT
		{
			get
			{
				return this._SDT;
			}
			set
			{
				if ((this._SDT != value))
				{
					this.OnSDTChanging(value);
					this.SendPropertyChanging();
					this._SDT = value;
					this.SendPropertyChanged("SDT");
					this.OnSDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LOAIBAN", DbType="Bit")]
		public System.Nullable<bool> LOAIBAN
		{
			get
			{
				return this._LOAIBAN;
			}
			set
			{
				if ((this._LOAIBAN != value))
				{
					this.OnLOAIBANChanging(value);
					this.SendPropertyChanging();
					this._LOAIBAN = value;
					this.SendPropertyChanged("LOAIBAN");
					this.OnLOAIBANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GHICHU", DbType="NVarChar(500)")]
		public string GHICHU
		{
			get
			{
				return this._GHICHU;
			}
			set
			{
				if ((this._GHICHU != value))
				{
					this.OnGHICHUChanging(value);
					this.SendPropertyChanging();
					this._GHICHU = value;
					this.SendPropertyChanged("GHICHU");
					this.OnGHICHUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TRANGTHAI", DbType="Bit")]
		public System.Nullable<bool> TRANGTHAI
		{
			get
			{
				return this._TRANGTHAI;
			}
			set
			{
				if ((this._TRANGTHAI != value))
				{
					this.OnTRANGTHAIChanging(value);
					this.SendPropertyChanging();
					this._TRANGTHAI = value;
					this.SendPropertyChanged("TRANGTHAI");
					this.OnTRANGTHAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_THOIGIANDEN", DbType="DateTime NOT NULL")]
		public System.DateTime THOIGIANDEN
		{
			get
			{
				return this._THOIGIANDEN;
			}
			set
			{
				if ((this._THOIGIANDEN != value))
				{
					this.OnTHOIGIANDENChanging(value);
					this.SendPropertyChanging();
					this._THOIGIANDEN = value;
					this.SendPropertyChanged("THOIGIANDEN");
					this.OnTHOIGIANDENChanged();
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
}
#pragma warning restore 1591

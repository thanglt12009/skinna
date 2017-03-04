#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using SkinCare.Entities;
using SkinCare.Data;

#endregion

namespace SkinCare.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="DonHangProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DonHangProviderBaseCore : EntityProviderBase<SkinCare.Entities.DonHang, SkinCare.Entities.DonHangKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.DonHangKey key)
		{
			return Delete(transactionManager, key.MaDonHang);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_maDonHang">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _maDonHang)
		{
			return Delete(null, _maDonHang);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maDonHang">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _maDonHang);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override SkinCare.Entities.DonHang Get(TransactionManager transactionManager, SkinCare.Entities.DonHangKey key, int start, int pageLength)
		{
			return GetByMaDonHang(transactionManager, key.MaDonHang, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDonHang index.
		/// </summary>
		/// <param name="_maDonHang"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHang"/> class.</returns>
		public SkinCare.Entities.DonHang GetByMaDonHang(System.Int32 _maDonHang)
		{
			int count = -1;
			return GetByMaDonHang(null,_maDonHang, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHang index.
		/// </summary>
		/// <param name="_maDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHang"/> class.</returns>
		public SkinCare.Entities.DonHang GetByMaDonHang(System.Int32 _maDonHang, int start, int pageLength)
		{
			int count = -1;
			return GetByMaDonHang(null, _maDonHang, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maDonHang"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHang"/> class.</returns>
		public SkinCare.Entities.DonHang GetByMaDonHang(TransactionManager transactionManager, System.Int32 _maDonHang)
		{
			int count = -1;
			return GetByMaDonHang(transactionManager, _maDonHang, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHang"/> class.</returns>
		public SkinCare.Entities.DonHang GetByMaDonHang(TransactionManager transactionManager, System.Int32 _maDonHang, int start, int pageLength)
		{
			int count = -1;
			return GetByMaDonHang(transactionManager, _maDonHang, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHang index.
		/// </summary>
		/// <param name="_maDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHang"/> class.</returns>
		public SkinCare.Entities.DonHang GetByMaDonHang(System.Int32 _maDonHang, int start, int pageLength, out int count)
		{
			return GetByMaDonHang(null, _maDonHang, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHang"/> class.</returns>
		public abstract SkinCare.Entities.DonHang GetByMaDonHang(TransactionManager transactionManager, System.Int32 _maDonHang, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DonHang&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DonHang&gt;"/></returns>
		public static TList<DonHang> Fill(IDataReader reader, TList<DonHang> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				SkinCare.Entities.DonHang c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DonHang")
					.Append("|").Append((System.Int32)reader[((int)DonHangColumn.MaDonHang - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DonHang>(
					key.ToString(), // EntityTrackingKey
					"DonHang",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.DonHang();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.MaDonHang = (System.Int32)reader[((int)DonHangColumn.MaDonHang - 1)];
					c.MaKhachHang = (reader.IsDBNull(((int)DonHangColumn.MaKhachHang - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaKhachHang - 1)];
					c.MaNguonDonHang = (reader.IsDBNull(((int)DonHangColumn.MaNguonDonHang - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaNguonDonHang - 1)];
					c.MaTrangThaiDonHang = (reader.IsDBNull(((int)DonHangColumn.MaTrangThaiDonHang - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaTrangThaiDonHang - 1)];
					c.NguoiDatHang = (reader.IsDBNull(((int)DonHangColumn.NguoiDatHang - 1)))?null:(System.String)reader[((int)DonHangColumn.NguoiDatHang - 1)];
					c.MaPhuongThucThanhToan = (reader.IsDBNull(((int)DonHangColumn.MaPhuongThucThanhToan - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaPhuongThucThanhToan - 1)];
					c.CachThucNhanHang = (reader.IsDBNull(((int)DonHangColumn.CachThucNhanHang - 1)))?null:(System.String)reader[((int)DonHangColumn.CachThucNhanHang - 1)];
					c.PhiVanChuyen = (reader.IsDBNull(((int)DonHangColumn.PhiVanChuyen - 1)))?null:(System.Decimal?)reader[((int)DonHangColumn.PhiVanChuyen - 1)];
					c.TongTienDonHang = (reader.IsDBNull(((int)DonHangColumn.TongTienDonHang - 1)))?null:(System.Decimal?)reader[((int)DonHangColumn.TongTienDonHang - 1)];
					c.NgayTaoDonHang = (reader.IsDBNull(((int)DonHangColumn.NgayTaoDonHang - 1)))?null:(System.DateTime?)reader[((int)DonHangColumn.NgayTaoDonHang - 1)];
					c.MaKhuyenMai = (reader.IsDBNull(((int)DonHangColumn.MaKhuyenMai - 1)))?null:(System.String)reader[((int)DonHangColumn.MaKhuyenMai - 1)];
					c.MaVoucher = (reader.IsDBNull(((int)DonHangColumn.MaVoucher - 1)))?null:(System.String)reader[((int)DonHangColumn.MaVoucher - 1)];
					c.GhiChu = (reader.IsDBNull(((int)DonHangColumn.GhiChu - 1)))?null:(System.String)reader[((int)DonHangColumn.GhiChu - 1)];
					c.TienChietKhau = (reader.IsDBNull(((int)DonHangColumn.TienChietKhau - 1)))?null:(System.Decimal?)reader[((int)DonHangColumn.TienChietKhau - 1)];
					c.TiLeChietKhau = (reader.IsDBNull(((int)DonHangColumn.TiLeChietKhau - 1)))?null:(System.Double?)reader[((int)DonHangColumn.TiLeChietKhau - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.DonHang"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.DonHang"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.DonHang entity)
		{
			if (!reader.Read()) return;
			
			entity.MaDonHang = (System.Int32)reader[((int)DonHangColumn.MaDonHang - 1)];
			entity.MaKhachHang = (reader.IsDBNull(((int)DonHangColumn.MaKhachHang - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaKhachHang - 1)];
			entity.MaNguonDonHang = (reader.IsDBNull(((int)DonHangColumn.MaNguonDonHang - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaNguonDonHang - 1)];
			entity.MaTrangThaiDonHang = (reader.IsDBNull(((int)DonHangColumn.MaTrangThaiDonHang - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaTrangThaiDonHang - 1)];
			entity.NguoiDatHang = (reader.IsDBNull(((int)DonHangColumn.NguoiDatHang - 1)))?null:(System.String)reader[((int)DonHangColumn.NguoiDatHang - 1)];
			entity.MaPhuongThucThanhToan = (reader.IsDBNull(((int)DonHangColumn.MaPhuongThucThanhToan - 1)))?null:(System.Int32?)reader[((int)DonHangColumn.MaPhuongThucThanhToan - 1)];
			entity.CachThucNhanHang = (reader.IsDBNull(((int)DonHangColumn.CachThucNhanHang - 1)))?null:(System.String)reader[((int)DonHangColumn.CachThucNhanHang - 1)];
			entity.PhiVanChuyen = (reader.IsDBNull(((int)DonHangColumn.PhiVanChuyen - 1)))?null:(System.Decimal?)reader[((int)DonHangColumn.PhiVanChuyen - 1)];
			entity.TongTienDonHang = (reader.IsDBNull(((int)DonHangColumn.TongTienDonHang - 1)))?null:(System.Decimal?)reader[((int)DonHangColumn.TongTienDonHang - 1)];
			entity.NgayTaoDonHang = (reader.IsDBNull(((int)DonHangColumn.NgayTaoDonHang - 1)))?null:(System.DateTime?)reader[((int)DonHangColumn.NgayTaoDonHang - 1)];
			entity.MaKhuyenMai = (reader.IsDBNull(((int)DonHangColumn.MaKhuyenMai - 1)))?null:(System.String)reader[((int)DonHangColumn.MaKhuyenMai - 1)];
			entity.MaVoucher = (reader.IsDBNull(((int)DonHangColumn.MaVoucher - 1)))?null:(System.String)reader[((int)DonHangColumn.MaVoucher - 1)];
			entity.GhiChu = (reader.IsDBNull(((int)DonHangColumn.GhiChu - 1)))?null:(System.String)reader[((int)DonHangColumn.GhiChu - 1)];
			entity.TienChietKhau = (reader.IsDBNull(((int)DonHangColumn.TienChietKhau - 1)))?null:(System.Decimal?)reader[((int)DonHangColumn.TienChietKhau - 1)];
			entity.TiLeChietKhau = (reader.IsDBNull(((int)DonHangColumn.TiLeChietKhau - 1)))?null:(System.Double?)reader[((int)DonHangColumn.TiLeChietKhau - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.DonHang"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.DonHang"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.DonHang entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaDonHang = (System.Int32)dataRow["MaDonHang"];
			entity.MaKhachHang = Convert.IsDBNull(dataRow["MaKhachHang"]) ? null : (System.Int32?)dataRow["MaKhachHang"];
			entity.MaNguonDonHang = Convert.IsDBNull(dataRow["MaNguonDonHang"]) ? null : (System.Int32?)dataRow["MaNguonDonHang"];
			entity.MaTrangThaiDonHang = Convert.IsDBNull(dataRow["MaTrangThaiDonHang"]) ? null : (System.Int32?)dataRow["MaTrangThaiDonHang"];
			entity.NguoiDatHang = Convert.IsDBNull(dataRow["NguoiDatHang"]) ? null : (System.String)dataRow["NguoiDatHang"];
			entity.MaPhuongThucThanhToan = Convert.IsDBNull(dataRow["MaPhuongThucThanhToan"]) ? null : (System.Int32?)dataRow["MaPhuongThucThanhToan"];
			entity.CachThucNhanHang = Convert.IsDBNull(dataRow["CachThucNhanHang"]) ? null : (System.String)dataRow["CachThucNhanHang"];
			entity.PhiVanChuyen = Convert.IsDBNull(dataRow["PhiVanChuyen"]) ? null : (System.Decimal?)dataRow["PhiVanChuyen"];
			entity.TongTienDonHang = Convert.IsDBNull(dataRow["TongTienDonHang"]) ? null : (System.Decimal?)dataRow["TongTienDonHang"];
			entity.NgayTaoDonHang = Convert.IsDBNull(dataRow["NgayTaoDonHang"]) ? null : (System.DateTime?)dataRow["NgayTaoDonHang"];
			entity.MaKhuyenMai = Convert.IsDBNull(dataRow["MaKhuyenMai"]) ? null : (System.String)dataRow["MaKhuyenMai"];
			entity.MaVoucher = Convert.IsDBNull(dataRow["MaVoucher"]) ? null : (System.String)dataRow["MaVoucher"];
			entity.GhiChu = Convert.IsDBNull(dataRow["GhiChu"]) ? null : (System.String)dataRow["GhiChu"];
			entity.TienChietKhau = Convert.IsDBNull(dataRow["TienChietKhau"]) ? null : (System.Decimal?)dataRow["TienChietKhau"];
			entity.TiLeChietKhau = Convert.IsDBNull(dataRow["TiLeChietKhau"]) ? null : (System.Double?)dataRow["TiLeChietKhau"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.DonHang"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.DonHang Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.DonHang entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the SkinCare.Entities.DonHang object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.DonHang instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.DonHang Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.DonHang entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region DonHangChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.DonHang</c>
	///</summary>
	public enum DonHangChildEntityTypes
	{
	}
	
	#endregion DonHangChildEntityTypes
	
	#region DonHangFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangFilterBuilder : SqlFilterBuilder<DonHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangFilterBuilder class.
		/// </summary>
		public DonHangFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangFilterBuilder
	
	#region DonHangParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangParameterBuilder : ParameterizedSqlFilterBuilder<DonHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangParameterBuilder class.
		/// </summary>
		public DonHangParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangParameterBuilder
	
	#region DonHangSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHang"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DonHangSortBuilder : SqlSortBuilder<DonHangColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangSqlSortBuilder class.
		/// </summary>
		public DonHangSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DonHangSortBuilder
	
} // end namespace

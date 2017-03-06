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
	/// This class is the base class for any <see cref="KhoHangSanPhamProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class KhoHangSanPhamProviderBaseCore : EntityProviderBase<SkinCare.Entities.KhoHangSanPham, SkinCare.Entities.KhoHangSanPhamKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.KhoHangSanPhamKey key)
		{
			return Delete(transactionManager, key.MaSanPham);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_maSanPham">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _maSanPham)
		{
			return Delete(null, _maSanPham);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maSanPham">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _maSanPham);		
		
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
		public override SkinCare.Entities.KhoHangSanPham Get(TransactionManager transactionManager, SkinCare.Entities.KhoHangSanPhamKey key, int start, int pageLength)
		{
			return GetByMaSanPham(transactionManager, key.MaSanPham, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblKhoHangSanPham index.
		/// </summary>
		/// <param name="_maSanPham"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhoHangSanPham"/> class.</returns>
		public SkinCare.Entities.KhoHangSanPham GetByMaSanPham(System.Int32 _maSanPham)
		{
			int count = -1;
			return GetByMaSanPham(null,_maSanPham, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhoHangSanPham index.
		/// </summary>
		/// <param name="_maSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhoHangSanPham"/> class.</returns>
		public SkinCare.Entities.KhoHangSanPham GetByMaSanPham(System.Int32 _maSanPham, int start, int pageLength)
		{
			int count = -1;
			return GetByMaSanPham(null, _maSanPham, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhoHangSanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maSanPham"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhoHangSanPham"/> class.</returns>
		public SkinCare.Entities.KhoHangSanPham GetByMaSanPham(TransactionManager transactionManager, System.Int32 _maSanPham)
		{
			int count = -1;
			return GetByMaSanPham(transactionManager, _maSanPham, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhoHangSanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhoHangSanPham"/> class.</returns>
		public SkinCare.Entities.KhoHangSanPham GetByMaSanPham(TransactionManager transactionManager, System.Int32 _maSanPham, int start, int pageLength)
		{
			int count = -1;
			return GetByMaSanPham(transactionManager, _maSanPham, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhoHangSanPham index.
		/// </summary>
		/// <param name="_maSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhoHangSanPham"/> class.</returns>
		public SkinCare.Entities.KhoHangSanPham GetByMaSanPham(System.Int32 _maSanPham, int start, int pageLength, out int count)
		{
			return GetByMaSanPham(null, _maSanPham, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhoHangSanPham index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maSanPham"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhoHangSanPham"/> class.</returns>
		public abstract SkinCare.Entities.KhoHangSanPham GetByMaSanPham(TransactionManager transactionManager, System.Int32 _maSanPham, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region _tblKhoHangSanPham_GetSanPhamFromLastThreeMonth 
		
		/// <summary>
		///	This method wrap the '_tblKhoHangSanPham_GetSanPhamFromLastThreeMonth' stored procedure. 
		/// </summary>
		/// <param name="maKhachHang"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSanPhamFromLastThreeMonth(System.Int32? maKhachHang)
		{
			return GetSanPhamFromLastThreeMonth(null, 0, int.MaxValue , maKhachHang);
		}
		
		/// <summary>
		///	This method wrap the '_tblKhoHangSanPham_GetSanPhamFromLastThreeMonth' stored procedure. 
		/// </summary>
		/// <param name="maKhachHang"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSanPhamFromLastThreeMonth(int start, int pageLength, System.Int32? maKhachHang)
		{
			return GetSanPhamFromLastThreeMonth(null, start, pageLength , maKhachHang);
		}
				
		/// <summary>
		///	This method wrap the '_tblKhoHangSanPham_GetSanPhamFromLastThreeMonth' stored procedure. 
		/// </summary>
		/// <param name="maKhachHang"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetSanPhamFromLastThreeMonth(TransactionManager transactionManager, System.Int32? maKhachHang)
		{
			return GetSanPhamFromLastThreeMonth(transactionManager, 0, int.MaxValue , maKhachHang);
		}
		
		/// <summary>
		///	This method wrap the '_tblKhoHangSanPham_GetSanPhamFromLastThreeMonth' stored procedure. 
		/// </summary>
		/// <param name="maKhachHang"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetSanPhamFromLastThreeMonth(TransactionManager transactionManager, int start, int pageLength , System.Int32? maKhachHang);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;KhoHangSanPham&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;KhoHangSanPham&gt;"/></returns>
		public static TList<KhoHangSanPham> Fill(IDataReader reader, TList<KhoHangSanPham> rows, int start, int pageLength)
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
				
				SkinCare.Entities.KhoHangSanPham c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("KhoHangSanPham")
					.Append("|").Append((System.Int32)reader[((int)KhoHangSanPhamColumn.MaSanPham - 1)]).ToString();
					c = EntityManager.LocateOrCreate<KhoHangSanPham>(
					key.ToString(), // EntityTrackingKey
					"KhoHangSanPham",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.KhoHangSanPham();
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
					c.MaSanPham = (System.Int32)reader[((int)KhoHangSanPhamColumn.MaSanPham - 1)];
					c.TenSanPham = (reader.IsDBNull(((int)KhoHangSanPhamColumn.TenSanPham - 1)))?null:(System.String)reader[((int)KhoHangSanPhamColumn.TenSanPham - 1)];
					c.GiaTien = (reader.IsDBNull(((int)KhoHangSanPhamColumn.GiaTien - 1)))?null:(System.Decimal?)reader[((int)KhoHangSanPhamColumn.GiaTien - 1)];
					c.SoLuongNhapVao = (reader.IsDBNull(((int)KhoHangSanPhamColumn.SoLuongNhapVao - 1)))?null:(System.Int32?)reader[((int)KhoHangSanPhamColumn.SoLuongNhapVao - 1)];
					c.SoLuongBanRa = (reader.IsDBNull(((int)KhoHangSanPhamColumn.SoLuongBanRa - 1)))?null:(System.Int32?)reader[((int)KhoHangSanPhamColumn.SoLuongBanRa - 1)];
					c.SoLuongTonKho = (reader.IsDBNull(((int)KhoHangSanPhamColumn.SoLuongTonKho - 1)))?null:(System.Int32?)reader[((int)KhoHangSanPhamColumn.SoLuongTonKho - 1)];
					c.NgayNhapHang = (reader.IsDBNull(((int)KhoHangSanPhamColumn.NgayNhapHang - 1)))?null:(System.DateTime?)reader[((int)KhoHangSanPhamColumn.NgayNhapHang - 1)];
					c.GhiChu = (reader.IsDBNull(((int)KhoHangSanPhamColumn.GhiChu - 1)))?null:(System.String)reader[((int)KhoHangSanPhamColumn.GhiChu - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.KhoHangSanPham"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.KhoHangSanPham"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.KhoHangSanPham entity)
		{
			if (!reader.Read()) return;
			
			entity.MaSanPham = (System.Int32)reader[((int)KhoHangSanPhamColumn.MaSanPham - 1)];
			entity.TenSanPham = (reader.IsDBNull(((int)KhoHangSanPhamColumn.TenSanPham - 1)))?null:(System.String)reader[((int)KhoHangSanPhamColumn.TenSanPham - 1)];
			entity.GiaTien = (reader.IsDBNull(((int)KhoHangSanPhamColumn.GiaTien - 1)))?null:(System.Decimal?)reader[((int)KhoHangSanPhamColumn.GiaTien - 1)];
			entity.SoLuongNhapVao = (reader.IsDBNull(((int)KhoHangSanPhamColumn.SoLuongNhapVao - 1)))?null:(System.Int32?)reader[((int)KhoHangSanPhamColumn.SoLuongNhapVao - 1)];
			entity.SoLuongBanRa = (reader.IsDBNull(((int)KhoHangSanPhamColumn.SoLuongBanRa - 1)))?null:(System.Int32?)reader[((int)KhoHangSanPhamColumn.SoLuongBanRa - 1)];
			entity.SoLuongTonKho = (reader.IsDBNull(((int)KhoHangSanPhamColumn.SoLuongTonKho - 1)))?null:(System.Int32?)reader[((int)KhoHangSanPhamColumn.SoLuongTonKho - 1)];
			entity.NgayNhapHang = (reader.IsDBNull(((int)KhoHangSanPhamColumn.NgayNhapHang - 1)))?null:(System.DateTime?)reader[((int)KhoHangSanPhamColumn.NgayNhapHang - 1)];
			entity.GhiChu = (reader.IsDBNull(((int)KhoHangSanPhamColumn.GhiChu - 1)))?null:(System.String)reader[((int)KhoHangSanPhamColumn.GhiChu - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.KhoHangSanPham"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.KhoHangSanPham"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.KhoHangSanPham entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaSanPham = (System.Int32)dataRow["MaSanPham"];
			entity.TenSanPham = Convert.IsDBNull(dataRow["TenSanPham"]) ? null : (System.String)dataRow["TenSanPham"];
			entity.GiaTien = Convert.IsDBNull(dataRow["GiaTien"]) ? null : (System.Decimal?)dataRow["GiaTien"];
			entity.SoLuongNhapVao = Convert.IsDBNull(dataRow["SoLuongNhapVao"]) ? null : (System.Int32?)dataRow["SoLuongNhapVao"];
			entity.SoLuongBanRa = Convert.IsDBNull(dataRow["SoLuongBanRa"]) ? null : (System.Int32?)dataRow["SoLuongBanRa"];
			entity.SoLuongTonKho = Convert.IsDBNull(dataRow["SoLuongTonKho"]) ? null : (System.Int32?)dataRow["SoLuongTonKho"];
			entity.NgayNhapHang = Convert.IsDBNull(dataRow["NgayNhapHang"]) ? null : (System.DateTime?)dataRow["NgayNhapHang"];
			entity.GhiChu = Convert.IsDBNull(dataRow["GhiChu"]) ? null : (System.String)dataRow["GhiChu"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.KhoHangSanPham"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.KhoHangSanPham Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.KhoHangSanPham entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.KhoHangSanPham object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.KhoHangSanPham instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.KhoHangSanPham Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.KhoHangSanPham entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region KhoHangSanPhamChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.KhoHangSanPham</c>
	///</summary>
	public enum KhoHangSanPhamChildEntityTypes
	{
	}
	
	#endregion KhoHangSanPhamChildEntityTypes
	
	#region KhoHangSanPhamFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;KhoHangSanPhamColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoHangSanPhamFilterBuilder : SqlFilterBuilder<KhoHangSanPhamColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamFilterBuilder class.
		/// </summary>
		public KhoHangSanPhamFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoHangSanPhamFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoHangSanPhamFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoHangSanPhamFilterBuilder
	
	#region KhoHangSanPhamParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;KhoHangSanPhamColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhoHangSanPhamParameterBuilder : ParameterizedSqlFilterBuilder<KhoHangSanPhamColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamParameterBuilder class.
		/// </summary>
		public KhoHangSanPhamParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhoHangSanPhamParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhoHangSanPhamParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhoHangSanPhamParameterBuilder
	
	#region KhoHangSanPhamSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;KhoHangSanPhamColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhoHangSanPham"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class KhoHangSanPhamSortBuilder : SqlSortBuilder<KhoHangSanPhamColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhoHangSanPhamSqlSortBuilder class.
		/// </summary>
		public KhoHangSanPhamSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion KhoHangSanPhamSortBuilder
	
} // end namespace

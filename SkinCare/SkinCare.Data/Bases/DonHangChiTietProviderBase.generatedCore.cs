﻿#region Using directives

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
	/// This class is the base class for any <see cref="DonHangChiTietProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DonHangChiTietProviderBaseCore : EntityProviderBase<SkinCare.Entities.DonHangChiTiet, SkinCare.Entities.DonHangChiTietKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.DonHangChiTietKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
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
		public override SkinCare.Entities.DonHangChiTiet Get(TransactionManager transactionManager, SkinCare.Entities.DonHangChiTietKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblDonHangChiTiet index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHangChiTiet"/> class.</returns>
		public SkinCare.Entities.DonHangChiTiet GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHangChiTiet index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHangChiTiet"/> class.</returns>
		public SkinCare.Entities.DonHangChiTiet GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHangChiTiet index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHangChiTiet"/> class.</returns>
		public SkinCare.Entities.DonHangChiTiet GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHangChiTiet index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHangChiTiet"/> class.</returns>
		public SkinCare.Entities.DonHangChiTiet GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHangChiTiet index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHangChiTiet"/> class.</returns>
		public SkinCare.Entities.DonHangChiTiet GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblDonHangChiTiet index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.DonHangChiTiet"/> class.</returns>
		public abstract SkinCare.Entities.DonHangChiTiet GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DonHangChiTiet&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DonHangChiTiet&gt;"/></returns>
		public static TList<DonHangChiTiet> Fill(IDataReader reader, TList<DonHangChiTiet> rows, int start, int pageLength)
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
				
				SkinCare.Entities.DonHangChiTiet c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DonHangChiTiet")
					.Append("|").Append((System.Int32)reader[((int)DonHangChiTietColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DonHangChiTiet>(
					key.ToString(), // EntityTrackingKey
					"DonHangChiTiet",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.DonHangChiTiet();
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
					c.Id = (System.Int32)reader[((int)DonHangChiTietColumn.Id - 1)];
					c.MaDonHang = (reader.IsDBNull(((int)DonHangChiTietColumn.MaDonHang - 1)))?null:(System.Int32?)reader[((int)DonHangChiTietColumn.MaDonHang - 1)];
					c.MaSanPham = (reader.IsDBNull(((int)DonHangChiTietColumn.MaSanPham - 1)))?null:(System.Int32?)reader[((int)DonHangChiTietColumn.MaSanPham - 1)];
					c.DonGia = (reader.IsDBNull(((int)DonHangChiTietColumn.DonGia - 1)))?null:(System.Decimal?)reader[((int)DonHangChiTietColumn.DonGia - 1)];
					c.SoLuong = (reader.IsDBNull(((int)DonHangChiTietColumn.SoLuong - 1)))?null:(System.Int32?)reader[((int)DonHangChiTietColumn.SoLuong - 1)];
					c.ThanhTien = (reader.IsDBNull(((int)DonHangChiTietColumn.ThanhTien - 1)))?null:(System.Decimal?)reader[((int)DonHangChiTietColumn.ThanhTien - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.DonHangChiTiet"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.DonHangChiTiet"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.DonHangChiTiet entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)DonHangChiTietColumn.Id - 1)];
			entity.MaDonHang = (reader.IsDBNull(((int)DonHangChiTietColumn.MaDonHang - 1)))?null:(System.Int32?)reader[((int)DonHangChiTietColumn.MaDonHang - 1)];
			entity.MaSanPham = (reader.IsDBNull(((int)DonHangChiTietColumn.MaSanPham - 1)))?null:(System.Int32?)reader[((int)DonHangChiTietColumn.MaSanPham - 1)];
			entity.DonGia = (reader.IsDBNull(((int)DonHangChiTietColumn.DonGia - 1)))?null:(System.Decimal?)reader[((int)DonHangChiTietColumn.DonGia - 1)];
			entity.SoLuong = (reader.IsDBNull(((int)DonHangChiTietColumn.SoLuong - 1)))?null:(System.Int32?)reader[((int)DonHangChiTietColumn.SoLuong - 1)];
			entity.ThanhTien = (reader.IsDBNull(((int)DonHangChiTietColumn.ThanhTien - 1)))?null:(System.Decimal?)reader[((int)DonHangChiTietColumn.ThanhTien - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.DonHangChiTiet"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.DonHangChiTiet"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.DonHangChiTiet entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.MaDonHang = Convert.IsDBNull(dataRow["MaDonHang"]) ? null : (System.Int32?)dataRow["MaDonHang"];
			entity.MaSanPham = Convert.IsDBNull(dataRow["MaSanPham"]) ? null : (System.Int32?)dataRow["MaSanPham"];
			entity.DonGia = Convert.IsDBNull(dataRow["DonGia"]) ? null : (System.Decimal?)dataRow["DonGia"];
			entity.SoLuong = Convert.IsDBNull(dataRow["SoLuong"]) ? null : (System.Int32?)dataRow["SoLuong"];
			entity.ThanhTien = Convert.IsDBNull(dataRow["ThanhTien"]) ? null : (System.Decimal?)dataRow["ThanhTien"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.DonHangChiTiet"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.DonHangChiTiet Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.DonHangChiTiet entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.DonHangChiTiet object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.DonHangChiTiet instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.DonHangChiTiet Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.DonHangChiTiet entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region DonHangChiTietChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.DonHangChiTiet</c>
	///</summary>
	public enum DonHangChiTietChildEntityTypes
	{
	}
	
	#endregion DonHangChiTietChildEntityTypes
	
	#region DonHangChiTietFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DonHangChiTietColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangChiTietFilterBuilder : SqlFilterBuilder<DonHangChiTietColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietFilterBuilder class.
		/// </summary>
		public DonHangChiTietFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangChiTietFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangChiTietFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangChiTietFilterBuilder
	
	#region DonHangChiTietParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DonHangChiTietColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DonHangChiTietParameterBuilder : ParameterizedSqlFilterBuilder<DonHangChiTietColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietParameterBuilder class.
		/// </summary>
		public DonHangChiTietParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DonHangChiTietParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DonHangChiTietParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DonHangChiTietParameterBuilder
	
	#region DonHangChiTietSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DonHangChiTietColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DonHangChiTiet"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DonHangChiTietSortBuilder : SqlSortBuilder<DonHangChiTietColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DonHangChiTietSqlSortBuilder class.
		/// </summary>
		public DonHangChiTietSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DonHangChiTietSortBuilder
	
} // end namespace

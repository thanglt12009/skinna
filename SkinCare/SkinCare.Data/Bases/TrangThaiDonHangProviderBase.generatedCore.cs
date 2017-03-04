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
	/// This class is the base class for any <see cref="TrangThaiDonHangProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TrangThaiDonHangProviderBaseCore : EntityProviderBase<SkinCare.Entities.TrangThaiDonHang, SkinCare.Entities.TrangThaiDonHangKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.TrangThaiDonHangKey key)
		{
			return Delete(transactionManager, key.MaTrangThaiDonHang);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_maTrangThaiDonHang">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _maTrangThaiDonHang)
		{
			return Delete(null, _maTrangThaiDonHang);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maTrangThaiDonHang">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _maTrangThaiDonHang);		
		
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
		public override SkinCare.Entities.TrangThaiDonHang Get(TransactionManager transactionManager, SkinCare.Entities.TrangThaiDonHangKey key, int start, int pageLength)
		{
			return GetByMaTrangThaiDonHang(transactionManager, key.MaTrangThaiDonHang, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblTrangThaiDonHang index.
		/// </summary>
		/// <param name="_maTrangThaiDonHang"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.TrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.TrangThaiDonHang GetByMaTrangThaiDonHang(System.Int32 _maTrangThaiDonHang)
		{
			int count = -1;
			return GetByMaTrangThaiDonHang(null,_maTrangThaiDonHang, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTrangThaiDonHang index.
		/// </summary>
		/// <param name="_maTrangThaiDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.TrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.TrangThaiDonHang GetByMaTrangThaiDonHang(System.Int32 _maTrangThaiDonHang, int start, int pageLength)
		{
			int count = -1;
			return GetByMaTrangThaiDonHang(null, _maTrangThaiDonHang, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTrangThaiDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maTrangThaiDonHang"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.TrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.TrangThaiDonHang GetByMaTrangThaiDonHang(TransactionManager transactionManager, System.Int32 _maTrangThaiDonHang)
		{
			int count = -1;
			return GetByMaTrangThaiDonHang(transactionManager, _maTrangThaiDonHang, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTrangThaiDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maTrangThaiDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.TrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.TrangThaiDonHang GetByMaTrangThaiDonHang(TransactionManager transactionManager, System.Int32 _maTrangThaiDonHang, int start, int pageLength)
		{
			int count = -1;
			return GetByMaTrangThaiDonHang(transactionManager, _maTrangThaiDonHang, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTrangThaiDonHang index.
		/// </summary>
		/// <param name="_maTrangThaiDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.TrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.TrangThaiDonHang GetByMaTrangThaiDonHang(System.Int32 _maTrangThaiDonHang, int start, int pageLength, out int count)
		{
			return GetByMaTrangThaiDonHang(null, _maTrangThaiDonHang, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblTrangThaiDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maTrangThaiDonHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.TrangThaiDonHang"/> class.</returns>
		public abstract SkinCare.Entities.TrangThaiDonHang GetByMaTrangThaiDonHang(TransactionManager transactionManager, System.Int32 _maTrangThaiDonHang, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TrangThaiDonHang&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TrangThaiDonHang&gt;"/></returns>
		public static TList<TrangThaiDonHang> Fill(IDataReader reader, TList<TrangThaiDonHang> rows, int start, int pageLength)
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
				
				SkinCare.Entities.TrangThaiDonHang c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TrangThaiDonHang")
					.Append("|").Append((System.Int32)reader[((int)TrangThaiDonHangColumn.MaTrangThaiDonHang - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TrangThaiDonHang>(
					key.ToString(), // EntityTrackingKey
					"TrangThaiDonHang",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.TrangThaiDonHang();
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
					c.MaTrangThaiDonHang = (System.Int32)reader[((int)TrangThaiDonHangColumn.MaTrangThaiDonHang - 1)];
					c.OriginalMaTrangThaiDonHang = c.MaTrangThaiDonHang;
					c.MaLoaiTrangThaiDonHang = (System.Int32)reader[((int)TrangThaiDonHangColumn.MaLoaiTrangThaiDonHang - 1)];
					c.TenLoaiTrangThaiDonHang = (reader.IsDBNull(((int)TrangThaiDonHangColumn.TenLoaiTrangThaiDonHang - 1)))?null:(System.String)reader[((int)TrangThaiDonHangColumn.TenLoaiTrangThaiDonHang - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.TrangThaiDonHang"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.TrangThaiDonHang"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.TrangThaiDonHang entity)
		{
			if (!reader.Read()) return;
			
			entity.MaTrangThaiDonHang = (System.Int32)reader[((int)TrangThaiDonHangColumn.MaTrangThaiDonHang - 1)];
			entity.OriginalMaTrangThaiDonHang = (System.Int32)reader["MaTrangThaiDonHang"];
			entity.MaLoaiTrangThaiDonHang = (System.Int32)reader[((int)TrangThaiDonHangColumn.MaLoaiTrangThaiDonHang - 1)];
			entity.TenLoaiTrangThaiDonHang = (reader.IsDBNull(((int)TrangThaiDonHangColumn.TenLoaiTrangThaiDonHang - 1)))?null:(System.String)reader[((int)TrangThaiDonHangColumn.TenLoaiTrangThaiDonHang - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.TrangThaiDonHang"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.TrangThaiDonHang"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.TrangThaiDonHang entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaTrangThaiDonHang = (System.Int32)dataRow["MaTrangThaiDonHang"];
			entity.OriginalMaTrangThaiDonHang = (System.Int32)dataRow["MaTrangThaiDonHang"];
			entity.MaLoaiTrangThaiDonHang = (System.Int32)dataRow["MaLoaiTrangThaiDonHang"];
			entity.TenLoaiTrangThaiDonHang = Convert.IsDBNull(dataRow["TenLoaiTrangThaiDonHang"]) ? null : (System.String)dataRow["TenLoaiTrangThaiDonHang"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.TrangThaiDonHang"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.TrangThaiDonHang Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.TrangThaiDonHang entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.TrangThaiDonHang object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.TrangThaiDonHang instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.TrangThaiDonHang Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.TrangThaiDonHang entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region TrangThaiDonHangChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.TrangThaiDonHang</c>
	///</summary>
	public enum TrangThaiDonHangChildEntityTypes
	{
	}
	
	#endregion TrangThaiDonHangChildEntityTypes
	
	#region TrangThaiDonHangFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TrangThaiDonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrangThaiDonHangFilterBuilder : SqlFilterBuilder<TrangThaiDonHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangFilterBuilder class.
		/// </summary>
		public TrangThaiDonHangFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrangThaiDonHangFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrangThaiDonHangFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrangThaiDonHangFilterBuilder
	
	#region TrangThaiDonHangParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TrangThaiDonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TrangThaiDonHangParameterBuilder : ParameterizedSqlFilterBuilder<TrangThaiDonHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangParameterBuilder class.
		/// </summary>
		public TrangThaiDonHangParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TrangThaiDonHangParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TrangThaiDonHangParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TrangThaiDonHangParameterBuilder
	
	#region TrangThaiDonHangSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TrangThaiDonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TrangThaiDonHang"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TrangThaiDonHangSortBuilder : SqlSortBuilder<TrangThaiDonHangColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TrangThaiDonHangSqlSortBuilder class.
		/// </summary>
		public TrangThaiDonHangSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TrangThaiDonHangSortBuilder
	
} // end namespace

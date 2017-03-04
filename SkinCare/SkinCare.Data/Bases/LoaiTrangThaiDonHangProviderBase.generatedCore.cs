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
	/// This class is the base class for any <see cref="LoaiTrangThaiDonHangProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LoaiTrangThaiDonHangProviderBaseCore : EntityProviderBase<SkinCare.Entities.LoaiTrangThaiDonHang, SkinCare.Entities.LoaiTrangThaiDonHangKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.LoaiTrangThaiDonHangKey key)
		{
			return Delete(transactionManager, key.MaLoaiTrangThai);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _maLoaiTrangThai)
		{
			return Delete(null, _maLoaiTrangThai);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _maLoaiTrangThai);		
		
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
		public override SkinCare.Entities.LoaiTrangThaiDonHang Get(TransactionManager transactionManager, SkinCare.Entities.LoaiTrangThaiDonHangKey key, int start, int pageLength)
		{
			return GetByMaLoaiTrangThai(transactionManager, key.MaLoaiTrangThai, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblLoaiTrangThaiDonHang index.
		/// </summary>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.LoaiTrangThaiDonHang GetByMaLoaiTrangThai(System.Int32 _maLoaiTrangThai)
		{
			int count = -1;
			return GetByMaLoaiTrangThai(null,_maLoaiTrangThai, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLoaiTrangThaiDonHang index.
		/// </summary>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.LoaiTrangThaiDonHang GetByMaLoaiTrangThai(System.Int32 _maLoaiTrangThai, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLoaiTrangThai(null, _maLoaiTrangThai, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLoaiTrangThaiDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.LoaiTrangThaiDonHang GetByMaLoaiTrangThai(TransactionManager transactionManager, System.Int32 _maLoaiTrangThai)
		{
			int count = -1;
			return GetByMaLoaiTrangThai(transactionManager, _maLoaiTrangThai, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLoaiTrangThaiDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.LoaiTrangThaiDonHang GetByMaLoaiTrangThai(TransactionManager transactionManager, System.Int32 _maLoaiTrangThai, int start, int pageLength)
		{
			int count = -1;
			return GetByMaLoaiTrangThai(transactionManager, _maLoaiTrangThai, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLoaiTrangThaiDonHang index.
		/// </summary>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> class.</returns>
		public SkinCare.Entities.LoaiTrangThaiDonHang GetByMaLoaiTrangThai(System.Int32 _maLoaiTrangThai, int start, int pageLength, out int count)
		{
			return GetByMaLoaiTrangThai(null, _maLoaiTrangThai, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLoaiTrangThaiDonHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maLoaiTrangThai">--------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> class.</returns>
		public abstract SkinCare.Entities.LoaiTrangThaiDonHang GetByMaLoaiTrangThai(TransactionManager transactionManager, System.Int32 _maLoaiTrangThai, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;LoaiTrangThaiDonHang&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;LoaiTrangThaiDonHang&gt;"/></returns>
		public static TList<LoaiTrangThaiDonHang> Fill(IDataReader reader, TList<LoaiTrangThaiDonHang> rows, int start, int pageLength)
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
				
				SkinCare.Entities.LoaiTrangThaiDonHang c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("LoaiTrangThaiDonHang")
					.Append("|").Append((System.Int32)reader[((int)LoaiTrangThaiDonHangColumn.MaLoaiTrangThai - 1)]).ToString();
					c = EntityManager.LocateOrCreate<LoaiTrangThaiDonHang>(
					key.ToString(), // EntityTrackingKey
					"LoaiTrangThaiDonHang",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.LoaiTrangThaiDonHang();
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
					c.MaLoaiTrangThai = (System.Int32)reader[((int)LoaiTrangThaiDonHangColumn.MaLoaiTrangThai - 1)];
					c.OriginalMaLoaiTrangThai = c.MaLoaiTrangThai;
					c.TenLoaiTrangThai = (reader.IsDBNull(((int)LoaiTrangThaiDonHangColumn.TenLoaiTrangThai - 1)))?null:(System.String)reader[((int)LoaiTrangThaiDonHangColumn.TenLoaiTrangThai - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.LoaiTrangThaiDonHang entity)
		{
			if (!reader.Read()) return;
			
			entity.MaLoaiTrangThai = (System.Int32)reader[((int)LoaiTrangThaiDonHangColumn.MaLoaiTrangThai - 1)];
			entity.OriginalMaLoaiTrangThai = (System.Int32)reader["MaLoaiTrangThai"];
			entity.TenLoaiTrangThai = (reader.IsDBNull(((int)LoaiTrangThaiDonHangColumn.TenLoaiTrangThai - 1)))?null:(System.String)reader[((int)LoaiTrangThaiDonHangColumn.TenLoaiTrangThai - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.LoaiTrangThaiDonHang entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaLoaiTrangThai = (System.Int32)dataRow["MaLoaiTrangThai"];
			entity.OriginalMaLoaiTrangThai = (System.Int32)dataRow["MaLoaiTrangThai"];
			entity.TenLoaiTrangThai = Convert.IsDBNull(dataRow["TenLoaiTrangThai"]) ? null : (System.String)dataRow["TenLoaiTrangThai"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.LoaiTrangThaiDonHang"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.LoaiTrangThaiDonHang Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.LoaiTrangThaiDonHang entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.LoaiTrangThaiDonHang object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.LoaiTrangThaiDonHang instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.LoaiTrangThaiDonHang Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.LoaiTrangThaiDonHang entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region LoaiTrangThaiDonHangChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.LoaiTrangThaiDonHang</c>
	///</summary>
	public enum LoaiTrangThaiDonHangChildEntityTypes
	{
	}
	
	#endregion LoaiTrangThaiDonHangChildEntityTypes
	
	#region LoaiTrangThaiDonHangFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LoaiTrangThaiDonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiTrangThaiDonHangFilterBuilder : SqlFilterBuilder<LoaiTrangThaiDonHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangFilterBuilder class.
		/// </summary>
		public LoaiTrangThaiDonHangFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiTrangThaiDonHangFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiTrangThaiDonHangFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiTrangThaiDonHangFilterBuilder
	
	#region LoaiTrangThaiDonHangParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LoaiTrangThaiDonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LoaiTrangThaiDonHangParameterBuilder : ParameterizedSqlFilterBuilder<LoaiTrangThaiDonHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangParameterBuilder class.
		/// </summary>
		public LoaiTrangThaiDonHangParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LoaiTrangThaiDonHangParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LoaiTrangThaiDonHangParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LoaiTrangThaiDonHangParameterBuilder
	
	#region LoaiTrangThaiDonHangSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;LoaiTrangThaiDonHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LoaiTrangThaiDonHang"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class LoaiTrangThaiDonHangSortBuilder : SqlSortBuilder<LoaiTrangThaiDonHangColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LoaiTrangThaiDonHangSqlSortBuilder class.
		/// </summary>
		public LoaiTrangThaiDonHangSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion LoaiTrangThaiDonHangSortBuilder
	
} // end namespace

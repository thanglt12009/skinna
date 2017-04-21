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
	/// This class is the base class for any <see cref="LieuTrinhProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LieuTrinhProviderBaseCore : EntityProviderBase<SkinCare.Entities.LieuTrinh, SkinCare.Entities.LieuTrinhKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.LieuTrinhKey key)
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
		public override SkinCare.Entities.LieuTrinh Get(TransactionManager transactionManager, SkinCare.Entities.LieuTrinhKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblLieuTrinh index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LieuTrinh"/> class.</returns>
		public SkinCare.Entities.LieuTrinh GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLieuTrinh index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LieuTrinh"/> class.</returns>
		public SkinCare.Entities.LieuTrinh GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLieuTrinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LieuTrinh"/> class.</returns>
		public SkinCare.Entities.LieuTrinh GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLieuTrinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LieuTrinh"/> class.</returns>
		public SkinCare.Entities.LieuTrinh GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLieuTrinh index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LieuTrinh"/> class.</returns>
		public SkinCare.Entities.LieuTrinh GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblLieuTrinh index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.LieuTrinh"/> class.</returns>
		public abstract SkinCare.Entities.LieuTrinh GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;LieuTrinh&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;LieuTrinh&gt;"/></returns>
		public static TList<LieuTrinh> Fill(IDataReader reader, TList<LieuTrinh> rows, int start, int pageLength)
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
				
				SkinCare.Entities.LieuTrinh c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("LieuTrinh")
					.Append("|").Append((System.Int32)reader[((int)LieuTrinhColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<LieuTrinh>(
					key.ToString(), // EntityTrackingKey
					"LieuTrinh",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.LieuTrinh();
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
					c.Id = (System.Int32)reader[((int)LieuTrinhColumn.Id - 1)];
					c.MaKhachHang = (reader.IsDBNull(((int)LieuTrinhColumn.MaKhachHang - 1)))?null:(System.Int32?)reader[((int)LieuTrinhColumn.MaKhachHang - 1)];
					c.Ngay = (reader.IsDBNull(((int)LieuTrinhColumn.Ngay - 1)))?null:(System.DateTime?)reader[((int)LieuTrinhColumn.Ngay - 1)];
					c.TayTrangToi = (reader.IsDBNull(((int)LieuTrinhColumn.TayTrangToi - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.TayTrangToi - 1)];
					c.RuaMat = (reader.IsDBNull(((int)LieuTrinhColumn.RuaMat - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.RuaMat - 1)];
					c.Toner = (reader.IsDBNull(((int)LieuTrinhColumn.Toner - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.Toner - 1)];
					c.Serum = (reader.IsDBNull(((int)LieuTrinhColumn.Serum - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.Serum - 1)];
					c.Kem = (reader.IsDBNull(((int)LieuTrinhColumn.Kem - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.Kem - 1)];
					c.SanPhamKhac = (reader.IsDBNull(((int)LieuTrinhColumn.SanPhamKhac - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.SanPhamKhac - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.LieuTrinh"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.LieuTrinh"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.LieuTrinh entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)LieuTrinhColumn.Id - 1)];
			entity.MaKhachHang = (reader.IsDBNull(((int)LieuTrinhColumn.MaKhachHang - 1)))?null:(System.Int32?)reader[((int)LieuTrinhColumn.MaKhachHang - 1)];
			entity.Ngay = (reader.IsDBNull(((int)LieuTrinhColumn.Ngay - 1)))?null:(System.DateTime?)reader[((int)LieuTrinhColumn.Ngay - 1)];
			entity.TayTrangToi = (reader.IsDBNull(((int)LieuTrinhColumn.TayTrangToi - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.TayTrangToi - 1)];
			entity.RuaMat = (reader.IsDBNull(((int)LieuTrinhColumn.RuaMat - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.RuaMat - 1)];
			entity.Toner = (reader.IsDBNull(((int)LieuTrinhColumn.Toner - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.Toner - 1)];
			entity.Serum = (reader.IsDBNull(((int)LieuTrinhColumn.Serum - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.Serum - 1)];
			entity.Kem = (reader.IsDBNull(((int)LieuTrinhColumn.Kem - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.Kem - 1)];
			entity.SanPhamKhac = (reader.IsDBNull(((int)LieuTrinhColumn.SanPhamKhac - 1)))?null:(System.String)reader[((int)LieuTrinhColumn.SanPhamKhac - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.LieuTrinh"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.LieuTrinh"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.LieuTrinh entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.MaKhachHang = Convert.IsDBNull(dataRow["MaKhachHang"]) ? null : (System.Int32?)dataRow["MaKhachHang"];
			entity.Ngay = Convert.IsDBNull(dataRow["Ngay"]) ? null : (System.DateTime?)dataRow["Ngay"];
			entity.TayTrangToi = Convert.IsDBNull(dataRow["TayTrangToi"]) ? null : (System.String)dataRow["TayTrangToi"];
			entity.RuaMat = Convert.IsDBNull(dataRow["RuaMat"]) ? null : (System.String)dataRow["RuaMat"];
			entity.Toner = Convert.IsDBNull(dataRow["Toner"]) ? null : (System.String)dataRow["Toner"];
			entity.Serum = Convert.IsDBNull(dataRow["Serum"]) ? null : (System.String)dataRow["Serum"];
			entity.Kem = Convert.IsDBNull(dataRow["Kem"]) ? null : (System.String)dataRow["Kem"];
			entity.SanPhamKhac = Convert.IsDBNull(dataRow["SanPhamKhac"]) ? null : (System.String)dataRow["SanPhamKhac"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.LieuTrinh"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.LieuTrinh Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.LieuTrinh entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.LieuTrinh object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.LieuTrinh instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.LieuTrinh Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.LieuTrinh entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region LieuTrinhChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.LieuTrinh</c>
	///</summary>
	public enum LieuTrinhChildEntityTypes
	{
	}
	
	#endregion LieuTrinhChildEntityTypes
	
	#region LieuTrinhFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;LieuTrinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LieuTrinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LieuTrinhFilterBuilder : SqlFilterBuilder<LieuTrinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LieuTrinhFilterBuilder class.
		/// </summary>
		public LieuTrinhFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LieuTrinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LieuTrinhFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LieuTrinhFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LieuTrinhFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LieuTrinhFilterBuilder
	
	#region LieuTrinhParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;LieuTrinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LieuTrinh"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LieuTrinhParameterBuilder : ParameterizedSqlFilterBuilder<LieuTrinhColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LieuTrinhParameterBuilder class.
		/// </summary>
		public LieuTrinhParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the LieuTrinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LieuTrinhParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LieuTrinhParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LieuTrinhParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LieuTrinhParameterBuilder
	
	#region LieuTrinhSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;LieuTrinhColumn&gt;"/> class
	/// that is used exclusively with a <see cref="LieuTrinh"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class LieuTrinhSortBuilder : SqlSortBuilder<LieuTrinhColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LieuTrinhSqlSortBuilder class.
		/// </summary>
		public LieuTrinhSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion LieuTrinhSortBuilder
	
} // end namespace

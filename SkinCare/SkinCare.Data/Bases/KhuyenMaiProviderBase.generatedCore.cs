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
	/// This class is the base class for any <see cref="KhuyenMaiProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class KhuyenMaiProviderBaseCore : EntityProviderBase<SkinCare.Entities.KhuyenMai, SkinCare.Entities.KhuyenMaiKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.KhuyenMaiKey key)
		{
			return Delete(transactionManager, key.MaKhuyenMai);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_maKhuyenMai">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _maKhuyenMai)
		{
			return Delete(null, _maKhuyenMai);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhuyenMai">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _maKhuyenMai);		
		
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
		public override SkinCare.Entities.KhuyenMai Get(TransactionManager transactionManager, SkinCare.Entities.KhuyenMaiKey key, int start, int pageLength)
		{
			return GetByMaKhuyenMai(transactionManager, key.MaKhuyenMai, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblKhuyenMai index.
		/// </summary>
		/// <param name="_maKhuyenMai"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhuyenMai"/> class.</returns>
		public SkinCare.Entities.KhuyenMai GetByMaKhuyenMai(System.Int32 _maKhuyenMai)
		{
			int count = -1;
			return GetByMaKhuyenMai(null,_maKhuyenMai, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhuyenMai index.
		/// </summary>
		/// <param name="_maKhuyenMai"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhuyenMai"/> class.</returns>
		public SkinCare.Entities.KhuyenMai GetByMaKhuyenMai(System.Int32 _maKhuyenMai, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhuyenMai(null, _maKhuyenMai, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhuyenMai index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhuyenMai"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhuyenMai"/> class.</returns>
		public SkinCare.Entities.KhuyenMai GetByMaKhuyenMai(TransactionManager transactionManager, System.Int32 _maKhuyenMai)
		{
			int count = -1;
			return GetByMaKhuyenMai(transactionManager, _maKhuyenMai, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhuyenMai index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhuyenMai"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhuyenMai"/> class.</returns>
		public SkinCare.Entities.KhuyenMai GetByMaKhuyenMai(TransactionManager transactionManager, System.Int32 _maKhuyenMai, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhuyenMai(transactionManager, _maKhuyenMai, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhuyenMai index.
		/// </summary>
		/// <param name="_maKhuyenMai"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhuyenMai"/> class.</returns>
		public SkinCare.Entities.KhuyenMai GetByMaKhuyenMai(System.Int32 _maKhuyenMai, int start, int pageLength, out int count)
		{
			return GetByMaKhuyenMai(null, _maKhuyenMai, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhuyenMai index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhuyenMai"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhuyenMai"/> class.</returns>
		public abstract SkinCare.Entities.KhuyenMai GetByMaKhuyenMai(TransactionManager transactionManager, System.Int32 _maKhuyenMai, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;KhuyenMai&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;KhuyenMai&gt;"/></returns>
		public static TList<KhuyenMai> Fill(IDataReader reader, TList<KhuyenMai> rows, int start, int pageLength)
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
				
				SkinCare.Entities.KhuyenMai c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("KhuyenMai")
					.Append("|").Append((System.Int32)reader[((int)KhuyenMaiColumn.MaKhuyenMai - 1)]).ToString();
					c = EntityManager.LocateOrCreate<KhuyenMai>(
					key.ToString(), // EntityTrackingKey
					"KhuyenMai",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.KhuyenMai();
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
					c.MaKhuyenMai = (System.Int32)reader[((int)KhuyenMaiColumn.MaKhuyenMai - 1)];
					c.OriginalMaKhuyenMai = c.MaKhuyenMai;
					c.MaLoaiKhuyenMai = (System.Int32)reader[((int)KhuyenMaiColumn.MaLoaiKhuyenMai - 1)];
					c.TenKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.TenKhuyenMai - 1)))?null:(System.String)reader[((int)KhuyenMaiColumn.TenKhuyenMai - 1)];
					c.GiaGiam = (reader.IsDBNull(((int)KhuyenMaiColumn.GiaGiam - 1)))?null:(System.Decimal?)reader[((int)KhuyenMaiColumn.GiaGiam - 1)];
					c.NgayTaoKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.NgayTaoKhuyenMai - 1)))?null:(System.DateTime?)reader[((int)KhuyenMaiColumn.NgayTaoKhuyenMai - 1)];
					c.NgayBatDauKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.NgayBatDauKhuyenMai - 1)))?null:(System.DateTime?)reader[((int)KhuyenMaiColumn.NgayBatDauKhuyenMai - 1)];
					c.NgayKetThucKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.NgayKetThucKhuyenMai - 1)))?null:(System.DateTime?)reader[((int)KhuyenMaiColumn.NgayKetThucKhuyenMai - 1)];
					c.Active = (reader.IsDBNull(((int)KhuyenMaiColumn.Active - 1)))?null:(System.Boolean?)reader[((int)KhuyenMaiColumn.Active - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.KhuyenMai"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.KhuyenMai"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.KhuyenMai entity)
		{
			if (!reader.Read()) return;
			
			entity.MaKhuyenMai = (System.Int32)reader[((int)KhuyenMaiColumn.MaKhuyenMai - 1)];
			entity.OriginalMaKhuyenMai = (System.Int32)reader["MaKhuyenMai"];
			entity.MaLoaiKhuyenMai = (System.Int32)reader[((int)KhuyenMaiColumn.MaLoaiKhuyenMai - 1)];
			entity.TenKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.TenKhuyenMai - 1)))?null:(System.String)reader[((int)KhuyenMaiColumn.TenKhuyenMai - 1)];
			entity.GiaGiam = (reader.IsDBNull(((int)KhuyenMaiColumn.GiaGiam - 1)))?null:(System.Decimal?)reader[((int)KhuyenMaiColumn.GiaGiam - 1)];
			entity.NgayTaoKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.NgayTaoKhuyenMai - 1)))?null:(System.DateTime?)reader[((int)KhuyenMaiColumn.NgayTaoKhuyenMai - 1)];
			entity.NgayBatDauKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.NgayBatDauKhuyenMai - 1)))?null:(System.DateTime?)reader[((int)KhuyenMaiColumn.NgayBatDauKhuyenMai - 1)];
			entity.NgayKetThucKhuyenMai = (reader.IsDBNull(((int)KhuyenMaiColumn.NgayKetThucKhuyenMai - 1)))?null:(System.DateTime?)reader[((int)KhuyenMaiColumn.NgayKetThucKhuyenMai - 1)];
			entity.Active = (reader.IsDBNull(((int)KhuyenMaiColumn.Active - 1)))?null:(System.Boolean?)reader[((int)KhuyenMaiColumn.Active - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.KhuyenMai"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.KhuyenMai"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.KhuyenMai entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaKhuyenMai = (System.Int32)dataRow["MaKhuyenMai"];
			entity.OriginalMaKhuyenMai = (System.Int32)dataRow["MaKhuyenMai"];
			entity.MaLoaiKhuyenMai = (System.Int32)dataRow["MaLoaiKhuyenMai"];
			entity.TenKhuyenMai = Convert.IsDBNull(dataRow["TenKhuyenMai"]) ? null : (System.String)dataRow["TenKhuyenMai"];
			entity.GiaGiam = Convert.IsDBNull(dataRow["GiaGiam"]) ? null : (System.Decimal?)dataRow["GiaGiam"];
			entity.NgayTaoKhuyenMai = Convert.IsDBNull(dataRow["NgayTaoKhuyenMai"]) ? null : (System.DateTime?)dataRow["NgayTaoKhuyenMai"];
			entity.NgayBatDauKhuyenMai = Convert.IsDBNull(dataRow["NgayBatDauKhuyenMai"]) ? null : (System.DateTime?)dataRow["NgayBatDauKhuyenMai"];
			entity.NgayKetThucKhuyenMai = Convert.IsDBNull(dataRow["NgayKetThucKhuyenMai"]) ? null : (System.DateTime?)dataRow["NgayKetThucKhuyenMai"];
			entity.Active = Convert.IsDBNull(dataRow["Active"]) ? null : (System.Boolean?)dataRow["Active"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.KhuyenMai"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.KhuyenMai Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.KhuyenMai entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.KhuyenMai object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.KhuyenMai instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.KhuyenMai Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.KhuyenMai entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region KhuyenMaiChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.KhuyenMai</c>
	///</summary>
	public enum KhuyenMaiChildEntityTypes
	{
	}
	
	#endregion KhuyenMaiChildEntityTypes
	
	#region KhuyenMaiFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;KhuyenMaiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuyenMaiFilterBuilder : SqlFilterBuilder<KhuyenMaiColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiFilterBuilder class.
		/// </summary>
		public KhuyenMaiFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuyenMaiFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuyenMaiFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuyenMaiFilterBuilder
	
	#region KhuyenMaiParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;KhuyenMaiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhuyenMaiParameterBuilder : ParameterizedSqlFilterBuilder<KhuyenMaiColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiParameterBuilder class.
		/// </summary>
		public KhuyenMaiParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhuyenMaiParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhuyenMaiParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhuyenMaiParameterBuilder
	
	#region KhuyenMaiSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;KhuyenMaiColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhuyenMai"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class KhuyenMaiSortBuilder : SqlSortBuilder<KhuyenMaiColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhuyenMaiSqlSortBuilder class.
		/// </summary>
		public KhuyenMaiSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion KhuyenMaiSortBuilder
	
} // end namespace

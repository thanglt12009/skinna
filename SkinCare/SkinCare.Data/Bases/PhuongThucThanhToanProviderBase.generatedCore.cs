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
	/// This class is the base class for any <see cref="PhuongThucThanhToanProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PhuongThucThanhToanProviderBaseCore : EntityProviderBase<SkinCare.Entities.PhuongThucThanhToan, SkinCare.Entities.PhuongThucThanhToanKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.PhuongThucThanhToanKey key)
		{
			return Delete(transactionManager, key.MaPhuongThucThanhToan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_maPhuongThucThanhToan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _maPhuongThucThanhToan)
		{
			return Delete(null, _maPhuongThucThanhToan);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maPhuongThucThanhToan">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _maPhuongThucThanhToan);		
		
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
		public override SkinCare.Entities.PhuongThucThanhToan Get(TransactionManager transactionManager, SkinCare.Entities.PhuongThucThanhToanKey key, int start, int pageLength)
		{
			return GetByMaPhuongThucThanhToan(transactionManager, key.MaPhuongThucThanhToan, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblPhuongThucThanhToan index.
		/// </summary>
		/// <param name="_maPhuongThucThanhToan"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> class.</returns>
		public SkinCare.Entities.PhuongThucThanhToan GetByMaPhuongThucThanhToan(System.Int32 _maPhuongThucThanhToan)
		{
			int count = -1;
			return GetByMaPhuongThucThanhToan(null,_maPhuongThucThanhToan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPhuongThucThanhToan index.
		/// </summary>
		/// <param name="_maPhuongThucThanhToan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> class.</returns>
		public SkinCare.Entities.PhuongThucThanhToan GetByMaPhuongThucThanhToan(System.Int32 _maPhuongThucThanhToan, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhuongThucThanhToan(null, _maPhuongThucThanhToan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPhuongThucThanhToan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maPhuongThucThanhToan"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> class.</returns>
		public SkinCare.Entities.PhuongThucThanhToan GetByMaPhuongThucThanhToan(TransactionManager transactionManager, System.Int32 _maPhuongThucThanhToan)
		{
			int count = -1;
			return GetByMaPhuongThucThanhToan(transactionManager, _maPhuongThucThanhToan, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPhuongThucThanhToan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maPhuongThucThanhToan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> class.</returns>
		public SkinCare.Entities.PhuongThucThanhToan GetByMaPhuongThucThanhToan(TransactionManager transactionManager, System.Int32 _maPhuongThucThanhToan, int start, int pageLength)
		{
			int count = -1;
			return GetByMaPhuongThucThanhToan(transactionManager, _maPhuongThucThanhToan, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPhuongThucThanhToan index.
		/// </summary>
		/// <param name="_maPhuongThucThanhToan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> class.</returns>
		public SkinCare.Entities.PhuongThucThanhToan GetByMaPhuongThucThanhToan(System.Int32 _maPhuongThucThanhToan, int start, int pageLength, out int count)
		{
			return GetByMaPhuongThucThanhToan(null, _maPhuongThucThanhToan, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblPhuongThucThanhToan index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maPhuongThucThanhToan"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> class.</returns>
		public abstract SkinCare.Entities.PhuongThucThanhToan GetByMaPhuongThucThanhToan(TransactionManager transactionManager, System.Int32 _maPhuongThucThanhToan, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;PhuongThucThanhToan&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;PhuongThucThanhToan&gt;"/></returns>
		public static TList<PhuongThucThanhToan> Fill(IDataReader reader, TList<PhuongThucThanhToan> rows, int start, int pageLength)
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
				
				SkinCare.Entities.PhuongThucThanhToan c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("PhuongThucThanhToan")
					.Append("|").Append((System.Int32)reader[((int)PhuongThucThanhToanColumn.MaPhuongThucThanhToan - 1)]).ToString();
					c = EntityManager.LocateOrCreate<PhuongThucThanhToan>(
					key.ToString(), // EntityTrackingKey
					"PhuongThucThanhToan",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.PhuongThucThanhToan();
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
					c.MaPhuongThucThanhToan = (System.Int32)reader[((int)PhuongThucThanhToanColumn.MaPhuongThucThanhToan - 1)];
					c.TenPhuongThucThanhToan = (reader.IsDBNull(((int)PhuongThucThanhToanColumn.TenPhuongThucThanhToan - 1)))?null:(System.String)reader[((int)PhuongThucThanhToanColumn.TenPhuongThucThanhToan - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.PhuongThucThanhToan"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.PhuongThucThanhToan entity)
		{
			if (!reader.Read()) return;
			
			entity.MaPhuongThucThanhToan = (System.Int32)reader[((int)PhuongThucThanhToanColumn.MaPhuongThucThanhToan - 1)];
			entity.TenPhuongThucThanhToan = (reader.IsDBNull(((int)PhuongThucThanhToanColumn.TenPhuongThucThanhToan - 1)))?null:(System.String)reader[((int)PhuongThucThanhToanColumn.TenPhuongThucThanhToan - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.PhuongThucThanhToan"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.PhuongThucThanhToan"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.PhuongThucThanhToan entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaPhuongThucThanhToan = (System.Int32)dataRow["MaPhuongThucThanhToan"];
			entity.TenPhuongThucThanhToan = Convert.IsDBNull(dataRow["TenPhuongThucThanhToan"]) ? null : (System.String)dataRow["TenPhuongThucThanhToan"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.PhuongThucThanhToan"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.PhuongThucThanhToan Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.PhuongThucThanhToan entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.PhuongThucThanhToan object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.PhuongThucThanhToan instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.PhuongThucThanhToan Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.PhuongThucThanhToan entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region PhuongThucThanhToanChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.PhuongThucThanhToan</c>
	///</summary>
	public enum PhuongThucThanhToanChildEntityTypes
	{
	}
	
	#endregion PhuongThucThanhToanChildEntityTypes
	
	#region PhuongThucThanhToanFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PhuongThucThanhToanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuongThucThanhToanFilterBuilder : SqlFilterBuilder<PhuongThucThanhToanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanFilterBuilder class.
		/// </summary>
		public PhuongThucThanhToanFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuongThucThanhToanFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuongThucThanhToanFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuongThucThanhToanFilterBuilder
	
	#region PhuongThucThanhToanParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PhuongThucThanhToanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PhuongThucThanhToanParameterBuilder : ParameterizedSqlFilterBuilder<PhuongThucThanhToanColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanParameterBuilder class.
		/// </summary>
		public PhuongThucThanhToanParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PhuongThucThanhToanParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PhuongThucThanhToanParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PhuongThucThanhToanParameterBuilder
	
	#region PhuongThucThanhToanSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PhuongThucThanhToanColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PhuongThucThanhToan"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PhuongThucThanhToanSortBuilder : SqlSortBuilder<PhuongThucThanhToanColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PhuongThucThanhToanSqlSortBuilder class.
		/// </summary>
		public PhuongThucThanhToanSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PhuongThucThanhToanSortBuilder
	
} // end namespace

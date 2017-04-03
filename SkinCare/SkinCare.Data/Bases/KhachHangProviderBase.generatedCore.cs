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
	/// This class is the base class for any <see cref="KhachHangProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class KhachHangProviderBaseCore : EntityProviderBase<SkinCare.Entities.KhachHang, SkinCare.Entities.KhachHangKey>
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
		public override bool Delete(TransactionManager transactionManager, SkinCare.Entities.KhachHangKey key)
		{
			return Delete(transactionManager, key.MaKhachHang);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_maKhachHang">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _maKhachHang)
		{
			return Delete(null, _maKhachHang);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhachHang">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _maKhachHang);		
		
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
		public override SkinCare.Entities.KhachHang Get(TransactionManager transactionManager, SkinCare.Entities.KhachHangKey key, int start, int pageLength)
		{
			return GetByMaKhachHang(transactionManager, key.MaKhachHang, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_tblKhachHang index.
		/// </summary>
		/// <param name="_maKhachHang"></param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhachHang"/> class.</returns>
		public SkinCare.Entities.KhachHang GetByMaKhachHang(System.Int32 _maKhachHang)
		{
			int count = -1;
			return GetByMaKhachHang(null,_maKhachHang, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhachHang index.
		/// </summary>
		/// <param name="_maKhachHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhachHang"/> class.</returns>
		public SkinCare.Entities.KhachHang GetByMaKhachHang(System.Int32 _maKhachHang, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhachHang(null, _maKhachHang, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhachHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhachHang"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhachHang"/> class.</returns>
		public SkinCare.Entities.KhachHang GetByMaKhachHang(TransactionManager transactionManager, System.Int32 _maKhachHang)
		{
			int count = -1;
			return GetByMaKhachHang(transactionManager, _maKhachHang, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhachHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhachHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhachHang"/> class.</returns>
		public SkinCare.Entities.KhachHang GetByMaKhachHang(TransactionManager transactionManager, System.Int32 _maKhachHang, int start, int pageLength)
		{
			int count = -1;
			return GetByMaKhachHang(transactionManager, _maKhachHang, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhachHang index.
		/// </summary>
		/// <param name="_maKhachHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhachHang"/> class.</returns>
		public SkinCare.Entities.KhachHang GetByMaKhachHang(System.Int32 _maKhachHang, int start, int pageLength, out int count)
		{
			return GetByMaKhachHang(null, _maKhachHang, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_tblKhachHang index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_maKhachHang"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SkinCare.Entities.KhachHang"/> class.</returns>
		public abstract SkinCare.Entities.KhachHang GetByMaKhachHang(TransactionManager transactionManager, System.Int32 _maKhachHang, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;KhachHang&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;KhachHang&gt;"/></returns>
		public static TList<KhachHang> Fill(IDataReader reader, TList<KhachHang> rows, int start, int pageLength)
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
				
				SkinCare.Entities.KhachHang c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("KhachHang")
					.Append("|").Append((System.Int32)reader[((int)KhachHangColumn.MaKhachHang - 1)]).ToString();
					c = EntityManager.LocateOrCreate<KhachHang>(
					key.ToString(), // EntityTrackingKey
					"KhachHang",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SkinCare.Entities.KhachHang();
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
					c.MaKhachHang = (System.Int32)reader[((int)KhachHangColumn.MaKhachHang - 1)];
					c.TenKhachHang = (reader.IsDBNull(((int)KhachHangColumn.TenKhachHang - 1)))?null:(System.String)reader[((int)KhachHangColumn.TenKhachHang - 1)];
					c.Email = (reader.IsDBNull(((int)KhachHangColumn.Email - 1)))?null:(System.String)reader[((int)KhachHangColumn.Email - 1)];
					c.SoDienThoai = (reader.IsDBNull(((int)KhachHangColumn.SoDienThoai - 1)))?null:(System.String)reader[((int)KhachHangColumn.SoDienThoai - 1)];
					c.DiaChi = (reader.IsDBNull(((int)KhachHangColumn.DiaChi - 1)))?null:(System.String)reader[((int)KhachHangColumn.DiaChi - 1)];
					c.GioiTinh = (reader.IsDBNull(((int)KhachHangColumn.GioiTinh - 1)))?null:(System.String)reader[((int)KhachHangColumn.GioiTinh - 1)];
					c.TayTrangToi = (reader.IsDBNull(((int)KhachHangColumn.TayTrangToi - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.TayTrangToi - 1)];
					c.RuaMat = (reader.IsDBNull(((int)KhachHangColumn.RuaMat - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.RuaMat - 1)];
					c.Toner = (reader.IsDBNull(((int)KhachHangColumn.Toner - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.Toner - 1)];
					c.Serum = (reader.IsDBNull(((int)KhachHangColumn.Serum - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.Serum - 1)];
					c.Kem = (reader.IsDBNull(((int)KhachHangColumn.Kem - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.Kem - 1)];
					c.SanPhamKhac = (reader.IsDBNull(((int)KhachHangColumn.SanPhamKhac - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.SanPhamKhac - 1)];
					c.Luuy = (reader.IsDBNull(((int)KhachHangColumn.Luuy - 1)))?null:(System.String)reader[((int)KhachHangColumn.Luuy - 1)];
					c.ImageLink = (reader.IsDBNull(((int)KhachHangColumn.ImageLink - 1)))?null:(System.String)reader[((int)KhachHangColumn.ImageLink - 1)];
					c.Ngaysinh = (reader.IsDBNull(((int)KhachHangColumn.Ngaysinh - 1)))?null:(System.DateTime?)reader[((int)KhachHangColumn.Ngaysinh - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.KhachHang"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.KhachHang"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SkinCare.Entities.KhachHang entity)
		{
			if (!reader.Read()) return;
			
			entity.MaKhachHang = (System.Int32)reader[((int)KhachHangColumn.MaKhachHang - 1)];
			entity.TenKhachHang = (reader.IsDBNull(((int)KhachHangColumn.TenKhachHang - 1)))?null:(System.String)reader[((int)KhachHangColumn.TenKhachHang - 1)];
			entity.Email = (reader.IsDBNull(((int)KhachHangColumn.Email - 1)))?null:(System.String)reader[((int)KhachHangColumn.Email - 1)];
			entity.SoDienThoai = (reader.IsDBNull(((int)KhachHangColumn.SoDienThoai - 1)))?null:(System.String)reader[((int)KhachHangColumn.SoDienThoai - 1)];
			entity.DiaChi = (reader.IsDBNull(((int)KhachHangColumn.DiaChi - 1)))?null:(System.String)reader[((int)KhachHangColumn.DiaChi - 1)];
			entity.GioiTinh = (reader.IsDBNull(((int)KhachHangColumn.GioiTinh - 1)))?null:(System.String)reader[((int)KhachHangColumn.GioiTinh - 1)];
			entity.TayTrangToi = (reader.IsDBNull(((int)KhachHangColumn.TayTrangToi - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.TayTrangToi - 1)];
			entity.RuaMat = (reader.IsDBNull(((int)KhachHangColumn.RuaMat - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.RuaMat - 1)];
			entity.Toner = (reader.IsDBNull(((int)KhachHangColumn.Toner - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.Toner - 1)];
			entity.Serum = (reader.IsDBNull(((int)KhachHangColumn.Serum - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.Serum - 1)];
			entity.Kem = (reader.IsDBNull(((int)KhachHangColumn.Kem - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.Kem - 1)];
			entity.SanPhamKhac = (reader.IsDBNull(((int)KhachHangColumn.SanPhamKhac - 1)))?null:(System.Boolean?)reader[((int)KhachHangColumn.SanPhamKhac - 1)];
			entity.Luuy = (reader.IsDBNull(((int)KhachHangColumn.Luuy - 1)))?null:(System.String)reader[((int)KhachHangColumn.Luuy - 1)];
			entity.ImageLink = (reader.IsDBNull(((int)KhachHangColumn.ImageLink - 1)))?null:(System.String)reader[((int)KhachHangColumn.ImageLink - 1)];
			entity.Ngaysinh = (reader.IsDBNull(((int)KhachHangColumn.Ngaysinh - 1)))?null:(System.DateTime?)reader[((int)KhachHangColumn.Ngaysinh - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SkinCare.Entities.KhachHang"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SkinCare.Entities.KhachHang"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SkinCare.Entities.KhachHang entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MaKhachHang = (System.Int32)dataRow["MaKhachHang"];
			entity.TenKhachHang = Convert.IsDBNull(dataRow["TenKhachHang"]) ? null : (System.String)dataRow["TenKhachHang"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.SoDienThoai = Convert.IsDBNull(dataRow["SoDienThoai"]) ? null : (System.String)dataRow["SoDienThoai"];
			entity.DiaChi = Convert.IsDBNull(dataRow["DiaChi"]) ? null : (System.String)dataRow["DiaChi"];
			entity.GioiTinh = Convert.IsDBNull(dataRow["GioiTinh"]) ? null : (System.String)dataRow["GioiTinh"];
			entity.TayTrangToi = Convert.IsDBNull(dataRow["TayTrangToi"]) ? null : (System.Boolean?)dataRow["TayTrangToi"];
			entity.RuaMat = Convert.IsDBNull(dataRow["RuaMat"]) ? null : (System.Boolean?)dataRow["RuaMat"];
			entity.Toner = Convert.IsDBNull(dataRow["Toner"]) ? null : (System.Boolean?)dataRow["Toner"];
			entity.Serum = Convert.IsDBNull(dataRow["Serum"]) ? null : (System.Boolean?)dataRow["Serum"];
			entity.Kem = Convert.IsDBNull(dataRow["Kem"]) ? null : (System.Boolean?)dataRow["Kem"];
			entity.SanPhamKhac = Convert.IsDBNull(dataRow["SanPhamKhac"]) ? null : (System.Boolean?)dataRow["SanPhamKhac"];
			entity.Luuy = Convert.IsDBNull(dataRow["LuuY"]) ? null : (System.String)dataRow["LuuY"];
			entity.ImageLink = Convert.IsDBNull(dataRow["ImageLink"]) ? null : (System.String)dataRow["ImageLink"];
			entity.Ngaysinh = Convert.IsDBNull(dataRow["Ngaysinh"]) ? null : (System.DateTime?)dataRow["Ngaysinh"];
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
		/// <param name="entity">The <see cref="SkinCare.Entities.KhachHang"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SkinCare.Entities.KhachHang Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, SkinCare.Entities.KhachHang entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the SkinCare.Entities.KhachHang object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SkinCare.Entities.KhachHang instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SkinCare.Entities.KhachHang Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, SkinCare.Entities.KhachHang entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region KhachHangChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SkinCare.Entities.KhachHang</c>
	///</summary>
	public enum KhachHangChildEntityTypes
	{
	}
	
	#endregion KhachHangChildEntityTypes
	
	#region KhachHangFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;KhachHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhachHangFilterBuilder : SqlFilterBuilder<KhachHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhachHangFilterBuilder class.
		/// </summary>
		public KhachHangFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhachHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhachHangFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhachHangFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhachHangFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhachHangFilterBuilder
	
	#region KhachHangParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;KhachHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KhachHangParameterBuilder : ParameterizedSqlFilterBuilder<KhachHangColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhachHangParameterBuilder class.
		/// </summary>
		public KhachHangParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the KhachHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KhachHangParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KhachHangParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KhachHangParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KhachHangParameterBuilder
	
	#region KhachHangSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;KhachHangColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KhachHang"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class KhachHangSortBuilder : SqlSortBuilder<KhachHangColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KhachHangSqlSortBuilder class.
		/// </summary>
		public KhachHangSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion KhachHangSortBuilder
	
} // end namespace

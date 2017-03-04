#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using SkinCare.Entities;
using SkinCare.Data;

#endregion

namespace SkinCare.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="DonHangChiTiet"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlDonHangChiTietProvider: SqlDonHangChiTietProviderBase
	{
		/// <summary>
		/// Creates a new <see cref="SqlDonHangChiTietProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
		/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
		public SqlDonHangChiTietProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}
	}
}
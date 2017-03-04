﻿using System;
using System.ComponentModel;

namespace SkinCare.Entities
{
	/// <summary>
	///		The data structure representation of the 'tblNguonDonHang' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface INguonDonHang 
	{
		/// <summary>			
		/// MaNguonDonHang : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblNguonDonHang"</remarks>
		System.Int32 MaNguonDonHang { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalMaNguonDonHang { get; set; }
			
		
		
		/// <summary>
		/// TenNguonDonHang : 
		/// </summary>
		System.String  TenNguonDonHang  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}



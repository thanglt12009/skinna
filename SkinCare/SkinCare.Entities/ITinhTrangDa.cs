﻿using System;
using System.ComponentModel;

namespace SkinCare.Entities
{
	/// <summary>
	///		The data structure representation of the 'tblTinhTrangDa' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ITinhTrangDa 
	{
		/// <summary>			
		/// ID : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblTinhTrangDa"</remarks>
		System.Int32 Id { get; set; }
				
		
		
		/// <summary>
		/// MaKhachHang : 
		/// </summary>
		System.Int32?  MaKhachHang  { get; set; }
		
		/// <summary>
		/// Ngay : 
		/// </summary>
		System.DateTime?  Ngay  { get; set; }
		
		/// <summary>
		/// TinhTrang : 
		/// </summary>
		System.String  TinhTrang  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}



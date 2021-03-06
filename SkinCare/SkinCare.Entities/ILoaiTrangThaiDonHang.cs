﻿using System;
using System.ComponentModel;

namespace SkinCare.Entities
{
	/// <summary>
	///		The data structure representation of the 'tblLoaiTrangThaiDonHang' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ILoaiTrangThaiDonHang 
	{
		/// <summary>			
		/// MaLoaiTrangThai : --------------- SAU KHI GIAO HANG -------------------------or--------------- KHOI TAO -------------------------or--------------- XU LY -------------------------
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblLoaiTrangThaiDonHang"</remarks>
		System.Int32 MaLoaiTrangThai { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalMaLoaiTrangThai { get; set; }
			
		
		
		/// <summary>
		/// TenLoaiTrangThai : 
		/// </summary>
		System.String  TenLoaiTrangThai  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}



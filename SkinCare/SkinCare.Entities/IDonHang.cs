﻿using System;
using System.ComponentModel;

namespace SkinCare.Entities
{
	/// <summary>
	///		The data structure representation of the 'tblDonHang' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IDonHang 
	{
		/// <summary>			
		/// MaDonHang : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tblDonHang"</remarks>
		System.Int32 MaDonHang { get; set; }
				
		
		
		/// <summary>
		/// MaKhachHang : 
		/// </summary>
		System.Int32?  MaKhachHang  { get; set; }
		
		/// <summary>
		/// MaNguonDonHang : 
		/// </summary>
		System.Int32?  MaNguonDonHang  { get; set; }
		
		/// <summary>
		/// MaTrangThaiDonHang : 
		/// </summary>
		System.Int32?  MaTrangThaiDonHang  { get; set; }
		
		/// <summary>
		/// NguoiDatHang : 
		/// </summary>
		System.String  NguoiDatHang  { get; set; }
		
		/// <summary>
		/// MaPhuongThucThanhToan : 
		/// </summary>
		System.Int32?  MaPhuongThucThanhToan  { get; set; }
		
		/// <summary>
		/// CachThucNhanHang : 
		/// </summary>
		System.String  CachThucNhanHang  { get; set; }
		
		/// <summary>
		/// PhiVanChuyen : 
		/// </summary>
		System.Decimal?  PhiVanChuyen  { get; set; }
		
		/// <summary>
		/// TongTienDonHang : 
		/// </summary>
		System.Decimal?  TongTienDonHang  { get; set; }
		
		/// <summary>
		/// NgayTaoDonHang : 
		/// </summary>
		System.DateTime?  NgayTaoDonHang  { get; set; }
		
		/// <summary>
		/// MaKhuyenMai : 
		/// </summary>
		System.String  MaKhuyenMai  { get; set; }
		
		/// <summary>
		/// MaVoucher : 
		/// </summary>
		System.String  MaVoucher  { get; set; }
		
		/// <summary>
		/// GhiChu : 
		/// </summary>
		System.String  GhiChu  { get; set; }
		
		/// <summary>
		/// TienChietKhau : 
		/// </summary>
		System.Decimal?  TienChietKhau  { get; set; }
		
		/// <summary>
		/// TiLeChietKhau : 
		/// </summary>
		System.Double?  TiLeChietKhau  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using SkinCare.Entities;

#endregion

namespace SkinCare.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current NguonDonHangProviderBase instance.
		///</summary>
		public virtual NguonDonHangProviderBase NguonDonHangProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DonHangProviderBase instance.
		///</summary>
		public virtual DonHangProviderBase DonHangProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PhuongThucThanhToanProviderBase instance.
		///</summary>
		public virtual PhuongThucThanhToanProviderBase PhuongThucThanhToanProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LoaiTrangThaiDonHangProviderBase instance.
		///</summary>
		public virtual LoaiTrangThaiDonHangProviderBase LoaiTrangThaiDonHangProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TrangThaiDonHangProviderBase instance.
		///</summary>
		public virtual TrangThaiDonHangProviderBase TrangThaiDonHangProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DonHangChiTietProviderBase instance.
		///</summary>
		public virtual DonHangChiTietProviderBase DonHangChiTietProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current KhuyenMaiProviderBase instance.
		///</summary>
		public virtual KhuyenMaiProviderBase KhuyenMaiProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current KhachHangProviderBase instance.
		///</summary>
		public virtual KhachHangProviderBase KhachHangProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserProviderBase instance.
		///</summary>
		public virtual UserProviderBase UserProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current KhoHangSanPhamProviderBase instance.
		///</summary>
		public virtual KhoHangSanPhamProviderBase KhoHangSanPhamProvider{get {throw new NotImplementedException();}}
		
		
	}
}

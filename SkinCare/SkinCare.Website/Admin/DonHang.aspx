<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DonHang.aspx.cs" Inherits="DonHang" Title="DonHang List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Don Hang List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DonHangDataSource"
				DataKeyNames="MaDonHang"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DonHang.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaKhachHang" HeaderText="Ma Khach Hang" SortExpression="[MaKhachHang]"  />
				<asp:BoundField DataField="MaNguonDonHang" HeaderText="Ma Nguon Don Hang" SortExpression="[MaNguonDonHang]"  />
				<asp:BoundField DataField="MaTrangThaiDonHang" HeaderText="Ma Trang Thai Don Hang" SortExpression="[MaTrangThaiDonHang]"  />
				<asp:BoundField DataField="NguoiDatHang" HeaderText="Nguoi Dat Hang" SortExpression="[NguoiDatHang]"  />
				<asp:BoundField DataField="MaPhuongThucThanhToan" HeaderText="Ma Phuong Thuc Thanh Toan" SortExpression="[MaPhuongThucThanhToan]"  />
				<asp:BoundField DataField="CachThucNhanHang" HeaderText="Cach Thuc Nhan Hang" SortExpression="[CachThucNhanHang]"  />
				<asp:BoundField DataField="PhiVanChuyen" HeaderText="Phi Van Chuyen" SortExpression="[PhiVanChuyen]"  />
				<asp:BoundField DataField="TongTienDonHang" HeaderText="Tong Tien Don Hang" SortExpression="[TongTienDonHang]"  />
				<asp:BoundField DataField="NgayTaoDonHang" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Tao Don Hang" SortExpression="[NgayTaoDonHang]"  />
				<asp:BoundField DataField="MaKhuyenMai" HeaderText="Ma Khuyen Mai" SortExpression="[MaKhuyenMai]"  />
				<asp:BoundField DataField="MaVoucher" HeaderText="Ma Voucher" SortExpression="[MaVoucher]"  />
				<asp:BoundField DataField="GhiChu" HeaderText="Ghi Chu" SortExpression="[GhiChu]"  />
				<asp:BoundField DataField="TienChietKhau" HeaderText="Tien Chiet Khau" SortExpression="[TienChietKhau]"  />
				<asp:BoundField DataField="TiLeChietKhau" HeaderText="Ti Le Chiet Khau" SortExpression="[TiLeChietKhau]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DonHang Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDonHang" OnClientClick="javascript:location.href='DonHangEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DonHangDataSource ID="DonHangDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DonHangDataSource>
	    		
</asp:Content>




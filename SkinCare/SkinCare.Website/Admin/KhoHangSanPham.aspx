<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="KhoHangSanPham.aspx.cs" Inherits="KhoHangSanPham" Title="KhoHangSanPham List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Kho Hang San Pham List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="KhoHangSanPhamDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_KhoHangSanPham.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaSanPham" HeaderText="Ma San Pham" SortExpression="[MaSanPham]"  />
				<asp:BoundField DataField="TenSanPham" HeaderText="Ten San Pham" SortExpression="[TenSanPham]"  />
				<asp:BoundField DataField="SoLuongNhapVao" HeaderText="So Luong Nhap Vao" SortExpression="[SoLuongNhapVao]"  />
				<asp:BoundField DataField="SoLuongBanRa" HeaderText="So Luong Ban Ra" SortExpression="[SoLuongBanRa]"  />
				<asp:BoundField DataField="SoLuongTonKho" HeaderText="So Luong Ton Kho" SortExpression="[SoLuongTonKho]"  />
				<asp:BoundField DataField="NgayNhapHang" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Nhap Hang" SortExpression="[NgayNhapHang]"  />
				<asp:BoundField DataField="GhiChu" HeaderText="Ghi Chu" SortExpression="[GhiChu]"  />
				<asp:BoundField DataField="GiaTien" HeaderText="Gia Tien" SortExpression="[GiaTien]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No KhoHangSanPham Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnKhoHangSanPham" OnClientClick="javascript:location.href='KhoHangSanPhamEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:KhoHangSanPhamDataSource ID="KhoHangSanPhamDataSource" runat="server"
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
		</data:KhoHangSanPhamDataSource>
	    		
</asp:Content>




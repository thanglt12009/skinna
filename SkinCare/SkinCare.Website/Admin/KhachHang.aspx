﻿<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="KhachHang.aspx.cs" Inherits="KhachHang" Title="KhachHang List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Khach Hang List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="KhachHangDataSource"
				DataKeyNames="MaKhachHang"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_KhachHang.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="TenKhachHang" HeaderText="Ten Khach Hang" SortExpression="[TenKhachHang]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="SoDienThoai" HeaderText="So Dien Thoai" SortExpression="[SoDienThoai]"  />
				<asp:BoundField DataField="DiaChi" HeaderText="Dia Chi" SortExpression="[DiaChi]"  />
				<asp:BoundField DataField="Tuoi" HeaderText="Tuoi" SortExpression="[Tuoi]"  />
				<asp:BoundField DataField="GioiTinh" HeaderText="Gioi Tinh" SortExpression="[GioiTinh]"  />
				<asp:BoundField DataField="TinhTrangDa" HeaderText="Tinh Trang Da" SortExpression="[TinhTrangDa]"  />
				<data:BoundRadioButtonField DataField="TayTrangToi" HeaderText="Tay Trang Toi" SortExpression="[TayTrangToi]"  />
				<data:BoundRadioButtonField DataField="RuaMat" HeaderText="Rua Mat" SortExpression="[RuaMat]"  />
				<data:BoundRadioButtonField DataField="Toner" HeaderText="Toner" SortExpression="[Toner]"  />
				<data:BoundRadioButtonField DataField="Serum" HeaderText="Serum" SortExpression="[Serum]"  />
				<data:BoundRadioButtonField DataField="Kem" HeaderText="Kem" SortExpression="[Kem]"  />
				<data:BoundRadioButtonField DataField="SanPhamKhac" HeaderText="San Pham Khac" SortExpression="[SanPhamKhac]"  />
				<asp:BoundField DataField="Luuy" HeaderText="Luuy" SortExpression="[LuuY]"  />
				<asp:BoundField DataField="ImageLink" HeaderText="Image Link" SortExpression="[ImageLink]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No KhachHang Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnKhachHang" OnClientClick="javascript:location.href='KhachHangEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:KhachHangDataSource ID="KhachHangDataSource" runat="server"
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
		</data:KhachHangDataSource>
	    		
</asp:Content>




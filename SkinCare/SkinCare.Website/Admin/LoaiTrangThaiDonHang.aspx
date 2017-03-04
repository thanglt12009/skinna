<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LoaiTrangThaiDonHang.aspx.cs" Inherits="LoaiTrangThaiDonHang" Title="LoaiTrangThaiDonHang List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Loai Trang Thai Don Hang List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LoaiTrangThaiDonHangDataSource"
				DataKeyNames="MaLoaiTrangThai"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_LoaiTrangThaiDonHang.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaLoaiTrangThai" HeaderText="Ma Loai Trang Thai" SortExpression="[MaLoaiTrangThai]" ReadOnly="True" />
				<asp:BoundField DataField="TenLoaiTrangThai" HeaderText="Ten Loai Trang Thai" SortExpression="[TenLoaiTrangThai]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No LoaiTrangThaiDonHang Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLoaiTrangThaiDonHang" OnClientClick="javascript:location.href='LoaiTrangThaiDonHangEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LoaiTrangThaiDonHangDataSource ID="LoaiTrangThaiDonHangDataSource" runat="server"
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
		</data:LoaiTrangThaiDonHangDataSource>
	    		
</asp:Content>




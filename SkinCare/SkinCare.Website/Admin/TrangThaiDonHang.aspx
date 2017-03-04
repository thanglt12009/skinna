<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TrangThaiDonHang.aspx.cs" Inherits="TrangThaiDonHang" Title="TrangThaiDonHang List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Trang Thai Don Hang List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TrangThaiDonHangDataSource"
				DataKeyNames="MaTrangThaiDonHang"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TrangThaiDonHang.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaTrangThaiDonHang" HeaderText="Ma Trang Thai Don Hang" SortExpression="[MaTrangThaiDonHang]" ReadOnly="True" />
				<asp:BoundField DataField="MaLoaiTrangThaiDonHang" HeaderText="Ma Loai Trang Thai Don Hang" SortExpression="[MaLoaiTrangThaiDonHang]"  />
				<asp:BoundField DataField="TenLoaiTrangThaiDonHang" HeaderText="Ten Loai Trang Thai Don Hang" SortExpression="[TenLoaiTrangThaiDonHang]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TrangThaiDonHang Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTrangThaiDonHang" OnClientClick="javascript:location.href='TrangThaiDonHangEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:TrangThaiDonHangDataSource ID="TrangThaiDonHangDataSource" runat="server"
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
		</data:TrangThaiDonHangDataSource>
	    		
</asp:Content>




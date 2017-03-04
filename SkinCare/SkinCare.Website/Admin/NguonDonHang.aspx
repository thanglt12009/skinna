<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="NguonDonHang.aspx.cs" Inherits="NguonDonHang" Title="NguonDonHang List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Nguon Don Hang List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="NguonDonHangDataSource"
				DataKeyNames="MaNguonDonHang"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_NguonDonHang.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaNguonDonHang" HeaderText="Ma Nguon Don Hang" SortExpression="[MaNguonDonHang]" ReadOnly="True" />
				<asp:BoundField DataField="TenNguonDonHang" HeaderText="Ten Nguon Don Hang" SortExpression="[TenNguonDonHang]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No NguonDonHang Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnNguonDonHang" OnClientClick="javascript:location.href='NguonDonHangEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:NguonDonHangDataSource ID="NguonDonHangDataSource" runat="server"
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
		</data:NguonDonHangDataSource>
	    		
</asp:Content>




<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PhuongThucThanhToan.aspx.cs" Inherits="PhuongThucThanhToan" Title="PhuongThucThanhToan List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Phuong Thuc Thanh Toan List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="PhuongThucThanhToanDataSource"
				DataKeyNames="MaPhuongThucThanhToan"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_PhuongThucThanhToan.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="TenPhuongThucThanhToan" HeaderText="Ten Phuong Thuc Thanh Toan" SortExpression="[TenPhuongThucThanhToan]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No PhuongThucThanhToan Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnPhuongThucThanhToan" OnClientClick="javascript:location.href='PhuongThucThanhToanEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:PhuongThucThanhToanDataSource ID="PhuongThucThanhToanDataSource" runat="server"
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
		</data:PhuongThucThanhToanDataSource>
	    		
</asp:Content>




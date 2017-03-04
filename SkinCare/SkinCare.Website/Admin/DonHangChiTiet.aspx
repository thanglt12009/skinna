<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DonHangChiTiet.aspx.cs" Inherits="DonHangChiTiet" Title="DonHangChiTiet List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Don Hang Chi Tiet List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DonHangChiTietDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_DonHangChiTiet.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaDonHang" HeaderText="Ma Don Hang" SortExpression="[MaDonHang]"  />
				<asp:BoundField DataField="MaSanPham" HeaderText="Ma San Pham" SortExpression="[MaSanPham]"  />
				<asp:BoundField DataField="DonGia" HeaderText="Don Gia" SortExpression="[DonGia]"  />
				<asp:BoundField DataField="SoLuong" HeaderText="So Luong" SortExpression="[SoLuong]"  />
				<asp:BoundField DataField="ThanhTien" HeaderText="Thanh Tien" SortExpression="[ThanhTien]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No DonHangChiTiet Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDonHangChiTiet" OnClientClick="javascript:location.href='DonHangChiTietEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:DonHangChiTietDataSource ID="DonHangChiTietDataSource" runat="server"
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
		</data:DonHangChiTietDataSource>
	    		
</asp:Content>




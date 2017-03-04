<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="KhuyenMai.aspx.cs" Inherits="KhuyenMai" Title="KhuyenMai List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Khuyen Mai List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="KhuyenMaiDataSource"
				DataKeyNames="MaKhuyenMai"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_KhuyenMai.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaKhuyenMai" HeaderText="Ma Khuyen Mai" SortExpression="[MaKhuyenMai]" ReadOnly="True" />
				<asp:BoundField DataField="MaLoaiKhuyenMai" HeaderText="Ma Loai Khuyen Mai" SortExpression="[MaLoaiKhuyenMai]"  />
				<asp:BoundField DataField="TenKhuyenMai" HeaderText="Ten Khuyen Mai" SortExpression="[TenKhuyenMai]"  />
				<asp:BoundField DataField="GiaGiam" HeaderText="Gia Giam" SortExpression="[GiaGiam]"  />
				<asp:BoundField DataField="NgayTaoKhuyenMai" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Tao Khuyen Mai" SortExpression="[NgayTaoKhuyenMai]"  />
				<asp:BoundField DataField="NgayBatDauKhuyenMai" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Bat Dau Khuyen Mai" SortExpression="[NgayBatDauKhuyenMai]"  />
				<asp:BoundField DataField="NgayKetThucKhuyenMai" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay Ket Thuc Khuyen Mai" SortExpression="[NgayKetThucKhuyenMai]"  />
				<data:BoundRadioButtonField DataField="Active" HeaderText="Active" SortExpression="[Active]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No KhuyenMai Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnKhuyenMai" OnClientClick="javascript:location.href='KhuyenMaiEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:KhuyenMaiDataSource ID="KhuyenMaiDataSource" runat="server"
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
		</data:KhuyenMaiDataSource>
	    		
</asp:Content>




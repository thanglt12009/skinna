<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LieuTrinh.aspx.cs" Inherits="LieuTrinh" Title="LieuTrinh List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lieu Trinh List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="LieuTrinhDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_LieuTrinh.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MaKhachHang" HeaderText="Ma Khach Hang" SortExpression="[MaKhachHang]"  />
				<asp:BoundField DataField="Ngay" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Ngay" SortExpression="[Ngay]"  />
				<asp:BoundField DataField="TayTrangToi" HeaderText="Tay Trang Toi" SortExpression="[TayTrangToi]"  />
				<asp:BoundField DataField="RuaMat" HeaderText="Rua Mat" SortExpression="[RuaMat]"  />
				<asp:BoundField DataField="Toner" HeaderText="Toner" SortExpression="[Toner]"  />
				<asp:BoundField DataField="Serum" HeaderText="Serum" SortExpression="[Serum]"  />
				<asp:BoundField DataField="Kem" HeaderText="Kem" SortExpression="[Kem]"  />
				<asp:BoundField DataField="SanPhamKhac" HeaderText="San Pham Khac" SortExpression="[SanPhamKhac]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No LieuTrinh Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnLieuTrinh" OnClientClick="javascript:location.href='LieuTrinhEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:LieuTrinhDataSource ID="LieuTrinhDataSource" runat="server"
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
		</data:LieuTrinhDataSource>
	    		
</asp:Content>




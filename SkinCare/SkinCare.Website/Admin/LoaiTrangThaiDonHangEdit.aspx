<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LoaiTrangThaiDonHangEdit.aspx.cs" Inherits="LoaiTrangThaiDonHangEdit" Title="LoaiTrangThaiDonHang Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Loai Trang Thai Don Hang - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="MaLoaiTrangThai" runat="server" DataSourceID="LoaiTrangThaiDonHangDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LoaiTrangThaiDonHangFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LoaiTrangThaiDonHangFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>LoaiTrangThaiDonHang not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LoaiTrangThaiDonHangDataSource ID="LoaiTrangThaiDonHangDataSource" runat="server"
			SelectMethod="GetByMaLoaiTrangThai"
		>
			<Parameters>
				<asp:QueryStringParameter Name="MaLoaiTrangThai" QueryStringField="MaLoaiTrangThai" Type="String" />

			</Parameters>
		</data:LoaiTrangThaiDonHangDataSource>
		
		<br />

		

</asp:Content>


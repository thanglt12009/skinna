<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="KhuyenMaiEdit.aspx.cs" Inherits="KhuyenMaiEdit" Title="KhuyenMai Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Khuyen Mai - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="MaKhuyenMai" runat="server" DataSourceID="KhuyenMaiDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/KhuyenMaiFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/KhuyenMaiFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>KhuyenMai not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:KhuyenMaiDataSource ID="KhuyenMaiDataSource" runat="server"
			SelectMethod="GetByMaKhuyenMai"
		>
			<Parameters>
				<asp:QueryStringParameter Name="MaKhuyenMai" QueryStringField="MaKhuyenMai" Type="String" />

			</Parameters>
		</data:KhuyenMaiDataSource>
		
		<br />

		

</asp:Content>


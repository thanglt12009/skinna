<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="NguonDonHangEdit.aspx.cs" Inherits="NguonDonHangEdit" Title="NguonDonHang Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Nguon Don Hang - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="MaNguonDonHang" runat="server" DataSourceID="NguonDonHangDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/NguonDonHangFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/NguonDonHangFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>NguonDonHang not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:NguonDonHangDataSource ID="NguonDonHangDataSource" runat="server"
			SelectMethod="GetByMaNguonDonHang"
		>
			<Parameters>
				<asp:QueryStringParameter Name="MaNguonDonHang" QueryStringField="MaNguonDonHang" Type="String" />

			</Parameters>
		</data:NguonDonHangDataSource>
		
		<br />

		

</asp:Content>


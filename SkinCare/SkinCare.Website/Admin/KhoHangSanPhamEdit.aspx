﻿<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="KhoHangSanPhamEdit.aspx.cs" Inherits="KhoHangSanPhamEdit" Title="KhoHangSanPham Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Kho Hang San Pham - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="MaSanPham" runat="server" DataSourceID="KhoHangSanPhamDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/KhoHangSanPhamFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/KhoHangSanPhamFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>KhoHangSanPham not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:KhoHangSanPhamDataSource ID="KhoHangSanPhamDataSource" runat="server"
			SelectMethod="GetByMaSanPham"
		>
			<Parameters>
				<asp:QueryStringParameter Name="MaSanPham" QueryStringField="MaSanPham" Type="String" />

			</Parameters>
		</data:KhoHangSanPhamDataSource>
		
		<br />

		

</asp:Content>

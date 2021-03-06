﻿<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TrangThaiDonHangEdit.aspx.cs" Inherits="TrangThaiDonHangEdit" Title="TrangThaiDonHang Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Trang Thai Don Hang - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="MaTrangThaiDonHang" runat="server" DataSourceID="TrangThaiDonHangDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TrangThaiDonHangFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TrangThaiDonHangFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>TrangThaiDonHang not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:TrangThaiDonHangDataSource ID="TrangThaiDonHangDataSource" runat="server"
			SelectMethod="GetByMaTrangThaiDonHang"
		>
			<Parameters>
				<asp:QueryStringParameter Name="MaTrangThaiDonHang" QueryStringField="MaTrangThaiDonHang" Type="String" />

			</Parameters>
		</data:TrangThaiDonHangDataSource>
		
		<br />

		

</asp:Content>


<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PhuongThucThanhToanEdit.aspx.cs" Inherits="PhuongThucThanhToanEdit" Title="PhuongThucThanhToan Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Phuong Thuc Thanh Toan - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="MaPhuongThucThanhToan" runat="server" DataSourceID="PhuongThucThanhToanDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PhuongThucThanhToanFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PhuongThucThanhToanFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>PhuongThucThanhToan not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:PhuongThucThanhToanDataSource ID="PhuongThucThanhToanDataSource" runat="server"
			SelectMethod="GetByMaPhuongThucThanhToan"
		>
			<Parameters>
				<asp:QueryStringParameter Name="MaPhuongThucThanhToan" QueryStringField="MaPhuongThucThanhToan" Type="String" />

			</Parameters>
		</data:PhuongThucThanhToanDataSource>
		
		<br />

		

</asp:Content>


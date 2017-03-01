<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SanPhamDaMua.ascx.cs" Inherits="SkinnaManagement.UserControl.SanPhamDaMua" %>
 <label>Các sản phẩm đã mua trong 3 tháng gần nhất</label>
<asp:Panel ID="Panel1" runat="server">
    <asp:GridView ID="SanPhamList" runat="server"></asp:GridView>
</asp:Panel>
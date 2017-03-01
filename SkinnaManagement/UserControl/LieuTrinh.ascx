<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LieuTrinh.ascx.cs" Inherits="SkinnaManagement.UserControl.LieuTrinh" %>
 <label>Liệu trình khách đang dùng</label>
<asp:Panel ID="Panel1" runat="server">
     <asp:CheckBox id="TayTrangToi" runat="server" Text="Tẩy trang tối"></asp:CheckBox> <br />
     <asp:CheckBox id="RuaMat" runat="server" Text="Rửa mặt"></asp:CheckBox><br />
     <asp:CheckBox id="Toner" runat="server" Text="Toner"></asp:CheckBox><br />
     <asp:CheckBox id="Serum" runat="server" Text="Serum"></asp:CheckBox><br />
    <asp:CheckBox id="Kem" runat="server" Text="Kem"></asp:CheckBox><br />
    <asp:CheckBox id="Others" runat="server" Text="Sản phẩm khác"></asp:CheckBox>
</asp:Panel>

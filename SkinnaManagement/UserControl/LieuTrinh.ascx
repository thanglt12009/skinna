<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LieuTrinh.ascx.cs" Inherits="SkinnaManagement.UserControl.LieuTrinh" %>
 <label>Liệu trình khách đang dùng</label>
<asp:Panel ID="Panel1" runat="server">
     <asp:CheckBox id="cbTayTrangToi" runat="server" Text="Tẩy trang tối"></asp:CheckBox> <br />
     <asp:CheckBox id="cbRuaMat" runat="server" Text="Rửa mặt"></asp:CheckBox><br />
     <asp:CheckBox id="cbToner" runat="server" Text="Toner"></asp:CheckBox><br />
     <asp:CheckBox id="cbSerum" runat="server" Text="Serum"></asp:CheckBox><br />
    <asp:CheckBox id="cbKem" runat="server" Text="Kem"></asp:CheckBox><br />
    <asp:CheckBox id="cbOthers" runat="server" Text="Sản phẩm khác"></asp:CheckBox>
</asp:Panel>

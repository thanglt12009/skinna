<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SanPhamDaMua.ascx.cs" Inherits="SkinnaManagement.UserControl.SanPhamDaMua" %>
<label id="lb1" runat="server">Các sản phẩm đã mua trong 3 tháng gần nhất</label>
<asp:Panel ID="Panel1" runat="server">
    <asp:GridView ID="gvSanPhamList" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="MaSanPham" HeaderText="Mã sản phẩm" />
            <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TenSanPham" HeaderText="Tên sản phẩm" />
        </Columns>
    </asp:GridView>
</asp:Panel>

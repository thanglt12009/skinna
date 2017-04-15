<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SanPhamDaMua.ascx.cs" Inherits="SkinnaManagement.UserControl.SanPhamDaMua" %>
<link rel="stylesheet" href="/css/jquery-ui.css" />
<script type="text/javascript">
    function ShowDialog() {
        SanPham_InitDialogs()
        $('#dlgXemTatca').dialog("open");
    }
    function SanPham_InitDialogs() {
        $('#dlgXemTatca').dialog({
            autoOpen: false,
            "width": 710,
            "modal": true,
            position: {
                at: "top top"
            },
            shadow: true,
            show: {
                duration: 1000
            },
            hide: {
                duration: 1000
            }
        });
    }
</script>
<label id="lb1" runat="server">Các sản phẩm đã mua trong 3 tháng gần nhất</label>
<div id="dlgXemTatca" title="Tất cả sản phẩm đã mua" runat="server" clientidmode="Static">
        <asp:GridView ID="gvAllSanPham" AllowPaging="true" OnPageIndexChanging="gvAllSanPham_PageIndexChanging" PageSize="3" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="SoThuTu" HeaderText="STT" />
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="MaSanPham" HeaderText="Mã sản phẩm" />
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="NgayMua" HeaderText="Ngày mua" />
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="TenSanPham" HeaderText="Tên sản phẩm" />
            </Columns>
            <HeaderStyle HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
<asp:Panel ID="Panel1" runat="server">
    <table class="table">
        <tr>
            <td>
                <asp:GridView ID="gvSanPhamList" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="MaSanPham" HeaderText="Mã sản phẩm" />
                        <asp:BoundField ItemStyle-HorizontalAlign="center" DataField="TenSanPham" HeaderText="Tên sản phẩm" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                <asp:Button ID="btnShow" CausesValidation="false" class="btn btn-primary" runat="server" OnClick="btnShow_Click" Text="Xem tất cả" />
            </td>
        </tr>
    </table>    
</asp:Panel>

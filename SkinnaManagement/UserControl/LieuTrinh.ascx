<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LieuTrinh.ascx.cs" Inherits="SkinnaManagement.UserControl.LieuTrinh" %>

<link rel="stylesheet" href="/css/jquery-ui.css" />
<script type="text/javascript">
    $(document).ready(function () {
        //$("#head_LieuTrinh_btnReset").click(function () {
           
        //});
    });
    function ShowDialog()
    {
        AccountStatement_InitDialogs()
        $('#dlgLieuTrinh').dialog("open");
    }
    function AccountStatement_InitDialogs() {
        $('#dlgLieuTrinh').dialog({
            autoOpen: false,
            "width": 710,
            "modal": true,
            position: {
                at: "center center"
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
<label>Liệu trình khách đang dùng</label>
<asp:Panel ID="Panel1" runat="server">
    <div class="form-group">
        <asp:CheckBox ID="cbTayTrangToi" runat="server" AutoPostBack="true" OnCheckedChanged="cbTayTrangToi_CheckedChanged" Text="Tẩy trang tối"></asp:CheckBox>
        <asp:TextBox ID="txtTayTrangToi" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="cbRuaMat" runat="server" AutoPostBack="true" OnCheckedChanged="cbRuaMat_CheckedChanged" Text="Rửa mặt"></asp:CheckBox>
        <asp:TextBox ID="txtRuaMat" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="cbToner" runat="server" AutoPostBack="true" OnCheckedChanged="cbToner_CheckedChanged" Text="Toner"></asp:CheckBox>
        <asp:TextBox ID="txtToner" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="cbSerum" runat="server" AutoPostBack="true" OnCheckedChanged="cbSerum_CheckedChanged" Text="Serum"></asp:CheckBox>
        <asp:TextBox ID="txtSerum" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="cbKem" runat="server" AutoPostBack="true" OnCheckedChanged="cbKem_CheckedChanged" Text="Kem"></asp:CheckBox>
        <asp:TextBox ID="txtKem" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:CheckBox ID="cbOthers" runat="server" AutoPostBack="true" OnCheckedChanged="cbOthers_CheckedChanged" Text="Sản phẩm khác"></asp:CheckBox>
        <asp:TextBox ID="txtOthers" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:GridView ID="gvLieuTrinh" runat="server" AutoGenerateColumns="false" OnRowCommand="gvLieuTrinh_RowCommand" DataKeyNames="MaKhachHang">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="SoThuTu" HeaderText="STT" />
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="Ngay" HeaderText="Ngày liệu trình" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CommandArgument='<%#Eval("Ngay")%>' CommandName="lbtView" CausesValidation="false" runat="server" ID="lbtEdit" Text="Chi tiết"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
    <div id="dlgLieuTrinh" title="Liệu Trình chi tiết" runat="server" clientidmode="Static">
        <asp:GridView ID="gvLieuTrinhChiTiet" runat="server" AutoGenerateColumns="false">
            <Columns>               
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="SoThuTu" HeaderText="STT" />
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="Ngay" HeaderText="Ngày liệu trình" />
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="LoaiLieuTrinh" HeaderText="Loại liệu trình" />
                <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="ThongTin" HeaderText="Thông tin tư vấn" />
            </Columns>
            <HeaderStyle HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Panel>

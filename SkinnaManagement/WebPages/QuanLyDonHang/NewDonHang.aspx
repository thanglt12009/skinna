<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="NewDonHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyDonHang.NewDonHang" %>

<%@ Register Src="~/UserControl/LieuTrinh.ascx" TagPrefix="uc1" TagName="LieuTrinh" %>
<%@ Register Src="~/UserControl/SanPhamDaMua.ascx" TagPrefix="uc1" TagName="SanPhamDaMua" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script type="text/javascript">
        function EnterEvent(e) {
            if (e.keyCode == 13)
                __doPostBack('<%=btnSoDienThoai.UniqueID%>', "");
        }
        $(document).ready(function () {
            $('#head_ChietKhau').change(function () {
                if ($(this).is(":checked")) {
                    $('#divChietKhau').show();
                }
                else {
                    $('#divChietKhau').hide();
                }
            });
            $('#head_PhiGiaoHang').change(function () {
                if ($(this).is(":checked")) {
                    $('#divGiaoHang').show();
                }
                else {
                    $('#divGiaoHang').hide();
                }
            });
        });
    </script>
    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
        <div class="row">
            <ol class="breadcrumb">
                <li><a href="#">
                    <svg class="glyph stroked home">
                        <use xlink:href="#stroked-home"></use></svg></a></li>
                <li class="active">Icons</li>
            </ol>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Tạo Đơn Hàng</h1>
            </div>
        </div>
        <!--/.row-->


        <div class="row">
            <div class="col-lg-12">
                <form role="form" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                                    <contenttemplate>
                    <label id="ErrorMessage" runat="server" class="error"></label>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Số Điện thoại<span style="color: red">*</span></label>
                                    <asp:TextBox id="SoDienThoai" clientidmode="Static" onkeypress="return EnterEvent(event)" class="form-control" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnSoDienThoai" causesvalidation="false" runat="server" style="display: none" onclick="btnSoDienThoai_Click" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="SoDienThoai" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Tên Khách Hàng</label>
                                    <input id="TenKhachHang" runat="server" class="form-control" readonly placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Phương thức thanh toán <span style="color: red">*</span></label>
                                    <select id="ThanhToan" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Phương thức thanh toán---</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="ThanhToan" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <%--<asp:CheckBox id="ChietKhau" runat="server" Text="Chiết khấu"></asp:CheckBox>--%>
                                    <div id="divChietKhau" runat="server">
                                        <div class="form-group">
                                            <label>Số tiền chiết khấu</label>
                                            <asp:TextBox id="SoTienChietKhau" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>Tỉ lệ chiết khấu</label>
                                            <asp:TextBox id="TiLeChietKhau" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <%--<asp:CheckBox id="PhiGiaoHang" runat="server" Text="Phí giao hàng"></asp:CheckBox>--%>
                                    <div id="divGiaoHang" runat="server">
                                        <div class="form-group">
                                            <label>Số tiền phí giao hàng</label>
                                            <asp:TextBox id="TienGiaoHang" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Giới tính</label>
                                    <asp:RadioButton ID="rdbMale" GroupName="Gender" Enabled="false" Text="Nam" runat="server" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:RadioButton ID="rdbFemale" GroupName="Gender" Enabled="false" Text="Nữ" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label>Tuổi</label>
                                    <input id="Age" runat="server" class="form-control" readonly placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Tình trạng da</label>
                                    <textarea id="TinhTrangDa" runat="server" class="form-control" rows="5" readonly placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Tổng tiền</label>
                                    <asp:TextBox id="TongTien" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Ảnh chụp</label>
                                    <asp:Image ID="AnhChup" runat="server"></asp:Image>
                                </div>
                                <div class="form-group">
                                    <uc1:LieuTrinh runat="server" ID="LieuTrinh" />
                                </div>
                                <div class="form-group">
                                    <uc1:SanPhamDaMua runat="server" ID="SanPhamDaMua" />
                                </div>
                                <div class="form-group">
                                    <label>Lưu ý riêng</label>
                                    <textarea id="LuuY" runat="server" class="form-control" rows="5" readonly placeholder="" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Chi tiết đơn hàng</label>
                                    <br />
                                    <asp:Gridview ID="gvProducts" OnRowCreated="Gridview1_RowCreated" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                                        <columns>    
                                            <asp:BoundField DataField="RowNumber" HeaderText="STT" />                                                                                   
                                            <asp:TemplateField ItemStyle-HorizontalAlign="center" HeaderText="Barcode">
                                                <ItemTemplate>
                                                    <input id="Barcode" runat="server" class="form-control" placeholder="Nhập barcode" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField ItemStyle-HorizontalAlign="center" HeaderText="Tên sản phẩm">
                                                <ItemTemplate>
                                                    <asp:DropDownList class="form-control" onselectedindexchanged="SanPham_SelectedIndexChanged" ID="SanPham" runat="server" AutoPostBack="true"></asp:DropDownList>                                                            
                                                </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="50px"  HeaderText="Đơn giá">
                                                <ItemTemplate>
                                                   <asp:Label ID="DonGia" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField ItemStyle-HorizontalAlign="center" HeaderText="Số lượng">
                                                <ItemTemplate>
                                                   <asp:TextBox id="SoLuong" class="form-control" AutoPostBack="true" ontextchanged="SoLuong_TextChanged" runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField ItemStyle-HorizontalAlign="center" HeaderText="Thành tiền">
                                                <ItemTemplate>
                                                   <asp:Label ID="ThanhTien" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                   <ItemTemplate>  
                                                      <asp:LinkButton AutoPostBack="true" causesvalidation="false" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Xóa</asp:LinkButton>  
                                                    </ItemTemplate>  
                                             <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                     <asp:Button causesvalidation="false" id="btnAddSanpham" OnClick="btnAddSanpham_Click" class="btn btn-primary" runat="server" Text="Thêm sản phẩm" />
                                                </FooterTemplate>
                                             </asp:TemplateField>
                                        </columns>
                                    </asp:Gridview>


                                </div>
                                <div class="col-md-6">
                                    <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Tạo Đơn hàng</button>
                                    <button type="reset" runat="server" causesvalidation="false" id="btnReset" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
                                </div>
                            </div>
                        </div>
                        </contenttemplate>
                                </asp:UpdatePanel> 
                </form>
            </div>

        </div>
    </div>
</asp:Content>


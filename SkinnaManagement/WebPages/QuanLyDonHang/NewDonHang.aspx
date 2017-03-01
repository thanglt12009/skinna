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
                else
                {
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
                                    <label>Tên Khách Hàng <span style="color: red">*</span></label>
                                    <asp:TextBox id="TenKhachHang" class="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator id="rqTenKhachHang" CssClass="error" ControlToValidate="TenKhachHang" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Phương thức thanh toán <span style="color: red">*</span></label>
                                    <select id="ThanhToan" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Phương thức thanh toán---</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="ThanhToan" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:CheckBox id="ChietKhau" runat="server" Text="Chiết khấu"></asp:CheckBox>
                                    <div id="divChietKhau" style="display:none;">
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
                                    <asp:CheckBox id="PhiGiaoHang" runat="server" Text="Phí giao hàng"></asp:CheckBox>
                                    <div id="divGiaoHang" style="display:none;">
                                         <div class="form-group">
                                            <label>Số tiền phí giao hàng</label>
                                            <asp:TextBox id="TienGiaoHang" class="form-control" runat="server"></asp:TextBox>
                                          </div>
                                    </div>
                                </div>
                               <div class="form-group">
                                    <label>Giới tính</label>
                                   <asp:RadioButton ID="rdbMale" GroupName="Gender" Text="Nam" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:RadioButton ID="rdbFemale" GroupName="Gender" Text="Nữ" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label>Tuổi</label>
                                    <input id="Age" type="number" runat="server" class="form-control" placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Tình trạng da</label>
                                    <asp:TextBox id="TinhTrangDa" class="form-control" TextMode="multiline" Rows="5" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label>Nguồn Đơn Hàng</label>
                                    <select id="ddlNguonDonHang" runat="server" class="form-control">
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label>Thông tin giao hàng</label>
                                    <div class="radio">
                                        <label>
                                            <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked>Thông tin giao hàng mới
                                        </label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label><a href="#">Lấy thông tin giao hàng mới</a></label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Tên Người Nhận <span style="color: red">*</span></label>
                                    <input id="tenNguoiNhan" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="tenNguoiNhan" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="form-group">
                                    <label>Chi tiết đơn hàng</label> <br />
                                    <button type="submit" runat="server" onserverclick="btnAddSanpham_ServerClick" causesvalidation="false" id="btnAddSanpham" class="btn">Thêm sản phẩm +</button>
                                     <asp:GridView runat="server">

                                     </asp:GridView>
                                </div>
                                 <div class="form-group">
                                    <label>Lưu ý riêng</label>
                                    <asp:TextBox id="TextBox1" class="form-control" TextMode="multiline" Rows="5" runat="server" />
                                </div>
                                <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Tạo Đơn hàng</button>
                                <button type="reset" runat="server" causesvalidation="false" id="btnReset" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Ảnh chụp</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>     
                                <div class="form-group">
                                    <uc1:LieuTrinh runat="server" id="LieuTrinh" />
                                </div>                          
                             <div class="form-group">
                                    <label>Email <span style="color: red">*</span></label>
                                    <input id="Email" type="email" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="Email" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="expEmail" CssClass="error" runat="server" ControlToValidate="Email" ErrorMessage="Valid email address required" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Số Điện Thoại <span style="color: red">*</span></label>
                                    <input id="DienThoai" type="number" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="DienThoai" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Địa chỉ <span style="color: red">*</span></label>
                                    <input id="Diachi" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="Diachi" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Tỉnh / Thành phố <span style="color: red">*</span></label>
                                    <select id="TinhThanh" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Tỉnh / Thành phố---</option>
                                        <option>Hồ Chí Minh</option>
                                        <option>Hà Nội</option>
                                        <option>Đà Nẵng</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="TinhThanh" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Quận / Huyện <span style="color: red">*</span></label>
                                    <select id="QuanHuyen" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Quận / Huyện---</option>
                                        <option value="1">1</option>
                                        <option value="2">2</option>
                                        <option value="3">3</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="QuanHuyen" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <label>Phương thức giao hàng <span style="color: red">*</span></label>
                                    <select id="GiaoHang" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Phương thức giao hàng---</option>
                                        <option value="Option 1">Option 1</option>
                                        <option value="Option 2">Option 2</option>
                                        <option value="Option 3">Option 3</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="GiaoHang" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <uc1:SanPhamDaMua runat="server" id="SanPhamDaMua" />
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>

                            </div>
                        </div>
                    </div>
                </form>
            </div>

        </div>
    </div>
</asp:Content>


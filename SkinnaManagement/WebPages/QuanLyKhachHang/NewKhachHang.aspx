<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="NewKhachHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyKhachHang.NewKhachHang" %>

<%@ Register Src="~/UserControl/LieuTrinh.ascx" TagPrefix="uc1" TagName="LieuTrinh" %>
<%@ Register Src="~/UserControl/SanPhamDaMua.ascx" TagPrefix="uc1" TagName="SanPhamDaMua" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <h1 class="page-header">Tạo Khách Hàng</h1>
            </div>
        </div>
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <form role="form" runat="server">
                    <label id="ErrorMessage" runat="server" class="error"></label>
                    <div class="panel panel-default">
                        <!--<div class="panel-heading">Nhập Thông Tin </div>-->
                        <div class="panel-body">
                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Họ Tên</label>
                                    <input id="hoTen" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="hoTen" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Số Điện Thoại</label>
                                    <input id="DienThoai" type="number" runat="server" class="form-control" placeholder="" />
                                     <asp:RequiredFieldValidator CssClass="error" ControlToValidate="DienThoai" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Tuổi</label>
                                    <input id="Age" type="number" runat="server" class="form-control" placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Giới tính</label>
                                   <asp:RadioButton ID="rdbMale" GroupName="Gender" Text="Nam" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:RadioButton ID="rdbFemale" GroupName="Gender" Text="Nữ" runat="server" />
                                </div>
                                 <div class="form-group">
                                    <label>Tình trạng da</label>
                                    <asp:TextBox id="TinhTrangDa" class="form-control" TextMode="multiline" Rows="5" runat="server" />
                                </div>

                                <div class="form-group">
                                    <label>Email <span style="color: red">*</span></label>
                                    <input type="email" id="Email" runat="server" class="form-control" placeholder="" />
                                     <asp:RequiredFieldValidator CssClass="error" ControlToValidate="Email" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="expEmail" CssClass="error" runat="server" ControlToValidate="Email" ErrorMessage="Valid email address required" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"></asp:RegularExpressionValidator>
                                </div>                               
                                <div class="form-group">
                                    <label>Địa chỉ</label>
                                    <input id="Diachi" runat="server" class="form-control" placeholder="" />
                                     <asp:RequiredFieldValidator CssClass="error" ControlToValidate="Diachi" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Tỉnh / Thành phố</label>
                                    <select id="TinhThanh" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Tỉnh / Thành phố---</option>
                                        <option value="Hồ Chí Minh">Hồ Chí Minh</option>
                                        <option value="Hà Nội">Hà Nội</option>
                                        <option value="Đà Nẵng">Đà Nẵng</option>
                                    </select>
                                     <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="TinhThanh" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Quận / Huyện</label>
                                    <select id="QuanHuyen" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Quận / Huyện---</option>
                                        <option>Option 2</option>
                                        <option>Option 3</option>
                                        <option>Option 4</option>
                                    </select>
                                     <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="QuanHuyen" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Số thẻ cũ</label>
                                    <input id="SoThe" runat="server" class="form-control" placeholder="" />
                                     <asp:RequiredFieldValidator CssClass="error" ControlToValidate="SoThe" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Loại thẻ</label>
                                    <select id="LoaiThe" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn loại thẻ---</option>
                                        <option>Option 2</option>
                                        <option>Option 3</option>
                                        <option>Option 4</option>
                                    </select>
                                     <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="LoaiThe" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Điểm thưởng</label>
                                    <input type="number" id="DiemThuong" runat="server" class="form-control" placeholder="" />
                                     <asp:RequiredFieldValidator CssClass="error" ControlToValidate="DiemThuong" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator3" CssClass="error" runat="server" ValueToCompare="0" ControlToValidate="DiemThuong"
                                        ErrorMessage="Must enter positive integers" Operator="GreaterThan" Type="Integer">
                                    </asp:CompareValidator>
                                </div>
                                <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Tạo Khách hàng</button>
                                <button type="reset" id="btnReset" causesvalidation="false" runat="server" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Ảnh chụp</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>     
                                <div class="form-group">
                                   <uc1:LieuTrinh runat="server" ID="LieuTrinh" />
                                </div>
                                <div class="form-group">
                                    <uc1:SanPhamDaMua runat="server" ID="SanPhamDaMua" />
                                </div>
                                 <div class="form-group">
                                    <label>Lưu ý riêng</label>
                                    <asp:TextBox id="TextBox1" class="form-control" TextMode="multiline" Rows="5" runat="server" />
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
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                </div>
                                <div class="form-group">
                                    <label>&nbsp;</label>
                                    <label>&nbsp;</label>
                                </div>

                                <!--<div class="form-group">
									<label>Text area</label>
									<textarea class="form-control" rows="3"></textarea>
								</div>
								
								<label>Validation</label>
								<div class="form-group has-success">
									<input class="form-control" placeholder="Success">
								</div>
								<div class="form-group has-warning">
									<input class="form-control" placeholder="Warning">
								</div>
								<div class="form-group has-error">
									<input class="form-control" placeholder="Error">
								</div>-->
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- /.col-->
    <%--</div><!-- /.row -->
		
	</div><!--/.main-->--%>
</asp:Content>

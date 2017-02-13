<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="NewDonHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyDonHang.NewDonHang" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../../css/styles.css" rel="stylesheet" />--%>
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
                        <!--<div class="panel-heading">Nhập Thông Tin </div>-->
                        <div class="panel-body">
                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Khách Hàng <span style="color: red">*</span></label>
                                    <input id="MaKhachHang" type="number" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="MaKhachHang" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
                                    <label>Phương thức thanh toán <span style="color: red">*</span></label>
                                    <select id="ThanhToan" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Phương thức thanh toán---</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="ThanhToan" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
                                <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Tạo Đơn hàng</button>
                                <button type="reset" runat="server" causesvalidation="false" id="btnReset" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
                            </div>
                            <div class="col-md-6">
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
</asp:Content>


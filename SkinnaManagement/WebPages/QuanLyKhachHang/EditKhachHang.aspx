﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="EditKhachHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyKhachHang.EditKhachHang" %>

<%@ Register Src="~/UserControl/LieuTrinh.ascx" TagPrefix="uc1" TagName="LieuTrinh" %>
<%@ Register Src="~/UserControl/SanPhamDaMua.ascx" TagPrefix="uc1" TagName="SanPhamDaMua" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


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
                <h1 class="page-header">Sửa Khách Hàng</h1>
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
                                    <label>Họ Tên <span style="color: red">*</span></label>
                                    <input id="hoTen" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="hoTen" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Số Điện Thoại <span style="color: red">*</span></label>
                                    <input id="DienThoai" runat="server" class="form-control" placeholder="" />
                                     <asp:RequiredFieldValidator CssClass="error" ControlToValidate="DienThoai" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Ngày sinh <span style="color: red">*</span></label>                                    
                                    <input id="DOB" type="date" runat="server" class="form-control" placeholder="" />                                    
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="DOB" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
                                    <label>Địa chỉ <span style="color: red">*</span></label>
                                    <input id="Diachi" runat="server" class="form-control" placeholder="" />
                                     <asp:RequiredFieldValidator CssClass="error" ControlToValidate="Diachi" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>                              
                                
                                <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Sửa Khách hàng</button>
                                <button type="reset" id="btnReset" causesvalidation="false" runat="server" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Ảnh chụp</label>
                                    <asp:FileUpload ID="FileUpload1" ClientIDMode="Static" onchange="this.form.submit()" runat="server" />
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
                                    <asp:TextBox id="LuuY" class="form-control" TextMode="multiline" Rows="5" runat="server" />
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


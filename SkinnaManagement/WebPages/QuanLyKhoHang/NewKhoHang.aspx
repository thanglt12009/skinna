<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewKhoHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyKhoHang.NewKhoHang" %>

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
       
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Tạo Sản Phẩm</h1>
            </div>
        </div>
        
        <div class="row">
            <div class="col-lg-12">
                <form role="form" runat="server">
                     <label id="ErrorMessage" runat="server" class="error"></label>
                    <div class="panel panel-default">
                      
                        <div class="panel-body">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Tên sản phẩm</label>
                                    <input id="tenSanPham" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="tenSanPham" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Ngày nhập hàng <span style="color: red">*</span></label>
                                    <input id="NgayNhap" runat="server" type="date" class="form-control" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="NgayNhap" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Số lượng bán <span style="color: red">*</span></label>
                                    <input id="SoLuongBan" type="number" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="SoLuongBan" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" CssClass="error" runat="server" ValueToCompare="0" ControlToValidate="SoLuongBan"
                                        ErrorMessage="Must enter positive integers" Operator="GreaterThan" Type="Integer">
                                    </asp:CompareValidator>
                                </div>
                                <div class="form-group">
                                    <label>Số lượng tồn <span style="color: red">*</span></label>
                                    <input id="SoLuongTon" type="number" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="SoLuongTon" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="CompareValidator2" CssClass="error" runat="server" ValueToCompare="0" ControlToValidate="SoLuongTon"
                                        ErrorMessage="Must enter positive integers" Operator="GreaterThan" Type="Integer">
                                    </asp:CompareValidator>
                                </div>
                                <div class="form-group">
                                    <label>Đơn giá<span style="color: red">*</span></label>
                                    <input id="TongTien" type="number" runat="server" class="form-control" placeholder="" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="TongTien" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>

                                <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Tạo Sản Phẩm</button>
                                <button type="reset" causesvalidation="false" id="btnReset" runat="server" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
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

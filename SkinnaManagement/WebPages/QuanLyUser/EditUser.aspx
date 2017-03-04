<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyUser.EditUser" %>
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
                <h1 class="page-header">Sửa User</h1>
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
                                    <label>Username <span style="color: red">*</span></label>
                                    <input id="UserName" runat="server" class="form-control" placeholder="" readonly/>
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="UserName" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Password <span style="color: red">*</span></label>
                                    <input id="Password" runat="server" type="password" class="form-control" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="Password" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Password Confirm <span style="color: red">*</span></label>
                                    <input id="PasswordConfirm" runat="server" type="password" class="form-control" />
                                    <asp:RequiredFieldValidator CssClass="error" ControlToValidate="PasswordConfirm" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator runat="server" CssClass="error" ControlToValidate="PasswordConfirm" controltocompare="Password" operator="Equal" type="String" errormessage="Password is not match" /><br />
                                </div>
                                 <div class="form-group">
                                    <label>User Role <span style="color: red">*</span></label>
                                    <select id="UserRole" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn User Role---</option>
                                        <option value="Admin">Admin</option>
                                        <option value="User">User</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="UserRole" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                                <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Sửa User</button>
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
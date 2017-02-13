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
        <!--/.row-->

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Sửa User</h1>
            </div>
        </div>
        <!--/.row-->


        <div class="row">
            <div class="col-lg-12">
                <form role="form" runat="server">
                    <div class="panel panel-default">
                        <!--<div class="panel-heading">Nhập Thông Tin </div>-->
                        <div class="panel-body">
                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Tên user <span style="color: red">*</span></label>
                                    <input class="form-control" placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Username <span style="color: red">*</span></label>
                                    <input class="form-control" placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Ngày tạo <span style="color: red">*</span></label>
                                    <input type="date" class="form-control" />
                                </div>
                                <div class="form-group">
                                    <label>Ngày cập nhật <span style="color: red">*</span></label>
                                    <input type="date" class="form-control" />
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
                                <button type="submit" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" class="btn btn-primary">Sửa User</button>
                                <button type="reset" id="btnReset" runat="server" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
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
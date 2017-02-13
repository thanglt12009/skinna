<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="QuanLyDonHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyDonHang.QuanLyDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript">
        function pageLoad() {
            $("#btSelectAll").click(function () {
                $('input:checkbox').not(this).prop('checked', this.checked);
            });
        }
    </script>
    <form runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="300">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
            <!--<div class="row">
			<ol class="breadcrumb">
				<li><a href="#"><svg class="glyph stroked home"><use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#stroked-home"></use></svg></a></li>
				<li class="active">Icons</li>
			</ol>
		</div><!--/.row-->

            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Quản Lý Đơn Hàng Bán Lẻ</h1>
                </div>
            </div>
            <!--/.row-->

            <button type="submit" runat="server" id="btnAdd" onserverclick="btnAdd_ServerClick" class="btn btn-danger">Thêm Mới</button>
            <%--<button type="submit" runat="server" id="btnEdit" onserverclick="btnEdit_ServerClick" class="btn btn-primary">Edit</button>--%>
            <br />
            <br />
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <!--<div class="panel-heading">Advanced Table</div>-->
                        <div class="panel-body">
                            <div class="bootstrap-table">
                                <div class="fixed-table-toolbar">
                                    <div class="columns btn-group pull-right">
                                        <button class="btn btn-default" type="button" name="refresh" title="Refresh"><i class="glyphicon glyphicon-refresh icon-refresh"></i></button>
                                        <button class="btn btn-default" type="button" name="toggle" title="Toggle"><i class="glyphicon glyphicon glyphicon-list-alt icon-list-alt"></i></button>
                                        <div class="keep-open btn-group" title="Columns">
                                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown"><i class="glyphicon glyphicon-th icon-th"></i><span class="caret"></span></button>
                                            <ul class="dropdown-menu" role="menu">
                                                <li>
                                                    <label>
                                                        <input type="checkbox" data-field="id" value="1" checked="checked" />
                                                        Item ID</label></li>
                                                <li>
                                                    <label>
                                                        <input type="checkbox" data-field="name" value="2" checked="checked" />
                                                        Item Name</label></li>
                                                <li>
                                                    <label>
                                                        <input type="checkbox" data-field="price" value="3" checked="checked" />
                                                        Item Price</label></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="pull-right search">
                                        <input class="form-control" type="text" placeholder="Search" />
                                    </div>
                                </div>
                                <div class="fixed-table-container">
                                    <div class="fixed-table-header">
                                        <table></table>
                                    </div>
                                    <div class="fixed-table-body">
                                        <div class="fixed-table-loading" style="top: 37px; display: none;">Loading, please wait…</div>
                                        <table id="tableData" data-toggle="table" data-url="tables/data1.json" data-show-refresh="true" data-show-toggle="true" data-show-columns="true" data-search="true" data-select-item-name="toolbar1" data-pagination="true" data-sort-name="name" data-sort-order="desc" class="table table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="bs-checkbox " style="width: 36px;">
                                                        <div class="th-inner ">
                                                            <input name="btSelectAll" id="btSelectAll" type="checkbox" />
                                                        </div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Mã Đơn Hàng</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Tên KH</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Số Điện thoại</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Ngày Đặt Hàng</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Tổng Tiền</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Nguồn Đơn hàng</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Trạng Thái Đơn Hàng</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                    <th style="">
                                                        <div class="th-inner sortable">Người Đặt Hàng</div>
                                                        <div class="fht-cell"></div>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbody" runat="server">
                                                <tr class="no-records-found" id="no_records" runat="server">
                                                    <td colspan="4">Không tìm thấy đơn hàng nào</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="fixed-table-pagination">
                                       <div class="pull-left pagination-detail">
                                            <span id="resultLabel" runat="server" class="pagination-info">Showing 1 to 10 of 10 rows</span><span class="page-list"><span class="btn-group dropup">
                                                <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown"><span runat="server" id="result_number" class="page-size">10</span> <span class="caret"></span></button>
                                                <ul class="dropdown-menu" role="menu">
                                                    <li><a id="Result_10" runat="server" onserverclick="Result_10_ServerClick" href="javascript:void(0)">10</a></li>
                                                    <li><a id="Result_25" runat="server" onserverclick="Result_25_ServerClick" href="javascript:void(0)">25</a></li>
                                                    <li><a id="Result_50" runat="server" onserverclick="Result_50_ServerClick" href="javascript:void(0)">50</a></li>
                                                    <li><a id="Result_100" runat="server" onserverclick="Result_100_ServerClick" href="javascript:void(0)">100</a></li>
                                                </ul>
                                            </span>records per page</span>
                                        </div>
                                        <div class="pull-right pagination">
                                            <ul class="pagination">
                                                <li class="page-first disabled"><a id="page_first" runat="server" onserverclick="page_first_ServerClick" href="javascript:void(0)">&lt;&lt;</a></li>
                                                <li class="page-pre disabled"><a href="javascript:void(0)">&lt;</a></li>
                                                <li class="page-next disabled"><a href="javascript:void(0)">&gt;</a></li>
                                                <li class="page-last disabled"><a href="javascript:void(0)">&gt;&gt;</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/.row-->
            <!--<div class="row">
			<div class="col-md-6">
				<div class="panel panel-default">
					<div class="panel-heading">Basic Table</div>
					<div class="panel-body">
						<div class="bootstrap-table"><div class="fixed-table-toolbar"></div><div class="fixed-table-container"><div class="fixed-table-header"><table></table></div><div class="fixed-table-body"><div class="fixed-table-loading" style="top: 37px; display: none;">Loading, please wait…</div><table data-toggle="table" data-url="tables/data2.json" class="table table-hover">
						    <thead>
						    <tr><th style="text-align: right; "><div class="th-inner ">Item ID</div><div class="fht-cell"></div></th><th style=""><div class="th-inner ">Item Name</div><div class="fht-cell"></div></th><th style=""><div class="th-inner ">Item Price</div><div class="fht-cell"></div></th></tr>
						    </thead>
						<tbody><tr class="no-records-found"><td colspan="3">No matching records found</td></tr></tbody></table></div><div class="fixed-table-pagination"></div></div></div><div class="clearfix"></div>
					</div>
				</div>
			</div>
			<div class="col-md-6">
				<div class="panel panel-default">
					<div class="panel-heading">Styled Table</div>
					<div class="panel-body">
						<div class="bootstrap-table"><div class="fixed-table-toolbar"></div><div class="fixed-table-container"><div class="fixed-table-header"><table></table></div><div class="fixed-table-body"><div class="fixed-table-loading" style="top: 37px; display: none;">Loading, please wait…</div><table data-toggle="table" id="table-style" data-url="tables/data2.json" data-row-style="rowStyle" class="table table-hover">
						    <thead>
						    <tr><th style="text-align: right; "><div class="th-inner ">Item ID</div><div class="fht-cell"></div></th><th style=""><div class="th-inner ">Item Name</div><div class="fht-cell"></div></th><th style=""><div class="th-inner ">Item Price</div><div class="fht-cell"></div></th></tr>
						    </thead>
						<tbody><tr class="no-records-found"><td colspan="3">No matching records found</td></tr></tbody></table></div><div class="fixed-table-pagination"></div></div></div><div class="clearfix"></div>
						<script>
						    $(function () {
						        $('#hover, #striped, #condensed').click(function () {
						            var classes = 'table';
						
						            if ($('#hover').prop('checked')) {
						                classes += ' table-hover';
						            }
						            if ($('#condensed').prop('checked')) {
						                classes += ' table-condensed';
						            }
						            $('#table-style').bootstrapTable('destroy')
						                .bootstrapTable({
						                    classes: classes,
						                    striped: $('#striped').prop('checked')
						                });
						        });
						    });
						
						    function rowStyle(row, index) {
						        var classes = ['active', 'success', 'info', 'warning', 'danger'];
						
						        if (index % 2 === 0 && index / 2 < classes.length) {
						            return {
						                classes: classes[index / 2]
						            };
						        }
						        return {};
						    }
						</script>
					</div>
				</div>
			</div>
		</div>/.row-->

        </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</asp:Content>

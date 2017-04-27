<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuanLyKhoHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyKhoHang.QuanLyKhoHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript">
        var table;
        $(document).ready(function () {
            table = $('#KhoHangTable').DataTable(
            {
                "pageLength": 50,
                "columnDefs": [

                  { "width": "5%", "targets": [0] },

                  { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6] },

                ],
                "language":
                  {
                      "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                  },
                "processing": true,
                "serverSide": true,
                "ajax":
                  {
                      "url": "QuanLyKhoHang.aspx/GetData",
                      "contentType": "application/json",
                      "type": "GET",
                      "dataType": "JSON",
                      "data": function (d) {
                          return d;
                      },
                      "dataSrc": function (json) {
                          json.draw = json.d.draw;
                          json.recordsTotal = json.d.recordsTotal;
                          json.recordsFiltered = json.d.recordsFiltered;
                          json.data = json.d.data;
                          var return_data = json;
                          return return_data.data;
                      }
                  },
                "columns": [                      
                      { "data": "MaSanPham" },
                      { "data": "TenSP" },
                      { "data": "SoLuongBan" },
                      { "data": "TongTienBan" },
                      { "data": "SoLuongTon" },
                      { "data": "TongTienTon" },
                      { "data": "Edit" },
                      { "data": "Delete" }
                ]
            });
        });
        function pageLoad() {
           
        }
        function OnSuccess(result, context, method) {
            table.destroy();
            table = $('#KhoHangTable').DataTable(
            {
                "pageLength": 50,
                "columnDefs": [

                  { "width": "5%", "targets": [0] },

                  { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6] },

                ],
                "language":
                  {
                      "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                  },
                "processing": true,
                "serverSide": true,
                "ajax":
                  {
                      "url": "QuanLyKhoHang.aspx/GetData",
                      "contentType": "application/json",
                      "type": "GET",
                      "dataType": "JSON",
                      "data": function (d) {
                          return d;
                      },
                      "dataSrc": function (json) {
                          json.draw = json.d.draw;
                          json.recordsTotal = json.d.recordsTotal;
                          json.recordsFiltered = json.d.recordsFiltered;
                          json.data = json.d.data;
                          var return_data = json;
                          return return_data.data;
                      }
                  },
                "columns": [
                      { "data": "MaSanPham" },
                      { "data": "TenSP" },                    
                      { "data": "SoLuongBan" },
                      { "data": "TongTienBan" },
                      { "data": "SoLuongTon" },
                      { "data": "TongTienTon" },
                      { "data": "Edit" },
                      { "data": "Delete" }
                ]
            });
        }
        function OnFailed(error, context, method) {

        }
        function XoaSanPham(id) {
            PageMethods.XoaSanPham(id, OnSuccess, OnFailed, null);
        }
    </script>
    <form runat="server">
        <asp:ScriptManager ID="Main" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Quản Lý Kho Hàng Xuất Nhập</h1>
                </div>
            </div>
            <button type="submit" runat="server" id="btnAdd" onserverclick="btnAdd_ServerClick" class="btn btn-danger">Thêm Mới</button>
            <br />
            <br />
            <table class="table table-striped table-bordered table-hover" id="KhoHangTable">
                <thead>
                    <tr>
                        <th>Mã SP</th>
                        <th>Tên SP</th>                       
                        <th>Số lượng Bán</th>
                        <th>Tổng Tiền Bán</th>
                        <th>Số Lượng Tồn</th>
                        <th>Tổng Tiền Tồn</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
            </table>           
        </div>        
    </form>
</asp:Content>

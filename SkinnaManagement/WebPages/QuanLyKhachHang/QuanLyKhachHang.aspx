<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuanLyKhachHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyKhachHang.QuanLyKhachHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script src="../../js/jquery-1.11.1.min.js"></script>
     <script type="text/javascript">
        $(document).ready(function () {
            $('#KhachHangTable').DataTable(
            {
                "pageLength": 50,
                "columnDefs": [

                  { "width": "5%", "targets": [0] },

                  { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5] },

                ],
                "language":
                  {
                      "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                  },
                "processing": true,
                "serverSide": true,
                "ajax":
                  {
                      "url": "QuanLyKhachHang.aspx/GetData",
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
                      { "data": "MaKhachHang" },
                      { "data": "TenKhachHang" },
                      { "data": "SoDienThoai" },                      
                      { "data": "NgaySinh" },
                      { "data": "TongTien" },
                      { "data": "DiaChi" },                      
                      { "data": "Edit" }
                ]
            });
        });
        function pageLoad() {
            $("#btSelectAll").click(function () {
                $('input:checkbox').not(this).prop('checked', this.checked);
            });
        }
    </script>
    <form runat="server">
        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Quản Lý Khách Hàng</h1>
                </div>
            </div>
            <button type="submit" runat="server" id="btnAdd" onserverclick="btnAdd_ServerClick" class="btn btn-danger">Thêm Mới</button>
            <button type="submit" runat="server" id="btnSendMail" onserverclick="btnSendMail_ServerClick" class="btn btn-danger">Gửi Mail</button>
            <button type="submit" runat="server" id="btnDownload" onserverclick="btnDownload_ServerClick" class="btn btn-danger">DOWNLOAD</button>
            <br />
            <br />
            <table class="table table-striped table-bordered table-hover" id="KhachHangTable">
                <thead>
                    <tr>                       
                        <th>Mã KH</th>
                        <th>Họ Tên</th>
                        <th>Số Điện Thoại</th>
                        <th>Ngày sinh</th>
                        <th>Tổng tiền đã mua</th>
                        <th>Địa chỉ</th>                        
                        <th></th>
                    </tr>
                </thead>
            </table>           
        </div>        
    </form>
</asp:Content>

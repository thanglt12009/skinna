<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuanLyDonHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyDonHang.QuanLyDonHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../js/jquery-1.11.1.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#from").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 3,
                format: 'dd/mm/yyyy',
                onClose: function (selectedDate) {
                    $("#to").datepicker("option", "minDate", selectedDate);
                }
            });
            $("#to").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                format: 'dd/mm/yyyy',
                numberOfMonths: 3,
                onClose: function (selectedDate) {
                    $("#from").datepicker("option", "maxDate", selectedDate);
                }
            });
        });
        $(document).ready(function () {
            var table = $('#DonHangTable').DataTable(
            {
                "pageLength": 50,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "columnDefs": [

                  { "width": "5%", "targets": [0] },

                  { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6, 7] },

                ],
                "language":
                  {
                      "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                  },
                "processing": true,
                "serverSide": true,
                "ajax":
                  {
                      "url": "QuanLyDonHang.aspx/GetData",
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
                          var sum = json.d.sum;
                          $('#<%=lblTotalCredits.ClientID%>').html(sum);
                          var return_data = json;
                          return return_data.data;
                      }
                  },
                "columns": [
                      { "data": "MaDonHang" },
                      { "data": "TenKhachHang" },
                      { "data": "NgayDatHang" },
                      { "data": "TongTien" },
                      { "data": "PhiVanChuyen" },
                      { "data": "TrangThaiDonHang" },
                      { "data": "PhuongThucThanhToan" },
                      { "data": "Edit" }
                ]
            });
            // Add event listeners to the two range filtering inputs
            $("#from").keyup(function () {
                if (!this.value) {
                    table.destroy();
                    table = $('#DonHangTable').DataTable(
                {
                    "pageLength": 50,
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                    "columnDefs": [

                      { "width": "5%", "targets": [0] },

                      { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6, 7] },

                    ],
                    "language":
                      {
                          "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                      },
                    "processing": true,
                    "serverSide": true,
                    "ajax":
                      {
                          "url": "QuanLyDonHang.aspx/GetData",
                          "contentType": "application/json",
                          "type": "GET",
                          "dataType": "JSON",
                          "data": function (d) {
                              d.from = $("#from").val();
                              d.to = $("#to").val();
                              return d;
                          },
                          "dataSrc": function (json) {
                              json.draw = json.d.draw;
                              json.recordsTotal = json.d.recordsTotal;
                              json.recordsFiltered = json.d.recordsFiltered;
                              json.data = json.d.data;
                              var sum = json.d.sum;
                              $('#<%=lblTotalCredits.ClientID%>').html(sum);
                          var return_data = json;
                          return return_data.data;
                      }
                  },
                "columns": [
                      { "data": "MaDonHang" },
                      { "data": "TenKhachHang" },
                      { "data": "NgayDatHang" },
                      { "data": "TongTien" },
                      { "data": "PhiVanChuyen" },
                      { "data": "TrangThaiDonHang" },
                      { "data": "PhuongThucThanhToan" },
                      { "data": "Edit" }
                ]
            });
          }
            });
            $("#from").datepicker().on('changeDate', function () {
                table.destroy();
                table = $('#DonHangTable').DataTable(
            {
                "pageLength": 50,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                "columnDefs": [

                  { "width": "5%", "targets": [0] },

                  { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6, 7] },

                ],
                "language":
                  {
                      "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                  },
                "processing": true,
                "serverSide": true,
                "ajax":
                  {
                      "url": "QuanLyDonHang.aspx/GetData",
                      "contentType": "application/json",
                      "type": "GET",
                      "dataType": "JSON",
                      "data": function (d) {
                          d.from = $("#from").val();
                          d.to = $("#to").val();
                          return d;
                      },
                      "dataSrc": function (json) {
                          json.draw = json.d.draw;
                          json.recordsTotal = json.d.recordsTotal;
                          json.recordsFiltered = json.d.recordsFiltered;
                          json.data = json.d.data;
                          var sum = json.d.sum;
                          $('#<%=lblTotalCredits.ClientID%>').html(sum);
                          var return_data = json;
                          return return_data.data;
                      }
                  },
                "columns": [
                      { "data": "MaDonHang" },
                      { "data": "TenKhachHang" },
                      { "data": "NgayDatHang" },
                      { "data": "TongTien" },
                      { "data": "PhiVanChuyen" },
                      { "data": "TrangThaiDonHang" },
                      { "data": "PhuongThucThanhToan" },
                      { "data": "Edit" }
                ]
            });
            });
              $("#to").keyup(function () {
                if (!this.value) {
                    table.destroy();
                    table = $('#DonHangTable').DataTable(
                {
                    "pageLength": 50,
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                    "columnDefs": [

                      { "width": "5%", "targets": [0] },

                      { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6, 7] },

                    ],
                    "language":
                      {
                          "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                      },
                    "processing": true,
                    "serverSide": true,
                    "ajax":
                      {
                          "url": "QuanLyDonHang.aspx/GetData",
                          "contentType": "application/json",
                          "type": "GET",
                          "dataType": "JSON",
                          "data": function (d) {
                              d.from = $("#from").val();
                              d.to = $("#to").val();
                              return d;
                          },
                          "dataSrc": function (json) {
                              json.draw = json.d.draw;
                              json.recordsTotal = json.d.recordsTotal;
                              json.recordsFiltered = json.d.recordsFiltered;
                              json.data = json.d.data;
                              var sum = json.d.sum;
                              $('#<%=lblTotalCredits.ClientID%>').html(sum);
                          var return_data = json;
                          return return_data.data;
                      }
                  },
                "columns": [
                      { "data": "MaDonHang" },
                      { "data": "TenKhachHang" },
                      { "data": "NgayDatHang" },
                      { "data": "TongTien" },
                      { "data": "PhiVanChuyen" },
                      { "data": "TrangThaiDonHang" },
                      { "data": "PhuongThucThanhToan" },
                      { "data": "Edit" }
                ]
            });
          }
            });
            $("#to").datepicker().on('changeDate', function () {
                table.destroy();
                table = $('#DonHangTable').DataTable(
           {
               "pageLength": 50,
               "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
               "columnDefs": [

                 { "width": "5%", "targets": [0] },

                 { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3, 4, 5, 6, 7] },

               ],
               "language":
                 {
                     "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                 },
               "processing": true,
               "serverSide": true,
               "ajax":
                 {
                     "url": "QuanLyDonHang.aspx/GetData",
                     "contentType": "application/json",
                     "type": "GET",
                     "dataType": "JSON",
                     "data": function (d) {
                         d.from = $("#from").val();
                         d.to = $("#to").val();
                         return d;
                     },
                     "dataSrc": function (json) {
                         json.draw = json.d.draw;
                         json.recordsTotal = json.d.recordsTotal;
                         json.recordsFiltered = json.d.recordsFiltered;
                         json.data = json.d.data;
                         var sum = json.d.sum;
                         $('#<%=lblTotalCredits.ClientID%>').html(sum);
                         var return_data = json;
                         return return_data.data;
                     }
                 },
               "columns": [
                     { "data": "MaDonHang" },
                     { "data": "TenKhachHang" },
                     { "data": "NgayDatHang" },
                     { "data": "TongTien" },
                     { "data": "PhiVanChuyen" },
                     { "data": "TrangThaiDonHang" },
                     { "data": "PhuongThucThanhToan" },
                     { "data": "Edit" }
               ]
           });
            });
        });
    </script>
    <form runat="server">
        <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Quản Lý Đơn Hàng Xuất Bán Lẻ</h1>
                </div>
            </div>
            <button type="submit" runat="server" id="btnAdd" onserverclick="btnAdd_ServerClick" class="btn btn-danger">Thêm Mới</button>
            <asp:Label ID="Label2" runat="server" Text="Tổng thu:" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblTotalCredits" runat="server" Font-Bold="true"></asp:Label>
            <br />
            <br />
            <div id="startfrom">
                <label for="from">From</label>
                <input type="text" id="from" name="From">
                <label for="to">to</label>
                <input type="text" id="to" name="To">
            </div>
            <br />
            <table class="table table-striped table-bordered table-hover" id="DonHangTable">
                <thead>
                    <tr>
                        <th>Mã Đơn Hàng</th>
                        <th>Tên Khách Hàng</th>
                        <th>Ngày Đặt Hàng</th>
                        <th>Tổng tiền</th>
                        <th>Phí ship</th>
                        <th>Trạng thái đơn hàng</th>
                        <th>Phương thức thanh toán</th>
                        <th></th>
                    </tr>
                </thead>
            </table>
        </div>
    </form>
</asp:Content>

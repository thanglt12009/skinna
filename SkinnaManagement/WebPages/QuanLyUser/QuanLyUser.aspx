<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuanLyUser.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyUser.QuanLyUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="../../js/jquery-1.11.1.min.js"></script>
     <script type="text/javascript">
        $(document).ready(function () {
            $('#UserTable').DataTable(
            {
                "columnDefs": [

                  { "width": "5%", "targets": [0] },

                  { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3] },

                ],
                "language":
                  {
                      "processing": "<div class='overlay custom-loader-background'><i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                  },
                "processing": true,
                "serverSide": true,
                "ajax":
                  {
                      "url": "QuanLyUser.aspx/GetData",
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
                      { "data": "UserId" },
                      { "data": "UserName" },
                      { "data": "UserRole" },                     
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
                    <h1 class="page-header">Quản Lý User</h1>
                </div>
            </div>
            <button type="submit" runat="server" id="btnAdd" onserverclick="btnAdd_ServerClick" class="btn btn-danger">Thêm Mới</button>
            <br />
            <br />
            <table class="table table-striped table-bordered table-hover" id="UserTable">
                <thead>
                    <tr>                       
                        <th>UserId</th>
                        <th>UserName</th>
                        <th>User Role</th>                                              
                        <th></th>
                    </tr>
                </thead>
            </table>           
        </div>        
    </form>
</asp:Content>


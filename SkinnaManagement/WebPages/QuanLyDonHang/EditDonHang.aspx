<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditDonHang.aspx.cs" Inherits="SkinnaManagement.WebPages.QuanLyDonHang.EditDonHang" %>

<%@ Register Src="~/UserControl/LieuTrinh.ascx" TagPrefix="uc1" TagName="LieuTrinh" %>
<%@ Register Src="~/UserControl/SanPhamDaMua.ascx" TagPrefix="uc1" TagName="SanPhamDaMua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src='<%= ResolveUrl("~/js/jquery-migrate-1.2.1.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/js/jquery-ui-1.10.4.custom.min.js") %>'></script>
    <script src='<%= ResolveUrl("~/js/bootstrap.min.js") %>'></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
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
                <h1 class="page-header">Sửa Đơn Hàng</h1>
            </div>
        </div>
        <!--/.row-->


        <div class="row">
            <div class="col-lg-12">
                <form role="form" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                    <label id="ErrorMessage" runat="server" class="error"></label>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Số Điện thoại<span style="color: red">*</span></label>
                                    <input id="SoDienThoai" runat="server" class="form-control" readonly placeholder="" />                                    
                                </div>
                                <div class="form-group">
                                    <label>Tên Khách Hàng</label>
                                    <input id="TenKhachHang" runat="server" class="form-control" readonly placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Phương thức thanh toán <span style="color: red">*</span></label>
                                    <select id="ThanhToan" runat="server" class="form-control">
                                        <option value="0" selected disabled>---Chọn Phương thức thanh toán---</option>
                                    </select>
                                    <asp:RequiredFieldValidator InitialValue="0" CssClass="error" ControlToValidate="ThanhToan" Display="Dynamic" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </div>
                               <div class="form-group">                                    
                                    <div id="divChietKhau" runat="server">
                                        <div class="form-group">
                                           <asp:RadioButton GroupName="ChietKhau" id="rbTienChietKhau" Checked="true" runat="server" Text="Số tiền chiết khấu" AutoPostBack="true" OnCheckedChanged="rbTienChietKhau_CheckedChanged" />
                                           <asp:TextBox id="SoTienChietKhau" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:RadioButton GroupName="ChietKhau" id="rbTiLeChietKhau" runat="server" Text="Tỉ lệ chiết khấu" AutoPostBack="true" OnCheckedChanged="rbTiLeChietKhau_CheckedChanged" />                                           
                                            <asp:TextBox id="TiLeChietKhau" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">                                   
                                    <div id="divGiaoHang" runat="server">
                                        <div class="form-group">
                                            <label>Số tiền phí giao hàng</label>
                                            <asp:TextBox id="TienGiaoHang" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label>Giới tính</label>
                                    <asp:RadioButton ID="rdbMale" GroupName="Gender" Enabled="false" Text="Nam" runat="server" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <asp:RadioButton ID="rdbFemale" GroupName="Gender" Enabled="false" Text="Nữ" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label>Ngày sinh</label>
                                    <input id="DOB" runat="server" class="form-control" readonly placeholder="" />
                                </div>
                                 <div class="form-group">
                                    <label>Tình trạng da</label>
                                     <asp:Gridview ID="gvTinhTrang" runat="server" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="4" AutoGenerateColumns="false">
                                        <columns>                               
                                            <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="SoThuTu" HeaderText="STT" />
                                            <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="Ngay" HeaderText="Ngày" /> 
                                            <asp:BoundField ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="TinhTrang" HeaderText="Tình trạng da" />                                                                                               
                                        </columns>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" />
                                    </asp:Gridview>
                                </div>       
                                 <div class="form-group">
                                    <label>Tên sản phẩm</label>
                                    <asp:DropDownList class="form-control" onselectedindexchanged="SanPham_SelectedIndexChanged" ID="SanPham" runat="server" AutoPostBack="true"></asp:DropDownList>                                                            
                                </div>
                                <div class="form-group">
                                    <label>Đơn giá</label>
                                    <input id="DonGia" runat="server" class="form-control" readonly placeholder="" />
                                </div>
                                <div class="form-group">
                                    <label>Số lượng</label>
                                    <input id="SoLuong" runat="server" class="form-control" placeholder="" />
                                </div>
                                 <div class="form-group">
                                    <asp:Button ID="btnAdd" causesvalidation="false" class="btn btn-default" runat="server" OnClick="btnAdd_Click" Text="Thêm sản phẩm" ValidationGroup="DetailGroup" />
                                    <asp:Button ID="btnCancel" causesvalidation="false" class="btn btn-default" runat="server" OnClick="btnCancel_Click" Text="Hủy sản phẩm" ValidationGroup="DetailGroup" />                            
                                </div>                   
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Ảnh chụp</label>
                                    <asp:Image ID="AnhChup" runat="server" style="height:200px;width:200px"></asp:Image>
                                </div>
                                <div class="form-group">
                                    <uc1:LieuTrinh runat="server" ID="LieuTrinh" />
                                </div>
                                <div class="form-group">
                                    <uc1:SanPhamDaMua runat="server" ID="SanPhamDaMua" />
                                </div>
                                <div class="form-group">
                                    <label>Lưu ý riêng</label>
                                    <textarea id="LuuY" runat="server" class="form-control" rows="5" readonly placeholder="" />
                                </div>
                                
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                   <asp:Gridview ID="gvProducts" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowCommand="gvProducts_RowCommand" >
                                        <columns>                
                                           <asp:BoundField ItemStyle-Width="150px" DataField="MaSanPham" Visible="false" />                                                               
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TenSanPham" HeaderText="Tên sản phẩm" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="DonGiaView" HeaderText="Giá bán" /> 
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TienChietKhau" HeaderText="Số tiền chiết khấu" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="TiLeChietKhau" HeaderText="Tỉ lệ chiết khấu" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="DonGia" Visible="false" /> 
                                            <asp:BoundField ItemStyle-Width="150px" DataField="SoLuong" HeaderText="Số lượng" /> 
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ThanhTienView" HeaderText="Thành tiền" />
                                            <asp:BoundField ItemStyle-Width="150px" DataField="ThanhTien" Visible="false" />          
                                            <asp:TemplateField>
                                                 <ItemTemplate>
                                                    <asp:LinkButton CommandArgument='<%#Eval("MaSanPham")%>' CommandName="lbtEdit" causesvalidation="false" runat="server" ID="lbtEdit" Text="Sửa"></asp:LinkButton>
                                                 </ItemTemplate>
                                                 <ItemStyle/>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                 <ItemTemplate>
                                                     <asp:LinkButton CommandArgument='<%#Eval("MaSanPham")%>' CommandName="lbtRemove"  causesvalidation="false" runat="server" ID="lbtRemove" Text="Xóa"></asp:LinkButton>
                                                 </ItemTemplate>
                                                <ItemStyle/>
                                            </asp:TemplateField>                                                         
                                        </columns>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" />
                                    </asp:Gridview>
                                    <asp:Label ID="Label2" runat="server" Text="Tổng tiền:" Font-Bold="true"></asp:Label>                               
                                     <asp:Label ID="lblTotalCredits" runat="server" Font-Bold="true"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Phí ship:" Font-Bold="true"></asp:Label>
                                     <asp:Label ID="lblPhiShip" runat="server" Font-Bold="true"></asp:Label>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="Thanh toán:" Font-Bold="true"></asp:Label>
                                     <asp:Label ID="lblThanhToan" runat="server" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="Button1" causesvalidation="false" class="btn btn-primary" runat="server" OnClick="btnSubmit_ServerClick" Text="Sửa Đơn hàng" />                                       
                                    <button type="reset" runat="server" causesvalidation="false" id="btnReset" onserverclick="btnReset_ServerClick" class="btn btn-default">Quay Về</button>
                                </div>
                            </div>
                        </div>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </form>
            </div>

        </div>
    </div>
</asp:Content>

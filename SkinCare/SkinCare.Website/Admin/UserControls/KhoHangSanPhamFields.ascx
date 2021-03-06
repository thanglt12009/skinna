﻿<%@ Control Language="C#" ClassName="KhoHangSanPhamFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsDeleted" runat="server" Text="Is Deleted:" AssociatedControlID="dataIsDeleted" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsDeleted" SelectedValue='<%# Bind("IsDeleted") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaSanPham" runat="server" Text="Ma San Pham:" AssociatedControlID="dataMaSanPham" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaSanPham" Text='<%# Bind("MaSanPham") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaSanPham" runat="server" Display="Dynamic" ControlToValidate="dataMaSanPham" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTenSanPham" runat="server" Text="Ten San Pham:" AssociatedControlID="dataTenSanPham" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTenSanPham" Text='<%# Bind("TenSanPham") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSoLuongNhapVao" runat="server" Text="So Luong Nhap Vao:" AssociatedControlID="dataSoLuongNhapVao" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSoLuongNhapVao" Text='<%# Bind("SoLuongNhapVao") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSoLuongNhapVao" runat="server" Display="Dynamic" ControlToValidate="dataSoLuongNhapVao" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSoLuongBanRa" runat="server" Text="So Luong Ban Ra:" AssociatedControlID="dataSoLuongBanRa" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSoLuongBanRa" Text='<%# Bind("SoLuongBanRa") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSoLuongBanRa" runat="server" Display="Dynamic" ControlToValidate="dataSoLuongBanRa" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSoLuongTonKho" runat="server" Text="So Luong Ton Kho:" AssociatedControlID="dataSoLuongTonKho" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSoLuongTonKho" Text='<%# Bind("SoLuongTonKho") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSoLuongTonKho" runat="server" Display="Dynamic" ControlToValidate="dataSoLuongTonKho" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNgayNhapHang" runat="server" Text="Ngay Nhap Hang:" AssociatedControlID="dataNgayNhapHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNgayNhapHang" Text='<%# Bind("NgayNhapHang", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayNhapHang" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGhiChu" runat="server" Text="Ghi Chu:" AssociatedControlID="dataGhiChu" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGhiChu" Text='<%# Bind("GhiChu") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGiaTien" runat="server" Text="Gia Tien:" AssociatedControlID="dataGiaTien" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGiaTien" Text='<%# Bind("GiaTien") %>'></asp:TextBox><asp:RegularExpressionValidator ID="RegExVal_dataGiaTien"  runat="server" ControlToValidate="dataGiaTien" Display="Dynamic" ValidationExpression="^[-]?(\d{1,9})(?:[.,]\d{1,4})?$" ErrorMessage="Invalid Value" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



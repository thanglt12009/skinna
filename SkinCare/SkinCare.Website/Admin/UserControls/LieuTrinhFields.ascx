﻿<%@ Control Language="C#" ClassName="LieuTrinhFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaKhachHang" runat="server" Text="Ma Khach Hang:" AssociatedControlID="dataMaKhachHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaKhachHang" Text='<%# Bind("MaKhachHang") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMaKhachHang" runat="server" Display="Dynamic" ControlToValidate="dataMaKhachHang" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNgay" runat="server" Text="Ngay:" AssociatedControlID="dataNgay" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNgay" Text='<%# Bind("Ngay", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgay" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTayTrangToi" runat="server" Text="Tay Trang Toi:" AssociatedControlID="dataTayTrangToi" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTayTrangToi" Text='<%# Bind("TayTrangToi") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRuaMat" runat="server" Text="Rua Mat:" AssociatedControlID="dataRuaMat" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRuaMat" Text='<%# Bind("RuaMat") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataToner" runat="server" Text="Toner:" AssociatedControlID="dataToner" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataToner" Text='<%# Bind("Toner") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSerum" runat="server" Text="Serum:" AssociatedControlID="dataSerum" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSerum" Text='<%# Bind("Serum") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataKem" runat="server" Text="Kem:" AssociatedControlID="dataKem" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataKem" Text='<%# Bind("Kem") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSanPhamKhac" runat="server" Text="San Pham Khac:" AssociatedControlID="dataSanPhamKhac" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSanPhamKhac" Text='<%# Bind("SanPhamKhac") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



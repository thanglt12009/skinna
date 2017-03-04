<%@ Control Language="C#" ClassName="DonHangFields" %>

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
        <td class="literal"><asp:Label ID="lbldataMaNguonDonHang" runat="server" Text="Ma Nguon Don Hang:" AssociatedControlID="dataMaNguonDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaNguonDonHang" Text='<%# Bind("MaNguonDonHang") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMaNguonDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaNguonDonHang" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaTrangThaiDonHang" runat="server" Text="Ma Trang Thai Don Hang:" AssociatedControlID="dataMaTrangThaiDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaTrangThaiDonHang" Text='<%# Bind("MaTrangThaiDonHang") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMaTrangThaiDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaTrangThaiDonHang" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNguoiDatHang" runat="server" Text="Nguoi Dat Hang:" AssociatedControlID="dataNguoiDatHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNguoiDatHang" Text='<%# Bind("NguoiDatHang") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaPhuongThucThanhToan" runat="server" Text="Ma Phuong Thuc Thanh Toan:" AssociatedControlID="dataMaPhuongThucThanhToan" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaPhuongThucThanhToan" Text='<%# Bind("MaPhuongThucThanhToan") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMaPhuongThucThanhToan" runat="server" Display="Dynamic" ControlToValidate="dataMaPhuongThucThanhToan" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCachThucNhanHang" runat="server" Text="Cach Thuc Nhan Hang:" AssociatedControlID="dataCachThucNhanHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCachThucNhanHang" Text='<%# Bind("CachThucNhanHang") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhiVanChuyen" runat="server" Text="Phi Van Chuyen:" AssociatedControlID="dataPhiVanChuyen" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhiVanChuyen" Text='<%# Bind("PhiVanChuyen") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPhiVanChuyen" runat="server" Display="Dynamic" ControlToValidate="dataPhiVanChuyen" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTongTienDonHang" runat="server" Text="Tong Tien Don Hang:" AssociatedControlID="dataTongTienDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTongTienDonHang" Text='<%# Bind("TongTienDonHang") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTongTienDonHang" runat="server" Display="Dynamic" ControlToValidate="dataTongTienDonHang" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNgayTaoDonHang" runat="server" Text="Ngay Tao Don Hang:" AssociatedControlID="dataNgayTaoDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNgayTaoDonHang" Text='<%# Bind("NgayTaoDonHang", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayTaoDonHang" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaKhuyenMai" runat="server" Text="Ma Khuyen Mai:" AssociatedControlID="dataMaKhuyenMai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaKhuyenMai" Text='<%# Bind("MaKhuyenMai") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaVoucher" runat="server" Text="Ma Voucher:" AssociatedControlID="dataMaVoucher" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaVoucher" Text='<%# Bind("MaVoucher") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGhiChu" runat="server" Text="Ghi Chu:" AssociatedControlID="dataGhiChu" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGhiChu" Text='<%# Bind("GhiChu") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTienChietKhau" runat="server" Text="Tien Chiet Khau:" AssociatedControlID="dataTienChietKhau" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTienChietKhau" Text='<%# Bind("TienChietKhau") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTienChietKhau" runat="server" Display="Dynamic" ControlToValidate="dataTienChietKhau" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTiLeChietKhau" runat="server" Text="Ti Le Chiet Khau:" AssociatedControlID="dataTiLeChietKhau" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTiLeChietKhau" Text='<%# Bind("TiLeChietKhau") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTiLeChietKhau" runat="server" Display="Dynamic" ControlToValidate="dataTiLeChietKhau" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



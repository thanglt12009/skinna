<%@ Control Language="C#" ClassName="KhuyenMaiFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaKhuyenMai" runat="server" Text="Ma Khuyen Mai:" AssociatedControlID="dataMaKhuyenMai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaKhuyenMai" Text='<%# Bind("MaKhuyenMai") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaKhuyenMai" runat="server" Display="Dynamic" ControlToValidate="dataMaKhuyenMai" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMaKhuyenMai" runat="server" Display="Dynamic" ControlToValidate="dataMaKhuyenMai" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaLoaiKhuyenMai" runat="server" Text="Ma Loai Khuyen Mai:" AssociatedControlID="dataMaLoaiKhuyenMai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaLoaiKhuyenMai" Text='<%# Bind("MaLoaiKhuyenMai") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaLoaiKhuyenMai" runat="server" Display="Dynamic" ControlToValidate="dataMaLoaiKhuyenMai" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMaLoaiKhuyenMai" runat="server" Display="Dynamic" ControlToValidate="dataMaLoaiKhuyenMai" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTenKhuyenMai" runat="server" Text="Ten Khuyen Mai:" AssociatedControlID="dataTenKhuyenMai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTenKhuyenMai" Text='<%# Bind("TenKhuyenMai") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGiaGiam" runat="server" Text="Gia Giam:" AssociatedControlID="dataGiaGiam" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGiaGiam" Text='<%# Bind("GiaGiam") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataGiaGiam" runat="server" Display="Dynamic" ControlToValidate="dataGiaGiam" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNgayTaoKhuyenMai" runat="server" Text="Ngay Tao Khuyen Mai:" AssociatedControlID="dataNgayTaoKhuyenMai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNgayTaoKhuyenMai" Text='<%# Bind("NgayTaoKhuyenMai", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayTaoKhuyenMai" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNgayBatDauKhuyenMai" runat="server" Text="Ngay Bat Dau Khuyen Mai:" AssociatedControlID="dataNgayBatDauKhuyenMai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNgayBatDauKhuyenMai" Text='<%# Bind("NgayBatDauKhuyenMai", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayBatDauKhuyenMai" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNgayKetThucKhuyenMai" runat="server" Text="Ngay Ket Thuc Khuyen Mai:" AssociatedControlID="dataNgayKetThucKhuyenMai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNgayKetThucKhuyenMai" Text='<%# Bind("NgayKetThucKhuyenMai", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgayKetThucKhuyenMai" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActive" runat="server" Text="Active:" AssociatedControlID="dataActive" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataActive" SelectedValue='<%# Bind("Active") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



<%@ Control Language="C#" ClassName="KhachHangFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTenKhachHang" runat="server" Text="Ten Khach Hang:" AssociatedControlID="dataTenKhachHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTenKhachHang" Text='<%# Bind("TenKhachHang") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSoDienThoai" runat="server" Text="So Dien Thoai:" AssociatedControlID="dataSoDienThoai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSoDienThoai" Text='<%# Bind("SoDienThoai") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiaChi" runat="server" Text="Dia Chi:" AssociatedControlID="dataDiaChi" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiaChi" Text='<%# Bind("DiaChi") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGioiTinh" runat="server" Text="Gioi Tinh:" AssociatedControlID="dataGioiTinh" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGioiTinh" Text='<%# Bind("GioiTinh") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLuuy" runat="server" Text="Luuy:" AssociatedControlID="dataLuuy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLuuy" Text='<%# Bind("Luuy") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataImageLink" runat="server" Text="Image Link:" AssociatedControlID="dataImageLink" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataImageLink" Text='<%# Bind("ImageLink") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNgaysinh" runat="server" Text="Ngaysinh:" AssociatedControlID="dataNgaysinh" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNgaysinh" Text='<%# Bind("Ngaysinh", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataNgaysinh" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



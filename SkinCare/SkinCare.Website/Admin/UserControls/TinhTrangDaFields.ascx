<%@ Control Language="C#" ClassName="TinhTrangDaFields" %>

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
        <td class="literal"><asp:Label ID="lbldataTinhTrang" runat="server" Text="Tinh Trang:" AssociatedControlID="dataTinhTrang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTinhTrang" Text='<%# Bind("TinhTrang") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



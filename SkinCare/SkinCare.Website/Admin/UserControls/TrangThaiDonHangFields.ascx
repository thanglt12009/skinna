<%@ Control Language="C#" ClassName="TrangThaiDonHangFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaTrangThaiDonHang" runat="server" Text="Ma Trang Thai Don Hang:" AssociatedControlID="dataMaTrangThaiDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaTrangThaiDonHang" Text='<%# Bind("MaTrangThaiDonHang") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaTrangThaiDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaTrangThaiDonHang" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMaTrangThaiDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaTrangThaiDonHang" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaLoaiTrangThaiDonHang" runat="server" Text="Ma Loai Trang Thai Don Hang:" AssociatedControlID="dataMaLoaiTrangThaiDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaLoaiTrangThaiDonHang" Text='<%# Bind("MaLoaiTrangThaiDonHang") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaLoaiTrangThaiDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaLoaiTrangThaiDonHang" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMaLoaiTrangThaiDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaLoaiTrangThaiDonHang" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTenLoaiTrangThaiDonHang" runat="server" Text="Ten Loai Trang Thai Don Hang:" AssociatedControlID="dataTenLoaiTrangThaiDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTenLoaiTrangThaiDonHang" Text='<%# Bind("TenLoaiTrangThaiDonHang") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



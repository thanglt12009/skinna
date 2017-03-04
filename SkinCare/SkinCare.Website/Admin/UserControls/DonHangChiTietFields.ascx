<%@ Control Language="C#" ClassName="DonHangChiTietFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaDonHang" runat="server" Text="Ma Don Hang:" AssociatedControlID="dataMaDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaDonHang" Text='<%# Bind("MaDonHang") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMaDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaDonHang" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaSanPham" runat="server" Text="Ma San Pham:" AssociatedControlID="dataMaSanPham" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaSanPham" Text='<%# Bind("MaSanPham") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMaSanPham" runat="server" Display="Dynamic" ControlToValidate="dataMaSanPham" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDonGia" runat="server" Text="Don Gia:" AssociatedControlID="dataDonGia" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDonGia" Text='<%# Bind("DonGia") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDonGia" runat="server" Display="Dynamic" ControlToValidate="dataDonGia" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSoLuong" runat="server" Text="So Luong:" AssociatedControlID="dataSoLuong" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSoLuong" Text='<%# Bind("SoLuong") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSoLuong" runat="server" Display="Dynamic" ControlToValidate="dataSoLuong" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataThanhTien" runat="server" Text="Thanh Tien:" AssociatedControlID="dataThanhTien" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataThanhTien" Text='<%# Bind("ThanhTien") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataThanhTien" runat="server" Display="Dynamic" ControlToValidate="dataThanhTien" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



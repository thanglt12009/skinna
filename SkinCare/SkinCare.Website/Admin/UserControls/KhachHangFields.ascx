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
        <td class="literal"><asp:Label ID="lbldataTuoi" runat="server" Text="Tuoi:" AssociatedControlID="dataTuoi" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTuoi" Text='<%# Bind("Tuoi") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTuoi" runat="server" Display="Dynamic" ControlToValidate="dataTuoi" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGioiTinh" runat="server" Text="Gioi Tinh:" AssociatedControlID="dataGioiTinh" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGioiTinh" Text='<%# Bind("GioiTinh") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTinhTrangDa" runat="server" Text="Tinh Trang Da:" AssociatedControlID="dataTinhTrangDa" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTinhTrangDa" Text='<%# Bind("TinhTrangDa") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTayTrangToi" runat="server" Text="Tay Trang Toi:" AssociatedControlID="dataTayTrangToi" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataTayTrangToi" SelectedValue='<%# Bind("TayTrangToi") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRuaMat" runat="server" Text="Rua Mat:" AssociatedControlID="dataRuaMat" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataRuaMat" SelectedValue='<%# Bind("RuaMat") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataToner" runat="server" Text="Toner:" AssociatedControlID="dataToner" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataToner" SelectedValue='<%# Bind("Toner") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSerum" runat="server" Text="Serum:" AssociatedControlID="dataSerum" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSerum" SelectedValue='<%# Bind("Serum") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataKem" runat="server" Text="Kem:" AssociatedControlID="dataKem" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataKem" SelectedValue='<%# Bind("Kem") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSanPhamKhac" runat="server" Text="San Pham Khac:" AssociatedControlID="dataSanPhamKhac" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSanPhamKhac" SelectedValue='<%# Bind("SanPhamKhac") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
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
			
		</table>

	</ItemTemplate>
</asp:FormView>



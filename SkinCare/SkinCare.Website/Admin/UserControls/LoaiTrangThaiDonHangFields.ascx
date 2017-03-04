<%@ Control Language="C#" ClassName="LoaiTrangThaiDonHangFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaLoaiTrangThai" runat="server" Text="Ma Loai Trang Thai:" AssociatedControlID="dataMaLoaiTrangThai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaLoaiTrangThai" Text='<%# Bind("MaLoaiTrangThai") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaLoaiTrangThai" runat="server" Display="Dynamic" ControlToValidate="dataMaLoaiTrangThai" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMaLoaiTrangThai" runat="server" Display="Dynamic" ControlToValidate="dataMaLoaiTrangThai" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTenLoaiTrangThai" runat="server" Text="Ten Loai Trang Thai:" AssociatedControlID="dataTenLoaiTrangThai" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTenLoaiTrangThai" Text='<%# Bind("TenLoaiTrangThai") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



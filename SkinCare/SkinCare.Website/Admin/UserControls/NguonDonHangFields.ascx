<%@ Control Language="C#" ClassName="NguonDonHangFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataMaNguonDonHang" runat="server" Text="Ma Nguon Don Hang:" AssociatedControlID="dataMaNguonDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMaNguonDonHang" Text='<%# Bind("MaNguonDonHang") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMaNguonDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaNguonDonHang" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMaNguonDonHang" runat="server" Display="Dynamic" ControlToValidate="dataMaNguonDonHang" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTenNguonDonHang" runat="server" Text="Ten Nguon Don Hang:" AssociatedControlID="dataTenNguonDonHang" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTenNguonDonHang" Text='<%# Bind("TenNguonDonHang") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



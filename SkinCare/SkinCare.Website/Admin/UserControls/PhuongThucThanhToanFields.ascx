<%@ Control Language="C#" ClassName="PhuongThucThanhToanFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTenPhuongThucThanhToan" runat="server" Text="Ten Phuong Thuc Thanh Toan:" AssociatedControlID="dataTenPhuongThucThanhToan" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTenPhuongThucThanhToan" Text='<%# Bind("TenPhuongThucThanhToan") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



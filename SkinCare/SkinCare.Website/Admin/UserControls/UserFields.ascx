<%@ Control Language="C#" ClassName="UserFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalt" runat="server" Text="Salt:" AssociatedControlID="dataSalt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSalt" Text='<%# Bind("Salt") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSalt" runat="server" Display="Dynamic" ControlToValidate="dataSalt" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPwd" runat="server" Text="Pwd:" AssociatedControlID="dataPwd" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPwd" Text='<%# Bind("Pwd") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPwd" runat="server" Display="Dynamic" ControlToValidate="dataPwd" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserRole" runat="server" Text="User Role:" AssociatedControlID="dataUserRole" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserRole" Text='<%# Bind("UserRole") %>' MaxLength="25"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserRole" runat="server" Display="Dynamic" ControlToValidate="dataUserRole" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



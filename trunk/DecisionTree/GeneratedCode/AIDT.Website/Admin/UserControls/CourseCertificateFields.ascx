<%@ Control Language="C#" ClassName="CourseCertificateFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCertificateName" runat="server" Text="Certificate Name:" AssociatedControlID="dataCertificateName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCertificateName" Text='<%# Bind("CertificateName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCertificateId" runat="server" Text="Certificate Id:" AssociatedControlID="dataCertificateId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCertificateId" Text='<%# Bind("CertificateId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCertificateId" runat="server" Display="Dynamic" ControlToValidate="dataCertificateId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCertificateId" runat="server" Display="Dynamic" ControlToValidate="dataCertificateId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



<%@ Control Language="C#" ClassName="ClassTimeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataNote" runat="server" Text="Note:" AssociatedControlID="dataNote" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNote" Text='<%# Bind("Note") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataClassTimeId" runat="server" Text="Class Time Id:" AssociatedControlID="dataClassTimeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataClassTimeId" Text='<%# Bind("ClassTimeId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataClassTimeId" runat="server" Display="Dynamic" ControlToValidate="dataClassTimeId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataClassTimeId" runat="server" Display="Dynamic" ControlToValidate="dataClassTimeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTimeName" runat="server" Text="Time Name:" AssociatedControlID="dataTimeName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTimeName" Text='<%# Bind("TimeName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



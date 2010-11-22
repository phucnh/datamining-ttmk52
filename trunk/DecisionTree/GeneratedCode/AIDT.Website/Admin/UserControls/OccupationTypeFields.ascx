<%@ Control Language="C#" ClassName="OccupationTypeFields" %>

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
        <td class="literal"><asp:Label ID="lbldataOccupationName" runat="server" Text="Occupation Name:" AssociatedControlID="dataOccupationName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOccupationName" Text='<%# Bind("OccupationName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOccupationTypeId" runat="server" Text="Occupation Type Id:" AssociatedControlID="dataOccupationTypeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOccupationTypeId" Text='<%# Bind("OccupationTypeId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOccupationTypeId" runat="server" Display="Dynamic" ControlToValidate="dataOccupationTypeId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataOccupationTypeId" runat="server" Display="Dynamic" ControlToValidate="dataOccupationTypeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



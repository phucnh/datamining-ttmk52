<%@ Control Language="C#" ClassName="CustomerDetailsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataOccupationTypeId" runat="server" Text="Occupation Type Id:" AssociatedControlID="dataOccupationTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataOccupationTypeId" DataSourceID="OccupationTypeIdOccupationTypeDataSource" DataTextField="OccupationName" DataValueField="OccupationTypeId" SelectedValue='<%# Bind("OccupationTypeId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:OccupationTypeDataSource ID="OccupationTypeIdOccupationTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerId" Text='<%# Bind("CustomerId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBirthday" runat="server" Text="Birthday:" AssociatedControlID="dataBirthday" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBirthday" Text='<%# Bind("Birthday") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



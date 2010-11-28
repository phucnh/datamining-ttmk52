<%@ Control Language="C#" ClassName="CustomerDetailsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhoneNumber" runat="server" Text="Phone Number:" AssociatedControlID="dataPhoneNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhoneNumber" Text='<%# Bind("PhoneNumber") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBirthday" runat="server" Text="Birthday:" AssociatedControlID="dataBirthday" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBirthday" Text='<%# Bind("Birthday", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBirthday" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOccupationTypeId" runat="server" Text="Occupation Type Id:" AssociatedControlID="dataOccupationTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataOccupationTypeId" DataSourceID="OccupationTypeIdOccupationTypeDataSource" DataTextField="OccupationName" DataValueField="OccupationTypeId" SelectedValue='<%# Bind("OccupationTypeId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:OccupationTypeDataSource ID="OccupationTypeIdOccupationTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



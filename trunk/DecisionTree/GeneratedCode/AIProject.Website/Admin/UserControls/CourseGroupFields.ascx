<%@ Control Language="C#" ClassName="CourseGroupFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourseGroupId" runat="server" Text="Course Group Id:" AssociatedControlID="dataCourseGroupId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCourseGroupId" Text='<%# Bind("CourseGroupId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCourseGroupId" runat="server" Display="Dynamic" ControlToValidate="dataCourseGroupId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCourseGroupId" runat="server" Display="Dynamic" ControlToValidate="dataCourseGroupId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNote" runat="server" Text="Note:" AssociatedControlID="dataNote" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNote" Text='<%# Bind("Note") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



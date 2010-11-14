<%@ Control Language="C#" ClassName="TeacherDetailsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTeacherId" runat="server" Text="Teacher Id:" AssociatedControlID="dataTeacherId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTeacherId" Text='<%# Bind("TeacherId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTeacherId" runat="server" Display="Dynamic" ControlToValidate="dataTeacherId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTeacherId" runat="server" Display="Dynamic" ControlToValidate="dataTeacherId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTeacherName" runat="server" Text="Teacher Name:" AssociatedControlID="dataTeacherName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTeacherName" Text='<%# Bind("TeacherName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTeacherCertificate" runat="server" Text="Teacher Certificate:" AssociatedControlID="dataTeacherCertificate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTeacherCertificate" Text='<%# Bind("TeacherCertificate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTeacherCertificate" runat="server" Display="Dynamic" ControlToValidate="dataTeacherCertificate" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
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



<%@ Control Language="C#" ClassName="CourseDetailsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourseFee" runat="server" Text="Course Fee:" AssociatedControlID="dataCourseFee" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCourseFee" Text='<%# Bind("CourseFee") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCourseFee" runat="server" Display="Dynamic" ControlToValidate="dataCourseFee" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourseGroup" runat="server" Text="Course Group:" AssociatedControlID="dataCourseGroup" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCourseGroup" DataSourceID="CourseGroupCourseGroupDataSource" DataTextField="Name" DataValueField="CourseGroupId" SelectedValue='<%# Bind("CourseGroup") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CourseGroupDataSource ID="CourseGroupCourseGroupDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourseCertificate" runat="server" Text="Course Certificate:" AssociatedControlID="dataCourseCertificate" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCourseCertificate" DataSourceID="CourseCertificateCourseCertificateDataSource" DataTextField="CertificateName" DataValueField="CertificateId" SelectedValue='<%# Bind("CourseCertificate") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CourseCertificateDataSource ID="CourseCertificateCourseCertificateDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourseId" runat="server" Text="Course Id:" AssociatedControlID="dataCourseId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCourseId" Text='<%# Bind("CourseId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCourseId" runat="server" Display="Dynamic" ControlToValidate="dataCourseId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCourseId" runat="server" Display="Dynamic" ControlToValidate="dataCourseId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourseName" runat="server" Text="Course Name:" AssociatedControlID="dataCourseName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCourseName" Text='<%# Bind("CourseName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



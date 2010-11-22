<%@ Control Language="C#" ClassName="ClassDetailsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataClassId" runat="server" Text="Class Id:" AssociatedControlID="dataClassId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataClassId" Text='<%# Bind("ClassId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataClassId" runat="server" Display="Dynamic" ControlToValidate="dataClassId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataClassId" runat="server" Display="Dynamic" ControlToValidate="dataClassId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataClassName" runat="server" Text="Class Name:" AssociatedControlID="dataClassName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataClassName" Text='<%# Bind("ClassName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataClassTime" runat="server" Text="Class Time:" AssociatedControlID="dataClassTime" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataClassTime" DataSourceID="ClassTimeClassTimeDataSource" DataTextField="TimeName" DataValueField="ClassTimeId" SelectedValue='<%# Bind("ClassTime") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ClassTimeDataSource ID="ClassTimeClassTimeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCourseId" runat="server" Text="Course Id:" AssociatedControlID="dataCourseId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCourseId" DataSourceID="CourseIdCourseDetailsDataSource" DataTextField="CourseName" DataValueField="CourseId" SelectedValue='<%# Bind("CourseId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CourseDetailsDataSource ID="CourseIdCourseDetailsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTeacherId" runat="server" Text="Teacher Id:" AssociatedControlID="dataTeacherId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTeacherId" DataSourceID="TeacherIdTeacherDetailsDataSource" DataTextField="TeacherName" DataValueField="TeacherId" SelectedValue='<%# Bind("TeacherId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:TeacherDetailsDataSource ID="TeacherIdTeacherDetailsDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>



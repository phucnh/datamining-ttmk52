<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CourseCertificateEdit.aspx.cs" Inherits="CourseCertificateEdit" Title="CourseCertificate Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Course Certificate - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CertificateId" runat="server" DataSourceID="CourseCertificateDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CourseCertificateFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CourseCertificateFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CourseCertificate not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CourseCertificateDataSource ID="CourseCertificateDataSource" runat="server"
			SelectMethod="GetByCertificateId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CertificateId" QueryStringField="CertificateId" Type="String" />

			</Parameters>
		</data:CourseCertificateDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewCourseDetails1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewCourseDetails1_SelectedIndexChanged"			 			 
			DataSourceID="CourseDetailsDataSource1"
			DataKeyNames="CourseId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CourseDetails.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="CourseName" HeaderText="Course Name" SortExpression="[CourseName]" />				
				<data:HyperLinkField HeaderText="Course Certificate" DataNavigateUrlFormatString="CourseCertificateEdit.aspx?CertificateId={0}" DataNavigateUrlFields="CertificateId" DataContainer="CourseCertificateSource" DataTextField="CertificateName" />
				<asp:BoundField DataField="CourseFee" HeaderText="Course Fee" SortExpression="[CourseFee]" />				
				<data:HyperLinkField HeaderText="Course Group" DataNavigateUrlFormatString="CourseGroupEdit.aspx?CourseGroupId={0}" DataNavigateUrlFields="CourseGroupId" DataContainer="CourseGroupSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Course Details Found! </b>
				<asp:HyperLink runat="server" ID="hypCourseDetails" NavigateUrl="~/admin/CourseDetailsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CourseDetailsDataSource ID="CourseDetailsDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CourseDetailsProperty Name="CourseCertificate"/> 
					<data:CourseDetailsProperty Name="CourseGroup"/> 
					<%--<data:CourseDetailsProperty Name="ClassDetailsCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CourseDetailsFilter  Column="CourseCertificate" QueryStringField="CertificateId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CourseDetailsDataSource>		
		
		<br />
		

</asp:Content>


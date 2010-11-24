
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CourseDetails.aspx.cs" Inherits="CourseDetails" Title="CourseDetails List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Course Details List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CourseDetailsDataSource"
				DataKeyNames="CourseId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CourseDetails.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="CourseName" HeaderText="Course Name" SortExpression="[CourseName]"  />
				<data:HyperLinkField HeaderText="Course Certificate" DataNavigateUrlFormatString="CourseCertificateEdit.aspx?CertificateId={0}" DataNavigateUrlFields="CertificateId" DataContainer="CourseCertificateSource" DataTextField="CertificateName" />
				<asp:BoundField DataField="CourseFee" HeaderText="Course Fee" SortExpression="[CourseFee]"  />
				<data:HyperLinkField HeaderText="Course Group" DataNavigateUrlFormatString="CourseGroupEdit.aspx?CourseGroupId={0}" DataNavigateUrlFields="CourseGroupId" DataContainer="CourseGroupSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No CourseDetails Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCourseDetails" OnClientClick="javascript:location.href='CourseDetailsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CourseDetailsDataSource ID="CourseDetailsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
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
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CourseDetailsDataSource>
	    		
</asp:Content>




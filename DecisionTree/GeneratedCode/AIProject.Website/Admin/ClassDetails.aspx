
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ClassDetails.aspx.cs" Inherits="ClassDetails" Title="ClassDetails List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Class Details List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ClassDetailsDataSource"
				DataKeyNames="ClassId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ClassDetails.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ClassId" HeaderText="Class Id" SortExpression="[ClassId]" ReadOnly="True" />
				<asp:BoundField DataField="ClassName" HeaderText="Class Name" SortExpression="[ClassName]"  />
				<data:HyperLinkField HeaderText="Class Time" DataNavigateUrlFormatString="ClassTimeEdit.aspx?ClassTimeId={0}" DataNavigateUrlFields="ClassTimeId" DataContainer="ClassTimeSource" DataTextField="TimeName" />
				<data:HyperLinkField HeaderText="Course Id" DataNavigateUrlFormatString="CourseDetailsEdit.aspx?CourseId={0}" DataNavigateUrlFields="CourseId" DataContainer="CourseIdSource" DataTextField="CourseName" />
				<data:HyperLinkField HeaderText="Teacher Id" DataNavigateUrlFormatString="TeacherDetailsEdit.aspx?TeacherId={0}" DataNavigateUrlFields="TeacherId" DataContainer="TeacherIdSource" DataTextField="TeacherName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No ClassDetails Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnClassDetails" OnClientClick="javascript:location.href='ClassDetailsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ClassDetailsDataSource ID="ClassDetailsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ClassDetailsProperty Name="ClassTime"/> 
					<data:ClassDetailsProperty Name="CourseDetails"/> 
					<data:ClassDetailsProperty Name="TeacherDetails"/> 
					<%--<data:ClassDetailsProperty Name="ClassArrangementCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ClassDetailsDataSource>
	    		
</asp:Content>




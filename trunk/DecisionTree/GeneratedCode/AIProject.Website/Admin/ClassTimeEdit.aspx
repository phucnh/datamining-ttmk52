<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ClassTimeEdit.aspx.cs" Inherits="ClassTimeEdit" Title="ClassTime Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Class Time - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ClassTimeId" runat="server" DataSourceID="ClassTimeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ClassTimeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ClassTimeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ClassTime not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ClassTimeDataSource ID="ClassTimeDataSource" runat="server"
			SelectMethod="GetByClassTimeId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ClassTimeId" QueryStringField="ClassTimeId" Type="String" />

			</Parameters>
		</data:ClassTimeDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewClassDetails1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewClassDetails1_SelectedIndexChanged"			 			 
			DataSourceID="ClassDetailsDataSource1"
			DataKeyNames="ClassId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ClassDetails.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="ClassName" HeaderText="Class Name" SortExpression="[ClassName]" />				
				<data:HyperLinkField HeaderText="Class Time" DataNavigateUrlFormatString="ClassTimeEdit.aspx?ClassTimeId={0}" DataNavigateUrlFields="ClassTimeId" DataContainer="ClassTimeSource" DataTextField="TimeName" />
				<data:HyperLinkField HeaderText="Course Id" DataNavigateUrlFormatString="CourseDetailsEdit.aspx?CourseId={0}" DataNavigateUrlFields="CourseId" DataContainer="CourseIdSource" DataTextField="CourseName" />
				<data:HyperLinkField HeaderText="Teacher Id" DataNavigateUrlFormatString="TeacherDetailsEdit.aspx?TeacherId={0}" DataNavigateUrlFields="TeacherId" DataContainer="TeacherIdSource" DataTextField="TeacherName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Class Details Found! </b>
				<asp:HyperLink runat="server" ID="hypClassDetails" NavigateUrl="~/admin/ClassDetailsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ClassDetailsDataSource ID="ClassDetailsDataSource1" runat="server" SelectMethod="Find"
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
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ClassDetailsFilter  Column="ClassTime" QueryStringField="ClassTimeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ClassDetailsDataSource>		
		
		<br />
		

</asp:Content>


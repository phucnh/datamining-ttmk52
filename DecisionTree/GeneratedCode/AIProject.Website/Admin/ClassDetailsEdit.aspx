<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ClassDetailsEdit.aspx.cs" Inherits="ClassDetailsEdit" Title="ClassDetails Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Class Details - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ClassId" runat="server" DataSourceID="ClassDetailsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ClassDetailsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ClassDetailsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ClassDetails not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ClassDetailsDataSource ID="ClassDetailsDataSource" runat="server"
			SelectMethod="GetByClassId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ClassId" QueryStringField="ClassId" Type="String" />

			</Parameters>
		</data:ClassDetailsDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewClassArrangement1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewClassArrangement1_SelectedIndexChanged"			 			 
			DataSourceID="ClassArrangementDataSource1"
			DataKeyNames="CustomerId, ClassId, CreateDate"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ClassArrangement.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerDetailsEdit.aspx?CustomerId={0}" DataNavigateUrlFields="CustomerId" DataContainer="CustomerIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Class Id" DataNavigateUrlFormatString="ClassDetailsEdit.aspx?ClassId={0}" DataNavigateUrlFields="ClassId" DataContainer="ClassIdSource" DataTextField="ClassName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Class Arrangement Found! </b>
				<asp:HyperLink runat="server" ID="hypClassArrangement" NavigateUrl="~/admin/ClassArrangementEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ClassArrangementDataSource ID="ClassArrangementDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ClassArrangementProperty Name="ClassDetails"/> 
					<data:ClassArrangementProperty Name="CustomerDetails"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ClassArrangementFilter  Column="ClassId" QueryStringField="ClassId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ClassArrangementDataSource>		
		
		<br />
		

</asp:Content>


<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerDetailsEdit.aspx.cs" Inherits="CustomerDetailsEdit" Title="CustomerDetails Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Details - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CustomerId" runat="server" DataSourceID="CustomerDetailsDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerDetailsFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerDetailsFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CustomerDetails not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CustomerDetailsDataSource ID="CustomerDetailsDataSource" runat="server"
			SelectMethod="GetByCustomerId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CustomerId" QueryStringField="CustomerId" Type="String" />

			</Parameters>
		</data:CustomerDetailsDataSource>
		
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
						<data:ClassArrangementFilter  Column="CustomerId" QueryStringField="CustomerId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ClassArrangementDataSource>		
		
		<br />
		

</asp:Content>


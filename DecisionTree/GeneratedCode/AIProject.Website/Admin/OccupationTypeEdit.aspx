<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="OccupationTypeEdit.aspx.cs" Inherits="OccupationTypeEdit" Title="OccupationType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Occupation Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="OccupationTypeId" runat="server" DataSourceID="OccupationTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/OccupationTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/OccupationTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>OccupationType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:OccupationTypeDataSource ID="OccupationTypeDataSource" runat="server"
			SelectMethod="GetByOccupationTypeId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="OccupationTypeId" QueryStringField="OccupationTypeId" Type="String" />

			</Parameters>
		</data:OccupationTypeDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewCustomerDetails1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewCustomerDetails1_SelectedIndexChanged"			 			 
			DataSourceID="CustomerDetailsDataSource1"
			DataKeyNames="CustomerId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CustomerDetails.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="[Birthday]" />				
				<data:HyperLinkField HeaderText="Occupation Type Id" DataNavigateUrlFormatString="OccupationTypeEdit.aspx?OccupationTypeId={0}" DataNavigateUrlFields="OccupationTypeId" DataContainer="OccupationTypeIdSource" DataTextField="OccupationName" />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />				
				<asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="[PhoneNumber]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Details Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomerDetails" NavigateUrl="~/admin/CustomerDetailsEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerDetailsDataSource ID="CustomerDetailsDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerDetailsProperty Name="OccupationType"/> 
					<%--<data:CustomerDetailsProperty Name="ClassArrangementCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerDetailsFilter  Column="OccupationTypeId" QueryStringField="OccupationTypeId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDetailsDataSource>		
		
		<br />
		

</asp:Content>


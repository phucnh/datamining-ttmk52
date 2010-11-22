
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerDetails.aspx.cs" Inherits="CustomerDetails" Title="CustomerDetails List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Details List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CustomerDetailsDataSource"
				DataKeyNames="CustomerId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CustomerDetails.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerId]" ReadOnly="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="Birthday" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Birthday" SortExpression="[Birthday]"  />
				<data:HyperLinkField HeaderText="Occupation Type Id" DataNavigateUrlFormatString="OccupationTypeEdit.aspx?OccupationTypeId={0}" DataNavigateUrlFields="OccupationTypeId" DataContainer="OccupationTypeIdSource" DataTextField="OccupationName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No CustomerDetails Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCustomerDetails" OnClientClick="javascript:location.href='CustomerDetailsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:CustomerDetailsDataSource ID="CustomerDetailsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerDetailsProperty Name="OccupationType"/> 
					<%--<data:CustomerDetailsProperty Name="ClassArrangementCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CustomerDetailsDataSource>
	    		
</asp:Content>




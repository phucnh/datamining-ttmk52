
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ClassArrangement.aspx.cs" Inherits="ClassArrangement" Title="ClassArrangement List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Class Arrangement List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ClassArrangementDataSource"
				DataKeyNames="CustomerId, ClassId, CreateDate"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ClassArrangement.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerDetailsEdit.aspx?CustomerId={0}" DataNavigateUrlFields="CustomerId" DataContainer="CustomerIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Class Id" DataNavigateUrlFormatString="ClassDetailsEdit.aspx?ClassId={0}" DataNavigateUrlFields="ClassId" DataContainer="ClassIdSource" DataTextField="ClassName" />
				<asp:BoundField DataField="CreateDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Create Date" SortExpression="[CreateDate]" ReadOnly="True" />
			</Columns>
			<EmptyDataTemplate>
				<b>No ClassArrangement Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnClassArrangement" OnClientClick="javascript:location.href='ClassArrangementEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:ClassArrangementDataSource ID="ClassArrangementDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ClassArrangementProperty Name="ClassDetails"/> 
					<data:ClassArrangementProperty Name="CustomerDetails"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ClassArrangementDataSource>
	    		
</asp:Content>




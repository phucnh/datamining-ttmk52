
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TeacherDetails.aspx.cs" Inherits="TeacherDetails" Title="TeacherDetails List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Teacher Details List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TeacherDetailsDataSource"
				DataKeyNames="TeacherId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TeacherDetails.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="TeacherName" HeaderText="Teacher Name" SortExpression="[TeacherName]"  />
				<asp:BoundField DataField="TeacherCertificate" HeaderText="Teacher Certificate" SortExpression="[TeacherCertificate]"  />
				<asp:BoundField DataField="Note" HeaderText="Note" SortExpression="[Note]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TeacherDetails Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTeacherDetails" OnClientClick="javascript:location.href='TeacherDetailsEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:TeacherDetailsDataSource ID="TeacherDetailsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:TeacherDetailsDataSource>
	    		
</asp:Content>




<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ClassArrangementEdit.aspx.cs" Inherits="ClassArrangementEdit" Title="ClassArrangement Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Class Arrangement - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="CustomerId, ClassId, CreateDate" runat="server" DataSourceID="ClassArrangementDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ClassArrangementFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ClassArrangementFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ClassArrangement not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ClassArrangementDataSource ID="ClassArrangementDataSource" runat="server"
			SelectMethod="GetByCustomerIdClassIdCreateDate"
		>
			<Parameters>
				<asp:QueryStringParameter Name="CustomerId" QueryStringField="CustomerId" Type="String" />
<asp:QueryStringParameter Name="ClassId" QueryStringField="ClassId" Type="String" />
<asp:QueryStringParameter Name="CreateDate" QueryStringField="CreateDate" Type="String" />

			</Parameters>
		</data:ClassArrangementDataSource>
		
		<br />


</asp:Content>



#region Imports...
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AIDT.Web.UI;
#endregion

public partial class OccupationTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "OccupationTypeEdit.aspx?{0}", OccupationTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "OccupationTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "OccupationType.aspx");
		FormUtil.SetDefaultMode(FormView1, "OccupationTypeId");
	}
	protected void GridViewCustomerDetails1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CustomerId={0}", GridViewCustomerDetails1.SelectedDataKey.Values[0]);
		Response.Redirect("CustomerDetailsEdit.aspx?" + urlParams, true);		
	}	
}



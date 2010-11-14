
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
using AIProject.Web.UI;
#endregion

public partial class CustomerDetailsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CustomerDetailsEdit.aspx?{0}", CustomerDetailsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CustomerDetailsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CustomerDetails.aspx");
		FormUtil.SetDefaultMode(FormView1, "CustomerId");
	}
	protected void GridViewClassArrangement1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CustomerId={0}&ClassId={1}&CreateDate={2}", GridViewClassArrangement1.SelectedDataKey.Values[0], GridViewClassArrangement1.SelectedDataKey.Values[1], GridViewClassArrangement1.SelectedDataKey.Values[2]);
		Response.Redirect("ClassArrangementEdit.aspx?" + urlParams, true);		
	}	
}



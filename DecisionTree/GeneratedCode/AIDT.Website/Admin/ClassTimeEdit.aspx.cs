
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

public partial class ClassTimeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ClassTimeEdit.aspx?{0}", ClassTimeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ClassTimeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ClassTime.aspx");
		FormUtil.SetDefaultMode(FormView1, "ClassTimeId");
	}
	protected void GridViewClassDetails1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("ClassId={0}", GridViewClassDetails1.SelectedDataKey.Values[0]);
		Response.Redirect("ClassDetailsEdit.aspx?" + urlParams, true);		
	}	
}



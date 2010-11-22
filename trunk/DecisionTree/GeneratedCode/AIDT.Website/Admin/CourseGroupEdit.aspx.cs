
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

public partial class CourseGroupEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CourseGroupEdit.aspx?{0}", CourseGroupDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CourseGroupEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CourseGroup.aspx");
		FormUtil.SetDefaultMode(FormView1, "CourseGroupId");
	}
	protected void GridViewCourseDetails1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CourseId={0}", GridViewCourseDetails1.SelectedDataKey.Values[0]);
		Response.Redirect("CourseDetailsEdit.aspx?" + urlParams, true);		
	}	
}



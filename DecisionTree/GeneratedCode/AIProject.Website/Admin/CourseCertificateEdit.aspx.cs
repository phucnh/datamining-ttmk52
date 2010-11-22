
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

public partial class CourseCertificateEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CourseCertificateEdit.aspx?{0}", CourseCertificateDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CourseCertificateEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CourseCertificate.aspx");
		FormUtil.SetDefaultMode(FormView1, "CertificateId");
	}
	protected void GridViewCourseDetails1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("CourseId={0}", GridViewCourseDetails1.SelectedDataKey.Values[0]);
		Response.Redirect("CourseDetailsEdit.aspx?" + urlParams, true);		
	}	
}



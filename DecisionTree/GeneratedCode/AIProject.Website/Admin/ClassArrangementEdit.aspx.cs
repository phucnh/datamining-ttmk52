
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

public partial class ClassArrangementEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ClassArrangementEdit.aspx?{0}", ClassArrangementDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ClassArrangementEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ClassArrangement.aspx");
		FormUtil.SetDefaultMode(FormView1, "CustomerId");
	}
}



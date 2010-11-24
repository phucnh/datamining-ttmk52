	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using AIProject.Entities;
using AIProject.Entities.Validation;

using AIProject.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace AIProject.Services
{		
	/// <summary>
	/// An component type implementation of the 'CourseCertificate' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CourseCertificateService : AIProject.Services.CourseCertificateServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CourseCertificateService class.
		/// </summary>
		public CourseCertificateService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace

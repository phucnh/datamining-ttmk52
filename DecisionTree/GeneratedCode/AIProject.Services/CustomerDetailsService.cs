	

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
	/// An component type implementation of the 'CustomerDetails' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class CustomerDetailsService : AIProject.Services.CustomerDetailsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CustomerDetailsService class.
		/// </summary>
		public CustomerDetailsService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace

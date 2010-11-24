	

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
	/// An component type implementation of the 'ClassDetails' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ClassDetailsService : AIProject.Services.ClassDetailsServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ClassDetailsService class.
		/// </summary>
		public ClassDetailsService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace

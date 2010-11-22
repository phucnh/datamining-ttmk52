	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using AIDT.Entities;
using AIDT.Entities.Validation;

using AIDT.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace AIDT.Services
{		
	/// <summary>
	/// An component type implementation of the 'OccupationType' table.
	/// </summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class OccupationTypeService : AIDT.Services.OccupationTypeServiceBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the OccupationTypeService class.
		/// </summary>
		public OccupationTypeService() : base()
		{
		}
		#endregion Constructors
		
	}//End Class

} // end namespace

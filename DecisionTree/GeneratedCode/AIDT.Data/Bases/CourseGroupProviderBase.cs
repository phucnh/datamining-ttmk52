#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using AIDT.Entities;
using AIDT.Data;

#endregion

namespace AIDT.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="CourseGroupProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CourseGroupProviderBase : CourseGroupProviderBaseCore
	{
	} // end class
} // end namespace

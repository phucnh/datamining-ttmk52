﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using AIProject.Entities;
using AIProject.Data;

#endregion

namespace AIProject.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ClassDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClassDetailsProviderBase : ClassDetailsProviderBaseCore
	{
	} // end class
} // end namespace

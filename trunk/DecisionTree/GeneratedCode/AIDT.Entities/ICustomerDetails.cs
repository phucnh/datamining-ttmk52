﻿using System;
using System.ComponentModel;

namespace AIDT.Entities
{
	/// <summary>
	///		The data structure representation of the 'CustomerDetails' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICustomerDetails 
	{
		/// <summary>			
		/// CustomerId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "CustomerDetails"</remarks>
		System.Int32 CustomerId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalCustomerId { get; set; }
			
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// Birthday : 
		/// </summary>
		System.String  Birthday  { get; set; }
		
		/// <summary>
		/// OccupationTypeId : 
		/// </summary>
		System.Int32?  OccupationTypeId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _classArrangementCustomerId
		/// </summary>	
		TList<ClassArrangement> ClassArrangementCollection {  get;  set;}	

		#endregion Data Properties

	}
}



﻿using System;
using System.ComponentModel;

namespace AIProject.Entities
{
	/// <summary>
	///		The data structure representation of the 'OccupationType' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IOccupationType 
	{
		/// <summary>			
		/// OccupationTypeId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "OccupationType"</remarks>
		System.Int32 OccupationTypeId { get; set; }
				
		
		
		/// <summary>
		/// OccupationName : 
		/// </summary>
		System.String  OccupationName  { get; set; }
		
		/// <summary>
		/// Note : 
		/// </summary>
		System.String  Note  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _customerDetailsOccupationTypeId
		/// </summary>	
		TList<CustomerDetails> CustomerDetailsCollection {  get;  set;}	

		#endregion Data Properties

	}
}



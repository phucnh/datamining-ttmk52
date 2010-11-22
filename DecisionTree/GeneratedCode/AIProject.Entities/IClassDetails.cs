﻿using System;
using System.ComponentModel;

namespace AIProject.Entities
{
	/// <summary>
	///		The data structure representation of the 'ClassDetails' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IClassDetails 
	{
		/// <summary>			
		/// ClassId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ClassDetails"</remarks>
		System.Int32 ClassId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalClassId { get; set; }
			
		
		
		/// <summary>
		/// ClassName : 
		/// </summary>
		System.String  ClassName  { get; set; }
		
		/// <summary>
		/// ClassTime : 
		/// </summary>
		System.Int32?  ClassTime  { get; set; }
		
		/// <summary>
		/// CourseId : 
		/// </summary>
		System.Int32?  CourseId  { get; set; }
		
		/// <summary>
		/// TeacherId : 
		/// </summary>
		System.Int32?  TeacherId  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _classArrangementClassId
		/// </summary>	
		TList<ClassArrangement> ClassArrangementCollection {  get;  set;}	

		#endregion Data Properties

	}
}



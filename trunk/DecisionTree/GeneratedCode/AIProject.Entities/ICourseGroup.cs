﻿using System;
using System.ComponentModel;

namespace AIProject.Entities
{
	/// <summary>
	///		The data structure representation of the 'CourseGroup' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICourseGroup 
	{
		/// <summary>			
		/// CourseGroupId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "CourseGroup"</remarks>
		System.Int32 CourseGroupId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalCourseGroupId { get; set; }
			
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		System.String  Name  { get; set; }
		
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
		///	which are related to this object through the relation _courseDetailsCourseGroup
		/// </summary>	
		TList<CourseDetails> CourseDetailsCollection {  get;  set;}	

		#endregion Data Properties

	}
}



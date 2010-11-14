﻿using System;
using System.ComponentModel;

namespace AIProject.Entities
{
	/// <summary>
	///		The data structure representation of the 'CourseDetails' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICourseDetails 
	{
		/// <summary>			
		/// CourseId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "CourseDetails"</remarks>
		System.Int32 CourseId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalCourseId { get; set; }
			
		
		
		/// <summary>
		/// CourseName : 
		/// </summary>
		System.String  CourseName  { get; set; }
		
		/// <summary>
		/// CourseCertificate : 
		/// </summary>
		System.Int32?  CourseCertificate  { get; set; }
		
		/// <summary>
		/// CourseFee : 
		/// </summary>
		System.Double?  CourseFee  { get; set; }
		
		/// <summary>
		/// CourseGroup : 
		/// </summary>
		System.Int32?  CourseGroup  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _classDetailsCourseId
		/// </summary>	
		TList<ClassDetails> ClassDetailsCollection {  get;  set;}	

		#endregion Data Properties

	}
}


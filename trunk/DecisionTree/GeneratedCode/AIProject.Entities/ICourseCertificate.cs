﻿using System;
using System.ComponentModel;

namespace AIProject.Entities
{
	/// <summary>
	///		The data structure representation of the 'CourseCertificate' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICourseCertificate 
	{
		/// <summary>			
		/// CertificateId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "CourseCertificate"</remarks>
		System.Int32 CertificateId { get; set; }
				
		
		
		/// <summary>
		/// CertificateName : 
		/// </summary>
		System.String  CertificateName  { get; set; }
		
		/// <summary>
		/// Description : 
		/// </summary>
		System.String  Description  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _courseDetailsCourseCertificate
		/// </summary>	
		TList<CourseDetails> CourseDetailsCollection {  get;  set;}	

		#endregion Data Properties

	}
}




#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using AIDT.Entities;

#endregion

namespace AIDT.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current CourseGroupProviderBase instance.
		///</summary>
		public virtual CourseGroupProviderBase CourseGroupProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OccupationTypeProviderBase instance.
		///</summary>
		public virtual OccupationTypeProviderBase OccupationTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerDetailsProviderBase instance.
		///</summary>
		public virtual CustomerDetailsProviderBase CustomerDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CourseCertificateProviderBase instance.
		///</summary>
		public virtual CourseCertificateProviderBase CourseCertificateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CourseDetailsProviderBase instance.
		///</summary>
		public virtual CourseDetailsProviderBase CourseDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TeacherDetailsProviderBase instance.
		///</summary>
		public virtual TeacherDetailsProviderBase TeacherDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClassTimeProviderBase instance.
		///</summary>
		public virtual ClassTimeProviderBase ClassTimeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClassDetailsProviderBase instance.
		///</summary>
		public virtual ClassDetailsProviderBase ClassDetailsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ClassArrangementProviderBase instance.
		///</summary>
		public virtual ClassArrangementProviderBase ClassArrangementProvider{get {throw new NotImplementedException();}}
		
		
	}
}

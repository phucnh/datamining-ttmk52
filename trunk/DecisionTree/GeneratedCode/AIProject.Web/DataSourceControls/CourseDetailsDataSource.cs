#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using AIProject.Entities;
using AIProject.Data;
using AIProject.Data.Bases;
using AIProject.Services;
#endregion

namespace AIProject.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.CourseDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CourseDetailsDataSourceDesigner))]
	public class CourseDetailsDataSource : ProviderDataSource<CourseDetails, CourseDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDetailsDataSource class.
		/// </summary>
		public CourseDetailsDataSource() : base(new CourseDetailsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CourseDetailsDataSourceView used by the CourseDetailsDataSource.
		/// </summary>
		protected CourseDetailsDataSourceView CourseDetailsView
		{
			get { return ( View as CourseDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CourseDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public CourseDetailsSelectMethod SelectMethod
		{
			get
			{
				CourseDetailsSelectMethod selectMethod = CourseDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CourseDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CourseDetailsDataSourceView class that is to be
		/// used by the CourseDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the CourseDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<CourseDetails, CourseDetailsKey> GetNewDataSourceView()
		{
			return new CourseDetailsDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the CourseDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CourseDetailsDataSourceView : ProviderDataSourceView<CourseDetails, CourseDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CourseDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CourseDetailsDataSourceView(CourseDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CourseDetailsDataSource CourseDetailsOwner
		{
			get { return Owner as CourseDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CourseDetailsSelectMethod SelectMethod
		{
			get { return CourseDetailsOwner.SelectMethod; }
			set { CourseDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CourseDetailsService CourseDetailsProvider
		{
			get { return Provider as CourseDetailsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CourseDetails> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CourseDetails> results = null;
			CourseDetails item;
			count = 0;
			
			System.Int32 _courseId;
			System.Int32? _courseCertificate_nullable;
			System.Int32? _courseGroup_nullable;

			switch ( SelectMethod )
			{
				case CourseDetailsSelectMethod.Get:
					CourseDetailsKey entityKey  = new CourseDetailsKey();
					entityKey.Load(values);
					item = CourseDetailsProvider.Get(entityKey);
					results = new TList<CourseDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CourseDetailsSelectMethod.GetAll:
                    results = CourseDetailsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CourseDetailsSelectMethod.GetPaged:
					results = CourseDetailsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CourseDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = CourseDetailsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CourseDetailsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CourseDetailsSelectMethod.GetByCourseId:
					_courseId = ( values["CourseId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CourseId"], typeof(System.Int32)) : (int)0;
					item = CourseDetailsProvider.GetByCourseId(_courseId);
					results = new TList<CourseDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CourseDetailsSelectMethod.GetByCourseCertificate:
					_courseCertificate_nullable = (System.Int32?) EntityUtil.ChangeType(values["CourseCertificate"], typeof(System.Int32?));
					results = CourseDetailsProvider.GetByCourseCertificate(_courseCertificate_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case CourseDetailsSelectMethod.GetByCourseGroup:
					_courseGroup_nullable = (System.Int32?) EntityUtil.ChangeType(values["CourseGroup"], typeof(System.Int32?));
					results = CourseDetailsProvider.GetByCourseGroup(_courseGroup_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == CourseDetailsSelectMethod.Get || SelectMethod == CourseDetailsSelectMethod.GetByCourseId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				CourseDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CourseDetailsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<CourseDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CourseDetailsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CourseDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CourseDetailsDataSource class.
	/// </summary>
	public class CourseDetailsDataSourceDesigner : ProviderDataSourceDesigner<CourseDetails, CourseDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the CourseDetailsDataSourceDesigner class.
		/// </summary>
		public CourseDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseDetailsSelectMethod SelectMethod
		{
			get { return ((CourseDetailsDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new CourseDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CourseDetailsDataSourceActionList

	/// <summary>
	/// Supports the CourseDetailsDataSourceDesigner class.
	/// </summary>
	internal class CourseDetailsDataSourceActionList : DesignerActionList
	{
		private CourseDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CourseDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CourseDetailsDataSourceActionList(CourseDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseDetailsSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion CourseDetailsDataSourceActionList
	
	#endregion CourseDetailsDataSourceDesigner
	
	#region CourseDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CourseDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum CourseDetailsSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByCourseId method.
		/// </summary>
		GetByCourseId,
		/// <summary>
		/// Represents the GetByCourseCertificate method.
		/// </summary>
		GetByCourseCertificate,
		/// <summary>
		/// Represents the GetByCourseGroup method.
		/// </summary>
		GetByCourseGroup
	}
	
	#endregion CourseDetailsSelectMethod

	#region CourseDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseDetailsFilter : SqlFilter<CourseDetailsColumn>
	{
	}
	
	#endregion CourseDetailsFilter

	#region CourseDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseDetailsExpressionBuilder : SqlExpressionBuilder<CourseDetailsColumn>
	{
	}
	
	#endregion CourseDetailsExpressionBuilder	

	#region CourseDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CourseDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseDetailsProperty : ChildEntityProperty<CourseDetailsChildEntityTypes>
	{
	}
	
	#endregion CourseDetailsProperty
}


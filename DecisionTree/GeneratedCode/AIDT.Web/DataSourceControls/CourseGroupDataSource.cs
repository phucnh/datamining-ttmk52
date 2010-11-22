#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using AIDT.Entities;
using AIDT.Data;
using AIDT.Data.Bases;
using AIDT.Services;
#endregion

namespace AIDT.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.CourseGroupProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CourseGroupDataSourceDesigner))]
	public class CourseGroupDataSource : ProviderDataSource<CourseGroup, CourseGroupKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseGroupDataSource class.
		/// </summary>
		public CourseGroupDataSource() : base(new CourseGroupService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CourseGroupDataSourceView used by the CourseGroupDataSource.
		/// </summary>
		protected CourseGroupDataSourceView CourseGroupView
		{
			get { return ( View as CourseGroupDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CourseGroupDataSource control invokes to retrieve data.
		/// </summary>
		public CourseGroupSelectMethod SelectMethod
		{
			get
			{
				CourseGroupSelectMethod selectMethod = CourseGroupSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CourseGroupSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CourseGroupDataSourceView class that is to be
		/// used by the CourseGroupDataSource.
		/// </summary>
		/// <returns>An instance of the CourseGroupDataSourceView class.</returns>
		protected override BaseDataSourceView<CourseGroup, CourseGroupKey> GetNewDataSourceView()
		{
			return new CourseGroupDataSourceView(this, DefaultViewName);
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
	/// Supports the CourseGroupDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CourseGroupDataSourceView : ProviderDataSourceView<CourseGroup, CourseGroupKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseGroupDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CourseGroupDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CourseGroupDataSourceView(CourseGroupDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CourseGroupDataSource CourseGroupOwner
		{
			get { return Owner as CourseGroupDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CourseGroupSelectMethod SelectMethod
		{
			get { return CourseGroupOwner.SelectMethod; }
			set { CourseGroupOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CourseGroupService CourseGroupProvider
		{
			get { return Provider as CourseGroupService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CourseGroup> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CourseGroup> results = null;
			CourseGroup item;
			count = 0;
			
			System.Int32 _courseGroupId;

			switch ( SelectMethod )
			{
				case CourseGroupSelectMethod.Get:
					CourseGroupKey entityKey  = new CourseGroupKey();
					entityKey.Load(values);
					item = CourseGroupProvider.Get(entityKey);
					results = new TList<CourseGroup>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CourseGroupSelectMethod.GetAll:
                    results = CourseGroupProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CourseGroupSelectMethod.GetPaged:
					results = CourseGroupProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CourseGroupSelectMethod.Find:
					if ( FilterParameters != null )
						results = CourseGroupProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CourseGroupProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CourseGroupSelectMethod.GetByCourseGroupId:
					_courseGroupId = ( values["CourseGroupId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CourseGroupId"], typeof(System.Int32)) : (int)0;
					item = CourseGroupProvider.GetByCourseGroupId(_courseGroupId);
					results = new TList<CourseGroup>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == CourseGroupSelectMethod.Get || SelectMethod == CourseGroupSelectMethod.GetByCourseGroupId )
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
				CourseGroup entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CourseGroupProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CourseGroup> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CourseGroupProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CourseGroupDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CourseGroupDataSource class.
	/// </summary>
	public class CourseGroupDataSourceDesigner : ProviderDataSourceDesigner<CourseGroup, CourseGroupKey>
	{
		/// <summary>
		/// Initializes a new instance of the CourseGroupDataSourceDesigner class.
		/// </summary>
		public CourseGroupDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseGroupSelectMethod SelectMethod
		{
			get { return ((CourseGroupDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CourseGroupDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CourseGroupDataSourceActionList

	/// <summary>
	/// Supports the CourseGroupDataSourceDesigner class.
	/// </summary>
	internal class CourseGroupDataSourceActionList : DesignerActionList
	{
		private CourseGroupDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CourseGroupDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CourseGroupDataSourceActionList(CourseGroupDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseGroupSelectMethod SelectMethod
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

	#endregion CourseGroupDataSourceActionList
	
	#endregion CourseGroupDataSourceDesigner
	
	#region CourseGroupSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CourseGroupDataSource.SelectMethod property.
	/// </summary>
	public enum CourseGroupSelectMethod
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
		/// Represents the GetByCourseGroupId method.
		/// </summary>
		GetByCourseGroupId
	}
	
	#endregion CourseGroupSelectMethod

	#region CourseGroupFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseGroupFilter : SqlFilter<CourseGroupColumn>
	{
	}
	
	#endregion CourseGroupFilter

	#region CourseGroupExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseGroupExpressionBuilder : SqlExpressionBuilder<CourseGroupColumn>
	{
	}
	
	#endregion CourseGroupExpressionBuilder	

	#region CourseGroupProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CourseGroupChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseGroupProperty : ChildEntityProperty<CourseGroupChildEntityTypes>
	{
	}
	
	#endregion CourseGroupProperty
}


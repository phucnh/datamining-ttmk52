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
	/// Represents the DataRepository.TeacherDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(TeacherDetailsDataSourceDesigner))]
	public class TeacherDetailsDataSource : ProviderDataSource<TeacherDetails, TeacherDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsDataSource class.
		/// </summary>
		public TeacherDetailsDataSource() : base(new TeacherDetailsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the TeacherDetailsDataSourceView used by the TeacherDetailsDataSource.
		/// </summary>
		protected TeacherDetailsDataSourceView TeacherDetailsView
		{
			get { return ( View as TeacherDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the TeacherDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public TeacherDetailsSelectMethod SelectMethod
		{
			get
			{
				TeacherDetailsSelectMethod selectMethod = TeacherDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (TeacherDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the TeacherDetailsDataSourceView class that is to be
		/// used by the TeacherDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the TeacherDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<TeacherDetails, TeacherDetailsKey> GetNewDataSourceView()
		{
			return new TeacherDetailsDataSourceView(this, DefaultViewName);
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
	/// Supports the TeacherDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class TeacherDetailsDataSourceView : ProviderDataSourceView<TeacherDetails, TeacherDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the TeacherDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public TeacherDetailsDataSourceView(TeacherDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal TeacherDetailsDataSource TeacherDetailsOwner
		{
			get { return Owner as TeacherDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal TeacherDetailsSelectMethod SelectMethod
		{
			get { return TeacherDetailsOwner.SelectMethod; }
			set { TeacherDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal TeacherDetailsService TeacherDetailsProvider
		{
			get { return Provider as TeacherDetailsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<TeacherDetails> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<TeacherDetails> results = null;
			TeacherDetails item;
			count = 0;
			
			System.Int32 _teacherId;

			switch ( SelectMethod )
			{
				case TeacherDetailsSelectMethod.Get:
					TeacherDetailsKey entityKey  = new TeacherDetailsKey();
					entityKey.Load(values);
					item = TeacherDetailsProvider.Get(entityKey);
					results = new TList<TeacherDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case TeacherDetailsSelectMethod.GetAll:
                    results = TeacherDetailsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case TeacherDetailsSelectMethod.GetPaged:
					results = TeacherDetailsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case TeacherDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = TeacherDetailsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = TeacherDetailsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case TeacherDetailsSelectMethod.GetByTeacherId:
					_teacherId = ( values["TeacherId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["TeacherId"], typeof(System.Int32)) : (int)0;
					item = TeacherDetailsProvider.GetByTeacherId(_teacherId);
					results = new TList<TeacherDetails>();
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
			if ( SelectMethod == TeacherDetailsSelectMethod.Get || SelectMethod == TeacherDetailsSelectMethod.GetByTeacherId )
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
				TeacherDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					TeacherDetailsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<TeacherDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			TeacherDetailsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region TeacherDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the TeacherDetailsDataSource class.
	/// </summary>
	public class TeacherDetailsDataSourceDesigner : ProviderDataSourceDesigner<TeacherDetails, TeacherDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the TeacherDetailsDataSourceDesigner class.
		/// </summary>
		public TeacherDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TeacherDetailsSelectMethod SelectMethod
		{
			get { return ((TeacherDetailsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new TeacherDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region TeacherDetailsDataSourceActionList

	/// <summary>
	/// Supports the TeacherDetailsDataSourceDesigner class.
	/// </summary>
	internal class TeacherDetailsDataSourceActionList : DesignerActionList
	{
		private TeacherDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public TeacherDetailsDataSourceActionList(TeacherDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public TeacherDetailsSelectMethod SelectMethod
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

	#endregion TeacherDetailsDataSourceActionList
	
	#endregion TeacherDetailsDataSourceDesigner
	
	#region TeacherDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the TeacherDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum TeacherDetailsSelectMethod
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
		/// Represents the GetByTeacherId method.
		/// </summary>
		GetByTeacherId
	}
	
	#endregion TeacherDetailsSelectMethod

	#region TeacherDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherDetailsFilter : SqlFilter<TeacherDetailsColumn>
	{
	}
	
	#endregion TeacherDetailsFilter

	#region TeacherDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherDetailsExpressionBuilder : SqlExpressionBuilder<TeacherDetailsColumn>
	{
	}
	
	#endregion TeacherDetailsExpressionBuilder	

	#region TeacherDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;TeacherDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherDetailsProperty : ChildEntityProperty<TeacherDetailsChildEntityTypes>
	{
	}
	
	#endregion TeacherDetailsProperty
}


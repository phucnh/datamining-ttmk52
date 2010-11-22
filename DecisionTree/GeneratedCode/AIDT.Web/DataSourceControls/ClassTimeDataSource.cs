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
	/// Represents the DataRepository.ClassTimeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ClassTimeDataSourceDesigner))]
	public class ClassTimeDataSource : ProviderDataSource<ClassTime, ClassTimeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassTimeDataSource class.
		/// </summary>
		public ClassTimeDataSource() : base(new ClassTimeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ClassTimeDataSourceView used by the ClassTimeDataSource.
		/// </summary>
		protected ClassTimeDataSourceView ClassTimeView
		{
			get { return ( View as ClassTimeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ClassTimeDataSource control invokes to retrieve data.
		/// </summary>
		public ClassTimeSelectMethod SelectMethod
		{
			get
			{
				ClassTimeSelectMethod selectMethod = ClassTimeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ClassTimeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ClassTimeDataSourceView class that is to be
		/// used by the ClassTimeDataSource.
		/// </summary>
		/// <returns>An instance of the ClassTimeDataSourceView class.</returns>
		protected override BaseDataSourceView<ClassTime, ClassTimeKey> GetNewDataSourceView()
		{
			return new ClassTimeDataSourceView(this, DefaultViewName);
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
	/// Supports the ClassTimeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ClassTimeDataSourceView : ProviderDataSourceView<ClassTime, ClassTimeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassTimeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ClassTimeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ClassTimeDataSourceView(ClassTimeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ClassTimeDataSource ClassTimeOwner
		{
			get { return Owner as ClassTimeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ClassTimeSelectMethod SelectMethod
		{
			get { return ClassTimeOwner.SelectMethod; }
			set { ClassTimeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ClassTimeService ClassTimeProvider
		{
			get { return Provider as ClassTimeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ClassTime> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ClassTime> results = null;
			ClassTime item;
			count = 0;
			
			System.Int32 _classTimeId;

			switch ( SelectMethod )
			{
				case ClassTimeSelectMethod.Get:
					ClassTimeKey entityKey  = new ClassTimeKey();
					entityKey.Load(values);
					item = ClassTimeProvider.Get(entityKey);
					results = new TList<ClassTime>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ClassTimeSelectMethod.GetAll:
                    results = ClassTimeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ClassTimeSelectMethod.GetPaged:
					results = ClassTimeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ClassTimeSelectMethod.Find:
					if ( FilterParameters != null )
						results = ClassTimeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ClassTimeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ClassTimeSelectMethod.GetByClassTimeId:
					_classTimeId = ( values["ClassTimeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ClassTimeId"], typeof(System.Int32)) : (int)0;
					item = ClassTimeProvider.GetByClassTimeId(_classTimeId);
					results = new TList<ClassTime>();
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
			if ( SelectMethod == ClassTimeSelectMethod.Get || SelectMethod == ClassTimeSelectMethod.GetByClassTimeId )
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
				ClassTime entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ClassTimeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ClassTime> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ClassTimeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ClassTimeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ClassTimeDataSource class.
	/// </summary>
	public class ClassTimeDataSourceDesigner : ProviderDataSourceDesigner<ClassTime, ClassTimeKey>
	{
		/// <summary>
		/// Initializes a new instance of the ClassTimeDataSourceDesigner class.
		/// </summary>
		public ClassTimeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClassTimeSelectMethod SelectMethod
		{
			get { return ((ClassTimeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ClassTimeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ClassTimeDataSourceActionList

	/// <summary>
	/// Supports the ClassTimeDataSourceDesigner class.
	/// </summary>
	internal class ClassTimeDataSourceActionList : DesignerActionList
	{
		private ClassTimeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ClassTimeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ClassTimeDataSourceActionList(ClassTimeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClassTimeSelectMethod SelectMethod
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

	#endregion ClassTimeDataSourceActionList
	
	#endregion ClassTimeDataSourceDesigner
	
	#region ClassTimeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ClassTimeDataSource.SelectMethod property.
	/// </summary>
	public enum ClassTimeSelectMethod
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
		/// Represents the GetByClassTimeId method.
		/// </summary>
		GetByClassTimeId
	}
	
	#endregion ClassTimeSelectMethod

	#region ClassTimeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassTimeFilter : SqlFilter<ClassTimeColumn>
	{
	}
	
	#endregion ClassTimeFilter

	#region ClassTimeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassTimeExpressionBuilder : SqlExpressionBuilder<ClassTimeColumn>
	{
	}
	
	#endregion ClassTimeExpressionBuilder	

	#region ClassTimeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ClassTimeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassTimeProperty : ChildEntityProperty<ClassTimeChildEntityTypes>
	{
	}
	
	#endregion ClassTimeProperty
}


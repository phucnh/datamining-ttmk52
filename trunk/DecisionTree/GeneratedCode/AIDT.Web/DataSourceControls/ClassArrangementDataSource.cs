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
	/// Represents the DataRepository.ClassArrangementProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ClassArrangementDataSourceDesigner))]
	public class ClassArrangementDataSource : ProviderDataSource<ClassArrangement, ClassArrangementKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassArrangementDataSource class.
		/// </summary>
		public ClassArrangementDataSource() : base(new ClassArrangementService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ClassArrangementDataSourceView used by the ClassArrangementDataSource.
		/// </summary>
		protected ClassArrangementDataSourceView ClassArrangementView
		{
			get { return ( View as ClassArrangementDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ClassArrangementDataSource control invokes to retrieve data.
		/// </summary>
		public ClassArrangementSelectMethod SelectMethod
		{
			get
			{
				ClassArrangementSelectMethod selectMethod = ClassArrangementSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ClassArrangementSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ClassArrangementDataSourceView class that is to be
		/// used by the ClassArrangementDataSource.
		/// </summary>
		/// <returns>An instance of the ClassArrangementDataSourceView class.</returns>
		protected override BaseDataSourceView<ClassArrangement, ClassArrangementKey> GetNewDataSourceView()
		{
			return new ClassArrangementDataSourceView(this, DefaultViewName);
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
	/// Supports the ClassArrangementDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ClassArrangementDataSourceView : ProviderDataSourceView<ClassArrangement, ClassArrangementKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassArrangementDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ClassArrangementDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ClassArrangementDataSourceView(ClassArrangementDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ClassArrangementDataSource ClassArrangementOwner
		{
			get { return Owner as ClassArrangementDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ClassArrangementSelectMethod SelectMethod
		{
			get { return ClassArrangementOwner.SelectMethod; }
			set { ClassArrangementOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ClassArrangementService ClassArrangementProvider
		{
			get { return Provider as ClassArrangementService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ClassArrangement> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ClassArrangement> results = null;
			ClassArrangement item;
			count = 0;
			
			System.Int32 _customerId;
			System.Int32 _classId;
			System.DateTime _createDate;

			switch ( SelectMethod )
			{
				case ClassArrangementSelectMethod.Get:
					ClassArrangementKey entityKey  = new ClassArrangementKey();
					entityKey.Load(values);
					item = ClassArrangementProvider.Get(entityKey);
					results = new TList<ClassArrangement>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ClassArrangementSelectMethod.GetAll:
                    results = ClassArrangementProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ClassArrangementSelectMethod.GetPaged:
					results = ClassArrangementProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ClassArrangementSelectMethod.Find:
					if ( FilterParameters != null )
						results = ClassArrangementProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ClassArrangementProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ClassArrangementSelectMethod.GetByCustomerIdClassIdCreateDate:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					_classId = ( values["ClassId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ClassId"], typeof(System.Int32)) : (int)0;
					_createDate = ( values["CreateDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["CreateDate"], typeof(System.DateTime)) : DateTime.MinValue;
					item = ClassArrangementProvider.GetByCustomerIdClassIdCreateDate(_customerId, _classId, _createDate);
					results = new TList<ClassArrangement>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ClassArrangementSelectMethod.GetByClassId:
					_classId = ( values["ClassId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ClassId"], typeof(System.Int32)) : (int)0;
					results = ClassArrangementProvider.GetByClassId(_classId, this.StartIndex, this.PageSize, out count);
					break;
				case ClassArrangementSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					results = ClassArrangementProvider.GetByCustomerId(_customerId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ClassArrangementSelectMethod.Get || SelectMethod == ClassArrangementSelectMethod.GetByCustomerIdClassIdCreateDate )
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
				ClassArrangement entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ClassArrangementProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ClassArrangement> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ClassArrangementProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ClassArrangementDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ClassArrangementDataSource class.
	/// </summary>
	public class ClassArrangementDataSourceDesigner : ProviderDataSourceDesigner<ClassArrangement, ClassArrangementKey>
	{
		/// <summary>
		/// Initializes a new instance of the ClassArrangementDataSourceDesigner class.
		/// </summary>
		public ClassArrangementDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClassArrangementSelectMethod SelectMethod
		{
			get { return ((ClassArrangementDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ClassArrangementDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ClassArrangementDataSourceActionList

	/// <summary>
	/// Supports the ClassArrangementDataSourceDesigner class.
	/// </summary>
	internal class ClassArrangementDataSourceActionList : DesignerActionList
	{
		private ClassArrangementDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ClassArrangementDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ClassArrangementDataSourceActionList(ClassArrangementDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClassArrangementSelectMethod SelectMethod
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

	#endregion ClassArrangementDataSourceActionList
	
	#endregion ClassArrangementDataSourceDesigner
	
	#region ClassArrangementSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ClassArrangementDataSource.SelectMethod property.
	/// </summary>
	public enum ClassArrangementSelectMethod
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
		/// Represents the GetByCustomerIdClassIdCreateDate method.
		/// </summary>
		GetByCustomerIdClassIdCreateDate,
		/// <summary>
		/// Represents the GetByClassId method.
		/// </summary>
		GetByClassId,
		/// <summary>
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId
	}
	
	#endregion ClassArrangementSelectMethod

	#region ClassArrangementFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassArrangementFilter : SqlFilter<ClassArrangementColumn>
	{
	}
	
	#endregion ClassArrangementFilter

	#region ClassArrangementExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassArrangementExpressionBuilder : SqlExpressionBuilder<ClassArrangementColumn>
	{
	}
	
	#endregion ClassArrangementExpressionBuilder	

	#region ClassArrangementProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ClassArrangementChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassArrangementProperty : ChildEntityProperty<ClassArrangementChildEntityTypes>
	{
	}
	
	#endregion ClassArrangementProperty
}


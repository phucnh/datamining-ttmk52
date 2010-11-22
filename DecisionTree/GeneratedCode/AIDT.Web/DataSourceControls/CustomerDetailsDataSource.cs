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
	/// Represents the DataRepository.CustomerDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomerDetailsDataSourceDesigner))]
	public class CustomerDetailsDataSource : ProviderDataSource<CustomerDetails, CustomerDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsDataSource class.
		/// </summary>
		public CustomerDetailsDataSource() : base(new CustomerDetailsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomerDetailsDataSourceView used by the CustomerDetailsDataSource.
		/// </summary>
		protected CustomerDetailsDataSourceView CustomerDetailsView
		{
			get { return ( View as CustomerDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomerDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public CustomerDetailsSelectMethod SelectMethod
		{
			get
			{
				CustomerDetailsSelectMethod selectMethod = CustomerDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomerDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomerDetailsDataSourceView class that is to be
		/// used by the CustomerDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the CustomerDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomerDetails, CustomerDetailsKey> GetNewDataSourceView()
		{
			return new CustomerDetailsDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomerDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomerDetailsDataSourceView : ProviderDataSourceView<CustomerDetails, CustomerDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomerDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomerDetailsDataSourceView(CustomerDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomerDetailsDataSource CustomerDetailsOwner
		{
			get { return Owner as CustomerDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomerDetailsSelectMethod SelectMethod
		{
			get { return CustomerDetailsOwner.SelectMethod; }
			set { CustomerDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomerDetailsService CustomerDetailsProvider
		{
			get { return Provider as CustomerDetailsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomerDetails> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomerDetails> results = null;
			CustomerDetails item;
			count = 0;
			
			System.Int32 _customerId;
			System.Int32? _occupationTypeId_nullable;

			switch ( SelectMethod )
			{
				case CustomerDetailsSelectMethod.Get:
					CustomerDetailsKey entityKey  = new CustomerDetailsKey();
					entityKey.Load(values);
					item = CustomerDetailsProvider.Get(entityKey);
					results = new TList<CustomerDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomerDetailsSelectMethod.GetAll:
                    results = CustomerDetailsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomerDetailsSelectMethod.GetPaged:
					results = CustomerDetailsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomerDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomerDetailsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomerDetailsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomerDetailsSelectMethod.GetByCustomerId:
					_customerId = ( values["CustomerId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomerId"], typeof(System.Int32)) : (int)0;
					item = CustomerDetailsProvider.GetByCustomerId(_customerId);
					results = new TList<CustomerDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CustomerDetailsSelectMethod.GetByOccupationTypeId:
					_occupationTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["OccupationTypeId"], typeof(System.Int32?));
					results = CustomerDetailsProvider.GetByOccupationTypeId(_occupationTypeId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomerDetailsSelectMethod.Get || SelectMethod == CustomerDetailsSelectMethod.GetByCustomerId )
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
				CustomerDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomerDetailsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomerDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomerDetailsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomerDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomerDetailsDataSource class.
	/// </summary>
	public class CustomerDetailsDataSourceDesigner : ProviderDataSourceDesigner<CustomerDetails, CustomerDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomerDetailsDataSourceDesigner class.
		/// </summary>
		public CustomerDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerDetailsSelectMethod SelectMethod
		{
			get { return ((CustomerDetailsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomerDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomerDetailsDataSourceActionList

	/// <summary>
	/// Supports the CustomerDetailsDataSourceDesigner class.
	/// </summary>
	internal class CustomerDetailsDataSourceActionList : DesignerActionList
	{
		private CustomerDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomerDetailsDataSourceActionList(CustomerDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomerDetailsSelectMethod SelectMethod
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

	#endregion CustomerDetailsDataSourceActionList
	
	#endregion CustomerDetailsDataSourceDesigner
	
	#region CustomerDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomerDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum CustomerDetailsSelectMethod
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
		/// Represents the GetByCustomerId method.
		/// </summary>
		GetByCustomerId,
		/// <summary>
		/// Represents the GetByOccupationTypeId method.
		/// </summary>
		GetByOccupationTypeId
	}
	
	#endregion CustomerDetailsSelectMethod

	#region CustomerDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDetailsFilter : SqlFilter<CustomerDetailsColumn>
	{
	}
	
	#endregion CustomerDetailsFilter

	#region CustomerDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDetailsExpressionBuilder : SqlExpressionBuilder<CustomerDetailsColumn>
	{
	}
	
	#endregion CustomerDetailsExpressionBuilder	

	#region CustomerDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomerDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDetailsProperty : ChildEntityProperty<CustomerDetailsChildEntityTypes>
	{
	}
	
	#endregion CustomerDetailsProperty
}


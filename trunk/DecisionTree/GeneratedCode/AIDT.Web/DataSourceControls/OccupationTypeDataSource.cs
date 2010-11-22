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
	/// Represents the DataRepository.OccupationTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(OccupationTypeDataSourceDesigner))]
	public class OccupationTypeDataSource : ProviderDataSource<OccupationType, OccupationTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OccupationTypeDataSource class.
		/// </summary>
		public OccupationTypeDataSource() : base(new OccupationTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the OccupationTypeDataSourceView used by the OccupationTypeDataSource.
		/// </summary>
		protected OccupationTypeDataSourceView OccupationTypeView
		{
			get { return ( View as OccupationTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the OccupationTypeDataSource control invokes to retrieve data.
		/// </summary>
		public OccupationTypeSelectMethod SelectMethod
		{
			get
			{
				OccupationTypeSelectMethod selectMethod = OccupationTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (OccupationTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the OccupationTypeDataSourceView class that is to be
		/// used by the OccupationTypeDataSource.
		/// </summary>
		/// <returns>An instance of the OccupationTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<OccupationType, OccupationTypeKey> GetNewDataSourceView()
		{
			return new OccupationTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the OccupationTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class OccupationTypeDataSourceView : ProviderDataSourceView<OccupationType, OccupationTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OccupationTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the OccupationTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public OccupationTypeDataSourceView(OccupationTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal OccupationTypeDataSource OccupationTypeOwner
		{
			get { return Owner as OccupationTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal OccupationTypeSelectMethod SelectMethod
		{
			get { return OccupationTypeOwner.SelectMethod; }
			set { OccupationTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal OccupationTypeService OccupationTypeProvider
		{
			get { return Provider as OccupationTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<OccupationType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<OccupationType> results = null;
			OccupationType item;
			count = 0;
			
			System.Int32 _occupationTypeId;

			switch ( SelectMethod )
			{
				case OccupationTypeSelectMethod.Get:
					OccupationTypeKey entityKey  = new OccupationTypeKey();
					entityKey.Load(values);
					item = OccupationTypeProvider.Get(entityKey);
					results = new TList<OccupationType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case OccupationTypeSelectMethod.GetAll:
                    results = OccupationTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case OccupationTypeSelectMethod.GetPaged:
					results = OccupationTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case OccupationTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = OccupationTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = OccupationTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case OccupationTypeSelectMethod.GetByOccupationTypeId:
					_occupationTypeId = ( values["OccupationTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OccupationTypeId"], typeof(System.Int32)) : (int)0;
					item = OccupationTypeProvider.GetByOccupationTypeId(_occupationTypeId);
					results = new TList<OccupationType>();
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
			if ( SelectMethod == OccupationTypeSelectMethod.Get || SelectMethod == OccupationTypeSelectMethod.GetByOccupationTypeId )
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
				OccupationType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					OccupationTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<OccupationType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			OccupationTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region OccupationTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the OccupationTypeDataSource class.
	/// </summary>
	public class OccupationTypeDataSourceDesigner : ProviderDataSourceDesigner<OccupationType, OccupationTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the OccupationTypeDataSourceDesigner class.
		/// </summary>
		public OccupationTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OccupationTypeSelectMethod SelectMethod
		{
			get { return ((OccupationTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new OccupationTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region OccupationTypeDataSourceActionList

	/// <summary>
	/// Supports the OccupationTypeDataSourceDesigner class.
	/// </summary>
	internal class OccupationTypeDataSourceActionList : DesignerActionList
	{
		private OccupationTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the OccupationTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public OccupationTypeDataSourceActionList(OccupationTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public OccupationTypeSelectMethod SelectMethod
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

	#endregion OccupationTypeDataSourceActionList
	
	#endregion OccupationTypeDataSourceDesigner
	
	#region OccupationTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the OccupationTypeDataSource.SelectMethod property.
	/// </summary>
	public enum OccupationTypeSelectMethod
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
		/// Represents the GetByOccupationTypeId method.
		/// </summary>
		GetByOccupationTypeId
	}
	
	#endregion OccupationTypeSelectMethod

	#region OccupationTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OccupationTypeFilter : SqlFilter<OccupationTypeColumn>
	{
	}
	
	#endregion OccupationTypeFilter

	#region OccupationTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OccupationTypeExpressionBuilder : SqlExpressionBuilder<OccupationTypeColumn>
	{
	}
	
	#endregion OccupationTypeExpressionBuilder	

	#region OccupationTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;OccupationTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OccupationTypeProperty : ChildEntityProperty<OccupationTypeChildEntityTypes>
	{
	}
	
	#endregion OccupationTypeProperty
}


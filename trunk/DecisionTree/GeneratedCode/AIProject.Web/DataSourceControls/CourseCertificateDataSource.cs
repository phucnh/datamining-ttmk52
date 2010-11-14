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
	/// Represents the DataRepository.CourseCertificateProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CourseCertificateDataSourceDesigner))]
	public class CourseCertificateDataSource : ProviderDataSource<CourseCertificate, CourseCertificateKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseCertificateDataSource class.
		/// </summary>
		public CourseCertificateDataSource() : base(new CourseCertificateService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CourseCertificateDataSourceView used by the CourseCertificateDataSource.
		/// </summary>
		protected CourseCertificateDataSourceView CourseCertificateView
		{
			get { return ( View as CourseCertificateDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CourseCertificateDataSource control invokes to retrieve data.
		/// </summary>
		public CourseCertificateSelectMethod SelectMethod
		{
			get
			{
				CourseCertificateSelectMethod selectMethod = CourseCertificateSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CourseCertificateSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CourseCertificateDataSourceView class that is to be
		/// used by the CourseCertificateDataSource.
		/// </summary>
		/// <returns>An instance of the CourseCertificateDataSourceView class.</returns>
		protected override BaseDataSourceView<CourseCertificate, CourseCertificateKey> GetNewDataSourceView()
		{
			return new CourseCertificateDataSourceView(this, DefaultViewName);
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
	/// Supports the CourseCertificateDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CourseCertificateDataSourceView : ProviderDataSourceView<CourseCertificate, CourseCertificateKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseCertificateDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CourseCertificateDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CourseCertificateDataSourceView(CourseCertificateDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CourseCertificateDataSource CourseCertificateOwner
		{
			get { return Owner as CourseCertificateDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CourseCertificateSelectMethod SelectMethod
		{
			get { return CourseCertificateOwner.SelectMethod; }
			set { CourseCertificateOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CourseCertificateService CourseCertificateProvider
		{
			get { return Provider as CourseCertificateService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CourseCertificate> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CourseCertificate> results = null;
			CourseCertificate item;
			count = 0;
			
			System.Int32 _certificateId;

			switch ( SelectMethod )
			{
				case CourseCertificateSelectMethod.Get:
					CourseCertificateKey entityKey  = new CourseCertificateKey();
					entityKey.Load(values);
					item = CourseCertificateProvider.Get(entityKey);
					results = new TList<CourseCertificate>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CourseCertificateSelectMethod.GetAll:
                    results = CourseCertificateProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CourseCertificateSelectMethod.GetPaged:
					results = CourseCertificateProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CourseCertificateSelectMethod.Find:
					if ( FilterParameters != null )
						results = CourseCertificateProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CourseCertificateProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CourseCertificateSelectMethod.GetByCertificateId:
					_certificateId = ( values["CertificateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CertificateId"], typeof(System.Int32)) : (int)0;
					item = CourseCertificateProvider.GetByCertificateId(_certificateId);
					results = new TList<CourseCertificate>();
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
			if ( SelectMethod == CourseCertificateSelectMethod.Get || SelectMethod == CourseCertificateSelectMethod.GetByCertificateId )
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
				CourseCertificate entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CourseCertificateProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CourseCertificate> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CourseCertificateProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CourseCertificateDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CourseCertificateDataSource class.
	/// </summary>
	public class CourseCertificateDataSourceDesigner : ProviderDataSourceDesigner<CourseCertificate, CourseCertificateKey>
	{
		/// <summary>
		/// Initializes a new instance of the CourseCertificateDataSourceDesigner class.
		/// </summary>
		public CourseCertificateDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseCertificateSelectMethod SelectMethod
		{
			get { return ((CourseCertificateDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CourseCertificateDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CourseCertificateDataSourceActionList

	/// <summary>
	/// Supports the CourseCertificateDataSourceDesigner class.
	/// </summary>
	internal class CourseCertificateDataSourceActionList : DesignerActionList
	{
		private CourseCertificateDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CourseCertificateDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CourseCertificateDataSourceActionList(CourseCertificateDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CourseCertificateSelectMethod SelectMethod
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

	#endregion CourseCertificateDataSourceActionList
	
	#endregion CourseCertificateDataSourceDesigner
	
	#region CourseCertificateSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CourseCertificateDataSource.SelectMethod property.
	/// </summary>
	public enum CourseCertificateSelectMethod
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
		/// Represents the GetByCertificateId method.
		/// </summary>
		GetByCertificateId
	}
	
	#endregion CourseCertificateSelectMethod

	#region CourseCertificateFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseCertificate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseCertificateFilter : SqlFilter<CourseCertificateColumn>
	{
	}
	
	#endregion CourseCertificateFilter

	#region CourseCertificateExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseCertificate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseCertificateExpressionBuilder : SqlExpressionBuilder<CourseCertificateColumn>
	{
	}
	
	#endregion CourseCertificateExpressionBuilder	

	#region CourseCertificateProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CourseCertificateChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CourseCertificate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseCertificateProperty : ChildEntityProperty<CourseCertificateChildEntityTypes>
	{
	}
	
	#endregion CourseCertificateProperty
}


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
	/// Represents the DataRepository.ClassDetailsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ClassDetailsDataSourceDesigner))]
	public class ClassDetailsDataSource : ProviderDataSource<ClassDetails, ClassDetailsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassDetailsDataSource class.
		/// </summary>
		public ClassDetailsDataSource() : base(new ClassDetailsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ClassDetailsDataSourceView used by the ClassDetailsDataSource.
		/// </summary>
		protected ClassDetailsDataSourceView ClassDetailsView
		{
			get { return ( View as ClassDetailsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ClassDetailsDataSource control invokes to retrieve data.
		/// </summary>
		public ClassDetailsSelectMethod SelectMethod
		{
			get
			{
				ClassDetailsSelectMethod selectMethod = ClassDetailsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ClassDetailsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ClassDetailsDataSourceView class that is to be
		/// used by the ClassDetailsDataSource.
		/// </summary>
		/// <returns>An instance of the ClassDetailsDataSourceView class.</returns>
		protected override BaseDataSourceView<ClassDetails, ClassDetailsKey> GetNewDataSourceView()
		{
			return new ClassDetailsDataSourceView(this, DefaultViewName);
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
	/// Supports the ClassDetailsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ClassDetailsDataSourceView : ProviderDataSourceView<ClassDetails, ClassDetailsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassDetailsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ClassDetailsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ClassDetailsDataSourceView(ClassDetailsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ClassDetailsDataSource ClassDetailsOwner
		{
			get { return Owner as ClassDetailsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ClassDetailsSelectMethod SelectMethod
		{
			get { return ClassDetailsOwner.SelectMethod; }
			set { ClassDetailsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ClassDetailsService ClassDetailsProvider
		{
			get { return Provider as ClassDetailsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ClassDetails> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ClassDetails> results = null;
			ClassDetails item;
			count = 0;
			
			System.Int32 _classId;
			System.Int32? _classTime_nullable;
			System.Int32? _courseId_nullable;
			System.Int32? _teacherId_nullable;

			switch ( SelectMethod )
			{
				case ClassDetailsSelectMethod.Get:
					ClassDetailsKey entityKey  = new ClassDetailsKey();
					entityKey.Load(values);
					item = ClassDetailsProvider.Get(entityKey);
					results = new TList<ClassDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ClassDetailsSelectMethod.GetAll:
                    results = ClassDetailsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ClassDetailsSelectMethod.GetPaged:
					results = ClassDetailsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ClassDetailsSelectMethod.Find:
					if ( FilterParameters != null )
						results = ClassDetailsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ClassDetailsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ClassDetailsSelectMethod.GetByClassId:
					_classId = ( values["ClassId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ClassId"], typeof(System.Int32)) : (int)0;
					item = ClassDetailsProvider.GetByClassId(_classId);
					results = new TList<ClassDetails>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ClassDetailsSelectMethod.GetByClassTime:
					_classTime_nullable = (System.Int32?) EntityUtil.ChangeType(values["ClassTime"], typeof(System.Int32?));
					results = ClassDetailsProvider.GetByClassTime(_classTime_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ClassDetailsSelectMethod.GetByCourseId:
					_courseId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CourseId"], typeof(System.Int32?));
					results = ClassDetailsProvider.GetByCourseId(_courseId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case ClassDetailsSelectMethod.GetByTeacherId:
					_teacherId_nullable = (System.Int32?) EntityUtil.ChangeType(values["TeacherId"], typeof(System.Int32?));
					results = ClassDetailsProvider.GetByTeacherId(_teacherId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ClassDetailsSelectMethod.Get || SelectMethod == ClassDetailsSelectMethod.GetByClassId )
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
				ClassDetails entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ClassDetailsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ClassDetails> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ClassDetailsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ClassDetailsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ClassDetailsDataSource class.
	/// </summary>
	public class ClassDetailsDataSourceDesigner : ProviderDataSourceDesigner<ClassDetails, ClassDetailsKey>
	{
		/// <summary>
		/// Initializes a new instance of the ClassDetailsDataSourceDesigner class.
		/// </summary>
		public ClassDetailsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClassDetailsSelectMethod SelectMethod
		{
			get { return ((ClassDetailsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ClassDetailsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ClassDetailsDataSourceActionList

	/// <summary>
	/// Supports the ClassDetailsDataSourceDesigner class.
	/// </summary>
	internal class ClassDetailsDataSourceActionList : DesignerActionList
	{
		private ClassDetailsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ClassDetailsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ClassDetailsDataSourceActionList(ClassDetailsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClassDetailsSelectMethod SelectMethod
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

	#endregion ClassDetailsDataSourceActionList
	
	#endregion ClassDetailsDataSourceDesigner
	
	#region ClassDetailsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ClassDetailsDataSource.SelectMethod property.
	/// </summary>
	public enum ClassDetailsSelectMethod
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
		/// Represents the GetByClassId method.
		/// </summary>
		GetByClassId,
		/// <summary>
		/// Represents the GetByClassTime method.
		/// </summary>
		GetByClassTime,
		/// <summary>
		/// Represents the GetByCourseId method.
		/// </summary>
		GetByCourseId,
		/// <summary>
		/// Represents the GetByTeacherId method.
		/// </summary>
		GetByTeacherId
	}
	
	#endregion ClassDetailsSelectMethod

	#region ClassDetailsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassDetailsFilter : SqlFilter<ClassDetailsColumn>
	{
	}
	
	#endregion ClassDetailsFilter

	#region ClassDetailsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassDetailsExpressionBuilder : SqlExpressionBuilder<ClassDetailsColumn>
	{
	}
	
	#endregion ClassDetailsExpressionBuilder	

	#region ClassDetailsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ClassDetailsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassDetailsProperty : ChildEntityProperty<ClassDetailsChildEntityTypes>
	{
	}
	
	#endregion ClassDetailsProperty
}


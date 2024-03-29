﻿
using System;
using System.Text;

using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace AIProject.Entities
{
   /// <summary>
   /// A abstract generic base class for the nettiers entities that are generated from tables and views. 
   /// Supports filtering, databinding, searching and sorting.
   /// </summary>
   [Serializable]
   public abstract class ListBase<T> : BindingList<T>, IBindingListView, IBindingList, IList, ICloneable, ICloneableEx, IListSource, ITypedList, IDisposable, IComponent, IRaiseItemChangedEvents, IDeserializationCallback
   {
      private List<T> _OriginalList = new List<T>();

      // Sorting
      private bool _isSorted = false;
      [NonSerialized]
      private PropertyDescriptor _sortProperty;
      private ListSortDirection _sortDirection = ListSortDirection.Descending;
      [NonSerialized]
      ListSortDescriptionCollection _sortDescriptions = new ListSortDescriptionCollection();

      //Filtering
      private string _filterString = null;
      private List<T> excludedItems = new List<T>();

      private string _listName;
      private bool _containsListCollection = false;
 
	  [NonSerialized]
      private PropertyDescriptorCollection _propertyCollection;
	  
	  //[NonSerialized]
      //private List<PropertyDescriptor> supportsChangeEventsProperties = new List<PropertyDescriptor>();
      
	  [NonSerialized]
      private Dictionary<string, PropertyDescriptorCollection> _childCollectionProperties;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:TList{T}"/> class.
      /// </summary>
      public ListBase() : base()
      {
         InitializeList();
      }

      /// <summary>
      /// Initialize any member variables when the list is created
      /// </summary>
      private void InitializeList()
      {
         // save the bindable properties in a local field
         _propertyCollection = EntityHelper.GetBindableProperties(typeof(T));
		
         // save the name of the type for use in the IDE GUI
         _listName = typeof(T).Name;
      }

      #region Core Overrides

      /// <summary>
      /// Gets a value indicating whether the list supports searching. 
      /// </summary>
      protected override bool SupportsSearchingCore
      {
         get
         {
            return true;
         }
      }

      /// <summary>
      /// Searches for the index of the item that has the specified property descriptor with the specified value.
      /// </summary>
      /// <param name="prop">The <see cref="PropertyDescriptor"/> to search for.</param>
      /// <param name="key">The value of <i>property</i> to match.</param>
      /// <returns>The zero-based index of the item that matches the property descriptor and contains the specified value. </returns>
      protected override int FindCore(PropertyDescriptor prop, object key)
      {
         return FindCore(prop, key, 0, true);
      }

      /// <summary>
      /// Searches for the index of the item that has the specified property descriptor with the specified value.
      /// </summary>
      /// <param name="prop">The <see cref="PropertyDescriptor"/> to search for.</param>
      /// <param name="key">The value of <i>property</i> to match.</param>
      /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
      /// <returns>The zero-based index of the item that matches the property descriptor and contains the specified value. </returns>
      protected virtual int FindCore(PropertyDescriptor prop, object key, bool ignoreCase)
      {
         return FindCore(prop, key, 0, ignoreCase);
      }

      /// <summary>
      /// Searches for the index of the item that has the specified property descriptor with the specified value.
      /// </summary>
      /// <param name="prop">The <see cref="PropertyDescriptor"> to search for.</see></param>
      /// <param name="key">The value of <i>property</i> to match.</param>
      /// <param name="start">The index in the list at which to start the search.</param>
      /// <param name="ignoreCase">Indicator of whether to perform a case-sensitive or case insensitive search (string properties only).</param>
      /// <returns>The zero-based index of the item that matches the property descriptor and contains the specified value. </returns>
      protected virtual int FindCore(PropertyDescriptor prop, object key, int start, bool ignoreCase)
      {
         // Simple iteration:
         for (int i = start; i < Count; i++)
         {

            T item = this[i];
            object temp = prop.GetValue(item);
			if ((key == null) && (temp == null))
			{
				return i;
			}
            else if (temp is string && key != null)
            {
               if (String.Compare(temp.ToString(), key.ToString(), ignoreCase) == 0)
                  return i;
            }
            else if (temp != null && temp.Equals(key))
            {
               return i;
            }
         }
         return -1; // Not found
      }

      /// <summary>
      /// Gets a value indicating whether the list supports sorting. 
      /// </summary>
      protected override bool SupportsSortingCore
      {
         get
         {
            return true;
         }
      }

      /// <summary>
      /// Gets a value indicating whether the list is sorted. 
      /// </summary>
      protected override bool IsSortedCore
      {
         get
         {
            return _isSorted;
         }
      }

      /// <summary>
      /// Gets the direction the list is sorted.
      /// </summary>
      protected override ListSortDirection SortDirectionCore
      {
         get
         {
            return _sortDirection;
         }
      }

      /// <summary>
      /// Gets the property descriptor that is used for sorting
      /// </summary>
      /// <returns>The <see cref="PropertyDescriptor"/> used for sorting the list.</returns>
      protected override PropertyDescriptor SortPropertyCore
      {
         get
         {
            return _sortProperty;
         }
      }

      /// <summary>
      /// Sorts the items in the list
      /// </summary>
      /// <param name="prop">A <see cref="PropertyDescriptor"/> that specifies the property to sort on.</param>
      /// <param name="direction">One of the <see cref="ListSortDirection"/> values.</param>
      protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
      {
         _sortDirection = direction;
         _sortProperty = prop;
         SortComparer<T> comparer = new SortComparer<T>(prop, direction);
         ApplySortInternal(comparer);
      }

      /// <summary>
      /// Removes any sort applied to the list.
      /// </summary>
      protected override void RemoveSortCore()
      {
         if (!_isSorted)
            return;

         Clear();
         foreach (T item in _OriginalList)
         {
            Add(item);
         }

         _OriginalList.Clear();
         _sortProperty = null;
         _sortDescriptions = null;
         _isSorted = false;
      }



      #endregion

      #region IBindingListView Members

      /// <summary>
      /// Gets or sets the filter to be used to exclude items from the collection of items returned by the data source.
      /// </summary>
      public string Filter
      {
         get
         {
            return _filterString;
         }
         set
         {
            if (value == this._filterString) return;

            this._filterString = value;
            this.ApplyFilter();
         }
      }

      /// <summary>
      /// Removes the current filter applied to the data source..
      /// </summary>
      public void RemoveFilter()
      {
      	 this._filterString = string.Empty;
         this.ApplyFilter();
      }

      /// <summary>
      /// Gets the collection of sort descriptions currently applied to the data source.
      /// </summary>
      public ListSortDescriptionCollection SortDescriptions
      {
         get
         {
            return _sortDescriptions;
         }
      }

      /// <summary>
      /// Gets a value indicating whether the data source supports advanced sorting.
      /// </summary>
      public bool SupportsAdvancedSorting
      {
         get
         {
            return true;
         }
      }

      /// <summary>
      /// Gets a value indicating whether the data source supports filtering.
      /// </summary>
      public bool SupportsFiltering
      {
         get
         {
            return true;
         }
      }

      #region Sorting

      ///<summary>
      /// Sorts the data source based on the given <see cref="ListSortDescriptionCollection"/>.
      ///</summary>
      ///<param name="sorts">The <see cref="ListSortDescriptionCollection"/> containing the sorts to apply to the data source.</param>
      public void ApplySort(ListSortDescriptionCollection sorts)
      {
         _sortProperty = null;
         _sortDescriptions = sorts;
         SortComparer<T> comparer = new SortComparer<T>(sorts);
         ApplySortInternal(comparer);
      }

      ///<summary>
      /// Sorts the data source based on a <see cref="PropertyDescriptor">PropertyDescriptor</see> and a <see cref="ListSortDirection">ListSortDirection</see>.
      ///</summary>
      ///<param name="property">The <see cref="PropertyDescriptor"/> to sort the collection by.</param>
      ///<param name="direction">The <see cref="ListSortDirection"/> in which to sort the collection.</param>
      public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
      {
         ApplySortCore(property, direction);
      }

      /// <summary>
      /// Sorts the elements in the entire list using the specified <see cref="System.Comparison{T}"/>.
      /// </summary>
      /// <param name="comparison">The <see cref="System.Comparison{T}"/> to use when comparing elements.</param>
      /// <exception cref="ArgumentNullException">comparison is a null reference.</exception>
      private void ApplySortInternal(Comparison<T> comparison)
      {
         if (comparison == null)
            throw new ArgumentNullException("The comparison parameter must be a valid object instance.");

         if (_OriginalList.Count == 0)
         {
            _OriginalList.AddRange(this);
         }

         List<T> listRef = this.Items as List<T>;

         if (listRef == null)
            return;

         listRef.Sort(comparison);
         _isSorted = true;
         OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
      }

      /// <summary>
      /// Sorts the elements in the entire list using the specified comparer. 
      /// </summary>
      /// <param name="comparer">The <see cref="IComparer{T}" /> implementation to use when comparing elements, or a null reference (Nothing in Visual Basic) to use the default comparer <see cref="Comparer.Default"/>.</param>
      private void ApplySortInternal(IComparer<T> comparer)
      {
         if (comparer == null)
            comparer = Comparer<T>.Default;

         ApplySortInternal(comparer.Compare);
      }

      /// <summary>
      /// Sorts the elements in the entire list using the specified comparer. 
      /// </summary>
      /// <param name="comparer">The <see cref="IComparer{T}" /> implementation to use when comparing elements, or a null reference (Nothing in Visual Basic) to use the default comparer <see cref="Comparer.Default"/>.</param>
      public void Sort(IComparer<T> comparer)
      {
         ApplySortInternal(comparer);
      }

      /// <summary>
      /// Sorts the elements in the entire list using the specified <see cref="System.Comparison{T}"/>.
      /// </summary>
      /// <param name="comparison">The <see cref="System.Comparison{T}"/> to use when comparing elements.</param>
      /// <exception cref="ArgumentNullException">comparison is a null reference.</exception>
      public void Sort(Comparison<T> comparison)
      {
         ApplySortInternal(comparison);
      }

      /// <summary>
      /// Sorts the elements in the entire list using the specified Order By statement.
      /// </summary>
      /// <param name="orderBy">SQL-like string representing the properties to sort the list by.</param>
      /// <remarks><i>orderBy</i> should be in the following format: 
      /// <para>PropertyName[[ [[ASC]|DESC]][, PropertyName[ [[ASC]|DESC]][,...]]]</para></remarks>
      /// <example><c>list.Sort("Property1, Property2 DESC, Property3 ASC");</c></example>
      public void Sort(string orderBy)
      {
         SortComparer<T> sortComparer = new SortComparer<T>(orderBy);
         ApplySortInternal(sortComparer.Compare);
      }

      #endregion

      #region Filtering


      /// <summary>
      /// Indicates whether a filter is currently applied to the collection.
      /// </summary>
      public bool IsFiltering
      {
         get { return this.excludedItems.Count > 0; }
      }

      /// <summary>
      /// Get the list of items that are excluded by the current filter.
      /// </summary>
      public List<T> ExcludedItems
      {
         get { return this.excludedItems; }
      }

      /// <summary>
      /// Force the filtering of the collection, based on the filter expression set through the <c cref="Filter"/> property.
      /// </summary>
      public void ApplyFilter()
      {
         // Restore the state without filter
         for (int i = 0; i < this.excludedItems.Count; i++)
         {           
			this.Add(this.excludedItems[i]);
         }

         // Clear the filterd items
         this.excludedItems.Clear();

         // Application du filtre si non vide
         if (!string.IsNullOrEmpty(this._filterString))
         {
            EntityFilter<ListBase<T>, T> MyFilter = new EntityFilter<ListBase<T>, T>(this, this._filterString);
         }

         // Send a IBindingList list event
         OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0, 0));
      }

      /// <summary>
      /// Force the filtering of the collection, based on the use of the specified Predicate.
      /// </summary>
      /// <param name="match"></param>
      public void ApplyFilter(Predicate<T> match)
      {
         this._filterString = string.Empty;

         // Restore the state without filter
         for (int i = 0; i < this.excludedItems.Count; i++)
         {
            this.Add(this.excludedItems[i]);
         }

         // Clear the filterd items
         this.excludedItems.Clear();

         for (int i = this.Items.Count - 1; i >= 0; i--)
         {
            if (!match(this.Items[i]))
            {
               RemoveFilteredItem(i);
            }
         }

         // Send a IBindingList list event
         OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0, 0));
      }
      
	  /// <summary>
      /// Removes the non criteria matching item at the specified index for the current filter set.
	  /// Adds the Item to the ExcludedItem  collection without changing EntityState
      /// </summary>
      /// <param name="index">The zero-based index of non criteria matching item to remove.</param>
      internal void RemoveFilteredItem(int index)
      {
          T item = Items[index];

          if (item != null)
          {
			  ExcludedItems.Add(item);
              base.RemoveItem(index);
          }
      }
      #endregion

      #endregion

      #region BindingList overrides

	/*
      
	  /// <summary>
      /// Inserts the specified item in the list at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index where the item is to be inserted.</param>
      /// <param name="item">The item to insert in the list.</param>
      protected override void InsertItem(int index, T item)
      {
         foreach (PropertyDescriptor propDesc in supportsChangeEventsProperties) 
		 {
            propDesc.AddValueChanged(item, OnItemChanged);
         }
		
         base.InsertItem(index, item);
      }

	  /// <summary>
      /// Removes the item at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index of the item to remove.</param>
      protected override void RemoveItem(int index)
      {
         T item = Items[index];
         foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(item))
         {
            if (propDesc.SupportsChangeEvents)
            {
               propDesc.RemoveValueChanged(item, OnItemChanged);
            }
         }

         base.RemoveItem(index);
      }
	*/
	
      /// <summary>
      /// Represents the method that will handle the ItemChanged event of the CurrencyManager class
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="args">An EventArgs that contains the event data.</param>
      /// <remarks>This raises the ListChanged event of the list.</remarks>
      void OnItemChanged(object sender, EventArgs args)
      {
         int index = Items.IndexOf((T)sender);
         OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
      }

      #endregion

      #region IRaiseItemChangedEvents Members

      /// <summary>
      /// Gets a value indicating whether the object raises <see cref="IBindingList.ListChanged"/> events.
      /// </summary>
      bool IRaiseItemChangedEvents.RaisesItemChangedEvents
      {
         get { return true; }
      }

      #endregion

      #region Shuffle

      /// <summary>
      ///		Sorts the collection based on a random shuffle.
      /// </summary>
      /// <author>Steven Smith</author>
      /// <url>http://blogs.aspadvice.com/ssmith/archive/2005/01/27/2480.aspx</url>
      ///<remarks></remarks>
      public virtual void Shuffle()
      {
         if (this._OriginalList.Count == 0)
         {
            this._OriginalList.AddRange(this);
         }

         //List<T> source = new List<T>(this);
         Random rnd = new Random();
         for (int inx = this.Count - 1; inx > 0; inx--)
         {
            int position = rnd.Next(inx + 1);
            T temp = this[inx];
            this[inx] = this[position];
            this[position] = temp;
         }
      }
      #endregion

      #region ICloneable

      ///<summary>
      /// Creates an exact copy of this instance.
      ///</summary>
      ///<implements><see cref="ICloneable.Clone"/></implements>
      public virtual object Clone()
      {
         throw new NotImplementedException("Method not implemented.");
      }

      ///<summary>
      /// Creates an exact copy of this instance.
      ///</summary>
      ///<implements><see cref="ICloneableEx.Clone"/></implements>
	  public virtual object Clone(IDictionary existingCopies)
      {
         throw new NotImplementedException("Method not implemented.");
      }
		
      ///<summary>
      /// Creates an exact copy of this TList{T} object.
      ///</summary>
      ///<returns>A new, identical copy of the TList{T} casted as object.</returns>
      public static object MakeCopyOf(object x)
      {
         if (x is ICloneable)
         {
            // Return a deep copy of the object
            return ((ICloneable)x).Clone();
         }
         else
         {
            throw new
                System.NotSupportedException("object not cloneable");
         }
      }

	      ///<summary>
      /// Creates an exact copy of this TList{T} object.
      ///</summary>
      ///<returns>A new, identical copy of the TList{T} casted as object.</returns>
      public static object MakeCopyOf(object x, IDictionary existingCopies)
      {
		 if (x is ICloneableEx)
		 {
            // Return a deep copy of the object
            return ((ICloneableEx)x).Clone(existingCopies);
		 }
         else if (x is ICloneable)
         {
            // Return a deep copy of the object
            return ((ICloneable)x).Clone();
         }
         else
         {
            throw new
                System.NotSupportedException("object not cloneable");
         }
      }
	
	  #endregion ICloneable
	  
	  #region PropertyCollection
	  /// <summary>
      /// Gets or sets the property descriptor collection for T.  
      /// </summary>
      /// <value>The property collection.</value>
       protected virtual PropertyDescriptorCollection PropertyCollection
       {
           get { return _propertyCollection; }
           set { _propertyCollection = value; }
       }
	   #endregion 
	
	  #region ToString
      /// <summary>
      /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
      /// </summary>
      /// <returns>
      /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
      /// </returns>
      public override string ToString()
      {
         string s = this.GetType().Name + " Collection" + System.Environment.NewLine;
         foreach (T Item in this)
         {
            s += Item.ToString() + System.Environment.NewLine;
         }
         return s;
      }
      #endregion 
	
	  #region EntityChanged
      /// <summary>
      /// Raises the ListChanged event indicating that a item in the list has changed.
      /// </summary>
      /// <param name="entity"></param>
      public void EntityChanged(T entity)
      {
         OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, IndexOf(entity)));
      }
      #endregion 
	
      #region ITypedList Members
      /// <summary>
      /// This member allows binding objects to discover the field/column information.
      /// </summary>
      public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
      {
         if (listAccessors == null || listAccessors.Length == 0)
         {
            return _propertyCollection;
         }
         else // Expect only one argument representing a child collection
         {
            if (_childCollectionProperties == null)
               _childCollectionProperties = new Dictionary<string, PropertyDescriptorCollection>();

				Type relevantType = listAccessors[listAccessors.Length - 1].PropertyType;
            string typeName = relevantType.FullName;

            if (_childCollectionProperties.ContainsKey(typeName))
            {
               return _childCollectionProperties[typeName];
            }
            else
            {
               PropertyDescriptorCollection props = EntityHelper.GetBindableProperties(relevantType);
               _childCollectionProperties.Add(typeName, props);

               return props;
            }
         }
      }


      /// <summary>
      /// This member returns the name displayed in the IDE.
      /// </summary>
      public string GetListName(PropertyDescriptor[] listAccessors)
      {
         return _listName;
      }

      #endregion // ITypedList

      #region IListSource Members

      /// <summary>
      /// Clean up. Nothing here though.
      /// </summary>
      public IList GetList()
      {
         return this;
      }

      /// <summary>
      /// Return TRUE if our list contains additional/child lists.
      /// </summary>
      public bool ContainsListCollection
      {
         get { return _containsListCollection; }
         set { _containsListCollection = value; }
      }

      #endregion // IListSource

      #region IComponent Members

      // Added to implement Site property correctly.
      private ISite _site = null;

      /// <summary>
      /// Get / Set the site where this data is located.
      /// </summary>
      public ISite Site
      {
         get { return _site; }
         set { _site = value; }
      }

      #endregion

      #region IDisposable Members

      /// <summary>
      /// Notify those that care when we dispose.
      /// </summary>
      public event System.EventHandler Disposed;

      /// <summary>
      /// Clean up. Nothing here though.
      /// </summary>
      public void Dispose()
      {
         this.Dispose(true);
         GC.SuppressFinalize(this);
      }

      /// <summary>
      /// Clean up.
      /// </summary>
      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
         {
            EventHandler handler = Disposed;
            if (handler != null)
               handler(this, EventArgs.Empty);
         }
      }

      #endregion

      #region Find

      ///<summary>
      /// Finds the first <see cref="IEntity" /> object in the current list matching the search criteria.
      ///</summary>
      /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
      /// <param name="value">Value to find.</param>
      public virtual T Find(System.Enum column, object value)
      {
         return Find(column.ToString(), value, true);
      }

      ///<summary>
      /// Finds the first <see cref="IEntity" /> object in the current list matching the search criteria.
      ///</summary>
      /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
      /// <param name="value">Value to find.</param>
      /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
      public virtual T Find(System.Enum column, object value, bool ignoreCase)
      {
         return Find(column.ToString(), value, ignoreCase);
      }

      ///<summary>
      /// Finds the first <see cref="IEntity" /> object in the current list matching the search criteria.
      ///</summary>
      /// <param name="propertyName">Property of the object to search.</param>
      /// <param name="value">Value to find.</param>
      public virtual T Find(string propertyName, object value)
      {
         return Find(propertyName, value, true);
      }

      ///<summary>
      /// Finds the first <see cref="IEntity" /> object in the current list matching the search criteria.
      ///</summary>
      /// <param name="propertyName">Property of the object to search.</param>
      /// <param name="value">Value to find.</param>
      /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
      public virtual T Find(string propertyName, object value, bool ignoreCase)
      {
         PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
         PropertyDescriptor searchBy = props.Find(propertyName, true);

         if (searchBy != null)
         {
            int index = this.FindCore(searchBy, value, ignoreCase);

            if (index > -1)
            {
               return this[index];
            }
            else
            {
               return default(T);
            }
         }
         else
         {
            //No such property found
            return default(T);
         }
      }

      #endregion Find

      #region IDeserializationCallback Members

      /// <summary>
      /// Runs when the entire object graph has been deserialized.
      /// </summary>
      /// <param name="sender">The object that initiated the callback.</param>
      public void OnDeserialization(object sender)
      {
         InitializeList();
      }

      #endregion

      #region Added Functionality

      /// <summary>
      /// Indicates whether the specified TList object is a null reference (Nothing in Visual Basic) or an empty collection (no item in it).
      /// </summary>
      /// <param name="list">The list.</param>
      /// <returns>
      /// 	<c>true</c> if the object is null or has no item; otherwise, <c>false</c>.
      /// </returns>
      public static bool IsNullOrEmpty(ListBase<T> list)
      {
         return list == null || list.Count == 0;
      }

      /// <summary>
      /// Performs the specified action on each element of the specified array.
      /// </summary>
      /// <param name="action">The action.</param>
      public void ForEach(Action<T> action)
      {
         foreach (T entity in this.Items)
         {
            action(entity);
         }
      }

      /// <summary>
      /// Adds an array of items to the list of items for a TList.
      /// </summary>
      /// <param name="array">The array of items to add.</param>
      public void AddRange(T[] array)
      {
         if (array == null) return;
         foreach (T item in array)
         {
            this.Add(item);
         }
      }

      /// <summary>
      /// Adds an array of items to the list of items for a TList.
      /// </summary>
      /// <param name="list">The list of items to add.</param>
      public void AddRange(ListBase<T> list)
      {
         if (list == null) return;
         foreach (T item in list)
         {
            this.Add(item);
         }
      }

      /// <summary>
      /// Adds an array of items to the list of items for a VList.
      /// </summary>
      /// <param name="list">The list of items to add.</param>
      public void AddRange(List<T> list)
      {
         if (list == null) return;
         foreach (T item in list)
         {
            this.Add(item);
         }
      }

      /// <summary>
      /// Retrieves the all the elements that match the conditions defined by the specified predicate.
      /// </summary>
      /// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the elements to search for.</param>
      /// <returns>
      /// A <see cref="T:TList`1"></see> containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty <see cref="T:TList`1"></see>.
      /// </returns>
      /// <exception cref="T:System.ArgumentNullException">match is null.</exception>		
      public ListBase<T> FindAll(Predicate<T> match)
      {
         if (match == null)
         {
            throw new ArgumentNullException("match");
         }

         ListBase<T> result = this.Clone() as ListBase<T>;
         result.ClearItems();
         foreach (T item in this.Items)
         {
            if (match(item))
            {
               result.Add(item);
            }
         }
         return result;
      }

      /// <summary>
      /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire <see cref="T:TList`1"></see>.
      /// </summary>
      /// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the element to search for.</param>
      /// <returns>
      /// The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T.
      /// </returns>
      /// <exception cref="T:System.ArgumentNullException">match is null.</exception>
      public T Find(Predicate<T> match)
      {
         if (match == null)
         {
            throw new ArgumentNullException("match");
         }

         foreach (T item in this.Items)
         {
            if (match(item))
            {
               return item;
            }
         }
         return default(T);
      }

      /*
      /// <summary>
      /// Reverses the order of the elements in the entire <see cref="T:TList{T}"></see>.
      /// </summary>
      public void Reverse()
      {
         this.Reverse(0, this.Count);
      }
		
      /// <summary>
      /// Reverses the order of the elements in the specified range.
      /// </summary>
      /// <param name="index">The zero-based starting index of the range to reverse.</param>
      /// <param name="count">The number of elements in the range to reverse.</param>
      /// <exception cref="T:System.ArgumentException">index and count do not denote a valid range of elements in the <see cref="T:T:TList{T}"></see>. </exception>
      /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0.-or-count is less than 0. </exception>
      public void Reverse(int index, int count)
      {
         if ((index < 0) || (count < 0))
         {
            throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", "Parameter is less than 0.");
         }
         if ((this.Count - index) < count)
         {
            throw new ArgumentException("index and count do not denote a valid range of elements");
         }
         Array.Reverse(this, index, count);
      }
      */


      #endregion
	
	  #region ToArray
	  ///<summary>
	  /// Convert list of entities to an <see cref="System.Array" />
	  ///</summary>
	  public T[] ToArray()
	  {
          List<T> tmpArray = new List<T>(this.Items.Count);
          foreach (T type in this.Items)
          {
              tmpArray.Add(type);
          }
          return tmpArray.ToArray();
	  }
	  #endregion

      #region ToDataSet
      /// <summary>
      /// Recursively adds child relationships of a <seealso cref="ListBase{T}"/> Entities and 
      /// builds out a nested dataset including <see cref="System.Data.DataRelation"/> relationships.
      /// </summary>
      /// <param name="includeChildren">You can optionally go deep by including includeChildren</param>
      /// <returns>DataSet</returns>
      /// <example>
      ///  An example using the Northwind database would be to deep load a TList or VList, 
      ///  and then call list.ToDataSet(true/false);
      ///  <code><![CDATA[
      ///    TList<Categories> list = DataRepository.CategoriesProvider.GetAll();
      ///    DataRepository.CategoriesProvider.DeepLoad(list, true);
      ///    DataSet ds = list.ToDataSet(true);
      ///    ds.WriteXml("C:\\Test2.xml");
      ///    ]]></code>
      /// </example>
      public System.Data.DataSet ToDataSet(bool includeChildren)
      {
         System.Data.DataSet dataset = new System.Data.DataSet();

         //recursively convert and fill object graph to a dataset.
         return AddRelations(dataset, null, includeChildren);
      }

      #region AddRelations
      /// <summary>
      /// Recursively adds child relationships of a TList's Entity and builds out a nested dataset including relationships.
      /// </summary>
      /// <param name="dataset">An already instatiated dataset which will be used to fill all objects.</param>
      /// <param name="parentKeys">Used to pass down the parent primary key to a child datatable to add a dataRelation</param>
      /// <param name="includeChildren">bool, include deep load of all child collections in this object graph?</param>
      /// <returns></returns>
      internal System.Data.DataSet AddRelations(System.Data.DataSet dataset, List<System.Data.DataColumn> parentKeys, bool includeChildren)
      {
         if (dataset == null)
            throw new ArgumentException("Invalid parameter context, dataset can not be null in this method context.", "dataset");

         //child property collections
         List<PropertyDescriptor> children = new List<PropertyDescriptor>();
         System.Data.DataTable dataTable = null;
         bool tableExists = false;
         string tName = typeof(T).Name;

         if (!dataset.Tables.Contains(tName))
         {
            //current type table
            dataTable = new System.Data.DataTable(tName);
            tableExists = false;
         }
         else
         {
            dataTable = dataset.Tables[tName];
            tableExists = true;
         }

         //Props
         PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

         //pks of current type
         List<System.Data.DataColumn> primaryKey = new List<System.Data.DataColumn>();

         //build out table if not exists
         if (!tableExists)
         {
            #region get meta data, build dataTable
            //look at current type's props, and if child hold a ref to it, so that you can recursively add the child.
            foreach (PropertyDescriptor prop in props)
            {
               if (prop.Attributes.Matches(new Attribute[] { new ReadOnlyAttribute(false), new System.ComponentModel.BindableAttribute(true), new DescriptionAttribute() }))
                  primaryKey.Add(dataTable.Columns.Add(prop.Name, prop.PropertyType));
               else if (prop.PropertyType.GetInterface("IList") != null && prop.PropertyType.IsGenericType && (prop.PropertyType.BaseType != null && prop.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(ListBase<>)))
                  children.Add(prop);
               else if (prop.PropertyType.GetInterface("IEntity") == null && prop.Attributes.Matches(new Attribute[] { new System.ComponentModel.BindableAttribute(true), new DescriptionAttribute() }))
               {
                  //check if nullable property, get param, otherwise, just add property type
                  Type columnType = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? prop.PropertyType.GetGenericArguments()[0] : prop.PropertyType);
                  dataTable.Columns.Add(prop.Name, columnType);
               }
            }
            #endregion
         }

         #region Fill Entity Data
         foreach (T entity in this.Items)
         {
            System.Data.DataRow row = dataTable.NewRow();

            foreach (PropertyDescriptor currentProperty in props)
            {
               if (!dataTable.Columns.Contains(currentProperty.Name))
                  continue;

               object val = currentProperty.GetValue(entity);
               row[currentProperty.Name] = (val == null ? DBNull.Value : val);
            }

            dataTable.Rows.Add(row);
         }
         #endregion

         //Add Table
         if (!tableExists)
            dataset.Tables.Add(dataTable);

         #region Add Child DataRelations
         if (parentKeys != null && !tableExists)
         {
            #region if part of a parentkey, then add relationship
            bool skip = false;

            // get last inserted table
            System.Data.DataTable childTable = dataset.Tables[dataset.Tables.Count - 1];

            System.Diagnostics.Trace.WriteLine(childTable.TableName + " - Found");

            //find fk's, add relationships
            List<System.Data.DataColumn> childCols = new List<System.Data.DataColumn>();
            if (childTable != null)
            {
               foreach (System.Data.DataColumn col in parentKeys)
               {
                  if (!childTable.Columns.Contains(col.ColumnName))
                     skip = true;

                  System.Diagnostics.Trace.WriteLine(childTable.TableName + " - Skip " + skip);
                  childCols.Add(childTable.Columns[col.ColumnName]);
               }

               if (!skip)
               {
                  System.Diagnostics.Trace.WriteLine(childTable.TableName + " - relation added ");
                  int key = parentKeys.GetHashCode() + childCols.GetHashCode();
                  if (!dataset.Relations.Contains(key.ToString()))
                  {
                     System.Data.DataRelation relation = dataset.Relations.Add(key.ToString(), parentKeys.ToArray(), childCols.ToArray());
                     relation.Nested = true;
                  }
               }
            }
            #endregion
         }
         #endregion

         #region Include Entity Child Collections
         // if include the child collections.
         if (includeChildren)
         {
            foreach (PropertyDescriptor child in children)
            {
               //Get DataTable in DataSet, nested recursively.
               foreach (T childEntity in this.Items)
               {
                  object[] childEntityParams = new object[3] { dataset, primaryKey, includeChildren };

                  //add children
                  System.Reflection.MethodInfo addRelationsMethod = child.PropertyType.GetMethod("AddRelations",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

                  //ensure method exists, invoke
                  if (addRelationsMethod == null)
                     throw new InvalidOperationException("The template method for converting a TList to a Dataset has been altered. Can not include child collections.");

                  //create a return reference, don't assign immediately, in case it's null.
                  object childDataset = null;
                  childDataset = addRelationsMethod.Invoke(Convert.ChangeType(child.GetValue(childEntity), child.PropertyType), childEntityParams);

                  // ensure obj not null, 
                  if (childDataset == null)
                     throw new ArgumentException("Could not successfully convert nested child relationships to a dataset, consider a shallow conversion.");

                  //convert it to my dataset, now filled another child
                  dataset = (System.Data.DataSet)childDataset;
               }
            }
         }
         #endregion

         //finally return the dataset
         return dataset;
      }
      #endregion
      #endregion

   }

   #region Sort Comparer
   /// <summary>
   /// Generic Sort comparer for the <see cref="TList{T}"/> class.
   /// </summary>
   /// <typeparam name="T">Type of object to sort.</typeparam>
   public class SortComparer<T> : IComparer<T>
   {
      /// <summary>
      /// Collection of properties to sort by.
      /// </summary>
      private ListSortDescriptionCollection m_SortCollection = null;

      /// <summary>
      /// Property to sort by.
      /// </summary>
      private PropertyDescriptor m_PropDesc = null;

      /// <summary>
      /// Direction to sort by
      /// </summary>
      private ListSortDirection m_Direction = ListSortDirection.Ascending;

      /// <summary>
      /// Collection of properties for T.
      /// </summary>
      private PropertyDescriptorCollection m_PropertyDescriptors = null;

      /// <summary>
      /// Create a new instance of the SortComparer class.
      /// </summary>
      /// <param name="propDesc">The <see cref="PropertyDescriptor"/> to sort by.</param>
      /// <param name="direction">The <see cref="ListSortDirection"/> to sort the list.</param>
      public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
      {
         Initialize();
         m_PropDesc = propDesc;
         m_Direction = direction;
      }

      /// <summary>
      /// Create a new instance of the SortComparer class.
      /// </summary>
      /// <param name="sortCollection">A <see cref="ListSortDescriptionCollection"/> containing the properties to sort the list by.</param>
      public SortComparer(ListSortDescriptionCollection sortCollection)
      {
         Initialize();
         m_SortCollection = sortCollection;
      }

      /// <summary>
      /// Create a new instance of the SortComparer class.
      /// </summary>
      /// <param name="orderBy">SQL-like string representing the properties to sort the list by.</param>
      /// <remarks><i>orderBy</i> should be in the following format: 
      /// <para>PropertyName[[ [[ASC]|DESC]][, PropertyName[ [[ASC]|DESC]][,...]]]</para></remarks>
      /// <example><c>list.Sort("Property1, Property2 DESC, Property3 ASC");</c></example>
      public SortComparer(string orderBy)
      {
         Initialize();
         m_SortCollection = ParseOrderBy(orderBy);
      }

      #region IComparer<T> Members

      /// <summary>
      /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
      /// </summary>
      /// <param name="x">The first object to compare.</param>
      /// <param name="y">The second object to compare.</param>
      /// <returns>Value is less than zero: <c>x</c> is less than <c>y</c>
      /// <para>Value is equal to zero: <c>x</c> equals <c>y</c></para>
      /// <para>Value is greater than zero: <c>x</c> is greater than <c>y</c></para>
      /// </returns>
      public int Compare(T x, T y)
      {
         if (m_PropDesc != null) // Simple sort 
         {
            object xValue = m_PropDesc.GetValue(x);
            object yValue = m_PropDesc.GetValue(y);
            return CompareValues(xValue, yValue, m_Direction);
         }
         else if (m_SortCollection != null && m_SortCollection.Count > 0)
         {
            return RecursiveCompareInternal(x, y, 0);
         }
         else return 0;
      }
      #endregion

      #region Private Methods

      /// <summary>
      /// Compare two objects
      /// </summary>
      /// <param name="xValue">The first object to compare</param>
      /// <param name="yValue">The second object to compare</param>
      /// <param name="direction">The direction to sort the objects in</param>
      /// <returns>Returns an integer representing the order of the objects</returns>
      private int CompareValues(object xValue, object yValue, ListSortDirection direction)
      {

         int retValue = 0;
         if (xValue != null && yValue == null)
         {
            retValue = 1;
         }
         else if (xValue == null && yValue != null)
         {
            retValue = -1;

         }
         else if (xValue == null && yValue == null)
         {
            retValue = 0;
         }
         else if (xValue is IComparable) // Can ask the x value
         {
            retValue = ((IComparable)xValue).CompareTo(yValue);
         }
         else if (yValue is IComparable) //Can ask the y value
         {
            retValue = ((IComparable)yValue).CompareTo(xValue);
         }
         else if (!xValue.Equals(yValue)) // not comparable, compare String representations
         {
            retValue = xValue.ToString().CompareTo(yValue.ToString());
         }
         if (direction == ListSortDirection.Ascending)
         {
            return retValue;
         }
         else
         {
            return retValue * -1;
         }
      }

      private int RecursiveCompareInternal(T x, T y, int index)
      {
         if (index >= m_SortCollection.Count)
            return 0; // termination condition

         ListSortDescription listSortDesc = m_SortCollection[index];
         object xValue = listSortDesc.PropertyDescriptor.GetValue(x);
         object yValue = listSortDesc.PropertyDescriptor.GetValue(y);

         int retValue = CompareValues(xValue, yValue, listSortDesc.SortDirection);
         if (retValue == 0)
         {
            return RecursiveCompareInternal(x, y, ++index);
         }
         else
         {
            return retValue;
         }
      }

      /// <summary>
      /// Parses a string into a <see cref="ListSortDescriptionCollection"/>.
      /// </summary>
      /// <param name="orderBy">SQL-like string of sort properties</param>
      /// <returns></returns>
      private ListSortDescriptionCollection ParseOrderBy(string orderBy)
      {
         if (orderBy == null || orderBy.Length == 0)
            throw new ArgumentNullException("orderBy");

         string[] props = orderBy.Split(',');
         ListSortDescription[] sortProps = new ListSortDescription[props.Length];
         string prop;
         ListSortDirection sortDirection = ListSortDirection.Ascending;

         for (int i = 0; i < props.Length; i++)
         {
            //Default to Ascending
            sortDirection = ListSortDirection.Ascending;
            prop = props[i].Trim();

            if (prop.ToUpper().EndsWith(" DESC"))
            {
               sortDirection = ListSortDirection.Descending;
               prop = prop.Substring(0, prop.ToUpper().LastIndexOf(" DESC"));
            }
            else if (prop.ToUpper().EndsWith(" ASC"))
            {
               prop = prop.Substring(0, prop.ToUpper().LastIndexOf(" ASC"));
            }

            prop = prop.Trim();

            //Get the appropriate descriptor
            PropertyDescriptor propertyDescriptor = m_PropertyDescriptors[prop];

            if (propertyDescriptor == null)
            {
               throw new ArgumentException(string.Format("The property \"{0}\" is not a valid property.", prop));
            }
            sortProps[i] = new ListSortDescription(propertyDescriptor, sortDirection);

         }

         return new ListSortDescriptionCollection(sortProps);
      }

      /// <summary>
      /// Initializes the SortComparer object
      /// </summary>
      private void Initialize()
      {
         Type instanceType = typeof(T);

         if (!instanceType.IsPublic)
            throw new ArgumentException(string.Format("Type \"{0}\" is not public.", typeof(T).FullName));

         m_PropertyDescriptors = TypeDescriptor.GetProperties(typeof(T));

      }

      #endregion
   }
   #endregion
}

#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using AIProject.Entities;
using AIProject.Data;

#endregion

namespace AIProject.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="OccupationTypeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OccupationTypeProviderBaseCore : EntityProviderBase<AIProject.Entities.OccupationType, AIProject.Entities.OccupationTypeKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, AIProject.Entities.OccupationTypeKey key)
		{
			return Delete(transactionManager, key.OccupationTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_occupationTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _occupationTypeId)
		{
			return Delete(null, _occupationTypeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_occupationTypeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _occupationTypeId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override AIProject.Entities.OccupationType Get(TransactionManager transactionManager, AIProject.Entities.OccupationTypeKey key, int start, int pageLength)
		{
			return GetByOccupationTypeId(transactionManager, key.OccupationTypeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_OccupationType index.
		/// </summary>
		/// <param name="_occupationTypeId"></param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.OccupationType"/> class.</returns>
		public AIProject.Entities.OccupationType GetByOccupationTypeId(System.Int32 _occupationTypeId)
		{
			int count = -1;
			return GetByOccupationTypeId(null,_occupationTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OccupationType index.
		/// </summary>
		/// <param name="_occupationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.OccupationType"/> class.</returns>
		public AIProject.Entities.OccupationType GetByOccupationTypeId(System.Int32 _occupationTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByOccupationTypeId(null, _occupationTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OccupationType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_occupationTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.OccupationType"/> class.</returns>
		public AIProject.Entities.OccupationType GetByOccupationTypeId(TransactionManager transactionManager, System.Int32 _occupationTypeId)
		{
			int count = -1;
			return GetByOccupationTypeId(transactionManager, _occupationTypeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OccupationType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_occupationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.OccupationType"/> class.</returns>
		public AIProject.Entities.OccupationType GetByOccupationTypeId(TransactionManager transactionManager, System.Int32 _occupationTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByOccupationTypeId(transactionManager, _occupationTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OccupationType index.
		/// </summary>
		/// <param name="_occupationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.OccupationType"/> class.</returns>
		public AIProject.Entities.OccupationType GetByOccupationTypeId(System.Int32 _occupationTypeId, int start, int pageLength, out int count)
		{
			return GetByOccupationTypeId(null, _occupationTypeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_OccupationType index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_occupationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.OccupationType"/> class.</returns>
		public abstract AIProject.Entities.OccupationType GetByOccupationTypeId(TransactionManager transactionManager, System.Int32 _occupationTypeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;OccupationType&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;OccupationType&gt;"/></returns>
		public static TList<OccupationType> Fill(IDataReader reader, TList<OccupationType> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				AIProject.Entities.OccupationType c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("OccupationType")
					.Append("|").Append((System.Int32)reader[((int)OccupationTypeColumn.OccupationTypeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<OccupationType>(
					key.ToString(), // EntityTrackingKey
					"OccupationType",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIProject.Entities.OccupationType();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.OccupationTypeId = (System.Int32)reader[((int)OccupationTypeColumn.OccupationTypeId - 1)];
					c.OriginalOccupationTypeId = c.OccupationTypeId;
					c.OccupationName = (reader.IsDBNull(((int)OccupationTypeColumn.OccupationName - 1)))?null:(System.String)reader[((int)OccupationTypeColumn.OccupationName - 1)];
					c.Note = (reader.IsDBNull(((int)OccupationTypeColumn.Note - 1)))?null:(System.String)reader[((int)OccupationTypeColumn.Note - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.OccupationType"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.OccupationType"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIProject.Entities.OccupationType entity)
		{
			if (!reader.Read()) return;
			
			entity.OccupationTypeId = (System.Int32)reader[((int)OccupationTypeColumn.OccupationTypeId - 1)];
			entity.OriginalOccupationTypeId = (System.Int32)reader["OccupationTypeId"];
			entity.OccupationName = (reader.IsDBNull(((int)OccupationTypeColumn.OccupationName - 1)))?null:(System.String)reader[((int)OccupationTypeColumn.OccupationName - 1)];
			entity.Note = (reader.IsDBNull(((int)OccupationTypeColumn.Note - 1)))?null:(System.String)reader[((int)OccupationTypeColumn.Note - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.OccupationType"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.OccupationType"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIProject.Entities.OccupationType entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OccupationTypeId = (System.Int32)dataRow["OccupationTypeId"];
			entity.OriginalOccupationTypeId = (System.Int32)dataRow["OccupationTypeId"];
			entity.OccupationName = Convert.IsDBNull(dataRow["OccupationName"]) ? null : (System.String)dataRow["OccupationName"];
			entity.Note = Convert.IsDBNull(dataRow["Note"]) ? null : (System.String)dataRow["Note"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="AIProject.Entities.OccupationType"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIProject.Entities.OccupationType Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIProject.Entities.OccupationType entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByOccupationTypeId methods when available
			
			#region CustomerDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CustomerDetails>|CustomerDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CustomerDetailsCollection = DataRepository.CustomerDetailsProvider.GetByOccupationTypeId(transactionManager, entity.OccupationTypeId);

				if (deep && entity.CustomerDetailsCollection.Count > 0)
				{
					deepHandles.Add("CustomerDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CustomerDetails>) DataRepository.CustomerDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.CustomerDetailsCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the AIProject.Entities.OccupationType object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIProject.Entities.OccupationType instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIProject.Entities.OccupationType Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIProject.Entities.OccupationType entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<CustomerDetails>
				if (CanDeepSave(entity.CustomerDetailsCollection, "List<CustomerDetails>|CustomerDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CustomerDetails child in entity.CustomerDetailsCollection)
					{
						if(child.OccupationTypeIdSource != null)
						{
							child.OccupationTypeId = child.OccupationTypeIdSource.OccupationTypeId;
						}
						else
						{
							child.OccupationTypeId = entity.OccupationTypeId;
						}

					}

					if (entity.CustomerDetailsCollection.Count > 0 || entity.CustomerDetailsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CustomerDetailsProvider.Save(transactionManager, entity.CustomerDetailsCollection);
						
						deepHandles.Add("CustomerDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CustomerDetails >) DataRepository.CustomerDetailsProvider.DeepSave,
							new object[] { transactionManager, entity.CustomerDetailsCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region OccupationTypeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIProject.Entities.OccupationType</c>
	///</summary>
	public enum OccupationTypeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>OccupationType</c> as OneToMany for CustomerDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<CustomerDetails>))]
		CustomerDetailsCollection,
	}
	
	#endregion OccupationTypeChildEntityTypes
	
	#region OccupationTypeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;OccupationTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OccupationTypeFilterBuilder : SqlFilterBuilder<OccupationTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OccupationTypeFilterBuilder class.
		/// </summary>
		public OccupationTypeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OccupationTypeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OccupationTypeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OccupationTypeFilterBuilder
	
	#region OccupationTypeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;OccupationTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OccupationTypeParameterBuilder : ParameterizedSqlFilterBuilder<OccupationTypeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OccupationTypeParameterBuilder class.
		/// </summary>
		public OccupationTypeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OccupationTypeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OccupationTypeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OccupationTypeParameterBuilder
	
	#region OccupationTypeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;OccupationTypeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class OccupationTypeSortBuilder : SqlSortBuilder<OccupationTypeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OccupationTypeSqlSortBuilder class.
		/// </summary>
		public OccupationTypeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion OccupationTypeSortBuilder
	
} // end namespace

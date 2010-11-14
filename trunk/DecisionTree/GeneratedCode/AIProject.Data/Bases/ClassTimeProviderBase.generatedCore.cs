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
	/// This class is the base class for any <see cref="ClassTimeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClassTimeProviderBaseCore : EntityProviderBase<AIProject.Entities.ClassTime, AIProject.Entities.ClassTimeKey>
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
		public override bool Delete(TransactionManager transactionManager, AIProject.Entities.ClassTimeKey key)
		{
			return Delete(transactionManager, key.ClassTimeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_classTimeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _classTimeId)
		{
			return Delete(null, _classTimeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classTimeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _classTimeId);		
		
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
		public override AIProject.Entities.ClassTime Get(TransactionManager transactionManager, AIProject.Entities.ClassTimeKey key, int start, int pageLength)
		{
			return GetByClassTimeId(transactionManager, key.ClassTimeId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClassTime index.
		/// </summary>
		/// <param name="_classTimeId"></param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassTime"/> class.</returns>
		public AIProject.Entities.ClassTime GetByClassTimeId(System.Int32 _classTimeId)
		{
			int count = -1;
			return GetByClassTimeId(null,_classTimeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassTime index.
		/// </summary>
		/// <param name="_classTimeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassTime"/> class.</returns>
		public AIProject.Entities.ClassTime GetByClassTimeId(System.Int32 _classTimeId, int start, int pageLength)
		{
			int count = -1;
			return GetByClassTimeId(null, _classTimeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classTimeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassTime"/> class.</returns>
		public AIProject.Entities.ClassTime GetByClassTimeId(TransactionManager transactionManager, System.Int32 _classTimeId)
		{
			int count = -1;
			return GetByClassTimeId(transactionManager, _classTimeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classTimeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassTime"/> class.</returns>
		public AIProject.Entities.ClassTime GetByClassTimeId(TransactionManager transactionManager, System.Int32 _classTimeId, int start, int pageLength)
		{
			int count = -1;
			return GetByClassTimeId(transactionManager, _classTimeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassTime index.
		/// </summary>
		/// <param name="_classTimeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassTime"/> class.</returns>
		public AIProject.Entities.ClassTime GetByClassTimeId(System.Int32 _classTimeId, int start, int pageLength, out int count)
		{
			return GetByClassTimeId(null, _classTimeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassTime index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classTimeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassTime"/> class.</returns>
		public abstract AIProject.Entities.ClassTime GetByClassTimeId(TransactionManager transactionManager, System.Int32 _classTimeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClassTime&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClassTime&gt;"/></returns>
		public static TList<ClassTime> Fill(IDataReader reader, TList<ClassTime> rows, int start, int pageLength)
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
				
				AIProject.Entities.ClassTime c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClassTime")
					.Append("|").Append((System.Int32)reader[((int)ClassTimeColumn.ClassTimeId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClassTime>(
					key.ToString(), // EntityTrackingKey
					"ClassTime",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIProject.Entities.ClassTime();
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
					c.ClassTimeId = (System.Int32)reader[((int)ClassTimeColumn.ClassTimeId - 1)];
					c.OriginalClassTimeId = c.ClassTimeId;
					c.TimeName = (reader.IsDBNull(((int)ClassTimeColumn.TimeName - 1)))?null:(System.String)reader[((int)ClassTimeColumn.TimeName - 1)];
					c.Note = (reader.IsDBNull(((int)ClassTimeColumn.Note - 1)))?null:(System.String)reader[((int)ClassTimeColumn.Note - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.ClassTime"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.ClassTime"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIProject.Entities.ClassTime entity)
		{
			if (!reader.Read()) return;
			
			entity.ClassTimeId = (System.Int32)reader[((int)ClassTimeColumn.ClassTimeId - 1)];
			entity.OriginalClassTimeId = (System.Int32)reader["ClassTimeId"];
			entity.TimeName = (reader.IsDBNull(((int)ClassTimeColumn.TimeName - 1)))?null:(System.String)reader[((int)ClassTimeColumn.TimeName - 1)];
			entity.Note = (reader.IsDBNull(((int)ClassTimeColumn.Note - 1)))?null:(System.String)reader[((int)ClassTimeColumn.Note - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.ClassTime"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.ClassTime"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIProject.Entities.ClassTime entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ClassTimeId = (System.Int32)dataRow["ClassTimeId"];
			entity.OriginalClassTimeId = (System.Int32)dataRow["ClassTimeId"];
			entity.TimeName = Convert.IsDBNull(dataRow["TimeName"]) ? null : (System.String)dataRow["TimeName"];
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
		/// <param name="entity">The <see cref="AIProject.Entities.ClassTime"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIProject.Entities.ClassTime Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIProject.Entities.ClassTime entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByClassTimeId methods when available
			
			#region ClassDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ClassDetails>|ClassDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClassDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClassDetailsCollection = DataRepository.ClassDetailsProvider.GetByClassTime(transactionManager, entity.ClassTimeId);

				if (deep && entity.ClassDetailsCollection.Count > 0)
				{
					deepHandles.Add("ClassDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ClassDetails>) DataRepository.ClassDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.ClassDetailsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the AIProject.Entities.ClassTime object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIProject.Entities.ClassTime instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIProject.Entities.ClassTime Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIProject.Entities.ClassTime entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<ClassDetails>
				if (CanDeepSave(entity.ClassDetailsCollection, "List<ClassDetails>|ClassDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ClassDetails child in entity.ClassDetailsCollection)
					{
						if(child.ClassTimeSource != null)
						{
							child.ClassTime = child.ClassTimeSource.ClassTimeId;
						}
						else
						{
							child.ClassTime = entity.ClassTimeId;
						}

					}

					if (entity.ClassDetailsCollection.Count > 0 || entity.ClassDetailsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ClassDetailsProvider.Save(transactionManager, entity.ClassDetailsCollection);
						
						deepHandles.Add("ClassDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ClassDetails >) DataRepository.ClassDetailsProvider.DeepSave,
							new object[] { transactionManager, entity.ClassDetailsCollection, deepSaveType, childTypes, innerList }
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
	
	#region ClassTimeChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIProject.Entities.ClassTime</c>
	///</summary>
	public enum ClassTimeChildEntityTypes
	{

		///<summary>
		/// Collection of <c>ClassTime</c> as OneToMany for ClassDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClassDetails>))]
		ClassDetailsCollection,
	}
	
	#endregion ClassTimeChildEntityTypes
	
	#region ClassTimeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClassTimeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassTimeFilterBuilder : SqlFilterBuilder<ClassTimeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassTimeFilterBuilder class.
		/// </summary>
		public ClassTimeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassTimeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassTimeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassTimeFilterBuilder
	
	#region ClassTimeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClassTimeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassTimeParameterBuilder : ParameterizedSqlFilterBuilder<ClassTimeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassTimeParameterBuilder class.
		/// </summary>
		public ClassTimeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassTimeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassTimeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassTimeParameterBuilder
	
	#region ClassTimeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClassTimeColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClassTimeSortBuilder : SqlSortBuilder<ClassTimeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassTimeSqlSortBuilder class.
		/// </summary>
		public ClassTimeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClassTimeSortBuilder
	
} // end namespace

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
	/// This class is the base class for any <see cref="CourseGroupProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CourseGroupProviderBaseCore : EntityProviderBase<AIProject.Entities.CourseGroup, AIProject.Entities.CourseGroupKey>
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
		public override bool Delete(TransactionManager transactionManager, AIProject.Entities.CourseGroupKey key)
		{
			return Delete(transactionManager, key.CourseGroupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_courseGroupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _courseGroupId)
		{
			return Delete(null, _courseGroupId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseGroupId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _courseGroupId);		
		
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
		public override AIProject.Entities.CourseGroup Get(TransactionManager transactionManager, AIProject.Entities.CourseGroupKey key, int start, int pageLength)
		{
			return GetByCourseGroupId(transactionManager, key.CourseGroupId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CourseGroup index.
		/// </summary>
		/// <param name="_courseGroupId"></param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CourseGroup"/> class.</returns>
		public AIProject.Entities.CourseGroup GetByCourseGroupId(System.Int32 _courseGroupId)
		{
			int count = -1;
			return GetByCourseGroupId(null,_courseGroupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseGroup index.
		/// </summary>
		/// <param name="_courseGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CourseGroup"/> class.</returns>
		public AIProject.Entities.CourseGroup GetByCourseGroupId(System.Int32 _courseGroupId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourseGroupId(null, _courseGroupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseGroupId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CourseGroup"/> class.</returns>
		public AIProject.Entities.CourseGroup GetByCourseGroupId(TransactionManager transactionManager, System.Int32 _courseGroupId)
		{
			int count = -1;
			return GetByCourseGroupId(transactionManager, _courseGroupId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CourseGroup"/> class.</returns>
		public AIProject.Entities.CourseGroup GetByCourseGroupId(TransactionManager transactionManager, System.Int32 _courseGroupId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourseGroupId(transactionManager, _courseGroupId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseGroup index.
		/// </summary>
		/// <param name="_courseGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CourseGroup"/> class.</returns>
		public AIProject.Entities.CourseGroup GetByCourseGroupId(System.Int32 _courseGroupId, int start, int pageLength, out int count)
		{
			return GetByCourseGroupId(null, _courseGroupId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseGroup index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseGroupId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CourseGroup"/> class.</returns>
		public abstract AIProject.Entities.CourseGroup GetByCourseGroupId(TransactionManager transactionManager, System.Int32 _courseGroupId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CourseGroup&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CourseGroup&gt;"/></returns>
		public static TList<CourseGroup> Fill(IDataReader reader, TList<CourseGroup> rows, int start, int pageLength)
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
				
				AIProject.Entities.CourseGroup c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CourseGroup")
					.Append("|").Append((System.Int32)reader[((int)CourseGroupColumn.CourseGroupId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CourseGroup>(
					key.ToString(), // EntityTrackingKey
					"CourseGroup",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIProject.Entities.CourseGroup();
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
					c.CourseGroupId = (System.Int32)reader[((int)CourseGroupColumn.CourseGroupId - 1)];
					c.OriginalCourseGroupId = c.CourseGroupId;
					c.Name = (reader.IsDBNull(((int)CourseGroupColumn.Name - 1)))?null:(System.String)reader[((int)CourseGroupColumn.Name - 1)];
					c.Note = (reader.IsDBNull(((int)CourseGroupColumn.Note - 1)))?null:(System.String)reader[((int)CourseGroupColumn.Note - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.CourseGroup"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.CourseGroup"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIProject.Entities.CourseGroup entity)
		{
			if (!reader.Read()) return;
			
			entity.CourseGroupId = (System.Int32)reader[((int)CourseGroupColumn.CourseGroupId - 1)];
			entity.OriginalCourseGroupId = (System.Int32)reader["CourseGroupId"];
			entity.Name = (reader.IsDBNull(((int)CourseGroupColumn.Name - 1)))?null:(System.String)reader[((int)CourseGroupColumn.Name - 1)];
			entity.Note = (reader.IsDBNull(((int)CourseGroupColumn.Note - 1)))?null:(System.String)reader[((int)CourseGroupColumn.Note - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.CourseGroup"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.CourseGroup"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIProject.Entities.CourseGroup entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CourseGroupId = (System.Int32)dataRow["CourseGroupId"];
			entity.OriginalCourseGroupId = (System.Int32)dataRow["CourseGroupId"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
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
		/// <param name="entity">The <see cref="AIProject.Entities.CourseGroup"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIProject.Entities.CourseGroup Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIProject.Entities.CourseGroup entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCourseGroupId methods when available
			
			#region CourseDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<CourseDetails>|CourseDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CourseDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.CourseDetailsCollection = DataRepository.CourseDetailsProvider.GetByCourseGroup(transactionManager, entity.CourseGroupId);

				if (deep && entity.CourseDetailsCollection.Count > 0)
				{
					deepHandles.Add("CourseDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<CourseDetails>) DataRepository.CourseDetailsProvider.DeepLoad,
						new object[] { transactionManager, entity.CourseDetailsCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the AIProject.Entities.CourseGroup object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIProject.Entities.CourseGroup instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIProject.Entities.CourseGroup Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIProject.Entities.CourseGroup entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<CourseDetails>
				if (CanDeepSave(entity.CourseDetailsCollection, "List<CourseDetails>|CourseDetailsCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(CourseDetails child in entity.CourseDetailsCollection)
					{
						if(child.CourseGroupSource != null)
						{
							child.CourseGroup = child.CourseGroupSource.CourseGroupId;
						}
						else
						{
							child.CourseGroup = entity.CourseGroupId;
						}

					}

					if (entity.CourseDetailsCollection.Count > 0 || entity.CourseDetailsCollection.DeletedItems.Count > 0)
					{
						//DataRepository.CourseDetailsProvider.Save(transactionManager, entity.CourseDetailsCollection);
						
						deepHandles.Add("CourseDetailsCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< CourseDetails >) DataRepository.CourseDetailsProvider.DeepSave,
							new object[] { transactionManager, entity.CourseDetailsCollection, deepSaveType, childTypes, innerList }
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
	
	#region CourseGroupChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIProject.Entities.CourseGroup</c>
	///</summary>
	public enum CourseGroupChildEntityTypes
	{

		///<summary>
		/// Collection of <c>CourseGroup</c> as OneToMany for CourseDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<CourseDetails>))]
		CourseDetailsCollection,
	}
	
	#endregion CourseGroupChildEntityTypes
	
	#region CourseGroupFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CourseGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseGroupFilterBuilder : SqlFilterBuilder<CourseGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseGroupFilterBuilder class.
		/// </summary>
		public CourseGroupFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseGroupFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseGroupFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseGroupFilterBuilder
	
	#region CourseGroupParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CourseGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseGroupParameterBuilder : ParameterizedSqlFilterBuilder<CourseGroupColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseGroupParameterBuilder class.
		/// </summary>
		public CourseGroupParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseGroupParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseGroupParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseGroupParameterBuilder
	
	#region CourseGroupSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CourseGroupColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CourseGroupSortBuilder : SqlSortBuilder<CourseGroupColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseGroupSqlSortBuilder class.
		/// </summary>
		public CourseGroupSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CourseGroupSortBuilder
	
} // end namespace

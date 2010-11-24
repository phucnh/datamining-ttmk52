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
	/// This class is the base class for any <see cref="TeacherDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class TeacherDetailsProviderBaseCore : EntityProviderBase<AIProject.Entities.TeacherDetails, AIProject.Entities.TeacherDetailsKey>
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
		public override bool Delete(TransactionManager transactionManager, AIProject.Entities.TeacherDetailsKey key)
		{
			return Delete(transactionManager, key.TeacherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_teacherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _teacherId)
		{
			return Delete(null, _teacherId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _teacherId);		
		
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
		public override AIProject.Entities.TeacherDetails Get(TransactionManager transactionManager, AIProject.Entities.TeacherDetailsKey key, int start, int pageLength)
		{
			return GetByTeacherId(transactionManager, key.TeacherId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_TeacherDetails index.
		/// </summary>
		/// <param name="_teacherId"></param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.TeacherDetails"/> class.</returns>
		public AIProject.Entities.TeacherDetails GetByTeacherId(System.Int32 _teacherId)
		{
			int count = -1;
			return GetByTeacherId(null,_teacherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TeacherDetails index.
		/// </summary>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.TeacherDetails"/> class.</returns>
		public AIProject.Entities.TeacherDetails GetByTeacherId(System.Int32 _teacherId, int start, int pageLength)
		{
			int count = -1;
			return GetByTeacherId(null, _teacherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TeacherDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.TeacherDetails"/> class.</returns>
		public AIProject.Entities.TeacherDetails GetByTeacherId(TransactionManager transactionManager, System.Int32 _teacherId)
		{
			int count = -1;
			return GetByTeacherId(transactionManager, _teacherId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TeacherDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.TeacherDetails"/> class.</returns>
		public AIProject.Entities.TeacherDetails GetByTeacherId(TransactionManager transactionManager, System.Int32 _teacherId, int start, int pageLength)
		{
			int count = -1;
			return GetByTeacherId(transactionManager, _teacherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TeacherDetails index.
		/// </summary>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.TeacherDetails"/> class.</returns>
		public AIProject.Entities.TeacherDetails GetByTeacherId(System.Int32 _teacherId, int start, int pageLength, out int count)
		{
			return GetByTeacherId(null, _teacherId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_TeacherDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.TeacherDetails"/> class.</returns>
		public abstract AIProject.Entities.TeacherDetails GetByTeacherId(TransactionManager transactionManager, System.Int32 _teacherId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;TeacherDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;TeacherDetails&gt;"/></returns>
		public static TList<TeacherDetails> Fill(IDataReader reader, TList<TeacherDetails> rows, int start, int pageLength)
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
				
				AIProject.Entities.TeacherDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("TeacherDetails")
					.Append("|").Append((System.Int32)reader[((int)TeacherDetailsColumn.TeacherId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<TeacherDetails>(
					key.ToString(), // EntityTrackingKey
					"TeacherDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIProject.Entities.TeacherDetails();
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
					c.TeacherId = (System.Int32)reader[((int)TeacherDetailsColumn.TeacherId - 1)];
					c.TeacherName = (reader.IsDBNull(((int)TeacherDetailsColumn.TeacherName - 1)))?null:(System.String)reader[((int)TeacherDetailsColumn.TeacherName - 1)];
					c.TeacherCertificate = (reader.IsDBNull(((int)TeacherDetailsColumn.TeacherCertificate - 1)))?null:(System.Int32?)reader[((int)TeacherDetailsColumn.TeacherCertificate - 1)];
					c.Note = (reader.IsDBNull(((int)TeacherDetailsColumn.Note - 1)))?null:(System.String)reader[((int)TeacherDetailsColumn.Note - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.TeacherDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.TeacherDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIProject.Entities.TeacherDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.TeacherId = (System.Int32)reader[((int)TeacherDetailsColumn.TeacherId - 1)];
			entity.TeacherName = (reader.IsDBNull(((int)TeacherDetailsColumn.TeacherName - 1)))?null:(System.String)reader[((int)TeacherDetailsColumn.TeacherName - 1)];
			entity.TeacherCertificate = (reader.IsDBNull(((int)TeacherDetailsColumn.TeacherCertificate - 1)))?null:(System.Int32?)reader[((int)TeacherDetailsColumn.TeacherCertificate - 1)];
			entity.Note = (reader.IsDBNull(((int)TeacherDetailsColumn.Note - 1)))?null:(System.String)reader[((int)TeacherDetailsColumn.Note - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.TeacherDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.TeacherDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIProject.Entities.TeacherDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.TeacherId = (System.Int32)dataRow["TeacherId"];
			entity.TeacherName = Convert.IsDBNull(dataRow["TeacherName"]) ? null : (System.String)dataRow["TeacherName"];
			entity.TeacherCertificate = Convert.IsDBNull(dataRow["TeacherCertificate"]) ? null : (System.Int32?)dataRow["TeacherCertificate"];
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
		/// <param name="entity">The <see cref="AIProject.Entities.TeacherDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIProject.Entities.TeacherDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIProject.Entities.TeacherDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByTeacherId methods when available
			
			#region ClassDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ClassDetails>|ClassDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClassDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClassDetailsCollection = DataRepository.ClassDetailsProvider.GetByTeacherId(transactionManager, entity.TeacherId);

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
		/// Deep Save the entire object graph of the AIProject.Entities.TeacherDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIProject.Entities.TeacherDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIProject.Entities.TeacherDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIProject.Entities.TeacherDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
						if(child.TeacherIdSource != null)
						{
							child.TeacherId = child.TeacherIdSource.TeacherId;
						}
						else
						{
							child.TeacherId = entity.TeacherId;
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
	
	#region TeacherDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIProject.Entities.TeacherDetails</c>
	///</summary>
	public enum TeacherDetailsChildEntityTypes
	{

		///<summary>
		/// Collection of <c>TeacherDetails</c> as OneToMany for ClassDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClassDetails>))]
		ClassDetailsCollection,
	}
	
	#endregion TeacherDetailsChildEntityTypes
	
	#region TeacherDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;TeacherDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherDetailsFilterBuilder : SqlFilterBuilder<TeacherDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsFilterBuilder class.
		/// </summary>
		public TeacherDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherDetailsFilterBuilder
	
	#region TeacherDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;TeacherDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherDetailsParameterBuilder : ParameterizedSqlFilterBuilder<TeacherDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsParameterBuilder class.
		/// </summary>
		public TeacherDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherDetailsParameterBuilder
	
	#region TeacherDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;TeacherDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class TeacherDetailsSortBuilder : SqlSortBuilder<TeacherDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsSqlSortBuilder class.
		/// </summary>
		public TeacherDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion TeacherDetailsSortBuilder
	
} // end namespace

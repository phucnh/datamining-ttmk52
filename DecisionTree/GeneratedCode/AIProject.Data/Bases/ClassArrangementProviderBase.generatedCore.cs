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
	/// This class is the base class for any <see cref="ClassArrangementProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClassArrangementProviderBaseCore : EntityProviderBase<AIProject.Entities.ClassArrangement, AIProject.Entities.ClassArrangementKey>
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
		public override bool Delete(TransactionManager transactionManager, AIProject.Entities.ClassArrangementKey key)
		{
			return Delete(transactionManager, key.CustomerId, key.ClassId, key.CreateDate);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">. Primary Key.</param>
		/// <param name="_classId">. Primary Key.</param>
		/// <param name="_createDate">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate)
		{
			return Delete(null, _customerId, _classId, _createDate);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <param name="_classId">. Primary Key.</param>
		/// <param name="_createDate">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_ClassDetails key.
		///		FK_ClassArrangement_ClassDetails Description: 
		/// </summary>
		/// <param name="_classId"></param>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByClassId(System.Int32 _classId)
		{
			int count = -1;
			return GetByClassId(_classId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_ClassDetails key.
		///		FK_ClassArrangement_ClassDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classId"></param>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		/// <remarks></remarks>
		public TList<ClassArrangement> GetByClassId(TransactionManager transactionManager, System.Int32 _classId)
		{
			int count = -1;
			return GetByClassId(transactionManager, _classId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_ClassDetails key.
		///		FK_ClassArrangement_ClassDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByClassId(TransactionManager transactionManager, System.Int32 _classId, int start, int pageLength)
		{
			int count = -1;
			return GetByClassId(transactionManager, _classId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_ClassDetails key.
		///		fkClassArrangementClassDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_classId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByClassId(System.Int32 _classId, int start, int pageLength)
		{
			int count =  -1;
			return GetByClassId(null, _classId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_ClassDetails key.
		///		fkClassArrangementClassDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_classId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByClassId(System.Int32 _classId, int start, int pageLength,out int count)
		{
			return GetByClassId(null, _classId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_ClassDetails key.
		///		FK_ClassArrangement_ClassDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public abstract TList<ClassArrangement> GetByClassId(TransactionManager transactionManager, System.Int32 _classId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_CustomerDetails key.
		///		FK_ClassArrangement_CustomerDetails Description: 
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(_customerId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_CustomerDetails key.
		///		FK_ClassArrangement_CustomerDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		/// <remarks></remarks>
		public TList<ClassArrangement> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_CustomerDetails key.
		///		FK_ClassArrangement_CustomerDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_CustomerDetails key.
		///		fkClassArrangementCustomerDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomerId(null, _customerId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_CustomerDetails key.
		///		fkClassArrangementCustomerDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public TList<ClassArrangement> GetByCustomerId(System.Int32 _customerId, int start, int pageLength,out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassArrangement_CustomerDetails key.
		///		FK_ClassArrangement_CustomerDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIProject.Entities.ClassArrangement objects.</returns>
		public abstract TList<ClassArrangement> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
		
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
		public override AIProject.Entities.ClassArrangement Get(TransactionManager transactionManager, AIProject.Entities.ClassArrangementKey key, int start, int pageLength)
		{
			return GetByCustomerIdClassIdCreateDate(transactionManager, key.CustomerId, key.ClassId, key.CreateDate, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClassArrangement index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_classId"></param>
		/// <param name="_createDate"></param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassArrangement"/> class.</returns>
		public AIProject.Entities.ClassArrangement GetByCustomerIdClassIdCreateDate(System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate)
		{
			int count = -1;
			return GetByCustomerIdClassIdCreateDate(null,_customerId, _classId, _createDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassArrangement index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_classId"></param>
		/// <param name="_createDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassArrangement"/> class.</returns>
		public AIProject.Entities.ClassArrangement GetByCustomerIdClassIdCreateDate(System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdClassIdCreateDate(null, _customerId, _classId, _createDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassArrangement index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_classId"></param>
		/// <param name="_createDate"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassArrangement"/> class.</returns>
		public AIProject.Entities.ClassArrangement GetByCustomerIdClassIdCreateDate(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate)
		{
			int count = -1;
			return GetByCustomerIdClassIdCreateDate(transactionManager, _customerId, _classId, _createDate, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassArrangement index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_classId"></param>
		/// <param name="_createDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassArrangement"/> class.</returns>
		public AIProject.Entities.ClassArrangement GetByCustomerIdClassIdCreateDate(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerIdClassIdCreateDate(transactionManager, _customerId, _classId, _createDate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassArrangement index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="_classId"></param>
		/// <param name="_createDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassArrangement"/> class.</returns>
		public AIProject.Entities.ClassArrangement GetByCustomerIdClassIdCreateDate(System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate, int start, int pageLength, out int count)
		{
			return GetByCustomerIdClassIdCreateDate(null, _customerId, _classId, _createDate, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassArrangement index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="_classId"></param>
		/// <param name="_createDate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.ClassArrangement"/> class.</returns>
		public abstract AIProject.Entities.ClassArrangement GetByCustomerIdClassIdCreateDate(TransactionManager transactionManager, System.Int32 _customerId, System.Int32 _classId, System.DateTime _createDate, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClassArrangement&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClassArrangement&gt;"/></returns>
		public static TList<ClassArrangement> Fill(IDataReader reader, TList<ClassArrangement> rows, int start, int pageLength)
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
				
				AIProject.Entities.ClassArrangement c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClassArrangement")
					.Append("|").Append((System.Int32)reader[((int)ClassArrangementColumn.CustomerId - 1)])
					.Append("|").Append((System.Int32)reader[((int)ClassArrangementColumn.ClassId - 1)])
					.Append("|").Append((System.DateTime)reader[((int)ClassArrangementColumn.CreateDate - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClassArrangement>(
					key.ToString(), // EntityTrackingKey
					"ClassArrangement",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIProject.Entities.ClassArrangement();
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
					c.CustomerId = (System.Int32)reader[((int)ClassArrangementColumn.CustomerId - 1)];
					c.OriginalCustomerId = c.CustomerId;
					c.ClassId = (System.Int32)reader[((int)ClassArrangementColumn.ClassId - 1)];
					c.OriginalClassId = c.ClassId;
					c.CreateDate = (System.DateTime)reader[((int)ClassArrangementColumn.CreateDate - 1)];
					c.OriginalCreateDate = c.CreateDate;
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.ClassArrangement"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.ClassArrangement"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIProject.Entities.ClassArrangement entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.Int32)reader[((int)ClassArrangementColumn.CustomerId - 1)];
			entity.OriginalCustomerId = (System.Int32)reader["CustomerId"];
			entity.ClassId = (System.Int32)reader[((int)ClassArrangementColumn.ClassId - 1)];
			entity.OriginalClassId = (System.Int32)reader["ClassId"];
			entity.CreateDate = (System.DateTime)reader[((int)ClassArrangementColumn.CreateDate - 1)];
			entity.OriginalCreateDate = (System.DateTime)reader["CreateDate"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.ClassArrangement"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.ClassArrangement"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIProject.Entities.ClassArrangement entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.Int32)dataRow["CustomerId"];
			entity.OriginalCustomerId = (System.Int32)dataRow["CustomerId"];
			entity.ClassId = (System.Int32)dataRow["ClassId"];
			entity.OriginalClassId = (System.Int32)dataRow["ClassId"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.OriginalCreateDate = (System.DateTime)dataRow["CreateDate"];
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
		/// <param name="entity">The <see cref="AIProject.Entities.ClassArrangement"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIProject.Entities.ClassArrangement Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIProject.Entities.ClassArrangement entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ClassIdSource	
			if (CanDeepLoad(entity, "ClassDetails|ClassIdSource", deepLoadType, innerList) 
				&& entity.ClassIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ClassId;
				ClassDetails tmpEntity = EntityManager.LocateEntity<ClassDetails>(EntityLocator.ConstructKeyFromPkItems(typeof(ClassDetails), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ClassIdSource = tmpEntity;
				else
					entity.ClassIdSource = DataRepository.ClassDetailsProvider.GetByClassId(transactionManager, entity.ClassId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClassIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ClassIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ClassDetailsProvider.DeepLoad(transactionManager, entity.ClassIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ClassIdSource

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "CustomerDetails|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerId;
				CustomerDetails tmpEntity = EntityManager.LocateEntity<CustomerDetails>(EntityLocator.ConstructKeyFromPkItems(typeof(CustomerDetails), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomerDetailsProvider.GetByCustomerId(transactionManager, entity.CustomerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerDetailsProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
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
		/// Deep Save the entire object graph of the AIProject.Entities.ClassArrangement object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIProject.Entities.ClassArrangement instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIProject.Entities.ClassArrangement Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIProject.Entities.ClassArrangement entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ClassIdSource
			if (CanDeepSave(entity, "ClassDetails|ClassIdSource", deepSaveType, innerList) 
				&& entity.ClassIdSource != null)
			{
				DataRepository.ClassDetailsProvider.Save(transactionManager, entity.ClassIdSource);
				entity.ClassId = entity.ClassIdSource.ClassId;
			}
			#endregion 
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "CustomerDetails|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomerDetailsProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.CustomerId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
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
	
	#region ClassArrangementChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIProject.Entities.ClassArrangement</c>
	///</summary>
	public enum ClassArrangementChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ClassDetails</c> at ClassIdSource
		///</summary>
		[ChildEntityType(typeof(ClassDetails))]
		ClassDetails,
			
		///<summary>
		/// Composite Property for <c>CustomerDetails</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(CustomerDetails))]
		CustomerDetails,
		}
	
	#endregion ClassArrangementChildEntityTypes
	
	#region ClassArrangementFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClassArrangementColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassArrangementFilterBuilder : SqlFilterBuilder<ClassArrangementColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassArrangementFilterBuilder class.
		/// </summary>
		public ClassArrangementFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassArrangementFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassArrangementFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassArrangementFilterBuilder
	
	#region ClassArrangementParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClassArrangementColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassArrangementParameterBuilder : ParameterizedSqlFilterBuilder<ClassArrangementColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassArrangementParameterBuilder class.
		/// </summary>
		public ClassArrangementParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassArrangementParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassArrangementParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassArrangementParameterBuilder
	
	#region ClassArrangementSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClassArrangementColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClassArrangementSortBuilder : SqlSortBuilder<ClassArrangementColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassArrangementSqlSortBuilder class.
		/// </summary>
		public ClassArrangementSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClassArrangementSortBuilder
	
} // end namespace

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
	/// This class is the base class for any <see cref="CustomerDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CustomerDetailsProviderBaseCore : EntityProviderBase<AIProject.Entities.CustomerDetails, AIProject.Entities.CustomerDetailsKey>
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
		public override bool Delete(TransactionManager transactionManager, AIProject.Entities.CustomerDetailsKey key)
		{
			return Delete(transactionManager, key.CustomerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _customerId)
		{
			return Delete(null, _customerId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _customerId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerDetails_OccupationType key.
		///		FK_CustomerDetails_OccupationType Description: 
		/// </summary>
		/// <param name="_occupationTypeId"></param>
		/// <returns>Returns a typed collection of AIProject.Entities.CustomerDetails objects.</returns>
		public TList<CustomerDetails> GetByOccupationTypeId(System.Int32? _occupationTypeId)
		{
			int count = -1;
			return GetByOccupationTypeId(_occupationTypeId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerDetails_OccupationType key.
		///		FK_CustomerDetails_OccupationType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_occupationTypeId"></param>
		/// <returns>Returns a typed collection of AIProject.Entities.CustomerDetails objects.</returns>
		/// <remarks></remarks>
		public TList<CustomerDetails> GetByOccupationTypeId(TransactionManager transactionManager, System.Int32? _occupationTypeId)
		{
			int count = -1;
			return GetByOccupationTypeId(transactionManager, _occupationTypeId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerDetails_OccupationType key.
		///		FK_CustomerDetails_OccupationType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_occupationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.CustomerDetails objects.</returns>
		public TList<CustomerDetails> GetByOccupationTypeId(TransactionManager transactionManager, System.Int32? _occupationTypeId, int start, int pageLength)
		{
			int count = -1;
			return GetByOccupationTypeId(transactionManager, _occupationTypeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerDetails_OccupationType key.
		///		fkCustomerDetailsOccupationType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_occupationTypeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.CustomerDetails objects.</returns>
		public TList<CustomerDetails> GetByOccupationTypeId(System.Int32? _occupationTypeId, int start, int pageLength)
		{
			int count =  -1;
			return GetByOccupationTypeId(null, _occupationTypeId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerDetails_OccupationType key.
		///		fkCustomerDetailsOccupationType Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_occupationTypeId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIProject.Entities.CustomerDetails objects.</returns>
		public TList<CustomerDetails> GetByOccupationTypeId(System.Int32? _occupationTypeId, int start, int pageLength,out int count)
		{
			return GetByOccupationTypeId(null, _occupationTypeId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CustomerDetails_OccupationType key.
		///		FK_CustomerDetails_OccupationType Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_occupationTypeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIProject.Entities.CustomerDetails objects.</returns>
		public abstract TList<CustomerDetails> GetByOccupationTypeId(TransactionManager transactionManager, System.Int32? _occupationTypeId, int start, int pageLength, out int count);
		
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
		public override AIProject.Entities.CustomerDetails Get(TransactionManager transactionManager, AIProject.Entities.CustomerDetailsKey key, int start, int pageLength)
		{
			return GetByCustomerId(transactionManager, key.CustomerId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CustomerDetails index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CustomerDetails"/> class.</returns>
		public AIProject.Entities.CustomerDetails GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDetails index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CustomerDetails"/> class.</returns>
		public AIProject.Entities.CustomerDetails GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CustomerDetails"/> class.</returns>
		public AIProject.Entities.CustomerDetails GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CustomerDetails"/> class.</returns>
		public AIProject.Entities.CustomerDetails GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDetails index.
		/// </summary>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CustomerDetails"/> class.</returns>
		public AIProject.Entities.CustomerDetails GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CustomerDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIProject.Entities.CustomerDetails"/> class.</returns>
		public abstract AIProject.Entities.CustomerDetails GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CustomerDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CustomerDetails&gt;"/></returns>
		public static TList<CustomerDetails> Fill(IDataReader reader, TList<CustomerDetails> rows, int start, int pageLength)
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
				
				AIProject.Entities.CustomerDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CustomerDetails")
					.Append("|").Append((System.Int32)reader[((int)CustomerDetailsColumn.CustomerId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CustomerDetails>(
					key.ToString(), // EntityTrackingKey
					"CustomerDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIProject.Entities.CustomerDetails();
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
					c.CustomerId = (System.Int32)reader[((int)CustomerDetailsColumn.CustomerId - 1)];
					c.Name = (reader.IsDBNull(((int)CustomerDetailsColumn.Name - 1)))?null:(System.String)reader[((int)CustomerDetailsColumn.Name - 1)];
					c.Birthday = (reader.IsDBNull(((int)CustomerDetailsColumn.Birthday - 1)))?null:(System.DateTime?)reader[((int)CustomerDetailsColumn.Birthday - 1)];
					c.OccupationTypeId = (reader.IsDBNull(((int)CustomerDetailsColumn.OccupationTypeId - 1)))?null:(System.Int32?)reader[((int)CustomerDetailsColumn.OccupationTypeId - 1)];
					c.Email = (reader.IsDBNull(((int)CustomerDetailsColumn.Email - 1)))?null:(System.String)reader[((int)CustomerDetailsColumn.Email - 1)];
					c.PhoneNumber = (reader.IsDBNull(((int)CustomerDetailsColumn.PhoneNumber - 1)))?null:(System.String)reader[((int)CustomerDetailsColumn.PhoneNumber - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.CustomerDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.CustomerDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIProject.Entities.CustomerDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.CustomerId = (System.Int32)reader[((int)CustomerDetailsColumn.CustomerId - 1)];
			entity.Name = (reader.IsDBNull(((int)CustomerDetailsColumn.Name - 1)))?null:(System.String)reader[((int)CustomerDetailsColumn.Name - 1)];
			entity.Birthday = (reader.IsDBNull(((int)CustomerDetailsColumn.Birthday - 1)))?null:(System.DateTime?)reader[((int)CustomerDetailsColumn.Birthday - 1)];
			entity.OccupationTypeId = (reader.IsDBNull(((int)CustomerDetailsColumn.OccupationTypeId - 1)))?null:(System.Int32?)reader[((int)CustomerDetailsColumn.OccupationTypeId - 1)];
			entity.Email = (reader.IsDBNull(((int)CustomerDetailsColumn.Email - 1)))?null:(System.String)reader[((int)CustomerDetailsColumn.Email - 1)];
			entity.PhoneNumber = (reader.IsDBNull(((int)CustomerDetailsColumn.PhoneNumber - 1)))?null:(System.String)reader[((int)CustomerDetailsColumn.PhoneNumber - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIProject.Entities.CustomerDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIProject.Entities.CustomerDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIProject.Entities.CustomerDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (System.Int32)dataRow["CustomerId"];
			entity.Name = Convert.IsDBNull(dataRow["Name"]) ? null : (System.String)dataRow["Name"];
			entity.Birthday = Convert.IsDBNull(dataRow["Birthday"]) ? null : (System.DateTime?)dataRow["Birthday"];
			entity.OccupationTypeId = Convert.IsDBNull(dataRow["OccupationTypeId"]) ? null : (System.Int32?)dataRow["OccupationTypeId"];
			entity.Email = Convert.IsDBNull(dataRow["Email"]) ? null : (System.String)dataRow["Email"];
			entity.PhoneNumber = Convert.IsDBNull(dataRow["PhoneNumber"]) ? null : (System.String)dataRow["PhoneNumber"];
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
		/// <param name="entity">The <see cref="AIProject.Entities.CustomerDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIProject.Entities.CustomerDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIProject.Entities.CustomerDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region OccupationTypeIdSource	
			if (CanDeepLoad(entity, "OccupationType|OccupationTypeIdSource", deepLoadType, innerList) 
				&& entity.OccupationTypeIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.OccupationTypeId ?? (int)0);
				OccupationType tmpEntity = EntityManager.LocateEntity<OccupationType>(EntityLocator.ConstructKeyFromPkItems(typeof(OccupationType), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.OccupationTypeIdSource = tmpEntity;
				else
					entity.OccupationTypeIdSource = DataRepository.OccupationTypeProvider.GetByOccupationTypeId(transactionManager, (entity.OccupationTypeId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'OccupationTypeIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.OccupationTypeIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.OccupationTypeProvider.DeepLoad(transactionManager, entity.OccupationTypeIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion OccupationTypeIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCustomerId methods when available
			
			#region ClassArrangementCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ClassArrangement>|ClassArrangementCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClassArrangementCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClassArrangementCollection = DataRepository.ClassArrangementProvider.GetByCustomerId(transactionManager, entity.CustomerId);

				if (deep && entity.ClassArrangementCollection.Count > 0)
				{
					deepHandles.Add("ClassArrangementCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<ClassArrangement>) DataRepository.ClassArrangementProvider.DeepLoad,
						new object[] { transactionManager, entity.ClassArrangementCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the AIProject.Entities.CustomerDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIProject.Entities.CustomerDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIProject.Entities.CustomerDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIProject.Entities.CustomerDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region OccupationTypeIdSource
			if (CanDeepSave(entity, "OccupationType|OccupationTypeIdSource", deepSaveType, innerList) 
				&& entity.OccupationTypeIdSource != null)
			{
				DataRepository.OccupationTypeProvider.Save(transactionManager, entity.OccupationTypeIdSource);
				entity.OccupationTypeId = entity.OccupationTypeIdSource.OccupationTypeId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
	
			#region List<ClassArrangement>
				if (CanDeepSave(entity.ClassArrangementCollection, "List<ClassArrangement>|ClassArrangementCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(ClassArrangement child in entity.ClassArrangementCollection)
					{
						if(child.CustomerIdSource != null)
						{
							child.CustomerId = child.CustomerIdSource.CustomerId;
						}
						else
						{
							child.CustomerId = entity.CustomerId;
						}

					}

					if (entity.ClassArrangementCollection.Count > 0 || entity.ClassArrangementCollection.DeletedItems.Count > 0)
					{
						//DataRepository.ClassArrangementProvider.Save(transactionManager, entity.ClassArrangementCollection);
						
						deepHandles.Add("ClassArrangementCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< ClassArrangement >) DataRepository.ClassArrangementProvider.DeepSave,
							new object[] { transactionManager, entity.ClassArrangementCollection, deepSaveType, childTypes, innerList }
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
	
	#region CustomerDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIProject.Entities.CustomerDetails</c>
	///</summary>
	public enum CustomerDetailsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>OccupationType</c> at OccupationTypeIdSource
		///</summary>
		[ChildEntityType(typeof(OccupationType))]
		OccupationType,
	
		///<summary>
		/// Collection of <c>CustomerDetails</c> as OneToMany for ClassArrangementCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClassArrangement>))]
		ClassArrangementCollection,
	}
	
	#endregion CustomerDetailsChildEntityTypes
	
	#region CustomerDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CustomerDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDetailsFilterBuilder : SqlFilterBuilder<CustomerDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsFilterBuilder class.
		/// </summary>
		public CustomerDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDetailsFilterBuilder
	
	#region CustomerDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CustomerDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDetailsParameterBuilder : ParameterizedSqlFilterBuilder<CustomerDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsParameterBuilder class.
		/// </summary>
		public CustomerDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDetailsParameterBuilder
	
	#region CustomerDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CustomerDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CustomerDetailsSortBuilder : SqlSortBuilder<CustomerDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsSqlSortBuilder class.
		/// </summary>
		public CustomerDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CustomerDetailsSortBuilder
	
} // end namespace

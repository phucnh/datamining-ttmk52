#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using AIDT.Entities;
using AIDT.Data;

#endregion

namespace AIDT.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="CourseDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CourseDetailsProviderBaseCore : EntityProviderBase<AIDT.Entities.CourseDetails, AIDT.Entities.CourseDetailsKey>
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
		public override bool Delete(TransactionManager transactionManager, AIDT.Entities.CourseDetailsKey key)
		{
			return Delete(transactionManager, key.CourseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_courseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _courseId)
		{
			return Delete(null, _courseId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _courseId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseCertificate key.
		///		FK_CourseDetails_CourseCertificate Description: 
		/// </summary>
		/// <param name="_courseCertificate"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseCertificate(System.Int32? _courseCertificate)
		{
			int count = -1;
			return GetByCourseCertificate(_courseCertificate, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseCertificate key.
		///		FK_CourseDetails_CourseCertificate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseCertificate"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		/// <remarks></remarks>
		public TList<CourseDetails> GetByCourseCertificate(TransactionManager transactionManager, System.Int32? _courseCertificate)
		{
			int count = -1;
			return GetByCourseCertificate(transactionManager, _courseCertificate, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseCertificate key.
		///		FK_CourseDetails_CourseCertificate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseCertificate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseCertificate(TransactionManager transactionManager, System.Int32? _courseCertificate, int start, int pageLength)
		{
			int count = -1;
			return GetByCourseCertificate(transactionManager, _courseCertificate, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseCertificate key.
		///		fkCourseDetailsCourseCertificate Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_courseCertificate"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseCertificate(System.Int32? _courseCertificate, int start, int pageLength)
		{
			int count =  -1;
			return GetByCourseCertificate(null, _courseCertificate, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseCertificate key.
		///		fkCourseDetailsCourseCertificate Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_courseCertificate"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseCertificate(System.Int32? _courseCertificate, int start, int pageLength,out int count)
		{
			return GetByCourseCertificate(null, _courseCertificate, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseCertificate key.
		///		FK_CourseDetails_CourseCertificate Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseCertificate"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public abstract TList<CourseDetails> GetByCourseCertificate(TransactionManager transactionManager, System.Int32? _courseCertificate, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseGroup key.
		///		FK_CourseDetails_CourseGroup Description: 
		/// </summary>
		/// <param name="_courseGroup"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseGroup(System.Int32? _courseGroup)
		{
			int count = -1;
			return GetByCourseGroup(_courseGroup, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseGroup key.
		///		FK_CourseDetails_CourseGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseGroup"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		/// <remarks></remarks>
		public TList<CourseDetails> GetByCourseGroup(TransactionManager transactionManager, System.Int32? _courseGroup)
		{
			int count = -1;
			return GetByCourseGroup(transactionManager, _courseGroup, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseGroup key.
		///		FK_CourseDetails_CourseGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseGroup(TransactionManager transactionManager, System.Int32? _courseGroup, int start, int pageLength)
		{
			int count = -1;
			return GetByCourseGroup(transactionManager, _courseGroup, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseGroup key.
		///		fkCourseDetailsCourseGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_courseGroup"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseGroup(System.Int32? _courseGroup, int start, int pageLength)
		{
			int count =  -1;
			return GetByCourseGroup(null, _courseGroup, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseGroup key.
		///		fkCourseDetailsCourseGroup Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_courseGroup"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public TList<CourseDetails> GetByCourseGroup(System.Int32? _courseGroup, int start, int pageLength,out int count)
		{
			return GetByCourseGroup(null, _courseGroup, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_CourseDetails_CourseGroup key.
		///		FK_CourseDetails_CourseGroup Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseGroup"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIDT.Entities.CourseDetails objects.</returns>
		public abstract TList<CourseDetails> GetByCourseGroup(TransactionManager transactionManager, System.Int32? _courseGroup, int start, int pageLength, out int count);
		
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
		public override AIDT.Entities.CourseDetails Get(TransactionManager transactionManager, AIDT.Entities.CourseDetailsKey key, int start, int pageLength)
		{
			return GetByCourseId(transactionManager, key.CourseId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_CourseDetails index.
		/// </summary>
		/// <param name="_courseId"></param>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.CourseDetails"/> class.</returns>
		public AIDT.Entities.CourseDetails GetByCourseId(System.Int32 _courseId)
		{
			int count = -1;
			return GetByCourseId(null,_courseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseDetails index.
		/// </summary>
		/// <param name="_courseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.CourseDetails"/> class.</returns>
		public AIDT.Entities.CourseDetails GetByCourseId(System.Int32 _courseId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourseId(null, _courseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.CourseDetails"/> class.</returns>
		public AIDT.Entities.CourseDetails GetByCourseId(TransactionManager transactionManager, System.Int32 _courseId)
		{
			int count = -1;
			return GetByCourseId(transactionManager, _courseId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.CourseDetails"/> class.</returns>
		public AIDT.Entities.CourseDetails GetByCourseId(TransactionManager transactionManager, System.Int32 _courseId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourseId(transactionManager, _courseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseDetails index.
		/// </summary>
		/// <param name="_courseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.CourseDetails"/> class.</returns>
		public AIDT.Entities.CourseDetails GetByCourseId(System.Int32 _courseId, int start, int pageLength, out int count)
		{
			return GetByCourseId(null, _courseId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CourseDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.CourseDetails"/> class.</returns>
		public abstract AIDT.Entities.CourseDetails GetByCourseId(TransactionManager transactionManager, System.Int32 _courseId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;CourseDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;CourseDetails&gt;"/></returns>
		public static TList<CourseDetails> Fill(IDataReader reader, TList<CourseDetails> rows, int start, int pageLength)
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
				
				AIDT.Entities.CourseDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("CourseDetails")
					.Append("|").Append((System.Int32)reader[((int)CourseDetailsColumn.CourseId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<CourseDetails>(
					key.ToString(), // EntityTrackingKey
					"CourseDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIDT.Entities.CourseDetails();
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
					c.CourseId = (System.Int32)reader[((int)CourseDetailsColumn.CourseId - 1)];
					c.OriginalCourseId = c.CourseId;
					c.CourseName = (reader.IsDBNull(((int)CourseDetailsColumn.CourseName - 1)))?null:(System.String)reader[((int)CourseDetailsColumn.CourseName - 1)];
					c.CourseCertificate = (reader.IsDBNull(((int)CourseDetailsColumn.CourseCertificate - 1)))?null:(System.Int32?)reader[((int)CourseDetailsColumn.CourseCertificate - 1)];
					c.CourseFee = (reader.IsDBNull(((int)CourseDetailsColumn.CourseFee - 1)))?null:(System.Double?)reader[((int)CourseDetailsColumn.CourseFee - 1)];
					c.CourseGroup = (reader.IsDBNull(((int)CourseDetailsColumn.CourseGroup - 1)))?null:(System.Int32?)reader[((int)CourseDetailsColumn.CourseGroup - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIDT.Entities.CourseDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIDT.Entities.CourseDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIDT.Entities.CourseDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.CourseId = (System.Int32)reader[((int)CourseDetailsColumn.CourseId - 1)];
			entity.OriginalCourseId = (System.Int32)reader["CourseId"];
			entity.CourseName = (reader.IsDBNull(((int)CourseDetailsColumn.CourseName - 1)))?null:(System.String)reader[((int)CourseDetailsColumn.CourseName - 1)];
			entity.CourseCertificate = (reader.IsDBNull(((int)CourseDetailsColumn.CourseCertificate - 1)))?null:(System.Int32?)reader[((int)CourseDetailsColumn.CourseCertificate - 1)];
			entity.CourseFee = (reader.IsDBNull(((int)CourseDetailsColumn.CourseFee - 1)))?null:(System.Double?)reader[((int)CourseDetailsColumn.CourseFee - 1)];
			entity.CourseGroup = (reader.IsDBNull(((int)CourseDetailsColumn.CourseGroup - 1)))?null:(System.Int32?)reader[((int)CourseDetailsColumn.CourseGroup - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIDT.Entities.CourseDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIDT.Entities.CourseDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIDT.Entities.CourseDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CourseId = (System.Int32)dataRow["CourseId"];
			entity.OriginalCourseId = (System.Int32)dataRow["CourseId"];
			entity.CourseName = Convert.IsDBNull(dataRow["CourseName"]) ? null : (System.String)dataRow["CourseName"];
			entity.CourseCertificate = Convert.IsDBNull(dataRow["CourseCertificate"]) ? null : (System.Int32?)dataRow["CourseCertificate"];
			entity.CourseFee = Convert.IsDBNull(dataRow["CourseFee"]) ? null : (System.Double?)dataRow["CourseFee"];
			entity.CourseGroup = Convert.IsDBNull(dataRow["CourseGroup"]) ? null : (System.Int32?)dataRow["CourseGroup"];
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
		/// <param name="entity">The <see cref="AIDT.Entities.CourseDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIDT.Entities.CourseDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIDT.Entities.CourseDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CourseCertificateSource	
			if (CanDeepLoad(entity, "CourseCertificate|CourseCertificateSource", deepLoadType, innerList) 
				&& entity.CourseCertificateSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CourseCertificate ?? (int)0);
				CourseCertificate tmpEntity = EntityManager.LocateEntity<CourseCertificate>(EntityLocator.ConstructKeyFromPkItems(typeof(CourseCertificate), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CourseCertificateSource = tmpEntity;
				else
					entity.CourseCertificateSource = DataRepository.CourseCertificateProvider.GetByCertificateId(transactionManager, (entity.CourseCertificate ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CourseCertificateSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CourseCertificateSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CourseCertificateProvider.DeepLoad(transactionManager, entity.CourseCertificateSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CourseCertificateSource

			#region CourseGroupSource	
			if (CanDeepLoad(entity, "CourseGroup|CourseGroupSource", deepLoadType, innerList) 
				&& entity.CourseGroupSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CourseGroup ?? (int)0);
				CourseGroup tmpEntity = EntityManager.LocateEntity<CourseGroup>(EntityLocator.ConstructKeyFromPkItems(typeof(CourseGroup), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CourseGroupSource = tmpEntity;
				else
					entity.CourseGroupSource = DataRepository.CourseGroupProvider.GetByCourseGroupId(transactionManager, (entity.CourseGroup ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CourseGroupSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CourseGroupSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CourseGroupProvider.DeepLoad(transactionManager, entity.CourseGroupSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CourseGroupSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByCourseId methods when available
			
			#region ClassDetailsCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ClassDetails>|ClassDetailsCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClassDetailsCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClassDetailsCollection = DataRepository.ClassDetailsProvider.GetByCourseId(transactionManager, entity.CourseId);

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
		/// Deep Save the entire object graph of the AIDT.Entities.CourseDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIDT.Entities.CourseDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIDT.Entities.CourseDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIDT.Entities.CourseDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CourseCertificateSource
			if (CanDeepSave(entity, "CourseCertificate|CourseCertificateSource", deepSaveType, innerList) 
				&& entity.CourseCertificateSource != null)
			{
				DataRepository.CourseCertificateProvider.Save(transactionManager, entity.CourseCertificateSource);
				entity.CourseCertificate = entity.CourseCertificateSource.CertificateId;
			}
			#endregion 
			
			#region CourseGroupSource
			if (CanDeepSave(entity, "CourseGroup|CourseGroupSource", deepSaveType, innerList) 
				&& entity.CourseGroupSource != null)
			{
				DataRepository.CourseGroupProvider.Save(transactionManager, entity.CourseGroupSource);
				entity.CourseGroup = entity.CourseGroupSource.CourseGroupId;
			}
			#endregion 
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
						if(child.CourseIdSource != null)
						{
							child.CourseId = child.CourseIdSource.CourseId;
						}
						else
						{
							child.CourseId = entity.CourseId;
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
	
	#region CourseDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIDT.Entities.CourseDetails</c>
	///</summary>
	public enum CourseDetailsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CourseCertificate</c> at CourseCertificateSource
		///</summary>
		[ChildEntityType(typeof(CourseCertificate))]
		CourseCertificate,
			
		///<summary>
		/// Composite Property for <c>CourseGroup</c> at CourseGroupSource
		///</summary>
		[ChildEntityType(typeof(CourseGroup))]
		CourseGroup,
	
		///<summary>
		/// Collection of <c>CourseDetails</c> as OneToMany for ClassDetailsCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClassDetails>))]
		ClassDetailsCollection,
	}
	
	#endregion CourseDetailsChildEntityTypes
	
	#region CourseDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;CourseDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseDetailsFilterBuilder : SqlFilterBuilder<CourseDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDetailsFilterBuilder class.
		/// </summary>
		public CourseDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseDetailsFilterBuilder
	
	#region CourseDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;CourseDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseDetailsParameterBuilder : ParameterizedSqlFilterBuilder<CourseDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDetailsParameterBuilder class.
		/// </summary>
		public CourseDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseDetailsParameterBuilder
	
	#region CourseDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;CourseDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class CourseDetailsSortBuilder : SqlSortBuilder<CourseDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDetailsSqlSortBuilder class.
		/// </summary>
		public CourseDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion CourseDetailsSortBuilder
	
} // end namespace

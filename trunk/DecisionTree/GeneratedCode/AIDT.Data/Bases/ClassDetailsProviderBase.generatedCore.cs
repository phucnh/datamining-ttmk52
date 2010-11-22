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
	/// This class is the base class for any <see cref="ClassDetailsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClassDetailsProviderBaseCore : EntityProviderBase<AIDT.Entities.ClassDetails, AIDT.Entities.ClassDetailsKey>
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
		public override bool Delete(TransactionManager transactionManager, AIDT.Entities.ClassDetailsKey key)
		{
			return Delete(transactionManager, key.ClassId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_classId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _classId)
		{
			return Delete(null, _classId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _classId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_ClassTime key.
		///		FK_ClassDetails_ClassTime Description: 
		/// </summary>
		/// <param name="_classTime"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByClassTime(System.Int32? _classTime)
		{
			int count = -1;
			return GetByClassTime(_classTime, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_ClassTime key.
		///		FK_ClassDetails_ClassTime Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classTime"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		/// <remarks></remarks>
		public TList<ClassDetails> GetByClassTime(TransactionManager transactionManager, System.Int32? _classTime)
		{
			int count = -1;
			return GetByClassTime(transactionManager, _classTime, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_ClassTime key.
		///		FK_ClassDetails_ClassTime Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classTime"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByClassTime(TransactionManager transactionManager, System.Int32? _classTime, int start, int pageLength)
		{
			int count = -1;
			return GetByClassTime(transactionManager, _classTime, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_ClassTime key.
		///		fkClassDetailsClassTime Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_classTime"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByClassTime(System.Int32? _classTime, int start, int pageLength)
		{
			int count =  -1;
			return GetByClassTime(null, _classTime, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_ClassTime key.
		///		fkClassDetailsClassTime Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_classTime"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByClassTime(System.Int32? _classTime, int start, int pageLength,out int count)
		{
			return GetByClassTime(null, _classTime, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_ClassTime key.
		///		FK_ClassDetails_ClassTime Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classTime"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public abstract TList<ClassDetails> GetByClassTime(TransactionManager transactionManager, System.Int32? _classTime, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_CourseDetails key.
		///		FK_ClassDetails_CourseDetails Description: 
		/// </summary>
		/// <param name="_courseId"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByCourseId(System.Int32? _courseId)
		{
			int count = -1;
			return GetByCourseId(_courseId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_CourseDetails key.
		///		FK_ClassDetails_CourseDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseId"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		/// <remarks></remarks>
		public TList<ClassDetails> GetByCourseId(TransactionManager transactionManager, System.Int32? _courseId)
		{
			int count = -1;
			return GetByCourseId(transactionManager, _courseId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_CourseDetails key.
		///		FK_ClassDetails_CourseDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByCourseId(TransactionManager transactionManager, System.Int32? _courseId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourseId(transactionManager, _courseId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_CourseDetails key.
		///		fkClassDetailsCourseDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_courseId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByCourseId(System.Int32? _courseId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCourseId(null, _courseId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_CourseDetails key.
		///		fkClassDetailsCourseDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_courseId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByCourseId(System.Int32? _courseId, int start, int pageLength,out int count)
		{
			return GetByCourseId(null, _courseId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_CourseDetails key.
		///		FK_ClassDetails_CourseDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_courseId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public abstract TList<ClassDetails> GetByCourseId(TransactionManager transactionManager, System.Int32? _courseId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_TeacherDetails key.
		///		FK_ClassDetails_TeacherDetails Description: 
		/// </summary>
		/// <param name="_teacherId"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByTeacherId(System.Int32? _teacherId)
		{
			int count = -1;
			return GetByTeacherId(_teacherId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_TeacherDetails key.
		///		FK_ClassDetails_TeacherDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		/// <remarks></remarks>
		public TList<ClassDetails> GetByTeacherId(TransactionManager transactionManager, System.Int32? _teacherId)
		{
			int count = -1;
			return GetByTeacherId(transactionManager, _teacherId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_TeacherDetails key.
		///		FK_ClassDetails_TeacherDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByTeacherId(TransactionManager transactionManager, System.Int32? _teacherId, int start, int pageLength)
		{
			int count = -1;
			return GetByTeacherId(transactionManager, _teacherId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_TeacherDetails key.
		///		fkClassDetailsTeacherDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_teacherId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByTeacherId(System.Int32? _teacherId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTeacherId(null, _teacherId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_TeacherDetails key.
		///		fkClassDetailsTeacherDetails Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_teacherId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public TList<ClassDetails> GetByTeacherId(System.Int32? _teacherId, int start, int pageLength,out int count)
		{
			return GetByTeacherId(null, _teacherId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ClassDetails_TeacherDetails key.
		///		FK_ClassDetails_TeacherDetails Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_teacherId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of AIDT.Entities.ClassDetails objects.</returns>
		public abstract TList<ClassDetails> GetByTeacherId(TransactionManager transactionManager, System.Int32? _teacherId, int start, int pageLength, out int count);
		
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
		public override AIDT.Entities.ClassDetails Get(TransactionManager transactionManager, AIDT.Entities.ClassDetailsKey key, int start, int pageLength)
		{
			return GetByClassId(transactionManager, key.ClassId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClassDetails index.
		/// </summary>
		/// <param name="_classId"></param>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.ClassDetails"/> class.</returns>
		public AIDT.Entities.ClassDetails GetByClassId(System.Int32 _classId)
		{
			int count = -1;
			return GetByClassId(null,_classId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassDetails index.
		/// </summary>
		/// <param name="_classId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.ClassDetails"/> class.</returns>
		public AIDT.Entities.ClassDetails GetByClassId(System.Int32 _classId, int start, int pageLength)
		{
			int count = -1;
			return GetByClassId(null, _classId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.ClassDetails"/> class.</returns>
		public AIDT.Entities.ClassDetails GetByClassId(TransactionManager transactionManager, System.Int32 _classId)
		{
			int count = -1;
			return GetByClassId(transactionManager, _classId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.ClassDetails"/> class.</returns>
		public AIDT.Entities.ClassDetails GetByClassId(TransactionManager transactionManager, System.Int32 _classId, int start, int pageLength)
		{
			int count = -1;
			return GetByClassId(transactionManager, _classId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassDetails index.
		/// </summary>
		/// <param name="_classId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.ClassDetails"/> class.</returns>
		public AIDT.Entities.ClassDetails GetByClassId(System.Int32 _classId, int start, int pageLength, out int count)
		{
			return GetByClassId(null, _classId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClassDetails index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_classId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="AIDT.Entities.ClassDetails"/> class.</returns>
		public abstract AIDT.Entities.ClassDetails GetByClassId(TransactionManager transactionManager, System.Int32 _classId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClassDetails&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClassDetails&gt;"/></returns>
		public static TList<ClassDetails> Fill(IDataReader reader, TList<ClassDetails> rows, int start, int pageLength)
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
				
				AIDT.Entities.ClassDetails c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClassDetails")
					.Append("|").Append((System.Int32)reader[((int)ClassDetailsColumn.ClassId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClassDetails>(
					key.ToString(), // EntityTrackingKey
					"ClassDetails",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new AIDT.Entities.ClassDetails();
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
					c.ClassId = (System.Int32)reader[((int)ClassDetailsColumn.ClassId - 1)];
					c.OriginalClassId = c.ClassId;
					c.ClassName = (reader.IsDBNull(((int)ClassDetailsColumn.ClassName - 1)))?null:(System.String)reader[((int)ClassDetailsColumn.ClassName - 1)];
					c.ClassTime = (reader.IsDBNull(((int)ClassDetailsColumn.ClassTime - 1)))?null:(System.Int32?)reader[((int)ClassDetailsColumn.ClassTime - 1)];
					c.CourseId = (reader.IsDBNull(((int)ClassDetailsColumn.CourseId - 1)))?null:(System.Int32?)reader[((int)ClassDetailsColumn.CourseId - 1)];
					c.TeacherId = (reader.IsDBNull(((int)ClassDetailsColumn.TeacherId - 1)))?null:(System.Int32?)reader[((int)ClassDetailsColumn.TeacherId - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="AIDT.Entities.ClassDetails"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="AIDT.Entities.ClassDetails"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, AIDT.Entities.ClassDetails entity)
		{
			if (!reader.Read()) return;
			
			entity.ClassId = (System.Int32)reader[((int)ClassDetailsColumn.ClassId - 1)];
			entity.OriginalClassId = (System.Int32)reader["ClassId"];
			entity.ClassName = (reader.IsDBNull(((int)ClassDetailsColumn.ClassName - 1)))?null:(System.String)reader[((int)ClassDetailsColumn.ClassName - 1)];
			entity.ClassTime = (reader.IsDBNull(((int)ClassDetailsColumn.ClassTime - 1)))?null:(System.Int32?)reader[((int)ClassDetailsColumn.ClassTime - 1)];
			entity.CourseId = (reader.IsDBNull(((int)ClassDetailsColumn.CourseId - 1)))?null:(System.Int32?)reader[((int)ClassDetailsColumn.CourseId - 1)];
			entity.TeacherId = (reader.IsDBNull(((int)ClassDetailsColumn.TeacherId - 1)))?null:(System.Int32?)reader[((int)ClassDetailsColumn.TeacherId - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="AIDT.Entities.ClassDetails"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="AIDT.Entities.ClassDetails"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, AIDT.Entities.ClassDetails entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ClassId = (System.Int32)dataRow["ClassId"];
			entity.OriginalClassId = (System.Int32)dataRow["ClassId"];
			entity.ClassName = Convert.IsDBNull(dataRow["ClassName"]) ? null : (System.String)dataRow["ClassName"];
			entity.ClassTime = Convert.IsDBNull(dataRow["ClassTime"]) ? null : (System.Int32?)dataRow["ClassTime"];
			entity.CourseId = Convert.IsDBNull(dataRow["CourseId"]) ? null : (System.Int32?)dataRow["CourseId"];
			entity.TeacherId = Convert.IsDBNull(dataRow["TeacherId"]) ? null : (System.Int32?)dataRow["TeacherId"];
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
		/// <param name="entity">The <see cref="AIDT.Entities.ClassDetails"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">AIDT.Entities.ClassDetails Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, AIDT.Entities.ClassDetails entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region ClassTimeSource	
			if (CanDeepLoad(entity, "ClassTime|ClassTimeSource", deepLoadType, innerList) 
				&& entity.ClassTimeSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.ClassTime ?? (int)0);
				ClassTime tmpEntity = EntityManager.LocateEntity<ClassTime>(EntityLocator.ConstructKeyFromPkItems(typeof(ClassTime), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ClassTimeSource = tmpEntity;
				else
					entity.ClassTimeSource = DataRepository.ClassTimeProvider.GetByClassTimeId(transactionManager, (entity.ClassTime ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClassTimeSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ClassTimeSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ClassTimeProvider.DeepLoad(transactionManager, entity.ClassTimeSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ClassTimeSource

			#region CourseIdSource	
			if (CanDeepLoad(entity, "CourseDetails|CourseIdSource", deepLoadType, innerList) 
				&& entity.CourseIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CourseId ?? (int)0);
				CourseDetails tmpEntity = EntityManager.LocateEntity<CourseDetails>(EntityLocator.ConstructKeyFromPkItems(typeof(CourseDetails), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CourseIdSource = tmpEntity;
				else
					entity.CourseIdSource = DataRepository.CourseDetailsProvider.GetByCourseId(transactionManager, (entity.CourseId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CourseIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CourseIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CourseDetailsProvider.DeepLoad(transactionManager, entity.CourseIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CourseIdSource

			#region TeacherIdSource	
			if (CanDeepLoad(entity, "TeacherDetails|TeacherIdSource", deepLoadType, innerList) 
				&& entity.TeacherIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.TeacherId ?? (int)0);
				TeacherDetails tmpEntity = EntityManager.LocateEntity<TeacherDetails>(EntityLocator.ConstructKeyFromPkItems(typeof(TeacherDetails), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TeacherIdSource = tmpEntity;
				else
					entity.TeacherIdSource = DataRepository.TeacherDetailsProvider.GetByTeacherId(transactionManager, (entity.TeacherId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TeacherIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TeacherIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.TeacherDetailsProvider.DeepLoad(transactionManager, entity.TeacherIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TeacherIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByClassId methods when available
			
			#region ClassArrangementCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<ClassArrangement>|ClassArrangementCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ClassArrangementCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.ClassArrangementCollection = DataRepository.ClassArrangementProvider.GetByClassId(transactionManager, entity.ClassId);

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
		/// Deep Save the entire object graph of the AIDT.Entities.ClassDetails object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">AIDT.Entities.ClassDetails instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">AIDT.Entities.ClassDetails Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, AIDT.Entities.ClassDetails entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region ClassTimeSource
			if (CanDeepSave(entity, "ClassTime|ClassTimeSource", deepSaveType, innerList) 
				&& entity.ClassTimeSource != null)
			{
				DataRepository.ClassTimeProvider.Save(transactionManager, entity.ClassTimeSource);
				entity.ClassTime = entity.ClassTimeSource.ClassTimeId;
			}
			#endregion 
			
			#region CourseIdSource
			if (CanDeepSave(entity, "CourseDetails|CourseIdSource", deepSaveType, innerList) 
				&& entity.CourseIdSource != null)
			{
				DataRepository.CourseDetailsProvider.Save(transactionManager, entity.CourseIdSource);
				entity.CourseId = entity.CourseIdSource.CourseId;
			}
			#endregion 
			
			#region TeacherIdSource
			if (CanDeepSave(entity, "TeacherDetails|TeacherIdSource", deepSaveType, innerList) 
				&& entity.TeacherIdSource != null)
			{
				DataRepository.TeacherDetailsProvider.Save(transactionManager, entity.TeacherIdSource);
				entity.TeacherId = entity.TeacherIdSource.TeacherId;
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
						if(child.ClassIdSource != null)
						{
							child.ClassId = child.ClassIdSource.ClassId;
						}
						else
						{
							child.ClassId = entity.ClassId;
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
	
	#region ClassDetailsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>AIDT.Entities.ClassDetails</c>
	///</summary>
	public enum ClassDetailsChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>ClassTime</c> at ClassTimeSource
		///</summary>
		[ChildEntityType(typeof(ClassTime))]
		ClassTime,
			
		///<summary>
		/// Composite Property for <c>CourseDetails</c> at CourseIdSource
		///</summary>
		[ChildEntityType(typeof(CourseDetails))]
		CourseDetails,
			
		///<summary>
		/// Composite Property for <c>TeacherDetails</c> at TeacherIdSource
		///</summary>
		[ChildEntityType(typeof(TeacherDetails))]
		TeacherDetails,
	
		///<summary>
		/// Collection of <c>ClassDetails</c> as OneToMany for ClassArrangementCollection
		///</summary>
		[ChildEntityType(typeof(TList<ClassArrangement>))]
		ClassArrangementCollection,
	}
	
	#endregion ClassDetailsChildEntityTypes
	
	#region ClassDetailsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClassDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassDetailsFilterBuilder : SqlFilterBuilder<ClassDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassDetailsFilterBuilder class.
		/// </summary>
		public ClassDetailsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassDetailsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassDetailsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassDetailsFilterBuilder
	
	#region ClassDetailsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClassDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassDetailsParameterBuilder : ParameterizedSqlFilterBuilder<ClassDetailsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassDetailsParameterBuilder class.
		/// </summary>
		public ClassDetailsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassDetailsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassDetailsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassDetailsParameterBuilder
	
	#region ClassDetailsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClassDetailsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClassDetailsSortBuilder : SqlSortBuilder<ClassDetailsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassDetailsSqlSortBuilder class.
		/// </summary>
		public ClassDetailsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClassDetailsSortBuilder
	
} // end namespace

#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using AIDT.Entities;
using AIDT.Data;
using AIDT.Data.Bases;

#endregion

namespace AIDT.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("AIDT.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region CourseGroupProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CourseGroup"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CourseGroupProviderBase CourseGroupProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CourseGroupProvider;
			}
		}
		
		#endregion
		
		#region OccupationTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="OccupationType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static OccupationTypeProviderBase OccupationTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.OccupationTypeProvider;
			}
		}
		
		#endregion
		
		#region CustomerDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomerDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomerDetailsProviderBase CustomerDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomerDetailsProvider;
			}
		}
		
		#endregion
		
		#region CourseCertificateProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CourseCertificate"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CourseCertificateProviderBase CourseCertificateProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CourseCertificateProvider;
			}
		}
		
		#endregion
		
		#region CourseDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CourseDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CourseDetailsProviderBase CourseDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CourseDetailsProvider;
			}
		}
		
		#endregion
		
		#region TeacherDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="TeacherDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static TeacherDetailsProviderBase TeacherDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.TeacherDetailsProvider;
			}
		}
		
		#endregion
		
		#region ClassTimeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClassTime"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClassTimeProviderBase ClassTimeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClassTimeProvider;
			}
		}
		
		#endregion
		
		#region ClassDetailsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClassDetails"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClassDetailsProviderBase ClassDetailsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClassDetailsProvider;
			}
		}
		
		#endregion
		
		#region ClassArrangementProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClassArrangement"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClassArrangementProviderBase ClassArrangementProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClassArrangementProvider;
			}
		}
		
		#endregion
		
		
		#endregion
	}
	
	#region Query/Filters
		
	#region CourseGroupFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseGroupFilters : CourseGroupFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseGroupFilters class.
		/// </summary>
		public CourseGroupFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseGroupFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseGroupFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseGroupFilters
	
	#region CourseGroupQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CourseGroupParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CourseGroup"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseGroupQuery : CourseGroupParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseGroupQuery class.
		/// </summary>
		public CourseGroupQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseGroupQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseGroupQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseGroupQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseGroupQuery
		
	#region OccupationTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OccupationTypeFilters : OccupationTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OccupationTypeFilters class.
		/// </summary>
		public OccupationTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OccupationTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OccupationTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OccupationTypeFilters
	
	#region OccupationTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="OccupationTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="OccupationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OccupationTypeQuery : OccupationTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OccupationTypeQuery class.
		/// </summary>
		public OccupationTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OccupationTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OccupationTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OccupationTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OccupationTypeQuery
		
	#region CustomerDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDetailsFilters : CustomerDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsFilters class.
		/// </summary>
		public CustomerDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDetailsFilters
	
	#region CustomerDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomerDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomerDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomerDetailsQuery : CustomerDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsQuery class.
		/// </summary>
		public CustomerDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomerDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomerDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomerDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomerDetailsQuery
		
	#region CourseCertificateFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseCertificate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseCertificateFilters : CourseCertificateFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseCertificateFilters class.
		/// </summary>
		public CourseCertificateFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseCertificateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseCertificateFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseCertificateFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseCertificateFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseCertificateFilters
	
	#region CourseCertificateQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CourseCertificateParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CourseCertificate"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseCertificateQuery : CourseCertificateParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseCertificateQuery class.
		/// </summary>
		public CourseCertificateQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseCertificateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseCertificateQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseCertificateQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseCertificateQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseCertificateQuery
		
	#region CourseDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseDetailsFilters : CourseDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDetailsFilters class.
		/// </summary>
		public CourseDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseDetailsFilters
	
	#region CourseDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CourseDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CourseDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CourseDetailsQuery : CourseDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CourseDetailsQuery class.
		/// </summary>
		public CourseDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CourseDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CourseDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CourseDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CourseDetailsQuery
		
	#region TeacherDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherDetailsFilters : TeacherDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsFilters class.
		/// </summary>
		public TeacherDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherDetailsFilters
	
	#region TeacherDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="TeacherDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="TeacherDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class TeacherDetailsQuery : TeacherDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsQuery class.
		/// </summary>
		public TeacherDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public TeacherDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the TeacherDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public TeacherDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion TeacherDetailsQuery
		
	#region ClassTimeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassTimeFilters : ClassTimeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassTimeFilters class.
		/// </summary>
		public ClassTimeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassTimeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassTimeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassTimeFilters
	
	#region ClassTimeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClassTimeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClassTime"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassTimeQuery : ClassTimeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassTimeQuery class.
		/// </summary>
		public ClassTimeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassTimeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassTimeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassTimeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassTimeQuery
		
	#region ClassDetailsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassDetailsFilters : ClassDetailsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassDetailsFilters class.
		/// </summary>
		public ClassDetailsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassDetailsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassDetailsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassDetailsFilters
	
	#region ClassDetailsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClassDetailsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClassDetails"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassDetailsQuery : ClassDetailsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassDetailsQuery class.
		/// </summary>
		public ClassDetailsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassDetailsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassDetailsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassDetailsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassDetailsQuery
		
	#region ClassArrangementFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassArrangementFilters : ClassArrangementFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassArrangementFilters class.
		/// </summary>
		public ClassArrangementFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassArrangementFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassArrangementFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassArrangementFilters
	
	#region ClassArrangementQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClassArrangementParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClassArrangement"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClassArrangementQuery : ClassArrangementParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClassArrangementQuery class.
		/// </summary>
		public ClassArrangementQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClassArrangementQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClassArrangementQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClassArrangementQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClassArrangementQuery
	#endregion

	
}

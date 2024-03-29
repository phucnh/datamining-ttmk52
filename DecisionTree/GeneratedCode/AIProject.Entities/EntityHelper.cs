﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AIProject.Entities
{
	/// <summary>
	/// This classes contains utilities functions for the <see cref="IEntity"/> instances and collections.
	/// </summary>
	/// <remarks>All methods static</remarks>
	public static class EntityHelper
	{

		#region SerializeBinary 

		/// <summary>
		/// Serializes the entity to binary.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <value>A byte array that contains the serialized entity.</value>
		public static byte[] SerializeBinary(IEntity entity)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, entity);
			return ms.ToArray();
		}

		/// <summary>
		/// Serializes the entity collection to binary.
		/// </summary>
		/// <param name="entityCollection">The Entity collection to serialize.</param>
		/// <value>A byte array that contains the serialized entity.</value>
		public static byte[] SerializeBinary(IList entityCollection) 
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, entityCollection);
			return ms.ToArray();			
		}
		
		/// <summary>
		/// Serializes the entity to binary and puts the data into a file.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeBinary(IEntity entity, string path)
		{
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, entity);
			fs.Close();
		}
		
		/// <summary>
		/// Serializes the entity collection to binary and puts the data into a file.
		/// </summary>
		/// <param name="entityCollection">The Entity collection to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeBinary(IList entityCollection, string path)
		{
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, entityCollection);
			fs.Close();
		}

		#endregion

		#region SerializeXml 
		
		/// <summary>
		/// serialize an object to xml.
		/// </summary>
		/// <param name="item">The item to serialize.</param>
		/// <returns></returns>
		public static string XmlSerialize<T>(T item)
		{
			XmlSerializer s = new XmlSerializer(typeof(T));
			StringBuilder stringBuilder = new StringBuilder();

			StringWriter writer = new StringWriter(stringBuilder);
			s.Serialize(writer, item);
			writer.Close();

			return stringBuilder.ToString();
		}
		
		/// <summary>
		/// Serializes the entity to Xml.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <returns>A string that contains the serialized entity.</returns>
		public static string SerializeXml(IEntity entity)
		{
			XmlSerializer ser = new XmlSerializer(entity.GetType());
			StringBuilder sb = new StringBuilder();
			TextWriter writer = new StringWriter(sb);
			ser.Serialize(writer, entity);
			writer.Close();
			return sb.ToString();
		}
		
        /// <summary>
        /// Serializes the <see cref="T:TList{T}"/> of IEntity to XML
        /// </summary>
        /// <typeparam name="T">type to return, type must implement IEntity</typeparam>
        /// <param name="entityCollection">TList of T type to return</param>
        /// <returns>string of serialized XML</returns>
        public static string SerializeXml<T>(TList<T> entityCollection)  where T : IEntity, new()
        {
            XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
            StringBuilder sb = new StringBuilder();
            TextWriter writer = new StringWriter(sb);
            ser.Serialize(writer, entityCollection);
            writer.Close();
            return sb.ToString();
        }

		/// <summary>
		/// Serializes the entity to xml and puts the data into a file.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeXml(IEntity entity, string path)
		{
			XmlSerializer ser = new XmlSerializer(entity.GetType());
			StreamWriter sw = new StreamWriter(path);
			ser.Serialize(sw, entity);
			sw.Close();
		}
		
		/// <summary>
		/// Serializes the entity collection to xml and puts the data into a file.
		/// </summary>
		/// <param name="entityCollection">The Entity collection to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeXml<T>(TList<T> entityCollection, string path) where T : IEntity, new()
		{
			XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
			StreamWriter sw = new StreamWriter(path);
			ser.Serialize(sw, entityCollection);
			sw.Close();
		}
		
		/// <summary>
      /// Serializes the <see cref="T:VList{T}"/> of view entities to XML
      /// </summary>
      /// <typeparam name="T">type to return</typeparam>
      /// <param name="entityCollection">VList of T type to return</param>
      /// <returns>string of serialized XML</returns>
      public static string SerializeXml<T>(VList<T> entityCollection)
      {
         XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
         StringBuilder sb = new StringBuilder();
         TextWriter writer = new StringWriter(sb);
         ser.Serialize(writer, entityCollection);
         writer.Close();
         return sb.ToString();
      }

      /// <summary>
      /// Serializes the view collection to xml and puts the data into a file.
      /// </summary>
      /// <param name="entityCollection">The Entity View collection to serialize.</param>
      /// <param name="path">The Path to the destination file.</param>
      public static void SerializeXml<T>(VList<T> entityCollection, string path)
      {
         XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
         StreamWriter sw = new StreamWriter(path);
         ser.Serialize(sw, entityCollection);
         sw.Close();
      }
		
		#endregion 

		#region Deserialize Binary
		
		/// <summary>
		/// Deserializes the binary data to an object instance.
		/// </summary>
		/// <param name="bytes">The byte array that contains binary serialized datas.</param>
		/// <returns>The deserialized instance</returns>
		public static object DeserializeBinary(byte[] bytes)
		{
			MemoryStream ms = new MemoryStream(bytes);
			BinaryFormatter bf = new BinaryFormatter();
			return bf.Deserialize(ms);
		}
		#endregion

		#region DeserializeXml

		/// <summary>
		/// deserialize an xml string into an object.
		/// </summary>
		/// <param name="xmlData">The XML data.</param>
		/// <returns></returns>
		public static T XmlDeserialize<T>(string xmlData)
		{
			XmlSerializer s = new XmlSerializer(typeof(T));
			TextReader reader = new StringReader(xmlData);
			T entity = (T)s.Deserialize(reader);
			reader.Close();
			return entity;
		}

        /// <summary>
        /// Deserialize an Entity from an xml string to T
        /// </summary>
        /// <typeparam name="T">T where T : IEntity</typeparam>
		/// <param name="data">string of serialized xml</param>
        /// <returns>T where T : IEntity</returns>
        public static T DeserializeEntityXml<T>(string data) where T : IEntity
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(data);
            T toReturn;
            toReturn = (T)serializer.Deserialize(reader) ;
            reader.Close();
            return toReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"><see cref="T:TList{T}"/> where T : IEntity, new()</typeparam>
        /// <param name="data">string of serialized TList of T xml</param>
        /// <returns><see cref="T:TList{T}"/> where T : IEntity, new()</returns>
        public static TList<T> DeserializeListXml<T>(string data) where T : IEntity, new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TList<T>));
            TextReader reader = new StringReader(data);
            TList<T> toReturn;
            toReturn = (TList<T>)serializer.Deserialize(reader);
            reader.Close();
            return toReturn;
        }

		/// <summary>
		/// Deserializes the XML string to an instance of the specified type.
		/// </summary>
		/// <param name="root">The name of the root node.</param>
		/// <param name="type">The targeted Type.</param>
		/// <param name="reader">The xmlReader instance that point to the xml data.</param>
		/// <returns>An instance of the Type class.</returns>		
		public static object DeserializeXml(string root, Type type, XmlReader reader)
		{
			XmlRootAttribute xmlRoot = new XmlRootAttribute();
			xmlRoot.ElementName = root;
			XmlSerializer serializer = new XmlSerializer(type, xmlRoot);
			object obj = serializer.Deserialize(reader);
			return obj;
		}
		
		/// <summary>
		/// Deserialize a list of view entity objects from an Xml string
		/// </summary>
		/// <typeparam name="T"><see cref="T:VList{T}"/> where T is a view entity class</typeparam>
		/// <param name="data">string of serialized VList of T xml</param>
		/// <returns><see cref="T:VList{T}"/></returns>
		public static VList<T> DeserializeVListXml<T>(string data)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(VList<T>));
			TextReader reader = new StringReader(data);
			VList<T> toReturn;
			toReturn = (VList<T>)serializer.Deserialize(reader);
			reader.Close();
			return toReturn;
		}
		
		#endregion

		#region GetByteLength 

		/// <summary>
		/// Gets the byte length of the specified object.
		/// </summary>
		/// <param name="obj">The object we want the length.</param>
		/// <returns>The byte length of the object.</returns>
		public static long GetByteLength(object obj)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, obj);
			return ms.Length;
		}

		#endregion
		
		#region Dynamic ToString Implementation through Reflection
		/// <summary>
		/// Give a string representation of a object, with use of reflection.
		/// </summary>
		/// <param name="o">O.</param>
		/// <returns></returns>
		public static string ToString(Object o)
		{
			StringBuilder sb = new StringBuilder();
			Type t = o.GetType();

			PropertyInfo[] pi = t.GetProperties();

			sb.Append("Properties for: " + o.GetType().Name + System.Environment.NewLine);
			foreach (PropertyInfo i in pi)
			{
				try
				{
					sb.Append("\t" + i.Name + "(" + i.PropertyType.ToString() + "): ");
					if (null != i.GetValue(o, null))
					{
						sb.Append(i.GetValue(o, null).ToString());
					}

				}
				catch
				{
				}
				sb.Append(System.Environment.NewLine);

			}

			FieldInfo[] fi = t.GetFields();

			foreach (FieldInfo i in fi)
			{
				try
				{
					sb.Append("\t" + i.Name + "(" + i.FieldType.ToString() + "): ");
					if (null != i.GetValue(o))
					{
						sb.Append(i.GetValue(o).ToString());
					}

				}
				catch
				{
				}
				sb.Append(System.Environment.NewLine);

			}

			return sb.ToString();
		}
		#endregion 
		
		#region Clone
      /// <summary>
      /// Generic method to perform a deep copy of an object
      /// </summary>
      /// <typeparam name="T">Type of object being cloned and returned</typeparam>
      /// <param name="sourceEntity">Source object to be cloned.</param>
      /// <returns>An object that is a deep copy of the sourceEntity object.</returns>
      public static T Clone<T>(T sourceEntity)
      { 
         BinaryFormatter bFormatter = new BinaryFormatter();
         MemoryStream stream = new MemoryStream();
         bFormatter.Serialize(stream, sourceEntity);
         stream.Seek(0, System.IO.SeekOrigin.Begin);
         T clone = (T)bFormatter.Deserialize(stream);
         return clone;
      }
      #endregion
		
		#region GetBindableProperties
		/// <summary>
		/// Get the collection of properties that have been marked as Bindable
		/// </summary>
		/// <param name="type">The type of the object to get the properties for.</param>
		/// <returns><see cref="PropertyDescriptorCollection"/> of bindable properties.</returns>
		public static PropertyDescriptorCollection GetBindableProperties(Type type)
		{
			// create a filter so we only return the properties that have been designated as bindable
			Attribute[] attrs = new Attribute[] { new System.ComponentModel.BindableAttribute(true) };
			
			//If the type is a generic type (TList or VList), we need to get the properties of the inner type
			if (type.IsGenericType)
			{
         	type = type.GetGenericArguments()[0];
      	}
		
			// save the bindable properties in a local field
			return TypeDescriptor.GetProperties(type, attrs);
		}
		#endregion

		#region GetEnumTextValue
		///<summary>
		/// Allows the discovery of an enumeration text value based on the <c>EnumTextValueAttribute</c>
		///</summary>
		/// <param name="e">The enum to get the reader friendly text value for.</param>
		/// <returns><see cref="System.String"/> </returns>
		public static string GetEnumTextValue( Enum e )
		{
			string ret = "";
			Type t = e.GetType();
			MemberInfo[] members = t.GetMember(e.ToString());
			if( members != null && members.Length == 1 )
			{
				object[] attrs = members[0].GetCustomAttributes(typeof(EnumTextValueAttribute), false);
				if( attrs.Length == 1 )
				{
					ret = ((EnumTextValueAttribute)attrs[0]).Text;
				}
			}
			return ret;
		}
		#endregion 
        
		#region GetEnumValue
		///<summary>
		/// Allows the discovery of an enumeration value based on the <c>EnumTextValueAttribute</c>
		///</summary>
		/// <param name="text">The text of the <c>EnumTextValueAttribute</c>.</param>
		/// <param name="enumType">The type of the enum to get the value for.</param>
		/// <returns><see cref="System.Object"/> boxed representation of the enum value </returns>
		public static object GetEnumValue(string text, Type enumType)
		{
			MemberInfo[] members = enumType.GetMembers(); 
			foreach( MemberInfo mi in members ) 
			{ 
				object[] attrs = mi.GetCustomAttributes(typeof(EnumTextValueAttribute), false); 
				if( attrs.Length == 1 ) 
				{ 
					if( ((EnumTextValueAttribute)attrs[0]).Text == text ) 
						return Enum.Parse(enumType, mi.Name); 
				} 
			} 
			throw new ArgumentOutOfRangeException("text", text, "The text passed does not correspond to an attributed enum value"); 
		}
		
		///<summary>
		/// Allows the discovery of an enumeration value based on the <c>Enum.Parse</c>
		///</summary>
		/// <param name="text">The text of a enum value of the specified enumeration.</param>
		/// <returns>A enum value of the specified enumeration,</returns>
		public static T GetEnumValue<T>(string text) where T : struct
		{
     		return (T)Enum.Parse(typeof(T), text, true);
		}
		
		#endregion 
		
		#region GetAttribute

		/// <summary>
		/// Gets the first occurrence of the specified type of <see cref="System.Attribute"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="e"></param>
		/// <returns></returns>
		public static T GetAttribute<T>(System.Enum e) where T : System.Attribute
		{
			T attribute = default(T);
			Type enumType = e.GetType();
			System.Reflection.MemberInfo[] members = enumType.GetMember(e.ToString());

			if ( members != null && members.Length == 1 )
			{
				object[] attrs = members[0].GetCustomAttributes(typeof(T), false);
				if ( attrs.Length > 0 )
				{
					attribute = (T) attrs[0];
				}
			}

			return attribute;
		}

		#endregion GetAttribute
		
		#region Pascal to spaced helper
		/// <summary>
		/// Get the Pascal spaced version of a name.  
		/// </summary>
		/// <param name="name">Name to be changed</param>
		/// <returns>PascalSpaced version of the name</returns>
		public static string GetPascalSpacedName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return string.Empty;
			}
				
	        Regex regex = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
		    return regex.Replace(name, " ${x}");

	    }
		#endregion	
			
	}
			
	#region EnumTextValue
	///<summary>
	/// Attribute used to decorate enumerations with reader friendly names
	///</summary>
	public sealed class EnumTextValueAttribute : System.Attribute
	{
		private readonly string enumTextValue;
		
		///<summary>
		/// Returns the text representation of the value
		///</summary>
		public string Text
		{
			get {
					return enumTextValue;
				}	
		}
		
		///<summary>
		/// Allows the creation of a friendly text representation of the enumeration.
		///</summary>
		/// <param name="text">The reader friendly text to decorate the enum.</param>
		public EnumTextValueAttribute( string text )
        {
			enumTextValue = text;
		}
	}
	#endregion 

	#region ColumnEnumAttribute

	/// <summary>
	/// Provides column metadata information for an entity column enumeration.
	/// </summary>
	public sealed class ColumnEnumAttribute : System.Attribute
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ColumnEnumAttribute class.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="systemType"></param>
		/// <param name="dbType"></param>
		/// <param name="isPrimaryKey"></param>
		/// <param name="isIdentity"></param>
		/// <param name="allowDbNull"></param>
		/// <param name="length"></param>
		public ColumnEnumAttribute(String name, Type systemType, System.Data.DbType dbType, bool isPrimaryKey, bool isIdentity, bool allowDbNull, int length)
		{
			this.Name = name;
			this.SystemType = systemType;
			this.DbType = dbType;
			this.IsPrimaryKey = isPrimaryKey;
			this.IsIdentity = isIdentity;
			this.AllowDbNull = allowDbNull;
			this.Length = length;
		}

		/// <summary>
		/// Initializes a new instance of the ColumnEnumAttribute class.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="systemType"></param>
		/// <param name="dbType"></param>
		/// <param name="isPrimaryKey"></param>
		/// <param name="isIdentity"></param>
		/// <param name="allowDbNull"></param>
		public ColumnEnumAttribute(String name, Type systemType, System.Data.DbType dbType, bool isPrimaryKey, bool isIdentity, bool allowDbNull)
			: this(name, systemType, dbType, isPrimaryKey, isIdentity, allowDbNull, -1)
		{
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// The Name member variable.
		/// </summary>
		private String name;

		/// <summary>
		/// Gets or sets the Name property.
		/// </summary>
		public String Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// The SystemType member variable.
		/// </summary>
		private Type systemType;

		/// <summary>
		/// Gets or sets the SystemType property.
		/// </summary>
		public Type SystemType
		{
			get { return systemType; }
			set { systemType = value; }
		}

		/// <summary>
		/// The DbType member variable.
		/// </summary>
		private System.Data.DbType dbType;

		/// <summary>
		/// Gets or sets the DbType property.
		/// </summary>
		public System.Data.DbType DbType
		{
			get { return dbType; }
			set { dbType = value; }
		}

		/// <summary>
		/// The IsPrimaryKey member variable.
		/// </summary>
		private bool isPrimaryKey;

		/// <summary>
		/// Gets or sets the IsPrimaryKey property.
		/// </summary>
		public bool IsPrimaryKey
		{
			get { return isPrimaryKey; }
			set { isPrimaryKey = value; }
		}

		/// <summary>
		/// The IsIdentity member variable.
		/// </summary>
		private bool isIdentity;

		/// <summary>
		/// Gets or sets the IsIdentity property.
		/// </summary>
		public bool IsIdentity
		{
			get { return isIdentity; }
			set { isIdentity = value; }
		}

		/// <summary>
		/// The AllowDbNull member variable.
		/// </summary>
		private bool allowDbNull;

		/// <summary>
		/// Gets or sets the AllowDbNull property.
		/// </summary>
		public bool AllowDbNull
		{
			get { return allowDbNull; }
			set { allowDbNull = value; }
		}

		/// <summary>
		/// The Length member variable.
		/// </summary>
		private int length;

		/// <summary>
		/// Gets or sets the Length property.
		/// </summary>
		public int Length
		{
			get { return length; }
			set { length = value; }
		}

		#endregion Properties
	}

	#endregion ColumnEnumAttribute
		
	#region GenericStateChangedEventArgs
	/// <summary>
    /// Provides a generic way to inform interested objects about state change
    /// Supplies the old value and the new value of the changed state.
    /// </summary>
    /// <typeparam name="T">State Object</typeparam>
	public class GenericStateChangedEventArgs<T> : EventArgs
	{
		private T oldValue;
		private T newValue;

      /// <summary>
        /// Initializes a new instance of the <see cref="GenericStateChangedEventArgs&lt;T&gt;"/> class.
      /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
		public GenericStateChangedEventArgs(T oldValue, T newValue)
      {
			this.oldValue = oldValue;
			this.newValue = newValue;
		}
		
		/// <summary>
        /// Gets the old value.
        /// </summary>
        /// <value>The old value.</value>
		public T OldValue { get { return oldValue; } }
     
        /// <summary>
        /// Gets the new value.
        /// </summary>
        /// <value>The new value.</value>
		public T NewValue { get { return newValue; } }
      }
      #endregion

}

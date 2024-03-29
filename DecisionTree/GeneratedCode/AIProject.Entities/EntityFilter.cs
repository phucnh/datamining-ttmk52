﻿using System;
using System.Reflection;
using System.Collections;

namespace AIProject.Entities
{
	/// <summary>
	/// Hold a list of <see cref="Expression"/> instance.
	/// </summary>
	public sealed class Expressions : CollectionBase
	{
		/// <summary>
		/// Initializes a new instance of the <c>Expressions</c> class.
		/// </summary>
		/// <param name="holeFilterExpression">the filter expression that will be parsed to create the collection.</param>
		public Expressions (string holeFilterExpression)
		{
			this.SplitFilter(holeFilterExpression);
		}
		
		/// <summary>
		/// Initializes a new instance of the <c>Expressions</c> class.
		/// </summary>
		public Expressions() 
		{
		}
		
		/// <summary>
		/// This method split a string filter expression anc create <c>EntityFilter</c> instances.
		/// </summary>
		public void SplitFilter(string HoleFilterExpression)
		{
			int LastPosition = 0;
			
			//AND
			for (int j = 5; j <= HoleFilterExpression.Length -5; j ++)
			{
			
				string FiveCurrentChars = HoleFilterExpression.Substring(j-5, 5).ToUpper();
				if (FiveCurrentChars == " AND ") 
				{
					
					
					this.Add( new Expression(HoleFilterExpression.Substring(LastPosition , j - LastPosition -5 )));
					LastPosition = j;
				}
			}
			//OR
			for (int z = 4; z <= HoleFilterExpression.Length -4; z ++)
			{
				string TowCurrentChars = HoleFilterExpression.Substring(z -4, 4).ToUpper();
				if (TowCurrentChars == " OR " ) 
				{
					this.Add(new Expression(HoleFilterExpression.Substring(LastPosition  , z - LastPosition -4)));
					LastPosition = z;
				}
			}
		
			//Ajouter le dernier ?lement ou le premier si aucun AND/OR
			this.Add(new Expression(HoleFilterExpression.Substring(LastPosition)));
		}
		
		/// <summary>
		/// Get the <see cref="Expression"/> at the specified index.
		/// </summary>
		/// <param name="Index">The index of the expression in the collection.</param>
		/// <returns></returns>
		public Expression Item(int Index)
		{
			return (Expression) List[Index];	
		}
		
		/// <summary>
		/// Adds the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public int Add(Expression value) 
		{			
			return List.Add(value);
		}

		/// <summary>
		/// Removes the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public void Remove(Expression value) 
		{		
			List.Remove(value);
		}
	}
	
	
	/// <summary>
	///	 Reprensents an expression to filter a collection.
	/// </summary>
	public sealed class Expression
	{
		private string TmpPropertyValue;
		private string TmpOperator;
		private string TmpUserValue;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Expression"/> class.
		/// </summary>
		public Expression()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Expression"/> class.
		/// </summary>
		/// <param name="PropValue">The prop value.</param>
		/// <param name="Opr">The opr.</param>
		/// <param name="Usrvalue">The usrvalue.</param>
		public Expression(string PropValue, string Opr, string Usrvalue )
		{
			this.PropertyName = PropValue;
			this.Operator = Opr;
			this.UserValue = this.UserValue = Usrvalue;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Expression"/> class.
		/// </summary>
		/// <param name="wholeExpression">The whole expression.</param>
		public Expression( string wholeExpression)
		{
			string [] Words = new string[2] ;
			Words = wholeExpression.Split(new char[]{' '}, 3);
			this.PropertyName = Words[0];
			this.Operator = Words[1].Trim();
			this.UserValue = Words[2].Trim ();
		}
		
		/// <summary>
		/// Gets or sets the name of the property.
		/// </summary>
		/// <value>The name of the property.</value>
		public string PropertyName
		{
			get{return TmpPropertyValue;}
			set{TmpPropertyValue = value;}
		}
		
		/// <summary>
		/// Gets or sets the operator.
		/// </summary>
		/// <value>The operator.</value>
		public string Operator
		{
			get{return TmpOperator;}
			set{TmpOperator = value;}
		}
		
		/// <summary>
		/// Gets or sets the user value.
		/// </summary>
		/// <value>The user value.</value>
		public string UserValue
		{
			get{return TmpUserValue;}
			set{TmpUserValue = value;}
		}
	}
	
	/// <summary>
	/// Represents a filter.
	/// </summary>
    public sealed class EntityFilter<T, Entity>
        where T : ListBase<Entity>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityFilter&lt;T, Entity&gt;"/> class.
        /// </summary>
		public EntityFilter()
		{
		}
		
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntityFilter&lt;T, Entity&gt;"/> class.
        /// </summary>
        /// <param name="objToFilter">The obj to filter.</param>
        /// <param name="filter">The filter.</param>
		public EntityFilter(T objToFilter, string filter)
		{			
			this.ApplyFilter(objToFilter, filter);
		}
		
		#region IsOk
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(string ObjectPropertyValue , string Operator, string UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue.TrimEnd() == UserValue.TrimEnd()) {Rt = true;}
			}
			else if(Operator == "<>" | Operator == "!=")
			{
				if (ObjectPropertyValue.TrimEnd() != UserValue.TrimEnd()) {Rt = true;}
			}
			else if (Operator.ToUpper() == "LIKE")
			{
				string SearchedText = UserValue.Replace("*", "").ToLower();
				if (!UserValue.StartsWith("*"))
					Rt = ObjectPropertyValue.ToLower().StartsWith(SearchedText);
				else if (!UserValue.EndsWith("*"))
					Rt = ObjectPropertyValue.ToLower().EndsWith(SearchedText);
				else
				{
					int LastStrar = UserValue.LastIndexOf("*");
					int UserValueLenght = UserValue.Length;
					int TextPosition = ObjectPropertyValue.ToLower().IndexOf(SearchedText);
					Rt = TextPosition > -1;
				} 
			}
			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type String !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(int ObjectPropertyValue , string Operator, int UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			
			else if(Operator == "<>"|Operator == "!=")
			{
				if (ObjectPropertyValue != UserValue) {Rt = true;}
			}

			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type int !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(decimal ObjectPropertyValue , string Operator, int UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			
			else if(Operator == "<>"|Operator == "!=")
			{
				if (ObjectPropertyValue != UserValue) {Rt = true;}
			}

			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type int !");
			}
			return Rt;
		}

		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(Guid ObjectPropertyValue , string Operator, Guid UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type Guid !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(double ObjectPropertyValue , string Operator, double UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			else
			{
				
				throw new Exception("The operator '" + Operator + "' does not match the type double !");
			}
			return Rt;
		}
		
		/// <summary>
        /// Determines whether the specified object property value is ok.
        /// </summary>
        /// <param name="ObjectPropertyValue">The object property value.</param>
        /// <param name="Operator">The operator.</param>
        /// <param name="UserValue">The user value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
        /// </returns>
        private bool IsOk(long ObjectPropertyValue, string Operator, long UserValue)
        {
            bool Rt = false;

            if (Operator == "=")
            {
                if (ObjectPropertyValue == UserValue) { Rt = true; }
            }
            else if (Operator == ">")
            {
                if (ObjectPropertyValue > UserValue) { Rt = true; }
            }
            else if (Operator == ">=")
            {
                if (ObjectPropertyValue >= UserValue) { Rt = true; }
            }
            else if (Operator == "<")
            {
                if (ObjectPropertyValue < UserValue) { Rt = true; }
            }
            else if (Operator == "<=")
            {
                if (ObjectPropertyValue <= UserValue) { Rt = true; }
            }
            else
            {
                throw new Exception("The operator '" + Operator + "' does not match the type double !");
            }
            return Rt;
        }
		
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(decimal ObjectPropertyValue , string Operator, decimal UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			else
			{
				
				throw new Exception("The operator '" + Operator + "' does not match the type decimal !");
			}
			return Rt;			
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(DateTime ObjectPropertyValue , string Operator, DateTime UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			else
			{
				
				throw new Exception("The operator '" + Operator + "' does not match the type DateTime !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">if set to <c>true</c> [object property value].</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">if set to <c>true</c> [user value].</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(bool ObjectPropertyValue , string Operator, bool UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type string !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">array of the user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(object ObjectPropertyValue, string Operator, object[] UserValue)
		{
			foreach (object item in UserValue)
			{
				if (item.Equals(ObjectPropertyValue))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether the specified operator is ok.
		/// </summary>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified operator is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(string Operator, object UserValue)
		{
			bool Rt = false;
			
			if (UserValue.ToString().ToUpper() == "NULL" & Operator == "=" )
			{
				Rt = true;
			}
			return Rt;
		}
		
		/// <summary>
		/// Corrects the user value.
		/// </summary>
		/// <param name="UserValue">The user value.</param>
		/// <returns></returns>
		private string CorrectUserValue(string UserValue)
		{
			if (string.IsNullOrEmpty(UserValue))
				return UserValue;
				
			if (UserValue.Substring(0,1)  == "'")
			{
				UserValue =UserValue.Replace("'", "");
			}
			
			if (UserValue.Substring(0,1)  == "#")
			{
				UserValue =UserValue.Replace("#", "");
			}

			return UserValue;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(object ObjectPropertyValue , string Operator, string UserValue)
		{
			bool Rt = false ;
			
			//Type of the property value
			if (ObjectPropertyValue == null)
				return false;
				
			Type TypeOfValue = ObjectPropertyValue.GetType();
			Object FilterValue  = CorrectUserValue(UserValue);

			if (Operator.ToUpper().Equals("IN"))
			{
				try
				{ 
					string[] fvalue = FilterValue.ToString().Substring(1, FilterValue.ToString().Length-2).Split(',');
					object[] values = new object[fvalue.Length];
					if (TypeOfValue == typeof(int))
					{
						for (int i=0; i<fvalue.Length; i++) values[i] = int.Parse(fvalue[i]);
					}
					else if (TypeOfValue == typeof(string))
					{
						for (int i=0; i< fvalue.Length; i++) values[i] = fvalue[i];
					}
					else if (TypeOfValue == typeof(long))
					{
						for (int i=0; i<fvalue.Length; i++) values[i] = long.Parse(fvalue[i]); 
					}
					if (values.Length > 0)
						Rt = IsOk(ObjectPropertyValue, Operator, values);
					else
					{
						throw new NotSupportedException("IN operator Filtering is not possible on the type " + TypeOfValue.ToString() + ". Please use integer or long values."); 
					}
				}
				catch (Exception ex) { throw new InvalidFilterCriteriaException("Invalid IN Filter value", ex); }
			} 
			else if (TypeOfValue ==typeof(string))
			{
				Rt = IsOk((string)ObjectPropertyValue, Operator, (string) FilterValue);
			}
            else if (TypeOfValue ==typeof(int))
            {
                int o;
                if (int.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((int)ObjectPropertyValue, Operator, o);
                else
                    Rt = false;
            } 
			else if (TypeOfValue == typeof(double))
			{
                double o;
                if (double.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((double)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 

			}
			else if (TypeOfValue == typeof(decimal))
			{
                decimal o;
                if (decimal.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((decimal)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 
 			}
			else if (TypeOfValue == typeof(DateTime))
			{
                DateTime o;
                if (DateTime.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((DateTime)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 
			}
			else if (TypeOfValue == typeof(bool))
			{
                bool o;
                if (bool.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((bool)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 
			}
			else if (TypeOfValue == typeof(Guid))
			{
                Guid o;
                if (EntityUtil.GuidTryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((Guid)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 
			}
			else if (TypeOfValue == typeof(byte))
            {
                byte o;
                if (byte.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((byte)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 
			}
			else if (TypeOfValue == typeof(long))
            {
                long o;
                if (long.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((long)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 
            }
			else if (TypeOfValue == typeof(short))
            {
                short o;
                if (short.TryParse(FilterValue.ToString(), out o))
                    Rt = IsOk((short)ObjectPropertyValue, Operator, o);
                else
                    Rt = false; 
			}
			else
			{
				throw new Exception("Filtering is not possible on the type " + TypeOfValue.ToString());
			}
			return Rt;
		}
		#endregion 
		
        /// <summary>
        /// Applies the filter.
        /// </summary>
        /// <param name="ObjectToFilter">The object to filter.</param>
        /// <param name="StrFilter">The STR filter.</param>
        public void ApplyFilter(T ObjectToFilter, string StrFilter) 
		{
			if (ObjectToFilter == null)
				throw new ArgumentNullException("ObjectToFilter");
			if(string.IsNullOrEmpty(StrFilter))
				throw new ArgumentNullException("StrFilter");
			
			int CountValue = ObjectToFilter.Count;
			Expressions ListOfExpressions = new Expressions(StrFilter);
			Type itemType = typeof(Entity);

			//Loading items of the collection
			bool [] Validations;
			bool AllIsOK;
			
			PropertyInfo [] PropsInfo = new PropertyInfo[ListOfExpressions.Count ];
			for(int x = 0; x < ListOfExpressions.Count; x++)
			{
				PropsInfo	[x] = itemType.GetProperty (ListOfExpressions.Item(x).PropertyName,BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase );
				if( PropsInfo[x] == null) 
				{
					throw new Exception ("property " + ListOfExpressions.Item(x).PropertyName + " does not exist!");
				}
			}
			
			for (int f = 0; f <= (ObjectToFilter.Count -1); f++)
			{
				object CollectionItem = ObjectToFilter[f];

				Validations = new bool[ListOfExpressions.Count ];
				AllIsOK = true;

				for (int t = 0 ; t<= ListOfExpressions.Count -1 ; t++)
				{
					PropertyInfo ItemProperty = PropsInfo[t];
					object PropertyValue = ItemProperty.GetValue(CollectionItem, new object[0]);

					if (PropertyValue ==null)
					{
						Validations[t] = IsOk(ListOfExpressions.Item(t).Operator , ListOfExpressions.Item(t).UserValue );
					}
					else
					{
						Validations[t] = this.IsOk(PropertyValue, ListOfExpressions.Item(t).Operator , ListOfExpressions.Item(t).UserValue );
					}
					
					if (Validations[t] == false)
						AllIsOK = false;
				}

				if (AllIsOK == false)
				{
					ObjectToFilter.RemoveFilteredItem(f);
					CountValue -= 1;
					f -= 1;
				}
			}	
		}
	}
}

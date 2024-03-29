﻿#region Imports...
using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
#endregion

namespace AIProject.Web.UI
{
	/// <summary>
	/// Provides a mechanism for combining multiple IBindableTemplate definitions
	/// into a single instance.
	/// </summary>
	/// <remarks>
	/// Adapted from an article written by James Crowley, which can be found at:
	/// http://www.developerfusion.co.uk/show/4721/
	/// </remarks>
	public class MultiBindableTemplate : IBindableTemplate
	{
		private IBindableTemplate[] _templates;

		/// <summary>
		/// Initializes a new instance of the MultiBindableTemplate class.
		/// </summary>
		/// <param name="templates"></param>
		public MultiBindableTemplate(params IBindableTemplate[] templates)
		{
			_templates = templates;
		}

		/// <summary>
		/// Initializes a new instance of the MultiBindableTemplate class.
		/// </summary>
		/// <param name="control"></param>
		/// <param name="paths"></param>
		public MultiBindableTemplate(TemplateControl control, params String[] paths)
		{
			_templates = new IBindableTemplate[paths.Length];

			for ( int i=0; i<paths.Length; i++ )
			{
				_templates[i] = FormUtil.LoadBindableTemplate(control, paths[i]);
			}
		}

		/// <summary>
		/// Retrieves a set of name/value pairs for values bound using
		/// two-way ASP.NET data-binding syntax within the templated content.
		/// </summary>
		/// <param name="container">
		/// The System.Web.UI.Control from which to extract name/value pairs, which are
		/// passed by the data-bound control to an associated data source control in
		/// two-way data-binding scenarios.
		/// </param>
		/// <returns>
		/// An System.Collections.Specialized.IOrderedDictionary of name/value pairs.
		/// The name represents the name of a control within templated content, and the
		/// value is the current value of a property value bound using two-way ASP.NET
		/// data-binding syntax.
		/// </returns>
		public IOrderedDictionary ExtractValues(Control container)
		{
			IOrderedDictionary multi = null;
			IOrderedDictionary temp;

			if ( HasTemplates )
			{
				multi = _templates[0].ExtractValues(container);

				// extract the values for each of the templates
				for ( int i = 1; i < _templates.Length; i++ )
				{
					temp = _templates[i].ExtractValues(container);

					// copy over to the first collection
					foreach ( Object key in temp.Keys )
					{
						multi.Add(key, temp[key]);
					}
				}
			}

			// return the combined collection
			return multi;
		}

		/// <summary>
		/// When implemented by a class, defines the System.Web.UI.Control object that
		/// child controls and templates belong to. These child controls are in turn
		/// defined within an inline template.
		/// </summary>
		/// <param name="container">
		/// The System.Web.UI.Control object to contain the instances of controls from
		/// the inline template.
		/// </param>
		public void InstantiateIn(Control container)
		{
			// create a container control
			Control c = new Control();

			if ( HasTemplates )
			{
				// instantiate the templates into this control
				for ( int i = 0; i < _templates.Length; i++ )
				{
					_templates[i].InstantiateIn(c);
				}
			}

			// add our control to the container we were passed
			container.Controls.Add(c);
		}

		/// <summary>
		/// Gets a value that indicates whether there are any templates specified.
		/// </summary>
		public bool HasTemplates
		{
			get { return (_templates != null && _templates.Length > 0); }
		}
	}
}

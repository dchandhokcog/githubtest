using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using PayPal.Payments.Common.Utility;


#region "Copyright"

//Unpublished Proprietary Program Material
//This material is proprietary to PayPal, Inc. and is not to be reproduced,
//used or disclosed except in accordance with a written license agreement
//with PayPal, Inc..
//(C) Copyright 2005  PayPal, Inc.   All Rights Reserved.
//PayPal, Inc. believes that this material furnished herewith is accurate
//and reliable.  However, no responsibility, financial or otherwise, can be
// accepted for any consequences arising out of the use of this material.

//The copyright notice above does not evidence any actual or intended
//publication of such source code.

#endregion

namespace PayPal.Payments.SampleStore.CS.Common
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This module consists of the properties that will be used by the SampleStore
	/// application
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public sealed class SampleStoreProperties
	{

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly property for getting HostAddress
		/// </summary>
		/// <value></value>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public static string HostAddress
		{
			get{
				return PayflowUtility.AppSettings(SampleStoreConstants.PROP_HOSTADDRESS);
			}
		}
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly property for getting HostPort
		/// </summary>
		/// <value></value>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public static string HostPort
		{
			get{
				return null;
			}
		}
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// ReadOnly property for getting HostTimeout
		/// </summary>
		/// <value></value>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public static string HostTimeout
		{
			get{
				return null;
			}
		}
		
		//public static string ErrorPageUrl
		//{
		//	get{
		//		return PayflowUtility.AppSettings[SampleStoreConstants.PROP_URL_ERRORPAGEURL];
		//	}
		//}

		//ReadOnly Property TermUrl() As String
		//Get
		//Return PayflowUtility.AppSettings(PROP_TERMURL)
		//End Get
		//End Property
		
		
		//ReadOnly Property SampleStoreUrl() As String
		//Get
		//Return PayflowUtility.AppSettings(PROP_URL_SAMPLESTOREURL)
		//End Get
		//End Property
		
		//ReadOnly Property RedirectToACSServerUrl() As String
		//Get
		//Return PayflowUtility.AppSettings(PROP_URL_REDIRECTTOACSSERVER)
		//End Get
		//End Property
		
		
		//ReadOnly Property BAHostAddress() As String
		//Get
		//Return PayflowUtility.AppSettings(PROP_BAHOSTADDRESS)
		//End Get
		//End Property
		
		
		//ReadOnly Property BAHostPort() As String
		//Get
		//Return PayflowUtility.AppSettings(PROP_BAHOSTPORT)
		//End Get
		//End Property
		

	}
	
}


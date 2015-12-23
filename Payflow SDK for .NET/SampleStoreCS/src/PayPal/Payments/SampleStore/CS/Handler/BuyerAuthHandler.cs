using PayPal.Payments.DataObjects;
using PayPal.Payments.SampleStore.CS.Common;

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

namespace PayPal.Payments.SampleStore.CS.Handler
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This is the base class for the Strong and Weak Assembly VE and VA handlers
	/// </summary>
	/// -----------------------------------------------------------------------------
	public class BuyerAuthHandler : PayPal.Payments.SampleStore.CS.Handler.ITransactionHandler
	{
		/// <summary>
		/// UserInfo object
		/// </summary>
		[field:System.CLSCompliant(false)]		public UserInfo UserInfo;
		/// <summary>
		/// PayflowConnectionData object
		/// </summary>
		[field:System.CLSCompliant(false)]		public PayflowConnectionData PayflowConnectionData;
		#region "SetDataObjects"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the data objects that will be passed in the constructor
		/// of BuyerAuthVETransaction and BuyerAuthVATransaction
		/// </summary>
		/// <param name="RequestData"></param>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public virtual void SetDataObjects (System.Collections.Hashtable RequestData)
		{
			
			UserInfo = SetUserInfo(RequestData[SampleStoreConstants.FIELD_USER].ToString(), RequestData[SampleStoreConstants.FIELD_VENDOR].ToString(), RequestData[SampleStoreConstants.FIELD_PARTNER].ToString(), RequestData[SampleStoreConstants.FIELD_PASSWORD].ToString());
			
			PayflowConnectionData = SetPayflowConnectionData();
			
		}
		
		#endregion
		
		#region "SetUserInfo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the User, Vendor , Partner , Password from the properties
		/// in the UserInfo object and returns the same
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private UserInfo SetUserInfo(string User, string Vendor, string Partner, string Password)
		{
			
			UserInfo = new UserInfo(User, Vendor, Partner, Password);
			return UserInfo;
			
		}
		#endregion
		
		#region "SetPayflowConnectionData"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the connection params from the properties in the
		/// Payflow Connection object and returns the same
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private PayflowConnectionData SetPayflowConnectionData()
		{
			PayflowConnectionData = new PayflowConnectionData(SampleStoreProperties.HostAddress);
			return PayflowConnectionData;
		}
		#endregion
		
		#region "SubmitTransaction"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This is the SubmitTransatcion function that will be overridden by the base
		/// classes with their own implementatin
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		public virtual System.Collections.Hashtable SubmitTransaction(System.Collections.Hashtable RequestData)
		{
			
			return null;
		}
		#endregion
	}
	
}


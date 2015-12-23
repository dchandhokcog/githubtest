using System.Collections;
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
	/// This class processes the Validate Authentication transaction for Strong assembly
	/// request.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public class StrongAssemblyVAHandler : BuyerAuthHandler
	{
		
		#region "SubmitTransaction"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// Function calls the SubmitTransaction method of the BuyerAuthVATransaction class
		/// and gets the BuyerAuthResponse object. The function pupulates the response in
		/// the hashtable and returns the same.
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>HashTable</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public new Hashtable SubmitTransaction(Hashtable RequestData)
		{
			//Dim BAVARequest As New BuyerAuthVATransaction(UserInfo,             '                                              PayflowConnectionData,             '                                            RequestData.Item(REQUEST_PARES).ToString)
			//Response BAResponse;
			//bool Status;
			
			//Status = BAVARequest.SubmitTransaction()
			//BAResponse = BAVARequest.Response
			
			//Get the response after Validate Authentication, set the same in the RequestData
			//and return the hashtable
			
			//RequestData.Item(BAS_RESP_AUTHID_KEY) = BAResponse.
			//RequestData.Item(BAS_RESP_AUTHSTATUS_KEY) = BAResponse.
			//RequestData.Item(BAS_RESP_CAVV_KEY) = BAResponse.
			//RequestData.Item(BAS_RESP_ECI_KEY) = BAResponse.
			//RequestData.Item(BAS_RESP_XID_KEY) = BAResponse.
			
			//Set the Buyer Auth required flag to N so that the code for Verify Enrollment is
			//not run in the ProcessRequest function of the controller
			
			RequestData[SampleStoreConstants.FIELD_BAREQUIRED] = SampleStoreConstants.FLG_NO;
			
			return RequestData;
		}
		#endregion
		
	}
}


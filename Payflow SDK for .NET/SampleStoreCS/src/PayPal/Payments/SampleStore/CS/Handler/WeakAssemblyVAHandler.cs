using System.Collections;


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
	/// <summary>
	/// Handler for Weak Assembly VA
	/// </summary>
	public class WeakAssemblyVAHandler
	{
		/// <summary>
		/// Validates authentication of Request
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns></returns>
		public Hashtable DoValidateAuthentication(Hashtable RequestData)
		{
			//Dim ObjPayflow API As New Payflow API
			//string StrRequest;
			//Dim StrResponse As String
			//StrRequest = RequestData[SampleStoreConstants.FIELD_WEAKASSEMBLYREQUEST].ToString();
			//ObjPayflow API.CreateContext()
			//StrResponse = ObjPayflow API.SubmitTransaction(StrRequest)
			//ObjPayflow API.DestroyContext()
			//RequestData.Item(FIELD_WEAKASSEMBLYRESPONSE) = StrResponse
			return RequestData;
		}
	}
}


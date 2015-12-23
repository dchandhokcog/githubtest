using System;
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
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This class processes the verify enrollment request for strong assembly.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public class StrongAssemblyVEHandler : BuyerAuthHandler
	{
		#region "SubmitTransaction"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function calls the submit transaction method of the buyerauthverequest class
		/// and gets the buyer auth response object. The response is populated in the
		/// request hashtable. The user is redirected to ACS server for entering the
		/// authentication if VE is successful else , the function
		/// returns the hash table with the response populated in it.
		/// </summary>
		/// <param name="RequestData"></param>
		/// <param name="HttpResponse"></param>
		/// <returns>HashTable</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public Hashtable SubmitTransaction(Hashtable RequestData, System.Web.HttpResponse HttpResponse)
		{
			
			//Response BAResponse = new Response();
			//			bool Status;
			//			BuyerAuthVETransaction BAVERequest;
			try
			{
				//BAVERequest = New BuyerAuthVETransaction(UserInfo,                 '                                               PayflowConnectionData,                 '                                              RequestData.Item(FIELD_CURRENCY).ToString,                 '                                             RequestData.Item(FIELD_PURDESC).ToString)
				
				//Status = BAVERequest.SubmitTransaction()
				
				//BAResponse = BAVERequest.Response
				
				//Get the buyer auth response and set the response fields in the Request hash table
				
				//
				//Code for setting the response in hashtable
				//
				
				//If VE is successful, encrypt the request in to a file
				//if (VE Successful ) then
				//WriteRequestToFile(RequestData)
				
				//Get ACSUrl and PaReq from the response and redirect to ACSUrl
				
				//Hardcoded for testing
				//				string StrACSUrl = "https://pilot-buyerauth-post.PayPal.com:443/DDDSecure/Acs3DSecureSim/start";
				//				string StrPaReq = "eJxVUttSgzAQ/RWmH0ACBex0tpnpxdE+wFTFcfQtJjsFLYEGkPbvTSjYui+7Zy8newmkmUbcvKBoNTKIsa75Hp1cLiaRoAGPxJ2YRX4QBZH0Qz5hsFs+45HBD+o6LxXzXOr6QEZoGLTIuGoYcHFcbRPmWwEyIChQbzfMGwTIBYPiBbIV1o2z5odDrvZGa+msy6Li6gykj4MoW9XoM5sFFMgIoNUHljVNNSek6zr307CIC4kwHK4oCyA2B8i1uV1rrdpwnnLJ4vS+S75k/p4m2ccm+U7SbRe/PQXxw+sCiM0AyRtkPqUBjajnUG8+pXM6BdL7gRe2GeaHLjWdDQgq+8hyDNnIrQfMyjUqMY4zIsBTVSq0NUD+bJBYCzPCoK79rx/tqkVjthh69FZmdut9wFJqRkPq9YzaENgyMtySDGc31r/v8AuSVLDc";
				//Dim StrTermUrl As String = TermUrl.ToString
				
				//HttpResponse.Redirect(RedirectToACSServerUrl.ToString & "?PaReq=" & HttpUtility.UrlEncode(StrPaReq) & "&ACSUrl=" & StrACSUrl & "&TermUrl=" & StrTermUrl)
				//Set the Buyer Auth required flag to N so that the code for Verify Enrollment is
				//not run after the response is obtained from ACS Server
				RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_BAREQUIRED] = PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FLG_NO;
				
				return RequestData;
			}
			catch (System.Threading.ThreadAbortException)
			{
				//Do nothing. If removed, throws error during redirecting
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message, ex));
			}
			
			//end if
			
			return null;
		}
		
		#endregion
	}
}


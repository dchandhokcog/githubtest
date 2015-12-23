using System;
using System.Collections;
using PayPal.Payments.Communication;
using PayPal.Payments.SampleStore.CS.Common;
using PayPal.Payments.Common.Utility;
using System.Xml;
using System.Text ;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.DataObjects;


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
	/// Class handler for weak Assembly Transaction
	/// </summary>
	public class WeakAssemblyTransHandler
	{
		///  -----------------------------------------------------------------------------
		/// <summary>
		/// This function calls the SubmitTransaction method, for the
		/// object of WeakAssemblyTransHandler class,gets the response object and returns the same       ''' 
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns></returns>
		/// -----------------------------------------------------------------------------
		#region "SetClientInfo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function creates an ClientInfo object, sets the data and returns the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>ClientInfo</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private  ClientInfo SetClientInfo(Hashtable RequestData)
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetClientInfo() : Entered", PayflowConstants.SEVERITY_DEBUG);
				ClientInfo ClientInfo = new ClientInfo();
				//Set the ClientInfo object fields
				Hashtable with_1 = RequestData;
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_PRODUCT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_PRODUCT)], null)))
				{
					ClientInfo.IntegrationProduct = with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_PRODUCT)].ToString();
				}
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_VERSION)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_VERSION)], null)))
				{
					ClientInfo.IntegrationVersion  = with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_VERSION)].ToString();
				}
								
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetInvoice() : Exiting", PayflowConstants.SEVERITY_DEBUG);
				return ClientInfo;
				
			}
			catch (Exception Ex)
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetInvoice() : In the catch of exception. Error Occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL);
				throw (new Exception(Ex.Message, Ex));
			}
		}
		#endregion
		
		public string SubmitTransaction(Hashtable RequestData)
		{
			try
			{
				string Response,mProxyAddress;
				string mRequestId;
				string TransactionReqt;
				int mProxyPort=0;
				mRequestId = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_REQUESTID].ToString();
				if (object.Equals(mRequestId, null) | object.Equals(mRequestId, PayflowConstants.EMPTY_STRING))
				{
					mRequestId = PayflowUtility.RequestId;
				}
				
				if (!(object.Equals(RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_PROXYPORT], null) | object.Equals(RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_PROXYPORT], PayflowConstants.EMPTY_STRING)))
				{
					mProxyPort = int.Parse(RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_PROXYPORT].ToString());
				}
				mProxyAddress=RequestData[SampleStoreConstants.FIELD_PROXYADDRESS].ToString();
				PayflowNETAPI PayflowNETAPI = new PayflowNETAPI(null, 0, 0, mProxyAddress, mProxyPort, RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_PROXYLOGON].ToString(), RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_PROXYPASSWORD].ToString());
				TransactionReqt = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_WEAKASSEMBLYREQUEST].ToString();
				PayflowNETAPI.ClientInfo = SetClientInfo(RequestData);
				Response = PayflowNETAPI.SubmitTransaction(TransactionReqt, mRequestId);
				Response = Response + "^";  

				return Response;
				
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message, ex));
			}
			
		}
		
	}
	
}


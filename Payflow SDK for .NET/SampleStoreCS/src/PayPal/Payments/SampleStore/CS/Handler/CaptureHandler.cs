using System;
using System.Collections;
using PayPal.Payments.SampleStore.CS.Common;
using PayPal.Payments.Transactions;
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

namespace PayPal.Payments.SampleStore.CS.Handler
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This class creates object of CaptureTransaction class, call its
	/// SubmitTransaction method, gets the response object and returns the same
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public class CaptureHandler : BaseTransactionHandler
	{
		
		
		#region "SubmitTransaction"
		/// <summary>
		/// This function overrides the submittransaction function of the base class.
		/// This function creates object of CaptureTransaction class, call its
		/// SubmitTransaction method, gets the response object and returns the same
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public override Hashtable SubmitTransaction(Hashtable RequestData)
		{
			try
			{
				
				string mRequestId;
				CaptureTransaction CaptureTrans;
				Hashtable ResponseTable = new Hashtable() ;
				
				mRequestId = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_REQUESTID].ToString();
				if (object.Equals(mRequestId, null) | object.Equals(mRequestId, PayflowConstants.EMPTY_STRING))
				{
					mRequestId = PayflowUtility.RequestId;
				}
				
				CaptureTrans = new CaptureTransaction(RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_ORIGID].ToString(), UserInfo, PayflowConnectionData, Invoice,Tender,mRequestId);
				
				string mVerbosity = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_VERBOSITY].ToString();
				
				if (!(object.Equals(mVerbosity, null) | mVerbosity.Length == 0))
				{
					CaptureTrans.Verbosity = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_VERBOSITY].ToString();
				}
				CaptureTrans.ClientInfo = ClientInfo;
				CaptureTrans.SubmitTransaction();
				ResponseTable.Add ("TRXRESPONSE", CaptureTrans.Response);
				return ResponseTable;
				
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message, ex));
			}
			
		}
		#endregion
	}
}



using System;
using System.Collections;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;
using PayPal.Payments.Common.Utility;
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
	/// Project	 : Payflow SDK-SampleStore
	/// Class	 : Payments.SampleStore.CS.Handler.VoiceAuthHandler
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This class creates object of VoiceAuthTransaction class, call its 
	/// SubmitTransaction method, gets the response object and returns the same
	/// </summary>
	///  -----------------------------------------------------------------------------
	
	public class VoiceAuthHandler : BaseTransactionHandler
	{
		///-----------------------------------------------------------------------------
		/// <summary>
		/// This function overrides the submittransaction function of the base class.
		/// This function creates object of VoiceAuthTransaction class, call its 
		/// SubmitTransaction method, gets the response object and returns the same     
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns></returns>
		///  -----------------------------------------------------------------------------
		
		public override Hashtable SubmitTransaction(Hashtable RequestData)
		{
			try
			{
				
				int mCount;
				string mRequestId;
				VoiceAuthTransaction VoiceAuthTrans;
				Hashtable ResponseTable = new Hashtable();
				
				mRequestId = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_REQUESTID].ToString();
				if (object.Equals(mRequestId, null) | object.Equals(mRequestId, PayflowConstants.EMPTY_STRING))
				{
					mRequestId = PayflowUtility.RequestId;
				}
				
				VoiceAuthTrans = new VoiceAuthTransaction(RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_AUTHCODE].ToString(), UserInfo, PayflowConnectionData, Invoice, Tender, mRequestId);
				
				for (mCount = 0; mCount <= ExtDataList.Count - 1; mCount++)
				{
					VoiceAuthTrans.AddToExtendData((ExtendData)(ExtDataList[mCount]));
				}
				
				string mVerbosity = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_VERBOSITY].ToString();
				if (!(object.Equals(mVerbosity, null) | mVerbosity.Length == 0))
				{
					VoiceAuthTrans.Verbosity = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_VERBOSITY].ToString();
				}
				VoiceAuthTrans.ClientInfo = ClientInfo;
				VoiceAuthTrans.SubmitTransaction();
				ResponseTable.Add ("TRXRESPONSE", VoiceAuthTrans.Response);
				return ResponseTable;
				
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message, ex));
			}
		}
	}
}

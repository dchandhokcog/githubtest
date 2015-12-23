using System;
using System.Collections;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;
using PayPal.Payments.SampleStore.CS.Common;
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
	/// This class creates object of CreditTransaction class, call its
	/// SubmitTransaction method, gets the response object and returns the same
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	
	public class CreditHandler : BaseTransactionHandler
	{
		#region "SubmitTransaction"
		/// <summary>
		/// This function overrides the submittransaction function of the base class.
		/// This function creates object of CreditTransaction class, call its
		/// SubmitTransaction method, gets the response object and returns the same
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		public override Hashtable SubmitTransaction(Hashtable RequestData)
		{
			try
			{
				CreditTransaction CreditTrans;
				string mOrigId;
				string mRequestId;
				int mCount;
				Hashtable ResponseTable = new Hashtable();
				
				mRequestId = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_REQUESTID].ToString();
				mOrigId = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_ORIGID].ToString();
				
				if (object.Equals(mRequestId, null) | object.Equals(mRequestId, PayflowConstants.EMPTY_STRING))
				{
					mRequestId = PayflowUtility.RequestId;
				}
				
				if (object.Equals(mOrigId, null) | object.Equals(mOrigId, PayflowConstants.EMPTY_STRING))
				{
					CreditTrans = new CreditTransaction(UserInfo, PayflowConnectionData, Invoice, Tender, mRequestId);
					
				}
				else
				{
					CreditTrans = new CreditTransaction(mOrigId, UserInfo, PayflowConnectionData, Invoice,Tender,mRequestId);
				}
				
				for (mCount = 0; mCount <= ExtDataList.Count - 1; mCount++)
				{
					CreditTrans.AddToExtendData((ExtendData)(ExtDataList[mCount]));
				}

				string mVerbosity = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_VERBOSITY].ToString();
				
				if (!(object.Equals(mVerbosity, null) | mVerbosity.Length == 0))
				{
					CreditTrans.Verbosity = RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_VERBOSITY].ToString();
				}
				CreditTrans.ClientInfo = ClientInfo;
				CreditTrans.SubmitTransaction();				
				ResponseTable.Add ("TRXRESPONSE", CreditTrans.Response);
								
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


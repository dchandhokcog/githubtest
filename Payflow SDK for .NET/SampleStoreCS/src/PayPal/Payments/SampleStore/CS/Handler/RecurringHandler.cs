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
	/// This class creates object of RecurringTransaction class, call its
	/// SubmitTransaction method, gets the response object and returns the same
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	
	public class RecurringHandler : BaseTransactionHandler
	{
		RecurringInfo RecurringInfo;
		#region "SubmitTransaction"
		/// <summary>
		/// This function overrides the submittransaction function of the base class.
		/// This function creates object of RecurringTransaction class, call its
		/// SubmitTransaction method, gets the response object and returns the same
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		public override Hashtable SubmitTransaction(Hashtable RequestData)
		{
			
			RecurringTransaction RecurringTrans = null;
			string mRequestId;
			int mCount;
			Hashtable ResponseTable = new Hashtable();
			
			mRequestId = RequestData[SampleStoreConstants.FIELD_REQUESTID].ToString();
			if (object.Equals(mRequestId, null) | object.Equals(mRequestId, SampleStoreConstants.EMPTY_STRING))
			{
				mRequestId = PayflowUtility.RequestId;
			}
			
			switch (RequestData[SampleStoreConstants.FIELD_ACTION].ToString())
			{
                case SampleStoreConstants.ACTION_ADD :
                    RecurringTrans = new RecurringAddTransaction(UserInfo, 
                                                                 PayflowConnectionData, 
                                                                 Invoice, 
                                                                 Tender, 
                                                                 RecurringInfo, 
                                                                 mRequestId);
					break;
                case SampleStoreConstants.ACTION_MODIFY :
                    RecurringTrans = new RecurringModifyTransaction(UserInfo, 
                                                                    PayflowConnectionData, 
                                                                    RecurringInfo, 
                                                                    Invoice, 
                                                                    Tender, 
                                                                    mRequestId);
					break;
                case SampleStoreConstants.ACTION_CANCEL :
                    RecurringTrans = new RecurringCancelTransaction(UserInfo, 
                                                                    PayflowConnectionData, 
                                                                    RecurringInfo, 
                                                                    mRequestId);
					break;
                case SampleStoreConstants.ACTION_INQUIRY :
                    RecurringTrans = new RecurringInquiryTransaction(UserInfo, 
                                                                        PayflowConnectionData, 
                                                                        RecurringInfo, 
                                                                        mRequestId);
					break;
                case SampleStoreConstants.ACTION_PAYMENT :
                    RecurringTrans = new RecurringPaymentTransaction(UserInfo, 
                                                                        PayflowConnectionData, 
                                                                        RecurringInfo, 
                                                                        Invoice, 
                                                                        mRequestId);
					break;
                case SampleStoreConstants.ACTION_REACTIVTE :
                    RecurringTrans = new RecurringReActivateTransaction(UserInfo, 
                                                                        PayflowConnectionData, 
                                                                        RecurringInfo, 
                                                                        Invoice, 
                                                                        Tender, 
                                                                        mRequestId);
					break;
				default:
					break;
			}
			
			for (mCount = 0; mCount <= ExtDataList.Count - 1; mCount++)
			{
				RecurringTrans.AddToExtendData((ExtendData)(ExtDataList[mCount]));
			}
			
			string mVerbosity = RequestData[SampleStoreConstants.FIELD_VERBOSITY].ToString();
			if (!(object.Equals(mVerbosity, null) | mVerbosity.Length == 0))
			{
				RecurringTrans.Verbosity = RequestData[SampleStoreConstants.FIELD_VERBOSITY].ToString();
			}
			RecurringTrans.ClientInfo = ClientInfo;
			RecurringTrans.SubmitTransaction();
			ResponseTable.Add ("TRXRESPONSE", RecurringTrans.Response);
							
			return ResponseTable;
			
			
		}
		
		#endregion
		
		#region "SetDataObjects"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function overrides the SetDataObjects function of the base class.
		/// The function sets the RecurringInfo object which is passed in the constructor
		/// of the RecurringTransaction
		/// </summary>
		/// <param name="RequestData"></param>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public override void SetDataObjects (Hashtable RequestData)
		{
			
			try
			{
				RecurringInfo = new RecurringInfo();
				
				Hashtable with_1 = RequestData;
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_OPTIONALTRXTYPE], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.OptionalTrx  = with_1[SampleStoreConstants.FIELD_OPTIONALTRXTYPE].ToString();
				}
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_ORIGPROFILEID], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.OrigProfileId = with_1[SampleStoreConstants.FIELD_ORIGPROFILEID].ToString();
				}
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_PAYMENTHISTORY], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.PaymentHistory = with_1[SampleStoreConstants.FIELD_PAYMENTHISTORY].ToString();
				}
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_PAYMENTNUM], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.PaymentNum = with_1[SampleStoreConstants.FIELD_PAYMENTNUM].ToString();
				}
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_PAYPERIOD], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.PayPeriod = with_1[SampleStoreConstants.FIELD_PAYPERIOD].ToString();
				}
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_PROFILENAME], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.ProfileName = with_1[SampleStoreConstants.FIELD_PROFILENAME].ToString();
				}			
				
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_MAXFAILPAYMENTS], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.MaxFailPayments = long.Parse(with_1[SampleStoreConstants.FIELD_MAXFAILPAYMENTS].ToString());
				}
				
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_OPTIONALTRXAMT], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.OptionalTrxAmt = SampleStoreUtil.GetCurrencyFromString(with_1[SampleStoreConstants.FIELD_OPTIONALTRXAMT].ToString());
				}
				
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_RETRYNUMDAYS], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.RetryNumDays = long.Parse(with_1[SampleStoreConstants.FIELD_RETRYNUMDAYS].ToString());
				}
				
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_RECURRINGSTARTDATE], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.Start = with_1[SampleStoreConstants.FIELD_RECURRINGSTARTDATE].ToString();
				}
				
				if (! object.Equals(with_1[SampleStoreConstants.FIELD_TERM], SampleStoreConstants.EMPTY_STRING))
				{
					RecurringInfo.Term = long.Parse(with_1[SampleStoreConstants.FIELD_TERM].ToString());
				}
				base.SetDataObjects(RequestData);
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message, ex));
			}
			
		}
		
		#endregion
	}
}


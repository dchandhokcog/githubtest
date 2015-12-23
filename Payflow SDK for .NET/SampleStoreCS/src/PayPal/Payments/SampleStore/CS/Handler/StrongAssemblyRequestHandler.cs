using System;
using System.Collections;
using PayPal.Payments.SampleStore.CS.Common;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.SampleStore.CS.Handler;



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
	/// This class redirects the request of different transaction handlers depending on the
	/// transaction type requested
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public class StrongAssemblyRequestHandler
	{
		#region "SubmitRequestToHandler"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function creates the object of the ITransactionHandler interface and assigns the
		/// same to the object of the handler that is instantiated depending on the transaction
		/// type. The SetDataObject function of the handlers is called for setting the
		/// data objects. The response object is obtained after calling the submittransaction
		/// of the handler which is returned from the function.
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>Response</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public Hashtable SubmitRequestToHandler(Hashtable RequestData)
		{
			
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG);
			
			Hashtable mResponse;
			ITransactionHandler ITransactionHandlerObj=null;
			try
			{
				switch (RequestData[SampleStoreConstants.FIELD_TRXTYPE].ToString())
				{
					case SampleStoreConstants.TRXTYPE_AUTH:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.AuthHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of AuthHandler", PayflowConstants.SEVERITY_INFO);
						break;
					case SampleStoreConstants.TRXTYPE_CAPTURE:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.CaptureHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of CaptureHandler", PayflowConstants.SEVERITY_INFO);
						break;
					case SampleStoreConstants.TRXTYPE_CREDIT:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.CreditHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of CreditHandler", PayflowConstants.SEVERITY_INFO);
						break;
					case SampleStoreConstants.TRXTYPE_SALE:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.SaleHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of SaleHandler", PayflowConstants.SEVERITY_INFO);
						break;
					case SampleStoreConstants.TRXTYPE_INQUIRY:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.InquiryHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of InquiryHandler", PayflowConstants.SEVERITY_INFO);
						break;
					case SampleStoreConstants.TRXTYPE_VOID:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.VoidHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of VoidHandler", PayflowConstants.SEVERITY_INFO);
						break;
					case SampleStoreConstants.TRXTYPE_VOICEAUTH:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.VoiceAuthHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of VoiceAuthHandler", PayflowConstants.SEVERITY_INFO);
						break;
					case SampleStoreConstants.TRXTYPE_RECURRING:
						
						ITransactionHandlerObj = new PayPal.Payments.SampleStore.CS.Handler.RecurringHandler();
						Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of RecurringHandler", PayflowConstants.SEVERITY_INFO);
						break;
					default:
						if (RequestData[SampleStoreConstants.FIELD_TRXTYPE].ToString() == SampleStoreConstants.TRXTYPE_RMSREVIEW)
						{
							
							ITransactionHandlerObj = new FraudReviewHandler();
							Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Created Object of FraudReviewHandler", PayflowConstants.SEVERITY_INFO);
							break;
						}
						break;
				}
				
				if (object.Equals(ITransactionHandlerObj, null))
				{
					mResponse = null;
				}
				else
				{
					ITransactionHandlerObj.SetDataObjects(RequestData);
					mResponse = ITransactionHandlerObj.SubmitTransaction(RequestData);
				}
				
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SubmitRequestToHandler(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG);
				return mResponse;
				
			}
			catch (Exception ex)
			{
				throw (new Exception(ex.Message, ex));
			}
			
		}
		
		#endregion
	}
}


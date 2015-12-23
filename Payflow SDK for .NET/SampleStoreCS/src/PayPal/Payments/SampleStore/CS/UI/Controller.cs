using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;
using PayPal.Payments.SampleStore.CS.Common;
using PayPal.Payments.SampleStore.CS.Handler;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Logging;
using System.Reflection;



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

namespace PayPal.Payments.SampleStore.CS.UI
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This is the controller class for the Samplestore.
	/// Depending upon the request and the transaction type ,
	/// appropriate request handlers are called.
	/// The response obtained is redirected to response page depending on the request
	/// type.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------

	public class Controller
	{
		//Dim mContinueFlag As Boolean
		/// <summary>
		/// Object of class HttpContext
		/// </summary>
		public System.Web.HttpContext mHttpContext;
		/// <summary>
		/// Object of class HttpServerUtility
		/// </summary>
		public System.Web.HttpServerUtility mServer;
		
		#region "ProcessRequest"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// Check if the request has PARES value present. If yes call the processVAFunction.
		/// If buyerauth is requested, call ProcessVERequest function and set the
		/// mContinueFlag to false.
		/// If mContinueFlag is true, check the request type and instantiate the request
		/// handlers depending on the request type.
		/// </summary>
		/// <param name="RequestData">Hashtable</param>
		/// <returns>Nothing</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private void ProcessRequest (Hashtable RequestData)
		{
			
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Entered", PayflowConstants.SEVERITY_DEBUG);
			
			object TransResponse;
			Hashtable ResponseTable = new Hashtable();
			try
			{
				//Uncomment the following code for performing Buyer Auth
				
				//If RequestData.ContainsKey(REQUEST_PARES) Then
				//PARES present
				//RequestData = ProcessVARequest(RequestData, HttpResponse)
				//mContinueFlag = False
				//End If
				
				//If Object.Equals(FLG_YES, RequestData.Item(FIELD_BAREQUIRED)) Then
				//Buyer Auth requested, do verify enrollment
				//ProcessVERequest(RequestData, HttpResponse)
				//mContinueFlag = False
				//End If
				
				//If mContinueFlag Then
				
				if (object.Equals(PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.REQUESTTYPE_STRONGASSEMBLY, RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_REQUESTTYPE]))
				{
					Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Executing Strong Assembly Request", PayflowConstants.SEVERITY_INFO);
					
				    StrongAssemblyRequestHandler StrongAsmblReqHandler = new StrongAssemblyRequestHandler();
					ResponseTable = StrongAsmblReqHandler.SubmitRequestToHandler(RequestData);
					TransResponse = ResponseTable["TRXRESPONSE"];
                   
					mHttpContext.Items.Add(PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.CONTEXT_RESPONSEOBJECT, TransResponse);
								
				}
				else
				{
					Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Executing Weak Assembly Request", PayflowConstants.SEVERITY_INFO);
					
					WeakAssemblyRequestHandler WeakAsmblReqHandler = new WeakAssemblyRequestHandler();
					string mResponse = WeakAsmblReqHandler.SubmitRequestToHandler(RequestData);
					
					Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : The Request to the Payflow Server : " + RequestData[PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.FIELD_REQUESTTYPE].ToString(), PayflowConstants.SEVERITY_INFO);
					Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : The Response obtained from Payflow Server : " + mResponse, PayflowConstants.SEVERITY_INFO);
					Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Exiting", PayflowConstants.SEVERITY_DEBUG);
					mHttpContext.Items.Add(PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.CONTEXT_WEAKASSEMBLYRESPONSE, mResponse);
				}
			}
			catch (System.Threading.ThreadAbortException)
			{
				//Do nothing. If removed, throws error during redirecting
				//Catch baex As Exceptions.BaseException
				//   HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & baex.ToString())
			}
			catch (Exception Ex)
			{
				
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : In the catch of exception. Following error occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL);
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Exiting", PayflowConstants.SEVERITY_DEBUG);
				throw (new Exception(Ex.Message, Ex));
			}
		}
		#endregion
		
		#region "ProcessVERequest"
		
		//Private Sub ProcessVERequest(ByVal RequestData As Hashtable, ByVal HttpResponse As HttpResponse)
		
		//    Dim BAHashTable As Hashtable
		//    Try
		//        If Object.Equals(REQUESTTYPE_STRONGASSEMBLY, RequestData.Item(FIELD_REQUESTTYPE)) Then
		//            Dim strongAsmblVEHandler As New StrongAssemblyVEHandler
		
		//            strongAsmblVEHandler.SetDataObjects(RequestData)
		//            BAHashTable = strongAsmblVEHandler.SubmitTransaction(RequestData, HttpResponse)
		
		//            ProcessRequest(BAHashTable)
		//        Else
		//            'Dim weakAsmblVEHandler As New WeakAssemblyVEHandler
		//        End If
		//    Catch taex As Threading.ThreadAbortException
		
		//    Catch ex As Exception
		//        Throw New Exception(ex.Message)
		//    End Try
		//End Sub
		
		#endregion
		
		#region "ProcessFollowOnRequest"
		
		
		//Private Sub ProcessFollowOnRequest(ByVal RequestData As Hashtable, ByVal HttpResponse As HttpResponse)
		
		//    Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessFollowOnRequest : Entered", PayflowConstants.SEVERITY_DEBUG)
		
		//    'mContinueFlag = True
		//    Dim TransResponse As Object
		//    Try
		//        'If mContinueFlag Then
		//        If Object.Equals(REQUESTTYPE_STRONGASSEMBLY, RequestData.Item(FIELD_REQUESTTYPE)) Then
		//            Dim StrongAsmblReqHandler As New StrongAssemblyRequestHandler
		//            TransResponse = StrongAsmblReqHandler.SubmitRequestToHandler(RequestData)
		//            mHttpContext.Items.Add(CONTEXT_RESPONSEOBJECT, TransResponse)
		//            If TypeOf TransResponse Is Response Then
		//                'Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessFollowOnRequest : The Request to the PFProServer : " + CType(TransResponse, Response).TransactionResult.Request, PayflowConstants.SEVERITY_DEBUG)
		//                'Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessFollowOnRequest : The Response obtained from the PFProServer : " + CType(TransResponse, Response).TransactionResult.Response, PayflowConstants.SEVERITY_DEBUG)
		//                'Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.ProcessFollowOnRequest : Exiting", PayflowConstants.SEVERITY_DEBUG)
		//                'mServer.Transfer(StrongAsmbRespUrl.ToString)
		//            Else
		//                'mHttpContext.Items.Add(CONTEXT_ERRORMESSAGE, "Response Object obtained null")
		//                'mServer.Transfer(ErrorPageUrl.ToString)
		//            End If
		//        Else
		//            Dim WeakAsmblReqHandler As New WeakAssemblyRequestHandler
		//            Dim mResponse As String
		//            mResponse = WeakAsmblReqHandler.SubmitRequestToHandler(RequestData)
		//            mHttpContext.Items.Add(CONTEXT_WEAKASSEMBLYRESPONSE, mResponse)
		//            'mServer.Transfer(WeakAsmbRespUrl.ToString)
		//        End If
		
		//        'End If
		
		//    Catch taex As Threading.ThreadAbortException
		//        'Do nothing. If removed, throws error during redirecting
		//        'Catch baex As Exceptions.BaseException
		//        '   HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & baex.ToString())
		//    Catch ex As Exception
		//        HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & ex.Message)
		//    End Try
		//End Sub
		#endregion
		
		#region "Constructor"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// Constructor for the controller. Accepts the HttpRequest and HttpResponse
		/// objects. It puts the request data into a hashtable and calls the ProcessRequest
		/// function. Gets the response in form of a string and redirects the Samplestore
		/// to the response page
		/// </summary>
		/// <param name="HttpRequest"></param>
		/// <param name="HttpContext"></param>
		/// <param name="Server"></param>
		/// <remarks>
		/// Will be called when the request comes from SampleStore.aspx
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public Controller(HttpRequest HttpRequest, System.Web.HttpContext HttpContext, System.Web.HttpServerUtility Server) {
			
			Hashtable RequestData;
			
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.New(HttpRequest, HttpResponse) : Entered", PayflowConstants.SEVERITY_DEBUG);
			
			mHttpContext = HttpContext;
			mServer = Server;
			
			RequestData = PayPal.Payments.SampleStore.CS.Common.SampleStoreUtil.GetHashTableWithRequest(HttpRequest);
			if (mHttpContext.Items.Contains(PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.CONTEXT_REQUESTDATA))
			{
				mHttpContext.Items.Remove(PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.CONTEXT_REQUESTDATA);
			}
			mHttpContext.Items.Add(PayPal.Payments.SampleStore.CS.Common.SampleStoreConstants.CONTEXT_REQUESTDATA, RequestData);
			ProcessRequest(RequestData);
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.New(HttpRequest, HttpResponse) : Exiting", PayflowConstants.SEVERITY_DEBUG);
		}
		#endregion
		
		#region "ProcessVARequest"
		
		//Private Shared Function ProcessVARequest(ByVal RequestData As Hashtable) As Hashtable
		
		//    Dim BAHashTable As New Hashtable
		//    Try
		//        'BAHashTable = ReadRequestFromFile()
		
		//        If Object.Equals(REQUESTTYPE_STRONGASSEMBLY, BAHashTable.Item(FIELD_REQUESTTYPE)) Then
		//            Dim StrongAsmbVAHdlr As New StrongAssemblyVAHandler
		
		//            StrongAsmbVAHdlr.SetDataObjects(RequestData)
		//            RequestData = StrongAsmbVAHdlr.SubmitTransaction(BAHashTable)
		//        Else
		//            Dim WeakAsmbVAHdlr As New WeakAssemblyVAHandler
		//            RequestData = WeakAsmbVAHdlr.DoValidateAuthentication(BAHashTable)
		//        End If
		
		//        Return RequestData
		//    Catch ex As Exception
		//        Throw New Exception(ex.Message)
		//    End Try
		
		//End Function
		
		#endregion
		
	}
}

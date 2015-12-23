Option Explicit On 
Option Strict On

Imports PayPal.Payments.SampleStore.VB.Common
Imports PayPal.Payments.SampleStore.VB.Handler
Imports System
Imports System.Web
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.Common.Logging
Imports System.Reflection

#Region "Copyright"

'Unpublished Proprietary Program Material
'This material is proprietary to PayPal, Inc. and is not to be reproduced, 
'used or disclosed except in accordance with a written license agreement 
'with PayPal, Inc.. 
'(C) Copyright 2005  PayPal, Inc.   All Rights Reserved.
'PayPal, Inc. believes that this material furnished herewith is accurate 
'and reliable.  However, no responsibility, financial or otherwise, can be 
' accepted for any consequences arising out of the use of this material. 

'The copyright notice above does not evidence any actual or intended 
'publication of such source code. 

#End Region

Namespace PayPal.Payments.SampleStore.VB.UI
    ''' -----------------------------------------------------------------------------
    ''' Project	 : SampleStoreVB
    ''' Class	 : Payments.SampleStore.VB.UI.Controller
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     
    ''' This is the controller class for the Samplestore.
    ''' Depending upon the request and the transaction type , 
    ''' appropriate request handlers are called.
    ''' The response obtained is redirected to response page depending on the request 
    ''' type.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Class Controller
        'Dim mContinueFlag As Boolean
        ''' <summary>
        ''' Object of class HttpContext
        ''' </summary>
        Public mHttpContext As System.Web.HttpContext
        ''' <summary>
        ''' Object of class HttpServerUtility
        ''' </summary>
        Public mServer As System.Web.HttpServerUtility

#Region "ProcessRequest"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Check if the request has PARES value present. If yes call the processVAFunction.
        ''' If buyerauth is requested, call ProcessVERequest function and set the 
        ''' mContinueFlag to false. 
        ''' If mContinueFlag is true, check the request type and instantiate the request 
        ''' handlers depending on the request type.
        ''' </summary>
        ''' <param name="RequestData">Hashtable</param>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Sub ProcessRequest(ByVal RequestData As Hashtable)

            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Entered", PayflowConstants.SEVERITY_DEBUG)

            Dim TransResponse As Object
            Dim ResponseTable As New Hashtable
            Try
                'Uncomment the following code for performing Buyer Auth

                'If RequestData.ContainsKey(REQUEST_PARES) Then
                'PARES present
                'RequestData = ProcessVARequest(RequestData, HttpResponse)
                'mContinueFlag = False
                'End If

                'If Object.Equals(FLG_YES, RequestData.Item(FIELD_BAREQUIRED)) Then
                'Buyer Auth requested, do verify enrollment
                'ProcessVERequest(RequestData, HttpResponse)
                'mContinueFlag = False
                'End If

                'If mContinueFlag Then

                If Object.Equals(SampleStoreConstants.REQUESTTYPE_STRONGASSEMBLY, RequestData.Item(SampleStoreConstants.FIELD_REQUESTTYPE)) Then
                    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Executing Strong Assembly Request", PayflowConstants.SEVERITY_INFO)

                    Dim StrongAsmblReqHandler As New StrongAssemblyRequestHandler
                    'TransResponse = StrongAsmblReqHandler.SubmitRequestToHandler(RequestData)
                    ResponseTable = StrongAsmblReqHandler.SubmitRequestToHandler(RequestData)
                    TransResponse = ResponseTable.Item("TRXRESPONSE")

                    mHttpContext.Items.Add(SampleStoreConstants.CONTEXT_RESPONSEOBJECT, TransResponse)
                Else
                    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Executing Weak Assembly Request", PayflowConstants.SEVERITY_INFO)

                    Dim WeakAsmblReqHandler As New WeakAssemblyRequestHandler
                    Dim ResponseVal As String = WeakAsmblReqHandler.SubmitRequestToHandler(RequestData)

                    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : The Request to the Payflow Server : " + RequestData.Item(SampleStoreConstants.FIELD_REQUESTTYPE).ToString, PayflowConstants.SEVERITY_INFO)
                    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : The Response obtained from Payflow Server : " + ResponseVal, PayflowConstants.SEVERITY_INFO)
                    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Exiting", PayflowConstants.SEVERITY_DEBUG)
                    mHttpContext.Items.Add(SampleStoreConstants.CONTEXT_WEAKASSEMBLYRESPONSE, ResponseVal)
                End If
            Catch taex As Threading.ThreadAbortException
                'Do nothing. If removed, throws error during redirecting
                'Catch baex As Exceptions.BaseException
                '   HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & baex.ToString())
            Catch Ex As Exception

                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : In the catch of exception. Following error occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL)
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessRequest(Hashtable, HttpResponse) : Exiting", PayflowConstants.SEVERITY_DEBUG)
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Sub
#End Region

#Region "ProcessVERequest"
        
        'Private Sub ProcessVERequest(ByVal RequestData As Hashtable, ByVal HttpResponse As HttpResponse)

        '    Dim BAHashTable As Hashtable
        '    Try
        '        If Object.Equals(REQUESTTYPE_STRONGASSEMBLY, RequestData.Item(FIELD_REQUESTTYPE)) Then
        '            Dim strongAsmblVEHandler As New StrongAssemblyVEHandler

        '            strongAsmblVEHandler.SetDataObjects(RequestData)
        '            BAHashTable = strongAsmblVEHandler.SubmitTransaction(RequestData, HttpResponse)

        '            ProcessRequest(BAHashTable)
        '        Else
        '            'Dim weakAsmblVEHandler As New WeakAssemblyVEHandler
        '        End If
        '    Catch taex As Threading.ThreadAbortException

        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Sub

#End Region

#Region "ProcessFollowOnRequest"

        
        'Private Sub ProcessFollowOnRequest(ByVal RequestData As Hashtable, ByVal HttpResponse As HttpResponse)

        '    Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessFollowOnRequest : Entered", PayflowConstants.SEVERITY_DEBUG)

        '    'mContinueFlag = True
        '    Dim TransResponse As Object
        '    Try
        '        'If mContinueFlag Then
        '        If Object.Equals(REQUESTTYPE_STRONGASSEMBLY, RequestData.Item(FIELD_REQUESTTYPE)) Then
        '            Dim StrongAsmblReqHandler As New StrongAssemblyRequestHandler
        '            TransResponse = StrongAsmblReqHandler.SubmitRequestToHandler(RequestData)
        '            mHttpContext.Items.Add(CONTEXT_RESPONSEOBJECT, TransResponse)
        '            If TypeOf TransResponse Is Response Then
        '                'Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessFollowOnRequest : The Request to the PFProServer : " + CType(TransResponse, Response).TransactionResult.Request, PayflowConstants.SEVERITY_DEBUG)
        '                'Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessFollowOnRequest : The Response obtained from the PFProServer : " + CType(TransResponse, Response).TransactionResult.Response, PayflowConstants.SEVERITY_DEBUG)
        '                'Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.ProcessFollowOnRequest : Exiting", PayflowConstants.SEVERITY_DEBUG)
        '                'mServer.Transfer(StrongAsmbRespUrl.ToString)
        '            Else
        '                'mHttpContext.Items.Add(CONTEXT_ERRORMESSAGE, "Response Object obtained null")
        '                'mServer.Transfer(ErrorPageUrl.ToString)
        '            End If
        '        Else
        '            Dim WeakAsmblReqHandler As New WeakAssemblyRequestHandler
        '            Dim ResponseVal As String
        '            ResponseVal = WeakAsmblReqHandler.SubmitRequestToHandler(RequestData)
        '            mHttpContext.Items.Add(CONTEXT_WEAKASSEMBLYRESPONSE, ResponseVal)
        '            'mServer.Transfer(WeakAsmbRespUrl.ToString)
        '        End If

        '        'End If

        '    Catch taex As Threading.ThreadAbortException
        '        'Do nothing. If removed, throws error during redirecting
        '        'Catch baex As Exceptions.BaseException
        '        '   HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & baex.ToString())
        '    Catch ex As Exception
        '        HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & ex.Message)
        '    End Try
        'End Sub
#End Region

#Region "Constructor"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constructor for the controller. Accepts the HttpRequest and HttpResponse 
        ''' objects. It puts the request data into a hashtable and calls the ProcessRequest 
        ''' function. Gets the response in form of a string and redirects the Samplestore 
        ''' to the response page
        ''' </summary>
        ''' <param name="HttpRequest"></param>
        ''' <param name="HttpContext"></param>
        ''' <remarks>
        ''' Will be called when the request comes from SampleStore.aspx
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Sub New(ByVal HttpRequest As HttpRequest, ByVal HttpContext As System.Web.HttpContext, ByVal Server As System.Web.HttpServerUtility)

            Dim RequestData As Hashtable
            Dim util As New SampleStore.VB.Common.SampleStoreUtil

            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.New(HttpRequest, HttpResponse) : Entered", PayflowConstants.SEVERITY_DEBUG)

            mHttpContext = HttpContext
            mServer = Server

            RequestData = util.GetHashTableWithRequest(HttpRequest)
            If mHttpContext.Items.Contains(SampleStoreConstants.CONTEXT_REQUESTDATA) Then
                mHttpContext.Items.Remove(SampleStoreConstants.CONTEXT_REQUESTDATA)
            End If
            mHttpContext.Items.Add(SampleStoreConstants.CONTEXT_REQUESTDATA, RequestData)
            ProcessRequest(RequestData)
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.New(HttpRequest, HttpResponse) : Exiting", PayflowConstants.SEVERITY_DEBUG)
        End Sub
#End Region

#Region "ProcessVARequest"
       
        'Private Shared Function ProcessVARequest(ByVal RequestData As Hashtable) As Hashtable

        '    Dim BAHashTable As New Hashtable
        '    Try
        '        'BAHashTable = ReadRequestFromFile()

        '        If Object.Equals(REQUESTTYPE_STRONGASSEMBLY, BAHashTable.Item(FIELD_REQUESTTYPE)) Then
        '            Dim StrongAsmbVAHdlr As New StrongAssemblyVAHandler

        '            StrongAsmbVAHdlr.SetDataObjects(RequestData)
        '            RequestData = StrongAsmbVAHdlr.SubmitTransaction(BAHashTable)
        '        Else
        '            Dim WeakAsmbVAHdlr As New WeakAssemblyVAHandler
        '            RequestData = WeakAsmbVAHdlr.DoValidateAuthentication(BAHashTable)
        '        End If

        '        Return RequestData
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try

        'End Function

#End Region

    End Class
End Namespace
Option Explicit On 
Option Strict On

Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants
Imports PayPal.Payments.Communication
Imports PayPal.Payments.SampleStore.VB.Common
Imports PayPal.Payments.Common.Utility
Imports System.Xml
Imports System.Text
Imports PayPal.Payments.Common.Logging


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

Namespace PayPal.Payments.SampleStore.VB.Handler
    ''' -----------------------------------------------------------------------------
    ''' Project	 : SampleStoreVB
    ''' Class	 : Payments.SampleStore.VB.Handler.WeakAssemblyTransHandler
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Class handler for weak Assembly Transaction
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class WeakAssemblyTransHandler

#Region "SetClientInfo"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function creates a ClientInfo object, sets the data and returns the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Function SetClientInfo(ByVal RequestData As Hashtable) As ClientInfo
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetClientInfo() : Entered", PayflowConstants.SEVERITY_DEBUG)
                Dim ClientInfo As New ClientInfo

                'Set the ClientInfo object fields
                With RequestData

                    If Not (Object.Equals(.Item(FIELD_VIT_INTEGRATION_VERSION), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_VIT_INTEGRATION_VERSION), Nothing)) Then
                        ClientInfo.IntegrationVersion = .Item(FIELD_VIT_INTEGRATION_VERSION).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_VIT_INTEGRATION_PRODUCT), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_VIT_INTEGRATION_PRODUCT), Nothing)) Then
                        ClientInfo.IntegrationProduct = .Item(FIELD_VIT_INTEGRATION_PRODUCT).ToString
                    End If
                End With
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetClientInfo() : Exiting", PayflowConstants.SEVERITY_DEBUG)
                Return ClientInfo

            Catch Ex As Exception
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetClientInfo() : In the catch of exception. Error Occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL)
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Function
#End Region

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  This function calls the SubmitTransaction method, for the
        ''' object of WeakAssemblyTransHandler class,gets the response object and returns the same       ''' 
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns></returns>
        ''' -----------------------------------------------------------------------------
        Public Function SubmitTransaction(ByVal RequestData As Hashtable) As String
            Try
                Dim Response As String
                Dim RequestId As String
                Dim ProxyPort As Integer
                Dim TransactionReqt As String
                RequestId = RequestData.Item(FIELD_REQUESTID).ToString
                If Object.Equals(RequestId, Nothing) Or _
                    Object.Equals(RequestId, EMPTY_STRING) Then
                    RequestId = PayflowUtility.RequestId
                End If

                If Not (Object.Equals(RequestData.Item(FIELD_PROXYPORT), Nothing) Or _
                Object.Equals(RequestData.Item(FIELD_PROXYPORT), EMPTY_STRING)) Then
                    ProxyPort = Integer.Parse(RequestData.Item(FIELD_PROXYPORT).ToString)
                End If

                Dim PayflowNETAPI As New PayflowNETAPI(Nothing, _
                                        0, _
                                        0, _
                                        RequestData.Item(FIELD_PROXYADDRESS).ToString, _
                                        ProxyPort, _
                                        RequestData.Item(FIELD_PROXYLOGON).ToString, _
                                        RequestData.Item(FIELD_PROXYPASSWORD).ToString)

                TransactionReqt = RequestData.Item(FIELD_WEAKASSEMBLYREQUEST).ToString()
                'Dim TransactionHandler As BaseTransactionHandler

                PayflowNETAPI.ClientInfo = SetClientInfo(RequestData)
                Response = PayflowNETAPI.SubmitTransaction(TransactionReqt, _
                                      RequestId)

                Response = Response + "^"

                Return Response

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Function

    End Class

End Namespace

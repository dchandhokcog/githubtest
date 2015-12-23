Option Explicit On 
Option Strict On

Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants
Imports PayPal.Payments.SampleStore.VB.Common
Imports PayPal.Payments.Common.Utility

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
    ''' Project	 : Payflow SDK-SampleStore
    ''' Class	 : Payments.SampleStore.VB.Handler.VoiceAuthHandler
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' This class creates object of VoiceAuthTransaction class, call its 
    ''' SubmitTransaction method, gets the response object and returns the same    ''' 
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Class VoiceAuthHandler
        Inherits BaseTransactionHandler
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function overrides the submittransaction function of the base class.
        ''' This function creates object of VoiceAuthTransaction class, call its 
        ''' SubmitTransaction method, gets the response object and returns the same        ''' 
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns></returns>
        ''' -----------------------------------------------------------------------------
        Public Overrides Function SubmitTransaction(ByVal RequestData As Hashtable) As Hashtable
            Try

                Dim Count As Integer
                Dim RequestId As String
                Dim VoiceAuthTrans As VoiceAuthTransaction
                Dim ResponseTable As New Hashtable

                RequestId = RequestData.Item(FIELD_REQUESTID).ToString
                If Object.Equals(RequestId, Nothing) Or _
                    Object.Equals(RequestId, EMPTY_STRING) Then
                    RequestId = PayflowUtility.RequestId
                End If

                VoiceAuthTrans = New VoiceAuthTransaction(RequestData.Item(FIELD_AUTHCODE).ToString, _
                                                                UserInfo, _
                                                                PayflowConnectionData, _
                                                                Invoice, _
                                                                Tender, _
                                                                RequestId)

                For Count = 0 To ExtDataList.Count - 1
                    VoiceAuthTrans.AddToExtendData(CType(ExtDataList(Count), ExtendData))
                Next

                Dim Verbosity As String = RequestData.Item(FIELD_VERBOSITY).ToString
                If Not (Object.Equals(Verbosity, Nothing) Or _
                    Verbosity.Length = 0) Then
                    VoiceAuthTrans.Verbosity = RequestData.Item(FIELD_VERBOSITY).ToString
                End If

                VoiceAuthTrans.ClientInfo = ClientInfo
                VoiceAuthTrans.SubmitTransaction()
                ResponseTable.Add("TRXRESPONSE", VoiceAuthTrans.Response())

                Return ResponseTable

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try
        End Function
    End Class
End Namespace
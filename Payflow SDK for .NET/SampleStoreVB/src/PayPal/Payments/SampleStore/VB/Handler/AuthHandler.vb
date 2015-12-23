Option Explicit On 
Option Strict On

Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions
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
    ''' Project	 : SampleStoreVB
    ''' Class	 : Payments.SampleStore.VB.Handler.AuthHandler
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' This class overrides the submittransaction function of the base class.
    ''' This class creates object of AuthorizationTransaction class, call its 
    ''' SubmitTransaction method, gets the response object and returns the same
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Class AuthHandler
        Inherits BaseTransactionHandler
#Region "SubmitTransaction"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function creates object of AuthorizationTransaction class, call its 
        ''' SubmitTransaction method, gets the response object and returns the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Public Overrides Function SubmitTransaction(ByVal RequestData As Hashtable) As Hashtable
            Try
                Dim AuthTrans As AuthorizationTransaction
                Dim Count As Integer
                Dim RequestId As String
                Dim ResponseTable As New Hashtable

                RequestId = RequestData.Item(SampleStoreConstants.FIELD_REQUESTID).ToString

                If Object.Equals(RequestId, Nothing) Or _
                    Object.Equals(RequestId, SampleStoreConstants.EMPTY_STRING) Then
                    RequestId = PayflowUtility.RequestId
                End If

                AuthTrans = New AuthorizationTransaction(UserInfo, _
                                                                PayflowConnectionData, _
                                                                Invoice, _
                                                                Tender, _
                                                                RequestId)

                For Count = 0 To ExtDataList.Count - 1
                    AuthTrans.AddToExtendData(CType(ExtDataList(Count), ExtendData))
                Next

                Dim Verbosity As String = RequestData.Item(SampleStoreConstants.FIELD_VERBOSITY).ToString
                If Not (Object.Equals(Verbosity, Nothing) Or _
                    Verbosity.Length = 0) Then
                    AuthTrans.Verbosity = RequestData.Item(SampleStoreConstants.FIELD_VERBOSITY).ToString
                End If

                Dim OrigId As String = RequestData.Item(SampleStoreConstants.FIELD_ORIGID).ToString
                If Not (Object.Equals(OrigId, Nothing) Or _
                    OrigId.Length = 0) Then
                    AuthTrans.OrigId = RequestData.Item(SampleStoreConstants.FIELD_ORIGID).ToString
                End If

                AuthTrans.ClientInfo = ClientInfo

                AuthTrans.SubmitTransaction()
                ResponseTable.Add("TRXRESPONSE", AuthTrans.Response())

                Return ResponseTable

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Function
#End Region

    End Class
End Namespace

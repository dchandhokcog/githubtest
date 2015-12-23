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
    ''' <summary>
    ''' This class creates object of RecurringTransaction class, call its 
    ''' SubmitTransaction method, gets the response object and returns the same
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------

    Public Class RecurringHandler
        Inherits BaseTransactionHandler
        Dim RecurringInfo As RecurringInfo
#Region "SubmitTransaction"
        ''' <summary>
        ''' This function overrides the submittransaction function of the base class.
        ''' This function creates object of RecurringTransaction class, call its 
        ''' SubmitTransaction method, gets the response object and returns the same
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Public Overrides Function SubmitTransaction(ByVal RequestData As Hashtable) As Hashtable

            Dim RecurringTrans As RecurringTransaction
            Dim RequestId As String
            Dim Count As Integer
            Dim ResponseTable As New Hashtable

            RequestId = RequestData.Item(SampleStoreConstants.FIELD_REQUESTID).ToString
            If Object.Equals(RequestId, Nothing) Or _
                Object.Equals(RequestId, SampleStoreConstants.EMPTY_STRING) Then
                RequestId = PayflowUtility.RequestId
            End If

            Select Case (RequestData.Item(SampleStoreConstants.FIELD_ACTION)).ToString
                Case SampleStoreConstants.ACTION_ADD
                    RecurringTrans = New RecurringAddTransaction(UserInfo, _
                                                                 PayflowConnectionData, _
                                                                 Invoice, _
                                                                 Tender, _
                                                                 RecurringInfo, _
                                                                 RequestId)
                Case SampleStoreConstants.ACTION_MODIFY
                    'RecurringTrans = New RecurringModifyTransaction(UserInfo, PayflowConnectionData, RecurringInfo)
                    RecurringTrans = New RecurringModifyTransaction(UserInfo, _
                                                                    PayflowConnectionData, _
                                                                    RecurringInfo, _
                                                                    Invoice, _
                                                                    Tender, _
                                                                    RequestId)
                Case SampleStoreConstants.ACTION_CANCEL
                    RecurringTrans = New RecurringCancelTransaction(UserInfo, _
                                                                    PayflowConnectionData, _
                                                                    RecurringInfo, _
                                                                    RequestId)
                Case SampleStoreConstants.ACTION_INQUIRY
                    RecurringTrans = New RecurringInquiryTransaction(UserInfo, _
                                                                        PayflowConnectionData, _
                                                                        RecurringInfo, _
                                                                        RequestId)
                Case SampleStoreConstants.ACTION_PAYMENT
                    RecurringTrans = New RecurringPaymentTransaction(UserInfo, _
                                                                        PayflowConnectionData, _
                                                                        RecurringInfo, _
                                                                        Invoice, _
                                                                        RequestId)
                Case SampleStoreConstants.ACTION_REACTIVTE
                    'RecurringTrans = New RecurringReActivateTransaction(UserInfo, PayflowConnectionData, RecurringInfo)
                    RecurringTrans = New RecurringReActivateTransaction(UserInfo, _
                                                                        PayflowConnectionData, _
                                                                        RecurringInfo, _
                                                                        Invoice, _
                                                                        Tender, _
                                                                        RequestId)
                Case Else
                    RecurringTrans = Nothing
            End Select


            For Count = 0 To ExtDataList.Count - 1
                RecurringTrans.AddToExtendData(CType(ExtDataList(Count), ExtendData))
            Next

            Dim Verbosity As String = RequestData.Item(SampleStoreConstants.FIELD_VERBOSITY).ToString
            If Not (Object.Equals(Verbosity, Nothing) Or _
                Verbosity.Length = 0) Then
                RecurringTrans.Verbosity = RequestData.Item(SampleStoreConstants.FIELD_VERBOSITY).ToString
            End If
            RecurringTrans.ClientInfo = ClientInfo
            RecurringTrans.SubmitTransaction()
            ResponseTable.Add("TRXRESPONSE", RecurringTrans.Response())

            Return ResponseTable


        End Function

#End Region

#Region "SetDataObjects"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function overrides the SetDataObjects function of the base class.
        ''' The function sets the RecurringInfo object which is passed in the constructor
        ''' of the RecurringTransaction
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Overrides Sub SetDataObjects(ByVal RequestData As Hashtable)

            Try
                RecurringInfo = New RecurringInfo
                Dim Util As New SampleStore.VB.Common.SampleStoreUtil

                With RequestData


                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_OPTIONALTRXTYPE), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.OptionalTrx = .Item(SampleStoreConstants.FIELD_OPTIONALTRXTYPE).ToString
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_ORIGPROFILEID), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.OrigProfileId = .Item(SampleStoreConstants.FIELD_ORIGPROFILEID).ToString
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_PAYMENTHISTORY), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.PaymentHistory = .Item(SampleStoreConstants.FIELD_PAYMENTHISTORY).ToString
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_PAYMENTNUM), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.PaymentNum = .Item(SampleStoreConstants.FIELD_PAYMENTNUM).ToString
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_PAYPERIOD), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.PayPeriod = .Item(SampleStoreConstants.FIELD_PAYPERIOD).ToString
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_PROFILENAME), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.ProfileName = .Item(SampleStoreConstants.FIELD_PROFILENAME).ToString
                    End If



                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_MAXFAILPAYMENTS), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.MaxFailPayments = CType(.Item(SampleStoreConstants.FIELD_MAXFAILPAYMENTS), Long)
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_OPTIONALTRXAMT), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.OptionalTrxAmt = Util.GetCurrencyFromString(.Item(SampleStoreConstants.FIELD_OPTIONALTRXAMT).ToString)
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_RETRYNUMDAYS), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.RetryNumDays = CType(.Item(SampleStoreConstants.FIELD_RETRYNUMDAYS), Long)
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_RECURRINGSTARTDATE), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.Start = (.Item(SampleStoreConstants.FIELD_RECURRINGSTARTDATE).ToString)
                    End If

                    If Not Object.Equals(.Item(SampleStoreConstants.FIELD_TERM), SampleStoreConstants.EMPTY_STRING) Then
                        RecurringInfo.Term = CType(.Item(SampleStoreConstants.FIELD_TERM), Long)
                    End If

                End With

                MyBase.SetDataObjects(RequestData)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Sub

#End Region
    End Class
End Namespace

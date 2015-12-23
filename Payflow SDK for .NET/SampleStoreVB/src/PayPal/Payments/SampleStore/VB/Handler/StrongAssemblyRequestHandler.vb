Option Explicit On 
Option Strict On

Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants
Imports PayPal.Payments.Common.Logging
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
    ''' <summary>
    ''' This class redirects the request of different transaction handlers depending on the 
    ''' transaction type requested
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Class StrongAssemblyRequestHandler
#Region "SubmitRequestToHandler"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function creates the object of the ITransactionHandler interface and assigns the 
        ''' same to the object of the handler that is instantiated depending on the transaction
        ''' type. The SetDataObject function of the handlers is called for setting the 
        ''' data objects. The response object is obtained after calling the submittransaction 
        ''' of the handler which is returned from the function.
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>Response</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Function SubmitRequestToHandler(ByVal RequestData As Hashtable) As Hashtable

            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)

            'Dim ResponseVal As Object
            Dim ResponseVal As Hashtable
            Dim ITransactionHandlerObj As ITransactionHandler
            ITransactionHandlerObj = Nothing
            Try
                Select Case (RequestData.Item(FIELD_TRXTYPE)).ToString
                    Case TRXTYPE_AUTH
                        ITransactionHandlerObj = New AuthHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of AuthHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_CAPTURE
                        ITransactionHandlerObj = New CaptureHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of CaptureHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_CREDIT
                        ITransactionHandlerObj = New CreditHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of CreditHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_SALE
                        ITransactionHandlerObj = New SaleHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of SaleHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_INQUIRY
                        ITransactionHandlerObj = New InquiryHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of InquiryHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_VOID
                        ITransactionHandlerObj = New VoidHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of VoidHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_VOICEAUTH
                        ITransactionHandlerObj = New VoiceAuthHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of VoiceAuthHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_RECURRING
                        ITransactionHandlerObj = New RecurringHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of RecurringHandler", PayflowConstants.SEVERITY_INFO)
                    Case TRXTYPE_RMSREVIEW
                        ITransactionHandlerObj = New FraudReviewHandler
                        Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Created Object of FraudReviewHandler", PayflowConstants.SEVERITY_INFO)
                End Select

                If Object.Equals(ITransactionHandlerObj, Nothing) Then
                    ResponseVal = Nothing
                Else
                    ITransactionHandlerObj.SetDataObjects(RequestData)

                    ResponseVal = ITransactionHandlerObj.SubmitTransaction(RequestData)
                End If

                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SubmitRequestToHandler(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)
                Return ResponseVal

            Catch ex As Exception
                Throw New Exception(ex.Message, ex)
            End Try

        End Function

#End Region
    End Class
End Namespace

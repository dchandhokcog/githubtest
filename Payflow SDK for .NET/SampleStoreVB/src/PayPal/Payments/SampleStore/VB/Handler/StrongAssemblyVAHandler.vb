Option Explicit On 
Option Strict On

Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

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
    ''' This class processes the Validate Authentication transaction for Strong assembly 
    ''' request.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Class StrongAssemblyVAHandler
        Inherits BuyerAuthHandler

#Region "SubmitTransaction"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Function calls the SubmitTransaction method of the BuyerAuthVATransaction class
        ''' and gets the BuyerAuthResponse object. The function pupulates the response in 
        ''' the hashtable and returns the same.
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Shadows Function SubmitTransaction(ByVal RequestData As Hashtable) As Hashtable
            'Dim BAVARequest As New BuyerAuthVATransaction(UserInfo, _
            '                                              PayflowConnectionData, _
            '                                            RequestData.Item(REQUEST_PARES).ToString)
            'Dim BAResponse As Response
            'Dim Status As Boolean

            'Status = BAVARequest.SubmitTransaction()
            'BAResponse = BAVARequest.Response

            'Get the response after Validate Authentication, set the same in the RequestData
            'and return the hashtable

            'RequestData.Item(BAS_RESP_AUTHID_KEY) = BAResponse.
            'RequestData.Item(BAS_RESP_AUTHSTATUS_KEY) = BAResponse.
            'RequestData.Item(BAS_RESP_CAVV_KEY) = BAResponse.
            'RequestData.Item(BAS_RESP_ECI_KEY) = BAResponse.
            'RequestData.Item(BAS_RESP_XID_KEY) = BAResponse.

            'Set the Buyer Auth required flag to N so that the code for Verify Enrollment is
            'not run in the ProcessRequest function of the controller

            RequestData.Item(FIELD_BAREQUIRED) = FLG_NO

            Return RequestData
        End Function
#End Region

    End Class
End Namespace

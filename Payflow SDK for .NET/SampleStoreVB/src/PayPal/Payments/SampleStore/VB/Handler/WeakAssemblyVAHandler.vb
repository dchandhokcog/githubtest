Option Explicit On 
Option Strict On

Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants


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
    ''' Class	 : Payments.SampleStore.VB.Handler.WeakAssemblyVAHandler
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Handler for Weak Assmebly VA
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class WeakAssemblyVAHandler

        Public Function DoValidateAuthentication(ByVal RequestData As Hashtable) As Hashtable
            'Dim ObjPayflow API As New Payflow API
            Dim StrRequest As String
            'Dim StrResponse As String
            StrRequest = RequestData.Item(FIELD_WEAKASSEMBLYREQUEST).ToString
            'ObjPayflow API.CreateContext()
            'StrResponse = ObjPayflow API.SubmitTransaction(StrRequest)
            'ObjPayflow API.DestroyContext()
            'RequestData.Item(FIELD_WEAKASSEMBLYRESPONSE) = StrResponse
            Return RequestData
        End Function
    End Class
End Namespace

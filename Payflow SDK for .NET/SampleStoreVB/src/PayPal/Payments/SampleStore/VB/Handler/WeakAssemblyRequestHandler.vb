Option Explicit On 
Option Strict On

Imports PayPal.Payments.DataObjects

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
    ''' Class	 : Payments.SampleStore.VB.Handler.WeakAssemblyRequestHandler
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' This function creates object of WeakAssemblyTransHandler class
    ''' and passes to WeakAssemblyTransHandler class
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class WeakAssemblyRequestHandler
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function creates object of WeakAssemblyTransHandler class 
        ''' and passes to WeakAssemblyTransHandler class '''  
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns></returns>
        ''' -----------------------------------------------------------------------------
        Public Function SubmitRequestToHandler(ByVal RequestData As Hashtable) As String

            Dim Response As String

            Dim WeakAssemblyHdlr As New WeakAssemblyTransHandler
            Response = WeakAssemblyHdlr.SubmitTransaction(RequestData)

            Return Response
        End Function
    End Class
End Namespace


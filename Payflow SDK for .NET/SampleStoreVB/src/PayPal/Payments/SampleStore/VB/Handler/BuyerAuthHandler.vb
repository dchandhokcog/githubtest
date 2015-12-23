Imports PayPal.Payments.SampleStore.VB.Handler
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreProperties
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
    ''' This is the base class for the Strong and Weak Assembly VE and VA handlers
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Class BuyerAuthHandler
        Implements ITransactionHandler
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public UserInfo As UserInfo
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' 
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public PayflowConnectionData As PayflowConnectionData
#Region "SetDataObjects"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the data objects that will be passed in the constructor
        ''' of BuyerAuthVETransaction and BuyerAuthVATransaction
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Overridable Sub SetDataObjects(ByVal RequestData As System.Collections.Hashtable) Implements Handler.ITransactionHandler.SetDataObjects

            UserInfo = SetUserInfo(RequestData.Item(FIELD_USER).ToString, _
                                    RequestData.Item(FIELD_VENDOR).ToString, _
                                    RequestData.Item(FIELD_PARTNER).ToString, _
                                    RequestData.Item(FIELD_PASSWORD).ToString)

            PayflowConnectionData = SetPayflowConnectionData()

        End Sub

#End Region

#Region "SetUserInfo"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the User, Vendor , Partner , Password from the properties 
        ''' in the UserInfo object and returns the same
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Function SetUserInfo(ByVal User As String, ByVal Vendor As String, ByVal Partner As String, ByVal Password As String) As UserInfo

            UserInfo = New UserInfo(User, _
                                    Vendor, _
                                    Partner, _
                                    Password)
            Return UserInfo

        End Function
#End Region

#Region "SetPayflowConnectionData"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the connection params from the properties in the 
        ''' Payflow Connection object and returns the same
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Function SetPayflowConnectionData() As PayflowConnectionData
            PayflowConnectionData = New PayflowConnectionData(HostAddress)
            Return PayflowConnectionData
        End Function
#End Region

#Region "SubmitTransaction"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This is the SubmitTransatcion function that will be overridden by the base 
        ''' classes with their own implementatin
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Public Overridable Function SubmitTransaction(ByVal RequestData As System.Collections.Hashtable) As Hashtable Implements Handler.ITransactionHandler.SubmitTransaction

            Return Nothing
        End Function
#End Region
    End Class

End Namespace

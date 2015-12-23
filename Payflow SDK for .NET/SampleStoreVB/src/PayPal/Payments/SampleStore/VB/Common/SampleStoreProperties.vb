Option Explicit On 
Option Strict On
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



Namespace PayPal.Payments.SampleStore.VB.Common
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' This class consists of the properties that will be used by the SampleStore 
    ''' application
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------
    Public Class SampleStoreProperties

        'public shared ReadOnly Property TermUrl() As String
        'Get
        'Return PayflowUtility.AppSettings(PROP_TERMURL)
        'End Get
        'End Property


        'public shared ReadOnly Property SampleStoreUrl() As String
        'Get
        'Return PayflowUtility.AppSettings(PROP_URL_SAMPLESTOREURL)
        'End Get
        'End Property

        'public shared ReadOnly Property RedirectToACSServerUrl() As String
        'Get
        'Return PayflowUtility.AppSettings(PROP_URL_REDIRECTTOACSSERVER)
        'End Get
        'End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' public shared ReadOnly Property for getting HostAddress
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly Property HostAddress() As String
            Get
                Return PayflowUtility.AppSettings(SampleStoreConstants.PROP_HOSTADDRESS)
            End Get
        End Property
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' public shared ReadOnly Property for getting HostPort
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly Property HostPort() As String
            Get
                Return Nothing
            End Get
        End Property
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' public shared ReadOnly Property for getting HostTimeout
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly Property HostTimeout() As String
            Get
                Return Nothing
            End Get
        End Property

        ''' ----------------------------------------------------------------------------
        ''' <summary>
        ''' public shared ReadOnly Property for getting ErrorPageUrl
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly Property ErrorPageUrl() As String
            Get
                Return PayflowUtility.AppSettings(SampleStoreConstants.PROP_URL_ERRORPAGEURL)
            End Get
        End Property
    End Class

End Namespace

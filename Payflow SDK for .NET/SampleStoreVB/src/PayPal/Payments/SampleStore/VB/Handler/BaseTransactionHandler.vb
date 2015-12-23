Option Explicit On 
Option Strict On

Imports System.Collections
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreProperties
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreUtil
Imports System.Globalization
Imports PayPal.Payments.Common.Logging
Imports PayPal.Payments.DataObjects
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
    ''' This is the base class for the following transaction handlers.
    ''' 
    ''' AuthHandler
    ''' CaptureHandler
    ''' SaleHandler
    ''' InquiryHandler
    ''' CreditHandler
    ''' VoiceAuthHandler
    ''' VoidHandler
    ''' RecurringHandler
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------

    Public Class BaseTransactionHandler
        Implements ITransactionHandler
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Object of class UserInfo
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public UserInfo As UserInfo
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Object of class PayflowConnectionData
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public PayflowConnectionData As PayflowConnectionData
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Object of class Invoice
        ''' </summary>
        '''-----------------------------------------------------------------
        Public Invoice As Invoice
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Object of class BaseTender
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Tender As BaseTender
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Object of class PaymentDevice
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public PaymentDevice As PaymentDevice
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Arraylist to store extended data feilds
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public ExtDataList As ArrayList
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String for invalid values
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public InvalidFieldList As String = ""
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Object of class ClientInfo
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public ClientInfo As ClientInfo


#Region "SetDataObjects"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This class sets the data in the data objects that will be passed in the 
        ''' constructors of the Transaction objects.
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Overridable Sub SetDataObjects(ByVal RequestData As Hashtable) Implements ITransactionHandler.SetDataObjects
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetDataObjects(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)
                InvalidFieldList = ""
                Dim ProxyPort As Integer
                If (Object.Equals(RequestData.Item(FIELD_PROXYPORT).ToString, Nothing) Or _
                Object.Equals(RequestData.Item(FIELD_PROXYPORT).ToString, EMPTY_STRING)) Then
                    ProxyPort = 0
                Else
                    ProxyPort = Integer.Parse(RequestData.Item(FIELD_PROXYPORT).ToString)
                End If
                UserInfo = SetUserInfo(RequestData.Item(FIELD_USER).ToString, _
                                        RequestData.Item(FIELD_VENDOR).ToString, _
                                        RequestData.Item(FIELD_PARTNER).ToString, _
                                        RequestData.Item(FIELD_PASSWORD).ToString)

                PayflowConnectionData = SetPayflowConnectionData(RequestData.Item(FIELD_PROXYADDRESS).ToString, _
                                                                ProxyPort, _
                                                                RequestData.Item(FIELD_PROXYLOGON).ToString, _
                                                                RequestData.Item(FIELD_PROXYPASSWORD).ToString)

                Invoice = SetInvoice(RequestData)
                ExtDataList = SetExtendData(RequestData)
                Tender = SetTender(RequestData)
                ClientInfo = SetClientInfo(RequestData)
                If InvalidFieldList.Length() > 0 Then
                    Throw New Exception("The following fields have invalid values:<br>" + InvalidFieldList)
                End If
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetDataObjects(HashTable) : Exiting", PayflowConstants.SEVERITY_DEBUG)

            Catch Ex As Exception
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Sub
#End Region

#Region "SetUserInfo"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the Use, Vendor, Partner, Password from the properties 
        ''' into the UserInfo data object.
        ''' </summary>
        ''' <returns>UserInfo</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Private Function SetUserInfo(ByVal UserParam As String, _
                                     ByVal VendorParam As String, _
                                     ByVal PartnerParam As String, _
                                     ByVal PasswordParam As String) As UserInfo

            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetUserInfo(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG)

                Logger.Instance.Log("Values Passed to the function : ", PayflowConstants.SEVERITY_INFO)

                Logger.Instance.Log("User : " + UserParam, PayflowConstants.SEVERITY_INFO)
                Logger.Instance.Log("Vendor : " + VendorParam, PayflowConstants.SEVERITY_INFO)
                Logger.Instance.Log("Partner : " + PartnerParam, PayflowConstants.SEVERITY_INFO)


                UserInfo = New UserInfo(UserParam, _
                        VendorParam, _
                        PartnerParam, _
                        PasswordParam)

                Return UserInfo

            Catch Ex As Exception
                Throw New Exception(Ex.Message, Ex)
            End Try

        End Function

#End Region

#Region "SetPayflowConnectionData"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the connection data form the properties in the 
        ''' PayflowConnectionData object and returns the same
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Function SetPayflowConnectionData(ByVal ProxyAddress As String, ByVal ProxyPort As Integer, ByVal ProxyLogon As String, ByVal ProxyPassword As String) As PayflowConnectionData
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetPayflowConnectionData() : Entered", PayflowConstants.SEVERITY_DEBUG)
                PayflowConnectionData = New PayflowConnectionData(Nothing, _
                                                                0, _
                                                                0, _
                                                                ProxyAddress, _
                                                                ProxyPort, _
                                                                ProxyLogon, _
                                                                ProxyPassword)

                Logger.Instance.Log("PayflowConnectionData object created with following values :", PayflowConstants.SEVERITY_INFO)
                Logger.Instance.Log("HostAddress : " + HostAddress, PayflowConstants.SEVERITY_INFO)
                Logger.Instance.Log("HostPort : " + HostPort, PayflowConstants.SEVERITY_INFO)
                Logger.Instance.Log("HostTimeout : " + HostTimeout, PayflowConstants.SEVERITY_INFO)

                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetPayflowConnectionData() : Exiting", PayflowConstants.SEVERITY_DEBUG)
                Return PayflowConnectionData

            Catch Ex As Exception
                Logger.Instance.Log("PayPal.ayments.SampleStore.VB.Handler.SetPayflowConnectionData() : In the catch of exception. Error Occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL)
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Function

#End Region

#Region "SetInvoice"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function creates an Invoice object, sets the data and returns the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>Invoice</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Function SetInvoice(ByVal RequestData As Hashtable) As Invoice
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetInvoice() : Entered", PayflowConstants.SEVERITY_DEBUG)
                Dim Invoice As New Invoice
                Dim Util As New SampleStore.VB.Common.SampleStoreUtil

                'Set the BillTo Data
                Invoice.BillTo = SetBillTo(RequestData)
                'Set the ShipTo Data
                Invoice.ShipTo = SetShipTo(RequestData)

                'Set the Browser Info
                Invoice.BrowserInfo = SetBrowserInfo(RequestData)

                'Set the Customer Info
                Invoice.CustomerInfo = SetCustomerInfo(RequestData)

                'Set the line item data
                Invoice = SetLineItemData(RequestData, Invoice)

                'Set the Invoice object fields
                With RequestData
                    If Not (Object.Equals(.Item(FIELD_ALTTAXAMT), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_ALTTAXAMT), Nothing)) Then
                        Try
                            Invoice.AltTaxAmt = Util.GetCurrencyFromString(.Item(FIELD_ALTTAXAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "ALTTAXAMT <br>"
                        End Try
                    End If
                    If Not (Object.Equals(.Item(FIELD_AMT), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_AMT), Nothing)) Then
                        Try
                            Invoice.Amt = Util.GetCurrencyFromString(.Item(FIELD_AMT).ToString)
                            Invoice.Amt.Round = True
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "AMT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_COMMENT1), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_COMMENT1), Nothing)) Then
                        Invoice.Comment1 = .Item(FIELD_COMMENT1).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_COMMENT2), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_COMMENT2), Nothing)) Then
                        Invoice.Comment2 = .Item(FIELD_COMMENT2).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_CUSTREF), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_CUSTREF), Nothing)) Then
                        Invoice.CustRef = .Item(FIELD_CUSTREF).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_TAXEXEMPT), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_TAXEXEMPT), Nothing)) Then
                        Invoice.TaxExempt = .Item(FIELD_TAXEXEMPT).ToString
                    End If


                    If Not (Object.Equals(.Item(FIELD_DESC), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_DESC), Nothing)) Then
                        Invoice.Desc = .Item(FIELD_DESC).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_DESC1), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_DESC1), Nothing)) Then
                        Invoice.Desc1 = .Item(FIELD_DESC1).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_DESC2), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_DESC2), Nothing)) Then
                        Invoice.Desc2 = .Item(FIELD_DESC2).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_DESC3), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_DESC3), Nothing)) Then
                        Invoice.Desc3 = .Item(FIELD_DESC3).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_DESC4), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_DESC4), Nothing)) Then
                        Invoice.Desc4 = .Item(FIELD_DESC4).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_ORDERDATE), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_ORDERDATE), Nothing)) Then
                        Invoice.OrderDate = .Item(FIELD_ORDERDATE).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_ORDERTIME), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_ORDERTIME), Nothing)) Then
                        Invoice.OrderTime = .Item(FIELD_ORDERTIME).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_DISCOUNT), EMPTY_STRING) Or _
                    Object.Equals(.Item(FIELD_DISCOUNT), Nothing)) Then
                        Try
                            Invoice.Discount = Util.GetCurrencyFromString(.Item(FIELD_DISCOUNT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "DISCOUNT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_DUTYAMT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_DUTYAMT), Nothing)) Then
                        Try
                            Invoice.DutyAmt = Util.GetCurrencyFromString(.Item(FIELD_DUTYAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "DUTYAMT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_ENDTIME), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_ENDTIME), Nothing)) Then
                        Try
                            Invoice.EndTime = .Item(FIELD_ENDTIME).ToString
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "ENDTIME <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_FREIGHTAMT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_FREIGHTAMT), Nothing)) Then
                        Try
                            Invoice.FreightAmt = Util.GetCurrencyFromString(.Item(FIELD_FREIGHTAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "FREIGHTAMT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_HANDLINGAMT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_HANDLINGAMT), Nothing)) Then
                        Try
                            Invoice.HandlingAmt = Util.GetCurrencyFromString(.Item(FIELD_HANDLINGAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "HANDLINGAMT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_INVNUM), EMPTY_STRING) Or _
                        Object.Equals(.Item(FIELD_INVNUM), Nothing)) Then
                        Invoice.InvNum = .Item(FIELD_INVNUM).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_INVOICEDATE), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_INVOICEDATE), Nothing)) Then
                        Try
                            Invoice.InvoiceDate = (.Item(FIELD_INVOICEDATE).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "INVOICEDATE <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_LOCALTAXAMT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_LOCALTAXAMT), Nothing)) Then
                        Try
                            Invoice.LocalTaxAmt = Util.GetCurrencyFromString(.Item(FIELD_LOCALTAXAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "LOCALTAXAMT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_NATIONALTAXAMT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_NATIONALTAXAMT), Nothing)) Then
                        Try
                            Invoice.NationalTaxAmt = Util.GetCurrencyFromString(.Item(FIELD_NATIONALTAXAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "NATIONALTAXAMT <br>"
                        End Try
                    End If


                    If Not (Object.Equals(.Item(FIELD_PONUM), EMPTY_STRING) Or _
                        Object.Equals(.Item(FIELD_PONUM), Nothing)) Then
                        Invoice.PoNum = .Item(FIELD_PONUM).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_STARTTIME), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_STARTTIME), Nothing)) Then
                        Try
                            Invoice.StartTime = (.Item(FIELD_STARTTIME).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "STARTTIME <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_TAXAMT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_TAXAMT), Nothing)) Then
                        Try
                            Invoice.TaxAmt = Util.GetCurrencyFromString(.Item(FIELD_TAXAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "TAXAMT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_VATREGNUM), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_VATREGNUM), Nothing)) Then
                        Invoice.VatRegNum = .Item(FIELD_VATREGNUM).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_VATTAXAMT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_VATTAXAMT), Nothing)) Then
                        Try
                            Invoice.VatTaxAmt = Util.GetCurrencyFromString(.Item(FIELD_VATTAXAMT).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "VATTAXAMT <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_VATAXPERCENT), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_VATAXPERCENT), Nothing)) Then
                        Invoice.VaTaxPercent = .Item(FIELD_VATAXPERCENT).ToString
                    End If
                    'addition of new params 6/5/05-prajkta
                    If Not (Object.Equals(.Item(FIELD_COMMCODE), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_COMMCODE), Nothing)) Then
                        Invoice.CommCode = .Item(FIELD_COMMCODE).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_MERCHDESCR), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_MERCHDESCR), Nothing)) Then
                        Invoice.MerchDescr = .Item(FIELD_MERCHDESCR).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_MERCHSVC), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_MERCHSVC), Nothing)) Then
                        Invoice.MerchSvc = .Item(FIELD_MERCHSVC).ToString
                    End If

                End With

                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetInvoice() : Exiting", PayflowConstants.SEVERITY_DEBUG)
                Return Invoice

            Catch Ex As Exception
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Handler.SetInvoice() : In the catch of exception. Error Occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL)
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Function

#End Region

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

#Region "SetBillTo"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the BillTo details in the BillTo object and returns the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>BillTo</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Shared Function SetBillTo(ByVal RequestData As Hashtable) As BillTo
            Dim BillToData As New BillTo
            With RequestData
                If Not (Object.Equals(.Item(FIELD_CITY), Nothing) Or _
                        Object.Equals(.Item(FIELD_CITY), EMPTY_STRING)) Then
                    BillToData.City = .Item(FIELD_CITY).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_BILLTOCOUNTRY), Nothing) Or _
                        Object.Equals(.Item(FIELD_BILLTOCOUNTRY), EMPTY_STRING)) Then
                    BillToData.BillToCountry = .Item(FIELD_BILLTOCOUNTRY).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_EMAIL), Nothing) Or _
                        Object.Equals(.Item(FIELD_EMAIL), EMPTY_STRING)) Then
                    BillToData.Email = .Item(FIELD_EMAIL).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_FAX), Nothing) Or _
        Object.Equals(.Item(FIELD_FAX), EMPTY_STRING)) Then
                    BillToData.Fax = .Item(FIELD_FAX).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_FIRSTNAME), Nothing) Or _
        Object.Equals(.Item(FIELD_FIRSTNAME), EMPTY_STRING)) Then
                    BillToData.FirstName = .Item(FIELD_FIRSTNAME).ToString

                End If
                If Not (Object.Equals(.Item(FIELD_LASTNAME), Nothing) Or _
        Object.Equals(.Item(FIELD_LASTNAME), EMPTY_STRING)) Then
                    BillToData.LastName = .Item(FIELD_LASTNAME).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_MIDDLENAME), Nothing) Or _
        Object.Equals(.Item(FIELD_MIDDLENAME), EMPTY_STRING)) Then
                    BillToData.MiddleName = .Item(FIELD_MIDDLENAME).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_BILLTOPHONE2), Nothing) Or _
        Object.Equals(.Item(FIELD_BILLTOPHONE2), EMPTY_STRING)) Then
                    BillToData.BillToPhone2 = .Item(FIELD_BILLTOPHONE2).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_PHONENUM), Nothing) Or _
        Object.Equals(.Item(FIELD_PHONENUM), EMPTY_STRING)) Then
                    BillToData.PhoneNum = .Item(FIELD_PHONENUM).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_STATE), Nothing) Or _
        Object.Equals(.Item(FIELD_STATE), EMPTY_STRING)) Then
                    BillToData.State = .Item(FIELD_STATE).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_STREET), Nothing) Or _
        Object.Equals(.Item(FIELD_STREET), EMPTY_STRING)) Then
                    BillToData.Street = .Item(FIELD_STREET).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_BILLTOSTREET2), Nothing) Or _
        Object.Equals(.Item(FIELD_BILLTOSTREET2), EMPTY_STRING)) Then
                    BillToData.BillToStreet2 = .Item(FIELD_BILLTOSTREET2).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_ZIP), Nothing) Or _
        Object.Equals(.Item(FIELD_ZIP), EMPTY_STRING)) Then
                    BillToData.Zip = .Item(FIELD_ZIP).ToString
                End If

                'additional params 6/5/05 prajkta
                If Not (Object.Equals(.Item(FIELD_BILLHOMEPHONE), Nothing) Or _
       Object.Equals(.Item(FIELD_BILLHOMEPHONE), EMPTY_STRING)) Then
                    BillToData.HomePhone = .Item(FIELD_BILLHOMEPHONE).ToString
                End If

                ' moved from CustomerInfo 04/07/07 tsieber
                If Not (Object.Equals(RequestData.Item(FIELD_COMPANYNAME), Nothing) Or _
                        Object.Equals(RequestData.Item(FIELD_COMPANYNAME), EMPTY_STRING)) Then
                    BillToData.CompanyName = RequestData.Item(FIELD_COMPANYNAME).ToString
                End If

            End With
            Return BillToData
        End Function

#End Region

#Region "SetShipTo"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the ShipTo details in the ShipTo object and returns the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>ShipTo</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Private Shared Function SetShipTo(ByVal RequestData As Hashtable) As ShipTo
            Dim ShipToData As New ShipTo

            With RequestData
                If Not (Object.Equals(.Item(FIELD_SHIPCARRIER), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPCARRIER), EMPTY_STRING)) Then
                    ShipToData.ShipCarrier = .Item(FIELD_SHIPCARRIER).ToString
                End If



                If Not (Object.Equals(.Item(FIELD_SHIPFROMZIP), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPFROMZIP), EMPTY_STRING)) Then
                    ShipToData.ShipFromZip = .Item(FIELD_SHIPFROMZIP).ToString


                End If



                If Not (Object.Equals(.Item(FIELD_SHIPMETHOD), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPMETHOD), EMPTY_STRING)) Then
                    ShipToData.ShipMethod = .Item(FIELD_SHIPMETHOD).ToString

                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOCITY), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOCITY), EMPTY_STRING)) Then
                    ShipToData.ShipToCity = .Item(FIELD_SHIPTOCITY).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOCOUNTRY), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOCOUNTRY), EMPTY_STRING)) Then
                    ShipToData.ShipToCountry = .Item(FIELD_SHIPTOCOUNTRY).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOEMAIL), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOEMAIL), EMPTY_STRING)) Then
                    ShipToData.ShipToEmail = .Item(FIELD_SHIPTOEMAIL).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOFIRSTNAME), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOFIRSTNAME), EMPTY_STRING)) Then
                    ShipToData.ShipToFirstName = .Item(FIELD_SHIPTOFIRSTNAME).ToString

                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOLASTNAME), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOLASTNAME), EMPTY_STRING)) Then
                    ShipToData.ShipToLastName = .Item(FIELD_SHIPTOLASTNAME).ToString

                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOMIDDLENAME), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOMIDDLENAME), EMPTY_STRING)) Then
                    ShipToData.ShipToMiddleName = .Item(FIELD_SHIPTOMIDDLENAME).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOPHONE), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOPHONE), EMPTY_STRING)) Then
                    ShipToData.ShipToPhone = .Item(FIELD_SHIPTOPHONE).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOPHONE2), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOPHONE2), EMPTY_STRING)) Then
                    ShipToData.ShipToPhone2 = .Item(FIELD_SHIPTOPHONE2).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOSTATE), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOSTATE), EMPTY_STRING)) Then
                    ShipToData.ShipToState = .Item(FIELD_SHIPTOSTATE).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOSTREET), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOSTREET), EMPTY_STRING)) Then
                    ShipToData.ShipToStreet = .Item(FIELD_SHIPTOSTREET).ToString

                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOSTREET2), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOSTREET2), EMPTY_STRING)) Then
                    ShipToData.ShipToStreet2 = .Item(FIELD_SHIPTOSTREET2).ToString

                End If

                If Not (Object.Equals(.Item(FIELD_SHIPTOZIP), Nothing) Or _
                        Object.Equals(.Item(FIELD_SHIPTOZIP), EMPTY_STRING)) Then
                    ShipToData.ShipToZip = .Item(FIELD_SHIPTOZIP).ToString
                End If
            End With
            Return ShipToData

        End Function

#End Region

#Region "SetBrowserInfo"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the Browser details in the BrowserInfo object and returns 
        ''' the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>BrowserInfo</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Private Shared Function SetBrowserInfo(ByVal RequestData As Hashtable) As BrowserInfo
            Dim BrowserInfoData As New BrowserInfo

            With RequestData
                If Not (Object.Equals(.Item(FIELD_BROWSERCOUNTRYCODE), Nothing) Or _
                    Object.Equals(.Item(FIELD_BROWSERCOUNTRYCODE), EMPTY_STRING)) Then
                    BrowserInfoData.BrowserCountryCode = .Item(FIELD_BROWSERCOUNTRYCODE).ToString
                End If
                If Not (Object.Equals(.Item(FIELD_BROWSERTIME), Nothing) Or _
                    Object.Equals(.Item(FIELD_BROWSERTIME), EMPTY_STRING)) Then
                    BrowserInfoData.BrowserTime = .Item(FIELD_BROWSERTIME).ToString
                End If

                If Not (Object.Equals(.Item(FIELD_BROWSERUSERAGENT), Nothing) Or _
                    Object.Equals(.Item(FIELD_BROWSERUSERAGENT), EMPTY_STRING)) Then
                    BrowserInfoData.BrowserUserAgent = .Item(FIELD_BROWSERUSERAGENT).ToString
                End If
            End With
            Return BrowserInfoData
        End Function

#End Region

#Region "SetCustomerInfo"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the Customer details in the CustomerInfo object and returns 
        ''' the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>CustomerInfo</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Function SetCustomerInfo(ByVal RequestData As Hashtable) As CustomerInfo
            Dim CustomerInfoData As New CustomerInfo

            'With RequestData

            ' Removed 04/07/07 tsieber
            'If Not (Object.Equals(RequestData.Item(FIELD_CORPNAME), Nothing) Or _
            '        Object.Equals(RequestData.Item(FIELD_CORPNAME), EMPTY_STRING)) Then
            'CustomerInfoData.CorpName = RequestData.Item(FIELD_CORPNAME).ToString
            'End If

            If Not (Object.Equals(RequestData.Item(FIELD_CUSTCODE), Nothing) Or _
                 Object.Equals(RequestData.Item(FIELD_CUSTCODE), EMPTY_STRING)) Then
                CustomerInfoData.CustCode = RequestData.Item(FIELD_CUSTCODE).ToString
            End If

            If Not (Object.Equals(RequestData.Item(FIELD_CUSTID), Nothing) Or _
                    Object.Equals(RequestData.Item(FIELD_CUSTID), EMPTY_STRING)) Then
                CustomerInfoData.CustId = RequestData.Item(FIELD_CUSTID).ToString
            End If

            If Not (Object.Equals(RequestData.Item(FIELD_CUSTIP), Nothing) Or _
                    Object.Equals(RequestData.Item(FIELD_CUSTIP), EMPTY_STRING)) Then
                CustomerInfoData.CustIP = RequestData.Item(FIELD_CUSTIP).ToString
            End If

            If Not (Object.Equals(RequestData.Item(FIELD_CUSTVATREGNUM), Nothing) Or _
                    Object.Equals(RequestData.Item(FIELD_CUSTVATREGNUM), EMPTY_STRING)) Then
                CustomerInfoData.CustVatRegNum = RequestData.Item(FIELD_CUSTVATREGNUM).ToString
            End If

            If Not (Object.Equals(RequestData.Item(FIELD_DOB), Nothing) Or _
                    Object.Equals(RequestData.Item(FIELD_DOB), EMPTY_STRING)) Then
                CustomerInfoData.DOB = RequestData.Item(FIELD_DOB).ToString
            End If

            If Not (Object.Equals(RequestData.Item(FIELD_REQNAME), Nothing) Or _
                    Object.Equals(RequestData.Item(FIELD_REQNAME), EMPTY_STRING)) Then
                CustomerInfoData.ReqName = RequestData.Item(FIELD_REQNAME).ToString
            End If

            'End With
            Return CustomerInfoData

        End Function

#End Region

#Region "SetExtendData"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function sets the Extended data in the ExtendDataList and returns the same
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>ArrayList</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Private Shared Function SetExtendData(ByVal RequestData As Hashtable) As ArrayList
            Dim ExtDataList As New ArrayList
            '  Dim KeysColl As System.Collections.ICollection
            ' Dim KeysEnum As System.Collections.IEnumerator
            '  Dim FieldName As String

            ' KeysColl = RequestData.Keys()
            '  KeysEnum = KeysColl.GetEnumerator()

            ' While KeysEnum.MoveNext
            ' If KeysEnum.Current().ToString().StartsWith("TxtBoxExtend_") Then
            ' FieldName = KeysEnum.Current().ToString()

            ' If Not (Object.Equals(RequestData.Item(FieldName), Nothing) Or _
            '          Object.Equals(RequestData.Item(FieldName), EMPTY_STRING)) Then
            '  ExtDataList.Add(New ExtendData(FieldName, RequestData.Item(FieldName).ToString))
            '   End If

            '  End If
            '  End While
            If Not (Object.Equals(RequestData.Item(FIELD_EXTENDFIELD1), Nothing) Or _
           Object.Equals(RequestData.Item(FIELD_EXTENDFIELD1), EMPTY_STRING)) Then
                ExtDataList.Add(New ExtendData("EXTENDFIELD1", RequestData.Item(FIELD_EXTENDFIELD1).ToString))
            End If

            If Not (Object.Equals(RequestData.Item(FIELD_EXTENDFIELD2), Nothing) Or _
                       Object.Equals(RequestData.Item(FIELD_EXTENDFIELD2), EMPTY_STRING)) Then
                ExtDataList.Add(New ExtendData("EXTENDFIELD2", RequestData.Item(FIELD_EXTENDFIELD2).ToString))
            End If

            Return ExtDataList
        End Function
#End Region

#Region "SetTender"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function creates a Tender object and then creates a PaymentDevice object 
        ''' depending on the tender type.
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>ArrayList</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------

        Private Function SetTender(ByVal RequestData As Hashtable) As BaseTender

            If Object.Equals(RequestData.Item(FIELD_TENDER), TENDER_CREDITCARD) Then

                If Object.Equals(RequestData.Item(FIELD_SWIPE), Nothing) Or _
                    Object.Equals(RequestData.Item(FIELD_SWIPE), EMPTY_STRING) Then
                    Dim Month As String = ""
                    Dim Year As String = ""
                    If Not (Object.Equals(RequestData.Item(FIELD_EXPIRYMONTH), Nothing) Or _
                        Object.Equals(RequestData.Item(FIELD_EXPIRYMONTH), EMPTY_STRING)) Then
                        Month = RequestData.Item(FIELD_EXPIRYMONTH).ToString
                    End If

                    If Not (Object.Equals(RequestData.Item(FIELD_EXPIRYYEAR), Nothing) Or _
                       Object.Equals(RequestData.Item(FIELD_EXPIRYYEAR), EMPTY_STRING)) Then

                        Year = RequestData.Item(FIELD_EXPIRYYEAR).ToString
                        Year = Year.Substring(2, 2)

                    End If

                    PaymentDevice = New CreditCard(RequestData.Item(FIELD_ACCT).ToString, _
                                                    Month + Year)

                    If Not (Object.Equals(RequestData.Item(FIELD_CVV2), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_CVV2), EMPTY_STRING)) Then
                        CType(PaymentDevice, CreditCard).Cvv2 = RequestData.Item(FIELD_CVV2).ToString
                    End If

                    If Not (Object.Equals(RequestData.Item(FIELD_NAME), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_NAME), EMPTY_STRING)) Then
                        PaymentDevice.Name = RequestData.Item(FIELD_NAME).ToString
                    End If

                    Tender = New CardTender(CType(PaymentDevice, CreditCard))
                Else
                    PaymentDevice = New SwipeCard(RequestData.Item(FIELD_SWIPE).ToString)
                    Tender = New CardTender(CType(PaymentDevice, SwipeCard))
                End If

            ElseIf Object.Equals(RequestData.Item(FIELD_TENDER), TENDER_ACH) Then

                PaymentDevice = New BankAcct(RequestData.Item(FIELD_ACCT).ToString, _
                                                RequestData.Item(FIELD_ABA).ToString)

                If Not (Object.Equals(RequestData.Item(FIELD_ACCTTYPE), Nothing) Or _
                        Object.Equals(RequestData.Item(FIELD_ACCTTYPE), EMPTY_STRING)) Then
                    CType(PaymentDevice, BankAcct).AcctType = RequestData.Item(FIELD_ACCTTYPE).ToString
                End If

                If Not (Object.Equals(RequestData.Item(FIELD_NAME), Nothing) Or _
                        Object.Equals(RequestData.Item(FIELD_NAME), EMPTY_STRING)) Then
                    CType(PaymentDevice, BankAcct).Name = RequestData.Item(FIELD_NAME).ToString
                End If

                Tender = New ACHTender(CType(PaymentDevice, BankAcct))
                'Cast the tender to ACHTender for setting the ACH specific fields
                With CType(Tender, ACHTender)

                    If Not (Object.Equals(RequestData.Item(FIELD_AUTHTYPE), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_AUTHTYPE), EMPTY_STRING)) Then
                        .AuthType = RequestData.Item(FIELD_AUTHTYPE).ToString
                    End If

                    If Not (Object.Equals(RequestData.Item(FIELD_CHKNUM), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_CHKNUM), EMPTY_STRING)) Then
                        .ChkNum = RequestData.Item(FIELD_CHKNUM).ToString
                    End If

                    If Not (Object.Equals(RequestData.Item(FIELD_PRENOTE), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_PRENOTE), EMPTY_STRING)) Then
                        .PreNote = RequestData.Item(FIELD_PRENOTE).ToString
                    End If
                    If Not (Object.Equals(RequestData.Item(FIELD_TERMCITY), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_TERMCITY), EMPTY_STRING)) Then
                        .TermCity = RequestData.Item(FIELD_TERMCITY).ToString
                    End If
                    If Not (Object.Equals(RequestData.Item(FIELD_TERMSTATE), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_TERMSTATE), EMPTY_STRING)) Then
                        .TermState = RequestData.Item(FIELD_TERMSTATE).ToString
                    End If
                End With

            ElseIf Object.Equals(RequestData.Item(FIELD_TENDER), TENDER_TELECHECK) Then
                PaymentDevice = New CheckPayment(RequestData.Item(FIELD_MICR).ToString)
                If Not (Object.Equals(RequestData.Item(FIELD_NAME), Nothing) Or _
                        Object.Equals(RequestData.Item(FIELD_NAME), EMPTY_STRING)) Then
                    PaymentDevice.Name = RequestData.Item(FIELD_NAME).ToString
                End If

                Tender = New CheckTender(CType(PaymentDevice, CheckPayment))
                'Cast the tender to CheckTender for setting the TeleCheck specific fields
                With CType(Tender, CheckTender)
                    If Not (Object.Equals(RequestData.Item(FIELD_CHKNUM), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_CHKNUM), EMPTY_STRING)) Then
                        .ChkNum = RequestData.Item(FIELD_CHKNUM).ToString
                    End If
                    If Not (Object.Equals(RequestData.Item(FIELD_CHKTYPE), Nothing) Or _
                            Object.Equals(RequestData.Item(FIELD_CHKTYPE), EMPTY_STRING)) Then
                        .ChkType = RequestData.Item(FIELD_CHKTYPE).ToString
                    End If
                End With
            End If
            'If Not (Object.Equals(RequestData.Item(FIELD_BANKNAME), Nothing) Or _
            '   Object.Equals(RequestData.Item(FIELD_BANKNAME), EMPTY_STRING)) Then
            '    Tender.BankName = RequestData.Item(FIELD_BANKNAME).ToString
            'End If
            'If Not (Object.Equals(RequestData.Item(FIELD_BANKSTATE), Nothing) Or _
            '   Object.Equals(RequestData.Item(FIELD_BANKSTATE), EMPTY_STRING)) Then
            '    Tender.BankState = RequestData.Item(FIELD_BANKSTATE).ToString
            'End If
            'If Not (Object.Equals(RequestData.Item(FIELD_CONSENTMEDIUM), Nothing) Or _
            '   Object.Equals(RequestData.Item(FIELD_CONSENTMEDIUM), EMPTY_STRING)) Then
            '    Tender.ConsentMedium = RequestData.Item(FIELD_CONSENTMEDIUM).ToString
            'End If
            'If Not (Object.Equals(RequestData.Item(FIELD_CUSTOMERTYPE), Nothing) Or _
            '   Object.Equals(RequestData.Item(FIELD_CUSTOMERTYPE), EMPTY_STRING)) Then
            '    Tender.CustomerType = RequestData.Item(FIELD_CUSTOMERTYPE).ToString
            'End If
            'If Not (Object.Equals(RequestData.Item(FIELD_DLSTATE), Nothing) Or _
            '   Object.Equals(RequestData.Item(FIELD_DLSTATE), EMPTY_STRING)) Then
            '    Tender.DlState = RequestData.Item(FIELD_DLSTATE).ToString
            'End If
            If Not (Object.Equals(RequestData.Item(FIELD_DL), Nothing) Or _
                Object.Equals(RequestData.Item(FIELD_DL), EMPTY_STRING)) Then
                Tender.DL = RequestData.Item(FIELD_DL).ToString
            End If
            If Not (Object.Equals(RequestData.Item(FIELD_SS), Nothing) Or _
                Object.Equals(RequestData.Item(FIELD_SS), EMPTY_STRING)) Then
                Tender.SS = RequestData.Item(FIELD_SS).ToString
            End If
            Return Tender
        End Function

#End Region

#Region "SetLineItemData"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function gets the number of line items passed from the SampleStore in an
        ''' Array. The code then loops through the length of the array. For each entry in the 
        ''' array, the code sets the lineitem data into lineitem object and sets the lineitem 
        ''' object in the invoice object. The function then returns the Invoice object with
        ''' the lineitem objects.
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <param name="Invoice"></param>
        ''' <returns>Invoice</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Function SetLineItemData(ByVal RequestData As Hashtable, ByVal Invoice As Invoice) As Invoice
            Dim LineItemNumbers As Array
            Dim Counter As Integer
            Dim LineItemData As LineItem
            Dim LineItemNumber As Integer
            Dim Util As New SampleStore.VB.Common.SampleStoreUtil

            'Get the lineitem numbers in an Array
            LineItemNumbers = GetLineItemNumberArray(RequestData)

            For Counter = 0 To LineItemNumbers.Length - 1
                LineItemNumber = Integer.Parse(LineItemNumbers.GetValue(Counter).ToString)

                'For each lineitem number in the array, create a lineitem object and set the 
                'lineitem data in he same

                LineItemData = New LineItem
                With RequestData

                    If Not (Object.Equals(.Item(FIELD_L_AMT & LineItemNumber), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_L_AMT & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.Amt = Util.GetCurrencyFromString(.Item(FIELD_L_AMT & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_AMT" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_L_CATALOGNUM & LineItemNumber), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_L_CATALOGNUM & LineItemNumber), Nothing)) Then
                        LineItemData.CatalogNum = .Item(FIELD_L_CATALOGNUM & LineItemNumber).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_L_COMMCODE & LineItemNumber), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_L_COMMCODE & LineItemNumber), Nothing)) Then
                        LineItemData.CommCode = .Item(FIELD_L_COMMCODE & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_COST & LineItemNumber), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_L_COST & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.Cost = Util.GetCurrencyFromString(.Item(FIELD_L_COST & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_COST" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_COSTCENTERNUM & LineItemNumber), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_L_COSTCENTERNUM & LineItemNumber), Nothing)) Then
                        LineItemData.CostCenterNum = .Item(FIELD_L_COSTCENTERNUM & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_DESC & LineItemNumber), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_L_DESC & LineItemNumber), Nothing)) Then
                        LineItemData.Desc = .Item(FIELD_L_DESC & LineItemNumber).ToString
                    End If

                    If Not (Object.Equals(.Item(FIELD_L_DISCOUNT & LineItemNumber), EMPTY_STRING) Or _
                            Object.Equals(.Item(FIELD_L_DISCOUNT & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.Discount = Util.GetCurrencyFromString(.Item(FIELD_L_DISCOUNT & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_DISCOUNT" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If

                    If Not (Object.Equals(.Item(FIELD_L_FREIGHTAMT & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_FREIGHTAMT & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.FreightAmt = Util.GetCurrencyFromString(.Item(FIELD_L_FREIGHTAMT & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_FREIGHTAMT" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If


                    If Not (Object.Equals(.Item(FIELD_L_HANDLINGAMT & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_HANDLINGAMT & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.HandlingAmt = Util.GetCurrencyFromString(.Item(FIELD_L_HANDLINGAMT & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_HANDLINGAMT" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If


                    If Not (Object.Equals(.Item(FIELD_L_MANUFACTURER & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_MANUFACTURER & LineItemNumber), Nothing)) Then
                        LineItemData.Manufacturer = .Item(FIELD_L_MANUFACTURER & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_PICKUPCITY & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_PICKUPCITY & LineItemNumber), Nothing)) Then
                        LineItemData.PickupCity = .Item(FIELD_L_PICKUPCITY & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_PICKUPCOUNTRY & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_PICKUPCOUNTRY & LineItemNumber), Nothing)) Then
                        LineItemData.PickupCountry = .Item(FIELD_L_PICKUPCOUNTRY & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_PICKUPSTATE & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_PICKUPSTATE & LineItemNumber), Nothing)) Then
                        LineItemData.PickupState = .Item(FIELD_L_PICKUPSTATE & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_PICKUPSTREET & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_PICKUPSTREET & LineItemNumber), Nothing)) Then
                        LineItemData.PickupStreet = .Item(FIELD_L_PICKUPSTREET & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_PICKUPZIP & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_PICKUPZIP & LineItemNumber), Nothing)) Then
                        LineItemData.PickupZip = .Item(FIELD_L_PICKUPZIP & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_PRODCODE & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_PRODCODE & LineItemNumber), Nothing)) Then
                        LineItemData.ProdCode = .Item(FIELD_L_PRODCODE & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_QTY & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_QTY & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.Qty = Integer.Parse(.Item(FIELD_L_QTY & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_QTY" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_SKU & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_SKU & LineItemNumber), Nothing)) Then
                        LineItemData.SKU = .Item(FIELD_L_SKU & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_TAXAMT & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_TAXAMT & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.TaxAmt = Util.GetCurrencyFromString(.Item(FIELD_L_TAXAMT & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_TAXAMT" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_TAXRATE & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_TAXRATE & LineItemNumber), Nothing)) Then
                        Try
                            LineItemData.TaxRate = Util.GetCurrencyFromString(.Item(FIELD_L_TAXRATE & LineItemNumber).ToString)
                        Catch Ex As Exception
                            InvalidFieldList = InvalidFieldList + "L_TAXRATE" + LineItemNumber.ToString + " <br>"
                        End Try
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_TRACKINGNUM & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_TRACKINGNUM & LineItemNumber), Nothing)) Then
                        LineItemData.TrackingNum = .Item(FIELD_L_TRACKINGNUM & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_TYPE & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_TYPE & LineItemNumber), Nothing)) Then
                        LineItemData.Type = .Item(FIELD_L_TYPE & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_UOM & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_UOM & LineItemNumber), Nothing)) Then
                        LineItemData.UOM = .Item(FIELD_L_UOM & LineItemNumber).ToString
                    End If
                    If Not (Object.Equals(.Item(FIELD_L_UPC & LineItemNumber), EMPTY_STRING) Or _
       Object.Equals(.Item(FIELD_L_UPC & LineItemNumber), Nothing)) Then
                        LineItemData.UPC = .Item(FIELD_L_UPC & LineItemNumber).ToString
                    End If


                End With
                'Set the lineitem object in Invoice object
                Invoice.AddLineItem(LineItemData)
            Next
            Return Invoice
        End Function
#End Region

#Region "GetLineItemNumberArray"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function iterates through the request hashtable and finds the fields 
        ''' starting with the LINE_ITEM_PREFIX. If a line item field is found, then the 
        ''' line item number is extracted from the field name. The code checks if this 
        ''' lineitem number is present in the array. If yes, then the search for the line
        ''' item number is continued. If no, then the number is added to the array.
        ''' So if there are 3 line items then the array will have {0,1,2} elements.
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns>Array</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Shared Function GetLineItemNumberArray(ByVal RequestData As Hashtable) As Array

            Dim Keys As System.Collections.ICollection
            Dim KeysEnum As System.Collections.IEnumerator
            Dim KeyDesc As String
            Dim LineItemNumber As String
            Dim LineNumberArray(-1) As String
            Dim Index As Integer = 0

            Keys = RequestData.Keys()
            KeysEnum = Keys.GetEnumerator()

            While KeysEnum.MoveNext
                KeyDesc = KeysEnum.Current().ToString()

                If KeyDesc.StartsWith(LINE_ITEM_PREFIX) Then
                    If Not Object.Equals(RequestData.Item(KeyDesc), EMPTY_STRING) Then
                        LineItemNumber = GetLineItemNumber(KeyDesc)

                        If Array.IndexOf(LineNumberArray, LineItemNumber) < 0 Then
                            ReDim Preserve LineNumberArray(Index)
                            LineNumberArray.SetValue(LineItemNumber, Index)
                            Index += 1
                        End If

                    End If
                End If
            End While

            Return LineNumberArray
        End Function
#End Region

#Region "GetLineItemNumber"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This method returns the line item no. for the passed line item
        '''The code check the parameter value from the last character
        '''onwards till it comes across a non-numeric characteand returns the item number
        ''' </summary>
        ''' <param name="LineItemName"></param>
        ''' <returns>String</returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Private Shared Function GetLineItemNumber(ByVal LineItemName As String) As String
            Dim LineItemNo As Integer = 0
            Dim Multiplier As Integer = 1
            Dim LineItemChar As Char = LineItemName.Chars(LineItemName.Length() - 1)

            While Char.IsDigit(LineItemChar)
                LineItemNo += CType(Char.GetNumericValue(LineItemChar) * Multiplier, Integer)
                LineItemName = LineItemName.Substring(0, LineItemName.Length() - 1)
                LineItemChar = LineItemName.Chars(LineItemName.Length() - 1)
                Multiplier *= 10
            End While

            Return LineItemNo.ToString
        End Function
#End Region

#Region "SubmitTransaction"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' This function will be overridden by the individual handlers for their respective
        ''' implementation
        ''' </summary>
        ''' <param name="RequestData"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' -----------------------------------------------------------------------------
        Public Overridable Function SubmitTransaction(ByVal RequestData As Hashtable) As Hashtable Implements ITransactionHandler.SubmitTransaction
            Return Nothing
        End Function

#End Region

    End Class
End Namespace

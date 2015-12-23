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
    ''' This  class consists of the Constants that are used throughout
    ''' the sample store application
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Class SampleStoreConstants


        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for EncryptedData.txt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FILENAME As String = "EncryptedData.txt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboAcctType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ACCTTYPE As String = "CboAcctType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboAuthType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_AUTHTYPE As String = "CboAuthType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboBuyerAuthenticationRequired
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BAREQUIRED As String = "CboBuyerAuthenticationRequired"

        'public Shared ReadOnly FIELD_CARDTYPE As String = "CboCardType"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboCurrency
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CURRENCY As String = "CboCurrency"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''         ''' Field on SampleStore for CboExpiryMonth
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_EXPIRYMONTH As String = "CboExpiryMonth"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboExpiryYear
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_EXPIRYYEAR As String = "CboExpiryYear"

        'public Shared ReadOnly FIELD_PAYMENTINSTRTYPE As String = "CboPaymentInstrType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboPurchaseCardSubType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PURCHASECARDSUBTYPE As String = "CboPurchaseCardSubType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboRecurring
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_RECURRING As String = "CboRecurring"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboRequestType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_REQUESTTYPE As String = "CboRequestType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboTender
        ''' </summary> 
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_TENDER As String = "CboTender"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboTrxType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_TRXTYPE As String = "CboTrxType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboVerbosity
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_VERBOSITY As String = "CboVerbosity"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxBillToStreet2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BILLTOSTREET2 As String = "TxtBoxBillToStreet2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxAba
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ABA As String = "TxtBoxAba"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxAcct
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ACCT As String = "TxtBoxAcct"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxAltTaxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ALTTAXAMT As String = "TxtBoxAltTaxAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_AMT As String = "TxtBoxAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxAuthCode
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_AUTHCODE As String = "TxtBoxAuthCode"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxBillToPhone2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BILLTOPHONE2 As String = "TxtBoxBillToPhone2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxBrowserCountryCode
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BROWSERCOUNTRYCODE As String = "TxtBoxBrowserCountryCode"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxBrowserTime
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BROWSERTIME As String = "TxtBoxBrowserTime"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxBrowserUserAgent
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BROWSERUSERAGENT As String = "TxtBoxBrowserUserAgent"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxBuyerAuthStatus
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BUYERAUTHSTATUS As String = "TxtBoxBuyerAuthStatus"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxChkNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------

        Public Shared ReadOnly FIELD_CHKNUM As String = "TxtBoxChkNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxChkType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CHKTYPE As String = "TxtBoxChkType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCity
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CITY As String = "TxtBoxCity"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxComment1
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_COMMENT1 As String = "TxtBoxComment1"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxComment2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_COMMENT2 As String = "TxtBoxComment2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCompanyName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_COMPANYNAME As String = "TxtBoxCompanyName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCorpName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CORPNAME As String = "TxtBoxCorpName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCountry
        ''' </summary>
        ''' -----------------------------------------------------------------------------

        Public Shared ReadOnly FIELD_BILLTOCOUNTRY As String = "TxtBoxCountry"

        'public Shared ReadOnly FIELD_CREDITCARDNAME As String = "TxtBoxCreditCardName"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCustCode
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CUSTCODE As String = "TxtBoxCustCode"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCustId
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CUSTID As String = "TxtBoxCustId"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCustIp
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CUSTIP As String = "TxtBoxCustIp"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCustRef
        ''' </summary>
        ''' -----------------------------------------------------------------------------

        Public Shared ReadOnly FIELD_CUSTREF As String = "TxtBoxCustRef"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCustVatRegNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------

        Public Shared ReadOnly FIELD_CUSTVATREGNUM As String = "TxtBoxCustVatRegNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxCvv2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_CVV2 As String = "TxtBoxCvv2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDesc
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DESC As String = "TxtBoxDesc"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDesc1
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DESC1 As String = "TxtBoxDesc1"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDesc2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DESC2 As String = "TxtBoxDesc2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDesc3
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DESC3 As String = "TxtBoxDesc3"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDesc4
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DESC4 As String = "TxtBoxDesc4"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDiscount
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DISCOUNT As String = "TxtBoxDiscount"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDL
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DL As String = "TxtBoxDL"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDob
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DOB As String = "TxtBoxDob"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxDutyAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_DUTYAMT As String = "TxtBoxDutyAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxEmail
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_EMAIL As String = "TxtBoxEmail"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxEndTime
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ENDTIME As String = "TxtBoxEndTime"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxFax
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_FAX As String = "TxtBoxFax"

        'public Shared ReadOnly FIELD_FINANCIALINSTITUTION As String = "TxtBoxFinancialInstitution"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxFirstName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_FIRSTNAME As String = "TxtBoxFirstName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxMiddleName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_MIDDLENAME As String = "TxtBoxMiddleName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxFreightAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_FREIGHTAMT As String = "TxtBoxFreightAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxHandlingAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_HANDLINGAMT As String = "TxtBoxHandlingAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxHomePhone
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_HOMEPHONE As String = "TxtBoxHomePhone"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxInvNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_INVNUM As String = "TxtBoxInvNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxInvoiceDate
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_INVOICEDATE As String = "TxtBoxInvoiceDate"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Amt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_AMT As String = "TxtBoxL_Amt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_CatalogNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_CATALOGNUM As String = "TxtBoxL_CatalogNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Commcode
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_COMMCODE As String = "TxtBoxL_Commcode"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Cost
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_COST As String = "TxtBoxL_Cost"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_CostcenterNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_COSTCENTERNUM As String = "TxtBoxL_CostcenterNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Desc
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_DESC As String = "TxtBoxL_Desc"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Discount
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_DISCOUNT As String = "TxtBoxL_Discount"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_FreightAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_FREIGHTAMT As String = "TxtBoxL_FreightAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_HandlingAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_HANDLINGAMT As String = "TxtBoxL_HandlingAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Manufacturer
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_MANUFACTURER As String = "TxtBoxL_Manufacturer"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Pickupcity
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_PICKUPCITY As String = "TxtBoxL_Pickupcity"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_PickupCountry
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_PICKUPCOUNTRY As String = "TxtBoxL_PickupCountry"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Pickupstate
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_PICKUPSTATE As String = "TxtBoxL_Pickupstate"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Pickupstreet
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_PICKUPSTREET As String = "TxtBoxL_Pickupstreet"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_PickupZip
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_PICKUPZIP As String = "TxtBoxL_PickupZip"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_ProdCode
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_PRODCODE As String = "TxtBoxL_ProdCode"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Qty
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_QTY As String = "TxtBoxL_Qty"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Sku
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_SKU As String = " "
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_TaxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_TAXAMT As String = "TxtBoxL_TaxAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_TaxRate
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_TAXRATE As String = "TxtBoxL_TaxRate"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_TaxType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_TAXTYPE As String = "TxtBoxL_TaxType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_TrackingNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_TRACKINGNUM As String = "TxtBoxL_TrackingNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Type
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_TYPE As String = "TxtBoxL_Type"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_UnspscCode
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_UNSPSCCODE As String = "TxtBoxL_UnspscCode"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Uom
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_UOM As String = "TxtBoxL_Uom"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Upc
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_UPC As String = "TxtBoxL_Upc"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxL_Description
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_L_Description As String = "TxtBoxL_Description"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxLastName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_LASTNAME As String = "TxtBoxLastName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxLocalTaxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_LOCALTAXAMT As String = "TxtBoxLocalTaxAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for  TxtBoxMerchDescr
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_MERCHDESCR As String = "TxtBoxMerchDescr"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxMerchSvc
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_MERCHSVC As String = "TxtBoxMerchSvc"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxMicr
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_MICR As String = "TxtBoxMicr"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_NAME As String = "TxtBoxName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxNationalTaxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_NATIONALTAXAMT As String = "TxtBoxNationalTaxAmt"

        'public Shared ReadOnly FIELD_ORDERNUMBER As String = "TxtBoxOrderNumber"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxOrigId
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ORIGID As String = "TxtBoxOrigId"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxPhoneNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PHONENUM As String = "TxtBoxPhoneNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxPoNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PONUM As String = "TxtBoxPoNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboPrenote
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PRENOTE As String = "CboPrenote"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxPurDesc
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PURDESC As String = "TxtBoxPurDesc"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxReqname
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_REQNAME As String = "TxtBoxReqname"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipCarrier
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPCARRIER As String = "TxtBoxShipCarrier"
        ''' -----------------------------------------------------------------------------
        ''' <summary> 
        ''' Field on SampleStore for TxtBoxShipFromzip
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPFROMZIP As String = "TxtBoxShipFromzip"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipMethod
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPMETHOD As String = "TxtBoxShipMethod"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToCity
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOCITY As String = "TxtBoxShipToCity"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToCountry
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOCOUNTRY As String = "TxtBoxShipToCountry"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToEmail
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOEMAIL As String = "TxtBoxShipToEmail"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToFirstName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOFIRSTNAME As String = "TxtBoxShipToFirstName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToLastName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOLASTNAME As String = "TxtBoxShipToLastName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToMiddleName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOMIDDLENAME As String = "TxtBoxShipToMiddleName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToPhone
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOPHONE As String = "TxtBoxShipToPhone"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToPhone2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOPHONE2 As String = "TxtBoxShipToPhone2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToState
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOSTATE As String = "TxtBoxShipToState"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToStreet
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOSTREET As String = "TxtBoxShipToStreet"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToStreet2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOSTREET2 As String = "TxtBoxShipToStreet2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxShipToZip
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SHIPTOZIP As String = "TxtBoxShipToZip"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxSS
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SS As String = "TxtBoxSS"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxStartTime
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_STARTTIME As String = "TxtBoxStartTime"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxState
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_STATE As String = "TxtBoxState"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxStreet
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_STREET As String = "TxtBoxStreet"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxSwipe
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_SWIPE As String = "TxtBoxSwipe"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxTaxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_TAXAMT As String = "TxtBoxTaxAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboTaxExempt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_TAXEXEMPT As String = "CboTaxExempt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxTermCity
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_TERMCITY As String = "TxtBoxTermCity"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxTermState
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_TERMSTATE As String = "TxtBoxTermState"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxVatRegNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_VATREGNUM As String = "TxtBoxVatRegNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxVatTaxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_VATTAXAMT As String = "TxtBoxVatTaxAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxZip
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ZIP As String = "TxtBoxZip"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxWeakAssemblyRequest
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_WEAKASSEMBLYREQUEST As String = "TxtBoxWeakAssemblyRequest"

        'public Shared ReadOnly FIELD_WEAKASSEMBLYRESPONSE As String = "TxtAreaWeakAssemblyResponse"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxUser
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_USER As String = "TxtBoxUser"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxVendor
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_VENDOR As String = "TxtBoxVendor"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxPartner
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PARTNER As String = "TxtBoxPartner"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxPassword
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PASSWORD As String = "TxtBoxPassword"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboAction
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ACTION As String = "CboAction"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxProfileName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PROFILENAME As String = "TxtBoxProfileName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxStart
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_RECURRINGSTARTDATE As String = "TxtBoxStart"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxTerm
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_TERM As String = "TxtBoxTerm"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboPayPeriod
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PAYPERIOD As String = "CboPayPeriod"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxOptionalTrxAmt
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_OPTIONALTRXAMT As String = "TxtBoxOptionalTrxAmt"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboOptionalTrxType
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_OPTIONALTRXTYPE As String = "CboOptionalTrxType"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxOrigProfileId
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ORIGPROFILEID As String = "TxtBoxOrigProfileId"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboPaymentHistory
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PAYMENTHISTORY As String = "CboPaymentHistory"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxPaymentNum
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PAYMENTNUM As String = "TxtBoxPaymentNum"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxRetryNumDays
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_RETRYNUMDAYS As String = "TxtBoxRetryNumDays"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxMaxFailPayments
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_MAXFAILPAYMENTS As String = "TxtBoxMaxFailPayments"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for CboUpdateAction
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_UPDATEACTION As String = "CboUpdateAction"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxExtend_Field1
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_EXTENDFIELD1 As String = "TxtBoxExtend_Field1"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxExtend_Field2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_EXTENDFIELD2 As String = "TxtBoxExtend_Field2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxProxyAddress
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PROXYADDRESS As String = "TxtBoxProxyAddress"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxProxyPort
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PROXYPORT As String = "TxtBoxProxyPort"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Field on SampleStore for TxtBoxProxyLogon
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PROXYLOGON As String = "TxtBoxProxyLogon"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxProxyPassword
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_PROXYPASSWORD As String = "TxtBoxProxyPassword"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxRequestId
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_REQUESTID As String = "TxtBoxRequestId"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxCommCode
        ''' </summary>
        ''' -----------------------------------------------------------------------------

        Public Shared ReadOnly FIELD_COMMCODE As String = "TxtBoxCommCode"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxBillHomePhone
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_BILLHOMEPHONE As String = "TxtBoxBillHomePhone"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxVaTaxPercent
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_VATAXPERCENT As String = "TxtBoxVaTaxPercent"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxOrderDate
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ORDERDATE As String = "TxtBoxOrderDate"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxOrderTime
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_ORDERTIME As String = "TxtBoxOrderTime"
      
        'Public Shared ReadOnly FIELD_BANKNAME As String = "TxtBoxBankName"
        
        'Public Shared ReadOnly FIELD_BANKSTATE As String = "TxtBoxBankState"
        
        'Public Shared ReadOnly FIELD_CONSENTMEDIUM As String = "TxtBoxConsentMedium"
        
        'Public Shared ReadOnly FIELD_CUSTOMERTYPE As String = "TxtBoxCustomerType"
       
        'Public Shared ReadOnly FIELD_DLSTATE As String = "TxtBoxDLState"

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxVITIntegrationProduct
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_VIT_INTEGRATION_PRODUCT As String = "TxtBoxVITIntegrationProduct"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        '''  Field on SampleStore for TxtBoxVITIntegrationVersion
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FIELD_VIT_INTEGRATION_VERSION As String = "TxtBoxVITIntegrationVersion"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Action type Add
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ACTION_ADD As String = "A"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Action type Modify
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ACTION_MODIFY As String = "M"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Action type INQUIRY
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ACTION_INQUIRY As String = "I"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Action type CANCEL
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ACTION_CANCEL As String = "C"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Action type REACTIVTE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ACTION_REACTIVTE As String = "R"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Action type PAYMENT
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ACTION_PAYMENT As String = "P"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Authroization
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_AUTH As String = "A"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Capture
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_CAPTURE As String = "D"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Sale
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_SALE As String = "S"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Credit
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_CREDIT As String = "C"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Void
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_VOID As String = "V"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Vaoice auth
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_VOICEAUTH As String = "F"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Inquiry
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_INQUIRY As String = "I"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type Recurring
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_RECURRING As String = "R"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction type RMS Review
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TRXTYPE_RMSREVIEW As String = "U"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the request parameter PaRes
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly REQUEST_PARES As String = "PaRes"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name TermUrl
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_TERMURL As String = "TermUrl"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name FileName
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_FILENAME As String = "FileName"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name HostPort
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_HOSTPORT As String = "HostPort"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name PAYFLOW_HOST
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_HOSTADDRESS As String = "PAYFLOW_HOST"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name HostTimeout
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_TIMEOUT As String = "HostTimeout"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name BAHostPort
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_BAHOSTPORT As String = "BAHostPort"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name BAHostAddress
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_BAHOSTADDRESS As String = "BAHostAddress"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name BAHostTimeout
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_BATIMEOUT As String = "BAHostTimeout"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name User
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_USER As String = "User"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name Vendor
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_VENDOR As String = "Vendor"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name Partner
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_PARTNER As String = "Partner"
        ''' -----------------------------------------------------------------------------
        ''' <summary> 
        ''' String Constant for the property name Password
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_PASSWORD As String = "Password"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name StrongAsmbRespUrl
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_URL_STRONGASMBRESPURL As String = "StrongAsmbRespUrl"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name SampleStoreUrl
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_URL_SAMPLESTOREURL As String = "SampleStoreUrl"
        ''' -----------------------------------------------------------------------------
        ''' <summary> 
        ''' String Constant for the property name WeakAsmbRespUrl
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_URL_WEAKASMBRESPURL As String = "WeakAsmbRespUrl"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name ErrorPageUrl
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_URL_ERRORPAGEURL As String = "ErrorPageUrl"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the property name RedirectToACSServer
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly PROP_URL_REDIRECTTOACSSERVER As String = "RedirectToACSServer"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for the empty string
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly EMPTY_STRING As String = ""
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Flag value YES
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FLG_YES As String = "Y"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Flag value NO
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly FLG_NO As String = "N"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Request type strong assembly
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly REQUESTTYPE_STRONGASSEMBLY As String = "Strong Assembly - Data Objects"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Request type Week Assembly :Name Value pair
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly REQUESTTYPE_WEAKASSEMBLY_NVP As String = "Name-Value Pair"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Request type Week Assembly :XML Pay 1.0
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly REQUESTTYPE_WEAKASSEMBLY_XML10 As String = "XML Pay 1.0"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Request type Week Assembly :XML Pay 2.0
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly REQUESTTYPE_WEAKASSEMBLY_XML20 As String = "XML Pay 2.0"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for name value delimiter
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly NV_DELIMITER As String = "&"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for name value delimiter response
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly NV_DELIMITER_RESPONSE As String = "&"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Tender Type Credit Card
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TENDER_CREDITCARD As String = "C"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Tender Type ACH
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TENDER_ACH As String = "A"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Tender Type TeleCheck
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly TENDER_TELECHECK As String = "K"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Tender Type LineItem Prefix
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly LINE_ITEM_PREFIX As String = "TxtBoxL_"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field  AUTHCODE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_AUTHCODE As String = "AUTHCODE"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field PNREF
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_PNREF As String = "PNREF"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field RESPMSG
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_RESPMSG As String = "RESPMSG"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field RESULT
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_RESULT As String = "RESULT"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field AVSADDR
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_AVSADDR As String = "AVSADDR"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field AVSZIP
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_AVSZIP As String = "AVSZIP"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field CARDSECURE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_CARDSECURE As String = "CARDSECURE"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field CVV2MATCH
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_CVV2MATCH As String = "CVV2MATCH"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for general response field IAVS
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_IAVS As String = "IAVS"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Transaction response field  ADDLMSGS
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_TRANS_ADDLMSGS As String = "ADDLMSGS"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for fraud response field FPSPOSTXMLDATA
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_FRAUD_FPSPOSTXMLDATA As String = "FPSPOSTXMLDATA"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for fraud response field FPSPREXMLDATA
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_FRAUD_FPSPREXMLDATA As String = "FPSPREXMLDATA"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for transaction response field HOSTCODE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_TRANS_HOSTCODE As String = "HOSTCODE"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for fraud response field POSTFPSMESSAGE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_FRAUD_POSTFPSMESSAGE As String = "POSTFPSMESSAGE"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for fraud response field PREFPSMESSAGE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_FRAUD_PREFPSMESSAGE As String = "PREFPSMESSAGE"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for transaction response field PROCCVV2
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_TRANS_PROCCVV2 As String = "PROCCVV2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for transaction response field PROCAVS
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_TRANS_PROCAVS As String = "PROCAVS"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for transaction response field PROCCARDSECURE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_TRANS_PROCCARDSECURE As String = "PROCCARDSECURE"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for transaction response field RESPTEXT
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_TRANS_RESPTEXT As String = "RESPTEXT"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant AUTHENTICATION_STATUS
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_AUTHSTATUS_KEY As String = "AUTHENTICATION_STATUS"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant AUTHENTICATION_ID
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_AUTHID_KEY As String = "AUTHENTICATION_ID"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant RESPMSG
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESPMSG_KEY As String = "RESPMSG"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant ECI
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_ECI_KEY As String = "ECI"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant ACSURL
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_ACSURL_KEY As String = "ACSURL"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant PAREQ
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_PAREQ_KEY As String = "PAREQ"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant  PaRes
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_PARES_KEY As String = "PaRes"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant XID
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_XID_KEY As String = "XID"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant CAVV
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_RESP_CAVV_KEY As String = "CAVV"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant VE status Enroled "E"
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VE_STATUS_ENROLED As String = "E"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant status not Enroled "O"
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VE_STATUS_NOT_ENROLED As String = "O"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant Status canot verify "X"
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VE_STATUS_CANNOT_VERIFY As String = "X"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant Status cardinal error "I"
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VE_STATUS_CARDINAL_ERROR As String = "I"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant Status Success "Y"
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VA_STATUS_SUCCESS As String = "Y"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VA_STATUS_FAILED As String = "N"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VA_STATUS_ATTEMPT As String = "A"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VA_STATUS_UNABLETOAUTHENTICATE As String = "U"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly VA_STATUS_UNSUCCESSFUL As String = "F"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_SUCCESS As String = "0"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_BUYER_NOT_ENROLLED As String = "1"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_READY_FOR_VE As String = "2"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_MERCHANT_NOT_CONFIGURED As String = "3"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_VE_SUCCESS As String = "4"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_PARES_OBTAINED As String = "5"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant        ''' 
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_PARES_NOT_OBTAINED As String = "6"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant        ''' 
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_FAILED As String = "7"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_ENROLLED_FOR_3D_SECURE As String = "8"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for Buyer Auth Constant
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly BAS_SKIPPED As String = "9"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constants for context variable ResponseObject
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_RESPONSEOBJECT As String = "ResponseObject"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable ErrorMessage
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_ERRORMESSAGE As String = "ErrorMessage"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable WeakAssemblyResponse
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_WEAKASSEMBLYRESPONSE As String = "WeakAssemblyResponse"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable ExceptionMessage
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_EXCEPTIONMESSAGE As String = "ExceptionMessage"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable PNREF
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_PNREF As String = "PNREF"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable ORIGID
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_ORIGID As String = "ORIGID"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable PROFILEID 
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_PROFILEID As String = "PROFILEID"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable RequestData
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_REQUESTDATA As String = "RequestData"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for context variable TempData
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly CONTEXT_TEMPDATA As String = "TempData"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for Invalid follow on Error Message
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ERRMSG_INVALIDFOLLOWON As String = "Invalid FollowOn Transaction"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for Invalid Action Error Message
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly ERRMSG_INVALIDACTION As String = "Invalid Action for the selected transaction."
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for Follow on Message
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly MSG_FOLLOWON As String = "Click on the button to perform followon transaction : "
        ''' <summary>
        ''' Constant for Global path
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly GLOBAL_PATH As String = "~"
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for Invalid Number
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly INVALID_NUM As Integer = -384783
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for Message display for Successful Transaction
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly MSG_SUCCESS As String = "Transaction Successful."
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Constant for Message display for Failed Transaction
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly MSG_FAILURE As String = "Transaction Failed."
        ''' -----------------------------------------------------------------------------
        'Added as SETTLE_DATE param is also available when VERBOSITY= MEDIUM
        '2005-12-10
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' String Constant for transaction response field SETTLE_DATE
        ''' </summary>
        ''' -----------------------------------------------------------------------------
        Public Shared ReadOnly RESP_TRANS_SETTLE_DATE As String = "SETTLE_DATE"

    End Class

End Namespace

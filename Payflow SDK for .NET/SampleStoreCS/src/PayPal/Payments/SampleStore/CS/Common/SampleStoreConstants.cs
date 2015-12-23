using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;


#region "Copyright"

//Unpublished Proprietary Program Material
//This material is proprietary to PayPal, Inc. and is not to be reproduced,
//used or disclosed except in accordance with a written license agreement
//with PayPal, Inc..
//(C) Copyright 2005  PayPal, Inc.   All Rights Reserved.
//PayPal, Inc. believes that this material furnished herewith is accurate
//and reliable.  However, no responsibility, financial or otherwise, can be
// accepted for any consequences arising out of the use of this material.

//The copyright notice above does not evidence any actual or intended
//publication of such source code.

#endregion

namespace PayPal.Payments.SampleStore.CS.Common
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This is the module file for storing the constants that will be used throughout
	/// the sample stroe application
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <history>
	/// 	[db2admin]	3/12/2005	Created
	/// </history>
	/// -----------------------------------------------------------------------------
	public sealed class SampleStoreConstants
	{
		
		//
		//String Constants for fields on the SampleStore
		//
		/// <summary>
		/// Field on SampleStore for EncryptedData.txt
		/// </summary>
		public const String FILENAME = "EncryptedData.txt";
		/// <summary>
		/// Field on SampleStore for CboAcctType
		/// </summary>
		public const String FIELD_ACCTTYPE = "CboAcctType";
		/// <summary>
		/// Field on SampleStore for CboAuthType
		/// </summary>
		public const String FIELD_AUTHTYPE = "CboAuthType";
		/// <summary>
		/// Field on SampleStore for CboBuyerAuthenticationRequired
		/// </summary>
		public const String FIELD_BAREQUIRED = "CboBuyerAuthenticationRequired";

		//Public Const FIELD_CARDTYPE As String = "CboCardType"
		/// <summary>
		/// Field on SampleStore for CboCurrency
		/// </summary>
		public const String FIELD_CURRENCY = "CboCurrency";
		/// <summary>
		/// Field on SampleStore for CboExpiryMonth
		/// </summary>
		public const String FIELD_EXPIRYMONTH = "CboExpiryMonth";
		/// <summary>
		/// Field on SampleStore for CboExpiryYear
		/// </summary>
		public const String FIELD_EXPIRYYEAR = "CboExpiryYear";

		//Public Const FIELD_PAYMENTINSTRTYPE As String = "CboPaymentInstrType"
		//public const String FIELD_PURCHASECARDSUBTYPE = "CboPurchaseCardSubType";
		/// <summary>
		/// Field on SampleStore for CboRecurring
		/// </summary>
		public const String FIELD_RECURRING = "CboRecurring";
		/// <summary>
		/// Field on SampleStore for CboRequestType
		/// </summary>
		public const String FIELD_REQUESTTYPE = "CboRequestType";
		/// <summary>
		/// Field on SampleStore for CboTender
		/// </summary>
		public const String FIELD_TENDER = "CboTender";
		/// <summary>
		/// Field on SampleStore for CboTrxType
		/// </summary>
		public const String FIELD_TRXTYPE = "CboTrxType";
		/// <summary>
		/// Field on SampleStore for CboVerbosity
		/// </summary>
		public const String FIELD_VERBOSITY = "CboVerbosity";
		/// <summary>
		/// Field on SampleStore for TxtBoxBillToStreet2
		/// </summary>
		public const String FIELD_BILLTOSTREET2 = "TxtBoxBillToStreet2";
		/// <summary>
		/// Field on SampleStore for TxtBoxAba
		/// </summary>
		public const String FIELD_ABA = "TxtBoxAba";
		/// <summary>
		/// Field on SampleStore for TxtBoxAcct
		/// </summary>
		public const String FIELD_ACCT = "TxtBoxAcct";
		/// <summary>
		/// Field on SampleStore for TxtBoxAltTaxAmt
		/// </summary>
		public const String FIELD_ALTTAXAMT = "TxtBoxAltTaxAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxAmt
		/// </summary>
		public const String FIELD_AMT = "TxtBoxAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxAuthCode
		/// </summary>
		public const String FIELD_AUTHCODE = "TxtBoxAuthCode";
		/// <summary>
		/// Field on SampleStore for TxtBoxBillToPhone2
		/// </summary>
		public const String FIELD_BILLTOPHONE2 = "TxtBoxBillToPhone2";
		/// <summary>
		/// Field on SampleStore for TxtBoxBrowserCountryCode
		/// </summary>
		public const String FIELD_BROWSERCOUNTRYCODE = "TxtBoxBrowserCountryCode";
		/// <summary>
		/// Field on SampleStore for TxtBoxBrowserTime
		/// </summary>
		public const String FIELD_BROWSERTIME = "TxtBoxBrowserTime";
		/// <summary>
		/// Field on SampleStore for TxtBoxBrowserUserAgent
		/// </summary>
		public const String FIELD_BROWSERUSERAGENT = "TxtBoxBrowserUserAgent";
		/// <summary>
		/// Field on SampleStore for TxtBoxBuyerAuthStatus
		/// </summary>
		public const String FIELD_BUYERAUTHSTATUS = "TxtBoxBuyerAuthStatus";
		
		//Public Const FIELD_CARDDESCRIPTION As String = "TxtBoxCardDescription"
		/// <summary>
		/// ield on SampleStore for TxtBoxCarrier
		/// </summary>
		public const String FIELD_CARRIER = "TxtBoxCarrier";
		/// <summary>
		/// Field on SampleStore for TxtBoxChkNum
		/// </summary>
		public const String FIELD_CHKNUM = "TxtBoxChkNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxChkType
		/// </summary>
		public const String FIELD_CHKTYPE = "TxtBoxChkType";
		/// <summary>
		/// Field on SampleStore for TxtBoxCity
		/// </summary>
		public const String FIELD_CITY = "TxtBoxCity";
		/// <summary>
		/// Field on SampleStore for TxtBoxComment1
		/// </summary>
		public const String FIELD_COMMENT1 = "TxtBoxComment1";
		/// <summary>
		/// Field on SampleStore for TxtBoxComment2
		/// </summary>
		public const String FIELD_COMMENT2 = "TxtBoxComment2";
		/// <summary>
		/// Field on SampleStore for TxtBoxCompanyName
		/// </summary>
		public const String FIELD_COMPANYNAME = "TxtBoxCompanyName";
		/// <summary>
		/// Field on SampleStore for TxtBoxCorpName
		/// </summary>
		public const String FIELD_CORPNAME = "TxtBoxCorpName";
		/// <summary>
		/// Field on SampleStore for TxtBoxCorpPurchDesc
		/// </summary>
		public const String FIELD_CORPPURCHDESC = "TxtBoxCorpPurchDesc";
		/// <summary>
		/// Field on SampleStore for TxtBoxCountry
		/// </summary>
		public const String FIELD_BILLTOCOUNTRY = "TxtBoxCountry";
		
		//Public Const FIELD_CREDITCARDNAME As String = "TxtBoxCreditCardName"
		/// <summary>
		/// Field on SampleStore for TxtBoxCustAge
		/// </summary>
		public const String FIELD_CUSTAGE = "TxtBoxCustAge";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustCode
		/// </summary>
		public const String FIELD_CUSTCODE = "TxtBoxCustCode";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustId
		/// </summary>
		public const String FIELD_CUSTID = "TxtBoxCustId";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustIp
		/// </summary>
		public const String FIELD_CUSTIP = "TxtBoxCustIp";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustMaxAge
		/// </summary>
		public const String FIELD_CUSTMAXAGE = "TxtBoxCustMaxAge";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustMinAge
		/// </summary>
		public const String FIELD_CUSTMINAGE = "TxtBoxCustMinAge";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustRef
		/// </summary>
		public const String FIELD_CUSTREF = "TxtBoxCustRef";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustTm
		/// </summary>
		public const String FIELD_CUSTTM = "TxtBoxCustTm";
		/// <summary>
		/// Field on SampleStore for TxtBoxCustVatRegNum
		/// </summary>
		public const String FIELD_CUSTVATREGNUM = "TxtBoxCustVatRegNum";
		/// <summary>
		/// Field on SampleStore forTxtBoxCvv2
		/// </summary>
		public const String FIELD_CVV2 = "TxtBoxCvv2";
		/// <summary>
		/// Field on SampleStore for TxtBoxDesc
		/// </summary>
		public const String FIELD_DESC = "TxtBoxDesc";
		/// <summary>
		/// Field on SampleStore for TxtBoxDesc1
		/// </summary>
		public const String FIELD_DESC1 = "TxtBoxDesc1";
		/// <summary>
		/// Field on SampleStore for TxtBoxDesc2
		/// </summary>
		public const String FIELD_DESC2 = "TxtBoxDesc2";
		/// <summary>
		/// Field on SampleStore for TxtBoxDesc3
		/// </summary>
		public const String FIELD_DESC3 = "TxtBoxDesc3";
		/// <summary>
		/// Field on SampleStore for TxtBoxDesc4
		/// </summary>
		public const String FIELD_DESC4 = "TxtBoxDesc4";
		/// <summary>
		/// Field on SampleStore for TxtBoxDiscount 
		/// </summary>
		public const String FIELD_DISCOUNT = "TxtBoxDiscount";
		/// <summary>
		/// Field on SampleStore for TxtBoxDL
		/// </summary>
		public const String FIELD_DL = "TxtBoxDL";
		/// <summary>
		/// Field on SampleStore for TxtBoxDob
		/// </summary>
		public const String FIELD_DOB = "TxtBoxDob";
		/// <summary>
		/// Field on SampleStore for TxtBoxDutyAmt		
		/// </summary>
		public const String FIELD_DUTYAMT = "TxtBoxDutyAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxEmail
		/// </summary>
		public const String FIELD_EMAIL = "TxtBoxEmail";
		/// <summary>
		/// Field on SampleStore for TxtBoxEndTime	
		/// </summary>
		public const String FIELD_ENDTIME = "TxtBoxEndTime";
		/// <summary>
		/// Field on SampleStore for TxtBoxFax	
		/// </summary>
		public const String FIELD_FAX = "TxtBoxFax";
		//Public Const FIELD_FINANCIALINSTITUTION As String = "TxtBoxFinancialInstitution"
		/// <summary>
		/// Field on SampleStore for TxtBoxFirstName
		/// </summary>
		public const String FIELD_FIRSTNAME = "TxtBoxFirstName";
		/// <summary>
		/// Field on SampleStore for TxtBoxMiddleName
		/// </summary>
		public const String FIELD_MIDDLENAME = "TxtBoxMiddleName";
		/// <summary>
		/// Field on SampleStore for TxtBoxForgotPwd
		/// </summary>
		public const String FIELD_FORGOTPWD = "TxtBoxForgotPwd";
		/// <summary>
		/// Field on SampleStore for TxtBoxFreightAmt
		/// </summary>
		public const String FIELD_FREIGHTAMT = "TxtBoxFreightAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxGiftcardtype
		/// </summary>
		public const String FIELD_GIFTCARDTYPE = "TxtBoxGiftcardtype";
		/// <summary>
		/// Field on SampleStore for TxtBoxGiftMsg
		/// </summary>
		public const String FIELD_GIFTMSG = "TxtBoxGiftMsg";
		/// <summary>
		/// Field on SampleStore for TxtBoxHandlingAmt
		/// </summary>
		public const String FIELD_HANDLINGAMT = "TxtBoxHandlingAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxHomePhone
		/// </summary>
		public const String FIELD_HOMEPHONE = "TxtBoxHomePhone";
		/// <summary>
		/// Field on SampleStore for TxtBoxInvNum
		/// </summary>
		public const String FIELD_INVNUM = "TxtBoxInvNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxInvoiceDate
		/// </summary>
		public const String FIELD_INVOICEDATE = "TxtBoxInvoiceDate";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Amt
		/// </summary>
		public const String FIELD_L_AMT = "TxtBoxL_Amt";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_BilledUom
		/// </summary>
		public const String FIELD_L_BILLEDUOM = "TxtBoxL_BilledUom";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_CatalogNum
		/// </summary>
		public const String FIELD_L_CATALOGNUM = "TxtBoxL_CatalogNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Category
		/// </summary>
		public const String FIELD_L_CATEGORY = "TxtBoxL_Category";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Commcode
		/// </summary>
		public const String FIELD_L_COMMCODE = "TxtBoxL_Commcode";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Cost
		/// </summary>
		public const String FIELD_L_COST = "TxtBoxL_Cost";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_CostcenterNum
		/// </summary>
		public const String FIELD_L_COSTCENTERNUM = "TxtBoxL_CostcenterNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Desc
		/// </summary>
		public const String FIELD_L_DESC = "TxtBoxL_Desc";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Discount
		/// </summary>
		public const String FIELD_L_DISCOUNT = "TxtBoxL_Discount";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_FreightAmt
		/// </summary>
		public const String FIELD_L_FREIGHTAMT = "TxtBoxL_FreightAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_FreightUom
		/// </summary>
		public const String FIELD_L_FREIGHTUOM = "TxtBoxL_FreightUom";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_HandlingAmt
		/// </summary>
		public const String FIELD_L_HANDLINGAMT = "TxtBoxL_HandlingAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_HandlingUom
		/// </summary>
		public const String FIELD_L_HANDLINGUOM = "TxtBoxL_HandlingUom";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Manufacturer
		/// </summary>
		public const String FIELD_L_MANUFACTURER = "TxtBoxL_Manufacturer";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Pickupcity
		/// </summary>
		public const String FIELD_L_PICKUPCITY = "TxtBoxL_Pickupcity";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_PickupCountry
		/// </summary>
		public const String FIELD_L_PICKUPCOUNTRY = "TxtBoxL_PickupCountry";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Pickupstate
		/// </summary>
		public const String FIELD_L_PICKUPSTATE = "TxtBoxL_Pickupstate";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Pickupstreet
		/// </summary>
		public const String FIELD_L_PICKUPSTREET = "TxtBoxL_Pickupstreet";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_PickupZip
		/// </summary>
		public const String FIELD_L_PICKUPZIP = "TxtBoxL_PickupZip";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_ProdCode
		/// </summary>
		public const String FIELD_L_PRODCODE = "TxtBoxL_ProdCode";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Qty
		/// </summary>
		public const String FIELD_L_QTY = "TxtBoxL_Qty";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Sku
		/// </summary>
		public const String FIELD_L_SKU = "TxtBoxL_Sku";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_TaxAmt
		/// </summary>
		public const String FIELD_L_TAXAMT = "TxtBoxL_TaxAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_TaxRate
		/// </summary>
		public const String FIELD_L_TAXRATE = "TxtBoxL_TaxRate";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_TaxType
		/// </summary>
		public const String FIELD_L_TAXTYPE = "TxtBoxL_TaxType";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_TrackingNum
		/// </summary>
		public const String FIELD_L_TRACKINGNUM = "TxtBoxL_TrackingNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Type
		/// </summary>
		public const String FIELD_L_TYPE = "TxtBoxL_Type";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_UnspscCode
		/// </summary>
		public const String FIELD_L_UNSPSCCODE = "TxtBoxL_UnspscCode";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Uom
		/// </summary>
		public const String FIELD_L_UOM = "TxtBoxL_Uom";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Upc
		/// </summary>
		public const String FIELD_L_UPC = "TxtBoxL_Upc";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_WeightUom
		/// </summary>
		public const String FIELD_L_WEIGHTUOM = "TxtBoxL_WeightUom";
		/// <summary>
		/// Field on SampleStore for TxtBoxL_Description
		/// </summary>
		public const String FIELD_L_Description = "TxtBoxL_Description";
		/// <summary>
		/// Field on SampleStore for TxtBoxLastName
		/// </summary>
		public const String FIELD_LASTNAME = "TxtBoxLastName";
		/// <summary>
		/// Field on SampleStore for TxtBoxLocalTaxAmt
		/// </summary>
		public const String FIELD_LOCALTAXAMT = "TxtBoxLocalTaxAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxMerchDescr
		/// </summary>
		public const String FIELD_MERCHDESCR = "TxtBoxMerchDescr";
		/// <summary>
		/// Field on SampleStore for TxtBoxMerchSvc 
		/// </summary>
		public const String FIELD_MERCHSVC = "TxtBoxMerchSvc";
		/// <summary>
		/// Field on SampleStore for TxtBoxMicr
		/// </summary>
		public const String FIELD_MICR = "TxtBoxMicr";
		/// <summary>
		/// Field on SampleStore for TxtBoxName
		/// </summary>
		public const String FIELD_NAME = "TxtBoxName";
		/// <summary>
		/// Field on SampleStore for TxtBoxNationalTaxAmt
		/// </summary>
		public const String FIELD_NATIONALTAXAMT = "TxtBoxNationalTaxAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxOrderbin
		/// </summary>
		public const String FIELD_ORDERBIN = "TxtBoxOrderbin";
		/// <summary>
		/// Field on SampleStore for TxtBoxOrderDateTime
		/// </summary>
		public const String FIELD_ORDERDATETIME = "TxtBoxOrderDateTime";
		//Public Const FIELD_ORDERNUMBER As String = "TxtBoxOrderNumber"
		/// <summary>
		/// Field on SampleStore for TxtBoxOrigId
		/// </summary>
		public const String FIELD_ORIGID = "TxtBoxOrigId";
		/// <summary>
		/// Field on SampleStore for TxtBoxPasswordGiven
		/// </summary>
		public const String FIELD_PASSWORDGIVEN = "TxtBoxPasswordGiven";
		/// <summary>
		/// Field on SampleStore for TxtBoxPhoneNum
		/// </summary>
		public const String FIELD_PHONENUM = "TxtBoxPhoneNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxPoNum
		/// </summary>
		public const String FIELD_PONUM = "TxtBoxPoNum";
		/// <summary>
		/// Field on SampleStore for CboPrenote
		/// </summary>
		public const String FIELD_PRENOTE = "CboPrenote";
		/// <summary>
		/// Field on SampleStore for TxtBoxPreviousCust
		/// </summary>
		public const String FIELD_PREVIOUSCUST = "TxtBoxPreviousCust";
		/// <summary>
		/// Field on SampleStore for TxtBoxPurDesc
		/// </summary>
		public const String FIELD_PURDESC = "TxtBoxPurDesc";
		/// <summary>
		/// Field on SampleStore for TxtBoxRegLoyalty
		/// </summary>
		public const String FIELD_REGLOYALTY = "TxtBoxRegLoyalty";
		/// <summary>
		/// Field on SampleStore for TxtBoxRegPromo
		/// </summary>
		public const String FIELD_REGPROMO = "TxtBoxRegPromo";
		/// <summary>
		/// Field on SampleStore for TxtBoxReqname
		/// </summary>
		public const String FIELD_REQNAME = "TxtBoxReqname";
		/// <summary>
		/// Field on SampleStore for TxtBoxReturnAllowed
		/// </summary>
		public const String FIELD_RETURNALLOWED = "TxtBoxReturnAllowed";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipCarrier
		/// </summary>
		public const String FIELD_SHIPCARRIER = "TxtBoxShipCarrier";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipFromzip
		/// </summary>
		public const String FIELD_SHIPFROMZIP = "TxtBoxShipFromzip";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipMentno
		/// </summary>
		public const String FIELD_SHIPMENTNO = "TxtBoxShipMentno";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipMethod
		/// </summary>
		public const String FIELD_SHIPMETHOD = "TxtBoxShipMethod";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToCity
		/// </summary>
		public const String FIELD_SHIPTOCITY = "TxtBoxShipToCity";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToCountry
		/// </summary>
		public const String FIELD_SHIPTOCOUNTRY = "TxtBoxShipToCountry";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToEmail
		/// </summary>
		public const String FIELD_SHIPTOEMAIL = "TxtBoxShipToEmail";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToFirstName
		/// </summary>
		public const String FIELD_SHIPTOFIRSTNAME = "TxtBoxShipToFirstName";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToLastName
		/// </summary>
		public const String FIELD_SHIPTOLASTNAME = "TxtBoxShipToLastName";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToMiddleName
		/// </summary>
		public const String FIELD_SHIPTOMIDDLENAME = "TxtBoxShipToMiddleName";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToPhone
		/// </summary>
		public const String FIELD_SHIPTOPHONE = "TxtBoxShipToPhone";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToPhone2
		/// </summary>
		public const String FIELD_SHIPTOPHONE2 = "TxtBoxShipToPhone2";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToState
		/// </summary>
		public const String FIELD_SHIPTOSTATE = "TxtBoxShipToState";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToStreet
		/// </summary>
		public const String FIELD_SHIPTOSTREET = "TxtBoxShipToStreet";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToStreet2
		/// </summary>
		public const String FIELD_SHIPTOSTREET2 = "TxtBoxShipToStreet2";
		/// <summary>
		/// Field on SampleStore for TxtBoxShipToZip
		/// </summary>
		public const String FIELD_SHIPTOZIP = "TxtBoxShipToZip";
		/// <summary>
		/// Field on SampleStore for TxtBoxSS
		/// </summary>
		public const String FIELD_SS = "TxtBoxSS";
		/// <summary>
		/// Field on SampleStore for TxtBoxStartTime
		/// </summary>
		public const String FIELD_STARTTIME = "TxtBoxStartTime";
		/// <summary>
		/// Field on SampleStore for TxtBoxState
		/// </summary>
		public const String FIELD_STATE = "TxtBoxState";
		/// <summary>
		/// Field on SampleStore for TxtBoxStreet
		/// </summary>
		public const String FIELD_STREET = "TxtBoxStreet";
		/// <summary>
		/// Field on SampleStore for TxtBoxSubTotal
		/// </summary>
		public const String FIELD_SUBTOTAL = "TxtBoxSubTotal";
		/// <summary>
		/// Field on SampleStore for TxtBoxSwipe
		/// </summary>
		public const String FIELD_SWIPE = "TxtBoxSwipe";
		/// <summary>
		/// Field on SampleStore for TxtBoxTaxAmt
		/// </summary>
		public const String FIELD_TAXAMT = "TxtBoxTaxAmt";
		/// <summary>
		/// Field on SampleStore for CboTaxExempt
		/// </summary>
		public const String FIELD_TAXEXEMPT = "CboTaxExempt";
		/// <summary>
		/// Field on SampleStore for TxtBoxTermCity
		/// </summary>
		public const String FIELD_TERMCITY = "TxtBoxTermCity";
		/// <summary>
		/// Field on SampleStore for TxtBoxTermState
		/// </summary>
		public const String FIELD_TERMSTATE = "TxtBoxTermState";
		/// <summary>
		/// Field on SampleStore for TxtBoxVatRegNum
		/// </summary>
		public const String FIELD_VATREGNUM = "TxtBoxVatRegNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxVatTaxAmt
		/// </summary>
		public const String FIELD_VATTAXAMT = "TxtBoxVatTaxAmt";
		/// <summary>
		/// Field on SampleStore for TxtBoxVaTaxPercent
		/// </summary>
		public const String FIELD_VATAXPERCENT = "TxtBoxVaTaxPercent";
		/// <summary>
		/// Field on SampleStore for TxtBoxWrapped
		/// </summary>
		public const String FIELD_WRAPPED = "TxtBoxWrapped";
		/// <summary>
		/// Field on SampleStore for TxtBoxZip
		/// </summary>
		public const String FIELD_ZIP = "TxtBoxZip";
		/// <summary>
		/// Field on SampleStore for TxtBoxWeakAssemblyRequest
		/// </summary>
		public static String FIELD_WEAKASSEMBLYREQUEST = "TxtBoxWeakAssemblyRequest";
		//Public Const FIELD_WEAKASSEMBLYRESPONSE As String = "TxtAreaWeakAssemblyResponse"
		/// <summary>
		/// Field on SampleStore for TxtBoxUser
		/// </summary>
		public const String FIELD_USER = "TxtBoxUser";
		/// <summary>
		/// Field on SampleStore for TxtBoxVendor
		/// </summary>
		public const String FIELD_VENDOR = "TxtBoxVendor";
		/// <summary>
		/// Field on SampleStore for TxtBoxPartner
		/// </summary>
		public const String FIELD_PARTNER = "TxtBoxPartner";
		/// <summary>
		/// Field on SampleStore for TxtBoxPassword
		/// </summary>
		public const String FIELD_PASSWORD = "TxtBoxPassword";
		/// <summary>
		/// Field on SampleStore for CboAction
		/// </summary>		
		public const String FIELD_ACTION = "CboAction";
		/// <summary>
		/// Field on SampleStore for TxtBoxProfileName
		/// </summary>
		public const String FIELD_PROFILENAME = "TxtBoxProfileName";
		/// <summary>
		/// Field on SampleStore for TxtBoxStart
		/// </summary>
		public const String FIELD_RECURRINGSTARTDATE = "TxtBoxStart";
		/// <summary>
		/// Field on SampleStore for TxtBoxTerm
		/// </summary>
		public const String FIELD_TERM = "TxtBoxTerm";
		/// <summary>
		/// Field on SampleStore for CboPayPeriod
		/// </summary>
		public const String FIELD_PAYPERIOD = "CboPayPeriod";
		/// <summary>
		/// Field on SampleStore for TxtBoxOptionalTrxAmt
		/// </summary>
		public const String FIELD_OPTIONALTRXAMT = "TxtBoxOptionalTrxAmt";
		/// <summary>
		/// Field on SampleStore for CboOptionalTrxType
		/// </summary>
		public const String FIELD_OPTIONALTRXTYPE = "CboOptionalTrxType";
		/// <summary>
		/// Field on SampleStore for TxtBoxOrigProfileId
		/// </summary>
		public const String FIELD_ORIGPROFILEID = "TxtBoxOrigProfileId";
		/// <summary>
		/// Field on SampleStore for CboPaymentHistory
		/// </summary>
		public const String FIELD_PAYMENTHISTORY = "CboPaymentHistory";
		/// <summary>
		/// Field on SampleStore for TxtBoxPaymentNum
		/// </summary>
		public const String FIELD_PAYMENTNUM = "TxtBoxPaymentNum";
		/// <summary>
		/// Field on SampleStore for TxtBoxRetryNumDays
		/// </summary>
		public const String FIELD_RETRYNUMDAYS = "TxtBoxRetryNumDays";
		/// <summary>
		/// Field on SampleStore for TxtBoxMaxFailPayments
		/// </summary>
		public const String FIELD_MAXFAILPAYMENTS = "TxtBoxMaxFailPayments";
		/// <summary>
		/// Field on SampleStore for CboUpdateAction
		/// </summary>
		public const String FIELD_UPDATEACTION = "CboUpdateAction";
		/// <summary>
		/// Field on SampleStore for TxtBoxExtend_Field1
		/// </summary>
		public const String FIELD_EXTENDFIELD1 = "TxtBoxExtend_Field1";
		/// <summary>
		/// Field on SampleStore for TxtBoxExtend_Field2
		/// </summary>
		public const String FIELD_EXTENDFIELD2 = "TxtBoxExtend_Field2";
		/// <summary>
		/// Field on SampleStore for TxtBoxProxyAddress
		/// </summary>
		public const String FIELD_PROXYADDRESS = "TxtBoxProxyAddress";
		/// <summary>
		/// Field on SampleStore for TxtBoxProxyPort
		/// </summary>
		public const String FIELD_PROXYPORT = "TxtBoxProxyPort";
		/// <summary>
		/// Field on SampleStore for TxtBoxProxyLogon
		/// </summary>
		public const String FIELD_PROXYLOGON = "TxtBoxProxyLogon";
		/// <summary>
		/// Field on SampleStore for TxtBoxProxyPassword
		/// </summary>
		public const String FIELD_PROXYPASSWORD = "TxtBoxProxyPassword";
		/// <summary>
		/// Field on SampleStore for TxtBoxRequestId
		/// </summary>
		public const String FIELD_REQUESTID = "TxtBoxRequestId";
		
		//Parameters added in sample store as on 06/05/2005
		/// <summary>
		/// Field on SampleStore for TxtBoxCommCode
		/// </summary>
		public const String FIELD_COMMCODE   = "TxtBoxCommCode";
		/// <summary>
		/// Field on SampleStore for TxtBoxOrderDate
		/// </summary>
		public const String FIELD_ORDERDATE   = "TxtBoxOrderDate";
		/// <summary>
		/// Field on SampleStore for TxtBoxOrderTime
		/// </summary>
		public const String FIELD_ORDERTIME   = "TxtBoxOrderTime";
		/// <summary>
		/// Field on SampleStore for TxtBoxShippedFromZip
		/// </summary>
		public const String FIELD_SHIPPEDFROMZIP  = "TxtBoxShippedFromZip";
		/// <summary>
		/// Field on SampleStore for TxtBoxDestCountryCode
		/// </summary>
		public const String FIELD_DESTCOUNTRYCODE   = "TxtBoxDestCountryCode";
		/// <summary>
		/// Field on SampleStore for TxtBoxBillHomePhone
		/// </summary>
		public const String FIELD_BILLHOMEPHONE   = "TxtBoxBillHomePhone";
		
		//added by prajkta 2005/05/30
		// -----------------------------------------------------------------------------
		// <summary>
		// Field on SampleStore for TxtBoxBankName
		// </summary>
		// -----------------------------------------------------------------------------
		//public const String FIELD_BANKNAME = "TxtBoxBankName";
		// -----------------------------------------------------------------------------
		// <summary>
		// Field on SampleStore for TxtBoxBankState
		// </summary>
		// -----------------------------------------------------------------------------
		//public const String FIELD_BANKSTATE  = "TxtBoxBankState";
		// -----------------------------------------------------------------------------
		// <summary>
		// Field on SampleStore for TxtBoxConsentMedium
		// </summary>
		// -----------------------------------------------------------------------------
		//public const String FIELD_CONSENTMEDIUM = "TxtBoxConsentMedium";
		// -----------------------------------------------------------------------------
		// <summary>
		// Field on SampleStore for TxtBoxCustomerType
		// </summary>
		// -----------------------------------------------------------------------------
		//public const String FIELD_CUSTOMERTYPE = "TxtBoxCustomerType";
		// -----------------------------------------------------------------------------
		// <summary>
		// Field on SampleStore for TxtBoxDLState
		// </summary>
		// -----------------------------------------------------------------------------
		//public const String FIELD_DLSTATE  = "TxtBoxDLState";
		//
		/// <summary>
		/// Field on SampleStore for TxtBoxVITIntegrationProduct
		/// </summary>
		public const String FIELD_VIT_INTEGRATION_PRODUCT   = "TxtBoxVITIntegrationProduct";
		/// <summary>
		/// Field on SampleStore for TxtBoxVITIntegrationVersion
		/// </summary>
		public const String FIELD_VIT_INTEGRATION_VERSION   = "TxtBoxVITIntegrationVersion";
		
		//String constants for Action types
		//
		/// <summary>
		/// String constant for Action type Add
		/// </summary>
		public const String ACTION_ADD = "A";
		/// <summary>
		/// String constant for Action type Modify
		/// </summary>
		public const String ACTION_MODIFY = "M";
		/// <summary>
		/// String constant for Action type INQUIRY
		/// </summary>
		public const String ACTION_INQUIRY = "I";
		/// <summary>
		/// String constant for Action type CANCEL
		/// </summary>
		public const String ACTION_CANCEL = "C";
		/// <summary>
		/// String constant for Action type REACTIVTE
		/// </summary>
		public const String ACTION_REACTIVTE = "R";
		/// <summary>
		/// String constant for Action type PAYMENT
		/// </summary>
		public const String ACTION_PAYMENT = "P";
		
		//
		//String constants for Transaction types
		//
		/// <summary>
		/// String constant for Transaction type Authroization
		/// </summary>
		public const String TRXTYPE_AUTH = "A";
		/// <summary>
		/// String constant for Transaction type Capture
		/// </summary>
		public const String TRXTYPE_CAPTURE = "D";
		/// <summary>
		/// String constant for Transaction type Sale
		/// </summary>
		public const String TRXTYPE_SALE = "S";
		/// <summary>
		/// String constant for Transaction type Credit
		/// </summary>
		public const String TRXTYPE_CREDIT = "C";
		/// <summary>
		/// String constant for Transaction type Void
		/// </summary>
		public const String TRXTYPE_VOID = "V";
		/// <summary>
		/// String constant for Transaction type Vaoice auth
		/// </summary>
		public const String TRXTYPE_VOICEAUTH = "F";
		/// <summary>
		/// String constant for Transaction type Inquiry
		/// </summary>
		public const String TRXTYPE_INQUIRY = "I";
		/// <summary>
		/// String constant for Transaction type Recurring
		/// </summary>
		public const String TRXTYPE_RECURRING = "R";
		/// <summary>
		/// String constant for Transaction type RMS Review
		/// </summary>
		public const String TRXTYPE_RMSREVIEW = "U";
		//
		//String Constant for the parameters from request
		//
		/// <summary>
		/// String Constant for the request parameter PaRes
		/// </summary>
		public const String REQUEST_PARES = "PaRes";
		
		//
		// String constant for the property names
		//
		/// <summary>
		/// String constant for the property name TermUrl
		/// </summary>
		public const String PROP_TERMURL = "TermUrl";
		/// <summary>
		/// String constant for the property name FileName
		/// </summary>
		public const String PROP_FILENAME = "FileName";
		/// <summary>
		/// String constant for the property name HostPort
		/// </summary>
		public const String PROP_HOSTPORT = "HostPort";
		/// <summary>
		/// String constant for the property name PAYFLOW_HOST
		/// </summary>
		public const String PROP_HOSTADDRESS = "PAYFLOW_HOST";
		/// <summary>
		/// String constant for the property name HostTimeout
		/// </summary>
		public const String PROP_TIMEOUT = "HostTimeout";
		/// <summary>
		/// String constant for the property name BAHostPort
		/// </summary>
		public const String PROP_BAHOSTPORT = "BAHostPort";
		/// <summary>
		/// String constant for the property name BAHostAddress
		/// </summary>
		public const String PROP_BAHOSTADDRESS = "BAHostAddress";
		/// <summary>
		/// String constant for the property name BAHostTimeout
		/// </summary>
		public const String PROP_BATIMEOUT = "BAHostTimeout";
		/// <summary>
		/// String constant for the property name User
		/// </summary>
		public const String PROP_USER = "User";
		/// <summary>
		/// String constant for the property name Vendor
		/// </summary>
		public const String PROP_VENDOR = "Vendor";
		/// <summary>
		/// String constant for the property name Partner
		/// </summary>
		public const String PROP_PARTNER = "Partner";
		/// <summary>
		/// String constant for the property name Password
		/// </summary>
		public const String PROP_PASSWORD = "Password";
		/// <summary>
		/// String constant for the property name StrongAsmbRespUrl
		/// </summary>
		public const String PROP_URL_STRONGASMBRESPURL = "StrongAsmbRespUrl";
		/// <summary>
		/// String constant for the property name SampleStoreUrl
		/// </summary>
		public const String PROP_URL_SAMPLESTOREURL = "SampleStoreUrl";
		/// <summary>
		/// String constant for the property name WeakAsmbRespUrl
		/// </summary>
		public const String PROP_URL_WEAKASMBRESPURL = "WeakAsmbRespUrl";
		/// <summary>
		/// String constant for the property name ErrorPageUrl
		/// </summary>
		public const String PROP_URL_ERRORPAGEURL = "ErrorPageUrl";
		/// <summary>
		/// String constant for the property name RedirectToACSServer
		/// </summary>
		public const String PROP_URL_REDIRECTTOACSSERVER = "RedirectToACSServer";
		//
		// String constant for the the Empty string.
		//
		/// <summary>
		/// String constant for the empty string
		/// </summary>
		public const String EMPTY_STRING = "";
		//
		// String constant for Flag values
		//
		/// <summary>
		/// String constant for Flag value YES
		/// </summary>
		public const String FLG_YES = "Y";
		/// <summary>
		/// String constant for Flag value NO
		/// </summary>
		public const String FLG_NO = "N";
		//
		//String Constants for Request type
		//
		/// <summary>
		/// String Constant for Request type strong assembly
		/// </summary>
		public const String REQUESTTYPE_STRONGASSEMBLY = "Strong Assembly - Data Objects";
		/// <summary>
		/// String Constant for Request type Week Assembly :Name Value pair
		/// </summary>
		public const String REQUESTTYPE_WEAKASSEMBLY_NVP = "Name-Value Pair";
		/// <summary>
		/// String Constant for Request type Week Assembly :XML Pay 1.0
		/// </summary>
		public const String REQUESTTYPE_WEAKASSEMBLY_XML10 = "XML Pay 1.0";
		/// <summary>
		/// String Constant for Request type Week Assembly :XML Pay 2.0
		/// </summary>
		public const String REQUESTTYPE_WEAKASSEMBLY_XML20 = "XML Pay 2.0";
		//
		//String Constant for name value delimiter
		//
		/// <summary>
		/// String Constant for name value delimiter
		/// </summary>
		public const String NV_DELIMITER = "&";
		/// <summary>
		/// String Constant for name value delimiter response
		/// </summary>
		public const String NV_DELIMITER_RESPONSE = "&";
		//
		//String Constants for Tender Type
		//
		/// <summary>
		/// String Constant for Tender Type Credit Card
		/// </summary>
		public const String TENDER_CREDITCARD = "C";
		/// <summary>
		///String Constant for Tender Type ACH 
		/// </summary>
		public const String TENDER_ACH = "A";
		/// <summary>
		/// String Constant for Tender Type TeleCheck
		/// </summary>
		public const String TENDER_TELECHECK = "K";
		//
		//String Constants for Line Item Prefix
		//
		/// <summary>
		/// String Constant for Tender Type LineItem Prefix
		/// </summary>
		public const String LINE_ITEM_PREFIX = "TxtBoxL_";
		//
		//String constants for general response fields
		//
		/// <summary>
		/// String Constant for general response field  AUTHCODE
		/// </summary>
		public const String RESP_AUTHCODE = "AUTHCODE";
		/// <summary>
		/// String Constant for general response field PNREF
		/// </summary>
		public const String RESP_PNREF = "PNREF";
		/// <summary>
		/// String Constant for general response RESPMSG
		/// </summary>
		public const String RESP_RESPMSG = "RESPMSG";
		/// <summary>
		/// String Constant for general response RESULT
		/// </summary>
		public const String RESP_RESULT = "RESULT";
		/// <summary>
		/// String Constant for general response AVSADDR
		/// </summary>
		public const String RESP_AVSADDR = "AVSADDR";
		/// <summary>
		/// String Constant for general response AVSZIP
		/// </summary>
		public const String RESP_AVSZIP = "AVSZIP";
		/// <summary>
		/// String Constant for general response CARDSECURE
		/// </summary>
		public const String RESP_CARDSECURE = "CARDSECURE";
		/// <summary>
		/// String Constant for general response CVV2MATCH
		/// </summary>
		public const String RESP_CVV2MATCH = "CVV2MATCH";
		/// <summary>
		/// String Constant for general response IAVS
		/// </summary>
		public const String RESP_IAVS = "IAVS";
		
		//
		//String constants for fraud response fields
		//
		/// <summary>
		/// String constant for fraud response field ADDLMSGS
		/// </summary>
		public const String RESP_TRANS_ADDLMSGS = "ADDLMSGS";
		/// <summary>
		/// String constant for fraud response field FPSPOSTXMLDATA
		/// </summary>
		public const String RESP_FRAUD_FPSPOSTXMLDATA = "FPSPOSTXMLDATA";
		/// <summary>
		/// String constant for fraud response field FPSPREXMLDATA
		/// </summary>
		public const String RESP_FRAUD_FPSPREXMLDATA = "FPSPREXMLDATA";
		/// <summary>
		/// String constant for fraud response field HOSTCODE
		/// </summary>
		public const String RESP_TRANS_HOSTCODE = "HOSTCODE";
		/// <summary>
		/// String constant for fraud response field POSTFPSMESSAGE
		/// </summary>
		public const String RESP_FRAUD_POSTFPSMESSAGE = "POSTFPSMESSAGE";
		/// <summary>
		/// String constant for fraud response field PREFPSMESSAGE
		/// </summary>
		public const String RESP_FRAUD_PREFPSMESSAGE = "PREFPSMESSAGE";
		/// <summary>
		/// String constant for transaction response field PROCCVV2
		/// </summary>
		public const String RESP_TRANS_PROCCVV2 = "PROCCVV2";
		/// <summary>
		/// String constant for fraud response field PROCAVS
		/// </summary>
		public const String RESP_TRANS_PROCAVS = "PROCAVS";
		/// <summary>
		/// String constant for fraud response field PROCCARDSECURE
		/// </summary>
		public const String RESP_TRANS_PROCCARDSECURE = "PROCCARDSECURE";
		/// <summary>
		/// String constant for fraud response field RESPTEXT
		/// </summary>
		public const String RESP_TRANS_RESPTEXT = "RESPTEXT";
		//Added as SETTLE_DATE param is also available when VERBOSITY= MEDIUM
		//2005-12-10
		/// <summary>
		/// String constant for transaction response field SETTLE_DATE
		/// </summary>
		public const String RESP_TRANS_SETTLE_DATE = "SETTLE_DATE";
		
		//
		// String constants for Buyer Auth constant
		//
		/// <summary>
		///  String constant for Buyer Auth constant AUTHENTICATION_STATUS
		/// </summary>
		public const String BAS_RESP_AUTHSTATUS_KEY = "AUTHENTICATION_STATUS";
		/// <summary>
		///  String constant for Buyer Auth constant AUTHENTICATION_ID
		/// </summary>
		public const String BAS_RESP_AUTHID_KEY = "AUTHENTICATION_ID";
		/// <summary>
		///  String constant for Buyer Auth constant RESPMSG
		/// </summary>
		public const String BAS_RESPMSG_KEY = "RESPMSG";
		/// <summary>
		///  String constant for Buyer Auth constant ECI
		/// </summary>
		public const String BAS_RESP_ECI_KEY = "ECI";
		/// <summary>
		///  String constant for Buyer Auth constant ACSURL
		/// </summary>
		public const String BAS_RESP_ACSURL_KEY = "ACSURL";
		/// <summary>
		///  String constant for Buyer Auth constant PAREQ
		/// </summary>
		public const String BAS_RESP_PAREQ_KEY = "PAREQ";
		/// <summary>
		///  String constant for Buyer Auth constant PaRes
		/// </summary>
		public const String BAS_RESP_PARES_KEY = "PaRes";
		/// <summary>
		///  String constant for Buyer Auth constant XID
		/// </summary>
		public const String BAS_RESP_XID_KEY = "XID";
		/// <summary>
		///  String constant for Buyer Auth constant CAVV
		/// </summary>
		public const String BAS_RESP_CAVV_KEY = "CAVV";
		/// <summary>
		///  String constant for Buyer Auth constant VE status Enroled "E"
		/// </summary>
		public const String VE_STATUS_ENROLED = "E";
		/// <summary>
		///  String constant for Buyer Auth constant status not Enroled "O"
		/// </summary>

		public const String VE_STATUS_NOT_ENROLED = "O";
		/// <summary>
		///  String constant for Buyer Auth constant Status canot verify "X"
		/// </summary>
		public const String VE_STATUS_CANNOT_VERIFY = "X";
		/// <summary>
		///  String constant for Buyer Auth constant Status cardinal error "I"
		/// </summary>
		public const String VE_STATUS_CARDINAL_ERROR = "I";
		/// <summary>
		///  String constant for Buyer Auth constant Status Success "Y"
		/// </summary>
		public const String VA_STATUS_SUCCESS = "Y";
		/// <summary>
		///  String constant for Buyer Auth constant 
		/// </summary>
		public const String VA_STATUS_FAILED = "N";
		/// <summary>
		///  String constant for Buyer Auth constant 
		/// </summary>
		public const String VA_STATUS_ATTEMPT = "A";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String VA_STATUS_UNABLETOAUTHENTICATE = "U";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String VA_STATUS_UNSUCCESSFUL = "F";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_SUCCESS = "0";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_BUYER_NOT_ENROLLED = "1";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_READY_FOR_VE = "2";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_MERCHANT_NOT_CONFIGURED = "3";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_VE_SUCCESS = "4";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_PARES_OBTAINED = "5";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_PARES_NOT_OBTAINED = "6";
		/// <summary>
		/// String Constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_FAILED = "7";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_ENROLLED_FOR_3D_SECURE = "8";
		/// <summary>
		/// String constant for Buyer Auth constant 
		/// </summary>
		public const String BAS_SKIPPED = "9";
		
		//Constants for context variables
		/// <summary>
		/// Constant for context variable ResponseObject
		/// </summary>
		public const String CONTEXT_RESPONSEOBJECT = "ResponseObject";
		/// <summary>
		/// Constant for context variable ErrorMessage
		/// </summary>
		public const String CONTEXT_ERRORMESSAGE = "ErrorMessage";
		/// <summary>
		/// Constant for context variable  WeakAssemblyResponse
		/// </summary>
		public const String CONTEXT_WEAKASSEMBLYRESPONSE = "WeakAssemblyResponse";
		/// <summary>
		/// Constant for context variable ExceptionMessage 
		/// </summary>
		public const String CONTEXT_EXCEPTIONMESSAGE = "ExceptionMessage";
		/// <summary>
		/// Constant for context variable  PNREF
		/// </summary>
		public const String CONTEXT_PNREF = "PNREF";
		/// <summary>
		/// Constant for context variable ORIGID
		/// </summary>
		public const String CONTEXT_ORIGID = "ORIGID";
		/// <summary>
		/// Constant for context variable PROFILEID
		/// </summary>
		public const String CONTEXT_PROFILEID = "PROFILEID";
		/// <summary>
		/// Constant for context variable RequestData
		/// </summary>
		public const String CONTEXT_REQUESTDATA = "RequestData";
		/// <summary>
		/// Constant for context variable TempData
		/// </summary>
		public const String CONTEXT_TEMPDATA = "TempData";		
//		/// <summary>
//		/// Constant for context variable ResponseObject
//		/// </summary>
//		public const String CONTEXT_COMMRESPONSEOBJECT = "CommResponseObject";
//		
		//Constants for Error Message
		/// <summary>
		/// onstant for Invalid follow on Error Message
		/// </summary>
		public const String ERRMSG_INVALIDFOLLOWON = "Invalid FollowOn Transaction";
		/// <summary>
		/// Constant for Invalid Action Error Message
		/// </summary>
		public const String ERRMSG_INVALIDACTION = "Invalid Action for the selected transaction.";
		
		//Constants for Message
		/// <summary>
		/// Constant for Follow on Message
		/// </summary>
		public const String MSG_FOLLOWON = "Click on the button to perform followon transaction : ";

		/// <summary>
		/// Constant for Global path
		/// </summary>
		public const String GLOBAL_PATH = "~";

		/// <summary>
		/// Constant for Invalid Number
		/// </summary>
		public const int INVALID_NUM = -384783;	

		/// <summary>
		/// Constant for Message display for Successful Transaction
		/// </summary>
		public const String MSG_SUCCESS = "Transaction Successful.";
		/// <summary>
		/// Constant for Message display for Failed Transaction
		/// </summary>								
		public const String MSG_FAILURE= "Transaction Failed.";

	}
	
}


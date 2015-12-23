Imports PayPal.Payments.SampleStore.VB.UI
Imports PayPal.Payments.SampleStore.VB.Common
Imports PayPal.Payments.SampleStore.VB.Common.SampleStoreConstants
Imports System.Reflection
Imports System.Text
Imports System.IO
Imports PayPal.Payments.DataObjects
Imports System.Xml
Imports PayPal.Payments.Common.Logging
Imports PayPal.Payments.Common.Utility


'' Namespace for SampleStore


Namespace PayPal.Payments.SampleStore.VB.Aspx
    ''' -----------------------------------------------------------------------------
    ''' Project	 : SampleStoreVB
    ''' Class	 : Payments.SampleStore.VB.Aspx.SampleStore
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' SampleStore class
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class SampleStore
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        '' Label used for setting  ORDERSEARCH


        Protected WithEvents OrderSearch As System.Web.UI.WebControls.Label

        Protected WithEvents Image1 As System.Web.UI.WebControls.Image


        '' Label used for setting  BILLEDUOM1


        Protected WithEvents LblL_BilledUom1 As System.Web.UI.WebControls.Label


        '' Label used for setting  CATALOGNUM1


        Protected WithEvents LblL_CatalogNum1 As System.Web.UI.WebControls.Label


        '' Label used for setting  COSTCENTERNUM1


        Protected WithEvents LblL_CostcenterNum1 As System.Web.UI.WebControls.Label


        '' Label used for setting  FREIGHTUOM1


        Protected WithEvents LblL_FreightUom1 As System.Web.UI.WebControls.Label


        '' Label used for setting  HANDLINGUOM1


        Protected WithEvents LblL_HandlingUom1 As System.Web.UI.WebControls.Label


        '' Label used for setting  WEIGHTUOM1


        Protected WithEvents LblL_WeightUom1 As System.Web.UI.WebControls.Label


        '' Label used for setting  UNSPSCCODE1


        Protected WithEvents LblL_UnspscCode1 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPCOUNTRY1


        Protected WithEvents LblL_PickupCountry1 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPZIP1


        Protected WithEvents LblL_PickupZip1 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPSTATE1


        Protected WithEvents LblL_PickupState1 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPCITY1


        Protected WithEvents LblL_PickupCity1 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPSTREET1


        Protected WithEvents LblL_PickupStreet1 As System.Web.UI.WebControls.Label


        '' Label used for setting  TRACKINGNUM1


        Protected WithEvents LblL_TrackingNum1 As System.Web.UI.WebControls.Label


        '' Label used for setting  HANDLINGAMT1


        Protected WithEvents LblL_HandlingAmt1 As System.Web.UI.WebControls.Label


        '' Label used for setting  FREIGHTAMT1


        Protected WithEvents LblL_FreightAmt1 As System.Web.UI.WebControls.Label


        '' Label used for setting  COMMCODE1


        Protected WithEvents LblL_CommCode1 As System.Web.UI.WebControls.Label


        '' Label used for setting  UPC1


        Protected WithEvents LblL_Upc1 As System.Web.UI.WebControls.Label


        '' Label used for setting  UOM1


        Protected WithEvents LblL_Uom1 As System.Web.UI.WebControls.Label


        '' Label used for setting  TYPE1


        Protected WithEvents LblL_Type1 As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXTYPE1


        Protected WithEvents LblL_TaxType1 As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXRATE1


        Protected WithEvents LblL_TaxRate1 As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXAMT1


        Protected WithEvents LblL_TaxAmt1 As System.Web.UI.WebControls.Label


        '' Label used for setting  SKU1


        Protected WithEvents LblL_Sku1 As System.Web.UI.WebControls.Label


        '' Label used for setting  QTY1


        Protected WithEvents LblL_Qty1 As System.Web.UI.WebControls.Label


        '' Label used for setting  PRODCODE1


        Protected WithEvents LblL_ProdCode1 As System.Web.UI.WebControls.Label


        '' Label used for setting  MANUFACTURER1


        Protected WithEvents LblL_Manufacturer1 As System.Web.UI.WebControls.Label


        '' Label used for setting  DISCOUNT1


        Protected WithEvents LblL_Discount1 As System.Web.UI.WebControls.Label


        '' Label used for setting  DESC1


        Protected WithEvents LblL_Desc1 As System.Web.UI.WebControls.Label


        '' Label used for setting  COST1


        Protected WithEvents LblL_Cost1 As System.Web.UI.WebControls.Label


        '' Label used for setting  CATEGORY1


        Protected WithEvents LblL_Category1 As System.Web.UI.WebControls.Label


        '' Label used for setting  AMT1


        Protected WithEvents LblL_Amt1 As System.Web.UI.WebControls.Label


        '' Label used for setting  BILLEDUOM0


        Protected WithEvents LblL_BilledUom0 As System.Web.UI.WebControls.Label


        '' Label used for setting  CATALOGNUM0


        Protected WithEvents LblL_CatalogNum0 As System.Web.UI.WebControls.Label


        '' Label used for setting  COSTCENTERNUM0


        Protected WithEvents LblL_CostcenterNum0 As System.Web.UI.WebControls.Label


        '' Label used for setting  FREIGHTUOM0


        Protected WithEvents LblL_FreightUom0 As System.Web.UI.WebControls.Label


        '' Label used for setting  HANDLINGUOM0


        Protected WithEvents LblL_HandlingUom0 As System.Web.UI.WebControls.Label


        '' Label used for setting  WEIGHTUOM0


        Protected WithEvents LblL_WeightUom0 As System.Web.UI.WebControls.Label


        '' Label used for setting  UNSPSCCODE0


        Protected WithEvents LblL_UnspscCode0 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPCOUNTRY0


        Protected WithEvents LblL_PickupCountry0 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPZIP0


        Protected WithEvents LblL_PickupZip0 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPSTATE0


        Protected WithEvents LblL_PickupState0 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPCITY0


        Protected WithEvents LblL_PickupCity0 As System.Web.UI.WebControls.Label


        '' Label used for setting  PICKUPSTREET0


        Protected WithEvents LblL_PickupStreet0 As System.Web.UI.WebControls.Label


        '' Label used for setting  TRACKINGNUM0


        Protected WithEvents LblL_TrackingNum0 As System.Web.UI.WebControls.Label


        '' Label used for setting  HANDLINGAMT0


        Protected WithEvents LblL_HandlingAmt0 As System.Web.UI.WebControls.Label


        '' Label used for setting  FREIGHTAMT0


        Protected WithEvents LblL_FreightAmt0 As System.Web.UI.WebControls.Label


        '' Label used for setting  COMMCODE0


        Protected WithEvents LblL_CommCode0 As System.Web.UI.WebControls.Label


        '' Label used for setting  UPC0


        Protected WithEvents LblL_Upc0 As System.Web.UI.WebControls.Label


        '' Label used for setting  UOM0


        Protected WithEvents LblL_Uom0 As System.Web.UI.WebControls.Label


        '' Label used for setting  TYPE0


        Protected WithEvents LblL_Type0 As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXTYPE0


        Protected WithEvents LblL_TaxType0 As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXRATE0


        Protected WithEvents LblL_TaxRate0 As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXAMT0


        Protected WithEvents LblL_TaxAmt0 As System.Web.UI.WebControls.Label


        '' Label used for setting  SKU0


        Protected WithEvents LblL_Sku0 As System.Web.UI.WebControls.Label


        '' Label used for setting  QTY0


        Protected WithEvents LblL_Qty0 As System.Web.UI.WebControls.Label


        '' Label used for setting  PRODCODE0


        Protected WithEvents LblL_ProdCode0 As System.Web.UI.WebControls.Label


        '' Label used for setting  MANUFACTURER0


        Protected WithEvents LblL_Manufacturer0 As System.Web.UI.WebControls.Label


        '' Label used for setting  DISCOUNT0


        Protected WithEvents LblL_Discount0 As System.Web.UI.WebControls.Label


        '' Label used for setting  DESC0


        Protected WithEvents LblL_Desc0 As System.Web.UI.WebControls.Label


        '' Label used for setting  COST0


        Protected WithEvents LblL_Cost0 As System.Web.UI.WebControls.Label


        '' Label used for setting  CATEGORY0


        Protected WithEvents LblL_Category0 As System.Web.UI.WebControls.Label


        '' Label used for setting  AMT0


        Protected WithEvents LblL_Amt0 As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  VERBOSITY


        Protected WithEvents VERBOSITY As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  VERBOSITY


        Protected WithEvents LblVerbosity As System.Web.UI.WebControls.Label


        '' Label used for setting  TERMSTATE


        Protected WithEvents LblTermState As System.Web.UI.WebControls.Label


        '' Label used for setting  TERMCITY


        Protected WithEvents LblTermCity As System.Web.UI.WebControls.Label


        '' Label used for setting  VATREGNUM


        Protected WithEvents LblVatRegNum As System.Web.UI.WebControls.Label


        '' Label used for setting  VATTAXAMT


        Protected WithEvents LblVatTaxAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  ALTTAXAMT


        Protected WithEvents LblAltTaxAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  NATIONALTAXAMT


        Protected WithEvents LblNationalTaxAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  LOCALTAXAMT


        Protected WithEvents LblLocalTaxAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXAMT


        Protected WithEvents LblTaxAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  TAXEXEMPT


        Protected WithEvents LblTaxExempt As System.Web.UI.WebControls.Label


        '' Label used for setting  SWIPE


        Protected WithEvents LblSwipe As System.Web.UI.WebControls.Label


        '' Label used for setting  SUBTOTAL


        Protected WithEvents LblSubTotal As System.Web.UI.WebControls.Label


        '' Label used for setting  ENDTIME


        Protected WithEvents LblEndTime As System.Web.UI.WebControls.Label


        '' Label used for setting  STARTTIME


        Protected WithEvents LblStartTime As System.Web.UI.WebControls.Label


        '' Label used for setting  REQNAME


        Protected WithEvents LblReqName As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  RECURRING


        Protected WithEvents RECURRING As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  RECURRING


        Protected WithEvents LblRecurring As System.Web.UI.WebControls.Label


        '' Label used for setting  PRENOTE


        Protected WithEvents LblPrenote As System.Web.UI.WebControls.Label


        '' Label used for setting  PONUM


        Protected WithEvents LblPoNum As System.Web.UI.WebControls.Label


        '' Label used for setting  PASSWORDGIVEN


        Protected WithEvents LblPasswordGiven As System.Web.UI.WebControls.Label


        '' Label used for setting  ORIGID


        Protected WithEvents LblOrigId As System.Web.UI.WebControls.Label


        '' Label used for setting  ORDERBIN


        Protected WithEvents LblOrderBin As System.Web.UI.WebControls.Label


        '' Label used for setting  MICR


        Protected WithEvents LblMicr As System.Web.UI.WebControls.Label


        '' Label used for setting  INVOICEDATE


        Protected WithEvents LblInvoiceDate As System.Web.UI.WebControls.Label


        '' Label used for setting  INVNUM


        Protected WithEvents LblInvNum As System.Web.UI.WebControls.Label


        '' Label used for setting  HANDLINGAMT


        Protected WithEvents LblHandlingAmt As System.Web.UI.WebControls.Label


        '' Label used for setting GOTPWD


        Protected WithEvents LblForgotPwd As System.Web.UI.WebControls.Label


        '' Label used for setting  DISCOUNT 


        Protected WithEvents LblDiscount As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOCOUNTRY


        Protected WithEvents LblShipToCountry As System.Web.UI.WebControls.Label


        '' Label used for setting  DESC4


        Protected WithEvents LblDesc4 As System.Web.UI.WebControls.Label


        '' Label used for setting  DESC3


        Protected WithEvents LblDesc3 As System.Web.UI.WebControls.Label


        '' Label used for setting  DESC2


        Protected WithEvents LblDesc2 As System.Web.UI.WebControls.Label


        '' Label used for setting  DESC1


        Protected WithEvents LblDesc1 As System.Web.UI.WebControls.Label


        '' Label used for setting  DESC


        Protected WithEvents LblDesc As System.Web.UI.WebControls.Label


        '' Label used for setting  CORPPURCHDESC


        Protected WithEvents LblCorpPurchDesc As System.Web.UI.WebControls.Label


        '' Label used for setting  CORPNAME


        Protected WithEvents LblCorpName As System.Web.UI.WebControls.Label


        '' Label used for setting  COMMENT2


        Protected WithEvents LblComment2 As System.Web.UI.WebControls.Label


        '' Label used for setting  COMMENT1


        Protected WithEvents LblComment1 As System.Web.UI.WebControls.Label


        '' Label used for setting  COMMCARD


        Protected WithEvents LblCommCard As System.Web.UI.WebControls.Label


        '' Label used for setting  CHKTYPE


        Protected WithEvents LblChkType As System.Web.UI.WebControls.Label


        '' Label used for setting  CHKNUM


        Protected WithEvents LblChkNum As System.Web.UI.WebControls.Label


        '' Label used for setting  BUYERAUTHSTATUS


        Protected WithEvents LblBuyerAuthStatus As System.Web.UI.WebControls.Label


        '' Label used for setting  ORDERDATETIME


        Protected WithEvents LblOrderDateTime As System.Web.UI.WebControls.Label


        '' Label used for setting  DUTYAMT


        Protected WithEvents LblDutyAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  FREIGHTAMT


        Protected WithEvents LblFreightAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  AUTHCODE


        Protected WithEvents LblAuthCode As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  ACCTTYPE


        Protected WithEvents AcctType As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  ACCTTYPE


        Protected WithEvents LblAcctType As System.Web.UI.WebControls.Label


        '' Label used for setting  ABA


        Protected WithEvents LblAba As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPMETHOD


        Protected WithEvents LblShipMethod As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPMENTNO


        Protected WithEvents LblShipMentno As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPFROMZIP


        Protected WithEvents LblShipFromzip As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPCARRIER


        Protected WithEvents LblShipCarrier As System.Web.UI.WebControls.Label


        '' Label used for setting  CARRIER


        Protected WithEvents LblCarrier As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOSTATE


        Protected WithEvents LblShipToState As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOZIP


        Protected WithEvents LblShipToZip As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOSTREET2


        Protected WithEvents LblShipToStreet2 As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOSTREET


        Protected WithEvents LblShipToStreet As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOPHONE2


        Protected WithEvents LblShipToPhone2 As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOPHONE


        Protected WithEvents LblShipToPhone As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOLASTNAME 


        Protected WithEvents LblShipToLastName As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOMIDDLENAME


        Protected WithEvents LblShipToMiddleName As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOFIRSTNAME


        Protected WithEvents LblShipToFirstName As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOEMAIL


        Protected WithEvents LblShipToEmail As System.Web.UI.WebControls.Label


        '' Label used for setting  SHIPTOCITY


        Protected WithEvents LblShipToCity As System.Web.UI.WebControls.Label


        '' Label used for setting  WRAPPED


        Protected WithEvents LblWrapped As System.Web.UI.WebControls.Label


        '' Label used for setting  GIFTMSG


        Protected WithEvents LblGiftMsg As System.Web.UI.WebControls.Label


        '' Label used for setting  GIFTCARDTYPE


        Protected WithEvents LblGiftCardType As System.Web.UI.WebControls.Label


        '' Label used for setting  RETURNALLOWED


        Protected WithEvents LblReturnAllowed As System.Web.UI.WebControls.Label


        '' Label used for setting  REGPROMO


        Protected WithEvents LblRegPromo As System.Web.UI.WebControls.Label


        '' Label used for setting  REGLOYALTY


        Protected WithEvents LblRegLoyalty As System.Web.UI.WebControls.Label


        '' Label used for setting  MERCHSVC


        Protected WithEvents LblMerchSvc As System.Web.UI.WebControls.Label


        '' Label used for setting  MERCHDESCR


        Protected WithEvents LblMerchDescr As System.Web.UI.WebControls.Label


        '' Label used for setting  BROWSERUSERAGENT


        Protected WithEvents LblBrowserUserAgent As System.Web.UI.WebControls.Label


        '' Label used for setting  BROWSERTIME


        Protected WithEvents LblBrowserTime As System.Web.UI.WebControls.Label


        '' Label used for setting  BROWSERCOUNTRYCODE


        Protected WithEvents LblBrowserCountryCode As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTTM


        Protected WithEvents LblCustTm As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTID


        Protected WithEvents LblCustId As System.Web.UI.WebControls.Label


        '' Label used for setting  BILLTOSTREET2


        Protected WithEvents LblBillToStreet2 As System.Web.UI.WebControls.Label


        '' Label used for setting  BILLTOPHONE2


        Protected WithEvents LblBillToPhone2 As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTVATREGNUM


        Protected WithEvents LblCustVatRegNum As System.Web.UI.WebControls.Label


        '' Label used for setting  LASTNAME


        Protected WithEvents LblLastName As System.Web.UI.WebControls.Label


        '' Label used for setting  FIRSTNAME 


        Protected WithEvents LblFirstName As System.Web.UI.WebControls.Label


        '' Label used for setting  PREVIOUSCUST


        Protected WithEvents LblPreviousCust As System.Web.UI.WebControls.Label


        '' Label used for setting  SSN


        Protected WithEvents LblSsn As System.Web.UI.WebControls.Label


        '' Label used for setting  SS


        Protected WithEvents LblSS As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTMINAGE


        Protected WithEvents LblCustMinAge As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTMAXAGE


        Protected WithEvents LblCustMaxAge As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTIP


        Protected WithEvents LblCustIp As System.Web.UI.WebControls.Label


        '' Label used for setting  DL


        Protected WithEvents LblDL As System.Web.UI.WebControls.Label


        '' Label used for setting  DOB


        Protected WithEvents LblDob As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTAGE


        Protected WithEvents LblCustAge As System.Web.UI.WebControls.Label


        '' Label used for setting  FAX


        Protected WithEvents LblFax As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTREF


        Protected WithEvents LblCustRef As System.Web.UI.WebControls.Label


        '' Label used for setting  CUSTCODE


        Protected WithEvents LblCustCode As System.Web.UI.WebControls.Label


        '' Label used for setting  CVV2


        Protected WithEvents LblCvv2 As System.Web.UI.WebControls.Label


        '' Label used for setting  EMAIL


        Protected WithEvents LblEmail As System.Web.UI.WebControls.Label


        '' Label used for setting  PHONENUM


        Protected WithEvents LblPhoneNum As System.Web.UI.WebControls.Label


        '' Label used for setting  ZIP


        Protected WithEvents LblZip As System.Web.UI.WebControls.Label


        '' Label used for setting  COUNTRY


        Protected WithEvents LblCountry As System.Web.UI.WebControls.Label


        '' Label used for setting  STATE


        Protected WithEvents LblState As System.Web.UI.WebControls.Label


        '' Label used for setting  CITY


        Protected WithEvents LblCity As System.Web.UI.WebControls.Label


        '' Label used for setting  NAME


        Protected WithEvents LblName As System.Web.UI.WebControls.Label


        '' Label used for setting  EXPIRYYEAR


        Protected WithEvents ExpiryYear As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  EXPIRYMONTH


        Protected WithEvents ExpiryMonth As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  EXPDATE


        Protected WithEvents LblExpDate As System.Web.UI.WebControls.Label


        '' Label used for setting  ACCT


        Protected WithEvents LblAcct As System.Web.UI.WebControls.Label


        '' Label used for setting  COMPANYNAME


        Protected WithEvents LblCompanyName As System.Web.UI.WebControls.Label


        '' Label used for setting  CARDTYPE


        Protected WithEvents CardType As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  PAYMENTINSTRTYPE


        Protected WithEvents PaymentInstrType As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  CURRENCY


        Protected WithEvents Currency As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  CURRENCY


        Protected WithEvents LblCurrency As System.Web.UI.WebControls.Label


        '' Label used for setting  AMT


        Protected WithEvents LblAmt As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  AUTHTYPE


        Protected WithEvents AuthType As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  AUTHTYPE


        Protected WithEvents LblAuthType As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  TENDER


        Protected WithEvents Tender As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  TENDER


        Protected WithEvents LblTender As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  BUYERAUTHENTICATIONREQUIRED


        Protected WithEvents BuyerAuthenticationRequired As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  BUYERAUTHENTICATIONREQUIRED


        Protected WithEvents LblBuyerAuthenticationRequired As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  TRXTYPE


        Protected WithEvents TrxType As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  TRXTYPE


        Protected WithEvents LblTrxType As System.Web.UI.WebControls.Label


        '' Label used for setting  ORDERNUMBER


        Protected WithEvents LblOrderNumber As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  REQUESTTYPE


        Protected WithEvents REQUESTTYPE As System.Web.UI.WebControls.DropDownList


        '' TextBox used for setting  REQUESTTYPE


        Protected WithEvents TxtBoxOrderNumber As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  Amt


        Protected WithEvents TxtBoxAmt As System.Web.UI.WebControls.TextBox


        '' DropDownList used for setting  PURCHASECARDSUBTYPE


        Protected WithEvents PurchaseCardSubType As System.Web.UI.WebControls.DropDownList


        '' TextBox used for setting  COMPANYNAME


        Protected WithEvents TxtBoxCompanyName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ACCT


        Protected WithEvents TxtBoxAcct As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  NAME


        Protected WithEvents TxtBoxName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CITY


        Protected WithEvents TxtBoxCity As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  STATE 


        Protected WithEvents TxtBoxState As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  COUNTRY


        Protected WithEvents TxtBoxCountry As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ZIP


        Protected WithEvents TxtBoxZip As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  PHONENUM


        Protected WithEvents TxtBoxPhoneNum As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  EMAIL


        Protected WithEvents TxtBoxEmail As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CVV2


        Protected WithEvents TxtBoxCvv2 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTCODE


        Protected WithEvents TxtBoxCustCode As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTREF


        Protected WithEvents TxtBoxCustRef As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  FAX


        Protected WithEvents TxtBoxFax As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTAGE


        Protected WithEvents TxtBoxCustAge As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DOB


        Protected WithEvents TxtBoxDob As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DL


        Protected WithEvents TxtBoxDL As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTIP


        Protected WithEvents TxtBoxCustIp As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTMAXAGE


        Protected WithEvents TxtBoxCustMaxAge As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTMINAGE


        Protected WithEvents TxtBoxCustMinAge As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SS


        Protected WithEvents TxtBoxSS As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SSN


        Protected WithEvents TxtBoxSsn As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  PREVIOUSCUST


        Protected WithEvents TxtBoxPreviousCust As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  FIRSTNAME


        Protected WithEvents TxtBoxFirstName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  LASTNAME


        Protected WithEvents TxtBoxLastName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTVATREGNUM


        Protected WithEvents TxtBoxCustVatRegNum As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  BILLTOPHONE2


        Protected WithEvents TxtBoxBillToPhone2 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTID


        Protected WithEvents TxtBoxCustId As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CUSTTM


        Protected WithEvents TxtBoxCustTm As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  BROWSERCOUNTRYCODE


        Protected WithEvents TxtBoxBrowserCountryCode As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  BROWSERTIME


        Protected WithEvents TxtBoxBrowserTime As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  BROWSERUSERAGENT


        Protected WithEvents TxtBoxBrowserUserAgent As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  MERCHDESCR


        Protected WithEvents TxtBoxMerchDescr As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  MERCHSVC 


        Protected WithEvents TxtBoxMerchSvc As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  REGLOYALTY


        Protected WithEvents TxtBoxRegLoyalty As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  REGPROMO


        Protected WithEvents TxtBoxRegPromo As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  RETURNALLOWED


        Protected WithEvents TxtBoxReturnAllowed As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  GIFTCARDTYPE


        Protected WithEvents TxtBoxGiftcardtype As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  GIFTMSG 


        Protected WithEvents TxtBoxGiftMsg As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  WRAPPED


        Protected WithEvents TxtBoxWrapped As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOCITY 


        Protected WithEvents TxtBoxShipToCity As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOEMAIL


        Protected WithEvents TxtBoxShipToEmail As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOFIRSTNAME 


        Protected WithEvents TxtBoxShipToFirstName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOMIDDLENAME


        Protected WithEvents TxtBoxShipToMiddleName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOLASTNAME


        Protected WithEvents TxtBoxShipToLastName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOPHONE


        Protected WithEvents TxtBoxShipToPhone As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOPHONE2


        Protected WithEvents TxtBoxShipToPhone2 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOSTREET


        Protected WithEvents TxtBoxShipToStreet As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOSTREET2


        Protected WithEvents TxtBoxShipToStreet2 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOZIP


        Protected WithEvents TxtBoxShipToZip As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOSTATE


        Protected WithEvents TxtBoxShipToState As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CARRIER


        Protected WithEvents TxtBoxCarrier As System.Web.UI.WebControls.TextBox

        '' TextBox used for setting  SHIPCARRIER


        Protected WithEvents TxtBoxShipCarrier As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPFROMZIP


        Protected WithEvents TxtBoxShipFromzip As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPMENTNO


        Protected WithEvents TxtBoxShipMentno As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPMETHOD


        Protected WithEvents TxtBoxShipMethod As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ABA


        Protected WithEvents TxtBoxAba As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  AuthCode


        Protected WithEvents TxtBoxAuthCode As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  FreightAmt


        Protected WithEvents TxtBoxFreightAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DUTYAMT


        Protected WithEvents TxtBoxDutyAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ORDERDATETIME


        Protected WithEvents TxtBoxOrderDateTime As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  BUYERAUTHSTATUS 


        Protected WithEvents TxtBoxBuyerAuthStatus As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CHKNUM


        Protected WithEvents TxtBoxChkNum As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CHKTYPE


        Protected WithEvents TxtBoxChkType As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  COMMCARD


        Protected WithEvents TxtBoxCommCard As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  COMMENT1


        Protected WithEvents TxtBoxComment1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  COMMENT2


        Protected WithEvents TxtBoxComment2 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CORPNAME


        Protected WithEvents TxtBoxCorpName As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  CORPPURCHDESC


        Protected WithEvents TxtBoxCorpPurchDesc As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DESC


        Protected WithEvents TxtBoxDesc As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DESC1


        Protected WithEvents TxtBoxDesc1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DESC2


        Protected WithEvents TxtBoxDesc2 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DESC3


        Protected WithEvents TxtBoxDesc3 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DESC4


        Protected WithEvents TxtBoxDesc4 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SHIPTOCOUNTRY


        Protected WithEvents TxtBoxShipToCountry As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  DISCOUNT


        Protected WithEvents TxtBoxDiscount As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting GOTPWD


        Protected WithEvents TxtBoxForgotPwd As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  HANDLINGAMT


        Protected WithEvents TxtBoxHandlingAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  INVNUM


        Protected WithEvents TxtBoxInvNum As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  INVOICEDATE


        Protected WithEvents TxtBoxInvoiceDate As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  MICR


        Protected WithEvents TxtBoxMicr As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ORDERBIN


        Protected WithEvents TxtBoxOrderbin As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ORIGID


        Protected WithEvents TxtBoxOrigId As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  PASSWORDGIVEN


        Protected WithEvents TxtBoxPasswordGiven As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  PONUM


        Protected WithEvents TxtBoxPoNum As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  PRENOTE


        Protected WithEvents TxtBoxPreNote As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  REQNAME


        Protected WithEvents TxtBoxReqname As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  STARTTIME


        Protected WithEvents TxtBoxStartTime As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ENDTIME


        Protected WithEvents TxtBoxEndTime As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SUBTOTAL


        Protected WithEvents TxtBoxSubTotal As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  SWIPE


        Protected WithEvents TxtBoxSwipe As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  TAXEXEMPT


        Protected WithEvents TxtBoxTaxExempt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  TAXAMT


        Protected WithEvents TxtBoxTaxAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  LOCALTAXAMT


        Protected WithEvents TxtBoxLocalTaxAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  NATIONALTAXAMT


        Protected WithEvents TxtBoxNationalTaxAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  ALTTAXAMT


        Protected WithEvents TxtBoxAltTaxAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  VATTAXAMT


        Protected WithEvents TxtBoxVatTaxAmt As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  VATREGNUM


        Protected WithEvents TxtBoxVatRegNum As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  TERMCITY


        Protected WithEvents TxtBoxTermCity As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  TERMSTATE


        Protected WithEvents TxtBoxTermState As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_AMT0


        Protected WithEvents TxtBoxL_Amt0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_CATEGORY0


        Protected WithEvents TxtBoxL_Category0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_COST0


        Protected WithEvents TxtBoxL_Cost0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_DESC0


        Protected WithEvents TxtBoxL_Desc0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_DISCOUNT0 


        Protected WithEvents TxtBoxL_Discount0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_MANUFACTURER0


        Protected WithEvents TxtBoxL_Manufacturer0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PRODCODE0


        Protected WithEvents TxtBoxL_ProdCode0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_QTY0


        Protected WithEvents TxtBoxL_Qty0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_SKU0


        Protected WithEvents TxtBoxL_Sku0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TAXAMT0


        Protected WithEvents TxtBoxL_TaxAmt0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TAXRATE0


        Protected WithEvents TxtBoxL_TaxRate0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TAXTYPE0


        Protected WithEvents TxtBoxL_TaxType0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TYPE0


        Protected WithEvents TxtBoxL_Type0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_UOM0


        Protected WithEvents TxtBoxL_Uom0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_UPC0


        Protected WithEvents TxtBoxL_Upc0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_COMMCODE0


        Protected WithEvents TxtBoxL_Commcode0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_FREIGHTAMT0


        Protected WithEvents TxtBoxL_FreightAmt0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_HANDLINGAMT0


        Protected WithEvents TxtBoxL_HandlingAmt0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TRACKINGNUM0


        Protected WithEvents TxtBoxL_TrackingNum0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPSTREET0 


        Protected WithEvents TxtBoxL_Pickupstreet0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPCITY0


        Protected WithEvents TxtBoxL_Pickupcity0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPSTATE0 


        Protected WithEvents TxtBoxL_Pickupstate0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPZIP0


        Protected WithEvents TxtBoxL_PickupZip0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPCOUNTRY0


        Protected WithEvents TxtBoxL_PickupCountry0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_UNSPSCCODE0 


        Protected WithEvents TxtBoxL_UnspscCode0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_WEIGHTUOM0


        Protected WithEvents TxtBoxL_WeightUom0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_HANDLINGUOM0


        Protected WithEvents TxtBoxL_HandlingUom0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_FREIGHTUOM0


        Protected WithEvents TxtBoxL_FreightUom0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  COSTCENTERNUM0


        Protected WithEvents TxtBoxL_CostcenterNum0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_CATALOGNUM0


        Protected WithEvents TxtBoxL_CatalogNum0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_BILLEDUOM0


        Protected WithEvents TxtBoxL_BilledUom0 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_AMT1


        Protected WithEvents TxtBoxL_Amt1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_CATEGORY1


        Protected WithEvents TxtBoxL_Category1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_COST1


        Protected WithEvents TxtBoxL_Cost1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_DESC1


        Protected WithEvents TxtBoxL_Desc1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_DISCOUNT1


        Protected WithEvents TxtBoxL_Discount1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_MANUFACTURER1


        Protected WithEvents TxtBoxL_Manufacturer1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PRODCODE1


        Protected WithEvents TxtBoxL_ProdCode1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_QTY1


        Protected WithEvents TxtBoxL_Qty1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_SKU1


        Protected WithEvents TxtBoxL_Sku1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TAXAMT1


        Protected WithEvents TxtBoxL_TaxAmt1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TAXRATE1


        Protected WithEvents TxtBoxL_TaxRate1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TAXTYPE1


        Protected WithEvents TxtBoxL_TaxType1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TYPE1


        Protected WithEvents TxtBoxL_Type1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_UOM1


        Protected WithEvents TxtBoxL_Uom1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_UPC1


        Protected WithEvents TxtBoxL_Upc1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_COMMCODE1 


        Protected WithEvents TxtBoxL_Commcode1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_FREIGHTAMT1


        Protected WithEvents TxtBoxL_FreightAmt1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_HANDLINGAMT1


        Protected WithEvents TxtBoxL_HandlingAmt1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_TRACKINGNUM1


        Protected WithEvents TxtBoxL_TrackingNum1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPSTREET1


        Protected WithEvents TxtBoxL_Pickupstreet1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPCITY1


        Protected WithEvents TxtBoxL_Pickupcity1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPSTATE1 


        Protected WithEvents TxtBoxL_Pickupstate1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_PICKUPZIP1


        Protected WithEvents TxtBoxL_PickupZip1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  PICKUPCOUNTRY1


        Protected WithEvents TxtBoxL_PickupCountry1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_UNSPSCCODE1


        Protected WithEvents TxtBoxL_UnspscCode1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_WEIGHTUOM1


        Protected WithEvents TxtBoxL_WeightUom1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_HANDLINGUOM1


        Protected WithEvents TxtBoxL_HandlingUom1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_FREIGHTUOM1


        Protected WithEvents TxtBoxL_FreightUom1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  L_CATALOGNUM1 


        Protected WithEvents TxtBoxL_CatalogNum1 As System.Web.UI.WebControls.TextBox


        '' Button used for setting  SUBMITTRANSACTION


        Protected WithEvents BtnSubmitTransaction As System.Web.UI.WebControls.Button


        '' TextBox used for setting  BILLTOSTREET2 


        Protected WithEvents TxtBoxBillToStreet2 As System.Web.UI.WebControls.TextBox


        '' DropDownList used for setting  REQUESTTYPE


        Protected WithEvents CboRequestType As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  TRXTYPE 


        Protected WithEvents CboTrxType As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  BUYERAUTHENTICATIONREQUIRED


        Protected WithEvents CboBuyerAuthenticationRequired As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  TENDER


        Protected WithEvents CboTender As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  AUTHTYPE


        Protected WithEvents CboAuthType As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  CURRENCY


        Protected WithEvents CboCurrency As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  EXPIRYMONTH


        Protected WithEvents CboExpiryMonth As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  EXPIRYYEAR


        Protected WithEvents CboExpiryYear As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  ACCTTYPE 


        Protected WithEvents CboAcctType As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  RECURRING


        Protected WithEvents CboRecurring As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  VERBOSITY


        Protected WithEvents CboVerbosity As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  VENDOR


        Protected WithEvents LblVendor As System.Web.UI.WebControls.Label


        '' TextBox used for setting  VENDOR


        Protected WithEvents TxtBoxVendor As System.Web.UI.WebControls.TextBox


        '' Label used for setting  USER


        Protected WithEvents LblUser As System.Web.UI.WebControls.Label


        '' TextBox used for setting  USER


        Protected WithEvents TxtBoxUser As System.Web.UI.WebControls.TextBox


        '' Label used for setting  PARTNER


        Protected WithEvents LblPartner As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PARTNER


        Protected WithEvents TxtBoxPartner As System.Web.UI.WebControls.TextBox


        '' Label used for setting  PASSWORD


        Protected WithEvents LblPassword As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PASSWORD


        Protected WithEvents TxtBoxPassword As System.Web.UI.WebControls.TextBox


        '' Label used for setting  ACTION


        Protected WithEvents LblAction As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  ACTION


        Protected WithEvents CboAction As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  PROFILENAME 


        Protected WithEvents LblProfileName As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PROFILENAME


        Protected WithEvents TxtBoxProfileName As System.Web.UI.WebControls.TextBox


        '' Label used for setting  START


        Protected WithEvents LblStart As System.Web.UI.WebControls.Label


        '' TextBox used for setting  START


        Protected WithEvents TxtBoxStart As System.Web.UI.WebControls.TextBox


        '' Label used for setting  TERM


        Protected WithEvents LblTerm As System.Web.UI.WebControls.Label


        '' TextBox used for setting  TERM


        Protected WithEvents TxtBoxTerm As System.Web.UI.WebControls.TextBox


        '' Label used for setting  PAYPERIOD


        Protected WithEvents LblPayPeriod As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  PAYPERIOD


        Protected WithEvents CboPayPeriod As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  RETRYNUMDAYS


        Protected WithEvents LblRetryNumDays As System.Web.UI.WebControls.Label


        '' TextBox used for setting  RETRYNUMDAYS


        Protected WithEvents TxtBoxRetryNumDays As System.Web.UI.WebControls.TextBox


        '' Label used for setting  MAXFAILPAYMENTS


        Protected WithEvents LblMaxFailPayments As System.Web.UI.WebControls.Label


        '' TextBox used for setting  MAXFAILPAYMENTS


        Protected WithEvents TxtBoxMaxFailPayments As System.Web.UI.WebControls.TextBox


        '' Label used for setting  OPTIONALTRXAMT


        Protected WithEvents LblOptionalTrxAmt As System.Web.UI.WebControls.Label


        '' Label used for setting  ORIGPROFILEID


        Protected WithEvents LblOrigProfileId As System.Web.UI.WebControls.Label


        '' TextBox used for setting  ORIGPROFILEID


        Protected WithEvents TxtBoxOrigProfileId As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LAMT0


        Protected WithEvents LblLAmt0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LAMT0


        Protected WithEvents TxtBoxLAmt0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCATEGORY0


        Protected WithEvents LblLCategory0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCATEGORY0


        Protected WithEvents TxtBoxLCategory0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCOST0


        Protected WithEvents LblLCost0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCOST0


        Protected WithEvents TxtBoxLCost0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LDESC0


        Protected WithEvents LblLDesc0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LDESC0


        Protected WithEvents TxtBoxLDesc0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LDISCOUNT0


        Protected WithEvents LblLDiscount0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LDISCOUNT0


        Protected WithEvents TxtBoxLDiscount0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LMANUFACTURER0


        Protected WithEvents LblLManufacturer0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LMANUFACTURER0


        Protected WithEvents TxtBoxLManufacturer0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPRODCODE0


        Protected WithEvents LblLProdCode0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPRODCODE0


        Protected WithEvents TxtBoxLProdCode0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LQTY0


        Protected WithEvents LblLQty0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LQTY0


        Protected WithEvents TxtBoxLQty0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LSKU0


        Protected WithEvents LblLSku0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LSKU0


        Protected WithEvents TxtBoxLSku0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTAXAMT0


        Protected WithEvents LblLTaxAmt0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTAXAMT0


        Protected WithEvents TxtBoxLTaxAmt0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTAXRATE0


        Protected WithEvents LblLTaxRate0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTAXRATE0


        Protected WithEvents TxtBoxLTaxRate0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTAXTYPE0


        Protected WithEvents LblLTaxType0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTAXTYPE0


        Protected WithEvents TxtBoxLTaxType0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTYPE0


        Protected WithEvents LblLType0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTYPE0


        Protected WithEvents TxtBoxLType0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LUOM0


        Protected WithEvents LblLUom0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LUOM0


        Protected WithEvents TxtBoxLUom0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LUPC0


        Protected WithEvents LblLUpc0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LUPC0


        Protected WithEvents TxtBoxLUpc0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCOMMCODE0 


        Protected WithEvents LblLCommCode0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCOMMCODE0


        Protected WithEvents TxtBoxLCommcode0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LFREIGHTAMT0


        Protected WithEvents LblLFreightAmt0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LFREIGHTAMT0


        Protected WithEvents TxtBoxLFreightAmt0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LHANDLINGAMT0


        Protected WithEvents LblLHandlingAmt0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LHANDLINGAMT0


        Protected WithEvents TxtBoxLHandlingAmt0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTRACKINGNUM0


        Protected WithEvents LblLTrackingNum0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTRACKINGNUM0


        Protected WithEvents TxtBoxLTrackingNum0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPSTREET0


        Protected WithEvents LblLPickupStreet0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPSTREET0


        Protected WithEvents TxtBoxLPickupstreet0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPCITY0


        Protected WithEvents LblLPickupCity0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPCITY0


        Protected WithEvents TxtBoxLPickupcity0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPSTATE0


        Protected WithEvents LblLPickupState0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPSTATE0 


        Protected WithEvents TxtBoxLPickupstate0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPZIP0


        Protected WithEvents LblLPickupZip0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPZIP0


        Protected WithEvents TxtBoxLPickupZip0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPCOUNTRY0


        Protected WithEvents LblLPickupCountry0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPCOUNTRY0


        Protected WithEvents TxtBoxLPickupCountry0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LUNSPSCCODE0


        Protected WithEvents LblLUnspscCode0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LUNSPSCCODE0


        Protected WithEvents TxtBoxLUnspscCode0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LWEIGHTUOM0


        Protected WithEvents LblLWeightUom0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LWEIGHTUOM0


        Protected WithEvents TxtBoxLWeightUom0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LHANDLINGUOM0


        Protected WithEvents LblLHandlingUom0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LHANDLINGUOM0 


        Protected WithEvents TxtBoxLHandlingUom0 As System.Web.UI.WebControls.TextBox


        '''Label used for setting  LFREIGHTUOM0


        Protected WithEvents LblLFreightUom0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LFREIGHTUOM0


        Protected WithEvents TxtBoxLFreightUom0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCOSTCENTERNUM0


        Protected WithEvents LblLCostcenterNum0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCOSTCENTERNUM0


        Protected WithEvents TxtBoxLCostcenterNum0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCATALOGNUM0


        Protected WithEvents LblLCatalogNum0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCATALOGNUM0


        Protected WithEvents TxtBoxLCatalogNum0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LBILLEDUOM0


        Protected WithEvents LblLBilledUom0 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LBILLEDUOM0


        Protected WithEvents TxtBoxLBilledUom0 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LAMT1 


        Protected WithEvents LblLAmt1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LAMT1


        Protected WithEvents TxtBoxLAmt1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCATEGORY1


        Protected WithEvents LblLCategory1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCATEGORY1


        Protected WithEvents TxtBoxLCategory1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCOST1


        Protected WithEvents LblLCost1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCOST1


        Protected WithEvents TxtBoxLCost1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LDESC1


        Protected WithEvents LblLDesc1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LDESC1


        Protected WithEvents TxtBoxLDesc1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LDISCOUNT1


        Protected WithEvents LblLDiscount1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LDISCOUNT1


        Protected WithEvents TxtBoxLDiscount1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LMANUFACTURER1


        Protected WithEvents LblLManufacturer1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LMANUFACTURER1


        Protected WithEvents TxtBoxLManufacturer1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPRODCODE1


        Protected WithEvents LblLProdCode1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPRODCODE1


        Protected WithEvents TxtBoxLProdCode1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LQTY1


        Protected WithEvents LblLQty1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LQTY1


        Protected WithEvents TxtBoxLQty1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LSKU1


        Protected WithEvents LblLSku1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LSKU1


        Protected WithEvents TxtBoxLSku1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTAXAMT1


        Protected WithEvents LblLTaxAmt1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTAXAMT1


        Protected WithEvents TxtBoxLTaxAmt1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTAXRATE1


        Protected WithEvents LblLTaxRate1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTAXRATE1


        Protected WithEvents TxtBoxLTaxRate1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTAXTYPE1


        Protected WithEvents LblLTaxType1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTAXTYPE1


        Protected WithEvents TxtBoxLTaxType1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTYPE1


        Protected WithEvents LblLType1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTYPE1


        Protected WithEvents TxtBoxLType1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LUOM1


        Protected WithEvents LblLUom1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LUOM1


        Protected WithEvents TxtBoxLUom1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LUPC1


        Protected WithEvents LblLUpc1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LUPC1


        Protected WithEvents TxtBoxLUpc1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCOMMCODE1


        Protected WithEvents LblLCommCode1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCOMMCODE1


        Protected WithEvents TxtBoxLCommcode1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LFREIGHTAMT1


        Protected WithEvents LblLFreightAmt1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LFREIGHTAMT1


        Protected WithEvents TxtBoxLFreightAmt1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LHANDLINGAMT1


        Protected WithEvents LblLHandlingAmt1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LHANDLINGAMT1


        Protected WithEvents TxtBoxLHandlingAmt1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LTRACKINGNUM1


        Protected WithEvents LblLTrackingNum1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LTRACKINGNUM1


        Protected WithEvents TxtBoxLTrackingNum1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPSTREET1


        Protected WithEvents LblLPickupStreet1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPSTREET1


        Protected WithEvents TxtBoxLPickupstreet1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPCITY1


        Protected WithEvents LblLPickupCity1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPCITY1


        Protected WithEvents TxtBoxLPickupcity1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPSTATE1


        Protected WithEvents LblLPickupState1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPSTATE1


        Protected WithEvents TxtBoxLPickupstate1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPZIP1


        Protected WithEvents LblLPickupZip1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPZIP1


        Protected WithEvents TxtBoxLPickupZip1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LPICKUPCOUNTRY1


        Protected WithEvents LblLPickupCountry1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LPICKUPCOUNTRY1


        Protected WithEvents TxtBoxLPickupCountry1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LUNSPSCCODE1


        Protected WithEvents LblLUnspscCode1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LUNSPSCCODE1


        Protected WithEvents TxtBoxLUnspscCode1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LWEIGHTUOM1


        Protected WithEvents LblLWeightUom1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LWEIGHTUOM1


        Protected WithEvents TxtBoxLWeightUom1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LHANDLINGUOM1


        Protected WithEvents LblLHandlingUom1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LHANDLINGUOM1


        Protected WithEvents TxtBoxLHandlingUom1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  FREIGHTUOM1


        Protected WithEvents LblLFreightUom1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  FREIGHTUOM1


        Protected WithEvents TxtBoxLFreightUom1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCOSTCENTERNUM1


        Protected WithEvents LblLCostcenterNum1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCOSTCENTERNUM1


        Protected WithEvents TxtBoxLCostcenterNum1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LCATALOGNUM1


        Protected WithEvents LblLCatalogNum1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LCATALOGNUM1


        Protected WithEvents TxtBoxLCatalogNum1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  LBILLEDUOM1


        Protected WithEvents LblLBilledUom1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  LBILLEDUOM1


        Protected WithEvents TxtBoxLBilledUom1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  STREET


        Protected WithEvents LblStreet As System.Web.UI.WebControls.Label


        '' TextBox used for setting  STREET


        Protected WithEvents TxtBoxStreet As System.Web.UI.WebControls.TextBox


        '' Label used for setting  MIDDLENAME


        Protected WithEvents LblMiddleName As System.Web.UI.WebControls.Label


        '' TextBox used for setting  MIDDLENAME


        Protected WithEvents TxtBoxMiddleName As System.Web.UI.WebControls.TextBox


        '' Label used for setting  EXTENDFIELD1


        Protected WithEvents LblExtendField1 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  EXTENDFIELD1


        Protected WithEvents TxtBoxExtendField1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  EXTENDFIELD2


        Protected WithEvents LblExtendField2 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  EXTENDFIELD2


        Protected WithEvents TxtBoxExtendField2 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  OPTIONALTRXAMT


        Protected WithEvents LblOptionalTrxType As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  OPTIONALTRXAMT


        Protected WithEvents CboOptionalTrxType As System.Web.UI.WebControls.DropDownList


        ''  TextBox used for setting  OPTIONALTRXAMT


        Protected WithEvents TxtBoxOptionalTrxAmt As System.Web.UI.WebControls.TextBox


        '' Label used for setting  PAYMENTHISTORY


        Protected WithEvents LblPaymentHistory As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  PAYMENTHISTORY 


        Protected WithEvents CboPaymentHistory As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  PAYMENTNUM


        Protected WithEvents LblPaymentNum As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PAYMENTNUM


        Protected WithEvents TxtBoxPaymentNum As System.Web.UI.WebControls.TextBox


        '' DropDownList used for setting  PRENOTE


        Protected WithEvents CboPrenote As System.Web.UI.WebControls.DropDownList


        '' DropDownList used for setting  TAXEXEMPT


        Protected WithEvents CboTaxExempt As System.Web.UI.WebControls.DropDownList


        '' Label used for setting  RMSACTION


        Protected WithEvents LblRMSAction As System.Web.UI.WebControls.Label


        '' DropDownList used for setting  UPDATEACTION


        Protected WithEvents CboUpdateAction As System.Web.UI.WebControls.DropDownList


        '' TextBox used for setting  WEAKASSEMBLYREQUEST


        Protected WithEvents TxtBoxWeakAssemblyRequest As System.Web.UI.WebControls.TextBox


        '' extBox used for setting  EXTEND_FIELD1


        Protected WithEvents TxtBoxExtend_Field1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  EXTEND_FIELD2


        Protected WithEvents TxtBoxExtend_Field2 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  WEAKASSEMBLYREQUEST


        Protected WithEvents LblWeakAssemblyRequest As System.Web.UI.WebControls.Label


        '' Label used for setting  PROXYADDRESS


        Protected WithEvents LblProxyAddress As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PROXYADDRESS


        Protected WithEvents TxtBoxProxyAddress As System.Web.UI.WebControls.TextBox


        '' Label used for setting  PROXYPORT


        Protected WithEvents LblProxyPort As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PROXYPORT


        Protected WithEvents TxtBoxProxyPort As System.Web.UI.WebControls.TextBox


        '' Label used for setting  PROXYLOGON


        Protected WithEvents LblProxyLogon As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PROXYLOGON


        Protected WithEvents TxtBoxProxyLogon As System.Web.UI.WebControls.TextBox


        '' Label used for setting  PROXYPASSWORD


        Protected WithEvents LblProxyPassword As System.Web.UI.WebControls.Label


        '' TextBox used for setting  PROXYPASSWORD


        Protected WithEvents TxtBoxProxyPassword As System.Web.UI.WebControls.TextBox


        '' Label used for setting  REQUESTTYPE


        Protected WithEvents LblRequestType As System.Web.UI.WebControls.Label


        '' Image used for setting  PayPalLOGO




        '' Label used for setting  VALIDATIONERROR  


        Protected WithEvents Lb1ValidationError As System.Web.UI.WebControls.Label


        '' Label used for setting  VALIDATIONMSG 


        Protected WithEvents Lb1ValidationMsg As System.Web.UI.WebControls.Label


        '' Table used for setting  ERROR


        Protected WithEvents TblError As System.Web.UI.WebControls.Table


        '' Label used for setting  REQUESTID


        Protected WithEvents LblRequestId As System.Web.UI.WebControls.Label


        '' TextBox used for setting  REQUESTID


        Protected WithEvents TxtBoxRequestId As System.Web.UI.WebControls.TextBox


        '' Button used for setting  FOLLOWONRECURRING


        Protected WithEvents BtnFollowOnRecurring As System.Web.UI.WebControls.Button


        '' DataGrid used for setting  RECURRING


        Protected WithEvents RecurringDataGrid As System.Web.UI.WebControls.DataGrid


        '' DataGrid used for setting  FRAUD


        Protected WithEvents FraudDataGrid As System.Web.UI.WebControls.DataGrid


        '' DataGrid used for setting  TRANSACTION


        Protected WithEvents TransactionDataGrid As System.Web.UI.WebControls.DataGrid


        '' TextBox used for setting  WEAKASSEMBLYRESPONSE


        Protected WithEvents TxtBoxWeakAssemblyResponse As System.Web.UI.WebControls.TextBox


        '' Label used for setting  HEADER


        Protected WithEvents LblHeader As System.Web.UI.WebControls.Label


        '' Button used for setting  WEAKASSEMBLYFOLLOWON


        Protected WithEvents BtnWeakAssemblyFollowOn As System.Web.UI.WebControls.Button


        '' Panel used for setting  WEAKASSEMBLYRESPONSE


        Protected WithEvents PnlWeakAssemblyResponse As System.Web.UI.WebControls.Panel


        '' Panel used for setting  SAMPLESTOREused for setting M


        Protected WithEvents PnlSampleStoreForm As System.Web.UI.WebControls.Panel


        '' Panel used for setting  STRONGASSEMBLYRESPONSE


        Protected WithEvents PnlStrongAssemblyResponse As System.Web.UI.WebControls.Panel


        '' DataGrid used for setting  Context


        Protected WithEvents ContextDataGrid As System.Web.UI.WebControls.DataGrid


        '' Panel used for setting  CONTEXTERROR


        Protected WithEvents PnlContextError As System.Web.UI.WebControls.Panel


        '' TextBox used for setting  COSTCENTERNUM38


        Protected WithEvents TxtBoxL_CostcenterNum38 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  BILLEDUOM1001


        Protected WithEvents TxtBoxL_BilledUom1001 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  COSTCENTERNUM1


        Protected WithEvents TxtBoxL_CostcenterNum1 As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  BILLEDUOM1


        Protected WithEvents TxtBoxL_BilledUom1 As System.Web.UI.WebControls.TextBox


        '' Label used for setting  COSTCENTERNUM38


        Protected WithEvents Label1 As System.Web.UI.WebControls.Label


        '' Label used for setting  CATALOGNUM101


        Protected WithEvents Label2 As System.Web.UI.WebControls.Label


        '' TextBox used for setting  CATALOGNUM101


        Protected WithEvents TxtBoxL_CatalogNum101 As System.Web.UI.WebControls.TextBox


        '' Button used for setting  RESET


        Protected WithEvents BtnReset As System.Web.UI.WebControls.Button


        '' Label used for setting  COMMCODE


        Protected WithEvents LblCommCode As System.Web.UI.WebControls.Label


        '' TextBox used for setting  COMMCODE


        Protected WithEvents TxtBoxCommCode As System.Web.UI.WebControls.TextBox


        '' Label used for setting  BILLHOMEPHONE


        Protected WithEvents LblBillHomePhone As System.Web.UI.WebControls.Label


        '' TextBox used for setting  BILLHOMEPHONE


        Protected WithEvents TxtBoxBillHomePhone As System.Web.UI.WebControls.TextBox


        '' TextBox used for setting  HOMEPHONE


        Protected WithEvents TxtBoxHomePhone As System.Web.UI.WebControls.TextBox


        '' Label used for setting  HOMEPHONE


        Protected WithEvents LblHomePhone As System.Web.UI.WebControls.Label


        '' Label used for setting  VATAXPERCENT


        Protected WithEvents LblVaTaxPercent As System.Web.UI.WebControls.Label


        '' TextBox used for setting  VATAXPERCENT


        Protected WithEvents TxtBoxVaTaxPercent As System.Web.UI.WebControls.TextBox


        '' Label used for setting  ORDERDATE


        Protected WithEvents LblOrderDate As System.Web.UI.WebControls.Label


        '' textBox used for setting  ORDERDATE


        Protected WithEvents TxtBoxOrderDate As System.Web.UI.WebControls.TextBox


        '' Label used for setting  ORDERTIME


        Protected WithEvents LblOrderTime As System.Web.UI.WebControls.Label


        '' TextBox used for setting  ORDERTIME


        Protected WithEvents TxtBoxOrderTime As System.Web.UI.WebControls.TextBox


        '' Button used for setting  FOLLOWONTRANSACTION


        Protected WithEvents BtnFollowOnTransaction As System.Web.UI.WebControls.Button

        'Protected WithEvents LblBankName As System.Web.UI.WebControls.Label

        'Protected WithEvents TxtBoxBankName As System.Web.UI.WebControls.TextBox

        'Protected WithEvents LblBankState As System.Web.UI.WebControls.Label

        'Protected WithEvents TxtBoxBankState As System.Web.UI.WebControls.TextBox

        'Protected WithEvents LblConsentMedium As System.Web.UI.WebControls.Label

        'Protected WithEvents TxtBoxConsentMedium As System.Web.UI.WebControls.TextBox

        'Protected WithEvents LblCustomerType As System.Web.UI.WebControls.Label

        'Protected WithEvents TxtBoxCustomerType As System.Web.UI.WebControls.TextBox

        'Protected WithEvents LblDLState As System.Web.UI.WebControls.Label

        'Protected WithEvents TxtBoxDLState As System.Web.UI.WebControls.TextBox


        'NOTE: The following placeholder declaration is required by the Web used for setting m Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object


        '' Label for displaying status of Transaction


        Protected WithEvents LblStatusResponse As System.Web.UI.WebControls.Label


        '' Label Header for displaying status of Transaction


        Protected WithEvents LblStatus As System.Web.UI.WebControls.Label
        'Protected WithEvents LblBankName As System.Web.UI.WebControls.Label
        'Protected WithEvents TxtBoxBankName As System.Web.UI.WebControls.TextBox
        'Protected WithEvents LblBankState As System.Web.UI.WebControls.Label
        'Protected WithEvents TxtBoxBankState As System.Web.UI.WebControls.TextBox
        'Protected WithEvents LblConsentMedium As System.Web.UI.WebControls.Label
        'Protected WithEvents TxtBoxConsentMedium As System.Web.UI.WebControls.TextBox
        'Protected WithEvents LblCustomerType As System.Web.UI.WebControls.Label
        'Protected WithEvents TxtBoxCustomerType As System.Web.UI.WebControls.TextBox
        'Protected WithEvents LblDLState As System.Web.UI.WebControls.Label
        'Protected WithEvents TxtBoxDLState As System.Web.UI.WebControls.TextBox


        '' Button for traversing BACK in case of error on Strong Assembly


        Protected WithEvents BtnStrongBack As System.Web.UI.WebControls.Button



        '' Label for VITIntegrationProduct


        Protected WithEvents LblVITIntegrationProduct As System.Web.UI.WebControls.Label


        '' TextBox for VITIntegrationProduct


        Protected WithEvents TxtBoxVITIntegrationProduct As System.Web.UI.WebControls.TextBox


        '' Label for VITIntegrationVersion


        Protected WithEvents LblVITIntegrationVersion As System.Web.UI.WebControls.Label

        '' TextBox for VITIntegrationVersion

        Protected WithEvents TxtBoxVITIntegrationVersion As System.Web.UI.WebControls.TextBox

        Protected WithEvents ImgPayPalLogo As System.Web.UI.WebControls.Image

        '' Button used for going BACK in case of Context error


        Protected WithEvents BtnBack As System.Web.UI.WebControls.Button
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes the page
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[db2admin]	6/17/2005	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web used for setting m Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not IsPostBack Then
                DisplaySampleStore()
            End If
        End Sub
        Private Sub DisplaySampleStore()
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.DisplaySampleStore(): Entered", PayflowConstants.SEVERITY_DEBUG)

            PnlStrongAssemblyResponse.Visible = False
            PnlSampleStoreForm.Visible = True
            PnlWeakAssemblyResponse.Visible = False
            ContextDataGrid.Visible = False
            TblError.Visible = False
            LblStatus.Visible = False
            LblStatusResponse.Visible = False

            Dim OrigId As String = System.Convert.ToString(ViewState.Item(CONTEXT_ORIGID))
            Dim ProfileId As String = System.Convert.ToString(ViewState.Item(CONTEXT_PROFILEID))

            If Not (Object.Equals(OrigId, Nothing) Or _
                    Object.Equals(OrigId, EMPTY_STRING)) Then

                SetDataInFields()
                If CboRequestType.Items(CboRequestType.SelectedIndex).Value = REQUESTTYPE_STRONGASSEMBLY Then
                    EnableControls(True)
                    TxtBoxWeakAssemblyRequest.ReadOnly = True
                Else
                    EnableControls(False)
                    TxtBoxWeakAssemblyRequest.ReadOnly = False
                End If
                TxtBoxOrigId.Text = OrigId
            ElseIf Not (Object.Equals(ProfileId, Nothing) Or _
                    Object.Equals(ProfileId, EMPTY_STRING)) Then

                SetDataInFields()
                TxtBoxOrigProfileId.Text = ProfileId
            Else
                SetValueInFields(CboRequestType.Items(CboRequestType.SelectedIndex).Value)
            End If
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.DisplaySampleStore(): Exiting", PayflowConstants.SEVERITY_DEBUG)
        End Sub
        Private Sub SetDataInFields()
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetDataInFields(): Entered", PayflowConstants.SEVERITY_DEBUG)
            Dim RequestData As New Hashtable
            Dim KeysColl As System.Collections.ICollection
            Dim KeysEnum As System.Collections.IEnumerator
            Dim Ctrl As Control

            RequestData = CType(Context.Items(CONTEXT_REQUESTDATA), Hashtable)
            KeysColl = RequestData.Keys()
            KeysEnum = KeysColl.GetEnumerator()

            While KeysEnum.MoveNext
                If KeysEnum.Current().ToString().StartsWith("TxtBox") Then
                    Ctrl = Me.FindControl(KeysEnum.Current().ToString())
                    CType(Ctrl, TextBox).Text = System.Convert.ToString(RequestData.Item(KeysEnum.Current().ToString))
                ElseIf KeysEnum.Current().ToString().StartsWith("Cbo") Then
                    Ctrl = Me.FindControl(KeysEnum.Current().ToString())
                    CType(Ctrl, DropDownList).SelectedValue = System.Convert.ToString(RequestData.Item(KeysEnum.Current().ToString))
                End If
            End While
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetDataInFields(): Exiting", PayflowConstants.SEVERITY_DEBUG)
        End Sub
        Private Shared Function CheckIfFollowOnValid(ByVal TrxType As String) As Boolean
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.CheckIfFollowOnValid(): Entered", PayflowConstants.SEVERITY_DEBUG)
            Dim RetVal As Boolean
            If Object.Equals(TrxType, TRXTYPE_VOICEAUTH) Then
                RetVal = False
            Else
                RetVal = True
            End If
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.UI.Controller.CheckIfFollowOnValid(String) : Returning - " + RetVal.ToString, PayflowConstants.SEVERITY_INFO)
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.CheckIfFollowOnValid(): Exiting", PayflowConstants.SEVERITY_DEBUG)
            Return RetVal
        End Function
        Private Sub EnableControls(ByVal Mode As Boolean)
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.EnableControls(Boolean): Entered", PayflowConstants.SEVERITY_DEBUG)
            Dim PanelCtrlColl As System.WEB.UI.ControlCollection
            Dim ControlInPanel As System.Web.UI.Control
            Dim TextBoxControl As System.Web.UI.WebControls.TextBox
            Dim DropDownControl As System.Web.UI.WebControls.DropDownList

            PanelCtrlColl = PnlSampleStoreForm.Controls

            For Each ControlInPanel In PanelCtrlColl
                If TypeOf ControlInPanel Is System.Web.UI.WebControls.TextBox Then
                    If ControlInPanel.ID = FIELD_REQUESTID Then
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = False
                    ElseIf ControlInPanel.ID = FIELD_VIT_INTEGRATION_PRODUCT Then
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = False
                    ElseIf ControlInPanel.ID = FIELD_VIT_INTEGRATION_VERSION Then
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = False
                    ElseIf ControlInPanel.ID = FIELD_PROXYADDRESS Then
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = False
                    ElseIf ControlInPanel.ID = FIELD_PROXYPORT Then
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = False
                    ElseIf ControlInPanel.ID = FIELD_PROXYLOGON Then
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = False
                    ElseIf ControlInPanel.ID = FIELD_PROXYPASSWORD Then
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = False
                    Else
                        TextBoxControl = CType(ControlInPanel, System.Web.UI.WebControls.TextBox)
                        TextBoxControl.ReadOnly = Not Mode
                    End If
                ElseIf TypeOf ControlInPanel Is System.Web.UI.WebControls.DropDownList Then
                    If Not ControlInPanel.ID = FIELD_REQUESTTYPE Then
                        DropDownControl = CType(ControlInPanel, System.Web.UI.WebControls.DropDownList)
                        DropDownControl.Enabled = Mode
                    End If
                End If
            Next
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.EnableControls(Boolean): Exiting", PayflowConstants.SEVERITY_DEBUG)
        End Sub
        Private Sub SetSADefaultValues()
            Dim Util As New SampleStoreUtil
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetSADefaultValues(): Entered", PayflowConstants.SEVERITY_DEBUG)
            Util.SetValueInDropDown(CboTender, "Credit Card")
            Util.SetValueInDropDown(CboTrxType, "Sale")
            Util.SetValueInDropDown(CboExpiryMonth, "January")
            Util.SetValueInDropDown(CboExpiryYear, "2009")
            Util.SetValueInDropDown(CboCurrency, "")
            TxtBoxPartner.Text = "partner"
            TxtBoxUser.Text = "user"
            TxtBoxVendor.Text = "vendor"
            TxtBoxAmt.Text = "25.00"
            TxtBoxAcct.Text = "5100000000000008"
            TxtBoxInvNum.Text = "INV12345"
            TxtBoxPoNum.Text = "PO12345"
            TxtBoxStreet.Text = "123 Main St."
            TxtBoxZip.Text = "12345"
            TxtBoxCvv2.Text = "123"
            TxtBoxVITIntegrationProduct.Text = "PYPL_dotNET_VBSampleStore"
            TxtBoxVITIntegrationVersion.Text = "1.0"
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetSADefaultValues(): Exiting", PayflowConstants.SEVERITY_DEBUG)
        End Sub
        Private Sub SetWADefaultValues()
            Dim Util As New SampleStoreUtil
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetWADefaultValues(): Entered", PayflowConstants.SEVERITY_DEBUG)
            TxtBoxVITIntegrationProduct.Text = "PYPL_dotNET_VBSampleStore"
            TxtBoxVITIntegrationVersion.Text = "1.0"
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetSADefaultValues(): Exiting", PayflowConstants.SEVERITY_DEBUG)
        End Sub
        Private Sub SetValueInFields(ByVal SelectedValue As String)
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetValueInFields(String): Entered", PayflowConstants.SEVERITY_DEBUG)
            If SelectedValue = REQUESTTYPE_STRONGASSEMBLY Then
                EnableControls(True)
                SetSADefaultValues()
                TxtBoxWeakAssemblyRequest.ReadOnly = True
                TxtBoxWeakAssemblyRequest.Text = ""
                TxtBoxRequestId.Text = ""
                LblWeakAssemblyRequest.Text = "NAME-VALUE PAIR REQUEST"
            ElseIf SelectedValue = REQUESTTYPE_WEAKASSEMBLY_NVP Then
                EnableControls(False)
                SetWADefaultValues()
                TxtBoxWeakAssemblyRequest.ReadOnly = False
                TxtBoxWeakAssemblyRequest.Text = "TRXTYPE=S&ACCT=5105105105105100&EXPDATE=0109&TENDER=C&INVNUM=INV12345&AMT=25.12&PONUM=PO12345&STREET=123 Main St.&ZIP=12345&CVV2=123&USER=<user>&VENDOR=<vendor>&PARTNER=<partner>&PWD=<password>"
                LblWeakAssemblyRequest.Text = "NAME-VALUE PAIR REQUEST"
                'ElseIf SelectedValue = REQUESTTYPE_WEAKASSEMBLY_XML10 Then
                '    EnableControls(False)
                '    TxtBoxWeakAssemblyRequest.ReadOnly = False
                '    TxtBoxWeakAssemblyRequest.Text = "<?xml version='1.0'?><XMLPayRequest Timeout='30' version='1.0'> <RequestData> <Vendor>OIPTestAcct</Vendor> <Partner>ReSellerA</Partner> <Transactions> <Transaction> <Sale> <PayData> <Invoice> <NationalTaxIncl>N</NationalTaxIncl> <TotalAmt>100.01</TotalAmt> </Invoice> <Tender> <Card> <CardType>visa</CardType> <CardNum>5105105105105100</CardNum> <ExpDate>200911</ExpDate> <NameOnCard>Joe Smith</NameOnCard> </Card> </Tender> </PayData> </Sale> </Transaction> </Transactions> </RequestData> <RequestAuth> <UserPass> <User>OIPTestAcct</User> <Password>infosys123</Password> </UserPass> </RequestAuth> </XMLPayRequest>"
                '    LblWeakAssemblyRequest.Text = "XML PAY 1.0 REQUEST"
            ElseIf SelectedValue = REQUESTTYPE_WEAKASSEMBLY_XML20 Then
                EnableControls(False)
                SetWADefaultValues()
                TxtBoxWeakAssemblyRequest.ReadOnly = False
                TxtBoxWeakAssemblyRequest.Text = "<?xml version='1.0'?><XMLPayRequest Timeout='45' version='2.0'><RequestData><Partner>partner</Partner><Vendor>vendor</Vendor><Transactions><Transaction><Sale><PayData><Invoice><TotalAmt Currency='USD'>25.12</TotalAmt><InvNum>INV12345</InvNum><BillTo><PONum>PO12345</PONum><Address><Street>123 Main St.</Street><Zip>12345</Zip></Address></BillTo></Invoice><Tender><Card><CardNum>5105105105105100</CardNum><ExpDate>200901</ExpDate><CVNum>123</CVNum></Card></Tender></PayData></Sale></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>user</User><Password>password</Password></UserPass></RequestAuth></XMLPayRequest>"
                LblWeakAssemblyRequest.Text = "XMLPAY 2.0 REQUEST"
            End If
            TblError.Visible = False
            TxtBoxOrigId.Text = ""
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SetValueInFields(String): Entered", PayflowConstants.SEVERITY_DEBUG)
        End Sub
        Private Sub CboRequestType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRequestType.SelectedIndexChanged
            SetValueInFields(CboRequestType.Items(CboRequestType.SelectedIndex).Value)
        End Sub
        Private Function ValidateStrongAssembly() As Boolean
            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.ValidateMe(): Entered", PayflowConstants.SEVERITY_DEBUG)
            Dim HasError As Boolean
            Dim ErrorMessage As String = ""

            If Not (Object.Equals(TxtBoxOrigId.Text, Nothing) Or _
                    Object.Equals(TxtBoxOrigId.Text, EMPTY_STRING)) Then
                If Not CheckIfFollowOnValid(CboTrxType.Items(CboTrxType.SelectedIndex).Value) Then
                    HasError = True
                    ErrorMessage = ERRMSG_INVALIDFOLLOWON
                End If
            End If

            If Object.Equals(CboAction.Items(CboAction.SelectedIndex).Value, Nothing) Or _
            Object.Equals(CboAction.Items(CboAction.SelectedIndex).Value, "") And _
            Object.Equals(CboTrxType.Items(CboTrxType.SelectedIndex).Value, TRXTYPE_RECURRING) Then
                HasError = True
                If ErrorMessage.Length > 0 Then
                    ErrorMessage += "<BR>"
                End If
                ErrorMessage += ERRMSG_INVALIDACTION
            End If

            If HasError Then
                TblError.Visible = True
                Lb1ValidationError.Text = "Validation Error"
                Lb1ValidationMsg.Text = ErrorMessage
            End If

            Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.ValidateMe(): Exiting", PayflowConstants.SEVERITY_DEBUG)
            Return HasError

        End Function
        Private Sub SubmitForm()
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SubmitForm(): Entered", PayflowConstants.SEVERITY_DEBUG)
                Dim objController As Controller

                If Object.Equals(REQUESTTYPE_STRONGASSEMBLY, Request.Item(FIELD_REQUESTTYPE)) Then
                    If Not ValidateStrongAssembly() Then
                        objController = New Controller(Request, Context, Server)
                        DisplayStrongAssemblyResponse()
                    End If
                Else
                    objController = New Controller(Request, Context, Server)
                    DisplayWeakAssemblyResponse()
                End If


                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.SubmitForm(): Exiting", PayflowConstants.SEVERITY_DEBUG)
            Catch taex As Threading.ThreadAbortException
                'Do nothing. If removed, throws error during redirecting
                'Catch baex As Exceptions.BaseException
                '   HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & baex.ToString())
            Catch Ex As Exception
                'Context.Items.Add(CONTEXT_EXCEPTIONMESSAGE, Ex.Message)
                'Server.Transfer(ErrorPageUrl.ToString)
                Dim WAError As New Hashtable
                WAError.Add("Error Message", Ex.Message)
                ContextDataGrid.DataSource = WAError
                ContextDataGrid.DataBind()
                PnlStrongAssemblyResponse.Visible = False
                PnlSampleStoreForm.Visible = False
                PnlWeakAssemblyResponse.Visible = False
                ContextDataGrid.Visible = True
                BtnFollowOnTransaction.Visible = False
                BtnBack.Visible = True
                BtnStrongBack.Visible = False

            End Try
        End Sub
        Private Function IsErrorInWAResponse(ByVal WAResponse As String) As Boolean
            Dim RetVal As Boolean
            If Not WAResponse.IndexOf("<XMLPay") >= 0 Then
                If WAResponse.IndexOf("RESULT") < 0 Then
                    RetVal = True
                End If
            End If
            Return RetVal
        End Function
        Private Sub DisplayWeakAssemblyResponse()
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.WeakAssemblyResponse(): Entered", PayflowConstants.SEVERITY_DEBUG)
                Dim ResponseData As Hashtable = New Hashtable
                Dim Util As New SampleStoreUtil
                Dim Response As String = CType(Context.Items(CONTEXT_WEAKASSEMBLYRESPONSE), String)
                Dim TransResponse As String = ""
                'Dim Resps() As String
                Dim StatusTransResponse As String = ""


                If Response.IndexOf("^") > 0 Then
                    StatusTransResponse = Response.Substring(0, Response.IndexOf("^"))
                    TransResponse = "Transaction Response :" + vbCrLf + StatusTransResponse
                End If

                Response = TransResponse

                TxtBoxWeakAssemblyResponse.Text = Response + vbCrLf

                LblStatus.Visible = True
                LblStatusResponse.Visible = True
                LblStatusResponse.Text = PayflowUtility.GetStatus(StatusTransResponse)

                If (StatusTransResponse.IndexOf("<XMLPayResponse") >= 0) Then
                    StatusTransResponse = PayflowUtility.GetXmlPayNodeValue(StatusTransResponse, "Result")
                Else
                    StatusTransResponse = PayflowUtility.LocateValueForName(StatusTransResponse, "RESULT", False)
                End If

                If ("0".Equals(StatusTransResponse)) Then
                    LblStatusResponse.ForeColor = System.Drawing.Color.Green
                Else
                    LblStatusResponse.ForeColor = System.Drawing.Color.Red
                End If

                ViewState.Add(CONTEXT_TEMPDATA, Context.Items(CONTEXT_REQUESTDATA))

                If Response.IndexOf("<XMLPay") >= 0 Then

                    'The following line has been added to trim extra string before the xml response
                    Response = Response.Substring(Response.IndexOf("<XMLPay"), (Response.Length() - Response.IndexOf("<XMLPay")))

                    Dim textReader As New System.IO.StringReader(Response)
                    Dim reader As New System.Xml.XmlTextReader(textReader)
                    Do While (reader.Read())
                        If reader.NodeType = XmlNodeType.Element Then
                            If reader.Name.ToUpper = "PNREF" Then
                                ViewState.Add(CONTEXT_ORIGID, reader.ReadString())
                                Exit Do
                            End If
                        End If
                    Loop
                Else
                    ResponseData = Util.ConvertStringToHashTbl(Response, NV_DELIMITER)
                    If Not (Object.Equals(ResponseData.Item("PNREF"), EMPTY_STRING) Or _
                        Object.Equals(ResponseData.Item("PNREF"), Nothing)) Then
                        ViewState.Add(CONTEXT_ORIGID, ResponseData.Item("PNREF").ToString)
                    End If

                End If

                If IsErrorInWAResponse(Response) Then
                    Context.Items.Add(CONTEXT_ERRORMESSAGE, Response)
                    Dim WAError As New Hashtable
                    WAError.Add("Error Message", Response)
                    ContextDataGrid.DataSource = WAError
                    ContextDataGrid.DataBind()
                    ContextDataGrid.Visible = True
                    BtnWeakAssemblyFollowOn.Visible = False
                    PnlWeakAssemblyResponse.Visible = False
                Else
                    BtnWeakAssemblyFollowOn.Visible = True
                    PnlWeakAssemblyResponse.Visible = True
                End If
                PnlStrongAssemblyResponse.Visible = False
                PnlSampleStoreForm.Visible = False
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.WeakAssemblyResponse(): Exiting", PayflowConstants.SEVERITY_DEBUG)
            Catch Ex As Exception
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Sub
        Private Sub DisplayStrongAssemblyResponse()
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.StrongAssemblyResponse(): Entered", PayflowConstants.SEVERITY_DEBUG)
                Dim TransactionResponse As New Hashtable
                Dim RecurringResponse As New Hashtable
                Dim FraudResponse As New Hashtable
                Dim ContextResponse As New Hashtable
                Dim ValColl As System.Collections.ICollection
                Dim ValEnum As System.Collections.IEnumerator
                Dim Response As Object = Context.Items("ResponseObject")
                Dim responsedata As PayPal.Payments.DataObjects.Response

                responsedata = CType(Response, PayPal.Payments.DataObjects.Response)

                ViewState.Add(CONTEXT_TEMPDATA, Context.Items(CONTEXT_REQUESTDATA))

                TransactionResponse = GetResponseInHashTbl(responsedata, "Transaction")

                If Not Object.Equals(TransactionResponse, Nothing) Then
                    If Not (Object.Equals(TransactionResponse.Item("PNREF"), Nothing) Or _
                    Object.Equals(TransactionResponse.Item("PNREF"), EMPTY_STRING)) Then
                        ViewState.Add(CONTEXT_ORIGID, TransactionResponse.Item("PNREF").ToString)
                        BtnFollowOnTransaction.Visible = True
                    Else
                        BtnFollowOnTransaction.Visible = False
                    End If

                    TransactionDataGrid.DataSource = TransactionResponse
                    TransactionDataGrid.DataBind()
                End If

                Dim TrxResult As String
                TrxResult = CType(TransactionResponse.Item("RESULT"), String)

                RecurringResponse = GetResponseInHashTbl(responsedata, "Recurring")
                BtnFollowOnRecurring.Visible = False
                RecurringDataGrid.Visible = False
                If Not Object.Equals(RecurringResponse, Nothing) Then
                    ValColl = RecurringResponse.Values
                    ValEnum = ValColl.GetEnumerator()
                    While ValEnum.MoveNext
                        If Not (Object.Equals(ValEnum.Current, Nothing) Or _
                        Object.Equals(ValEnum.Current, EMPTY_STRING)) Then

                            If Not (Object.Equals(RecurringResponse.Item("PROFILEID"), Nothing) Or _
                                Object.Equals(RecurringResponse.Item("PROFILEID"), EMPTY_STRING)) Then
                                ViewState.Add(CONTEXT_PROFILEID, RecurringResponse.Item("PROFILEID").ToString)
                                'LblProfileId.Text = "Click on the button to perform recurring follow on transaction :"
                                BtnFollowOnRecurring.Visible = True
                                RecurringDataGrid.Visible = True
                            Else
                                'LblProfileId.Text = ""
                                BtnFollowOnRecurring.Visible = False
                                RecurringDataGrid.Visible = False
                            End If

                            RecurringDataGrid.DataSource = RecurringResponse
                            RecurringDataGrid.DataBind()
                            Exit While
                        End If
                    End While
                End If


                FraudResponse = GetResponseInHashTbl(responsedata, "Fraud")
                If Not Object.Equals(FraudResponse, Nothing) Then
                    ValColl = FraudResponse.Values
                    ValEnum = ValColl.GetEnumerator()
                    While ValEnum.MoveNext
                        If Not (Object.Equals(ValEnum.Current, Nothing) Or _
                        Object.Equals(ValEnum.Current, EMPTY_STRING)) Then
                            FraudDataGrid.DataSource = FraudResponse
                            FraudDataGrid.DataBind()
                            Exit While
                        End If
                    End While
                End If

                ContextResponse = GetResponseInHashTbl(responsedata, "Context")
                If Not Object.Equals(ContextResponse, Nothing) Then
                    ValColl = ContextResponse.Values
                    ValEnum = ValColl.GetEnumerator()
                    While ValEnum.MoveNext
                        If Not (Object.Equals(ValEnum.Current, Nothing) Or _
                        Object.Equals(ValEnum.Current, EMPTY_STRING)) Then
                            ContextDataGrid.DataSource = ContextResponse
                            ContextDataGrid.DataBind()
                            ContextDataGrid.Visible = True
                            Exit While
                        End If
                    End While
                End If

                PnlStrongAssemblyResponse.Visible = True
                PnlSampleStoreForm.Visible = False
                PnlWeakAssemblyResponse.Visible = False
                LblStatus.Visible = True
                LblStatusResponse.Visible = True
                Dim TrxSuccess As Boolean
                TrxSuccess = "0".Equals(TrxResult)

                If Not (TrxSuccess) Then
                    LblStatusResponse.Text = SampleStoreConstants.MSG_FAILURE
                    LblStatusResponse.ForeColor = System.Drawing.Color.Red
                Else
                    LblStatusResponse.Text = SampleStoreConstants.MSG_SUCCESS
                    LblStatusResponse.ForeColor = System.Drawing.Color.Green
                End If


                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.StrongAssemblyResponse(): Exiting", PayflowConstants.SEVERITY_DEBUG)
            Catch Ex As Exception
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Sub
        Private Shared Function GetResponseInHashTbl(ByVal Response As Response, ByVal ResponseType As String) As Hashtable
            Try
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.GetResponseInHashTbl(Response,As String): Entered", PayflowConstants.SEVERITY_DEBUG)
                Dim RetVal As New Hashtable
                Select Case ResponseType
                    Case "Transaction"
                        Dim obj As TransactionResponse = Response.TransactionResponse()
                        If Object.Equals(obj, Nothing) Then
                            Exit Select
                        End If

                        RetVal.Add("AUTHCODE", obj.AuthCode)
                        RetVal.Add("AVSADDR", obj.AVSAddr)
                        RetVal.Add("AVSZIP", obj.AVSZip)
                        RetVal.Add("CARDSECURE", obj.CardSecure)
                        RetVal.Add("CVV2MATCH", obj.CVV2Match)
                        RetVal.Add("IAVS", obj.IAVS)
                        RetVal.Add("PNREF", obj.Pnref)
                        RetVal.Add("REQUEST", Response.RequestString)
                        RetVal.Add("REQUESTID", Response.RequestId)
                        RetVal.Add("RESPMSG", obj.RespMsg)
                        RetVal.Add("RESPONSE", Response.ResponseString)
                        If Not Object.Equals(obj.Result, Nothing) Then
                            RetVal.Add("RESULT", obj.Result.ToString())
                        End If
                        RetVal.Add("CUSTREF", obj.CustRef)
                        RetVal.Add("ORIGRESULT", obj.OrigResult)
                        RetVal.Add("TRANSSTATE", obj.TransState)
                        RetVal.Add("STARTTIME", obj.StartTime)
                        RetVal.Add("ENDTIME", obj.EndTime)
                        RetVal.Add(RESP_TRANS_ADDLMSGS, obj.AddlMsgs)
                        RetVal.Add(RESP_TRANS_HOSTCODE, obj.HostCode)
                        RetVal.Add(RESP_TRANS_PROCAVS, obj.ProcAVS)
                        RetVal.Add(RESP_TRANS_PROCCARDSECURE, obj.ProcCardSecure)
                        RetVal.Add(RESP_TRANS_PROCCVV2, obj.ProcCVV2)
                        RetVal.Add(RESP_TRANS_RESPTEXT, obj.RespText)
                        RetVal.Add("DUPLICATE", obj.Duplicate)
                        'Added as SETTLE_DATE param is also available when VERBOSITY= MEDIUM
                        '2005-12-10
                        RetVal.Add(RESP_TRANS_SETTLE_DATE, obj.SettleDate)
                        RetVal.Add("ORIGPNREF", obj.OrigPnref)



                    Case "Fraud"
                        Dim obj As FraudResponse = Response.FraudResponse
                        If Object.Equals(obj, Nothing) Then
                            Exit Select
                        End If

                        Dim FpsXmlData As FpsXmlData
                        Dim Rules As New ArrayList
                        Dim RuleType As Rule
                        Dim RuleVendorParamType As RuleParameter
                        Dim RuleVendorParams As New ArrayList


                        RetVal.Add(RESP_FRAUD_POSTFPSMESSAGE, obj.PostFpsMsg)
                        RetVal.Add(RESP_FRAUD_PREFPSMESSAGE, obj.PreFpsMsg)


                        FpsXmlData = obj.Fps_PreXmlData
                        Rules = FpsXmlData.Rules()
                        Dim iCount As Integer
                        iCount = 0
                        For Each RuleType In Rules

                            RetVal.Add("ACTION FOR RULE ID - " + RuleType.RuleId, RuleType.Action)
                            RetVal.Add("NUM FOR RULE ID - " + RuleType.RuleId, RuleType.Num)
                            RetVal.Add("RULEALIAS FOR RULE ID - " + RuleType.RuleId, RuleType.RuleAlias)
                            RetVal.Add("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId, RuleType.RuleDescription)
                            RetVal.Add("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId, RuleType.TriggeredMessage)

                            RuleVendorParams = RuleType.RuleVendorParms
                            For Each RuleVendorParamType In RuleVendorParams
                                RetVal.Add("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Name)
                                RetVal.Add("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Num)
                                RetVal.Add("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Type)
                                RetVal.Add("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Value)
                                iCount = iCount + 1
                            Next
                        Next

                        FpsXmlData = obj.Fps_PostXmlData
                        Rules = FpsXmlData.Rules()
                        For Each RuleType In Rules

                            'RetVal.Add("RuleId", RuleType.RuleId)
                            RetVal.Add("ACTION FOR RULE ID - " + RuleType.RuleId, RuleType.Action)
                            RetVal.Add("NUM FOR RULE ID - " + RuleType.RuleId, RuleType.Num)
                            RetVal.Add("RULEALIAS FOR RULE ID - " + RuleType.RuleId, RuleType.RuleAlias)
                            RetVal.Add("RULEDESCRIPTION FOR RULE ID - " + RuleType.RuleId, RuleType.RuleDescription)
                            RetVal.Add("TRIGGEREDMESSAGE FOR RULE ID - " + RuleType.RuleId, RuleType.TriggeredMessage)

                            RuleVendorParams = RuleType.RuleVendorParms

                            iCount = 0
                            For Each RuleVendorParamType In RuleVendorParams
                                RetVal.Add("NAME_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Name)
                                RetVal.Add("NUM_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Num)
                                RetVal.Add("TYPE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Type)
                                RetVal.Add("VALUE_" + iCount.ToString + " FOR RULE ID - " + RuleType.RuleId, RuleVendorParamType.Value)
                                iCount = iCount + 1
                            Next
                        Next
                    Case "Context"
                        Dim obj As PayPal.Payments.Common.Context = Response.TransactionContext
                        If Object.Equals(obj, Nothing) Then
                            Exit Select
                        End If

                        Dim Errors As New ArrayList
                        Dim ErrorObject As PayPal.Payments.Common.ErrorObject
                        Dim i As Integer
                        i = 0
                        Errors = obj.GetErrors(PayflowConstants.SEVERITY_ERROR)
                        For Each ErrorObject In Errors
                            RetVal.Add(ErrorObject.MessageCode + "*" + i.ToString, ErrorObject.ToString)
                            i = i + 1
                        Next
                    Case "Recurring"
                        Dim obj As RecurringResponse = Response.RecurringResponse
                        If Object.Equals(obj, Nothing) Then
                            Exit Select
                        End If

                        RetVal.Add("ACCT", obj.Acct)
                        RetVal.Add("AGGREGATEAMT", obj.AggregateAmt)
                        RetVal.Add("AGGREGATEOPTAMT", obj.AggregateOptionalAmt)
                        RetVal.Add("AMT", obj.Amt)
                        RetVal.Add("CITY", obj.City)
                        RetVal.Add("COMPANYNAME", obj.CompanyName)
                        RetVal.Add("COUNTRY", obj.Country)
                        RetVal.Add("EMAIL", obj.Email)
                        RetVal.Add("ENDPAYMENT", obj.End)
                        RetVal.Add("EXPDATE", obj.ExpDate)
                        RetVal.Add("FIRSTNAME", obj.FirstName)
                        RetVal.Add("LASTNAME", obj.LastName)
                        RetVal.Add("MAXFAILPAYMENTS", obj.MaxFailPayments)
                        RetVal.Add("MIDDLENAME", obj.MiddleName)
                        RetVal.Add("NAME", obj.Name)
                        RetVal.Add("NUMFAILPAYMENTS", obj.NumFailPayments)
                        RetVal.Add("NXTPAYMENT", obj.NextPayment)
                        'RetVal.Add("P_AMT", obj.P_Amt)
                        'RetVal.Add("P_PNREFN", obj.P_PNRefn)
                        'RetVal.Add("P_RESULTN", obj.P_Resultn)
                        'RetVal.Add("P_TENDERTYPEN", obj.P_TenderTypen)
                        'RetVal.Add("P_TRANSTATEN", obj.P_TranStaten)
                        'RetVal.Add("P_TRANSTIMEN", obj.P_TransTimen)
                        RetVal.Add("PAYMENTSLEFT", obj.PaymentsLeft)
                        RetVal.Add("PAYPERIOD", obj.PayPeriod)
                        RetVal.Add("PHONENUM", obj.PhoneNum)
                        RetVal.Add("PROFILEID", obj.ProfileId)
                        RetVal.Add("PROFILENAME", obj.ProfileName)
                        RetVal.Add("RETRYNUMDAYS", obj.RetryNumDays)
                        RetVal.Add("RPREF", obj.RPRef)
                        RetVal.Add("SHIPTOCITY", obj.ShipToCity)
                        RetVal.Add("SHIPTOCOUNTRY", obj.ShipToCountry)
                        RetVal.Add("SHIPTOFNAME", obj.ShipToFirstName)
                        RetVal.Add("SHIPTOLNAME", obj.ShipToLastName)
                        RetVal.Add("SHIPTOMNAME", obj.ShipToMiddleName)
                        RetVal.Add("SHIPTOSTATE", obj.ShipToState)
                        RetVal.Add("SHIPTOSTREET", obj.ShipToStreet)
                        RetVal.Add("SHIPTOZIP", obj.ShipToZip)
                        RetVal.Add("START", obj.Start)
                        RetVal.Add("STATE", obj.State)
                        RetVal.Add("STATUS", obj.Status)
                        RetVal.Add("STREET", obj.Street)
                        RetVal.Add("TENDERTYPE", obj.Tender)
                        RetVal.Add("TERM", obj.Term)
                        RetVal.Add("TRXPNREF", obj.TrxPNRef)
                        RetVal.Add("TRXRESPMESG", obj.TrxRespMsg)
                        RetVal.Add("TRXRESULT", obj.TrxResult)
                        ' to add inquiryparams hashtable to RetVal hashtable
                        Dim KeysColl As System.Collections.ICollection
                        Dim KeysEnum As System.Collections.IEnumerator
                        Dim FieldName As String
                        If Not IsDBNull(obj.InquiryParams) And (obj.InquiryParams.Count > 0) Then
                            KeysColl = obj.InquiryParams.Keys
                            KeysEnum = KeysColl.GetEnumerator()

                            While KeysEnum.MoveNext
                                FieldName = KeysEnum.Current().ToString()
                                RetVal.Add(FieldName, obj.InquiryParams.Item(FieldName).ToString)
                            End While
                        End If
                        'end of addition
                End Select
                Logger.Instance.Log("PayPal.Payments.SampleStore.VB.Aspx.SampleStore.GetResponseInHashTbl(Response,As String): Exiting", PayflowConstants.SEVERITY_DEBUG)
                Return RetVal

            Catch Ex As Exception
                Throw New Exception(Ex.Message, Ex)
            End Try
        End Function
        Private Sub BtnSubmitTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmitTransaction.Click
            SubmitForm()
        End Sub
        Private Sub BtnFollowOnRecurring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFollowOnRecurring.Click
            Context.Items.Add(CONTEXT_PROFILEID, ViewState(CONTEXT_PROFILEID))
            Context.Items.Add(CONTEXT_REQUESTDATA, ViewState(CONTEXT_TEMPDATA))
            DisplaySampleStore()
        End Sub
        Private Sub BtnFollowOnTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFollowOnTransaction.Click
            Context.Items.Add(CONTEXT_REQUESTDATA, ViewState(CONTEXT_TEMPDATA))
            Context.Items.Add(CONTEXT_ORIGID, ViewState(CONTEXT_PNREF))
            Context.Items.Add(CONTEXT_PROFILEID, ViewState("PROFILEID"))
            DisplaySampleStore()
        End Sub
        Private Sub BtnWeakAssemblyFollowOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWeakAssemblyFollowOn.Click
            Response.Redirect(GLOBAL_PATH & "/src/PayPal/Payments/SampleStore/vb/Aspx/SampleStore.aspx")
        End Sub
        Private Sub TransactionDataGrid_OnItemDataBound(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionDataGrid.SelectedIndexChanged

        End Sub

        Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click
            Response.Redirect(GLOBAL_PATH & "/src/PayPal/Payments/SampleStore/vb/Aspx/SampleStore.aspx")
        End Sub

        Private Sub ContextDataGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles ContextDataGrid.ItemDataBound


            ' e.Item.FindControl("LblErrorCode").Visible = True 'DataBinder.Eval(e.Item.DataItem, "Key")
            'CType(e.Item.FindControl("LblErrorMessage"), Label).Text = 1 'DataBinder.Eval(e.Item.DataItem, "Value")

        End Sub
        Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
            Response.Redirect(GLOBAL_PATH & "/src/PayPal/Payments/SampleStore/vb/Aspx/SampleStore.aspx")
        End Sub

        Private Sub BtnStrongBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStrongBack.Click
            Response.Redirect(GLOBAL_PATH & "/src/PayPal/Payments/SampleStore/vb/Aspx/SampleStore.aspx")
        End Sub
    End Class

End Namespace

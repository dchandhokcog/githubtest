using System;
using System.Collections;
using System.Xml; 
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.Payments.SampleStore.CS.Common; 
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;



namespace PayPal.Payments.SampleStore.CS.Aspx
{
	
	// Summary description for SampleStore
	
	public class SampleStore : System.Web.UI.Page
	{
		
		// PayPal Logo Image
		
		protected System.Web.UI.WebControls.Image ImgPayPalLogo;
		
		// Table used for setting  ERROR
		
		protected System.Web.UI.WebControls.Table TblError;
		
		// Label used for setting  REQUESTTYPE
		
		protected System.Web.UI.WebControls.Label LblRequestType;
		
		// DropDownList used for setting  REQUESTTYPE
		
		protected System.Web.UI.WebControls.DropDownList CboRequestType;
		
		// Label used for setting  WEAKASSEMBLYREQUEST
		
		protected System.Web.UI.WebControls.Label LblWeakAssemblyRequest;
		
		// TextBox used for setting  WEAKASSEMBLYREQUEST
		
		protected System.Web.UI.WebControls.TextBox TxtBoxWeakAssemblyRequest;
		
		// Label used for setting  REQUESTID
		
		protected System.Web.UI.WebControls.Label LblRequestId;
		
		// TextBox used for setting  REQUESTID
		
		protected System.Web.UI.WebControls.TextBox TxtBoxRequestId;
		
		// Label used for setting  VENDOR
		
		protected System.Web.UI.WebControls.Label LblVendor;
		
		// Text Box used for setting  VENDOR
		
		protected System.Web.UI.WebControls.TextBox TxtBoxVendor;
		
		// Label used for setting  USER
		
		protected System.Web.UI.WebControls.Label LblUser;
		
		// TextBox used for setting  USER 
		
		protected System.Web.UI.WebControls.TextBox TxtBoxUser;
		
		// Label used for setting  PARTNER
		
		protected System.Web.UI.WebControls.Label LblPartner;
		
		// TextBox used for setting  used for setting  PARTNER
		
		protected System.Web.UI.WebControls.TextBox TxtBoxPartner;
		
		// Label used for setting  PASSWORD
		
		protected System.Web.UI.WebControls.Label LblPassword;
		
		// TextBox used for setting  PASSWORD
		
		protected System.Web.UI.WebControls.TextBox TxtBoxPassword;
		
		// Label used for setting  PROXYADDRESS
		
		protected System.Web.UI.WebControls.Label LblProxyAddress;
		
		// TextBox used for setting  PROXYADDRESS
		
		protected System.Web.UI.WebControls.TextBox TxtBoxProxyAddress;
		
		// Label used for setting  PROXYPORT
		
		protected System.Web.UI.WebControls.Label LblProxyPort;
		
		// TextBox used for setting  PROXYPORT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxProxyPort;
		
		// Label used for setting  PROXYLOGON
		
		protected System.Web.UI.WebControls.Label LblProxyLogon;
		
		// TextBox used for setting  PROXYLOGON
		
		protected System.Web.UI.WebControls.TextBox TxtBoxProxyLogon;
		
		// Label used for setting  PROXYPASSWORD
		
		protected System.Web.UI.WebControls.Label LblProxyPassword;
		
		// TextBox used for setting  PROXYPASSWORD
		
		protected System.Web.UI.WebControls.TextBox TxtBoxProxyPassword;
		
		// Label used for setting  TENDER
		
		protected System.Web.UI.WebControls.Label LblTender;
		
		// DropDownList used for setting  TENDER
		
		protected System.Web.UI.WebControls.DropDownList CboTender;
		
		// Label used for setting  CHKNUM
		
		protected System.Web.UI.WebControls.Label LblChkNum;
		
		// TextBox used for setting  CHKNUM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxChkNum;
		
		// Label used for setting  CHKTYPE
		
		protected System.Web.UI.WebControls.Label LblChkType;
		
		// TextBox used for setting  CHKTYPE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxChkType;
		
		// Label used for setting  ORIGID
		
		protected System.Web.UI.WebControls.Label LblOrigId;
		
		// TextBox used for setting  ORIGID
		
		protected System.Web.UI.WebControls.TextBox TxtBoxOrigId;
		
		// Label used for setting  TRXTYPE
		
		protected System.Web.UI.WebControls.Label LblTrxType;
		
		// DropDownList used for setting  TRXTYPE
		
		protected System.Web.UI.WebControls.DropDownList CboTrxType;
		
		// Label used for setting  AMT
		
		protected System.Web.UI.WebControls.Label LblAmt;
		
		// TextBox used for setting  AMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxAmt;
		
		// Label used for setting  CURRENCY
		
		protected System.Web.UI.WebControls.Label LblCurrency;
		
		// DropDownList used for setting  CURRENCY
		
		protected System.Web.UI.WebControls.DropDownList CboCurrency;
		
		// Label used for setting  AUTHCODE
		
		protected System.Web.UI.WebControls.Label LblAuthCode;
		
		//  TextBox used for setting  AUTHCODE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxAuthCode;
		
		// Label used for setting  SWIPE
		
		protected System.Web.UI.WebControls.Label LblSwipe;
		
		// TextBox used for setting  SWIPE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxSwipe;
		
		// Label used for setting  ACCT
		
		protected System.Web.UI.WebControls.Label LblAcct;
		
		// TextBox used for setting  ACCT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxAcct;
		
		// Label used for setting  EXPDATE
		
		protected System.Web.UI.WebControls.Label LblExpDate;
		
		// DropDownList used for setting  EXPIRYMONTH
		
		protected System.Web.UI.WebControls.DropDownList CboExpiryMonth;
		
		// DropDownList used for setting  EXPIRYYEAR
		
		protected System.Web.UI.WebControls.DropDownList CboExpiryYear;
		
		// Label used for setting  CVV2
		
		protected System.Web.UI.WebControls.Label LblCvv2;
		
		// TextBox used for setting  CVV2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCvv2;
		
		// Label used for setting  ORDERBIN
		
		protected System.Web.UI.WebControls.Label LblOrderBin;
		
		// TextBox used for setting  ORDERBIN
		
		protected System.Web.UI.WebControls.TextBox TxtBoxOrderbin;
		
		// Label used for setting  VERBOSITY
		
		protected System.Web.UI.WebControls.Label LblVerbosity;
		
		// DropDownList used for setting  VERBOSITY
		
		protected System.Web.UI.WebControls.DropDownList CboVerbosity;
		
		// Label used for setting  ABA
		
		protected System.Web.UI.WebControls.Label LblAba;
		
		// TextBox used for setting  ABA
		
		protected System.Web.UI.WebControls.TextBox TxtBoxAba;
		
		// Label used for setting  ACCTTYPE
		
		protected System.Web.UI.WebControls.Label LblAcctType;
		
		// DropDownList used for setting  ACCTTYPE
		
		protected System.Web.UI.WebControls.DropDownList CboAcctType;
		
		// Label used for setting  AUTHTYPE
		
		protected System.Web.UI.WebControls.Label LblAuthType;
		
		//  DropDownList used for setting  AuthType
		
		protected System.Web.UI.WebControls.DropDownList CboAuthType;
		
		// Label used for setting  PRENOTE
		
		protected System.Web.UI.WebControls.Label LblPrenote;
		
		//  DropDownList used for setting  PRENOTE
		
		protected System.Web.UI.WebControls.DropDownList CboPrenote;
		
		// Label used for setting  TERMCITY
		
		protected System.Web.UI.WebControls.Label LblTermCity;
		
		//  TextBox used for setting  TERMCITY
		
		protected System.Web.UI.WebControls.TextBox TxtBoxTermCity;
		
		// Label used for setting  TERMSTATE
		
		protected System.Web.UI.WebControls.Label LblTermState;
		
		// TextBox used for setting  TERMSTATE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxTermState;
		
		// Label used for setting  MICR
		
		protected System.Web.UI.WebControls.Label LblMicr;
		
		// TextBox used for setting  MICR
		
		protected System.Web.UI.WebControls.TextBox TxtBoxMicr;
		
		// Label used for setting  DL
		
		protected System.Web.UI.WebControls.Label LblDL;
		
		// TextBox used for setting  DL
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDL;
		
		// Label used for setting  SS
		
		protected System.Web.UI.WebControls.Label LblSS;
		
		// TextBox used for setting  SS
		
		protected System.Web.UI.WebControls.TextBox TxtBoxSS;
		
		// Label used for setting  NAME
		
		protected System.Web.UI.WebControls.Label LblName;
		
		// TextBox used for setting  NAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxName;
		
		// Label used for setting  COMPANYNAME
		
		protected System.Web.UI.WebControls.Label LblCompanyName;
		
		// TextBox used for setting  COMPANYNAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCompanyName;
		
		// Label used for setting  CUSTCODE
		
		protected System.Web.UI.WebControls.Label LblCustCode;
		
		// TextBox used for setting  CUSTCODE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustCode;
		
		// Label used for setting  CUSTREF
		
		protected System.Web.UI.WebControls.Label LblCustRef;
		
		// TextBox used for setting  CUSTREF
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustRef;
		
		// Label used for setting  FAX
		
		protected System.Web.UI.WebControls.Label LblFax;
		
		// TextBox used for setting  FAX
		
		protected System.Web.UI.WebControls.TextBox TxtBoxFax;
		
		// Label used for setting  HOMEPHONE
		
		protected System.Web.UI.WebControls.Label LblHomePhone;
		
		// TextBox used for setting  HOMEPHONE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxHomePhone;
		
		// Label used for setting  CUSTAGE
		
		protected System.Web.UI.WebControls.Label LblCustAge;
		
		// TextBox used for setting  CUSTAGE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustAge;
		
		// Label used for setting  DOB
		
		protected System.Web.UI.WebControls.Label LblDob;
		
		// TextBox used for setting  DOB
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDob;
		
		// Label used for setting  CUSTIP
		
		protected System.Web.UI.WebControls.Label LblCustIp;
		
		// TextBox used for setting  CUSTIP
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustIp;
		
		// Label used for setting  CORPNAME
		
		protected System.Web.UI.WebControls.Label LblCorpName;
		
		// TextBox used for setting  CORPNAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCorpName;
		
		// Label used for setting  CORPPURCHDESC
		
		protected System.Web.UI.WebControls.Label LblCorpPurchDesc;
		
		// TextBox used for setting  CORPPURCHDESC
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCorpPurchDesc;
		
		// Label used for setting  CUSTMAXAGE
		
		protected System.Web.UI.WebControls.Label LblCustMaxAge;
		
		// TextBox used for setting  CUSTMAXAGE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustMaxAge;
		
		// Label used for setting  CUSTMINAGE
		
		protected System.Web.UI.WebControls.Label LblCustMinAge;
		
		// TextBox used for setting  CUSTMINAGE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustMinAge;
		
		// Label used for setting  SSN
		
		protected System.Web.UI.WebControls.Label LblSsn;
		
		// TextBox used for setting  SSN
		
		protected System.Web.UI.WebControls.TextBox TxtBoxSsn;
		
		// Label used for setting  CUSTID
		
		protected System.Web.UI.WebControls.Label LblCustId;
		
		// TextBox used for setting  CUSTID
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustId;
		
		// Label used for setting  CUSTTM
		
		protected System.Web.UI.WebControls.Label LblCustTm;
		
		// TextBox used for setting  CUSTTM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustTm;
		
		// Label used for setting  PREVIOUSCUST
		
		protected System.Web.UI.WebControls.Label LblPreviousCust;
		
		// TextBox used for setting  PREVIOUSCUST
		
		protected System.Web.UI.WebControls.TextBox TxtBoxPreviousCust;
		
		// Label used for setting  CUSTVATREGNUM
		
		protected System.Web.UI.WebControls.Label LblCustVatRegNum;
		
		// TextBox used for setting  CUSTVATREGNUM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCustVatRegNum;
		
		// Label used for setting  used for setting GOTPWD
		
		protected System.Web.UI.WebControls.Label LblForgotPwd;
		
		// TextBox used for setting  used for setting GOTPWD
		
		protected System.Web.UI.WebControls.TextBox TxtBoxForgotPwd;
		
		// Label used for setting  PASSWORDGIVEN
		
		protected System.Web.UI.WebControls.Label LblPasswordGiven;
		
		// TextBox used for setting  PASSWORDGIVEN
		
		protected System.Web.UI.WebControls.TextBox TxtBoxPasswordGiven;
		
		// Label used for setting  MERCHDESCR
		
		protected System.Web.UI.WebControls.Label LblMerchDescr;
		
		// TextBox used for setting  MERCHDESCR
		
		protected System.Web.UI.WebControls.TextBox TxtBoxMerchDescr;
		
		// Label used for setting  MERCHSVC
		
		protected System.Web.UI.WebControls.Label LblMerchSvc;
		
		// TextBox used for setting  MERCHSVC
		
		protected System.Web.UI.WebControls.TextBox TxtBoxMerchSvc;
		
		// Label used for setting  REGLOYALTY
		
		protected System.Web.UI.WebControls.Label LblRegLoyalty;
		
		// TextBox used for setting  REGLOYALTY
		
		protected System.Web.UI.WebControls.TextBox TxtBoxRegLoyalty;
		
		// Label used for setting  REGPROMO
		
		protected System.Web.UI.WebControls.Label LblRegPromo;
		
		// TextBox used for setting  REGPROMO
		
		protected System.Web.UI.WebControls.TextBox TxtBoxRegPromo;
		
		// Label used for setting  RETURNALLOWED
		
		protected System.Web.UI.WebControls.Label LblReturnAllowed;
		
		// TextBox used for setting  RETURNALLOWED
		
		protected System.Web.UI.WebControls.TextBox TxtBoxReturnAllowed;
		
		// Label used for setting  GIFTCARDTYPE
		
		protected System.Web.UI.WebControls.Label LblGiftCardType;
		
		// TextBox used for setting  GIFTCARDTYPE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxGiftcardtype;
		
		// Label used for setting  GIFTMSG
		
		protected System.Web.UI.WebControls.Label LblGiftMsg;
		
		// TextBox used for setting  GIFTMSG
		
		protected System.Web.UI.WebControls.TextBox TxtBoxGiftMsg;
		
		// Label used for setting  WRAPPED
		
		protected System.Web.UI.WebControls.Label LblWrapped;
		
		// TextBox used for setting  WRAPPED
		
		protected System.Web.UI.WebControls.TextBox TxtBoxWrapped;
		
		// Label used for setting  REQNAME
		
		protected System.Web.UI.WebControls.Label LblReqName;
		
		// TextBox used for setting  REQNAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxReqname;
		
		// Label used for setting  FIRSTNAME
		
		protected System.Web.UI.WebControls.Label LblFirstName;
		
		// TextBox used for setting  FIRSTNAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxFirstName;
		
		// Label used for setting  MIDDLENAME
		
		protected System.Web.UI.WebControls.Label LblMiddleName;
		
		// TextBox used for setting  MIDDLENAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxMiddleName;
		
		// Label used for setting  LASTNAME
		
		protected System.Web.UI.WebControls.Label LblLastName;
		
		// TextBox used for setting  LASTNAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxLastName;
		
		// Label used for setting  STREET
		
		protected System.Web.UI.WebControls.Label LblStreet;
		
		//  TextBox used for setting  STREET
		
		protected System.Web.UI.WebControls.TextBox TxtBoxStreet;
		
		// Label used for setting  BILLTOSTREET2
		
		protected System.Web.UI.WebControls.Label LblBillToStreet2;
		
		// TextBox used for setting  BILLTOSTREET2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxBillToStreet2;
		
		// Label used for setting  CITY
		
		protected System.Web.UI.WebControls.Label LblCity;
		
		// TextBox used for setting  CITY
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCity;
		
		// Label used for setting  STATE
		
		protected System.Web.UI.WebControls.Label LblState;
		
		// TextBox used for setting  STATE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxState;
		
		// Label used for setting  COUNTRY
		
		protected System.Web.UI.WebControls.Label LblCountry;
		
		// TextBox used for setting  COUNTRY
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCountry;
		
		// Label used for setting  ZIP
		
		protected System.Web.UI.WebControls.Label LblZip;
		
		// TextBox used for setting  ZIP
		
		protected System.Web.UI.WebControls.TextBox TxtBoxZip;
		
		// Label used for setting  EMAIL
		
		protected System.Web.UI.WebControls.Label LblEmail;
		
		// TextBox used for setting  EMAIL
		
		protected System.Web.UI.WebControls.TextBox TxtBoxEmail;
		
		// Label used for setting  BILLTOPHONE2
		
		protected System.Web.UI.WebControls.Label LblBillToPhone2;
		
		// TextBox used for setting  BILLTOPHONE2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxBillToPhone2;
		
		// Label used for setting  PHONENUM
		
		protected System.Web.UI.WebControls.Label LblPhoneNum;
		
		// TextBox used for setting  PHONENUM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxPhoneNum;
		
		// Label used for setting  SHIPTOFIRSTNAME
		
		protected System.Web.UI.WebControls.Label LblShipToFirstName;
		
		// TextBox used for setting  SHIPTOFIRSTNAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToFirstName;
		
		// Label used for setting  SHIPTOMIDDLENAME
		
		protected System.Web.UI.WebControls.Label LblShipToMiddleName;
		
		// TextBox used for setting  SHIPTOMIDDLENAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToMiddleName;
		
		// Label used for setting  SHIPTOLASTNAME
		
		protected System.Web.UI.WebControls.Label LblShipToLastName;
		
		// TextBox used for setting  SHIPTOLASTNAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToLastName;
		
		// Label used for setting  SHIPTOSTREET
		
		protected System.Web.UI.WebControls.Label LblShipToStreet;
		
		// TextBox used for setting  SHIPTOSTREET
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToStreet;
		
		// Label used for setting  SHIPTOSTREET2
		
		protected System.Web.UI.WebControls.Label LblShipToStreet2;
		
		// TextBox used for setting  SHIPTOSTREET2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToStreet2;
		
		// Label used for setting  SHIPTOCITY
		
		protected System.Web.UI.WebControls.Label LblShipToCity;
		
		// TextBox used for setting  SHIPTOCITY
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToCity;
		
		// Label used for setting  SHIPTOSTATE
		
		protected System.Web.UI.WebControls.Label LblShipToState;
		
		// TextBox used for setting  SHIPTOSTATE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToState;
		
		// Label used for setting  SHIPTOCOUNTRY
		
		protected System.Web.UI.WebControls.Label LblShipToCountry;
		
		// TextBox used for setting  SHIPTOCOUNTRY
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToCountry;
		
		// Label used for setting  SHIPTOZIP
		
		protected System.Web.UI.WebControls.Label LblShipToZip;
		
		// TextBox used for setting  SHIPTOZIP
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToZip;
		
		// Label used for setting  SHIPTOEMAIL
		
		protected System.Web.UI.WebControls.Label LblShipToEmail;
		
		// TextBox used for setting  SHIPTOEMAIL
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToEmail;
		
		// Label used for setting  SHIPFROMZIP
		
		protected System.Web.UI.WebControls.Label LblShipFromzip;
		
		// TextBox used for setting  SHIPFROMZIP
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipFromzip;
		
		// Label used for setting  SHIPTOPHONE
		
		protected System.Web.UI.WebControls.Label LblShipToPhone;
		
		// TextBox used for setting  SHIPTOPHONE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToPhone;
		
		// Label used for setting  SHIPTOPHONE2
		
		protected System.Web.UI.WebControls.Label LblShipToPhone2;
		
		// TextBox used for setting  SHIPTOPHONE2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipToPhone2;
		
		// Label used for setting  CARRIER
		
		protected System.Web.UI.WebControls.Label LblCarrier;
		
		// TextBox used for setting  CARRIER
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCarrier;
		
		// Label used for setting  SHIPCARRIER
		
		protected System.Web.UI.WebControls.Label LblShipCarrier;
		
		// TextBox used for setting  SHIPCARRIER
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipCarrier;
		
		// Label used for setting  SHIPMENTNO
		
		protected System.Web.UI.WebControls.Label LblShipMentno;
		
		// TextBox used for setting  SHIPMENTNO
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipMentno;
		
		// Label used for setting  SHIPMETHOD
		
		protected System.Web.UI.WebControls.Label LblShipMethod;
		
		// TextBox used for setting  SHIPMETHOD
		
		protected System.Web.UI.WebControls.TextBox TxtBoxShipMethod;
		
		// Label used for setting  FREIGHTAMT
		
		protected System.Web.UI.WebControls.Label LblFreightAmt;
		
		// TextBox used for setting  FREIGHTAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxFreightAmt;
		
		// Label used for setting  DUTYAMT
		
		protected System.Web.UI.WebControls.Label LblDutyAmt;
		
		// TextBox used for setting  DUTYAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDutyAmt;
		
		// Label used for setting  ORDERDATETIME
		
		protected System.Web.UI.WebControls.Label LblOrderDateTime;
		
		// TextBox used for setting  ORDERDATETIME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxOrderDateTime;
		
		// Label used for setting  COMMENT1
		
		protected System.Web.UI.WebControls.Label LblComment1;
		
		// TextBox used for setting  COMMENT1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxComment1;
		
		// Label used for setting  COMMENT2
		
		protected System.Web.UI.WebControls.Label LblComment2;
		
		// TextBox used for setting  COMMENT2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxComment2;
		
		// Label used for setting  DESC
		
		protected System.Web.UI.WebControls.Label LblDesc;
		
		// TextBox used for setting  DESC
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDesc;
		
		// Label used for setting  DESC1
		
		protected System.Web.UI.WebControls.Label LblDesc1;
		
		// TextBox used for setting  DESC1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDesc1;
		
		// Label used for setting  DESC2
		
		protected System.Web.UI.WebControls.Label LblDesc2;
		
		// TextBox used for setting  DESC2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDesc2;
		
		// Label used for setting  DESC3
		
		protected System.Web.UI.WebControls.Label LblDesc3;
		
		// TextBox used for setting  DESC3
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDesc3;
		
		// Label used for setting  DESC4 
		
		protected System.Web.UI.WebControls.Label LblDesc4;
		
		// TextBox used for setting  DESC4
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDesc4;
		
		// Label used for setting  DISCOUNT
		
		protected System.Web.UI.WebControls.Label LblDiscount;
		
		// TextBox used for setting  DISCOUNT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxDiscount;
		
		// Label used for setting  HANDLINGAMT
		
		protected System.Web.UI.WebControls.Label LblHandlingAmt;
		
		// TextBox used for setting  HANDLINGAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxHandlingAmt;
		
		// Label used for setting  INVNUM
		
		protected System.Web.UI.WebControls.Label LblInvNum;
		
		// TextBox used for setting  INVNUM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxInvNum;
		
		// Label used for setting  INVOICEDATE
		
		protected System.Web.UI.WebControls.Label LblInvoiceDate;
		
		// TextBox used for setting  INVOICEDATE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxInvoiceDate;
		
		// Label used for setting  PONUM
		
		protected System.Web.UI.WebControls.Label LblPoNum;
		
		// TextBox used for setting  PONUM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxPoNum;
		
		// Label used for setting  STARTTIME
		
		protected System.Web.UI.WebControls.Label LblStartTime;
		
		// TextBox used for setting  STARTTIME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxStartTime;
		
		// Label used for setting  ENDTIME
		
		protected System.Web.UI.WebControls.Label LblEndTime;
		
		// TextBox used for setting  ENDTIME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxEndTime;
		
		// Label used for setting  SUBTOTAL
		
		protected System.Web.UI.WebControls.Label LblSubTotal;
		
		// TextBox used for setting  SUBTOTAL
		
		protected System.Web.UI.WebControls.TextBox TxtBoxSubTotal;
		
		// Label used for setting  TAXEXEMPT
		
		protected System.Web.UI.WebControls.Label LblTaxExempt;
		
		// DropDownList used for setting  TAXEXEMPT
		
		protected System.Web.UI.WebControls.DropDownList CboTaxExempt;
		
		// Label used for setting  TAXAMT
		
		protected System.Web.UI.WebControls.Label LblTaxAmt;
		
		// TextBox used for setting  TAXAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxTaxAmt;
		
		// Label used for setting  LOCALTAXAMT
		
		protected System.Web.UI.WebControls.Label LblLocalTaxAmt;
		
		// TextBox used for setting  LOCALTAXAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxLocalTaxAmt;
		
		// Label used for setting  NATIONALTAXAMT
		
		protected System.Web.UI.WebControls.Label LblNationalTaxAmt;
		
		// TextBox used for setting  NATIONALTAXAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxNationalTaxAmt;
		
		// Label used for setting  ALTTAXAMT
		
		protected System.Web.UI.WebControls.Label LblAltTaxAmt;
		
		// TextBox used for setting  ALTTAXAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxAltTaxAmt;
		
		// Label used for setting  VATTAXPERCENT
		
		protected System.Web.UI.WebControls.Label LblVatTaxPercent;
		
		// TextBox used for setting  VATTAXPERCENT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxVatTaxPercent;
		
		// Label used for setting  VATTAXAMT
		
		protected System.Web.UI.WebControls.Label LblVatTaxAmt;
		
		// TextBox used for setting  VATTAXAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxVatTaxAmt;
		
		// Label used for setting  VATREGNUM
		
		protected System.Web.UI.WebControls.Label LblVatRegNum;
		
		// TextBox used for setting  VATREGNUM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxVatRegNum;
		
		// Label used for setting  BROWSERCOUNTRYCODE
		
		protected System.Web.UI.WebControls.Label LblBrowserCountryCode;
		
		// TextBox used for setting  BROWSERCOUNTRYCODE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxBrowserCountryCode;
		
		// Label used for setting  BROWSERTIME
		
		protected System.Web.UI.WebControls.Label LblBrowserTime;
		
		// TextBox used for setting  BROWSERTIME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxBrowserTime;
		
		// Label used for setting  BROWSERUSERAGENT
		
		protected System.Web.UI.WebControls.Label LblBrowserUserAgent;
		
		// TextBox used for setting  BROWSERUSERAGENT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxBrowserUserAgent;
		
		// Label used for setting  ACTION
		
		protected System.Web.UI.WebControls.Label LblAction;
		
		// DropDownList used for setting  ACTION
		
		protected System.Web.UI.WebControls.DropDownList CboAction;
		
		// Label used for setting  PAYMENTHISTORY
		
		protected System.Web.UI.WebControls.Label LblPaymentHistory;
		
		// DropDownList used for setting  PAYMENTHISTORY
		
		protected System.Web.UI.WebControls.DropDownList CboPaymentHistory;
		
		// Label used for setting  PROFILENAME
		
		protected System.Web.UI.WebControls.Label LblProfileName;
		
		// TextBox used for setting  PROFILENAME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxProfileName;
		
		// Label used for setting  START
		
		protected System.Web.UI.WebControls.Label LblStart;
		
		// TextBox used for setting  START
		
		protected System.Web.UI.WebControls.TextBox TxtBoxStart;
		
		// Label used for setting  Term
		
		protected System.Web.UI.WebControls.Label LblTerm;
		
		// TextBox used for setting  Term
		
		protected System.Web.UI.WebControls.TextBox TxtBoxTerm;
		
		// Label used for setting  PAYPERIOD
		
		protected System.Web.UI.WebControls.Label LblPayPeriod;
		
		// DropDownList used for setting  PAYPERIOD
		
		protected System.Web.UI.WebControls.DropDownList CboPayPeriod;
		
		// Label used for setting  RETRYNUMDAYS
		
		protected System.Web.UI.WebControls.Label LblRetryNumDays;
		
		// TextBox used for setting  RETRYNUMDAYS
		
		protected System.Web.UI.WebControls.TextBox TxtBoxRetryNumDays;
		
		// Label used for setting  PAYMENTNUM
		
		protected System.Web.UI.WebControls.Label LblPaymentNum;
		
		// TextBox used for setting  PAYMENTNUM
		
		protected System.Web.UI.WebControls.TextBox TxtBoxPaymentNum;
		
		// Label used for setting  MAXFAILPAYMENTS
		
		protected System.Web.UI.WebControls.Label LblMaxFailPayments;
		
		// TextBox used for setting  MAXFAILPAYMENTS
		
		protected System.Web.UI.WebControls.TextBox TxtBoxMaxFailPayments;
		
		// Label used for setting  OPTIONALTRXTYPE
		
		protected System.Web.UI.WebControls.Label LblOptionalTrxType;
		
		// DropDownList used for setting  OPTIONALTRXTYPE
		
		protected System.Web.UI.WebControls.DropDownList CboOptionalTrxType;
		
		// Label used for setting  OPTIONALTRXAMT
		
		protected System.Web.UI.WebControls.Label LblOptionalTrxAmt;
		
		// TextBox used for setting  OPTIONALTRXAMT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxOptionalTrxAmt;
		
		// Label used for setting  ORIGPROFILEID
		
		protected System.Web.UI.WebControls.Label LblOrigProfileId;
		
		// TextBox used for setting  ORIGPROFILEID
		
		protected System.Web.UI.WebControls.TextBox TxtBoxOrigProfileId;
		
		// Label used for setting  UPDATEACTION
		
		protected System.Web.UI.WebControls.Label LblRMSAction;
		
		// DropDownList used for setting  UPDATEACTION
		
		protected System.Web.UI.WebControls.DropDownList CboUpdateAction;
		
		// Label used for setting  L_AMT0
		
		protected System.Web.UI.WebControls.Label LblLAmt0;
		
		// TextBox used for setting  L_AMT0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Amt0;
		
		// Label used for setting  L_CATEGORY0
		
		protected System.Web.UI.WebControls.Label LblLCategory0;
		
		// TextBox used for setting  L_CATEGORY0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Category0;
		
		// Label used for setting  L_COST0
		
		protected System.Web.UI.WebControls.Label LblLCost0;
		
		// TextBox used for setting  L_COST0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Cost0;
		
		// Label used for setting  L_DESC0
		
		protected System.Web.UI.WebControls.Label LblLDesc0;
		
		// TextBox used for setting  L_DESC0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Desc0;
		
		// Label used for setting  L_DISCOUNT0
		
		protected System.Web.UI.WebControls.Label LblLDiscount0;
		
		// TextBox used for setting  L_DISCOUNT0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Discount0;
		
		// Label used for setting  L_MANUFACTURER0
		
		protected System.Web.UI.WebControls.Label LblLManufacturer0;
		
		// TextBox used for setting  L_MANUFACTURER0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Manufacturer0;
		
		// Label used for setting  L_PRODCODE0
		
		protected System.Web.UI.WebControls.Label LblLProdCode0;
		
		// TextBox used for setting  L_PRODCODE0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_ProdCode0;
		
		// Label used for setting  L_QTY0
		
		protected System.Web.UI.WebControls.Label LblLQty0;
		
		// TextBox used for setting  L_QTY0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Qty0;
		
		// Label used for setting  L_SKU0
		
		protected System.Web.UI.WebControls.Label LblLSku0;
		
		// TextBox used for setting  L_SKU0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Sku0;
		
		// Label used for setting  L_TAXAMT0
		
		protected System.Web.UI.WebControls.Label LblLTaxAmt0;
		
		// TextBox used for setting  L_TAXAMT0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TaxAmt0;
		
		// Label used for setting  L_TAXRATE0
		
		protected System.Web.UI.WebControls.Label LblLTaxRate0;
		
		// TextBox used for setting  L_TAXRATE0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TaxRate0;
		
		// Label used for setting  L_TAXTYPE0
		
		protected System.Web.UI.WebControls.Label LblLTaxType0;
		
		// TextBox used for setting  L_TAXTYPE0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TaxType0;
		
		// Label used for setting  L_TYPE0
		
		protected System.Web.UI.WebControls.Label LblLType0;
		
		// TextBox used for setting  L_TYPE0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Type0;
		
		// Label used for setting  L_UOM0
		
		protected System.Web.UI.WebControls.Label LblLUom0;
		
		// TextBox used for setting  L_UOM0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Uom0;
		
		// Label used for setting  L_UPC0
		
		protected System.Web.UI.WebControls.Label LblLUpc0;
		
		// TextBox used for setting  L_UPC0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Upc0;
		
		// Label used for setting  L_COMMCODE0
		
		protected System.Web.UI.WebControls.Label LblLCommCode0;
		
		// TextBox used for setting  L_COMMCODE0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Commcode0;
		
		// Label used for setting  L_FREIGHTAMT0
		
		protected System.Web.UI.WebControls.Label LblLFreightAmt0;
		
		// TextBox used for setting  L_FREIGHTAMT0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_FreightAmt0;
		
		// Label used for setting  L_HANDLINGAMT0
		
		protected System.Web.UI.WebControls.Label LblLHandlingAmt0;
		
		// TextBox used for setting  L_HANDLINGAMT0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_HandlingAmt0;
		
		// Label used for setting  L_TRACKINGNUM0
		
		protected System.Web.UI.WebControls.Label LblLTrackingNum0;
		
		// TextBox used for setting  L_TRACKINGNUM0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TrackingNum0;
		
		// Label used for setting  L_PICKUPSTREET0
		
		protected System.Web.UI.WebControls.Label LblLPickupStreet0;
		
		// TextBox used for setting  L_PICKUPSTREET0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Pickupstreet0;
		
		// Label used for setting  L_PICKUPCITY0
		
		protected System.Web.UI.WebControls.Label LblLPickupCity0;
		
		// TextBox used for setting  L_PICKUPCITY0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Pickupcity0;
		
		// Label used for setting  LPICKUPSTATE0 
		
		protected System.Web.UI.WebControls.Label LblLPickupState0;
		
		// TextBox used for setting  L_PICKUPSTATE0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Pickupstate0;
		
		// Label used for setting  L_PICKUPZIP0
		
		protected System.Web.UI.WebControls.Label LblLPickupZip0;
		
		// TextBox used for setting  L_PICKUPZIP0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_PickupZip0;
		
		// Label used for setting  L_PICKUPCOUNTRY0
		
		protected System.Web.UI.WebControls.Label LblLPickupCountry0;
		
		// TextBox used for setting  L_PICKUPCOUNTRY0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_PickupCountry0;
		
		// Label used for setting  L_UNSPSCCODE0
		
		protected System.Web.UI.WebControls.Label LblLUnspscCode0;
		
		// TextBox used for setting  L_UNSPSCCODE0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_UnspscCode0;
		
		// Label used for setting  L_WEIGHTUOM0
		
		protected System.Web.UI.WebControls.Label LblLWeightUom0;
		
		// TextBox used for setting  L_WEIGHTUOM0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_WeightUom0;
		
		// Label used for setting  L_HANDLINGUOM0
		
		protected System.Web.UI.WebControls.Label LblLHandlingUom0;
		
		// TextBox used for setting  L_HANDLINGUOM0;
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_HandlingUom0;
		
		// Label used for setting  L_FREIGHTUOM0
		
		protected System.Web.UI.WebControls.Label LblLFreightUom0;
		
		// TextBox used for setting  L_FREIGHTUOM0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_FreightUom0;
		
		// Label used for setting  L_COSTCENTERNUM0
		
		protected System.Web.UI.WebControls.Label LblLCostcenterNum0;
		
		// TextBox used for setting  L_COSTCENTERNUM0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_CostcenterNum0;
		
		// Label used for setting  L_CATALOGNUM0
		
		protected System.Web.UI.WebControls.Label LblLCatalogNum0;
		
		// TextBox used for setting  L_CATALOGNUM0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_CatalogNum0;
		
		// Label used for setting  L_BILLEDUOM0
		
		protected System.Web.UI.WebControls.Label LblLBilledUom0;
		
		// TextBox used for setting  L_BILLEDUOM0
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_BilledUom0;
		
		// Label used for setting  L_AMT1
		
		protected System.Web.UI.WebControls.Label LblLAmt1;
		
		// TextBox used for setting  L_AMT1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Amt1;
		
		// Label used for setting  L_CATEGORY1
		
		protected System.Web.UI.WebControls.Label LblLCategory1;
		
		// TextBox used for setting  L_CATEGORY1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Category1;
		
		// Label used for setting  L_COST1
		
		protected System.Web.UI.WebControls.Label LblLCost1;
		
		// TextBox used for setting  L_COST1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Cost1;
		
		// Label used for setting  L_DESC1
		
		protected System.Web.UI.WebControls.Label LblLDesc1;
		
		// TextBox used for setting  L_DESC1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Desc1;
		
		// Label used for setting  L_DISCOUNT1
		
		protected System.Web.UI.WebControls.Label LblLDiscount1;
		
		// TextBox used for setting  L_DISCOUNT1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Discount1;
		
		// Label used for setting  L_MANUFACTURER1
		
		protected System.Web.UI.WebControls.Label LblLManufacturer1;
		
		// TextBox used for setting  L_MANUFACTURER1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Manufacturer1;
		
		// Label used for setting  L_PRODCODE1
		
		protected System.Web.UI.WebControls.Label LblLProdCode1;
		
		// TextBox used for setting  L_PRODCODE1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_ProdCode1;
		
		// Label used for setting  L_QTY1
		
		protected System.Web.UI.WebControls.Label LblLQty1;
		
		// TextBox used for setting  L_QTY1;
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Qty1;
		
		// Label used for setting  L_SKU1
		
		protected System.Web.UI.WebControls.Label LblLSku1;
		
		// TextBox used for setting  L_SKU1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Sku1;
		
		// Label used for setting  L_TAXAMT1
		
		protected System.Web.UI.WebControls.Label LblLTaxAmt1;
		
		// TextBox used for setting  L_TAXAMT1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TaxAmt1;
		
		// Label used for setting  L_TAXRATE1
		
		protected System.Web.UI.WebControls.Label LblLTaxRate1;
		
		// TextBox used for setting  L_TAXRATE1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TaxRate1;
		
		// Label used for setting  L_TAXTYPE1
		
		protected System.Web.UI.WebControls.Label LblLTaxType1;
		
		// TextBox used for setting  L_TAXTYPE1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TaxType1;
		
		// Label used for setting  L_TYPE1
		
		protected System.Web.UI.WebControls.Label LblLType1;
		
		// TextBox used for setting  L_TYPE1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Type1;
		
		// Label used for setting  L_UOM1
		
		protected System.Web.UI.WebControls.Label LblLUom1;
		
		// TextBox used for setting  L_UOM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Uom1;
		
		// Label used for setting  L_UPC1
		
		protected System.Web.UI.WebControls.Label LblLUpc1;
		
		// TextBox used for setting  L_UPC1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Upc1;
		
		// Label used for setting  L_COMMCODE1
		
		protected System.Web.UI.WebControls.Label LblLCommCode1;
		
		// TextBox used for setting  L_COMMCODE1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Commcode1;
		
		// Label used for setting  L_FREIGHTAMT1
		
		protected System.Web.UI.WebControls.Label LblLFreightAmt1;
		
		// TextBox used for setting  L_FREIGHTAMT1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_FreightAmt1;
		
		// Label used for setting  L_HANDLINGAMT1
		
		protected System.Web.UI.WebControls.Label LblLHandlingAmt1;
		
		// TextBox used for setting  L_HANDLINGAMT1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_HandlingAmt1;
		
		// Label used for setting  L_TRACKINGNUM1
		
		protected System.Web.UI.WebControls.Label LblLTrackingNum1;
		
		// TextBox used for setting  L_TRACKINGNUM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_TrackingNum1;
		
		// Label used for setting  L_PICKUPSTREET1
		
		protected System.Web.UI.WebControls.Label LblLPickupStreet1;
		
		// TextBox used for setting  L_PICKUPSTREET1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Pickupstreet1;
		
		// Label used for setting  L_PICKUPCITY1
		
		protected System.Web.UI.WebControls.Label LblLPickupCity1;
		
		// TextBox used for setting  L_PICKUPCITY1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Pickupcity1;
		
		// Label used for setting  L_PICKUPSTATE1
		
		protected System.Web.UI.WebControls.Label LblLPickupState1;
		
		// TextBox used for setting  L_PICKUPSTATE1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_Pickupstate1;
		
		// Label used for setting  L_PICKUPZIP1
		
		protected System.Web.UI.WebControls.Label LblLPickupZip1;
		
		// TextBox used for setting  L_PICKUPZIP1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_PickupZip1;
		
		// Label used for setting  L_PICKUPCOUNTRY1
		
		protected System.Web.UI.WebControls.Label LblLPickupCountry1;
		
		// TextBox used for setting  L_PICKUPCOUNTRY1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_PickupCountry1;
		
		// Label used for setting  L_UNSPSCCODE1
		
		protected System.Web.UI.WebControls.Label LblLUnspscCode1;
		
		// TextBox used for setting  L_UNSPSCCODE1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_UnspscCode1;
		
		// Label used for setting  L_WEIGHTUOM1
		
		protected System.Web.UI.WebControls.Label LblLWeightUom1;
		
		// TextBox used for setting  L_WEIGHTUOM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_WeightUom1;
		
		// Label used for setting  L_HANDLINGUOM1
		
		protected System.Web.UI.WebControls.Label LblLHandlingUom1;
		
		// TextBox used for setting  L_HANDLINGUOM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_HandlingUom1;
		
		// Label used for setting  L_FREIGHTUOM1
		
		protected System.Web.UI.WebControls.Label LblLFreightUom1;
		
		// TextBox used for setting  L_FREIGHTUOM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_FreightUom1;
		
		// Label used for setting  L_COSTCENTERNUM1
		
		protected System.Web.UI.WebControls.Label LblLCostcenterNum1;
		
		// TextBox used for setting  L_COSTCENTERNUM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_CostcenterNum1;
		
		// Label used for setting  CATALOGNUM1
		
		protected System.Web.UI.WebControls.Label LblLCatalogNum1;
		
		// TextBox used for setting  CATALOGNUM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_CatalogNum1;
		
		// Label used for setting  BILLEDUOM1
		
		protected System.Web.UI.WebControls.Label LblLBilledUom1;
		
		// TextBox used for setting  BILLEDUOM1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxL_BilledUom1;
		
		// Label used for setting  EXTEND_FIELD1
		
		protected System.Web.UI.WebControls.Label LblExtendField1;
		
		// TextBox used for setting  EXTEND_FIELD1
		
		protected System.Web.UI.WebControls.TextBox TxtBoxExtend_Field1;
		
		// Label used for setting  EXTEND_FIELD2
		
		protected System.Web.UI.WebControls.Label LblExtendField2;
		
		// TextBox used for setting  EXTEND_FIELD2
		
		protected System.Web.UI.WebControls.TextBox TxtBoxExtend_Field2;
		
		// Button used for setting  SUBMITTRANSACTION
		
		protected System.Web.UI.WebControls.Button BtnSubmitTransaction;
		
		// Panel used for setting  SAMPLESTOREused for setting M
		
		protected System.Web.UI.WebControls.Panel PnlSampleStoreForm;
		
		// DataGrid used for setting  TRANSACTION
		
		protected System.Web.UI.WebControls.DataGrid TransactionDataGrid;
		
		// DataGrid used for setting  RECURRING
		
		protected System.Web.UI.WebControls.DataGrid RecurringDataGrid;
		
		// Button used for setting  FOLLOWONRECURRING
		
		protected System.Web.UI.WebControls.Button BtnFollowOnRecurring;
		
		// DataGrid used for setting  FRAUD
		
		protected System.Web.UI.WebControls.DataGrid FraudDataGrid;
		
		// Panel used for setting  STRONGASSEMBLYRESPONSE
		
		protected System.Web.UI.WebControls.Panel PnlStrongAssemblyResponse;
		
		// Label used for setting  HEADER
		
		protected System.Web.UI.WebControls.Label LblHeader;
		
		// TextBox used for setting  WEAKASSEMBLYRESPONSE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxWeakAssemblyResponse;
		
		// Button used for setting  WEAKASSEMBLYFOLLOWON
		
		protected System.Web.UI.WebControls.Button BtnWeakAssemblyFollowOn;
		
		// Panel used for setting  WEAKASSEMBLYRESPONSE
		
		protected System.Web.UI.WebControls.Panel PnlWeakAssemblyResponse;
		
		// DataGrid used for setting  CONTEXT
		
		protected System.Web.UI.WebControls.DataGrid ContextDataGrid;
		
		// Label used for setting  BILLHOMEPHONE
		
		protected System.Web.UI.WebControls.Label LblBillHomePhone;
		
		// TextBox used for setting  BILLHOMEPHONE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxBillHomePhone;
		
		// Label used for setting  COMMCODE
				
		protected System.Web.UI.WebControls.Label LblCommCode;
		
		// TextBox used for setting  COMMCODE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxCommCode;
		
		// Label used for setting  VATAXPERCENT
		
		protected System.Web.UI.WebControls.Label LblVaTaxPercent;
		
		// TextBox used for setting  VATAXPERCENT
		
		protected System.Web.UI.WebControls.TextBox TxtBoxVaTaxPercent;
		
		// Label used for setting  ORDERDATE
		
		protected System.Web.UI.WebControls.Label LblOrderDate;
		
		// TextBox used for setting  ORDERDATE
		
		protected System.Web.UI.WebControls.TextBox TxtBoxOrderDate;
		
		// Label used for setting  ORDERTIME
		
		protected System.Web.UI.WebControls.Label LblOrderTime;
		
		// TextBox used for setting  ORDERTIME
		
		protected System.Web.UI.WebControls.TextBox TxtBoxOrderTime;
		
		// Button used for setting  RESET
		
		protected System.Web.UI.WebControls.Button BtnReset;
		
		// Button used for setting  FOLLOWONTRANSACTION
		
		protected System.Web.UI.WebControls.Button BtnFollowOnTransaction;
		// <summary>
		// Label used for setting  BANKNAME
		// </summary>
		//protected System.Web.UI.WebControls.Label LblBankName;
		// <summary>
		// TextBox used for setting  BANKNAME
		// </summary>
		//protected System.Web.UI.WebControls.TextBox TxtBoxBankName;
		// <summary>
		// Label used for setting  BANKSTATE
		// </summary>
		//protected System.Web.UI.WebControls.Label LblBankState;
		// <summary>
		// TextBox used for setting  BANKSTATE
		// </summary>
		//protected System.Web.UI.WebControls.TextBox TxtBoxBankState;
		// <summary>
		// Label used for setting  CONSENTMEDIUM
		// </summary>
		//protected System.Web.UI.WebControls.Label LblConsentMedium;
		// <summary>
		// TextBox used for setting  CONSENTMEDIUM
		// </summary>
		//protected System.Web.UI.WebControls.TextBox TxtBoxConsentMedium;
		// <summary>
		// Label used for setting  CUSTOMERTYPE
		// </summary>
		//protected System.Web.UI.WebControls.Label LblCustomerType;
		// <summary>
		// TextBox used for setting  CUSTOMERTYPE
		// </summary>
		//protected System.Web.UI.WebControls.TextBox TxtBoxCustomerType;
		// <summary>
		// Label used for setting  DLSTATE
		// </summary>
		//protected System.Web.UI.WebControls.Label LblDLState;
		// <summary>
		// TextBox used for setting  DLSTATE
		// </summary>
		//protected System.Web.UI.WebControls.TextBox TxtBoxDLState;
		
		// Panel used for setting  CONTEXTERROR
		
		protected System.Web.UI.WebControls.Panel PnlContextError;
		
		// Label used for setting  VALIDERROR
		
		protected System.Web.UI.WebControls.Label LblValidError;
		
		// Label used for setting  VALIDMSG
		
		protected System.Web.UI.WebControls.Label LblValidMsg;
		
		// Label used for setting  Status Response
		
		protected System.Web.UI.WebControls.Label LblStatusResponse;
		
		// Label Header for displaying status of Transaction
		
		protected System.Web.UI.WebControls.Label LblStatus;
		
		// Button for traversing BACK in case of error on Strong Assembly
		
		protected System.Web.UI.WebControls.Button BtnStrongBack;
		
		// Label for VITIntegrationProduct
		
		protected System.Web.UI.WebControls.Label LblVITIntegrationProduct;
		
		// TextBox for VITIntegrationProduct
		
		protected System.Web.UI.WebControls.TextBox TxtBoxVITIntegrationProduct;
		
		// Label for VITIntegrationVersion
		
		protected System.Web.UI.WebControls.Label LblVITIntegrationVersion;
		
		// TextBox for VITIntegrationVersion
		
		protected System.Web.UI.WebControls.TextBox TxtBoxVITIntegrationVersion;
		
		// Button used for going BACK in case of Context error
		
		protected System.Web.UI.WebControls.Button BtnBack;
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (! IsPostBack)
			{
				DisplaySampleStore();
			}
		}
		private void CboRequestType_SelectedIndexChanged (System.Object sender, System.EventArgs e)
		{
			SetValueInFields(CboRequestType.Items[CboRequestType.SelectedIndex].Value);
		}

		private void DisplaySampleStore ()
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.DisplaySampleStore(): Entered", PayflowConstants.SEVERITY_DEBUG);
			
			PnlStrongAssemblyResponse.Visible = false;
			PnlSampleStoreForm.Visible = true;
			PnlWeakAssemblyResponse.Visible = false;
			TblError.Visible = false;
			ContextDataGrid.Visible = false; 
			LblStatus.Visible = false;
			LblStatusResponse.Visible = false; 

			string mOrigId = System.Convert.ToString(ViewState[SampleStoreConstants.CONTEXT_ORIGID]);
			string mProfileId = System.Convert.ToString(ViewState[SampleStoreConstants.CONTEXT_PROFILEID]);
			
			if (! (object.Equals(mOrigId, null) || object.Equals(mOrigId, SampleStoreConstants.EMPTY_STRING) ))
			{
				SetDataInFields();
				if (CboRequestType.Items[CboRequestType.SelectedIndex].Value == SampleStoreConstants.REQUESTTYPE_STRONGASSEMBLY)
				{
					EnableControls(true);
					TxtBoxWeakAssemblyRequest.ReadOnly = true;
				}
				else
				{
					EnableControls(false);
					TxtBoxWeakAssemblyRequest.ReadOnly = false;
				}
				TxtBoxOrigId.Text = mOrigId;
			}
			else if (! (object.Equals(mProfileId, null) || object.Equals(mProfileId, SampleStoreConstants.EMPTY_STRING)))
			{
				SetDataInFields();
				TxtBoxOrigProfileId.Text = mProfileId;
			}
			else
			{
				SetValueInFields(CboRequestType.Items[CboRequestType.SelectedIndex].Value);
			}
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.DisplaySampleStore(): Exiting", PayflowConstants.SEVERITY_DEBUG);
		}

		private void SetDataInFields ()
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetDataInFields(): Entered", PayflowConstants.SEVERITY_DEBUG);
			Hashtable RequestData = new Hashtable();
			System.Collections.ICollection mKeysColl;
			System.Collections.IEnumerator mKeysEnum;
			Control mControl;
			
			RequestData = ((Hashtable)(Context.Items[SampleStoreConstants.CONTEXT_REQUESTDATA]));
			mKeysColl = RequestData.Keys; 
			mKeysEnum = mKeysColl.GetEnumerator();
			
			while (mKeysEnum.MoveNext())
			{
				if (mKeysEnum.Current.ToString().StartsWith("TxtBox"))
				{
					mControl = this.FindControl(mKeysEnum.Current.ToString());
					((TextBox)(mControl)).Text = System.Convert.ToString(RequestData[mKeysEnum.Current.ToString()]);
				}
				else if (mKeysEnum.Current.ToString().StartsWith("Cbo"))
				{
					mControl = this.FindControl(mKeysEnum.Current.ToString());
					((DropDownList)(mControl)).SelectedValue = System.Convert.ToString(RequestData[mKeysEnum.Current.ToString()]);
				}
			}
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetDataInFields(): Exiting", PayflowConstants.SEVERITY_DEBUG);
		}
		private static bool CheckIfFollowOnValid(string TrxType)
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.CheckIfFollowOnValid(): Entered", PayflowConstants.SEVERITY_DEBUG);
			bool mRetVal;
			if (object.Equals(TrxType, SampleStoreConstants.TRXTYPE_VOICEAUTH)) 
			{
				mRetVal = false;
			}
			else
			{
				mRetVal = true;
			}
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.UI.Controller.CheckIfFollowOnValid(String) : Returning - " + mRetVal.ToString(), PayflowConstants.SEVERITY_INFO);
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.CheckIfFollowOnValid(): Exiting", PayflowConstants.SEVERITY_DEBUG);
			return mRetVal;
		}
		private void EnableControls (bool Mode)
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.EnableControls(Boolean): Entered", PayflowConstants.SEVERITY_DEBUG);
			System.Web.UI.ControlCollection mPanelCtrlColl;
			System.Web.UI.Control mControlInPanel;
			System.Web.UI.WebControls.TextBox mTextBoxControl;
			System.Web.UI.WebControls.DropDownList mDropDownControl;
			
			mPanelCtrlColl = PnlSampleStoreForm.Controls;
			
			foreach (System.Web.UI.Control tempLoopVar_mControlInPanel in mPanelCtrlColl)
			{
				mControlInPanel = tempLoopVar_mControlInPanel;
				if (mControlInPanel is System.Web.UI.WebControls.TextBox)
				{				
					if (mControlInPanel.ID == SampleStoreConstants.FIELD_REQUESTID)
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = false;
					}
					else if (mControlInPanel.ID == SampleStoreConstants.FIELD_VIT_INTEGRATION_PRODUCT)
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = false;
					}
					else if (mControlInPanel.ID == SampleStoreConstants.FIELD_VIT_INTEGRATION_VERSION)
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = false;
					}
					else if (mControlInPanel.ID == SampleStoreConstants.FIELD_PROXYADDRESS)
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = false;
					}
					else if (mControlInPanel.ID == SampleStoreConstants.FIELD_PROXYPORT)
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = false;
					}
					else if (mControlInPanel.ID == SampleStoreConstants.FIELD_PROXYLOGON)
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = false;
					}
					else if (mControlInPanel.ID == SampleStoreConstants.FIELD_PROXYPASSWORD)
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = false;
					}
					else 
					{
						mTextBoxControl = (System.Web.UI.WebControls.TextBox) mControlInPanel;
						mTextBoxControl.ReadOnly = !Mode;
					}
				}
				else if (mControlInPanel is System.Web.UI.WebControls.DropDownList)
				{
					if (mControlInPanel.ID != SampleStoreConstants.FIELD_REQUESTTYPE)
					{
						mDropDownControl = (System.Web.UI.WebControls.DropDownList) mControlInPanel;
						mDropDownControl.Enabled = Mode;
					}
				}
			}
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.EnableControls(Boolean): Exiting", PayflowConstants.SEVERITY_DEBUG);
		}
		private void SetSADefaultValues ()
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetSADefaultValues(): Entered", PayflowConstants.SEVERITY_DEBUG);
			
			SampleStoreUtil.SetValueInDropDown(CboTender, "Credit Card");
			SampleStoreUtil.SetValueInDropDown(CboTrxType, "Sale");
			SampleStoreUtil.SetValueInDropDown(CboExpiryMonth, "January");
			SampleStoreUtil.SetValueInDropDown(CboExpiryYear, "2009");
			SampleStoreUtil.SetValueInDropDown(CboCurrency, "");
	        TxtBoxPartner.Text = "partner";
	        TxtBoxUser.Text = "user";
            TxtBoxVendor.Text = "vendor";
		    TxtBoxAmt.Text = "25.00";
			TxtBoxAcct.Text = "5100000000000008";
			TxtBoxInvNum.Text = "INV12345";
			TxtBoxPoNum.Text = "PO12345";
			TxtBoxStreet.Text = "123 Main St.";
			TxtBoxZip.Text = "12345";
			TxtBoxCvv2.Text = "123";
			TxtBoxVITIntegrationProduct.Text = "PYPL_dotNET_C#SampleStore";
			TxtBoxVITIntegrationVersion.Text = "1.0";
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetSADefaultValues(): Exiting", PayflowConstants.SEVERITY_DEBUG);
		}
		private void SetWADefaultValues ()
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetWADefaultValues(): Entered", PayflowConstants.SEVERITY_DEBUG);
			TxtBoxVITIntegrationProduct.Text = "PYPL_dotNET_C#SampleStore";
			TxtBoxVITIntegrationVersion.Text = "1.0";
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetWADefaultValues(): Exiting", PayflowConstants.SEVERITY_DEBUG);
		}
		private void SetValueInFields (string SelectedValue)
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetValueInFields(String): Entered", PayflowConstants.SEVERITY_DEBUG);
			if (SelectedValue == SampleStoreConstants.REQUESTTYPE_STRONGASSEMBLY)
			{
				EnableControls(true);
				SetSADefaultValues();
				TxtBoxWeakAssemblyRequest.ReadOnly = true;
				TxtBoxWeakAssemblyRequest.Text = "";
				TxtBoxRequestId.Text = "";
				LblWeakAssemblyRequest.Text = "NAME-VALUE PAIR REQUEST";
			}
			else if (SelectedValue == SampleStoreConstants.REQUESTTYPE_WEAKASSEMBLY_NVP)
			{
				EnableControls(false);
				SetWADefaultValues();
				TxtBoxWeakAssemblyRequest.ReadOnly = false;
				TxtBoxWeakAssemblyRequest.Text = "TRXTYPE=S&ACCT=5105105105105100&EXPDATE=0109&TENDER=C&INVNUM=INV12345&AMT=25.12&PONUM=PO12345&STREET=123 Main St.&ZIP=12345&CVV2=123&USER=<user>&VENDOR=<vendor>&PARTNER=<partner>&PWD=<password>";
				LblWeakAssemblyRequest.Text = "NAME-VALUE PAIR REQUEST";
			}
//			else if (SelectedValue == SampleStoreConstants.REQUESTTYPE_WEAKASSEMBLY_XML10)
//			{
//				EnableControls(false);
//				TxtBoxWeakAssemblyRequest.ReadOnly = false;
//				TxtBoxWeakAssemblyRequest.Text = "<?xml version=\'1.0\'?><XMLPayRequest Timeout=\'30\' version=\'1.0\'> <RequestData> <Vendor>OIPTestAcct</Vendor> <Partner>ReSellerA</Partner> <Transactions> <Transaction> <Sale> <PayData> <Invoice> <NationalTaxIncl>N</NationalTaxIncl> <TotalAmt>100.01</TotalAmt> </Invoice> <Tender> <Card> <CardType>visa</CardType> <CardNum>5105105105105100</CardNum> <ExpDate>200911</ExpDate> <NameOnCard>Joe Smith</NameOnCard> </Card> </Tender> </PayData> </Sale> </Transaction> </Transactions> </RequestData> <RequestAuth> <UserPass> <User>OIPTestAcct</User> <Password>infosys123</Password> </UserPass> </RequestAuth> </XMLPayRequest>";
//				LblWeakAssemblyRequest.Text = "XML PAY 1.0 REQUEST";
//			}
			else if (SelectedValue == SampleStoreConstants.REQUESTTYPE_WEAKASSEMBLY_XML20)
			{
				EnableControls(false);
				SetWADefaultValues();
				TxtBoxWeakAssemblyRequest.ReadOnly = false;
				TxtBoxWeakAssemblyRequest.Text = "<?xml version='1.0'?><XMLPayRequest Timeout='45' version='2.0'><RequestData><Partner>partner</Partner><Vendor>vendor</Vendor><Transactions><Transaction><Sale><PayData><Invoice><TotalAmt Currency='840'>25.12</TotalAmt><InvNum>INV12345</InvNum><BillTo><PONum>PO12345</PONum><Address><Street>123 Main St.</Street><Zip>12345</Zip></Address></BillTo></Invoice><Tender><Card><CardNum>5105105105105100</CardNum><ExpDate>200901</ExpDate><CVNum>123</CVNum></Card></Tender></PayData></Sale></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>user</User><Password>password</Password></UserPass></RequestAuth></XMLPayRequest>";
				LblWeakAssemblyRequest.Text = "XMLPAY 2.0 REQUEST";
			}
			TblError.Visible = false;
			TxtBoxOrigId.Text = "";
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SetValueInFields(String): Entered", PayflowConstants.SEVERITY_DEBUG);
		}
		private bool ValidateMe()
		{
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.ValidateMe(): Entered", PayflowConstants.SEVERITY_DEBUG);
			bool mHasError = false;
			string mErrorMessage = "";
			
			if (!(object.Equals(TxtBoxOrigId.Text, null) | object.Equals(TxtBoxOrigId.Text, SampleStoreConstants.EMPTY_STRING)))
			{
				if (! CheckIfFollowOnValid(CboTrxType.Items[CboTrxType.SelectedIndex].Value))
				{
					mHasError = true;
					mErrorMessage = SampleStoreConstants.ERRMSG_INVALIDFOLLOWON;
				}
			}
			
			if (object.Equals(CboAction.Items[CboAction.SelectedIndex].Value, null) | object.Equals(CboAction.Items[CboAction.SelectedIndex].Value, "") & object.Equals(CboTrxType.Items[CboTrxType.SelectedIndex].Value, SampleStoreConstants.TRXTYPE_RECURRING))
			{
				mHasError = true;
				if (mErrorMessage.Length > 0)
				{
					mErrorMessage += "<BR>";
				}
				mErrorMessage += SampleStoreConstants.ERRMSG_INVALIDACTION;
			}
			
			if (mHasError)
			{
				TblError.Visible = true;				
				LblValidError.Text = "Validation Error";
				LblValidMsg.Text = mErrorMessage;
			}
			
			Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.ValidateMe(): Exiting", PayflowConstants.SEVERITY_DEBUG);
			return mHasError;
			
		}
		private void SubmitForm ()
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SubmitForm(): Entered", PayflowConstants.SEVERITY_DEBUG);
				if (! ValidateMe())
				{
					PayPal.Payments.SampleStore.CS.UI.Controller objController=new PayPal.Payments.SampleStore.CS.UI.Controller(Request, Context, Server);
					if (object.Equals(SampleStoreConstants.REQUESTTYPE_STRONGASSEMBLY, Request[SampleStoreConstants.FIELD_REQUESTTYPE]))
					{
						StrongAssemblyResponse();
					}
					else
					{
						WeakAssemblyResponse();
					}
				}
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.SubmitForm(): Exiting", PayflowConstants.SEVERITY_DEBUG);
			}
			catch (System.Threading.ThreadAbortException)
			{
				//Do nothing. If removed, throws error during redirecting
				//Catch baex As Exceptions.BaseException
				//   HttpResponse.Redirect(ErrorPageUrl.ToString & "?ErrorMessage=" & baex.ToString())
			}
			catch (Exception Ex)
			{
				//Context.Items.Add(SampleStoreConstants.CONTEXT_EXCEPTIONMESSAGE, Ex.Message);
				//Server.Transfer(ToString());
				Hashtable mWAError = new Hashtable();
				mWAError.Add("Error Message", Ex.Message);
				ContextDataGrid.DataSource = mWAError;
				ContextDataGrid.DataBind();
				PnlStrongAssemblyResponse.Visible = false;
				PnlSampleStoreForm.Visible = false;
				PnlWeakAssemblyResponse.Visible = false;
				ContextDataGrid.Visible = true;
				BtnFollowOnTransaction.Visible = false;
				BtnBack.Visible = true;
				BtnStrongBack.Visible = false;

			}
		}
		private static bool IsErrorInWAResponse(string WAResponse)
		{
			bool mRetVal = false;
			if(!(WAResponse.IndexOf("<XMLPay") >= 0)) {
				if (WAResponse.IndexOf("RESULT") < 0)
				{
					mRetVal = true;
				}
				}
			return mRetVal;
		}
		private void WeakAssemblyResponse ()
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.WeakAssemblyResponse(): Entered", PayflowConstants.SEVERITY_DEBUG);
				Hashtable ResponseData = new Hashtable();
				String mResponse = System.Convert.ToString(Context.Items[SampleStoreConstants.CONTEXT_WEAKASSEMBLYRESPONSE]);

                string TransResponse = "";
				string StatusTransResponse = "";
                
                if (mResponse.IndexOf ("^" ) > 0)
				{
                    StatusTransResponse = mResponse.Substring (0,mResponse.IndexOf ("^"));
					TransResponse = "Transaction Response :" + Environment.NewLine  + StatusTransResponse;
				}
				mResponse = TransResponse;

                TxtBoxWeakAssemblyResponse.Text = mResponse + Environment.NewLine;
				
				
				//update the status
				
				LblStatus.Visible = true;
				LblStatusResponse.Visible = true;
				LblStatusResponse.Text= PayflowUtility.GetStatus (StatusTransResponse);
				
				if (StatusTransResponse.IndexOf ("<XMLPay") >= 0)
				{
					StatusTransResponse = PayflowUtility.GetXmlPayNodeValue(StatusTransResponse ,"Result");  
				}
				else
				{
					StatusTransResponse = PayflowUtility.LocateValueForName (StatusTransResponse ,"RESULT",false);  
				}
				if (StatusTransResponse == "0")
				{
					LblStatusResponse.ForeColor = System.Drawing.Color.Green;
				}
				else
				{
					LblStatusResponse.ForeColor = System.Drawing.Color.Red;
				}
				
				ViewState.Add(SampleStoreConstants.CONTEXT_TEMPDATA, Context.Items[SampleStoreConstants.CONTEXT_REQUESTDATA]);
				if (mResponse.IndexOf("<XMLPay") >= 0)
				{
					//The following line has been added to trim extra string before the xml response
					mResponse=mResponse.Substring(mResponse.IndexOf("<XMLPay"),(mResponse.Length-mResponse.IndexOf("<XMLPay")));
					
					System.IO.StringReader textReader = new System.IO.StringReader(mResponse);
					System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(textReader);
					do
					{
						if (reader.NodeType == XmlNodeType.Element)
						{
							if (reader.Name.ToUpper() == "PNREF")
							{
								ViewState.Add(SampleStoreConstants.CONTEXT_ORIGID, reader.ReadString());
								break;
							}
						}
					} while (reader.Read());
				}
				else
				{
					ResponseData =  SampleStoreUtil.ConvertStringToHashTbl(mResponse, SampleStoreConstants.NV_DELIMITER);
					if (!(object.Equals(ResponseData["PNREF"], SampleStoreConstants.EMPTY_STRING) | object.Equals(ResponseData["PNREF"], null)))
					{
						ViewState.Add(SampleStoreConstants.CONTEXT_ORIGID, ResponseData["PNREF"].ToString());
					}
				}

				if (IsErrorInWAResponse(mResponse))
				{
					//Context.Items.Add(SampleStoreConstants.CONTEXT_ERRORMESSAGE, mResponse);
					Hashtable mWAError = new Hashtable();
					mWAError.Add("Error Message", mResponse);
					ContextDataGrid.DataSource = mWAError;
					ContextDataGrid.DataBind();
					ContextDataGrid.Visible = true;
					BtnWeakAssemblyFollowOn.Visible = false;
					PnlWeakAssemblyResponse.Visible = false;
				}
				else
				{
					BtnWeakAssemblyFollowOn.Visible = true;
					PnlWeakAssemblyResponse.Visible = true;
				}
				PnlStrongAssemblyResponse.Visible = false;
				PnlSampleStoreForm.Visible = false;
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.WeakAssemblyResponse(): Exiting", PayflowConstants.SEVERITY_DEBUG);
			}
			catch (Exception Ex)
			{
				throw (new Exception(Ex.Message, Ex));
			}
		}
		private void StrongAssemblyResponse ()
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.StrongAssemblyResponse(): Entered", PayflowConstants.SEVERITY_DEBUG);
				Hashtable TransactionResponse = new Hashtable();
				Hashtable RecurringResponse = new Hashtable();
				Hashtable FraudResponse = new Hashtable();
				Hashtable ContextResponse = new Hashtable();
				System.Collections.ICollection ValColl;
				System.Collections.IEnumerator ValEnum;
				object mResponse = Context.Items["ResponseObject"];

				PayPal.Payments.DataObjects.Response responsedata=(PayPal.Payments.DataObjects.Response) mResponse;

				ViewState.Add(SampleStoreConstants.CONTEXT_TEMPDATA, Context.Items[SampleStoreConstants.CONTEXT_REQUESTDATA]);
				
				TransactionResponse = GetResponseInHashTbl(responsedata, "Transaction");
				
				if (! object.Equals(TransactionResponse, null))
				{
					if (!(object.Equals(TransactionResponse["PNREF"], null) | object.Equals(TransactionResponse["PNREF"], SampleStoreConstants.EMPTY_STRING)))
					{
						ViewState.Add(SampleStoreConstants.CONTEXT_ORIGID, TransactionResponse["PNREF"].ToString());
						BtnFollowOnTransaction.Visible = true;
					}
					else
					{
						BtnFollowOnTransaction.Visible = false;
					}
					
					TransactionDataGrid.DataSource = TransactionResponse;
					TransactionDataGrid.DataBind();
				}
				 string TrxResult;
                TrxResult = (string)TransactionResponse["RESULT"];
				
				RecurringResponse = GetResponseInHashTbl(responsedata, "Recurring");
				BtnFollowOnRecurring.Visible = false;
                RecurringDataGrid.Visible = false;
				if (!object.Equals(RecurringResponse, null))
				{
					ValColl = RecurringResponse.Values;
					ValEnum = ValColl.GetEnumerator();
					while (ValEnum.MoveNext())
					{
						if (!(object.Equals(ValEnum.Current, null) || object.Equals(ValEnum.Current, SampleStoreConstants.EMPTY_STRING)))
						{
							
							if (!(object.Equals(RecurringResponse["PROFILEID"], null) || object.Equals(RecurringResponse["PROFILEID"], SampleStoreConstants.EMPTY_STRING)))
							{
								ViewState.Add(SampleStoreConstants.CONTEXT_PROFILEID, RecurringResponse["PROFILEID"].ToString());
								//LblProfileId.Text = "Click on the button to perform recurring follow on transaction :"
								BtnFollowOnRecurring.Visible = true;
								RecurringDataGrid.Visible = true;
							}
							else
							{
								//LblProfileId.Text = ""
								BtnFollowOnRecurring.Visible = false;
								RecurringDataGrid.Visible = false;
							}
							
							RecurringDataGrid.DataSource = RecurringResponse;
							RecurringDataGrid.DataBind();
							break;
						}
					}
				}
				
				
				FraudResponse = GetResponseInHashTbl(responsedata, "Fraud");
				if (! object.Equals(FraudResponse, null))
				{
					ValColl = FraudResponse.Values;
					ValEnum = ValColl.GetEnumerator();
					while (ValEnum.MoveNext())
					{
						if (!(object.Equals(ValEnum.Current, null) | object.Equals(ValEnum.Current, SampleStoreConstants.EMPTY_STRING)))
						{
							FraudDataGrid.DataSource = FraudResponse;
							FraudDataGrid.DataBind();
							break;
						}
					}
				}
				
				ContextResponse = GetResponseInHashTbl(responsedata, "Context");
				if (! object.Equals(ContextResponse, null))
				{
					ValColl = ContextResponse.Values;
					ValEnum = ValColl.GetEnumerator();
					while (ValEnum.MoveNext())
					{
						if (!(object.Equals(ValEnum.Current, null) | object.Equals(ValEnum.Current, SampleStoreConstants.EMPTY_STRING)))
						{
							ContextDataGrid.DataSource = ContextResponse;
							ContextDataGrid.DataBind();
							ContextDataGrid.Visible = true;
							break;
						}
					}
				}
				PnlStrongAssemblyResponse.Visible = true;
				PnlSampleStoreForm.Visible = false;
				PnlWeakAssemblyResponse.Visible = false;
				LblStatus.Visible = true;
                LblStatusResponse.Visible = true;
				bool TrxSuccess;
				TrxSuccess =  "0".Equals(TrxResult);;
				if(!TrxSuccess)
				{
					LblStatusResponse.Text= SampleStoreConstants.MSG_FAILURE;
					LblStatusResponse.ForeColor = System.Drawing.Color.Red;
				}
                else
				{
					LblStatusResponse.Text = SampleStoreConstants.MSG_SUCCESS;
					LblStatusResponse.ForeColor = System.Drawing.Color.Green;
				}
               
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.StrongAssemblyResponse(): Exiting", PayflowConstants.SEVERITY_DEBUG);
			}
			catch (Exception Ex)
			{
				throw (new Exception(Ex.Message, Ex));
			}
		}
		private static Hashtable GetResponseInHashTbl(Response Response, string ResponseType)
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.GetResponseInHashTbl(Response,As String): Entered", PayflowConstants.SEVERITY_DEBUG);
				Hashtable mRetVal = new Hashtable();
				
				switch (ResponseType)
				{
					case "Transaction":
						
						TransactionResponse mTransresponse = Response.TransactionResponse;
						if (object.Equals(mTransresponse, null))
						{
							break;
						}
						
						mRetVal.Add("AUTHCODE", mTransresponse.AuthCode);
						mRetVal.Add("AVSADDR", mTransresponse.AVSAddr);
						mRetVal.Add("AVSZIP", mTransresponse.AVSZip);
						mRetVal.Add("CARDSECURE", mTransresponse.CardSecure);
						mRetVal.Add("CVV2MATCH", mTransresponse.CVV2Match);
						mRetVal.Add("IAVS", mTransresponse.IAVS);
						mRetVal.Add("PNREF", mTransresponse.Pnref);
						mRetVal.Add("REQUEST", Response.RequestString);
						mRetVal.Add("REQUESTID", Response.RequestId);
						mRetVal.Add("RESPMSG", mTransresponse.RespMsg);
						mRetVal.Add("RESPONSE", Response.ResponseString);
						if (! object.Equals(mTransresponse.Result, null))
						mRetVal.Add("RESULT", mTransresponse.Result.ToString() );
						mRetVal.Add("CUSTREF", mTransresponse.CustRef);
						mRetVal.Add("ORIGRESULT", mTransresponse.OrigResult);
						mRetVal.Add("TRANSSTATE", mTransresponse.TransState);
						mRetVal.Add("STARTTIME", mTransresponse.StartTime);
						mRetVal.Add("ENDTIME", mTransresponse.EndTime);
						mRetVal.Add(SampleStoreConstants.RESP_TRANS_ADDLMSGS, mTransresponse.AddlMsgs );
						mRetVal.Add(SampleStoreConstants.RESP_TRANS_HOSTCODE, mTransresponse.HostCode );
						mRetVal.Add(SampleStoreConstants.RESP_TRANS_PROCAVS, mTransresponse.ProcAVS );
						mRetVal.Add(SampleStoreConstants.RESP_TRANS_PROCCARDSECURE, mTransresponse.ProcCardSecure );
						mRetVal.Add(SampleStoreConstants.RESP_TRANS_PROCCVV2, mTransresponse.ProcCVV2 );
						mRetVal.Add(SampleStoreConstants.RESP_TRANS_RESPTEXT, mTransresponse.RespText );
						mRetVal.Add("DUPLICATE", mTransresponse.Duplicate);
						//Added as SETTLE_DATE param is also available when VERBOSITY= MEDIUM
						//2005-12-10
						mRetVal.Add(SampleStoreConstants.RESP_TRANS_SETTLE_DATE, mTransresponse.SettleDate );
						mRetVal.Add("ORIGPNREF", mTransresponse.OrigPnref);
						break;
					case "Fraud":
						
						FraudResponse mFraudResp = Response.FraudResponse;
						if (object.Equals(mFraudResp, null))
						{
							break;
						}
						
						FpsXmlData mFpsXmlData;
						ArrayList mRules = new ArrayList();
						PayPal.Payments.DataObjects.Rule mRuleType;
						RuleParameter mRuleVendorParamType;
						ArrayList mRuleVendorParams = new ArrayList();
						
						
						mRetVal.Add(SampleStoreConstants.RESP_FRAUD_POSTFPSMESSAGE, mFraudResp.PostFpsMsg );
						mRetVal.Add(SampleStoreConstants.RESP_FRAUD_PREFPSMESSAGE, mFraudResp.PreFpsMsg );
						
						
						mFpsXmlData = mFraudResp.Fps_PreXmlData;
						mRules = mFpsXmlData.Rules;
						int i=0;
						foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
						{
							mRuleType = tempLoopVar_mRuleType;
							
							mRetVal.Add("ACTION FOR RULE ID - " + mRuleType.RuleId, mRuleType.Action);
							mRetVal.Add("NUM FOR RULE ID - " + mRuleType.RuleId, mRuleType.Num);
							mRetVal.Add("RULEALIAS FOR RULE ID - " + mRuleType.RuleId, mRuleType.RuleAlias);
							mRetVal.Add("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId, mRuleType.RuleDescription);
							mRetVal.Add("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId, mRuleType.TriggeredMessage);
							
							mRuleVendorParams = mRuleType.RuleVendorParms;
							i=0;
							foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
							{
								mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
								mRetVal.Add("Name_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Name);
								mRetVal.Add("Num_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Num);
								mRetVal.Add("Type_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Type);
								mRetVal.Add("Value_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Value);
							   i++;
							}
						}
						
						mFpsXmlData = mFraudResp.Fps_PostXmlData;
						mRules = mFpsXmlData.Rules;
						foreach (PayPal.Payments.DataObjects.Rule tempLoopVar_mRuleType in mRules)
						{
							mRuleType = tempLoopVar_mRuleType;
							
							mRetVal.Add("RuleId", mRuleType.RuleId);
							mRetVal.Add("ACTION FOR RULE ID - " + mRuleType.RuleId, mRuleType.Action);
							mRetVal.Add("NUM FOR RULE ID - " + mRuleType.RuleId, mRuleType.Num);
							mRetVal.Add("RULEALIAS FOR RULE ID - " + mRuleType.RuleId, mRuleType.RuleAlias);
							mRetVal.Add("RULEDESCRIPTION FOR RULE ID - " + mRuleType.RuleId, mRuleType.RuleDescription);
							mRetVal.Add("TRIGGEREDMESSAGE FOR RULE ID - " + mRuleType.RuleId, mRuleType.TriggeredMessage);
							
							mRuleVendorParams = mRuleType.RuleVendorParms;
							i=0;
							foreach (RuleParameter tempLoopVar_mRuleVendorParamType in mRuleVendorParams)
							{
								mRuleVendorParamType = tempLoopVar_mRuleVendorParamType;
								mRetVal.Add("NAME_"+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Name);
								mRetVal.Add("NUM "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Num);
								mRetVal.Add("TYPE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Type);
								mRetVal.Add("VALUE "+i.ToString()+" FOR RULE ID -"+mRuleType.RuleId, mRuleVendorParamType.Value);
							    i++;
							}
						}
						break;
					case "Context":
						
						PayPal.Payments.Common.Context mContext = Response.TransactionContext;
						if (object.Equals(mContext, null))
						{
							break;
						}
						
						ArrayList mErrors = new ArrayList();
						PayPal.Payments.Common.ErrorObject mError;
						
						mErrors = mContext.GetErrors(PayflowConstants.SEVERITY_ERROR);
						 i=0;
						foreach (PayPal.Payments.Common.ErrorObject tempLoopVar_mError in mErrors)
						{
							mError = tempLoopVar_mError;
							mRetVal.Add(mError.MessageCode+"*"+i.ToString(), mError.ToString() );
							i++;
						}
						break;
					case "Recurring":
						
						RecurringResponse mRecurring = Response.RecurringResponse;
						if (object.Equals(mRecurring, null))
						{
							break;
						}
						
						mRetVal.Add("ACCT", mRecurring.Acct );
						mRetVal.Add("AGGREGATEAMT", mRecurring.AggregateAmt );
						mRetVal.Add("AGGREGATEOPTAMT", mRecurring.AggregateOptionalAmt );
						mRetVal.Add("AMT", mRecurring.Amt );
						mRetVal.Add("CITY", mRecurring.City );
						mRetVal.Add("COMPANYNAME", mRecurring.CompanyName );
						mRetVal.Add("COUNTRY", mRecurring.Country );
						mRetVal.Add("EMAIL", mRecurring.Email );
						mRetVal.Add("ENDPAYMENT", mRecurring.End  );
						mRetVal.Add("EXPDATE", mRecurring.ExpDate );
						mRetVal.Add("FIRSTNAME", mRecurring.FirstName );
						mRetVal.Add("LASTNAME", mRecurring.LastName );
						mRetVal.Add("MAXFAILPAYMENTS", mRecurring.MaxFailPayments );
						mRetVal.Add("MIDDLENAME", mRecurring.MiddleName );
						mRetVal.Add("NAME", mRecurring.Name );
						mRetVal.Add("NUMFAILPAYMENTS", mRecurring.NumFailPayments );
						mRetVal.Add("NXTPAYMENT", mRecurring.NextPayment  );
						//mRetVal.Add("P_AMOUNT", mRecurring.P_Amount );
						//mRetVal.Add("P_PNREFN", mRecurring.P_PNRefn );
						//mRetVal.Add("P_RESULTN", mRecurring.P_Resultn );
						//mRetVal.Add("P_TENDERTYPEN", mRecurring.P_TenderTypen );
						//mRetVal.Add("P_TRANSTATEN", mRecurring.P_TranStaten );
						//mRetVal.Add("P_TRANSTIMEN", mRecurring.P_TransTimen );
						mRetVal.Add("PAYMENTSLEFT", mRecurring.PaymentsLeft );
						mRetVal.Add("PAYPERIOD", mRecurring.PayPeriod );
						mRetVal.Add("PHONENUM", mRecurring.PhoneNum );
						mRetVal.Add("PROFILEID", mRecurring.ProfileId );
						mRetVal.Add("PROFILENAME", mRecurring.ProfileName );
						mRetVal.Add("RETRYNUMDAYS", mRecurring.RetryNumDays );
						mRetVal.Add("RPREF", mRecurring.RPRef );
						mRetVal.Add("SHIPTOCITY", mRecurring.ShipToCity );
						mRetVal.Add("SHIPTOCOUNTRY", mRecurring.ShipToCountry );
						mRetVal.Add("SHIPTOFNAME", mRecurring.ShipToFirstName  );
						mRetVal.Add("SHIPTOLNAME", mRecurring.ShipToLastName );
						mRetVal.Add("SHIPTOMNAME", mRecurring.ShipToMiddleName );
						mRetVal.Add("SHIPTOSTATE", mRecurring.ShipToState );
						mRetVal.Add("SHIPTOSTREET", mRecurring.ShipToStreet );
						mRetVal.Add("SHIPTOZIP", mRecurring.ShipToZip );
						mRetVal.Add("START", mRecurring.Start );
						mRetVal.Add("STATE", mRecurring.State );
						mRetVal.Add("STATUS", mRecurring.Status );
						mRetVal.Add("STREET", mRecurring.Street );
						mRetVal.Add("TENDERTYPE", mRecurring.Tender );
						mRetVal.Add("TERM", mRecurring.Term );
						mRetVal.Add("TRXPNREF", mRecurring.TrxPNRef );
						mRetVal.Add("TRXRESPMESG", mRecurring.TrxRespMsg );
						mRetVal.Add("TRXRESULT", mRecurring.TrxResult );
						mRetVal.Add("ZIP", mRecurring.Zip);
						
						//Setting the Inquiry params from the recurring response in the mRetVal

						Hashtable mInqParam=mRecurring.InquiryParams;
                        IEnumerator menum= mInqParam.Keys.GetEnumerator();
						
						if(mInqParam!=null)
						{
							while(menum.MoveNext())
							{
								mRetVal.Add(menum.Current.ToString(),mInqParam[menum.Current.ToString()]);
							}
						}
						
						
						
						
						break;
				}
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Aspx.SampleStore.GetResponseInHashTbl(Response,As String): Exiting", PayflowConstants.SEVERITY_DEBUG);
				return mRetVal;
				
			}
			catch (Exception Ex)
			{
				throw (new Exception(Ex.Message, Ex));
			}
		}
		private void BtnSubmitTransaction_Click (System.Object sender, System.EventArgs e)
		{
			SubmitForm();
		}
		private void BtnFollowOnRecurring_Click (System.Object sender, System.EventArgs e)
		{
			Context.Items.Add(SampleStoreConstants.CONTEXT_PROFILEID, ViewState[SampleStoreConstants.CONTEXT_PROFILEID]);
			Context.Items.Add(SampleStoreConstants.CONTEXT_REQUESTDATA, ViewState[SampleStoreConstants.CONTEXT_TEMPDATA]);
			DisplaySampleStore();
		}
		/// <summary>
		/// This event is triggered when Follow-On Transaction needs to be performed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void BtnFollowOnTransaction_Click (System.Object sender, System.EventArgs e)
		{
			Context.Items.Add(SampleStoreConstants.CONTEXT_REQUESTDATA, ViewState[SampleStoreConstants.CONTEXT_TEMPDATA]);
			Context.Items.Add(SampleStoreConstants.CONTEXT_ORIGID, ViewState[SampleStoreConstants.CONTEXT_PNREF]);
			Context.Items.Add(SampleStoreConstants.CONTEXT_PROFILEID, ViewState["PROFILEID"]);
			DisplaySampleStore();
		}
		private void BtnWeakAssemblyFollowOn_Click (System.Object sender, System.EventArgs e)
		{
			Response.Redirect(SampleStoreConstants.GLOBAL_PATH + "/src/PayPal/Payments/SampleStore/cs/Aspx/SampleStore.aspx");
		}
		private void BtnReset_Click (System.Object sender, System.EventArgs e)
		{
			Response.Redirect(SampleStoreConstants.GLOBAL_PATH + "/src/PayPal/Payments/SampleStore/cs/Aspx/SampleStore.aspx");		
		}
		


		#region Web Form Designer generated code
		/// <summary>
		/// This call is required by the ASP.NET Web Form Designer
		/// </summary>
		/// <param name="e"></param>
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.CboRequestType.SelectedIndexChanged += new System.EventHandler(this.CboRequestType_SelectedIndexChanged);
			this.BtnSubmitTransaction.Click += new System.EventHandler(this.BtnSubmitTransaction_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.TransactionDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.TransactionDataGrid_ItemDataBound);
			this.TransactionDataGrid.SelectedIndexChanged += new System.EventHandler(this.TransactionDataGrid_SelectedIndexChanged);
			this.RecurringDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.RecurringDataGrid_ItemDataBound);
			this.BtnFollowOnRecurring.Click += new System.EventHandler(this.BtnFollowOnRecurring_Click);
			this.FraudDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.FraudDataGrid_ItemDataBound);
			this.BtnFollowOnTransaction.Click += new System.EventHandler(this.BtnFollowOnTransaction_Click);
			this.BtnStrongBack.Click += new System.EventHandler(this.BtnStrongBack_Click);
			this.BtnWeakAssemblyFollowOn.Click += new System.EventHandler(this.BtnWeakAssemblyFollowOn_Click);
			this.ContextDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ContextDataGrid_ItemDataBound);
			this.ContextDataGrid.SelectedIndexChanged += new System.EventHandler(this.ContextDataGrid_SelectedIndexChanged);
			this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ContextDataGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void TransactionDataGrid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		/// <summary>
		/// This event is triggered when user wants to go back to main page after getting error.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void BtnBack_Click (System.Object sender, System.EventArgs e)
		{
			Response.Redirect(SampleStoreConstants.GLOBAL_PATH + "/src/PayPal/Payments/SampleStore/cs/Aspx/SampleStore.aspx");
			
		}

		private void BtnStrongBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(SampleStoreConstants.GLOBAL_PATH + "/src/PayPal/Payments/SampleStore/cs/Aspx/SampleStore.aspx");
		}
		private void TransactionDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Label lblKey = (Label)e.Item.FindControl("LblTransactionKey");	
			Label lblValue = (Label)e.Item.FindControl("LblTransactionValue");	
			if (lblKey != null)
			{
				lblKey.Text = (string)DataBinder.Eval(e.Item.DataItem, "key");   
			}
			if (lblValue != null)
			{
				lblValue.Text = (string)DataBinder.Eval(e.Item.DataItem, "Value");   
			}
		}


		private void RecurringDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Label lblKey = (Label)e.Item.FindControl("LblRecurringKey");	
			Label lblValue = (Label)e.Item.FindControl("LblRecurringValue");	
			if (lblKey != null)
			{
				lblKey.Text = (string)DataBinder.Eval(e.Item.DataItem, "key");   
			}
			if (lblValue != null)
			{
				lblValue.Text = (string)DataBinder.Eval(e.Item.DataItem, "Value");   
			}
		}

		private void FraudDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Label lblKey = (Label)e.Item.FindControl("LblFraudKey");	
			Label lblValue = (Label)e.Item.FindControl("LblFraudValue");	
			if (lblKey != null)
			{
				lblKey.Text = (string)DataBinder.Eval(e.Item.DataItem, "key");   
			}
			if (lblValue != null)
			{
				lblValue.Text = (string)DataBinder.Eval(e.Item.DataItem, "Value");   
			}
		}

		private void ContextDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			Label lblValue = (Label)e.Item.FindControl("LblErrorMessage");	
			if (lblValue != null)
			{
				lblValue.Text = (string)DataBinder.Eval(e.Item.DataItem, "Value");   
			}
		}
	}
}

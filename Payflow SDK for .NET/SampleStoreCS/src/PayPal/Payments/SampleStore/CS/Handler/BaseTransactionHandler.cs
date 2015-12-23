using System;
using System.Collections;
using PayPal.Payments.SampleStore.CS.Common;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;

//using Microsoft.VisualBasic.CompilerServices;



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

namespace PayPal.Payments.SampleStore.CS.Handler
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This is the base class for the following transaction handlers.
	/// AuthHandler
	/// CaptureHandler
	/// SaleHandler
	/// InquiryHandler
	/// CreditHandler
	/// VoiceAuthHandler
	/// VoidHandler
	/// RecurringHandler
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// -----------------------------------------------------------------------------
	
	public class BaseTransactionHandler : ITransactionHandler
	{
		/// <summary>
		/// Object of class UserInfo
		/// </summary>
		[field:System.CLSCompliant(false)]		public UserInfo UserInfo;
		
		/// <summary>
		///Object of class PayflowConnectionData
		/// </summary>
		[field:System.CLSCompliant(false)]		public PayflowConnectionData PayflowConnectionData;
		/// <summary>
		/// Object of class Invoice
		/// </summary>
		[field:System.CLSCompliant(false)]		public Invoice Invoice;
		/// <summary>
		/// Object of class BaseTender
		/// </summary>
		[field:System.CLSCompliant(false)]		public BaseTender Tender;
		/// <summary>
		/// Object of class PaymentDevice
		/// </summary>
		[field:System.CLSCompliant(false)]		public PaymentDevice PaymentDevice;
		/// <summary>
		/// Arraylist to store extended data fields
		/// </summary>
		public ArrayList ExtDataList;
		/// <summary>
		/// String for invalid values
		/// </summary>
		public string strInvalidFieldList="";
		/// <summary>
		/// Object of class ClientInfo
		/// </summary>
		[field:System.CLSCompliant(false)]		public ClientInfo ClientInfo;

		
		#region "SetDataObjects"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This class sets the data in the data objects that will be passed in the
		/// constructors of the Transaction objects.
		/// </summary>
		/// <param name="RequestData"></param>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public virtual void SetDataObjects (Hashtable RequestData)
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetDataObjects(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG);
				strInvalidFieldList ="";
				int mProxyPort;
				if (object.Equals(RequestData[SampleStoreConstants.FIELD_PROXYPORT].ToString(), null) | object.Equals(RequestData[SampleStoreConstants.FIELD_PROXYPORT].ToString(), SampleStoreConstants.EMPTY_STRING))
				{
					mProxyPort = 0;
				}
				else
				{
					mProxyPort = int.Parse(RequestData[(SampleStoreConstants.FIELD_PROXYPORT)].ToString());
				}
				UserInfo = SetUserInfo(RequestData[SampleStoreConstants.FIELD_USER].ToString(), 
										RequestData[SampleStoreConstants.FIELD_VENDOR].ToString(), 
										RequestData[(SampleStoreConstants.FIELD_PARTNER)].ToString(), 
										RequestData[(SampleStoreConstants.FIELD_PASSWORD)].ToString());
				
				PayflowConnectionData = SetPayflowConnectionData(RequestData[(SampleStoreConstants.FIELD_PROXYADDRESS)].ToString(), mProxyPort, RequestData[(SampleStoreConstants.FIELD_PROXYLOGON)].ToString(), RequestData[(SampleStoreConstants.FIELD_PROXYPASSWORD)].ToString());
				
				Invoice = SetInvoice(RequestData);
				ExtDataList = SetExtendData(RequestData);
				Tender = SetTender(RequestData);
				ClientInfo = SetClientInfo(RequestData);
				//The following code checks whether there was any errors encountered during setting of the fields in objects if so
				//it displays the same on the screen
				if(strInvalidFieldList.Length>0)
				{
					throw new Exception("The following fields have invalid values : <br>"+strInvalidFieldList);
				}

				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetDataObjects(HashTable) : Exiting", PayflowConstants.SEVERITY_DEBUG);
				
			}
			catch (Exception Ex)
			{
				throw (new Exception(Ex.Message, Ex));
			}
		}
		#endregion
		
		#region "SetUserInfo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the Use, Vendor, Partner, Password from the properties
		/// into the UserInfo data object.
		/// </summary>
		/// <returns>UserInfo</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		private UserInfo SetUserInfo(string UserParam, string VendorParam, string PartnerParam, string PasswordParam)
		{
			
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetUserInfo(HashTable) : Entered", PayflowConstants.SEVERITY_DEBUG);
				
				Logger.Instance.Log("Values Passed to the function : ", PayflowConstants.SEVERITY_INFO);
				
				Logger.Instance.Log("User : " + UserParam, PayflowConstants.SEVERITY_INFO);
				Logger.Instance.Log("Vendor : " + VendorParam, PayflowConstants.SEVERITY_INFO);
				Logger.Instance.Log("Partner : " + PartnerParam, PayflowConstants.SEVERITY_INFO);
				
				
				UserInfo = new UserInfo(UserParam, VendorParam, PartnerParam, PasswordParam);
				
				return UserInfo;
				
			}
			catch (Exception Ex)
			{
				throw (new Exception(Ex.Message, Ex));
			}
			
		}
		
		#endregion
		
		#region "SetPayflowConnectionData"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the connection data form the properties in the
		/// PayflowConnectionData object and returns the same
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private PayflowConnectionData SetPayflowConnectionData(string ProxyAddress, int ProxyPort, string ProxyLogon, string ProxyPassword)
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetPayflowConnectionData() : Entered", PayflowConstants.SEVERITY_DEBUG);
				PayflowConnectionData = new PayflowConnectionData(null, 0, 0, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword);
				
				
				Logger.Instance.Log("PayflowConnectionData object created with following values :", PayflowConstants.SEVERITY_INFO);
				Logger.Instance.Log("HostAddress : " + SampleStoreProperties.HostAddress, PayflowConstants.SEVERITY_INFO);
				Logger.Instance.Log("HostPort : " + SampleStoreProperties.HostPort, PayflowConstants.SEVERITY_INFO);
				Logger.Instance.Log("HostTimeout : " + SampleStoreProperties.HostTimeout, PayflowConstants.SEVERITY_INFO);
				
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetPayflowConnectionData() : Exiting", PayflowConstants.SEVERITY_DEBUG);
				return PayflowConnectionData;
				
			}
			catch (Exception Ex)
			{
				Logger.Instance.Log("PayPal.ayments.SampleStore.VB.Handler.SetPayflowConnectionData() : In the catch of exception. Error Occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL);
				throw (new Exception(Ex.Message, Ex));
			}
		}
		
		#endregion
		
		#region "SetInvoice"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function creates an Invoice object, sets the data and returns the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>Invoice</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private  Invoice SetInvoice(Hashtable RequestData)
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetInvoice() : Entered", PayflowConstants.SEVERITY_DEBUG);
				Invoice Invoice = new Invoice();
				
				//Set the BillTo Data
				Invoice.BillTo = SetBillTo(RequestData);
				//Set the ShipTo Data
				Invoice.ShipTo = SetShipTo(RequestData);
				
				//Set the Browser Info
				Invoice.BrowserInfo = SetBrowserInfo(RequestData);
				
				//Set the Customer Info
				Invoice.CustomerInfo = SetCustomerInfo(RequestData);
				
				//Set the line item data
				Invoice = SetLineItemData(RequestData, Invoice);
				
				//Set the Invoice object fields
				Hashtable with_1 = RequestData;
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_ALTTAXAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_ALTTAXAMT)], null)))
				{
					try
					{
						Invoice.AltTaxAmt = SampleStoreUtil.GetCurrencyFromString (with_1[(SampleStoreConstants.FIELD_ALTTAXAMT)].ToString());
					}
					catch{
						strInvalidFieldList+="ALTTAXAMT<br> ";
						
					}
				}
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_AMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_AMT)], null)))
				{
					try
					{
						Invoice.Amt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_AMT)].ToString());
                        Invoice.Amt.Round = true; 
					}
					catch
					{
						strInvalidFieldList+="AMT <br> ";
						
					}
				}
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_COMMENT1)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_COMMENT1)], null)))
				{
					Invoice.Comment1 = with_1[(SampleStoreConstants.FIELD_COMMENT1)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_COMMENT2)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_COMMENT2)], null)))
				{
					Invoice.Comment2 = with_1[(SampleStoreConstants.FIELD_COMMENT2)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_CUSTREF)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_CUSTREF)], null)))
				{
					Invoice.CustRef = with_1[(SampleStoreConstants.FIELD_CUSTREF)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_TAXEXEMPT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_TAXEXEMPT)], null)))
				{
					Invoice.TaxExempt = with_1[(SampleStoreConstants.FIELD_TAXEXEMPT)].ToString();
				}
				
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_DESC)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_DESC)], null)))
				{
					Invoice.Desc = with_1[(SampleStoreConstants.FIELD_DESC)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_DESC1)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_DESC1)], null)))
				{
					Invoice.Desc1 = with_1[(SampleStoreConstants.FIELD_DESC1)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_DESC2)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_DESC2)], null)))
				{
					Invoice.Desc2 = with_1[(SampleStoreConstants.FIELD_DESC2)].ToString();
				}
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_DESC3)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_DESC3)], null)))
				{
					Invoice.Desc3 = with_1[(SampleStoreConstants.FIELD_DESC3)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_DESC4)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_DESC4)], null)))
				{
					Invoice.Desc4 = with_1[(SampleStoreConstants.FIELD_DESC4)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_ORDERDATE)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_ORDERDATE)], null)))
				{
					Invoice.OrderDate = with_1[(SampleStoreConstants.FIELD_ORDERDATE)].ToString();
				}
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_ORDERTIME)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_ORDERTIME)], null)))
				{
					Invoice.OrderTime = with_1[(SampleStoreConstants.FIELD_ORDERTIME)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_MERCHDESCR)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_MERCHDESCR)], null)))
				{
					Invoice.MerchDescr = with_1[(SampleStoreConstants.FIELD_MERCHDESCR)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_MERCHSVC)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_MERCHSVC)], null)))
				{
					Invoice.MerchSvc = with_1[(SampleStoreConstants.FIELD_MERCHSVC)].ToString();
				}

				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_DISCOUNT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_DISCOUNT)], null)))
				{
					try{
					Invoice.Discount = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_DISCOUNT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="DISCOUNT <br> ";
					}
					}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_DUTYAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_DUTYAMT)], null)))
				{
					try{
					Invoice.DutyAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_DUTYAMT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="DUTYAMT <br> ";
					}
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_ENDTIME)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_ENDTIME)], null)))
				{
					
					Invoice.EndTime = with_1[(SampleStoreConstants.FIELD_ENDTIME)].ToString();
					
					
					}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_FREIGHTAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_FREIGHTAMT)], null)))
				{
					try{
					Invoice.FreightAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_FREIGHTAMT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="FREIGHTAMT <br> ";
					}
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_HANDLINGAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_HANDLINGAMT)], null)))
				{
					try
					{
						Invoice.HandlingAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_HANDLINGAMT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="HANDLINGAMT <br> ";
					}
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_INVNUM)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_INVNUM)], null)))
				{
					Invoice.InvNum = with_1[(SampleStoreConstants.FIELD_INVNUM)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_INVOICEDATE)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_INVOICEDATE)], null)))
				{
					
						Invoice.InvoiceDate = with_1[(SampleStoreConstants.FIELD_INVOICEDATE)].ToString();
					
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_LOCALTAXAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_LOCALTAXAMT)], null)))
				{
					try{
					Invoice.LocalTaxAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_LOCALTAXAMT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="LOCALTAXAMT <br> ";
					}
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_NATIONALTAXAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_NATIONALTAXAMT)], null)))
				{
					try{
					Invoice.NationalTaxAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_NATIONALTAXAMT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="NATIONALTAXAMT <br> ";
					}
				}
				
				
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_PONUM)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_PONUM)], null)))
				{
					Invoice.PoNum = with_1[(SampleStoreConstants.FIELD_PONUM)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_STARTTIME)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_STARTTIME)], null)))
				{
					
					Invoice.StartTime = with_1[(SampleStoreConstants.FIELD_STARTTIME)].ToString();
					
				}
				
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_TAXAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_TAXAMT)], null)))
				{
					try{
					Invoice.TaxAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_TAXAMT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="TAXAMT <br> ";
					}
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_VATREGNUM)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_VATREGNUM)], null)))
				{
					Invoice.VatRegNum = with_1[(SampleStoreConstants.FIELD_VATREGNUM)].ToString();
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_VATTAXAMT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_VATTAXAMT)], null)))
				{
					try
					{
						Invoice.VatTaxAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_VATTAXAMT)].ToString());
					}
					catch
					{
						strInvalidFieldList+="VATTAXAMT<br> ";
					}
				}
				
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_VATAXPERCENT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_VATAXPERCENT)], null)))
				{
					Invoice.VaTaxPercent  = with_1[(SampleStoreConstants.FIELD_VATAXPERCENT)].ToString();
				}
				
				
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetInvoice() : Exiting", PayflowConstants.SEVERITY_DEBUG);
				return Invoice;
				
			}
			catch (Exception Ex)
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetInvoice() : In the catch of exception. Error Occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL);
				throw (new Exception(Ex.Message, Ex));
			}
		}
		
		#endregion

		#region "SetClientInfo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function creates an ClientInfo object, sets the data and returns the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>ClientInfo</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private  ClientInfo SetClientInfo(Hashtable RequestData)
		{
			try
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetClientInfo() : Entered", PayflowConstants.SEVERITY_DEBUG);
				ClientInfo ClientInfo = new ClientInfo();
				//Set the ClientInfo object fields
				Hashtable with_1 = RequestData;
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_PRODUCT)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_PRODUCT)], null)))
				{
					ClientInfo.IntegrationProduct = with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_PRODUCT)].ToString();
				}
				if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_VERSION)], SampleStoreConstants.EMPTY_STRING) | object.Equals(with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_VERSION)], null)))
				{
					ClientInfo.IntegrationVersion  = with_1[(SampleStoreConstants.FIELD_VIT_INTEGRATION_VERSION)].ToString();
				}
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetInvoice() : Exiting", PayflowConstants.SEVERITY_DEBUG);
				return ClientInfo;
				
			}
			catch (Exception Ex)
			{
				Logger.Instance.Log("PayPal.Payments.SampleStore.CS.Handler.SetInvoice() : In the catch of exception. Error Occured - " + Ex.Message, PayflowConstants.SEVERITY_FATAL);
				throw (new Exception(Ex.Message, Ex));
			}
			}
				#endregion
		
		#region "SetBillTo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the BillTo details in the BillTo object and returns the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>BillTo</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private static BillTo SetBillTo(Hashtable RequestData)
		{
			BillTo mBillTo = new BillTo();
			Hashtable with_1 = RequestData;
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_CITY)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_CITY)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.City = with_1[(SampleStoreConstants.FIELD_CITY)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_BILLTOCOUNTRY)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_BILLTOCOUNTRY)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.BillToCountry = with_1[(SampleStoreConstants.FIELD_BILLTOCOUNTRY)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_EMAIL)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_EMAIL)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.Email = with_1[(SampleStoreConstants.FIELD_EMAIL)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_FAX)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_FAX)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.Fax = with_1[(SampleStoreConstants.FIELD_FAX)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_FIRSTNAME)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_FIRSTNAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.FirstName = with_1[(SampleStoreConstants.FIELD_FIRSTNAME)].ToString();
				
			}
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_LASTNAME)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_LASTNAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.LastName = with_1[(SampleStoreConstants.FIELD_LASTNAME)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_MIDDLENAME)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_MIDDLENAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.MiddleName = with_1[(SampleStoreConstants.FIELD_MIDDLENAME)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_BILLTOPHONE2)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_BILLTOPHONE2)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.BillToPhone2 = with_1[(SampleStoreConstants.FIELD_BILLTOPHONE2)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_PHONENUM)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_PHONENUM)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.PhoneNum = with_1[(SampleStoreConstants.FIELD_PHONENUM)].ToString();
				
			}
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_STATE)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_STATE)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.State = with_1[(SampleStoreConstants.FIELD_STATE)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_STREET)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_STREET)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.Street = with_1[(SampleStoreConstants.FIELD_STREET)].ToString();
				
			}
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_BILLTOSTREET2)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_BILLTOSTREET2)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.BillToStreet2  = with_1[(SampleStoreConstants.FIELD_BILLTOSTREET2)].ToString();
				
			}
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_ZIP)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_ZIP)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.Zip = with_1[(SampleStoreConstants.FIELD_ZIP)].ToString();
				
			}

			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_COMPANYNAME)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_COMPANYNAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBillTo.CompanyName = RequestData[(SampleStoreConstants.FIELD_COMPANYNAME)].ToString();
			}
			
			return mBillTo;
		}
		
		#endregion
		
		#region "SetShipTo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the ShipTo details in the ShipTo object and returns the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>ShipTo</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		private static ShipTo SetShipTo(Hashtable RequestData)
		{
			ShipTo mShipTo = new ShipTo();
			
			Hashtable with_1 = RequestData;
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPCARRIER)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPCARRIER)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipCarrier = with_1[(SampleStoreConstants.FIELD_SHIPCARRIER)].ToString();
			}
			
			
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPFROMZIP)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPFROMZIP)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipFromZip = with_1[(SampleStoreConstants.FIELD_SHIPFROMZIP)].ToString();
				
				
			}
			
			
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPMETHOD)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPMETHOD)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipMethod = with_1[(SampleStoreConstants.FIELD_SHIPMETHOD)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOCITY)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOCITY)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToCity = with_1[(SampleStoreConstants.FIELD_SHIPTOCITY)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOCOUNTRY)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOCOUNTRY)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToCountry = with_1[(SampleStoreConstants.FIELD_SHIPTOCOUNTRY)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOEMAIL)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOEMAIL)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToEmail = with_1[(SampleStoreConstants.FIELD_SHIPTOEMAIL)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOFIRSTNAME)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOFIRSTNAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToFirstName = with_1[(SampleStoreConstants.FIELD_SHIPTOFIRSTNAME)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOLASTNAME)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOLASTNAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToLastName = with_1[(SampleStoreConstants.FIELD_SHIPTOLASTNAME)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOMIDDLENAME)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOMIDDLENAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToMiddleName = with_1[(SampleStoreConstants.FIELD_SHIPTOMIDDLENAME)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOPHONE)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOPHONE)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToPhone = with_1[(SampleStoreConstants.FIELD_SHIPTOPHONE)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOPHONE2)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOPHONE2)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToPhone2 = with_1[(SampleStoreConstants.FIELD_SHIPTOPHONE2)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOSTATE)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOSTATE)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToState = with_1[(SampleStoreConstants.FIELD_SHIPTOSTATE)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOSTREET)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOSTREET)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToStreet = with_1[(SampleStoreConstants.FIELD_SHIPTOSTREET)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOSTREET2)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOSTREET2)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToStreet2 = with_1[(SampleStoreConstants.FIELD_SHIPTOSTREET2)].ToString();
				
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOZIP)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_SHIPTOZIP)], SampleStoreConstants.EMPTY_STRING)))
			{
				mShipTo.ShipToZip = with_1[(SampleStoreConstants.FIELD_SHIPTOZIP)].ToString();
				
			}
			
			
			return mShipTo;
			
		}
		
		#endregion
		
		#region "SetBrowserInfo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the Browser details in the BrowserInfo object and returns
		/// the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>BrowserInfo</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		private static BrowserInfo SetBrowserInfo(Hashtable RequestData)
		{
			BrowserInfo mBrowserInfo = new BrowserInfo();
			
			Hashtable with_1 = RequestData;
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_BROWSERCOUNTRYCODE)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_BROWSERCOUNTRYCODE)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBrowserInfo.BrowserCountryCode = with_1[(SampleStoreConstants.FIELD_BROWSERCOUNTRYCODE)].ToString();
			}
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_BROWSERTIME)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_BROWSERTIME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBrowserInfo.BrowserTime = with_1[(SampleStoreConstants.FIELD_BROWSERTIME)].ToString();
			}
			
			if (!(object.Equals(with_1[(SampleStoreConstants.FIELD_BROWSERUSERAGENT)], null) | object.Equals(with_1[(SampleStoreConstants.FIELD_BROWSERUSERAGENT)], SampleStoreConstants.EMPTY_STRING)))
			{
				mBrowserInfo.BrowserUserAgent = with_1[(SampleStoreConstants.FIELD_BROWSERUSERAGENT)].ToString();
			}
			return mBrowserInfo;
		}
		
		#endregion
		
		#region "SetCustomerInfo"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the Customer details in the CustomerInfo object and returns
		/// the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>CustomerInfo</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private  CustomerInfo SetCustomerInfo(Hashtable RequestData)
		{
			CustomerInfo mCustomerInfo = new CustomerInfo();
			
			//With RequestData
			
			//if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CORPNAME)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CORPNAME)], SampleStoreConstants.EMPTY_STRING)))
			//{
			//	mCustomerInfo.CorpName = RequestData[(SampleStoreConstants.FIELD_CORPNAME)].ToString();
			//}
			
			
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTCODE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTCODE)], SampleStoreConstants.EMPTY_STRING)))
			{
				mCustomerInfo.CustCode = RequestData[(SampleStoreConstants.FIELD_CUSTCODE)].ToString();
			}
			
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTID)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTID)], SampleStoreConstants.EMPTY_STRING)))
			{
				mCustomerInfo.CustId = RequestData[(SampleStoreConstants.FIELD_CUSTID)].ToString();
			}
			
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTIP)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTIP)], SampleStoreConstants.EMPTY_STRING)))
			{
				mCustomerInfo.CustIP = RequestData[(SampleStoreConstants.FIELD_CUSTIP)].ToString();
			}
			
			
			
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTVATREGNUM)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTVATREGNUM)], SampleStoreConstants.EMPTY_STRING)))
			{
				mCustomerInfo.CustVatRegNum = RequestData[(SampleStoreConstants.FIELD_CUSTVATREGNUM)].ToString();
			}
			
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_DOB)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_DOB)], SampleStoreConstants.EMPTY_STRING)))
			{
				mCustomerInfo.DOB = RequestData[(SampleStoreConstants.FIELD_DOB)].ToString();
			}
			
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_REQNAME)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_REQNAME)], SampleStoreConstants.EMPTY_STRING)))
			{
				mCustomerInfo.ReqName = RequestData[(SampleStoreConstants.FIELD_REQNAME)].ToString();
			}
	
			//End With
			return mCustomerInfo;
		}
		
		#endregion
		
		#region "SetExtendData"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function sets the Extended data in the ExtendDataList and returns the same
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>ArrayList</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		private static ArrayList SetExtendData(Hashtable RequestData)
		{
			ArrayList ExtDataList = new ArrayList();
			System.Collections.ICollection mKeysColl;
			System.Collections.IEnumerator mKeysEnum;
			string mFieldName,mRqstField;
			
			mKeysColl = RequestData.Keys;
			mKeysEnum = mKeysColl.GetEnumerator();
			
			while (mKeysEnum.MoveNext())
			{
				if (mKeysEnum.Current.ToString().StartsWith("TxtBoxExtend_"))
				{
					mFieldName = mKeysEnum.Current.ToString();
					mRqstField = "EXTENDFIELD"+GetLineItemNumber(mFieldName);

					if (!(object.Equals(RequestData[mFieldName], null) | object.Equals(RequestData[mFieldName], SampleStoreConstants.EMPTY_STRING)))
					{
						ExtDataList.Add(new ExtendData(mRqstField, RequestData[mFieldName].ToString()));
					}
					
				}
			}
			return ExtDataList;
		}
		
		#endregion
		
		#region "SetTender"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function creates a Tender object and then creates a PaymentDevice object
		/// depending on the tender type.
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>ArrayList</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		
		private BaseTender SetTender(Hashtable RequestData)
		{
			
			if (object.Equals(RequestData[(SampleStoreConstants.FIELD_TENDER)], SampleStoreConstants.TENDER_CREDITCARD))
			{
				
				if (object.Equals(RequestData[(SampleStoreConstants.FIELD_SWIPE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_SWIPE)], SampleStoreConstants.EMPTY_STRING))
				{
				string mMonth="",mYear="";

					if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_EXPIRYMONTH)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_EXPIRYMONTH)], SampleStoreConstants.EMPTY_STRING)))
					{
						mMonth = RequestData[(SampleStoreConstants.FIELD_EXPIRYMONTH)].ToString();
					}
					
					if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_EXPIRYYEAR)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_EXPIRYYEAR)], SampleStoreConstants.EMPTY_STRING)))
					{
						
						mYear = RequestData[(SampleStoreConstants.FIELD_EXPIRYYEAR)].ToString();
					}
					
					PaymentDevice = new CreditCard(RequestData[(SampleStoreConstants.FIELD_ACCT)].ToString(), 
													mMonth+mYear.Substring(2,2));
					
					
					
					if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CVV2)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CVV2)], SampleStoreConstants.EMPTY_STRING)))
					{
						((CreditCard)(PaymentDevice)).Cvv2 = RequestData[(SampleStoreConstants.FIELD_CVV2)].ToString();
					}
					
					
					if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_NAME)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_NAME)], SampleStoreConstants.EMPTY_STRING)))
					{
						PaymentDevice.Name = RequestData[(SampleStoreConstants.FIELD_NAME)].ToString();
					}
								
					Tender = new CardTender(((CreditCard)(PaymentDevice)));
				}
				else
				{
					PaymentDevice = new SwipeCard(RequestData[(SampleStoreConstants.FIELD_SWIPE)].ToString());
					Tender = new CardTender(((SwipeCard)(PaymentDevice)));
				}				
			}
			else if (object.Equals(RequestData[(SampleStoreConstants.FIELD_TENDER)], SampleStoreConstants.TENDER_ACH))
			{
				
				PaymentDevice = new BankAcct(RequestData[(SampleStoreConstants.FIELD_ACCT)].ToString(),SampleStoreConstants.FIELD_ABA);
				
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_ACCTTYPE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_ACCTTYPE)], SampleStoreConstants.EMPTY_STRING)))
				{
					((BankAcct)(PaymentDevice)).AcctType = RequestData[(SampleStoreConstants.FIELD_ACCTTYPE)].ToString();
				}
				
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_ABA)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_ABA)], SampleStoreConstants.EMPTY_STRING)))
				{
					((BankAcct)(PaymentDevice)).Aba = RequestData[(SampleStoreConstants.FIELD_ABA)].ToString();
				}
				
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_NAME)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_NAME)], SampleStoreConstants.EMPTY_STRING)))
				{
					((BankAcct)(PaymentDevice)).Name = RequestData[(SampleStoreConstants.FIELD_NAME)].ToString();
				}
				
				
				Tender = new ACHTender(((BankAcct)(PaymentDevice)));
				//Cast the tender to ACHTender for setting the ACH specific fields
				
				
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_AUTHTYPE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_AUTHTYPE)], SampleStoreConstants.EMPTY_STRING)))
				{
					((ACHTender)(Tender)).AuthType  = RequestData[(SampleStoreConstants.FIELD_AUTHTYPE)].ToString();
				}
				
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CHKNUM)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CHKNUM)], SampleStoreConstants.EMPTY_STRING)))
				{
					((ACHTender)(Tender)).ChkNum = RequestData[(SampleStoreConstants.FIELD_CHKNUM)].ToString();
				}
				
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_PRENOTE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_PRENOTE)], SampleStoreConstants.EMPTY_STRING)))
				{
					((ACHTender)(Tender)).PreNote  = RequestData[(SampleStoreConstants.FIELD_PRENOTE)].ToString();
				}
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_TERMCITY)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_TERMCITY)], SampleStoreConstants.EMPTY_STRING)))
				{
					((ACHTender)(Tender)).TermCity  = RequestData[(SampleStoreConstants.FIELD_TERMCITY)].ToString();
				}
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_TERMSTATE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_TERMSTATE)], SampleStoreConstants.EMPTY_STRING)))
				{
					((ACHTender)(Tender)).TermState  = RequestData[(SampleStoreConstants.FIELD_TERMSTATE)].ToString();
				}
				
			}
			else if (object.Equals(RequestData[(SampleStoreConstants.FIELD_TENDER)], SampleStoreConstants.TENDER_TELECHECK))
			{
				PaymentDevice = new CheckPayment(RequestData[(SampleStoreConstants.FIELD_MICR)].ToString());
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_NAME)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_NAME)], SampleStoreConstants.EMPTY_STRING)))
				{
					PaymentDevice.Name = RequestData[(SampleStoreConstants.FIELD_NAME)].ToString();
				}
				
				Tender = new CheckTender(((CheckPayment)(PaymentDevice)));
				
				//Cast the tender to CheckTender for setting the TeleCheck specific fields
				

				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CHKNUM)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CHKNUM)], SampleStoreConstants.EMPTY_STRING)))
				{
					((CheckTender)(Tender)).ChkNum  = RequestData[(SampleStoreConstants.FIELD_CHKNUM)].ToString();
				}
				if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CHKTYPE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CHKTYPE)], SampleStoreConstants.EMPTY_STRING)))
				{
					((CheckTender)(Tender)).ChkType  = RequestData[(SampleStoreConstants.FIELD_CHKTYPE)].ToString();
				}
				

			}
//			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_BANKNAME)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_BANKNAME)], SampleStoreConstants.EMPTY_STRING)))
//			{
//				Tender.BankName = RequestData[(SampleStoreConstants.FIELD_BANKNAME)].ToString();
//			}
//			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_BANKSTATE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_BANKSTATE)], SampleStoreConstants.EMPTY_STRING)))
//			{
//				Tender.BankState = RequestData[(SampleStoreConstants.FIELD_BANKSTATE)].ToString();
//			}
//			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CONSENTMEDIUM)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CONSENTMEDIUM)], SampleStoreConstants.EMPTY_STRING)))
//			{
//				Tender.ConsentMedium = RequestData[(SampleStoreConstants.FIELD_CONSENTMEDIUM)].ToString();
//			}
//			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTOMERTYPE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_CUSTOMERTYPE)], SampleStoreConstants.EMPTY_STRING)))
//			{
//				Tender.CustomerType = RequestData[(SampleStoreConstants.FIELD_CUSTOMERTYPE)].ToString();
//			}
//			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_DLSTATE)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_DLSTATE)], SampleStoreConstants.EMPTY_STRING)))
//			{
//				Tender.DlState = RequestData[(SampleStoreConstants.FIELD_DLSTATE)].ToString();
//			}
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_DL)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_DL)], SampleStoreConstants.EMPTY_STRING)))
			{
				Tender.DL = RequestData[(SampleStoreConstants.FIELD_DL)].ToString();
			}
			if (!(object.Equals(RequestData[(SampleStoreConstants.FIELD_SS)], null) | object.Equals(RequestData[(SampleStoreConstants.FIELD_SS)], SampleStoreConstants.EMPTY_STRING)))
			{
				Tender.SS = RequestData[(SampleStoreConstants.FIELD_SS)].ToString();
			}
			
			return Tender;
		}
		
		#endregion
		
		#region "SetLineItemData"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function gets the number of line items passed from the SampleStore in an
		/// Array. The code then loops through the length of the array. For each entry in the
		/// array, the code sets the lineitem data into lineitem object and sets the lineitem
		/// object in the invoice object. The function then returns the Invoice object with
		/// the lineitem objects.
		/// </summary>
		/// <param name="RequestData"></param>
		/// <param name="Invoice"></param>
		/// <returns>Invoice</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private  Invoice SetLineItemData(Hashtable RequestData, Invoice Invoice)
		{
			Array mLineItemNumbers;
			int mCounter;
			LineItem mLineItem;
			int mLineItemNumber;
			
			//Get the lineitem numbers in an Array
			mLineItemNumbers = GetLineItemNumberArray(RequestData);
			
			for (mCounter = 0; mCounter <= mLineItemNumbers.Length - 1; mCounter++)
			{
				mLineItemNumber = int.Parse(mLineItemNumbers.GetValue(mCounter).ToString());
				
				//For each lineitem number in the array, create a lineitem object and set the
				//lineitem data in he same
				
				mLineItem = new LineItem();
				Hashtable with_1 = RequestData;
				
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_AMT + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try
					{
						mLineItem.Amt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_L_AMT + mLineItemNumber)].ToString());
					}
					catch
					{
                         strInvalidFieldList+="L_AMT"+mLineItemNumber+" <br> ";
					}
				}
				
				
				mLineItem.CatalogNum = with_1[(SampleStoreConstants.FIELD_L_CATALOGNUM + mLineItemNumber)].ToString();
				
				mLineItem.CommCode = with_1[(SampleStoreConstants.FIELD_L_COMMCODE + mLineItemNumber)].ToString();
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_COST + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try
					{
						mLineItem.Cost = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_L_COST + mLineItemNumber)].ToString());
					}
					catch
					{
						strInvalidFieldList+="L_COST"+mLineItemNumber+" <br> ";
					}
				}
				
				mLineItem.CostCenterNum = with_1[(SampleStoreConstants.FIELD_L_COSTCENTERNUM + mLineItemNumber)].ToString();
				mLineItem.Desc = with_1[(SampleStoreConstants.FIELD_L_DESC + mLineItemNumber)].ToString();
				
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_DISCOUNT + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try{
					mLineItem.Discount = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_L_DISCOUNT + mLineItemNumber)].ToString());
					}
					catch
					{
						strInvalidFieldList+="L_DISCOUNT"+mLineItemNumber+" <br> ";
					}
				}
				
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_FREIGHTAMT + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try
					{
						mLineItem.FreightAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_L_FREIGHTAMT + mLineItemNumber)].ToString());
					}
					catch
					{
						strInvalidFieldList+="L_FREIGHTAMT"+mLineItemNumber+" <br> ";
					}
				}
				
				
				
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_HANDLINGAMT + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try{
					mLineItem.HandlingAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_L_HANDLINGAMT + mLineItemNumber)].ToString());
					}
					catch
					{
					strInvalidFieldList+="L_HANDLINGAMT"+mLineItemNumber+" <br> ";
					}
				}
				
				
				mLineItem.Manufacturer = with_1[(SampleStoreConstants.FIELD_L_MANUFACTURER + mLineItemNumber)].ToString();
				mLineItem.PickupCity = with_1[(SampleStoreConstants.FIELD_L_PICKUPCITY + mLineItemNumber)].ToString();
				mLineItem.PickupCountry = with_1[(SampleStoreConstants.FIELD_L_PICKUPCOUNTRY + mLineItemNumber)].ToString();
				mLineItem.PickupState = with_1[(SampleStoreConstants.FIELD_L_PICKUPSTATE + mLineItemNumber)].ToString();
				mLineItem.PickupStreet = with_1[(SampleStoreConstants.FIELD_L_PICKUPSTREET + mLineItemNumber)].ToString();
				mLineItem.PickupZip = with_1[(SampleStoreConstants.FIELD_L_PICKUPZIP + mLineItemNumber)].ToString();
				mLineItem.ProdCode = with_1[(SampleStoreConstants.FIELD_L_PRODCODE + mLineItemNumber)].ToString();
				
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_QTY + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try{
					mLineItem.Qty = int.Parse(with_1[(SampleStoreConstants.FIELD_L_QTY + mLineItemNumber)].ToString());
					}
					catch
					{
						strInvalidFieldList+="L_QTY"+mLineItemNumber+" <br> ";
					}
				}
				mLineItem.SKU = with_1[(SampleStoreConstants.FIELD_L_SKU + mLineItemNumber)].ToString();
				
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_TAXAMT + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try{
					mLineItem.TaxAmt = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_L_TAXAMT + mLineItemNumber)].ToString());
					}
					catch
					{
						strInvalidFieldList+=" L_TAXAMT"+mLineItemNumber+" <br> ";
					}
				}
				
				if (! object.Equals(with_1[(SampleStoreConstants.FIELD_L_TAXRATE + mLineItemNumber)], SampleStoreConstants.EMPTY_STRING))
				{
					try
					{
						mLineItem.TaxRate = SampleStoreUtil.GetCurrencyFromString(with_1[(SampleStoreConstants.FIELD_L_TAXRATE + mLineItemNumber)].ToString());
					}
					catch
					{
						strInvalidFieldList+="L_TAXRATE"+mLineItemNumber+" <br> ";
					}
				}
				
				mLineItem.TrackingNum = with_1[(SampleStoreConstants.FIELD_L_TRACKINGNUM + mLineItemNumber)].ToString();
				mLineItem.Type = with_1[(SampleStoreConstants.FIELD_L_TYPE + mLineItemNumber)].ToString();
				mLineItem.UOM = with_1[(SampleStoreConstants.FIELD_L_UOM + mLineItemNumber)].ToString();
				mLineItem.UPC = with_1[(SampleStoreConstants.FIELD_L_UPC + mLineItemNumber)].ToString();
				
				
				//Set the lineitem object in Invoice object
				Invoice.AddLineItem(mLineItem);
			}
			return Invoice;
		}
		#endregion
		
		#region "GetLineItemNumberArray"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function iterates through the request hashtable and finds the fields
		/// starting with the LINE_ITEM_PREFIX. If a line item field is found, then the
		/// line item number is extracted from the field name. The code checks if this
		/// lineitem number is present in the array. If yes, then the search for the line
		/// item number is continued. If no, then the number is added to the array.
		/// So if there are 3 line items then the array will have {0,1,2} elements.
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns>Array</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private static Array GetLineItemNumberArray(Hashtable RequestData)
		{
			
			System.Collections.ICollection mKeys;
			System.Collections.IEnumerator mKeysEnum;
			string mKeyStr;
			string mLineItemNumber;
			string[] mLineNumberArray = new string[0];
			int mIndex = 0;
			string[] mtemp=null;
			
			mKeys = RequestData.Keys;
			mKeysEnum = mKeys.GetEnumerator();
			
			while (mKeysEnum.MoveNext())
			{
				mKeyStr = mKeysEnum.Current.ToString();
				
				if (mKeyStr.StartsWith(SampleStoreConstants.LINE_ITEM_PREFIX))
				{
					if (! object.Equals(RequestData[mKeyStr], SampleStoreConstants.EMPTY_STRING))
					{
						mLineItemNumber = GetLineItemNumber(mKeyStr);
						
						if (mLineNumberArray.Length==0||Array.IndexOf(mLineNumberArray, mLineItemNumber) < 0)
						{
							mtemp=new String[mIndex+1];
							Array.Copy(mLineNumberArray,0,mtemp,0,  mIndex);
							mLineNumberArray = mtemp;

							//mLineNumberArray = (string[]) Microsoft.VisualBasic.CompilerServices.Utils.CopyArray ((Array) mLineNumberArray, new string[mIndex + 1]);
							mLineNumberArray.SetValue(mLineItemNumber, mIndex);
							mIndex += 1;
						}
						
					}
				}
			}
			
			return mLineNumberArray;
		}
		#endregion
		
		#region "GetLineItemNumber"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method returns the line item no. for the passed line item
		///The code check the parameter value from the last character
		///onwards till it comes across a non-numeric characteand returns the item number
		/// </summary>
		/// <param name="LineItemName"></param>
		/// <returns>String</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		private static string GetLineItemNumber(string LineItemName)
		{
			int mLineItemNo = 0;
			int mMultiplier = 1;
			char mLineItemChar = LineItemName[LineItemName.Length - 1];
			
			while (char.IsDigit(mLineItemChar))
			{
				mLineItemNo += ((int)(char.GetNumericValue(mLineItemChar) * mMultiplier));
				LineItemName = LineItemName.Substring(0, LineItemName.Length - 1);
				mLineItemChar = LineItemName[LineItemName.Length - 1];
				mMultiplier *= 10;
			}
			
			return mLineItemNo.ToString();
		}
		#endregion
		
		#region "SubmitTransaction"
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function will be overridden by the individual handlers for their respective
		/// implementation
		/// </summary>
		/// <param name="RequestData"></param>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public virtual Hashtable SubmitTransaction(Hashtable RequestData)
		{
			
			return null;
		}
		
		#endregion
		
	}
}


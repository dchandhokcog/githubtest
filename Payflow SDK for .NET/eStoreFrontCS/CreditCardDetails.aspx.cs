#region "Imports"
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;
using PayPal.Payments.Common.Utility;
using System.IO;
#endregion

namespace eStoreFrontCS
{
	/// <summary>
	/// Summary description for CreditCardDetails.
	/// </summary>
	public class CreditCardDetails : System.Web.UI.Page
	{
		#region "Member Variables"
		protected System.Web.UI.WebControls.DropDownList ddExpMonth;
		protected System.Web.UI.WebControls.DropDownList ddExpYear;
		protected System.Web.UI.WebControls.Label lblBillingAddress;
		protected System.Web.UI.WebControls.Label lblBillName;
		protected System.Web.UI.WebControls.Label lblBillFName;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtCCNumber;
		protected System.Web.UI.WebControls.Label lblBillLastName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.Label lblStreet;
		protected System.Web.UI.WebControls.TextBox txtStreet;
		protected System.Web.UI.WebControls.Label lblCity;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.Label lblZip;
		protected System.Web.UI.WebControls.TextBox txtZip;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.Label lblShippingAddress;
		protected System.Web.UI.WebControls.CheckBox chkCopyBilling;
		protected System.Web.UI.WebControls.TextBox txtShipToFName;
		protected System.Web.UI.WebControls.TextBox txtShipToLName;
		protected System.Web.UI.WebControls.TextBox txtShipToStreet;
		protected System.Web.UI.WebControls.TextBox txtShipToZip;
		protected System.Web.UI.WebControls.TextBox txtShipToCity;
		protected System.Web.UI.WebControls.TextBox txtShipToState;
		protected System.Web.UI.WebControls.Label lblCreditCard;
		protected System.Web.UI.WebControls.Label lblCCNumber;
		protected System.Web.UI.WebControls.Label lblExpDate;
		protected System.Web.UI.WebControls.Label lblExMonth;
		protected System.Web.UI.WebControls.Label lblExDate;
		protected System.Web.UI.WebControls.Label lblSTName;
		protected System.Web.UI.WebControls.Label lblSTFName;
		protected System.Web.UI.WebControls.Label lblSTLName;
		protected System.Web.UI.WebControls.Label lblSTStreet;
		protected System.Web.UI.WebControls.Label lblSTCity;
		protected System.Web.UI.WebControls.Label lblSTZip;
		protected System.Web.UI.WebControls.Label lblSTState;
		protected System.Web.UI.WebControls.CheckBox chkProcessWithBuyerAuth;
		protected System.Web.UI.WebControls.Label lblCvv2;
		protected System.Web.UI.WebControls.TextBox txtCVV2;
		protected System.Web.UI.WebControls.Button btnCheckout;
		protected System.Web.UI.WebControls.Label Label1;
		private String mOrderId;

		#endregion
	
		#region "Private methods"
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(Page.IsPostBack)
			{
				if(chkCopyBilling.Checked)
				{
					txtShipToFName.Text = txtFirstName.Text;
					txtShipToLName.Text = txtLastName.Text;
					txtShipToStreet.Text = txtStreet.Text;
					txtShipToCity.Text = txtCity.Text;
					txtShipToZip.Text = txtZip.Text;
					txtShipToState.Text = txtState.Text;
				}
			}
			else if(!String.Equals("VE",(String)Request.QueryString.Get("action")))
			{
				// Do the validate authentication transaction for buyerauth.
				Response VaResp = DoValidateAuthentication();

				if(VaResp.TransactionResponse.Result == 0)
				{
					// If validate authentication is successful, then perform the 
					// main authorization transaction.
					DoAuthorization(VaResp);
				}
				else 
				{
					String Message = "An error ocurred while trying to process the transaction.";
					String MessageError = "Result code = " + VaResp.TransactionResponse.Result.ToString() + ", RespMsg = " + VaResp.TransactionResponse.RespMsg.ToString();
					Response.Redirect("PurchaseComplete.aspx?auth=NO&msg=" + HttpUtility.UrlEncode(Message) + "&msgError=" + HttpUtility.UrlEncode(MessageError),true);
				}
			}
		}

		private void btnCheckout_Click(object sender, System.EventArgs e)
		{			
			mOrderId = PayflowUtility.RequestId;
			// When checkout is clicked, perform a verify enrollment transaction 
			// to check whether the user is enrolled for the buyer authentication 
			// service or not.

			// Before proceeding with transaction processing, you should persist the order details.
			// The details of the order that are generally persisted are:
			// Credit card details : Card Number, Expiry date ( Card CVV2 number cannot be stored).
			// Billing address details, shipping address details.
			// Storing these details helps you to allow a returning customer to do a faster 
			// checkout, having his/her details already populated in the desired fields.
			// Storing the ordering details is generally uses database.
			// Here, however for the demonstration purpose, this web application stores the order 
			// details in a flat file named <order_id>.ord and retrieves it later. 
			// Note that this is not a recommended method to persist order details.
			PersistOrderDetails(mOrderId);
			if(chkProcessWithBuyerAuth.Checked)
			{
				// After a successful Verify Transaction,
				// if the user is enrolled for the buyer authentication service;
				// user's browser needs to be redirected to his/her banks'/cards' server(Access Control Server [ACS]).
				// Here he/she authenticates him/her self with his login information.
				// During this process, your web application will not have any control over the proceedings unless the 
				// ACS does not redirect back to your server. 
				DoVerifyEnrollmentAndRedirect();
			}
			else
			{				
				// Perform an authorization transaction.
				// Populate the transaction from persisted order details.
				AuthorizationTransaction Trans =  PopulateTransaction(mOrderId);
				
				// Submit the transaction.
				Trans.SubmitTransaction();

				if(Trans.Response.TransactionResponse.Result >= 0)
				{					
					// Persist the response paramaters in the order details.
					// It is a good practice to store AVSADDR, AVSZIP, CVV2MATCH 
					// along with the unique transaction reference number PNREF.
					Base64Encoder Encoder = new Base64Encoder();
					
					System.Security.Permissions.FileIOPermission IOPerm = new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write,AppDomain.CurrentDomain.BaseDirectory + "orders");
					IOPerm.Demand();
					FileInfo OrderFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"orders\" + mOrderId  + ".ord");
					if(OrderFile.Exists)
					{	
						StreamWriter OrderWriter =  OrderFile.AppendText();
						OrderWriter.WriteLine("PnRef=" + Trans.Response.TransactionResponse.Pnref);
						OrderWriter.WriteLine("Result=" + Trans.Response.TransactionResponse.Result.ToString());
						OrderWriter.WriteLine("RespMsg=" + Trans.Response.TransactionResponse.RespMsg);
						OrderWriter.WriteLine("AvsAddr=" + Trans.Response.TransactionResponse.AVSAddr);
						OrderWriter.WriteLine("AvsZip=" + Trans.Response.TransactionResponse.AVSZip);
						OrderWriter.WriteLine("Cvv2Match=" + Trans.Response.TransactionResponse.CVV2Match);
						OrderWriter.Flush();
						OrderWriter.Close();
					}
				}
				ShowStatusAndRedirect(Trans);
			}
		}

		private void DoVerifyEnrollmentAndRedirect()
		{
			
			// Create the Credit card object.
			CreditCard Card = new CreditCard(txtCCNumber.Text, 
				ddExpMonth.SelectedValue + ddExpYear.SelectedValue);
			
			// Create the currency object for amount. 
			// Here the currency code is the 3 digit ISO country code.
			// For US -> 840 or USD.
			Currency Amt = new Currency(new decimal(21.98),"840");

			// Create a Verify Enrollment Transaction.
			BuyerAuthVETransaction Trans = new BuyerAuthVETransaction
				(Constants.PayflowBAUser,
				Card,Constants.Connection,
				Amt,
				PayflowUtility.RequestId);
						
			// Submit the transaction.
			Response Resp = Trans.SubmitTransaction();

			// Redirect to the ACS ( Access Control Server, eg. users' bank)
			// The URL to ACS and PaReq (Payer Authentication Request -- 
			// digitally signed, encrypted request to authenticate user's enrollment 
			// upon his/her login is returned in the response of verify enrollment.
			// This happens if, the user is enrolled for buyerauth abd the transaction succeeds.
			if(Resp.TransactionResponse.Result == 0)
			{
					
				// Check if the user is enrolled for the buyer authentication service.
				// If the AUTHENTICATION_STATUS response parameter is E, means user is 
				// enrolled for this service. If so, redirect the user's browser  as follows 
				// to his/her bank's secure URL with PaReq, both obtained in ACSURL response parameter:
				// In this you can use the MD field to set any descriptive field or a key to your persisted 
				// order details (such as order id), which are required to retrive later on.
				// TermUrl is the URL of the page of your web application where the bank's secure server will 
				// redirect the PaRes as the authentication response to for further processing.
				if(String.Equals("E",Resp.BuyerAuthResponse.Authentication_Status))
				{
					// This means the user has enrolled him/her self for the buyer authentication 
					// service. Therefore, now the user should be redirected to his/her bank's secure 
					// server.
					//	String RedirectUrl = Trans.Response.BuyerAuthResponse.AcsUrl 
					//	+ "?PaReq=" 
					//	+ System.Web.HttpUtility.UrlEncode(Trans.Response.BuyerAuthResponse.PaReq.Trim())
					//	+ "&TermUrl=" 
					//	+ Constants.LocalHostName +"/CreditCardDetails.aspx&MD="+mOrderId;
					// Response.Redirect(RedirectUrl,true);
					RedirectBuyerAuthRequest(Trans.Response.BuyerAuthResponse.PaReq.Trim(), Trans.Response.BuyerAuthResponse.AcsUrl, mOrderId);
				}
				else
				{
					// If the user is not enrolled for buyer authentication, 
					// take the decision accornding to your business logic whether to 
					// allow the transaction to proceed or not.
					// Here in this ficitous store front, the decision is taken to go 
					// ahead with an authorization.
					AuthorizationTransaction TransAuth = PopulateTransaction(mOrderId);
					Response RespAuth = TransAuth.SubmitTransaction();
					ShowStatusAndRedirect(TransAuth);
				}
			}
			else
			{
				ShowStatusAndRedirect(Trans);
			}
		}

		private AuthorizationTransaction PopulateTransaction(String OrderId)
		{
			Hashtable OrderTable = new Hashtable();
			// Populate the authorization transaction from the persisted order 
			// details. This will generally involve populating the order from 
			// your order database. Here, however for the demonstration purpose, 
			// the order details are stored in a flat file named <order_id>.ord.
			// Note that, this is not a recommneded method to persist order details 
			// and is only implemented for demonstration purpose.
		{
			Base64Encoder Decoder = new Base64Encoder();
			StreamReader OrderReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"orders\" + OrderId + ".ord");
			if(OrderReader != null)
			{
				while(OrderReader.Peek() >= 0)
				{
					String CurrLine = OrderReader.ReadLine();
					int SepIndex = CurrLine.IndexOf("=",0);
					String Name = CurrLine.Substring(0,SepIndex);
					String Value = String.Empty;
					if(SepIndex < CurrLine.Length -1)
					{
						if (Name == "CCNumber")
						{
							// Example of how you might decrypt the credit card number should you decide to store it.
							Value = Decoder.Decrypt(CurrLine.Substring(SepIndex+1));
						} 
						else 
						{
							Value = CurrLine.Substring(SepIndex+1);
						}
						OrderTable.Add(Name,Value);
					}
				}
			}
			OrderReader.Close();
		}

			// Populate the Billing address details.
			BillTo Bill = new BillTo();
			Bill.FirstName = (String)OrderTable["FirstName"];
			Bill.LastName = (String)OrderTable["LastName"];
			Bill.Street = (String)OrderTable["Street"];
			Bill.City = (String)OrderTable["City"];
			Bill.Zip = (String)OrderTable["Zip"];
			Bill.State = (String)OrderTable["State"];

			// Populate the Shipping address details.
			ShipTo Ship = new ShipTo();
			Ship.ShipToFirstName = (String)OrderTable["ShipToFName"];
			Ship.ShipToLastName = (String)OrderTable["ShipToLName"];
			Ship.ShipToStreet = (String)OrderTable["ShipToStreet"];
			Ship.ShipToCity = (String)OrderTable["ShipToCity"];
			Ship.ShipToZip = (String)OrderTable["ShipToZip"];
			Ship.ShipToState = (String)OrderTable["ShipToState"];
			
			// Populate the invoice
			Invoice Inv = new Invoice();
			Inv.BillTo = Bill;
			Inv.ShipTo = Ship;
			Inv.InvNum = OrderId;
			Inv.Amt = new Currency(decimal.Parse((String)OrderTable["Amount"]));

			// Populate the Credit Card details.
			CreditCard Card = new CreditCard((String)OrderTable["CCNumber"],
				(String)OrderTable["ExpDate"]);

			// Note that CVV2 is not persisted in database.
			// You should never store CVV2 value.
			Card.Cvv2 = txtCVV2.Text;

			// Create the Tender.
			CardTender Tender = new CardTender(Card);
			
			// Create the transaction.
			AuthorizationTransaction Trans = new AuthorizationTransaction(Constants.PayflowBAUser,Constants.Connection,Inv,Tender,OrderId);

			return Trans;
		
		}
		private void PersistOrderDetails(String OrderId)
		{
			// Before proceeding with transaction processing, you should persist the order details.
			// The details of the order that are generally persisted are:
			// Credit card details : Card Number, Expiry date ( Card CVV2 number cannot be stored).
			// Billing address details, shipping address details.
			// Storing these details helps you to allow a returning customer to do a faster 
			// checkout, having his/her details already populated in the desired fields.
			// Storing the ordering details is generally uses database.
			// Here, however for the demonstration purpose, this web application stores the order 
			// details in a flat file named <order_id>.ord and retrieves it later. 
			// Note that this is not a recommended method to persist order details.
			try
			{
				Response.SetCookie(new HttpCookie("OrderId",OrderId));
				Response.Cookies["OrderId"].Expires = DateTime.Now.AddDays(1);
				Base64Encoder Encoder = new Base64Encoder();
				System.Security.Permissions.FileIOPermission IOPerm = new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write,AppDomain.CurrentDomain.BaseDirectory + "orders");
				IOPerm.Demand();
				FileInfo OrderFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"orders\" + OrderId  + ".ord");
				if(OrderFile.Exists)
				{
					OrderFile.Delete();
				}
				StreamWriter OrderWriter =  OrderFile.CreateText();
				OrderWriter.WriteLine("FirstName=" + txtFirstName.Text);
				OrderWriter.WriteLine("LastName=" + txtLastName.Text);
				OrderWriter.WriteLine("Street=" + txtStreet.Text);
				OrderWriter.WriteLine("City=" + txtCity.Text);
				OrderWriter.WriteLine("Zip=" + txtZip.Text);
				OrderWriter.WriteLine("State=" + txtState.Text);
				OrderWriter.WriteLine("ShipToFName=" + txtShipToFName.Text);
				OrderWriter.WriteLine("ShipToLName=" + txtShipToLName.Text);
				OrderWriter.WriteLine("ShipToStreet=" + txtShipToStreet.Text);
				OrderWriter.WriteLine("ShipToCity=" + txtShipToCity.Text);
				OrderWriter.WriteLine("ShipToZip=" + txtShipToZip.Text);
				OrderWriter.WriteLine("ShipToState=" + txtShipToState.Text);
				OrderWriter.WriteLine("Amount=" + "21.98");
				// Example of how you might encrypt the credit card number should you decide to store it.
				OrderWriter.WriteLine("CCNumber=" + Encoder.Encrypt(txtCCNumber.Text));
				OrderWriter.WriteLine("ExpDate=" + ddExpMonth.SelectedValue + ddExpYear.SelectedValue);
				OrderWriter.WriteLine("PayMethod=" + "Credit Card");
				OrderWriter.Flush();
				OrderWriter.Close();
			}
			catch(Exception)			
			{
				String Msg = "An error ocurred while trying to write the order details file. Please check permissions on the 'orders' folder.";
				Response.Redirect("PurchaseComplete.aspx?auth=NO&msg="+Msg,true);
			}
		}

		private void ShowStatusAndRedirect(BaseTransaction Trans)
		{
			bool mSuccess = false;
			if(Trans.Response.TransactionResponse.Result >= 0)
			{
				mSuccess = true;
			}

			if(Trans.Response.TransactionResponse.Result == 0)
			{
				Response.Redirect("PurchaseComplete.aspx?auth=YES",true);
			}
			else
			{
				String Message = "Your order cannot be completed at this time.";
				String MessageError = "";
				
				// If result code is greater than 0 (Zero), the transaction is discarded 
				// by the Payflow server. The reason why the transaction is discarded is 
				// evident by the result code value and therefore, you should look at this 
				// result code and decide if 
				// 1. The customer has given some wrong inputs,
				// 2. It's a fraudulent transaction.
				// 3. There's a problem with your merchant account credentials etc.
				// (This is more likely to be caught in your test scenarios.)
				if(mSuccess)
				{
					// Here you can decide what message needs to be shown to 
					// the customer based on the result code returned by the Payflow 
					// Pro service.
					Message += " Please check your credit card details.";
					// Normally you wouldn't dislay the result code on your web page. This is just for review.
					MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString() + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString();
				}
				else
				{
					// A negative result code means there was an error thrown from the 
					// Payflow SDK for .NET. Pls make sure that your configurations is 
					// correct.
					Message += "An internal error occurred.";
					MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString() + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString();
				}
				
				Response.Redirect("PurchaseComplete.aspx?auth=NO&msg="+HttpUtility.UrlEncode(Message)+"&msgError="+HttpUtility.UrlEncode(MessageError),true);
			}
		}

		private Response DoValidateAuthentication()
		{
			// Validate authentication is the second step in processing the purchase 
			// with buyer authentication. 
			// When an enrolled user for buyer auth is redirected to his/her bank's secure server, 
			// he/she auhthenticates him/her self using credentials.
			// Based on credentials, the bank's secure server genrates a payer authentication response or 
			// PaRes and sends the same back to the TermUrl (which should be your web application's URL 
			// where you want to do further processing). The server also sends MD which is the merhcant data 
			// sent by merchant for his/her tracking purpose. Here we're passing the Order Id of the 
			// transaction as MD. We use this order id to retrieve the order details.

			// Once obtain you need to send the PaRes to the VPS gateway to Validate the authentication.
			// The gateway in turn will give the AUTHENTICATION_STATUS of the user in response.

			
			// Read the data from request in binary format first.
			byte[] ByteContent = Request.BinaryRead(Request.ContentLength);
			
			// Convert the binary content in to text content.
			String StrContent = HttpUtility.UrlDecode(System.Text.Encoding.UTF8.GetString(ByteContent));
			
			// Obtain the value of PaRes.
			String Pares = PayflowUtility.LocateValueForName(StrContent,"PaRes",false);

			// Obtain the value of MD.
			Session.Add("MD",PayflowUtility.LocateValueForName(StrContent,"MD",false));
			
			// Create a Validate authentication transaction.
			BuyerAuthVATransaction VaTrans =new BuyerAuthVATransaction(Constants.PayflowBAUser,Constants.Connection,Pares,PayflowUtility.RequestId);
				
			// Submit the transaction.
			VaTrans.SubmitTransaction();
			return VaTrans.Response;
		}

		private void DoAuthorization(Response VaResp)
		{
			// Now that process of buyer auhtentication is complete, you can do the 
			// authorization which will put the charge on the customer's card.
			// Retrieve the transaction from persisted order details and create the transaction.
			BuyerAuthStatus BAstatus = new BuyerAuthStatus();
			BAstatus.AuthenticationId = VaResp.BuyerAuthResponse.Authentication_Id;
			BAstatus.AuthenticationStatus= VaResp.BuyerAuthResponse.Authentication_Status;
			BAstatus.CAVV=VaResp.BuyerAuthResponse.CAVV;
			BAstatus.ECI =VaResp.BuyerAuthResponse.ECI;
			BAstatus.XID= VaResp.BuyerAuthResponse.XID;

			AuthorizationTransaction Trans = PopulateTransaction((String)Session["MD"]);
			Trans.BuyerAuthStatus = BAstatus;
			
			// submit the transaction.
			Response RespAuth = Trans.SubmitTransaction();
			ShowStatusAndRedirect(Trans);
		}

		public void RedirectBuyerAuthRequest(string PayLoad, string ACSUrl, string mTransactionId) 
		{ 
			string myTermURL = Constants.LocalHostName + "/CreditCardDetails.aspx"; 
			System.Web.HttpContext.Current.Response.Clear(); 
			System.Web.HttpContext.Current.Response.Write("<html><head>"); 
			System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", "form1")); 
			System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" enctype=\"{3}\">", "form1", "POST", ACSUrl, "application/x-www-form-urlencoded")); 
			System.Web.HttpContext.Current.Response.Write(string.Format("<input type='hidden' name='PaReq' value='" + PayLoad + "'>")); 
			System.Web.HttpContext.Current.Response.Write(string.Format("<input type='hidden' name='TermUrl' value='" + myTermURL + "'>")); 
			System.Web.HttpContext.Current.Response.Write(string.Format("<input type='hidden' name='MD' value='" + mTransactionId + "'>")); 
			System.Web.HttpContext.Current.Response.Write("</form>"); 
			System.Web.HttpContext.Current.Response.Write("</body></html>"); 
			System.Web.HttpContext.Current.Response.End(); 
		}

		#endregion

		#region Web Form Designer generated code
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
			this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}

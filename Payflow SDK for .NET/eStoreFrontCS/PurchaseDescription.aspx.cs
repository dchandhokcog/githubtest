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
using PayPal.Payments.Transactions;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;

namespace eStoreFrontCS
{
	/// <summary>
	/// This is a sample cart page.
	/// </summary>
	public class PurchaseDescription : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblContinue;
		protected System.Web.UI.WebControls.Button btnContinue;
		protected System.Web.UI.WebControls.RadioButton rdoCreditCard;
		protected System.Web.UI.WebControls.RadioButton rdoPaypal;
		private String mPayOption  = String.Empty;
		private String mOrderId = String.Empty;		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			// Set your page load options and processing here, if any.

			if(Page.IsPostBack)
			{
				if(rdoPaypal.Checked)
				{
					mPayOption = "PPL";
					lblContinue.Text = "Clicking “Continue” will transfer you to PayPal.";
					lblContinue.Text +="<br>After you approve the use of PayPal, you will";
					lblContinue.Text +=" be returned to eStoreFront to complete your purchase.";
				}
				else if(rdoCreditCard.Checked)
				{
					mPayOption = "CC";
					lblContinue.Text = "Clicking “Continue” will transfer you to billing and shipping information page.";
					// lblContinue.Text +="<br>Please enter the necessary billing and shipping information.";
				}
				else
				{
					mPayOption = "";
					lblContinue.Text = "";
				}
			}
			else if(Request.QueryString["Token"] != null)
			{
				mPayOption = "PPL";
				mOrderId = Request.QueryString["OrderId"];
				CallSetAndRedirect(mOrderId ,Request.QueryString["Token"]);
			}
		}

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
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			mOrderId = PayflowUtility.RequestId;

			if(String.Equals("CC",mPayOption))
			{
				Response.Redirect("CreditCardDetails.aspx?action=VE");
			}
			else if(String.Equals("PPL",mPayOption))
			{
				CallSetAndRedirect(mOrderId,null);
			}
		}

		private void CallSetAndRedirect(String OrderId,String Token)
		{
			// Calling SET operation is the first step of PayPal 
			// express checkout process.
			// In response of the SET request, you will get a secure 
			// session token id.
			// Using this token id, you should redirect the customer's 
			// browser to the PayPal website to establish a secure token.
			
			Response.SetCookie(new HttpCookie("OrderId",OrderId));
			Response.Cookies["OrderId"].Expires = DateTime.Now.AddDays(1);

			
			// Create the invoice object and set the amount value.
			Invoice Inv = new Invoice();
			Inv.Amt = new Currency(new decimal(21.98), "USD");

			// Create the data object for Express Checkout SET operation 
			// using ECSetRequest Data Object.
			ECSetRequest SetRequest = new ECSetRequest
				(Constants.LocalHostName + "/PayPalDetails.aspx", // This is the Return URL
				Constants.LocalHostName + "/PurchaseComplete.aspx"); // This is the Cancel URL
			
			//Check if Token passed is null or not.
			
			// If the token passed is not null, it means,
			// the user wants to edit the shipping details and therefore,
			// the page PayPalDetails.aspx has redirected the request back to this page.
			// PayPalDetails.aspx has passed Token (session token) and orderid in the querystring
			// We will hence do a repeated SET operation passing the current session id rather than
			// obtaining one.

			//If the token passed is null, it means, it is a new express checkout 
			// process. Therefore, by doing a SET operation, we should obtain a session 
			// token from paypal and later on redirect the user's browser to the paypal site
			// with this session token.
			if(Token != null && Token.Length > 0)
			{
				SetRequest.Token = Token;
			}

			// Create the Tender object.
			PayPalTender Tender = new PayPalTender(SetRequest);

			// Create the transaction object.
			AuthorizationTransaction Trans = new AuthorizationTransaction
				(Constants.PayflowECUser,
				Constants.Connection,
				Inv,
				Tender,
				OrderId);
			
			// Submit the transaction.
			Trans.SubmitTransaction();
			
			// Check the transaction status.
			bool mSuccess = false;
			if(Trans.Response.TransactionResponse.Result >= 0)
			{
				mSuccess = true;
			}

			if(Trans.Response.TransactionResponse.Result == 0)
			{
				// If the SET operation succeeds, 
				// you will get a secure session token id in the response of this operation.
				// Using this token, redirect the user's browser as follows:
				// Modify the url value in the web.config file for key "PayPalHost":
				String PayPalUrl = PayflowUtility.AppSettings("PayPalHost");
				PayPalUrl += Trans.Response.ExpressCheckoutSetResponse.Token;
				Response.Redirect(PayPalUrl,true);
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
					Message += " Please check your account details.";
					// Normally you wouldn't dislay the result code on your web page. This is just for review.
					MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString() + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString();
				}
				else
				{
					// A negative result code means there was an error thrown from the 
					// Payflow SDK for .NET. Pls make sure that your configurations is 
					// correct.
					Message += " An internal error occurred.";
					MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString() + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString();
				}
				Response.Redirect("PurchaseComplete.aspx?auth=NO&msg="+HttpUtility.UrlEncode(Message)+"&msgError="+HttpUtility.UrlEncode(MessageError),true);
			}
		}

	}
}

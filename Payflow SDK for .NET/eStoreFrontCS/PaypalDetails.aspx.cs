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
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;
using System.IO;

namespace eStoreFrontCS
{
	/// <summary>
	/// Summary description for PayPalDetails.
	/// </summary>
	public class PayPalDetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnContinue;
		protected System.Web.UI.WebControls.Label lblPaypalShippingDetails;
		private String mOrderId;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				String Token = Request.QueryString["Token"];
				mOrderId = Request.Cookies["OrderId"].Value;
				CallGetAndShowAddress(Token);
			}
			else
			{
				mOrderId = Request.Cookies["OrderId"].Value;
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

		private void CallGetAndShowAddress(String Token)
		{
			
			// Calling a GET operation is second step in PayPal 
			// Express checkout process. Once the customner has logged into 
			// his/her paypal account, selected shipping address and clicked on 
			// "Continue checkout", the paypal server will redirect the page to 
			// the ReturnUrl you have specified in the previous SET request.
			// To obtain the shipping details chosen by the Customer, you will 
			// then need to do a GET operation.

			// Create a Get request.
			ECGetRequest GetRequest = new ECGetRequest(Token);
			
			// Create the Tender.
			PayPalTender Tender = new PayPalTender(GetRequest);

			// Create a transaction.
			AuthorizationTransaction Trans = new AuthorizationTransaction
				(Constants.PayflowECUser,
				Constants.Connection,
				null,
				Tender,
				PayflowUtility.RequestId);
			
			// Submit the transaction.
			Response Resp = Trans.SubmitTransaction();
			
			bool mSuccess = false;
			if(Trans.Response.TransactionResponse.Result >= 0)
			{
				mSuccess = true;
			}

			if(Trans.Response.TransactionResponse.Result == 0)
			{
				// You have now obtained the customer's order details in the response of 
				// Get operation. Show these order details for review to the customer and persist them.
				lblPaypalShippingDetails.Text += "<blockquote>"  + Trans.Response.ExpressCheckoutGetResponse.FirstName + " " + Trans.Response.ExpressCheckoutGetResponse.LastName + "<br>";
				lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToStreet + "<br>";
				lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToStreet2 + "<br>";
				lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToCity + ", ";
				lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToState+ " ";
				lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToZip+ "</blockquote>";
				
				Session.Add("PayerId",Trans.Response.ExpressCheckoutGetResponse.PayerId);
				Session.Add("Token",Token);

				System.Security.Permissions.FileIOPermission IOPerm = new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write,AppDomain.CurrentDomain.BaseDirectory + "orders");
				IOPerm.Demand();
				FileInfo OrderFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"orders\" + mOrderId  + ".ord");
				if(OrderFile.Exists)
				{
					OrderFile.Delete();
				}
				StreamWriter OrderWriter =  OrderFile.CreateText();
				OrderWriter.WriteLine("ShipToFName=" + Trans.Response.ExpressCheckoutGetResponse.FirstName);
				OrderWriter.WriteLine("ShipToLName=" + Trans.Response.ExpressCheckoutGetResponse.LastName);
				OrderWriter.WriteLine("ShipToStreet=" + Trans.Response.ExpressCheckoutGetResponse.ShipToStreet);
				OrderWriter.WriteLine("ShipToStreet2=" + Trans.Response.ExpressCheckoutGetResponse.ShipToStreet2);
				OrderWriter.WriteLine("ShipToCity=" + Trans.Response.ExpressCheckoutGetResponse.ShipToCity);
				OrderWriter.WriteLine("ShipToState=" + Trans.Response.ExpressCheckoutGetResponse.ShipToState);
				OrderWriter.WriteLine("ShipToZip=" + Trans.Response.ExpressCheckoutGetResponse.ShipToZip);
				OrderWriter.WriteLine("PayMethod=" + "PayPal");
				OrderWriter.Flush();
				OrderWriter.Close();
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

		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			// Once the customer has reviewed the shipping details and decides to continue 
			// checkout by clicking on "Continue Checkout" button, it's time to actually 
			// authorize the transaction.
			// This is the third step in PayPal Express Checkout, in which you need to perform a 
			// DO operation to authorize the purchase amount.
			
			// Create a DO request.
			ECDoRequest DoRequest = new ECDoRequest((String)Session["Token"],(String)Session["PayerId"]);

			// Populate Invoice object.
			Invoice Inv = new Invoice();
			Inv.Amt = new Currency(new decimal(21.98), "USD");
			Inv.Comment1 = "Testing Express Checkout";
			// Create the Tender object.
			PayPalTender Tender = new PayPalTender(DoRequest);

			// Create the transaction object.
			AuthorizationTransaction Trans = new AuthorizationTransaction(Constants.PayflowECUser, Constants.Connection, Inv, Tender, PayflowUtility.RequestId);
			// Submit the transaction.
			Trans.SubmitTransaction();

			bool mSuccess = false;
			if(Trans.Response.TransactionResponse.Result >= 0)
			{
				mSuccess = true;
			}
			if(Trans.Response.TransactionResponse.Result == 0)
			{
				// Since we have done a Authorization we are going to Capture it for this example.
				// However, normally you would do the capture upon fullfillment of the order either through
				// PayPal Manager or via your back-end application. 
				// Create a new Capture Transaction for the original amount of the authorization.  We assume the
				// amount captured is the same as the original authorization.
				CaptureTransaction DCTrans = new CaptureTransaction(Trans.Response.TransactionResponse.Pnref, Constants.PayflowECUser, Constants.Connection, PayflowUtility.RequestId);
				// Indicates if this Delayed Capture transaction is the last capture you intend to make.
				// The values are: Y (default) / N
				// NOTE: If CAPTURECOMPLETE is Y, any remaining amount of the original reauthorized transaction
				// is automatically voided.
				// DCTrans.CaptureComplete = "N";
				// Submit the transaction.
				DCTrans.SubmitTransaction();
				// Store the response params in the order details file.
				// We are storing PNREF, PPREF, AVSADDR, AVSZIP, etc. for this example.  You would determine what 
				// you would store in your DB for your own needs.
				System.Security.Permissions.FileIOPermission IOPerm = new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write,AppDomain.CurrentDomain.BaseDirectory + "orders");
				IOPerm.Demand();
				FileInfo OrderFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"orders\" + mOrderId  + ".ord");
				if(OrderFile.Exists)
				{	
					StreamWriter OrderWriter =  OrderFile.AppendText();
					OrderWriter.WriteLine("PNREF=" + Trans.Response.TransactionResponse.Pnref);
					OrderWriter.WriteLine("PPREF=" + Trans.Response.TransactionResponse.PPref);
					OrderWriter.WriteLine("AVSADDR=" + Trans.Response.TransactionResponse.AVSAddr);
					OrderWriter.WriteLine("AVSZIP=" + Trans.Response.TransactionResponse.AVSZip);
					OrderWriter.WriteLine("AMOUNT=" + Inv.Amt.ToString());
					OrderWriter.WriteLine("PENDINGREASON=" + Trans.Response.TransactionResponse.PendingReason);
					OrderWriter.WriteLine("DC_PNREF=" + DCTrans.Response.TransactionResponse.Pnref);
					OrderWriter.WriteLine("DC_PPREF=" + DCTrans.Response.TransactionResponse.PPref);
					OrderWriter.WriteLine("DC_RESPMSG=" + DCTrans.Response.TransactionResponse.RespMsg);
					OrderWriter.WriteLine("DC_PENDINGREASON=" + DCTrans.Response.TransactionResponse.PendingReason);
					OrderWriter.Flush();
					OrderWriter.Close();
				}
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
	}
}

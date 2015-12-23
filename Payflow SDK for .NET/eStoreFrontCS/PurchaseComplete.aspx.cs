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
using System.IO;
using PayPal.Payments.Common.Utility;

namespace eStoreFrontCS
{
	/// <summary>
	/// Summary description for PurchaseComplete.
	/// </summary>
	public class PurchaseComplete : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblPurchaseStatus;
		private String mAuth;
		private String mMessage;
		private String mMessageError;
		protected System.Web.UI.WebControls.Button btnReturnToCart;
		protected System.Web.UI.WebControls.Label lblGreetings;
		private String mToken;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			mAuth = Request.QueryString.Get("auth");
			mMessage = Request.QueryString.Get("msg");
			mMessageError = Request.QueryString.Get("msgError");
			mToken = Request.QueryString.Get("token");
			
			if(String.Equals("NO",mAuth))
			{
				lblPurchaseStatus.Text = mMessage + "<br><br>" + mMessageError + "<br><br>Click “Return to Cart” to process a new transaction.";
				lblGreetings.Text = "Sorry ...";
				btnReturnToCart.Visible = true;
			}
			else if(String.Equals("YES",mAuth))
			{
				String OrderId = Request.Cookies["OrderId"].Value;
				StreamReader OrderReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"orders\" + OrderId + ".ord");
				Hashtable OrderTable = new Hashtable();
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
							Value = CurrLine.Substring(SepIndex+1);
						}
						OrderTable.Add(Name,Value);
					}
					OrderReader.Close();
				}
				lblGreetings.Text = "Thank you ...";
				lblPurchaseStatus.Text = "Your order is placed successfully. Order details as shown:";
				lblPurchaseStatus.Text += "<br><br><TABLE id='Table1' style='Z-INDEX: 103; LEFT: 72px; WIDTH: 488px;'";
				lblPurchaseStatus.Text += "cellSpacing='1' cellPadding='0' width='300' border='0' align='left'>";
				lblPurchaseStatus.Text += "<TR align='left'><TD><STRONG>Cart</STRONG></TD><TD><STRONG>Total</STRONG></TD></TR>";
				lblPurchaseStatus.Text += "<TR align='left'><TD>All Season Jacket. (Large)</TD><TD>19.99</TD></TR>";
				lblPurchaseStatus.Text += "<TR><TD>State Sales Tax</TD><TD>&nbsp; 1.99</TD></TR>";
				lblPurchaseStatus.Text += "<TR><TD><b>Order Total:</b></TD><TD>21.98</TD></TR></TABLE><br>";
				lblPurchaseStatus.Text += "<br><br><br><br><br><b>Payment Method:</b>		";	
				lblPurchaseStatus.Text += (String)OrderTable["PayMethod"];

				if(!"PayPal".Equals((String)OrderTable["PayMethod"]))
				{
					String Billing = "<br><br><br><b>Billing Address:</b><br>";
					Billing += "<blockquote>"  + (String)OrderTable["FirstName"] + " " + (String)OrderTable["LastName"] + "<br>";
					Billing += (String)OrderTable["Street"] + "<br>";
					Billing += (String)OrderTable["City"] + ", " + (String)OrderTable["State"] + " " + (String)OrderTable["Zip"];
					Billing += "</blockquote>";
					if(Billing != null && Billing.Length > 0 && !"<br><br><br><b>Billing Address:</b><br><blockquote> <br><br><br>, </blockquote>".Equals(Billing))
					{
						lblPurchaseStatus.Text += Billing;
					}
				}
				String Shipping = "<br><br><b>Shipping Address:</b><br>";
				Shipping += "<blockquote>"  + (String)OrderTable["ShipToFName"] + " " + (String)OrderTable["ShipToLName"] + "<br>";
				Shipping += (String)OrderTable["ShipToStreet"] + "<br>";
				Shipping += (String)OrderTable["ShipToStreet2"] + "<br>";
				Shipping += (String)OrderTable["ShipToCity"] + ", " + (String)OrderTable["ShipToState"] + " " + (String)OrderTable["ShipToZip"];
				Shipping += "</blockquote>";
				if(Shipping != null && Shipping.Length > 0 && !"<br><br><b>Shipping Address:</b><br><blockquote> <br><br><br>, </blockquote>".Equals(Shipping))
				{
					lblPurchaseStatus.Text += Shipping;
				}				
			}
			else
			{
				lblPurchaseStatus.Text = "Your order could not be completed at this time."+ "<br>Click “Return to Cart” to a process new transaction.";
				lblGreetings.Text = "Sorry ...";
			}
			btnReturnToCart.Visible = true;
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
			this.btnReturnToCart.Click += new System.EventHandler(this.btnReturnToCart_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnReturnToCart_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("PurchaseDescription.aspx",true);
		}
	}
}

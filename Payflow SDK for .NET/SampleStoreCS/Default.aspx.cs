using System;
//namespace 
//{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Put user code to initialize the page here
        Response.Redirect(Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/")) + "/src/PayPal/Payments/SampleStore/CS/Aspx/SampleStore.aspx");
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Init Function
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
//}

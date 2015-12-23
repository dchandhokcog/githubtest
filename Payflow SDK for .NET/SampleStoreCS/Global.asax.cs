using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

//namespace Payflow SDK_SampleStore_CS 
//{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		/// <summary>
		/// 
		/// </summary>
		public Global()
		{
			InitializeComponent();
		}	
		/// <summary>
		/// Fires when the application is started
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
		/// <summary>
		/// Fires when the session is started
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}
		/// <summary>
		/// Fires at the beginning of each request
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}
		/// <summary>
		/// Fires at the end of each request
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}
		/// <summary>
		/// Fires upon attempting to authenticate the use
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}
		/// <summary>
		/// Fires when an error occurs
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_Error(Object sender, EventArgs e)
		{

		}
		/// <summary>
		/// Fires when the session ends
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Session_End(Object sender, EventArgs e)
		{

		}
		/// <summary>
		/// Fires when the application ends
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
//}


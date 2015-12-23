using System;
using PayPal.Payments.DataObjects;

namespace eStoreFrontCS
{
	/// <summary>
	/// Summary description for Constants.
	/// </summary>
	public class Constants
	{
		private Constants()
		{
		}
				
		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: 	pilot-payflowpro.paypal.com
		// For production: 	payflowpro.paypal.com

		// DO NOT use test-payflow.verisign.com or payflow.verisign.com.
		
		// If needed, set proxy like given example.
		// internal static PayflowConnectionData Connection = new PayflowConnectionData("pilot-payflowpro.paypal.com",443,<ProxyAddress>,<ProxyPort>,<ProxyLogon>,<ProxyPassword>);
		public static PayflowConnectionData Connection = new PayflowConnectionData("pilot-payflowpro.paypal.com",443,null,0,null,null);
		//This is Express Checkout User information
		internal static UserInfo PayflowECUser = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");
		//This is Buyer Auth User information
		internal static UserInfo PayflowBAUser = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");
		internal static String LocalHostName  = System.Configuration.ConfigurationSettings.AppSettings["hostName"];
	}
}

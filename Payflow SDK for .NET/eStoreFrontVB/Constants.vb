Imports System
Imports PayPal.Payments.DataObjects

Namespace eStoreFrontVB
    Public Class Constants
        ''' <summary>
        ''' Summary description for Constants.
        ''' </summary>
        Private Sub Constants()

        End Sub

        ' Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
        ' For testing: 	    pilot-payflowpro.paypal.com
        ' For production: 	payflowpro.paypal.com

        ' DO NOT use test-payflow.verisign.com or payflow.verisign.com.
        
        ' If needed, set proxy like given example.
        'Friend Shared Connection As PayflowConnectionData = New PayflowConnectionData("pilot-payflowpro.paypal.com",443,<ProxyAddress>,<ProxyPort>,<ProxyLogon>,<ProxyPassword>)
        Friend Shared Connection As PayflowConnectionData = New PayflowConnectionData("pilot-payflowpro.paypal.com", 443, "", 0, "", "")
        'This is Express check out User information
        Friend Shared PayflowECUser As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")
        'This is Buyer Auth User information
        Friend Shared PayflowBAUser As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

        Friend Shared LocalHostName As String = System.Configuration.ConfigurationSettings.AppSettings("hostName")
    End Class

End Namespace


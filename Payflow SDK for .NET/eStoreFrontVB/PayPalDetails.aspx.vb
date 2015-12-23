Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions
Imports System.IO
Namespace eStoreFrontVB

    Public Class PayPalDetails
        Inherits System.Web.UI.Page
        Protected WithEvents btnContinue As System.Web.UI.WebControls.Button
        Protected lblPaypalShippingDetails As System.Web.UI.WebControls.Label
        Private mOrderId As String

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Dim Token As String = Request.QueryString("Token")
                mOrderId = Request.Cookies("OrderId").Value
                CallGetAndShowAddress(Token)
            Else
                mOrderId = Request.Cookies("OrderId").Value
            End If
        End Sub

        Private Sub CallGetAndShowAddress(ByVal Token As String)
            ' Calling a GET operation is second step in PayPal 
            ' Express checkout process. Once the customner has logged into 
            ' his/her PayPal account, selected shipping address and clicked on 
            ' "Continue checkout", the PayPal server will redirect the page to 
            ' the ReturnUrl you have specified in the previous SET request.
            ' To obtain the shipping details chosen by the Customer, you will 
            ' then need to do a GET operation.

            ' Create a Get request.
            Dim GetRequest As ECGetRequest = New ECGetRequest(Token)
            ' Create the Tender.
            Dim Tender As PayPalTender = New PayPalTender(GetRequest)

            ' Create a transaction.
            Dim Trans As AuthorizationTransaction = New AuthorizationTransaction(Constants.PayflowECUser, Constants.Connection, Nothing, Tender, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()
            Dim mSuccess As Boolean = False
            If Trans.Response.TransactionResponse.Result >= 0 Then
                mSuccess = True
            End If

            If Trans.Response.TransactionResponse.Result = 0 Then
                ' You have now obtained the customer's order details in the response of 
                ' Get operation. Show these order details for review to the customer and persist them.
                lblPaypalShippingDetails.Text += "<blockquote>" + Trans.Response.ExpressCheckoutGetResponse.FirstName + " " + Trans.Response.ExpressCheckoutGetResponse.LastName + "<br>"
                lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToStreet + "<br>"
                lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToStreet2 + "<br>"
                lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToCity + ", "
                lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToState + " "
                lblPaypalShippingDetails.Text += Trans.Response.ExpressCheckoutGetResponse.ShipToZip + "</blockquote>"
                Session.Add("PayerId", Trans.Response.ExpressCheckoutGetResponse.PayerId)
                Session.Add("Token", Token)
                Dim IOPerm As System.Security.Permissions.FileIOPermission = New System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, AppDomain.CurrentDomain.BaseDirectory + "orders")
                IOPerm.Demand()
                Dim OrderFile As FileInfo = New FileInfo(AppDomain.CurrentDomain.BaseDirectory + "orders\" + mOrderId + ".ord")
                If OrderFile.Exists Then
                    OrderFile.Delete()
                End If
                Dim OrderWriter As StreamWriter = OrderFile.CreateText()
                OrderWriter.WriteLine("ShipToFName=" + Trans.Response.ExpressCheckoutGetResponse.FirstName)
                OrderWriter.WriteLine("ShipToLName=" + Trans.Response.ExpressCheckoutGetResponse.LastName)
                OrderWriter.WriteLine("ShipToStreet=" + Trans.Response.ExpressCheckoutGetResponse.ShipToStreet)
                OrderWriter.WriteLine("ShipToCity=" + Trans.Response.ExpressCheckoutGetResponse.ShipToCity)
                OrderWriter.WriteLine("ShipToState=" + Trans.Response.ExpressCheckoutGetResponse.ShipToState)
                OrderWriter.WriteLine("ShipToZip=" + Trans.Response.ExpressCheckoutGetResponse.ShipToZip)
                OrderWriter.WriteLine("PayMethod=" + "PayPal")
                OrderWriter.Flush()
                OrderWriter.Close()
            Else
                ' Do the error handling here according to your design and business logic.
                ' This is a sample error handling code for this fictious eStoreFront.
                Dim Message As String = "Your order cannot be completed at this time."
                Dim MessageError As String = ""
                ' If result code is greater than 0 (Zero), the transaction is discarded 
                ' by the Payflow server. The reason why the transaction is discarded is 
                ' evident by the result code value and therefore, you should look at this 
                ' result code and decide if 
                ' 1. The customer has given some wrong inputs,
                ' 2. It's a fraudulent transaction.
                ' 3. There's a problem with your merchant account credentials etc.
                ' (This is more likely to be caught in your test scenarios.)
                If (mSuccess) Then
                    ' Here you can decide what message needs to be shown to 
                    ' the customer based on the result code returned by the Payflow 
                    ' Pro service.
                    Message += " Please check your account details."
                    ' Normally you wouldn't dislay the result code on your web page.  This is just for review.
                    MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString
                Else
                    ' A negative result code means there was an error thrown from the 
                    ' Payflow SDK for .NET. Pls make sure that your configurations is 
                    ' correct.
                    Message += "  An internal error occurred."
                    MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString
                End If
                Response.Redirect("PurchaseComplete.aspx?auth=NO&msg=" + HttpUtility.UrlEncode(Message) + "&msgError=" + HttpUtility.UrlEncode(MessageError), True)
            End If

        End Sub

        Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
            ' Once the customer has reviewed the shipping details and decides to continue 
            ' checkout by clicking on "Continue Checkout" button, it's time to actually 
            ' authorize the transaction.
            ' This is the third step in PayPal Express Checkout, in which you need to perform a 
            ' DO operation to authorize the purchase amount.

            ' Create a DO request.
            Dim DoRequest As ECDoRequest = New ECDoRequest(Session("Token"), Session("PayerId"))
            ' Populate Invoice object.
            Dim Inv As Invoice = New Invoice
            Inv.Amt = New Currency(New Decimal(21.98), "USD")
            Inv.Comment1 = "Testing Express Checkout"
            ' Create the Tender object.
            Dim Tender As PayPalTender = New PayPalTender(DoRequest)

            ' Create the transaction object.
            ' Here we are going to Authorize the transaction as you would if fullfillment was delayed.  If you 
            ' are going to be fullfilling the order immediately, you could do a SaleTransaction instead which
            ' would bypass having to capture the transaction later.
            Dim Trans As AuthorizationTransaction = New AuthorizationTransaction(Constants.PayflowECUser, Constants.Connection, Inv, Tender, PayflowUtility.RequestId)
            ' Submit the transaction.
            Trans.SubmitTransaction()

            Dim mSuccess As Boolean = False
            If Trans.Response.TransactionResponse.Result >= 0 Then
                mSuccess = True
            End If
            If Trans.Response.TransactionResponse.Result = 0 Then
                ' Since we have done a Authorization we are going to Capture it for this example.
                ' However, normally you would do the capture upon fullfillment of the order either through
                ' PayPal Manager or via your back-end application. 
                ' Create a new Capture Transaction for the original amount of the authorization.  We assume the
                ' amount captured is the same as the original authorization.
                Dim DCTrans As CaptureTransaction = New CaptureTransaction(Trans.Response.TransactionResponse.Pnref, Constants.PayflowECUser, Constants.Connection, PayflowUtility.RequestId)
                ' Indicates if this Delayed Capture transaction is the last capture you intend to make.
                ' The values are: Y (default) / N
                ' NOTE: If CAPTURECOMPLETE is Y, any remaining amount of the original reauthorized transaction
                ' is automatically voided.
                ' DCTrans.CaptureComplete = "N"
                ' Submit the transaction.
                DCTrans.SubmitTransaction()
                ' Store the response params in the order details file.
                ' We are storing PNREF, PPREF, AVSADDR, AVSZIP, etc. for this example.  You would determine what 
                ' you would store in your DB for your own needs.
                Dim IOPerm As System.Security.Permissions.FileIOPermission = New System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, AppDomain.CurrentDomain.BaseDirectory + "orders")
                IOPerm.Demand()
                Dim OrderFile As FileInfo = New FileInfo(AppDomain.CurrentDomain.BaseDirectory + "orders\" + mOrderId + ".ord")
                If (OrderFile.Exists) Then
                    Dim OrderWriter As StreamWriter = OrderFile.AppendText()
                    OrderWriter.WriteLine("PNREF=" + Trans.Response.TransactionResponse.Pnref)
                    OrderWriter.WriteLine("PPREF=" + Trans.Response.TransactionResponse.PPref)
                    OrderWriter.WriteLine("AVSADDR=" + Trans.Response.TransactionResponse.AVSAddr)
                    OrderWriter.WriteLine("AVSZIP=" + Trans.Response.TransactionResponse.AVSZip)
                    OrderWriter.WriteLine("AMOUNT=" + Inv.Amt.ToString)
                    OrderWriter.WriteLine("PENDINGREASON=" + Trans.Response.TransactionResponse.PendingReason)
                    OrderWriter.WriteLine("DC_PNREF=" + DCTrans.Response.TransactionResponse.Pnref)
                    OrderWriter.WriteLine("DC_PPREF=" + DCTrans.Response.TransactionResponse.PPref)
                    OrderWriter.WriteLine("DC_RESPMSG=" + DCTrans.Response.TransactionResponse.RespMsg)
                    OrderWriter.WriteLine("DC_PENDINGREASON=" + DCTrans.Response.TransactionResponse.PendingReason)
                    OrderWriter.Flush()
                    OrderWriter.Close()
                End If
                Response.Redirect("PurchaseComplete.aspx?auth=YES", True)
            Else
                ' Do the error handling here according to your design and business logic.
                ' This is a sample error handling code for this fictious eStoreFront.
                Dim Message As String = "Your order cannot be completed at this time."
                Dim MessageError As String = ""
                ' If result code is greater than 0 (Zero), the transaction is discarded 
                ' by the Payflow server. The reason why the transaction is discarded is 
                ' evident by the result code value and therefore, you should look at this 
                ' result code and decide if 
                ' 1. The customer has given some wrong inputs,
                ' 2. It's a fraudulent transaction.
                ' 3. There's a problem with your merchant account credentials etc.
                ' (This is more likely to be caught in your test scenarios.)
                If (mSuccess) Then
                    ' Here you can decide what message needs to be shown to 
                    ' the customer based on the result code returned by the Payflow 
                    ' Pro service.
                    Message += " Please check your account details."
                    ' Normally you wouldn't dislay the result code on your web page.  This is just for review.
                    MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString
                Else
                    ' A negative result code means there was an error thrown from the 
                    ' Payflow SDK for .NET. Pls make sure that your configurations is 
                    ' correct.
                    Message += "  An internal error occurred."
                    MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString
                End If
                Response.Redirect("PurchaseComplete.aspx?auth=NO&msg=" + HttpUtility.UrlEncode(Message) + "&msgError=" + HttpUtility.UrlEncode(MessageError), True)
            End If
        End Sub
    End Class
End Namespace
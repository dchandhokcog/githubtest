Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports PayPal.Payments.Transactions
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Common.Utility
Namespace eStoreFrontVB

    Public Class PurchaseDescription
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblContinue As System.Web.UI.WebControls.Label
        Protected WithEvents btnContinue As System.Web.UI.WebControls.Button
        Protected WithEvents rdoCreditCard As System.Web.UI.WebControls.RadioButton
        Protected WithEvents rdoPaypal As System.Web.UI.WebControls.RadioButton
        Private mPayOption As String = String.Empty
        Private mOrderId As String = String.Empty

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
            ' Set your page load options and processing here, if any.
            If Page.IsPostBack Then
                If rdoPaypal.Checked Then
                    mPayOption = "PPL"
                    lblContinue.Text = "Clicking ""Continue"" will transfer you to PayPal."
                    lblContinue.Text += "<br>After you approve the use of PayPal, you will "
                    lblContinue.Text += "be returned to eStoreFront to complete your purchase."
                ElseIf (rdoCreditCard.Checked) Then
                    mPayOption = "CC"
                    lblContinue.Text = "Clicking Continue will transfer you to billing and shipping information."
                    lblContinue.Text += "<br>Please enter the necessary billing and shipping information."
                Else
                    mPayOption = ""
                    lblContinue.Text = ""
                End If
            ElseIf (Request.QueryString("Token") <> "") Then
                mPayOption = "PPL"
                mOrderId = Request.QueryString("OrderId")
                CallSetAndRedirect(mOrderId, Request.QueryString("Token"))
            End If
        End Sub


        Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
            mOrderId = PayflowUtility.RequestId
            If (String.Equals("CC", mPayOption)) Then
                Response.Redirect("CreditCardDetails.aspx?action=VE")
            ElseIf (String.Equals("PPL", mPayOption)) Then
                CallSetAndRedirect(mOrderId, "")
            End If
        End Sub

        Private Sub CallSetAndRedirect(ByVal OrderId As String, ByVal Token As String)

            ' Calling SET operation is the first step of PayPal 
            ' express checkout process.
            ' In response of the SET request, you will get a secure 
            ' session token id.
            ' Using this token id, you should redirect the customer's 
            ' browser to the PayPal website to establish a secure token.
            Response.SetCookie(New HttpCookie("OrderId", OrderId))
            Response.Cookies("OrderId").Expires = DateTime.Now.AddDays(1)
            ' Create the invoice object and set the amount value.
            Dim Inv As Invoice = New Invoice
            Inv.Amt = New Currency(New Decimal(21.98), "USD")

            ' Create the data object for Express Checkout SET operation 
            ' using ECSetRequest Data Object.
            ' Setting the Return and Cancel URL.
            Dim SetRequest As ECSetRequest = New ECSetRequest( _
                Constants.LocalHostName.ToString + "/PayPalDetails.aspx", _
                Constants.LocalHostName.ToString + "/PurchaseComplete.aspx")

            'Check if Token passed is null or not.

            ' If the token passed is not null, it means,
            ' the user wants to edit the shipping details and therefore,
            ' the page PayPalDetails.aspx has redirected the request back to this page.
            ' PayPalDetails.aspx has passed Token (session token) and orderid in the querystring
            ' We will hence do a repeated SET operation passing the current session id rather than
            ' obtaining one.

            'If the token passed is null, it means, it is a new express checkout 
            ' process. Therefore, by doing a SET operation, we should obtain a session 
            ' token from paypal and later on redirect the user's browser to the paypal site
            ' with this session token.

            If Token <> "" And Token.Length > 0 Then
                SetRequest.Token = Token
            End If

            ' Create the Tender object.
            Dim Tender As PayPalTender = New PayPalTender(SetRequest)

            ' Create the transaction object.
            Dim Trans As AuthorizationTransaction = New AuthorizationTransaction(Constants.PayflowECUser, Constants.Connection, Inv, Tender, OrderId)
            ' Submit the transaction.
            Trans.SubmitTransaction()

            ' Check the transaction status.
            Dim mSuccess As Boolean = False
            If Trans.Response.TransactionResponse.Result >= 0 Then
                mSuccess = True
            End If

            If Trans.Response.TransactionResponse.Result = 0 Then

                ' If the SET operation succeeds, 
                ' you will get a secure session token id in the response of this operation.
                ' Using this token, redirect the user's browser as follows:
                ' Modify the url value in the web.config file for key "PayPalHost":
                Dim PayPalUrl As String = PayflowUtility.AppSettings("PayPalHost")
                PayPalUrl += Trans.Response.ExpressCheckoutSetResponse.Token
                Response.Redirect(PayPalUrl, True)
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


Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.Common
Imports System.IO
Namespace eStoreFrontVB

    Public Class CreditCardDetails
        Inherits System.Web.UI.Page
        Public Event Redirect As HandleRequestPayer
        Delegate Sub HandleRequestPayer(ByVal RequestHTML As String)

#Region "Member Variables"
        Protected ddExpMonth As System.Web.UI.WebControls.DropDownList
        Protected ddExpYear As System.Web.UI.WebControls.DropDownList
        Protected lblBillingAddress As System.Web.UI.WebControls.Label
        Protected lblBillName As System.Web.UI.WebControls.Label
        Protected lblBillFName As System.Web.UI.WebControls.Label
        Protected txtFirstName As System.Web.UI.WebControls.TextBox
        Protected txtCCNumber As System.Web.UI.WebControls.TextBox
        Protected lblBillLastName As System.Web.UI.WebControls.Label
        Protected txtLastName As System.Web.UI.WebControls.TextBox
        Protected lblStreet As System.Web.UI.WebControls.Label
        Protected txtStreet As System.Web.UI.WebControls.TextBox
        Protected lblCity As System.Web.UI.WebControls.Label
        Protected txtCity As System.Web.UI.WebControls.TextBox
        Protected lblZip As System.Web.UI.WebControls.Label
        Protected txtZip As System.Web.UI.WebControls.TextBox
        Protected lblState As System.Web.UI.WebControls.Label

        Protected txtState As System.Web.UI.WebControls.TextBox
        Protected lblShippingAddress As System.Web.UI.WebControls.Label
        Protected chkCopyBilling As System.Web.UI.WebControls.CheckBox
        Protected txtShipToFName As System.Web.UI.WebControls.TextBox
        Protected txtShipToLName As System.Web.UI.WebControls.TextBox
        Protected txtShipToStreet As System.Web.UI.WebControls.TextBox
        Protected txtShipToZip As System.Web.UI.WebControls.TextBox
        Protected txtShipToCity As System.Web.UI.WebControls.TextBox
        Protected txtShipToState As System.Web.UI.WebControls.TextBox
        Protected lblCreditCard As System.Web.UI.WebControls.Label
        Protected lblCCNumber As System.Web.UI.WebControls.Label
        Protected lblExpDate As System.Web.UI.WebControls.Label
        Protected lblExMonth As System.Web.UI.WebControls.Label
        Protected lblExDate As System.Web.UI.WebControls.Label
        Protected lblSTName As System.Web.UI.WebControls.Label
        Protected lblSTFName As System.Web.UI.WebControls.Label
        Protected lblSTLName As System.Web.UI.WebControls.Label
        Protected lblSTStreet As System.Web.UI.WebControls.Label
        Protected lblSTCity As System.Web.UI.WebControls.Label
        Protected lblSTZip As System.Web.UI.WebControls.Label
        Protected lblSTState As System.Web.UI.WebControls.Label
        Protected chkProcessWithBuyerAuth As System.Web.UI.WebControls.CheckBox
        Protected lblCvv2 As System.Web.UI.WebControls.Label
        Protected txtCVV2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCheckout As System.Web.UI.WebControls.Button
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Private mOrderId As String

#End Region

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

            If Page.IsPostBack Then
                If chkCopyBilling.Checked Then
                    txtShipToFName.Text = txtFirstName.Text
                    txtShipToLName.Text = txtLastName.Text
                    txtShipToStreet.Text = txtStreet.Text
                    txtShipToCity.Text = txtCity.Text
                    txtShipToZip.Text = txtZip.Text
                    txtShipToState.Text = txtState.Text
                End If

            ElseIf (Not String.Equals("VE", CStr(Request.QueryString.Get("action")))) Then
                ' Do the validate authentication transaction for buyerauth.
                Dim VaResp As Response = DoValidateAuthentication()
                If VaResp.TransactionResponse.Result = 0 Then
                    ' If validate authentication is successful, then perform the 
                    ' main authorization transaction.
                    DoAuthorization(VaResp)
                Else
                    Dim Message As String = "An error ocurred while trying to process the transaction."
                    Dim MessageError As String = "Result code: " + VaResp.TransactionResponse.Result.ToString + ", " + VaResp.TransactionResponse.RespMsg.ToString
                    Response.Redirect("PurchaseComplete.aspx?auth=NO&msg=" + HttpUtility.UrlEncode(Message) + "&msgError=" + HttpUtility.UrlEncode(MessageError), True)
                End If
            End If
        End Sub



        Private Sub btnCheckout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckout.Click
            mOrderId = PayflowUtility.RequestId
            ' When checkout is clicked, perform a verify enrollment transaction 
            ' to check whether the user is enrolled for the buyer authentication 
            ' service or not.

            ' Before proceeding with transaction processing, you should persist the order details.
            ' The details of the order that are generally persisted are:
            ' Credit card details : Card Number, Expiry date ( Card CVV2 number cannot be stored).
            ' Billing address details, shipping address details.
            ' Storing these details helps you to allow a returning customer to do a faster 
            ' checkout, having his/her details already populated in the desired fields.
            ' Storing the ordering details is generally uses database.
            ' Here, however for the demonstration purpose, this web application stores the order 
            ' details in a flat file named <order_id>.ord and retrieves it later. 
            ' Note that this is not a recommended method to persist order details.
            PersistOrderDetails(mOrderId)
            If chkProcessWithBuyerAuth.Checked Then

                ' After a successful Verify Transaction,
                ' if the user is enrolled for the buyer authentication service
                ' user's browser needs to be redirected to his/her banks'/cards' server(Access Control Server [ACS]).
                ' Here he/she authenticates him/her self with his login information.
                ' During this process, your web application will not have any control over the proceedings unless the 
                ' ACS does not redirect back to your server. 
                DoVerifyEnrollmentAndRedirect()

            Else
                ' Perform an authorization transaction.
                ' Populate the transaction from persisted order details.
                Dim Trans As AuthorizationTransaction = PopulateTransaction(mOrderId)
                ' Submit the transaction.
                Trans.SubmitTransaction()

                If Trans.Response.TransactionResponse.Result >= 0 Then
                    ' Persist the response paramaters in the order details.
                    ' It is a good practice to store AVSADDR, AVSZIP, CVV2MATCH 
                    ' along with the unique transaction reference number PNREF.
                    Dim Encoder As Base64Encoder = New Base64Encoder
                    Dim IOPerm As System.Security.Permissions.FileIOPermission = New System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, AppDomain.CurrentDomain.BaseDirectory + "orders")
                    IOPerm.Demand()
                    Dim OrderFile As FileInfo = New FileInfo(AppDomain.CurrentDomain.BaseDirectory + "orders\" + mOrderId + ".ord")
                    If OrderFile.Exists Then
                        Dim OrderWriter As StreamWriter = OrderFile.AppendText()
                        OrderWriter.WriteLine("PnRef=" + Trans.Response.TransactionResponse.Pnref)
                        OrderWriter.WriteLine("Result=" + Trans.Response.TransactionResponse.Result.ToString)
                        OrderWriter.WriteLine("RespMsg=" + Trans.Response.TransactionResponse.RespMsg)
                        OrderWriter.WriteLine("AvsAddr=" + Trans.Response.TransactionResponse.AVSAddr)
                        OrderWriter.WriteLine("AvsZip=" + Trans.Response.TransactionResponse.AVSZip)
                        OrderWriter.WriteLine("Cvv2Match=" + Trans.Response.TransactionResponse.CVV2Match)
                        ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                        Dim TransCtx As Context = Trans.Response.TransactionContext
                        If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
                            OrderWriter.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
                        End If
                        OrderWriter.Flush()
                        OrderWriter.Close()
                    End If
                End If
                ShowStatusAndRedirect(Trans)
            End If
        End Sub

        Private Sub DoVerifyEnrollmentAndRedirect()
            ' Create the Credit card object.
            Dim Card As CreditCard = New CreditCard(txtCCNumber.Text, ddExpMonth.SelectedValue + ddExpYear.SelectedValue)
            ' Create the currency object for amount. 
            ' Here the currency code is the 3 digit ISO country code.
            ' For US -> USD.
            'Dim Amt As Currency = New Currency(New Decimal(21.98), "840")
            Dim Amt As Currency = New Currency(New Decimal(1.0), "840")
            ' Create a Verify Enrollment Transaction.
            Dim Trans As BuyerAuthVETransaction = New BuyerAuthVETransaction(Constants.PayflowBAUser, Card, Constants.Connection, Amt, PayflowUtility.RequestId)
            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()
            ' Redirect to the ACS ( Access Control Server, eg. users' bank)
            ' The URL to ACS and PaReq (Payer Authentication Request -- 
            ' digitally signed, encrypted request to authenticate user's enrollment 
            ' upon his/her login is returned in the response of verify enrollment.
            ' This happens if, the user is enrolled for buyerauth abd the transaction succeeds.
            If Resp.TransactionResponse.Result = 0 Then
                ' Check if the user is enrolled for the buyer authentication service.
                ' If the AUTHENTICATION_STATUS response parameter is E, means user is 
                ' enrolled for this service. If so, redirect the user's browser  as follows 
                ' to his/her bank's secure URL with PaReq, both obtained in ACSURL response parameter:
                ' In this you can use the MD field to set any descriptive field or a key to your persisted 
                ' order details (such as order id), which are required to retrive later on.
                ' TermUrl is the URL of the page of your web application where the bank's secure server will 
                ' redirect the PaRes as the authentication response to for further processing.
                If (String.Equals("E", Resp.BuyerAuthResponse.Authentication_Status)) Then
                    ' This means the user has enrolled him/her self for the buyer authentication 
                    ' service. Therefore, now the user should be redirected to his/her bank's secure 
                    ' server.

                    RedirectBuyerAuthRequest(Trans.Response.BuyerAuthResponse.PaReq.Trim(), Trans.Response.BuyerAuthResponse.AcsUrl, mOrderId)

                    ' Dim RedirectUrl As String = Trans.Response.BuyerAuthResponse.AcsUrl & "?PaReq=" & System.Web.HttpUtility.UrlEncode(Trans.Response.BuyerAuthResponse.PaReq.Trim()) & "&TermUrl=" & Constants.LocalHostName + "/CreditCardDetails.aspx&MD=" + mOrderId
                    ' Response.Redirect(RedirectUrl, True)

                Else
                    ' If the user is not enrolled for buyer authentication, 
                    ' take the decision accornding to your business logic whether to 
                    ' allow the transaction to proceed or not.
                    ' Here in this ficitous store front, the decision is taken to go 
                    ' ahead with an authorization.
                    Dim TransAuth As AuthorizationTransaction = PopulateTransaction(mOrderId)
                    Dim RespAuth As Response = TransAuth.SubmitTransaction()
                    ShowStatusAndRedirect(TransAuth)
                End If
            Else
                ShowStatusAndRedirect(Trans)
            End If
        End Sub

        Private Function PopulateTransaction(ByVal OrderId As String) As AuthorizationTransaction
            Dim OrderTable As Hashtable = New Hashtable
            ' Populate the authorization transaction from the persisted order 
            ' details. This will generally involve populating the order from 
            ' your order database. Here, however for the demonstration purpose, 
            ' the order details are stored in a flat file named <order_id>.ord.
            ' Note that, this is not a recommneded method to persist order details 
            ' and is only implemented for demonstration purpose.
            Dim Decoder As Base64Encoder = New Base64Encoder
            Dim OrderReader As StreamReader = New StreamReader(AppDomain.CurrentDomain.BaseDirectory + "orders\" + OrderId + ".ord")
            If Not "".Equals(OrderReader) Then

                While (OrderReader.Peek() >= 0)
                    Dim CurrLine As String = OrderReader.ReadLine()
                    Dim SepIndex As Integer = CurrLine.IndexOf("=", 0)
                    Dim Name As String = CurrLine.Substring(0, SepIndex)
                    Dim Value = String.Empty
                    If (SepIndex < CurrLine.Length - 1) Then
                        If Name = "CCNumber" Then
                            ' Example of how you might decrypt the credit card number should you decide to store it.
                            Value = Decoder.Decrypt(CurrLine.Substring(SepIndex + 1))
                        Else
                            Value = CurrLine.Substring(SepIndex + 1)
                        End If
                    End If
                    OrderTable.Add(Name, Value)
                End While
                OrderReader.Close()
            End If

            ' Populate the Billing address details.
            Dim Bill As BillTo = New BillTo
            Bill.FirstName = OrderTable.Item("FirstName")
            Bill.LastName = OrderTable.Item("LastName")
            Bill.Street = OrderTable.Item("Street")
            Bill.City = OrderTable.Item("City")
            Bill.Zip = OrderTable.Item("Zip")
            Bill.State = OrderTable.Item("State")

            ' Populate the Shipping address details.
            Dim Ship As ShipTo = New ShipTo
            Ship.ShipToFirstName = OrderTable.Item("ShipToFName")
            Ship.ShipToLastName = OrderTable.Item("ShipToLName")
            Ship.ShipToStreet = OrderTable.Item("ShipToStreet")
            Ship.ShipToCity = OrderTable.Item("ShipToCity")
            Ship.ShipToZip = OrderTable.Item("ShipToZip")
            Ship.ShipToState = OrderTable.Item("ShipToState")

            ' Populate the invoice
            Dim Inv As Invoice = New Invoice
            Inv.BillTo = Bill
            Inv.ShipTo = Ship
            Inv.InvNum = OrderId
            Inv.Amt = New Currency(Decimal.Parse(OrderTable.Item("Amount")))

            ' Populate the Credit Card details.
            Dim Card As CreditCard = New CreditCard(OrderTable.Item("CCNumber"), OrderTable.Item("ExpDate"))

            ' Create the Tender.
            Dim Tender As CardTender = New CardTender(Card)

            ' Create the transaction.
            Dim Trans As AuthorizationTransaction = New AuthorizationTransaction(Constants.PayflowBAUser, Constants.Connection, Inv, Tender, OrderId)
            Return Trans
        End Function

        Private Sub PersistOrderDetails(ByVal OrderId As String)
            ' Before proceeding with transaction processing, you should persist the order details.
            ' The details of the order that are generally persisted are:
            ' Credit card details : Card Number, Expiry date ( Card CVV2 number cannot be stored).
            ' Billing address details, shipping address details.
            ' Storing these details helps you to allow a returning customer to do a faster 
            ' checkout, having his/her details already populated in the desired fields.
            ' Storing the ordering details is generally uses database.
            ' Here, however for the demonstration purpose, this web application stores the order 
            ' details in a flat file named <order_id>.ord and retrieves it later. 
            ' Note that this is not a recommended method to persist order details.
            Try
                Response.SetCookie(New HttpCookie("OrderId", OrderId))
                Response.Cookies("OrderId").Expires = DateTime.Now.AddDays(1)
                Dim Encoder As Base64Encoder = New Base64Encoder
                Dim IOPerm As System.Security.Permissions.FileIOPermission = New System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, AppDomain.CurrentDomain.BaseDirectory + "orders")
                IOPerm.Demand()
                Dim OrderFile As FileInfo = New FileInfo(AppDomain.CurrentDomain.BaseDirectory + "orders\" + OrderId + ".ord")
                If (OrderFile.Exists) Then
                    OrderFile.Delete()
                End If
                Dim OrderWriter As StreamWriter = OrderFile.CreateText()
                OrderWriter.WriteLine("FirstName=" + txtFirstName.Text)
                OrderWriter.WriteLine("LastName=" + txtLastName.Text)
                OrderWriter.WriteLine("Street=" + txtStreet.Text)
                OrderWriter.WriteLine("City=" + txtCity.Text)
                OrderWriter.WriteLine("Zip=" + txtZip.Text)
                OrderWriter.WriteLine("State=" + txtState.Text)
                OrderWriter.WriteLine("ShipToFName=" + txtShipToFName.Text)
                OrderWriter.WriteLine("ShipToLName=" + txtShipToLName.Text)
                OrderWriter.WriteLine("ShipToStreet=" + txtShipToStreet.Text)
                OrderWriter.WriteLine("ShipToCity=" + txtShipToCity.Text)
                OrderWriter.WriteLine("ShipToZip=" + txtShipToZip.Text)
                OrderWriter.WriteLine("ShipToState=" + txtShipToState.Text)
                OrderWriter.WriteLine("Amount=" + "21.98")
                ' Example of how you might encrypt the credit card number should you decide to store it.
                OrderWriter.WriteLine("CCNumber=" + Encoder.Encrypt(txtCCNumber.Text))
                OrderWriter.WriteLine("ExpDate=" + ddExpMonth.SelectedValue + ddExpYear.SelectedValue)
                OrderWriter.WriteLine("PayMethod=" + "Credit Card")
                OrderWriter.Flush()
                OrderWriter.Close()
            Catch
                Dim Msg As String = "An error ocurred while trying to write the order details file. Please check permissions on the 'orders' folder."
                Response.Redirect("PurchaseComplete.aspx?auth=NO&msg=" + Msg, True)
            End Try
        End Sub


        Private Sub ShowStatusAndRedirect(ByVal Trans As BaseTransaction)
            Dim mSuccess As Boolean = False
            If Trans.Response.TransactionResponse.Result >= 0 Then
                mSuccess = True
            End If

            If Trans.Response.TransactionResponse.Result = 0 Then
                Response.Redirect("PurchaseComplete.aspx?auth=YES", True)
            Else
                Dim Message As String = "Your order cannot be completed at this time. "
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
                    Message += " Please check your credit card details."
                    ' Normally you wouldn't dislay the result code on your web page.  This is just for review.
                    MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString
                Else
                    ' A negative result code means there was an error thrown from the 
                    ' Payflow SDK for .NET. Pls make sure that your configurations is 
                    ' correct.
                    Message += "An internal error occurred."
                    MessageError = "Result code = " + Trans.Response.TransactionResponse.Result.ToString + ", RespMsg = " + Trans.Response.TransactionResponse.RespMsg.ToString
                End If
                Response.Redirect("PurchaseComplete.aspx?auth=NO&msg=" + HttpUtility.UrlEncode(Message) + "&msgError=" + HttpUtility.UrlEncode(MessageError), True)
            End If
        End Sub

        Private Function DoValidateAuthentication() As Response
            ' Validate authentication is the second step in processing the purchase 
            ' with buyer authentication. 
            ' When an enrolled user for buyer auth is redirected to his/her bank's secure server, 
            ' he/she auhthenticates him/her self using credentials.
            ' Based on credentials, the bank's secure server genrates a payer authentication response or 
            ' PaRes and sends the same back to the TermUrl (which should be your web application's URL 
            ' where you want to do further processing). The server also sends MD which is the merhcant data 
            ' sent by merchant for his/her tracking purpose. Here we're passing the Order Id of the 
            ' transaction as MD. We use this order id to retrieve the order details.

            ' Once obtain you need to send the PaRes to the VPS gateway to Validate the authentication.
            ' The gateway in turn will give the AUTHENTICATION_STATUS of the user in response.

            ' Read the data from request in binary format first.
            Dim ByteContent As Byte() = Request.BinaryRead(Request.ContentLength)

            ' Convert the binary content in to text content.
            Dim StrContent As String = HttpUtility.UrlDecode(System.Text.Encoding.UTF8.GetString(ByteContent))

            ' Obtain the value of PaRes.
            Dim Pares As String = PayflowUtility.LocateValueForName(StrContent, "PaRes", False)

            ' Obtain the value of MD.
            Session.Add("MD", PayflowUtility.LocateValueForName(StrContent, "MD", False))

            ' Create a Validate authentication transaction.
            Dim VaTrans As BuyerAuthVATransaction = New BuyerAuthVATransaction(Constants.PayflowBAUser, Constants.Connection, Pares, PayflowUtility.RequestId)

            ' Submit the transaction.
            VaTrans.SubmitTransaction()
            Return VaTrans.Response
        End Function

        Private Sub DoAuthorization(ByVal VaResp As Response)

            'Now that process of buyer auhtentication is complete, you can do the 
            'authorization which will put the charge on the customer's card.
            'Retrieve the transaction from persisted order details and create the transaction.

            Dim BAstatus As BuyerAuthStatus = New BuyerAuthStatus
            BAstatus.AuthenticationId = VaResp.BuyerAuthResponse.Authentication_Id
            BAstatus.AuthenticationStatus = VaResp.BuyerAuthResponse.Authentication_Status
            BAstatus.CAVV = VaResp.BuyerAuthResponse.CAVV
            BAstatus.ECI = VaResp.BuyerAuthResponse.ECI
            BAstatus.XID = VaResp.BuyerAuthResponse.XID
            Dim Trans As AuthorizationTransaction = PopulateTransaction(Session("MD"))
            Trans.BuyerAuthStatus = BAstatus

            ' submit the transaction.
            Dim RespAuth As Response = Trans.SubmitTransaction()
            ShowStatusAndRedirect(Trans)
        End Sub

        Public Sub RedirectBuyerAuthRequest(ByVal PayLoad As String, ByVal ACSUrl As String, ByVal mTransactionId As String)
            Dim myTermURL As String = Constants.LocalHostName + "/CreditCardDetails.aspx"
            System.Web.HttpContext.Current.Response.Clear()
            System.Web.HttpContext.Current.Response.Write("<html><head>")
            System.Web.HttpContext.Current.Response.Write(String.Format("</head><body onload=""document.{0}.submit()"">", "Form1"))
            'Get Form name, method from constants, and gateway URL from Web.Config
            System.Web.HttpContext.Current.Response.Write(String.Format("<form name=""{0}"" method=""{1}"" action=""{2}"" enctype=""{3}"">", "Form1", "POST", ACSUrl, "application/x-www-form-urlencoded"))
            System.Web.HttpContext.Current.Response.Write(String.Format("<input type='hidden' name='PaReq' value='" & PayLoad & "'>"))
            System.Web.HttpContext.Current.Response.Write(String.Format("<input type='hidden' name='TermUrl' value='" & myTermURL & "'>"))
            System.Web.HttpContext.Current.Response.Write(String.Format("<input type='hidden' name='MD' value='" & mTransactionId & "'>"))
            System.Web.HttpContext.Current.Response.Write("</form>")
            System.Web.HttpContext.Current.Response.Write("</body></html>")
            System.Web.HttpContext.Current.Response.End()
        End Sub

    End Class
End Namespace
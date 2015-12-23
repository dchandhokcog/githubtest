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
Imports System.IO
Imports PayPal.Payments.Common.Utility

Namespace eStoreFrontVB
    Public Class PurchaseComplete
        Inherits System.Web.UI.Page

        Protected lblPurchaseStatus As System.Web.UI.WebControls.Label
        Private mAuth As String
        Private mMessage As String
        Private mMessageError As String
        Protected WithEvents btnReturnToCart As System.Web.UI.WebControls.Button
        Protected lblGreetings As System.Web.UI.WebControls.Label
        Private mToken As String

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
            mAuth = Request.QueryString.Get("auth")
            mMessage = Request.QueryString.Get("msg")
            mMessageError = Request.QueryString.Get("msgError")
            mToken = Request.QueryString.Get("token")

            If String.Equals("NO", mAuth) Then
                lblPurchaseStatus.Text = mMessage + "<br><br>" + mMessageError + "<br><br>Click 'Return to Cart' to process a new transaction."
                lblGreetings.Text = "Sorry ..."
                btnReturnToCart.Visible = True
            ElseIf String.Equals("YES", mAuth) Then
                Dim OrderId As String = Request.Cookies("OrderId").Value
                Dim OrderReader As StreamReader = New StreamReader(AppDomain.CurrentDomain.BaseDirectory + "orders\" + OrderId + ".ord")
                Dim OrderTable As Hashtable = New Hashtable
                If Not String.Equals(OrderReader, "") Then
                    While (OrderReader.Peek() >= 0)
                        Dim CurrLine As String = OrderReader.ReadLine()
                        Dim SepIndex As Integer = CurrLine.IndexOf("=", 0)
                        Dim Name As String = CurrLine.Substring(0, SepIndex)
                        Dim Value As String = String.Empty
                        If (SepIndex < CurrLine.Length - 1) Then
                            Value = CurrLine.Substring(SepIndex + 1)
                        End If
                        OrderTable.Add(Name, Value)
                    End While
                    OrderReader.Close()
                End If
                lblGreetings.Text = "Thank you ..."
                lblPurchaseStatus.Text = "Your order is placed successfully. Order details as shown:"
                lblPurchaseStatus.Text += "<br><br><TABLE id='Table1' style='Z-INDEX: 103; LEFT: 72px; WIDTH: 488px;'"
                lblPurchaseStatus.Text += "cellSpacing='1' cellPadding='0' width='300' border='0' align='left'>"
                lblPurchaseStatus.Text += "<TR align='left'><TD><STRONG>Cart</STRONG></TD><TD><STRONG>Total</STRONG></TD></TR>"
                lblPurchaseStatus.Text += "<TR align='left'><TD>All Season Jacket. (Large)</TD><TD>19.99</TD></TR>"
                lblPurchaseStatus.Text += "<TR><TD>State Sales Tax</TD><TD>&nbsp; 1.99</TD></TR>"
                lblPurchaseStatus.Text += "<TR><TD><b>Order Total:</b></TD><TD>21.98</TD></TR></TABLE><br>"
                lblPurchaseStatus.Text += "<br><br><br><br><br><b>Payment Method:</b>		"
                lblPurchaseStatus.Text += OrderTable("PayMethod")

                If Not "PayPal".Equals(CType(OrderTable("PayMethod"), String)) Then
                    Dim Billing As String = "<br><br><br><b>Billing Address:</b><br>"
                    Billing += "<blockquote>" + OrderTable.Item("FirstName") + " " + OrderTable.Item("LastName") + "<br>"
                    Billing += OrderTable.Item("Street") + "<br>"
                    Billing += OrderTable.Item("City") + ", " + OrderTable.Item("State") + " " + OrderTable.Item("Zip")
                    Billing += "</blockquote>"
                    If Billing <> "" And Billing.Length > 0 And Not "<br><br><br><b>Billing Address:</b><br><blockquote> <br><br><br>, </blockquote>".Equals(Billing) Then
                        lblPurchaseStatus.Text += Billing
                    End If
                End If

                Dim Shipping As String = "<br><br><b>Shipping Address:</b><br>"
                Shipping += "<blockquote>" + OrderTable.Item("ShipToFName") + " " + OrderTable.Item("ShipToLName") + "<br>"
                Shipping += OrderTable.Item("ShipToStreet") + "<br>"
                Shipping += OrderTable.Item("ShipToStreet2") + "<br>"
                Shipping += OrderTable.Item("ShipToCity") + ", " + OrderTable.Item("ShipToState") + " " + OrderTable.Item("ShipToZip")
                Shipping += "</blockquote>"
                If (Shipping <> "" And Shipping.Length > 0 And Not "<br><br><b>Shipping Address:</b><br><blockquote> <br><br><br>, </blockquote>".Equals(Shipping)) Then
                    lblPurchaseStatus.Text += Shipping
                End If
            Else
                lblPurchaseStatus.Text = "Your order could not be completed at this time." + "<br>Clicking Return to Cart will restart the purchase."
                lblGreetings.Text = "Sorry ..."
            End If
            btnReturnToCart.Visible = True

        End Sub

        Private Sub btnReturnToCart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnToCart.Click
            Response.Redirect("PurchaseDescription.aspx", True)
        End Sub

    End Class
End Namespace
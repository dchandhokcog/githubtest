Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a simple Telecheck - Sale transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DOSale_Telecheck
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOSale_Telecheck.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(25.12))
            Inv.Amt = Amt
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details required for a teleCheck transaction.
            Dim Bill As BillTo = New BillTo
            Bill.Street = "123 Main St."
            Bill.Zip = "12345"
            Bill.City = "New York"
            Bill.State = "PA"
            Bill.Email = "ivan@test.com"

            Inv.BillTo = Bill

            ' Create a new Payment Device - Check Payment data object.
            ' The input parameters is MICR. Magnetic Ink Check Reader. This is the entire line
            ' of numbers at the bottom of all checks. It includes the transit number, account 
            ' number, and check number.
            Dim ChkPayment As CheckPayment = New CheckPayment("1234567804390850001001")

            ' Name property needs to be set for the Check Payment.
            ChkPayment.Name = "Ivan Smith"

            ' Create a new Tender - Check Tender data object.
            Dim ChkTender As CheckTender = New CheckTender(ChkPayment)
            ' Account holder�s next unused (available) check number. Up to 7 characters.
            ChkTender.ChkNum = "1234"
            
            ' DL or SS is required for a TeleCheck transaction.
            ' If CHKTYPE=P, a value for either DL or SS must be passed as an identifier.
						' If CHKTYPE=C, the Federal Tax ID must be passed as the SS value.
						ChkTender.ChkType = "P"
						
            ' Driver�s License number. If CHKTYPE=P, a value for either DL or SS must be passed as an identifier.
            ' Format: XXnnnnnnnn
            ' XX = State Code
            ' nnnnnnnn = DL Number - up to 31 characters.
            ChkTender.DL = "CAN85452345"
            
            ' Social Security number.
            'ChkTender.SS = "456765833"
            
            '/////////////////////////////////////////////////////////////////

            ' Create a new TeleCheck - Sale Transaction.
            Dim Trans As SaleTransaction = New SaleTransaction(User, Connection, Inv, ChkTender, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
                    Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
                    Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
                    Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
                End If

                ' Get the Fraud Response parameters.
                Dim FraudResp As FraudResponse = Resp.FraudResponse
                If Not FraudResp Is Nothing Then
                    Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
                    Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
                End If

                ' Display the response.
                Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp))

                ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                Dim TransCtx As Context = Resp.TransactionContext
                If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
                    Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
                End If
            End If

            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace
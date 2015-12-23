Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions


Namespace PayPal.Payments.Samples.VB.DataObjects.BasicTransactions
    ''' <summary>
    ''' This class uses the Payflow .NET SDK Data Objects to do a Sale transaction including some business rules.
    ''' This class depicts the use of the Data Objects which would normally be used in a transaction.
    ''' </summary>
    Public Class DOSaleCompleteVB
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args() As String)
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOSaleComplete.vb")
            Console.WriteLine("------------------------------------------------------")

            ' NOTE: All information regarding the available objects within payflow_dotNET.dll can be found in the API doc
            '       found under the "Docs" directory of the installed SDK.  You will also need to refer to the Website
            '		Payments Pro Payflow Edition or Payflow Pro Developer’s Guide found in the downloads section of PayPal
            '       Manager at https://manager.paypal.com.
            '
            ' Request ID: the request Id is a unique id that you send with your transaction data.  This Id if not changed
            ' will help prevent duplicate transactions.  The idea is to set this Id outside the loop or if on a page,
            ' prior to the final confirmation page.
            '
            ' Once the transaction is sent and if you don't receive a response you can resend the transaction and the 
            ' server will respond with the response data of the original submission.  Also, the object,
            ' Trans.Response.TransactionResponse.Duplicate will be set to "1" if the transaction is a duplicate.
            '
            ' This allows you to resend transaction requests should there be a network or user issue without re-charging
            ' a customers credit card.
            '
            ' Set the Request ID.
            ' Uncomment the line below and run two concurrent transactions to show how duplicate works.  You will notice on
            ' the second transaction that the response returned is identical to the first, but the duplicate object will be set.
            ' Dim strRequestID As [String] = "123456"
            ' Comment out this line if testing duplicate response.  
            Dim strRequestID As [String] = PayflowUtility.RequestId

            ' *** Create the Data Objects. ***
            '
            ' *** Create the User data object with the required user details. ***
            '         
            ' Should you choose to store the login information (Vendor, User, Partner and Password) in
            ' app.config, you can retrieve the data using PayflowUtility.AppSettings. 
            '
            ' For Example:
            '
            '      App.Config Entry: <add key="PayflowPartner" value="PayPal"/>
            '
            '      Dim mUser As String = PayflowUtility.AppSettings("PayflowUser")
            '      Dim mVendor As String = PayflowUtility.AppSettings("PayflowVendor")
            '      Dim mPartner As String = PayflowUtility.AppSettings("PayflowPartner")
            '      Dim mPassword As String = PayflowUtility.AppSettings("PayflowPassword")
            '
            '      Dim User As UserInfo = New UserInfo(mUser, mVendor, mPartner, mPassword)
            '
            ' Remember: <vendor> = your merchant (login id), <user> = <vendor> unless you created a separate <user> for Payflow Pro.
            ' Result code 26 will be issued if you do not provide both the <vendor> and <user> fields.

            ' The other most common error with authentication is result code 1, user authentication failed.  This is usually
            ' due to invalid account information or ip restriction on the account.  You can verify ip restriction by logging 
            ' into Manager.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' *** Create the Payflow Connection data object with the required connection details. ***
            '
            ' To allow the ability to change easily between the live and test servers, the PFPRO_HOST
            ' property is defined in the App.config (or web.config for a web site) file.  However,
            ' you can also pass these fields and others directly from the PayflowConnectionData constructor. 
            ' This will override the values passed in the App.config file.
            '
            ' For Example:
            '
            '      Example values passed below are as follows:
            '      Payflow Pro Host address : pilot-payflowpro.paypal.com 
            '      Payflow Pro Host Port : 443
            '      Timeout : 45 ( in seconds )
            '
            '      Dim Connection As New PayflowConnectionData("pilot-payflowpro.paypal.com", 443, 45, "",0,"","")
            '
            ' Obtain Host address from the app.config file and use default values for
            ' timeout and proxy settings.
            Dim Connection As New PayflowConnectionData

            ' *** Create a new Invoice data object ***
            ' Set Invoice object with the Amount, Billing & Shipping Address, etc. ***
            Dim Inv As New Invoice

            ' Set the amount object.
            ' Currency Code USD is US ISO currency code.  If no code passed, USD is default.
            ' See the Developer's Guide for the list of three-character currency codes available.
            Dim Amt As New Currency(New Decimal(25.25), "USD")

            ' A valid amount has either no decimal value or only a two decimal value. 
            ' An invalid amount will generate a result code 4.
            '
            ' For values which have more than two decimal places such as:
            ' Currency Amt = new Currency(new Decimal(25.1214))
            ' You will either need to truncate or round as needed using the following property: Amt.NoOfDecimalDigits
            '
            ' If the NoOfDecimalDigits property is used then it is mandatory to set one of the following
            ' properties to true.
            '
            'Amt.Round = True
            'Amt.Truncate = true
            '
            ' For Currencies without a decimal, you'll need to set the NoOfDecimalDigits = 0.
            'Amt.NoOfDecimalDigits = 2
            Inv.Amt = Amt

            ' PONum, InvNum and CustRef are sent to the processors and could show up on a customers
            ' or your bank statement. These fields are reportable but not searchable in PayPal Manager.
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"
            Inv.CustRef = "CustRef1"
            Inv.MerchDescr = "Merchant Descr"
            Inv.MerchSvc = "Merchant Svc"

            ' Comment1 and Comment2 fields are searchable within PayPal Manager .
            ' You may want to populate these fields with any of the above three fields or any other data.
            ' However, the search is a case-sensitive and is a non-wildcard search, so plan accordingly.
            Inv.Comment1 = "Comment1"
            Inv.Comment2 = "Comment2"

            Dim ln As New LineItem
            ln.ItemNumber = "1"
            ln.Desc = "Desc1"
            Dim lnAmt1 As New Currency(New Decimal(5.25), "USD")
            ln.Amt = lnAmt1
            Inv.AddLineItem(ln)
            ln.ItemNumber = "2"
            ln.Desc = "Desc2"
            Inv.AddLineItem(ln)
            Dim ln1 As New LineItem
            ln1.ItemNumber = "3"
            Inv.AddLineItem(ln1)


            ' There are additional Invoice parameters that could assist you in obtaining a better rate
            ' from your merchant bank.  Refer to the Payflow Pro Developer’s Guide
            ' and consult your Internet Merchant Bank on what parameters (if any) you can use.
            ' Some of the parameters could include:
            ' Inv.Recurring = "Y";
            ' Inv.TaxExempt = "Y";

            ' *** Set the Billing Address details. ***
            '
            ' The billing details below except for Street and Zip are for reporting purposes only. 
            ' It is suggested that you pass all the billing details for enhanced reporting and as data backup.

            ' Create the BillTo object.
            Dim Bill As New BillTo

            ' Set the customer name.
            Bill.FirstName = "Joe"
            ' Bill.MiddleName = "M";
            Bill.LastName = "Smith"
            Bill.CompanyName = "Joe's Hardware"

            ' It is highly suggested that you pass at minimum Street and Zip for AVS response.
            ' However, AVS is only supported by US banks and some foreign banks.  See the Payflow 
            ' Developer's Guide for more information.  Sending these fields could help in obtaining
            ' a lower discount rate from your Internet merchant Bank.  Consult your bank for more information.
            Bill.Street = "123 Main St."
            Bill.City = "San Jose"
            Bill.State = "CA"
            Bill.Zip = "12345"
            ' BillToCountry code is based on numeric ISO country codes. (e.g. 840 = USA)
            ' For more information, refer to the Payflow Developer's Guide.
            Bill.BillToCountry = "840"

            Bill.PhoneNum = "555-243-7689"
            ' Secondary phone numbers (could be mobile number etc).
            ' Bill.BillToPhone2 = "222-222-2222";
            ' Bill.HomePhone = "555-123-9867";
            ' Bill.Fax = "555-343-5444";
            Bill.Email = "Joe.Smith@anyemail.com"

            ' Set the BillTo object into invoice.
            Inv.BillTo = Bill

            ' Shipping details may not be necessary if providing a
            ' service or downloadable product such as software etc.
            '
            ' Set the Shipping Address details.
            ' The shipping details are for reporting purposes only. 
            ' It is suggested that you pass all the shipping details for enhanced reporting.
            '
            ' Create the ShipTo object.
            Dim Ship As New ShipTo

            ' To prevent an 'Address Mismatch' fraud trigger, we are shipping to the billing address.  However,
            ' shipping parameters are listed.
            ' Comment line below if you want a separate Ship To address.
            Ship = Bill.Copy()

            ' Uncomment statements below to send to separate Ship To address.
            ' Set the recipient's name.			
            ' Ship.ShipToFirstName = "Sam";
            ' Ship.ShipToMiddleName = "J";
            ' Ship.ShipToLastName = "Spade";
            ' Ship.ShipToStreet = "456 Shipping St.";
            ' Ship.ShipToStreet2 = "Apt A";
            ' Ship.ShipToCity = "Las Vegas";
            ' Ship.ShipToState = "NV";
            ' Ship.ShipToZip = "99999";
            ' ShipToCountry code is based on numeric ISO country codes. (e.g. 840 = USA)
            ' For more information, refer to the Payflow Pro Developer's Guide.
            ' Ship.ShipToCountry = "840";
            ' Ship.ShipToPhone = "555-123-1233";
            ' Secondary phone numbers (could be mobile number etc).
            ' Ship.ShipToPhone2 = "555-333-1222";
            ' Ship.ShipToEmail = "Sam.Spade@email.com";
            ' Ship.ShipFromZip = Bill.Zip;
            ' Following 2 items are just for reporting purposes and are not required.
            ' Ship.ShipCarrier = "UPS";
            ' Ship.ShipMethod = "Ground";
            Inv.ShipTo = Ship

            ' *** 	Create Customer Data ***
            ' There are additional CustomerInfo parameters that can be sent to assist in obtaining a better discount rate.
            ' Refer to the Website Payments Pro Payflow Edition Developer’s Guide and consult with your Internet
            ' Merchant Bank regarding what parameters to send.
            ' Some of the parameters could include:
            '
            Dim CustInfo As New CustomerInfo
            CustInfo.CustCode = "Cust123"
            CustInfo.CustId = "CustomerID"
            Inv.CustomerInfo = CustInfo

            ' *** Create a new Payment Device - Credit Card data object. ***
            ' The input parameters are Credit Card Number and Expiration Date of the Credit Card.
            ' Note: Expiration date is in the format MMYY.
            Dim CC As New CreditCard("5105105105105100", "1212")

            ' Example of Swipe Data
            ' See DOSwipe.vb example for more information.
            'Dim Swipe As New SwipeCard(";5105105105105100=15121011000012345678?")

            ' *** Card Security Code ***
            ' This is the 3 or 4 digit code on either side of the Credit Card.
            ' It is highly suggested that you obtain and pass this information to help prevent fraud.
            ' Sending this fields could help in obtaining a lower discount rate from your Internet merchant Bank.
            ' CVV2 is not required when performing a Swipe transaction as the card is present.
            CC.Cvv2 = "123"
            ' Name on Credit Card is optional.
            CC.Name = "Joe M Smith"

            ' *** Create a new Tender - Card Tender data object. ***
            Dim Card As New CardTender(CC)  ' credit card
            'Dim Card As New CardTender(Swipe) ' swipe card

            ' *** Create a new Sale Transaction. ***
            ' The Request Id is the unique id necessary for each transaction.  If you are performing an authorization
            ' - delayed capture transaction, make sure that you pass two different unique request ids for each of the
            ' transaction.
            ' If you pass a non-unique request id, you will receive the transaction details from the original request.
            ' The only difference is you will also receive a parameter DUPLICATE indicating this request id has been used
            ' before.
            ' The Request Id can be any unique number such order id, invoice number from your implementation or a random
            ' id can be generated using the PayflowUtility.RequestId.
            Dim Trans As New SaleTransaction(User, Connection, Inv, Card, strRequestID)

            ' Transaction results (especially values for declines and error conditions) returned by each PayPal-supported
            ' processor vary in detail level and in format. The Payflow Verbosity parameter enables you to control the kind
            ' and level of information you want returned. 

            ' By default, Verbosity is set to LOW. A LOW setting causes PayPal to normalize the transaction result values. 
            ' Normalizing the values limits them to a standardized set of values and simplifies the process of integrating 
            ' the Payflow SDK.

            ' By setting Verbosity to MEDIUM, you can view the processor’s raw response values. This setting is more “verbose”
            ' than the LOW setting in that it returns more detailed, processor-specific information. 

            '  Review the chapter in the Payflow Pro Developer's Guide regarding VERBOSITY and the INQUIRY function for more details.

            ' Set the transaction verbosity to MEDIUM.
            Trans.Verbosity = "MEDIUM"

            ' Submit the Transaction
            Dim Resp As Response = Trans.SubmitTransaction()

            ' Display the transaction response parameters.
            If Not (Resp Is Nothing) Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                Console.WriteLine(Resp.ResponseString)
                Console.WriteLine(Environment.NewLine)

                ' Refer to the Payflow Pro .NET API Reference Guide and the Payflow Pro (Website Payments Pro Payflow Edition)
                ' Developer's Guide  for explanation of the items returned and for additional information and parameters available.
                If Not (TrxnResponse Is Nothing) Then
                    Console.WriteLine("Transaction Response:")
                    Console.WriteLine(("Result Code (RESULT) = " + TrxnResponse.Result.ToString))
                    Console.WriteLine(("Transaction ID (PNREF) = " + TrxnResponse.Pnref))
                    Console.WriteLine(("Response Message (RESPMSG) = " + TrxnResponse.RespMsg))
                    Console.WriteLine(("Authorization (AUTHCODE) = " + TrxnResponse.AuthCode))
                    Console.WriteLine(("Street Address Match (AVSADDR) = " + TrxnResponse.AVSAddr))
                    Console.WriteLine(("Streep Zip Match (AVSZIP) = " + TrxnResponse.AVSZip))
                    Console.WriteLine(("International Card (IAVS) = " + TrxnResponse.IAVS))
                    Console.WriteLine(("CVV2 Match (CVV2MATCH) = " + TrxnResponse.CVV2Match))
                    Console.WriteLine("------------------------------------------------------")
                    Console.WriteLine("Verbosity Response:")
                    Console.WriteLine(("Processor AVS (PROCAVS) = " + TrxnResponse.ProcAVS))
                    Console.WriteLine(("Processor CSC (PROCCVV2) = " + TrxnResponse.ProcCVV2))
                End If

                ' Get the Fraud Response parameters.
                ' All trial accounts come with basic Fraud Protection Services enabled.
                ' Review the PayPal Manager guide to set up your Fraud Filters prior to 
                ' running this sample code.
                ' If Fraud Filters are not set, you will receive a RESULT code 126.
                Dim FraudResp As FraudResponse = Resp.FraudResponse
                If Not (FraudResp Is Nothing) Then
                    Console.WriteLine("------------------------------------------------------")
                    Console.WriteLine("Fraud Response:")
                    Console.WriteLine(("Pre-Filters (PREFPSMSG) = " + FraudResp.PreFpsMsg))
                    Console.WriteLine(("Post-Filters (POSTFPSMSG) = " + FraudResp.PostFpsMsg))
                End If

                ' Was this a duplicate transaction?
                ' If this value is true, then the original response of the original transaction will
                ' be returned.  The transaction type listed in Manager will be "N" and the Original
                ' Transaction ID will be the PNREF of the original transaction.  The value would be
                ' true if the Request ID of the Transaction Object has not been changed.
                Console.WriteLine("------------------------------------------------------")
                Console.WriteLine("Duplicate Response:")
                Dim DupMsg As String
                If (TrxnResponse.Duplicate = "1") Then
                    DupMsg = "Duplicate Transaction"
                Else
                    DupMsg = "Not a Duplicate Transaction"
                End If
                Console.WriteLine(("Duplicate Transaction (DUPLICATE) = " + DupMsg))

                ' Example of adding in business rules.  This is not an exhaustive list of failures or issues
                ' that could arise.  Review the list of Result Code's in the Developer's Guide and add logic as 
                ' you deem necessary.
                '
                ' These responses are just an example of what you can do and how you handle the response received
                ' from the bank is dependent on your business rules and needs.
                Dim RespMsg As String
                Select Case TrxnResponse.Result ' Evaluate Result Code

                    Case Is < 0  ' Transaction failed.
                        RespMsg = "There was an error processing your transaction.  Please contact Customer Service." + Environment.NewLine + "Error: " + TrxnResponse.Result.ToString
                    Case 1, 26
                        ' This is just checking for invalid login information.  You would not want to display this to your customers.
                        RespMsg = "Account configuration issue.  Please verify your login credentials."
                    Case 0
                        RespMsg = "Your transaction was approved.  Will ship in 24 hours."

                    Case 12 ' Hard decline from bank.
                        RespMsg = "Your transaction was declined."

                    Case 13 ' Voice authorization required.
                        RespMsg = "Your Transaction is pending. Contact Customer Service to complete your order."

                    Case 23, 24 ' Issue with credit card number or expiration date.
                        RespMsg = "Invalid credit card information.  Please re-enter."

                    Case 125 ' 125, 126 and 127 are Fraud Responses.
                        ' Refer to the Payflow Pro Fraud Protection Services User's Guide or Website Payments Pro Payflow Edition - Fraud Protection Services User's Guide.
                        RespMsg = "Your Transactions has been declined. Contact Customer Service."

                    Case 126
                        ' Decline transaction if AVS fails.
                        If (TrxnResponse.AVSAddr <> "Y" Or TrxnResponse.AVSZip <> "Y") Then
                            ' Display message that transaction was not accepted.  At this time, you
                            ' could display message that information is incorrect and redirect user 
                            ' to re-enter STREET and ZIP information.  However, there should be some sort of
                            ' 3 strikes your out check.
                            RespMsg = "Your billing information does not match.  Please re-enter."
                        Else
                            RespMsg = "Your Transaction is Under Review. We will notify you via e-mail if accepted."
                        End If

                    Case 127
                        RespMsg = "Your Transaction is Under Review. We will notify you via e-mail if accepted."

                    Case Else
                        ' Error occurred, display normalized message returned.
                        RespMsg = TrxnResponse.RespMsg

                End Select

                ' Display Message
                Console.WriteLine("------------------------------------------------------")
                Console.WriteLine("User/System Response:")
                Console.WriteLine("User Message (RESPMSG) = " + RespMsg)
                Console.WriteLine("System Message (TRXNRESPONSE.RESPMSG) = " + TrxnResponse.RespMsg)
            End If

            ' Display the status response of the transaction.
            ' This is just additional information and normally would not be used in production.
            ' Your business logic should be built around the result code returned as shown above.
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine(("Overall Transaction Status: " + PayflowUtility.GetStatus(Resp)))

            ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
            ' This is not normally used in production.
            Dim TransCtx As Context = Resp.TransactionContext
            If Not (TransCtx Is Nothing) And TransCtx.getErrorCount() > 0 Then
                Console.WriteLine("------------------------------------------------------")
                Console.WriteLine(("Transaction Context Errors: " + TransCtx.ToString()))
            End If
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace
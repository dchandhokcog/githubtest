<%@ LANGUAGE = VBScript %>
<% 
'
'  Classic ASP Client Integration Example using the Payflow Pro .NET SDK
'
'  This file must be used in conjunction with ASPCOMExample.htm.
'  Please copy both example files to a directory on your web server
'  the has script execute access.
'
'  You must install the Payflow Pro .NET assembly into GAC and register its types before you can
'  successfully run this example.  See the enclosed ReadMeCOM.txt file in the COM directory of the
'  .NET SDK.
'
'  This file shows the differences and the changes that will need to be completed to migrate from the 
'  v3 Win32 SDK Sample (ASPCOMExample.asp) to the new v4 .NET SDK.
'
'  All Original Items of the v3 SDK that have been commented out or replaced, begin with **.
'  The new line that replaces the older syntax is immediately following the original line.
'
'  For example:
'** This is the old line.
'  This is the new line.
'
'  New comments begin with !.
'  For example:
'! This is a new comment.
'
'
%>
<html>

<head>
<title>Payflow Pro .NET SDK - Classic ASP Test</title>
</head>

<body BGCOLOR="#FFFFFF">
<font FACE="ARIAL,HELVETICA"><%

'** Set client = Server.CreateObject("PFProCOMControl.PFProCOMControl.1")
'!  Create the PayflowNETAPI component
'!  Before this make sure that you have registered the types of Payflow_dotNET.dll 
'!  using regasm and the Payflow_dotNET.dll assembly is added to Global Assembly Cache (GAC)
'!  using gacutil.  See the enclosed ReadMeCOM.txt file for instructions.
Set client = Server.CreateObject("PayPal.Payments.Communication.PayflowNETAPI")

'!  No longer used.
'** client.DebugMode = "True"

'build the parameter list, such that we have a sale transaction and
'a credit card tender.
parmList = "TRXTYPE=S&TENDER=C&ZIP=12345&COMMENT1=Payflow Pro .NET Classic ASP Test Transaction"
'set the account form the html form
parmList = parmList + "&ACCT=" + request.form("cardNum") 
'set the password from the html form
parmList = parmList + "&PWD=" + request.form("password")
'set the user from the HTML form
parmList = parmList + "&USER=" + request.form("user")
'set the vendor from the HTML form
parmList = parmList + "&VENDOR=" + request.form("vendor")
'set the partner from the HTML form
parmList = parmList + "&PARTNER=" + request.form("partner")
'set the expiration date form the HTML form
parmList = parmList + "&EXPDATE=" + request.form("cardExp")
'set the amount from the HTML form
parmList = parmList + "&AMT=" + request.form("amount")

'! Set the connection params
'! Host address. (NEW HOST URLS USED)
'! The .NET SDK uses a different server for transactions.  The URLs are:
'! Test: pilot-payflowpro.paypal.com -- Live: payflowpro.paypal.com
'!
'! DO NOT use payflow.verisign.com or test-payflow.verisign.com!
'!
'! Specify whether exception trace is enabled or not. when ON, response will also have entire stack
'! trace of exception if any. Default is OFF. (NEW PARAMETER)
traceEnabled = "OFF"

'! DO NOT CHANGE THE LAST 4 ITEMS ON THE SET PARAMETERS LINE AS THEY ARE REQUIRED LEGACY PARAMS 
'! Call SetParameters to set the connection parameters with the format:
'! host, port, timeout, proxy address, proxy port, proxy user, proxy password, traceEnable, "", "", "", true
client.SetParameters  "pilot-payflowpro.paypal.com", 443, 30, "", 0, "", "", traceEnabled, "", "", "", true
'** Ctx1 = client.CreateContext("test-payflow.verisign.com", 443, 30, "", 0, "", "")

'! Submit the transaction
'! The SubmitTransaction object has been modified by removing the host and proxy information, you no longer need to 
'! pass the length of the parameter list sting and the request ID has been added.
'! Generate a request Id. (NEW REQUIRED FUNCTION)
'! The Request Id is the unique id necessary for each transaction.  If you are performing an authorization
'! - delayed capture transaction, make sure that you pass two different unique request ids for each of the
'! transaction.
'! If you pass a non-unique request id, you will receive the transaction details from the original request.
'! The only difference is you will also receive a parameter DUPLICATE indicating this request id has been used
'! before.
'! The Request Id can be any unique number such order id, invoice number from your implementation or a random
'! id can be generated using the GenerateRequestID object as shown below.
'** curString = client.SubmitTransaction(Ctx1, parmList, Len(parmList))
transResponse = client.SubmitTransaction(parmList,client.GenerateRequestId())


'Show the response
response.Write "<br><B>Transaction Response:</B><BR>"
showResponse(transResponse)

'! Destroy the client
'** client.DestroyContext (Ctx1)
set client = nothing

' handle the response
done = 0

function showResponse(curString)

'loop until we're done processing the entire string
Do while Len(curString) <> 0
	'get the next name value pair
	if InStr(curString,"&") Then
		varString = Left(curString, InStr(curString , "&" ) -1)
	else
		varString = curString
	end if
	Response.Write "<br>"
	'get the name part of the name/value pair
	name = Left(varString, InStr(varString, "=" ) -1)
	'get the value out of the name/value pair
	value = Right(varString, Len(varString) - (Len(name)+1))
	'write out the name/value pair in "name = value" format
	response.write name
	response.write " = "
	Response.Write value
	Response.Write "<br>"
	'skip over the &
	if Len(curString) <> Len(varString) Then 
		curString = Right(curString, Len(curString) - (Len(varString)+1))
	else
		curString = ""
	end if
Loop
end function
%>
</font>
</body>
</html>

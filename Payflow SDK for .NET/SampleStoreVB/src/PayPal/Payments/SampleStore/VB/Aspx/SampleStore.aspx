<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SampleStore.aspx.vb" Inherits="PayPal.Payments.SampleStore.VB.Aspx.SampleStore" %>
<!DOCTYPE html
PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML lang="EN">
	<HEAD>
		<title>PayPal .NET SDK VB Sample Store</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script type="text/javascript" language="Javascript">
                history.go (1);
		</script>
		<style type="text/css">
            .heading { FONT-SIZE: 24px; COLOR: black; FONT-FAMILY: Arial }
            .table { COLOR: black; FONT-FAMILY: Arial; align: center }
            .hr { FONT-WEIGHT: bold; FONT-SIZE: 40px; COLOR: black }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmSampleStore" method="post" runat="server">
			<table id="TblHeading" cellspacing="1" cellpadding="1" width="100%">
				<tr>
					<th valign="middle" align="center" class="heading">
						PayPal .NET SDK VB Sample Store</th>
					<td align="right">
						<asp:Image id="ImgPayPalLogo" runat="server" ImageUrl="../Images/paypal_logo.gif"></asp:Image></td>
				</tr>
				<tr>
					<td colspan="2"><FONT face="Arial" size="2">
							<hr class="hr">
							This sample is designed to be used to show all the available parameters that 
							can be passed.&nbsp; It is not designed to be used for code snippets for your 
							own application.&nbsp; It is suggested that you review the Console Samples 
							under SamplesCS or SamplesVB and use that code for a template in your 
							application. </FONT>
					</td>
				</tr>
			</table>
			<asp:Panel id="PnlSampleStoreForm" runat="server">
				<asp:table id="TblError" cellspacing="1" cellpadding="1" width="100%" Runat="server" Visible="False">
					<asp:TableRow>
						<asp:TableCell>
							<asp:label id="LblValidError" font-Bold="True" ForeColor="#000000" runat="server"></asp:label>
						</asp:TableCell>
						<asp:TableCell>
							<asp:label id="LblValidMsg" font-Bold="True" ForeColor="#ff0000" runat="server"></asp:label>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell ColumnSpan="2">
							<hr />
						</asp:TableCell>
					</asp:TableRow>
				</asp:table>
				<TABLE class="table" id="TblRequestGrid" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD align="left">
							<asp:label id="LblRequestType" runat="server">REQUEST TYPE</asp:label></TD>
						<TD align="left">
							<asp:dropdownlist id="CboRequestType" runat="server" AutoPostBack="True">
								<asp:ListItem Value="Name-Value Pair" Selected="True">Name-Value Pair</asp:ListItem>
								<asp:ListItem Value="XML Pay 2.0">XMLPay 2.0</asp:ListItem>
								<asp:ListItem Value="Strong Assembly - Data Objects">Object Based</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblWeakAssemblyRequest" runat="server">NAME-VALUE PAIR REQUEST</asp:label></TD>
						<TD align="left">
							<asp:textbox id="TxtBoxWeakAssemblyRequest" runat="server" MaxLength="1000" Columns="60" Rows="5"
								TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblRequestId" runat="server">X-VPS-Request-ID</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxRequestId" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Proxy Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblProxyAddress" runat="server">PROXYADDRESS</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxProxyAddress" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblProxyPort" runat="server">PROXYPORT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxProxyPort" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblProxyLogon" runat="server">PROXYLOGON</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxProxyLogon" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblProxyPassword" runat="server">PROXYPASSWORD</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxProxyPassword" runat="server" MaxLength="50" TextMode="Password"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>User Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblVendor" runat="server">VENDOR</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxVendor" runat="server" MaxLength="50">vendor</asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblUser" runat="server">USER</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxUser" runat="server" MaxLength="50">user</asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPartner" runat="server">PARTNER</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxPartner" runat="server" MaxLength="50">partner</asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPassword" runat="server">PASSWORD</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxPassword" runat="server" MaxLength="50" TextMode="Password">password</asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Tender Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblTender" runat="server">TENDER</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboTender" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="C">Credit Card</asp:ListItem>
								<asp:ListItem Value="A">ACH</asp:ListItem>
								<asp:ListItem Value="K">TeleCheck</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblChkNum" runat="server">CHKNUM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxChkNum" runat="server" MaxLength="8"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblChkType" runat="server">CHKTYPE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxChkType" runat="server" MaxLength="1"></asp:textbox></TD>
					</TR> <!--<tr>
							<td align="left">
								<asp:label id="LblBankName" runat="server">BANKNAME</asp:label></td>
							<td align="left" colspan="1" rowspan="1">
								<asp:textbox id="TxtBoxBankName" runat="server" MaxLength="50"></asp:textbox></td>
						</tr>
						<tr>
							<td align="left">
								<asp:label id="LblBankState" runat="server">BANKSTATE</asp:label></td>
							<td align="left" colspan="1" rowspan="1">
								<asp:textbox id="TxtBoxBankState" runat="server" MaxLength="2"></asp:textbox></td>
						</tr>
						<tr>
							<td align="left">
								<asp:label id="LblConsentMedium" runat="server">CONSENTMEDIUM</asp:label></td>
							<td align="left" colspan="1" rowspan="1">
								<asp:textbox id="TxtBoxConsentMedium" runat="server" MaxLength="10"></asp:textbox></td>
						</tr>
						<tr>
							<td align="left">
								<asp:label id="LblCustomerType" runat="server">CUSTOMERTYPE</asp:label></td>
							<td align="left" colspan="1" rowspan="1">
								<asp:textbox id="TxtBoxCustomerType" runat="server" MaxLength="10"></asp:textbox></td>
						</tr>
						<tr>
							<td align="left">
								<asp:label id="LblDLState" runat="server">DLSTATE</asp:label></td>
							<td align="left" colspan="1" rowspan="1">
								<asp:textbox id="TxtBoxDLState" runat="server" MaxLength="2"></asp:textbox></td>
						</tr>-->
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Transaction Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblOrigId" runat="server">ORIGID</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxOrigId" runat="server" MaxLength="12"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblTrxType" runat="server">TRXTYPE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboTrxType" runat="server">
								<asp:ListItem Value="S" Selected="True">Sale</asp:ListItem>
								<asp:ListItem Value="A">Authorization</asp:ListItem>
								<asp:ListItem Value="D">Capture</asp:ListItem>
								<asp:ListItem Value="C">Credit</asp:ListItem>
								<asp:ListItem Value="I">Inquiry</asp:ListItem>
								<asp:ListItem Value="F">Voice Authorization</asp:ListItem>
								<asp:ListItem Value="R">Recurring</asp:ListItem>
								<asp:ListItem Value="V">Void</asp:ListItem>
								<asp:ListItem Value="U">RMS Review</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR> <!--
						<tr>
						<td align="left">
							<asp:label id="LblBuyerAuthenticationRequired" runat="server">BUYER AUTHENTICATION REQUIRED</asp:label></td>
						<td align="left" colspan="1" rowspan="1">
							<asp:DropDownList id="CboBuyerAuthenticationRequired" runat="server">
								<asp:ListItem Value=""></asp:ListItem>
								<asp:ListItem Value="Y">Yes</asp:ListItem>
								<asp:ListItem Value="N">No</asp:ListItem>
							</asp:DropDownList></td>
					</tr>
	-->
					<TR>
						<TD align="left">
							<asp:label id="LblAmt" runat="server">AMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCurrency" runat="server">CURRENCY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboCurrency" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="USD">US Dollars</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblAuthCode" runat="server">AUTHCODE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxAuthCode" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblSwipe" runat="server">SWIPE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxSwipe" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Credit Card Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblAcct" runat="server">ACCT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxAcct" runat="server" MaxLength="19"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblExpDate" runat="server">EXPDATE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboExpiryMonth" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="01">January</asp:ListItem>
								<asp:ListItem Value="02">February</asp:ListItem>
								<asp:ListItem Value="03">March</asp:ListItem>
								<asp:ListItem Value="04">April</asp:ListItem>
								<asp:ListItem Value="05">May</asp:ListItem>
								<asp:ListItem Value="06">June</asp:ListItem>
								<asp:ListItem Value="07">July</asp:ListItem>
								<asp:ListItem Value="08">August</asp:ListItem>
								<asp:ListItem Value="09">September</asp:ListItem>
								<asp:ListItem Value="10">October</asp:ListItem>
								<asp:ListItem Value="11">November</asp:ListItem>
								<asp:ListItem Value="12">December</asp:ListItem>
							</asp:dropdownlist>
							<asp:dropdownlist id="CboExpiryYear" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="2006">2006</asp:ListItem>
								<asp:ListItem Value="2007">2007</asp:ListItem>
								<asp:ListItem Value="2008">2008</asp:ListItem>
								<asp:ListItem Value="2009">2009</asp:ListItem>
								<asp:ListItem Value="2010">2010</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCvv2" runat="server">CVV2 (CARD SECURITY CODE)</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCvv2" runat="server" MaxLength="4"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblVerbosity" runat="server">VERBOSITY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboVerbosity" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="HIGH">High</asp:ListItem>
								<asp:ListItem Value="MEDIUM">Medium</asp:ListItem>
								<asp:ListItem Value="LOW">Low</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>ACH Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblAba" runat="server">ABA</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxAba" runat="server" MaxLength="9"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblAcctType" runat="server">ACCTTYPE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboAcctType" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="C">Checking</asp:ListItem>
								<asp:ListItem Value="S">Saving</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblAuthType" runat="server">AUTHTYPE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboAuthType" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="TEL">TEL</asp:ListItem>
								<asp:ListItem Value="POP">POP</asp:ListItem>
								<asp:ListItem Value="ARC">ARC</asp:ListItem>
								<asp:ListItem Value="RCK">RCK</asp:ListItem>
								<asp:ListItem Value="WEB">WEB</asp:ListItem>
								<asp:ListItem Value="CCD">CCD</asp:ListItem>
								<asp:ListItem Value="PPD">PPD</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPrenote" runat="server">PRENOTE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboPrenote" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="Y">Yes</asp:ListItem>
								<asp:ListItem Value="N">No</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblTermCity" runat="server">TERMCITY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxTermCity" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblTermState" runat="server">TERMSTATE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxTermState" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>TeleCheck Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblMicr" runat="server">MICR</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxMicr" runat="server" MaxLength="35"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDL" runat="server">DL</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDL" runat="server" MaxLength="35"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblSS" runat="server">SS</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxSS" runat="server" MaxLength="35"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Card Holder's Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblName" runat="server">NAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxName" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Customer's Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCompanyName" runat="server">COMPANYNAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCompanyName" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCustCode" runat="server">CUSTCODE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCustCode" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCustRef" runat="server">CUSTREF</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCustRef" runat="server" MaxLength="12"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblFax" runat="server">FAX</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxFax" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblHomePhone" runat="server">HOMEPHONE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxHomePhone" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDob" runat="server">DOB(mmddyyyy)</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDob" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCustIp" runat="server">CUSTIP</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCustIp" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCorpName" runat="server">CORPNAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCorpName" runat="server" MaxLength="40"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblSsn" runat="server">SSN</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxSsn" runat="server" MaxLength="35"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCustId" runat="server">CUSTID</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCustId" runat="server" MaxLength="200"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCustVatRegNum" runat="server">CUSTVATREGNUM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCustVatRegNum" runat="server" MaxLength="13"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblMerchDescr" runat="server">MERCHDESCR</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxMerchDescr" runat="server" MaxLength="22"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblMerchSvc" runat="server">MERCHSVC</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxMerchSvc" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblReqName" runat="server">REQNAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxReqname" runat="server" MaxLength="40"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Billing Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblFirstName" runat="server">FIRSTNAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxFirstName" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblMiddleName" runat="server">MIDDLENAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxMiddleName" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLastName" runat="server">LASTNAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxLastName" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblStreet" runat="server">STREET</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxStreet" runat="server" MaxLength="150"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblBillToStreet2" runat="server">BILLTOSTREET2</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxBillToStreet2" runat="server" MaxLength="150"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCity" runat="server">CITY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCity" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblState" runat="server">STATE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxState" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCountry" runat="server">BILLTOCOUNTRY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCountry" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblZip" runat="server">ZIP</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxZip" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblEmail" runat="server">EMAIL</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxEmail" runat="server" MaxLength="60"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblBillToPhone2" runat="server">BILLTOPHONE2</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxBillToPhone2" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPhoneNum" runat="server">PHONENUM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxPhoneNum" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblBillHomePhone" runat="server">HOMEPHONE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxBillHomePhone" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Shipping Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToFirstName" runat="server">SHIPTOFIRSTNAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToFirstName" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToMiddleName" runat="server">SHIPTOMIDDLENAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToMiddleName" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToLastName" runat="server">SHIPTOLASTNAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToLastName" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToStreet" runat="server">SHIPTOSTREET</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToStreet" runat="server" MaxLength="150"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToStreet2" runat="server">SHIPTOSTREET2</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToStreet2" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToCity" runat="server">SHIPTOCITY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToCity" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToState" runat="server">SHIPTOSTATE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToState" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToCountry" runat="server">SHIPTOCOUNTRY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToCountry" runat="server" MaxLength="4"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToZip" runat="server">SHIPTOZIP</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToZip" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToEmail" runat="server">SHIPTOEMAIL</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToEmail" runat="server" MaxLength="120"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipFromzip" runat="server">SHIPFROMZIP</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipFromzip" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToPhone" runat="server">SHIPTOPHONE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToPhone" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipToPhone2" runat="server">SHIPTOPHONE2</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipToPhone2" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipCarrier" runat="server">SHIPCARRIER</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipCarrier" runat="server" MaxLength="200"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblShipMethod" runat="server">SHIPMETHOD</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxShipMethod" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Invoice Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblFreightAmt" runat="server">FREIGHTAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxFreightAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDutyAmt" runat="server">DUTYAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDutyAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR> <!--					<tr>
							<td align="left"><asp:label id="LblBuyerAuthStatus" runat="server">BUYERAUTHSTATUS</asp:label></td>
							<td align="left" colspan="1" rowspan="1"><asp:textbox id="TxtBoxBuyerAuthStatus" runat="server" MaxLength="50"></asp:textbox></td>
						</tr>
-->
					<TR>
						<TD align="left">
							<asp:label id="LblComment1" runat="server">COMMENT1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxComment1" runat="server" MaxLength="255"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblComment2" runat="server">COMMENT2</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxComment2" runat="server" MaxLength="255"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDesc" runat="server">DESC</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDesc" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDesc1" runat="server">DESC1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDesc1" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDesc2" runat="server">DESC2</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDesc2" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDesc3" runat="server">DESC3</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDesc3" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDesc4" runat="server">DESC4</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDesc4" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblOrderDate" runat="server">ORDERDATE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxOrderDate" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblOrderTime" runat="server">ORDERTIME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxOrderTime" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblDiscount" runat="server">DISCOUNT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxDiscount" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblHandlingAmt" runat="server">HANDLINGAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxHandlingAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblInvNum" runat="server">INVNUM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxInvNum" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblInvoiceDate" runat="server">INVOICEDATE(yyyymmdd)</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxInvoiceDate" runat="server" MaxLength="8"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPoNum" runat="server">PONUM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxPoNum" runat="server" MaxLength="40"></asp:textbox></TD>
					</TR> <!--						<tr>
							<td align="left"><asp:label id="LblRecurring" runat="server">RECURRING</asp:label></td>
							<td align="left" colspan="1" rowspan="1"><asp:dropdownlist id="CboRecurring" runat="server">
									<asp:ListItem Value="" Selected="True"></asp:ListItem>
									<asp:ListItem Value="Y">Yes</asp:ListItem>
									<asp:ListItem Value="N">No</asp:ListItem>
								</asp:dropdownlist></td>
						</tr>
						-->
					<TR>
						<TD align="left">
							<asp:label id="LblStartTime" runat="server">STARTTIME(yyyymmddhhmmss)</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxStartTime" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblEndTime" runat="server">ENDTIME(yyyymmddhhmmss)</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxEndTime" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblTaxExempt" runat="server">TAXEXEMPT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboTaxExempt" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="Y">Yes</asp:ListItem>
								<asp:ListItem Value="N">No</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblTaxAmt" runat="server">TAXAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxTaxAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLocalTaxAmt" runat="server">LOCALTAXAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxLocalTaxAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblNationalTaxAmt" runat="server">NATIONALTAXAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxNationalTaxAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblAltTaxAmt" runat="server">ALTTAXAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxAltTaxAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblVaTaxPercent" runat="server">VATAXPERCENT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxVaTaxPercent" runat="server" MaxLength="6"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblVatTaxAmt" runat="server">VATTAXAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxVatTaxAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblVatRegNum" runat="server">VATREGNUM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxVatRegNum" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblCommCode" runat="server">COMMCODE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxCommCode" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Browser Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblBrowserCountryCode" runat="server">BROWSERCOUNTRYCODE</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxBrowserCountryCode" runat="server" MaxLength="3"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblBrowserTime" runat="server">BROWSERTIME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxBrowserTime" runat="server" MaxLength="40"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblBrowserUserAgent" runat="server">BROWSERUSERAGENT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxBrowserUserAgent" runat="server" MaxLength="255"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Recurring Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblAction" runat="server">ACTION</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboAction" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="A">Add</asp:ListItem>
								<asp:ListItem Value="M">Modify</asp:ListItem>
								<asp:ListItem Value="C">Cancel</asp:ListItem>
								<asp:ListItem Value="R">Reactivate</asp:ListItem>
								<asp:ListItem Value="I">Inquiry</asp:ListItem>
								<asp:ListItem Value="P">Payment</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPaymentHistory" runat="server">PAYMENT HISTORY</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboPaymentHistory" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="Y">Yes</asp:ListItem>
								<asp:ListItem Value="N">No</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblProfileName" runat="server">PROFILENAME</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxProfileName" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblStart" runat="server">START(MMDDYYYY)</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxStart" runat="server" MaxLength="8"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblTerm" runat="server">TERM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxTerm" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPayPeriod" runat="server">PAYPERIOD</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboPayPeriod" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="WEEK">Weekly</asp:ListItem>
								<asp:ListItem Value="BIWK">Every Two Weeks</asp:ListItem>
								<asp:ListItem Value="SMMO">Twice Every Month</asp:ListItem>
								<asp:ListItem Value="FRWK">Every Four Weeks</asp:ListItem>
								<asp:ListItem Value="MONT">Monthly</asp:ListItem>
								<asp:ListItem Value="QTER">Quaterly</asp:ListItem>
								<asp:ListItem Value="SMYR">Twice Every Year</asp:ListItem>
								<asp:ListItem Value="YEAR">Yearly</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblRetryNumDays" runat="server">RETRYNUMDAYS</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxRetryNumDays" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblPaymentNum" runat="server">PAYMENTNUM</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxPaymentNum" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblMaxFailPayments" runat="server">MAXFAILPAYMENTS</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxMaxFailPayments" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblOptionalTrxType" runat="server">OPTIONALTRX</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboOptionalTrxType" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="S">Sale</asp:ListItem>
								<asp:ListItem Value="A">Authorization</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblOptionalTrxAmt" runat="server">OPTIONALTRXAMT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxOptionalTrxAmt" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblOrigProfileId" runat="server">ORIGPROFILEID</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxOrigProfileId" runat="server" MaxLength="12"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Review Fraud Transaction</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblRMSAction" runat="server">UPDATEACTION</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:dropdownlist id="CboUpdateAction" runat="server">
								<asp:ListItem Value="" Selected="True"></asp:ListItem>
								<asp:ListItem Value="RMS_APPROVE">Approve</asp:ListItem>
								<asp:ListItem Value="RMS_MERCHANT_DECLINE">Merchant Decline</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Line Item Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLAmt0" runat="server">L_AMT0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Amt0" runat="server" MaxLength="18"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCost0" runat="server">L_COST0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Cost0" runat="server" MaxLength="18"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLDesc0" runat="server">L_DESC0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Desc0" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLDiscount0" runat="server">L_DISCOUNT0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Discount0" runat="server" MaxLength="18"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLManufacturer0" runat="server">L_MANUFACTURER0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Manufacturer0" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLProdCode0" runat="server">L_PRODCODE0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_ProdCode0" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLQty0" runat="server">L_QTY0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Qty0" runat="server" MaxLength="9"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLSku0" runat="server">L_SKU0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Sku0" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTaxAmt0" runat="server">L_TAXAMT0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TaxAmt0" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTaxRate0" runat="server">L_TAXRATE0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TaxRate0" runat="server" MaxLength="6"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTaxType0" runat="server">L_TAXTYPE0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TaxType0" runat="server" MaxLength="4"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLType0" runat="server">L_TYPE0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Type0" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLUom0" runat="server">L_UOM0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Uom0" runat="server" MaxLength="3"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLUpc0" runat="server">L_UPC0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Upc0" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCommCode0" runat="server">L_COMMCODE0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Commcode0" runat="server" MaxLength="12"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLFreightAmt0" runat="server">L_FREIGHTAMT0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_FreightAmt0" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLHandlingAmt0" runat="server">L_HANDLINGAMT0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_HandlingAmt0" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTrackingNum0" runat="server">L_TRACKINGNUM0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TrackingNum0" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupStreet0" runat="server">L_PICKUPSTREET0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Pickupstreet0" runat="server" MaxLength="150"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupCity0" runat="server">L_PICKUPCITY0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Pickupcity0" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupState0" runat="server">L_PICKUPSTATE0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Pickupstate0" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupZip0" runat="server">L_PICKUPZIP0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_PickupZip0" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupCountry0" runat="server">L_PICKUPCOUNTRY0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_PickupCountry0" runat="server" MaxLength="4"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLUnspscCode0" runat="server">L_UNSPSCCODE0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_UnspscCode0" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCostcenterNum0" runat="server">L_COSTCENTERNUM0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_CostcenterNum0" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCatalogNum0" runat="server">L_CATALOGNUM0</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_CatalogNum0" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">&nbsp;</TD>
						<TD align="left"></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLAmt1" runat="server">L_AMT1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Amt1" runat="server" MaxLength="18"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCost1" runat="server">L_COST1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Cost1" runat="server" MaxLength="18"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLDesc1" runat="server">L_DESC1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Desc1" runat="server" MaxLength="80"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLDiscount1" runat="server">L_DISCOUNT1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Discount1" runat="server" MaxLength="18"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLManufacturer1" runat="server">L_MANUFACTURER1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Manufacturer1" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLProdCode1" runat="server">L_PRODCODE1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_ProdCode1" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLQty1" runat="server">L_QTY1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Qty1" runat="server" MaxLength="9"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLSku1" runat="server">L_SKU1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Sku1" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTaxAmt1" runat="server">L_TAXAMT1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TaxAmt1" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTaxRate1" runat="server">L_TAXRATE1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TaxRate1" runat="server" MaxLength="6"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTaxType1" runat="server">L_TAXTYPE1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TaxType1" runat="server" MaxLength="4"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLType1" runat="server">L_TYPE1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Type1" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLUom1" runat="server">L_UOM1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Uom1" runat="server" MaxLength="3"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLUpc1" runat="server">L_UPC1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Upc1" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCommCode1" runat="server">L_COMMCODE1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Commcode1" runat="server" MaxLength="12"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLFreightAmt1" runat="server">L_FREIGHTAMT1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_FreightAmt1" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLHandlingAmt1" runat="server">L_HANDLINGAMT1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_HandlingAmt1" runat="server" MaxLength="15"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLTrackingNum1" runat="server">L_TRACKINGNUM1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_TrackingNum1" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupStreet1" runat="server">L_PICKUPSTREET1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Pickupstreet1" runat="server" MaxLength="150"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupCity1" runat="server">L_PICKUPCITY1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Pickupcity1" runat="server" MaxLength="100"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupState1" runat="server">L_PICKUPSTATE1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_Pickupstate1" runat="server" MaxLength="45"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupZip1" runat="server">L_PICKUPZIP1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_PickupZip1" runat="server" MaxLength="10"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLPickupCountry1" runat="server">L_PICKUPCOUNTRY1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_PickupCountry1" runat="server" MaxLength="4"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLUnspscCode1" runat="server">L_UNSPSCCODE1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_UnspscCode1" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCostcenterNum1" runat="server">L_COSTCENTERNUM1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_CostcenterNum1" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblLCatalogNum1" runat="server">L_CATALOGNUM1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_CatalogNum1" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="Label1" runat="server">L_COSTCENTERNUM38</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_CostcenterNum38" runat="server" MaxLength="30"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="Label2" runat="server">L_CATALOGNUM101</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxL_CatalogNum101" runat="server" MaxLength="20"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Extended Data Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblExtendField1" runat="server">EXTENDFIELD1</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxExtend_Field1" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblExtendField2" runat="server">EXTENDFIELD2</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxExtend_Field2" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><B>Version Information Tracking Information</B></TD>
					</TR>
					<TR>
						<TD align="left">
						<TD align="left" colSpan="1" rowSpan="1"></TD>
					<TR>
						<TD align="left">
							<asp:label id="LblVITIntegrationProduct" runat="server">PAYFLOW-INTEGRATION-PRODUCT</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxVITIntegrationProduct" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left">
							<asp:label id="LblVITIntegrationVersion" runat="server">PAYFLOW-INTEGRATION-VERSION</asp:label></TD>
						<TD align="left" colSpan="1" rowSpan="1">
							<asp:textbox id="TxtBoxVITIntegrationVersion" runat="server" MaxLength="50"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<HR class="hr">
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:button id="BtnSubmitTransaction" runat="server" Text="Submit Transaction"></asp:button>
							<asp:button id="BtnReset" runat="server" Text="Reset Form"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<table width="100%">
				<tr>
					<td style="WIDTH: 203px">
						<asp:Label id="LblStatus" runat="server" Visible="False" font-Bold="True">Status</asp:Label></td>
					<td>
						<asp:Label id="LblStatusResponse" runat="server" Visible="False" font-Bold="True" ForeColor="Black"
							Width="392px"></asp:Label></td>
				</tr>
			</table>
			<asp:panel id="PnlStrongAssemblyResponse" runat="server">
				<TABLE width="100%">
					<TR>
						<TD>
							<asp:datagrid id="TransactionDataGrid" runat="server" AutoGenerateColumns="false">
								<Columns>
									<asp:TemplateColumn HeaderStyle-Width="200" HeaderStyle-font-Bold="True" HeaderText="Transaction Response Field">
										<ItemTemplate>
											<asp:label ID="LblTransactionKey" Runat="server" text='<%# Container.DataItem.Key %>'/>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-font-Bold="True" HeaderText="Transaction Response Value" ItemStyle-Width="400">
										<ItemTemplate>
											<asp:label ID="LblTransactionValue" Runat="server" text='<%# Container.DataItem.Value %>'/>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:datagrid id="RecurringDataGrid" runat="server" AutoGenerateColumns="false">
								<Columns>
									<asp:TemplateColumn HeaderStyle-Width="200" HeaderStyle-font-Bold="True" HeaderText="Recurring Response Field">
										<ItemTemplate>
											<asp:label ID="LblRecurringKey" Runat="server" text='<%# Container.DataItem.Key %>'/>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-font-Bold="True" HeaderText="Recurring Response Value">
										<ItemTemplate>
											<asp:label ID="LblRecurringValue" Runat="server" text='<%# Container.DataItem.Value %>'/>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
							<asp:Button id="BtnFollowOnRecurring" runat="server" Visible="False" Text="Perform Recurring Follow-On Transaction"></asp:Button></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:datagrid id="FraudDataGrid" runat="server" AutoGenerateColumns="false">
								<Columns>
									<asp:TemplateColumn HeaderStyle-Width="200" HeaderStyle-font-Bold="True" HeaderText="Fraud Response Field">
										<ItemTemplate>
											<asp:label ID="LblFraudKey" Runat="server" text='<%# Container.DataItem.Key %>'/>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Font-Bold="True" HeaderText="Fraud Response Value">
										<ItemTemplate>
											<asp:label ID="LblFraudValue" Runat="server" text='<%# Container.DataItem.Value %>'/>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<asp:Button id="BtnFollowOnTransaction" runat="server" Visible="False" Text="Perform Follow-On Transaction"></asp:Button>
						<asp:Button id="BtnStrongBack" runat="server" Text="Back"></asp:Button></TR>
				</TABLE>
			</asp:panel><asp:panel id="PnlWeakAssemblyResponse" Runat="server">
				<TABLE width="100%">
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="LblHeader" runat="server">Response Obtained from the Payflow  Server :</asp:Label></TD>
					</TR>
					<TR>
						<TD>
							<asp:TextBox id="TxtBoxWeakAssemblyResponse" runat="server" Columns="60" Rows="5" TextMode="MultiLine"
								Width="592px" BorderStyle="None" Height="176px"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:Button id="BtnWeakAssemblyFollowOn" runat="server" Visible="False" Text="Back"></asp:Button></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:Panel id="PnlContextError" Runat="server">
				<TABLE width="100%">
					<TR>
						<TD>
							<asp:datagrid id="ContextDataGrid" runat="server" AutoGenerateColumns="false">
								<Columns>
									<asp:TemplateColumn HeaderStyle-font-Bold="True" HeaderText="Error Message">
										<ItemTemplate>
											<asp:label ID="LblErrorMessage" Runat="server" text='<%# Container.DataItem.Value %>'/>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
							<asp:Button id="BtnBack" runat="server" Visible="False" Text="Back"></asp:Button></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
	</body>
</HTML>

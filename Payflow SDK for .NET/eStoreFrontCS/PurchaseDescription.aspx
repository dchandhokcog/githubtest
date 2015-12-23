<%@ Page language="c#" Codebehind="PurchaseDescription.aspx.cs" AutoEventWireup="false" Inherits="eStoreFrontCS.PurchaseDescription" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Your Cart Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body bgColor="#ffffff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server"></TD>&nbsp; <!-- PayPal Logo -->
			<DIV style="DISPLAY: inline; FONT-WEIGHT: normal; FONT-SIZE: medium; Z-INDEX: 101; LEFT: 72px; WIDTH: 232px; BORDER-TOP-STYLE: none; FONT-FAMILY: Verdana; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: absolute; TOP: 248px; HEIGHT: 8px; BORDER-BOTTOM-STYLE: none"
				align="left" ms_positioning="FlowLayout">Payment Method</DIV>
			<HR style="Z-INDEX: 106; LEFT: 72px; POSITION: absolute; TOP: 344px; HEIGHT: 8px; BACKGROUND-COLOR: #146690"
				align="left" width="92%" SIZE="1">
			&nbsp;&nbsp;&nbsp;
			<DIV style="DISPLAY: inline; FONT-WEIGHT: normal; FONT-SIZE: medium; Z-INDEX: 102; LEFT: 72px; WIDTH: 320px; BORDER-TOP-STYLE: none; FONT-FAMILY: Verdana; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: absolute; TOP: 56px; HEIGHT: 24px; BORDER-BOTTOM-STYLE: none"
				align="left" ms_positioning="FlowLayout">Purchase Description</DIV>
			<HR style="Z-INDEX: 103; LEFT: 72px; POSITION: absolute; TOP: 88px; HEIGHT: 8px; BACKGROUND-COLOR: #146690"
				align="left" width="92%" SIZE="8">
			<HR style="Z-INDEX: 104; LEFT: 72px; POSITION: absolute; TOP: 280px; HEIGHT: 8px; BACKGROUND-COLOR: #146690"
				align="left" width="92%" SIZE="1">
			<asp:label id="lblContinue" style="Z-INDEX: 105; LEFT: 72px; POSITION: absolute; TOP: 368px"
				runat="server" Height="64px" Width="744px" Font-Names="Verdana" Font-Italic="True" Font-Size="Smaller"></asp:label>
			<asp:Button id="btnContinue" style="Z-INDEX: 107; LEFT: 64px; POSITION: absolute; TOP: 432px"
				runat="server" Font-Names="Verdana" Height="32px" Width="120px" Text="Continue" tabIndex="3"></asp:Button>
			<img alt="Visa Mastercard Logos" title="Visa Mastercard Logos" src="img/CreditCardLogo.gif"
				width="148" height="32" border="0" style="Z-INDEX: 108; LEFT: 144px; POSITION: absolute; TOP: 304px"></A>&nbsp;
			<img alt="Express Checkout Logo" title="Express Checkout logo" src="img/paypal_logo.gif"
				height="32" border="0" style="Z-INDEX: 109; LEFT: 496px; POSITION: absolute; TOP: 304px">&nbsp;
			<DIV style="DISPLAY: inline; FONT-SIZE: 11px; Z-INDEX: 110; LEFT: 576px; WIDTH: 248px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 304px; HEIGHT: 32px"
				align="left" ms_positioning="FlowLayout">Save time. Checkout securely. Pay 
				without sharing your financial information.</DIV>
			<asp:RadioButton id="rdoCreditCard" style="Z-INDEX: 111; LEFT: 104px; POSITION: absolute; TOP: 312px"
				runat="server" AutoPostBack="True" GroupName="PaymentMethod" tabIndex="1" />
			<asp:RadioButton id="rdoPaypal" style="Z-INDEX: 112; LEFT: 448px; POSITION: absolute; TOP: 312px"
				runat="server" AutoPostBack="True" GroupName="PaymentMethod" tabIndex="2" />
			<TABLE id="Table1" style="Z-INDEX: 113; LEFT: 72px; WIDTH: 488px; POSITION: absolute; TOP: 112px"
				cellSpacing="1" cellPadding="0" width="300" border="0" align="left">
				<TR align="left">
					<TD><STRONG>Cart</STRONG></TD>
					<TD><STRONG>Total</STRONG></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR align="left">
					<TD>All Season&nbsp;Jacket. (Large)</TD>
					<TD>19.99</TD>
				</TR>
				<TR>
					<TD>State Sales Tax</TD>
					<TD>&nbsp; 1.99</TD>
				</TR>
				<TR>
					<TD><B>Order Total:</B></TD>
					<TD>21.98</TD>
				</TR>
			</TABLE></A>
		</form></SPAN>
	</body>
</HTML>

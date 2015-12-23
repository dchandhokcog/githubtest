<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PurchaseDescription.aspx.vb" Inherits="eStoreFrontVB.eStoreFrontVB.PurchaseDescription" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Your Cart Details</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body bgColor="#ffffff" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server"></TD>&nbsp; <!-- PayPal Logo -->
			<DIV style="DISPLAY: inline; FONT-WEIGHT: normal; FONT-SIZE: medium; Z-INDEX: 101; LEFT: 32px; WIDTH: 232px; BORDER-TOP-STYLE: none; FONT-FAMILY: Verdana; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: absolute; TOP: 208px; HEIGHT: 8px; BORDER-BOTTOM-STYLE: none"
				align="left" ms_positioning="FlowLayout">Payment Method</DIV>
			<HR style="Z-INDEX: 106; LEFT: 32px; POSITION: absolute; TOP: 304px; HEIGHT: 8px; BACKGROUND-COLOR: #146690"
				align="left" width="92%" SIZE="1">
			&nbsp;&nbsp;&nbsp;
			<DIV style="DISPLAY: inline; FONT-WEIGHT: normal; FONT-SIZE: medium; Z-INDEX: 102; LEFT: 32px; WIDTH: 320px; BORDER-TOP-STYLE: none; FONT-FAMILY: Verdana; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: absolute; TOP: 16px; HEIGHT: 24px; BORDER-BOTTOM-STYLE: none"
				align="left" ms_positioning="FlowLayout">Purchase Description</DIV>
			<HR style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 48px; HEIGHT: 8px; BACKGROUND-COLOR: #146690"
				align="left" width="92%" SIZE="8">
			<HR style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 240px; HEIGHT: 8px; BACKGROUND-COLOR: #146690"
				align="left" width="92%" SIZE="1">
			<asp:label id="lblContinue" style="Z-INDEX: 105; LEFT: 32px; POSITION: absolute; TOP: 328px"
				runat="server" Height="64px" Width="920px" Font-Names="Verdana" Font-Italic="True" Font-Size="Smaller"></asp:label>
			<asp:Button id="btnContinue" style="Z-INDEX: 107; LEFT: 32px; POSITION: absolute; TOP: 416px"
				runat="server" Font-Names="Verdana" Height="32px" Width="120px" Text="Continue" tabIndex="3"></asp:Button>
			<img alt="Visa Mastercard Logos" title="Visa Mastercard Logos" src="img/CreditCardLogo.gif"
				width="148" border="0" style="Z-INDEX: 108; LEFT: 88px; POSITION: absolute; TOP: 264px"></A>&nbsp;
			<img alt="Express Checkout Logo" title="Express Checkout logo" src="img/paypal_logo.gif"
				height="32" border="0" style="Z-INDEX: 109; LEFT: 432px; POSITION: absolute; TOP: 264px">&nbsp;
			<DIV style="DISPLAY: inline; FONT-SIZE: 11px; Z-INDEX: 110; LEFT: 520px; WIDTH: 248px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 264px; HEIGHT: 32px"
				align="left" ms_positioning="FlowLayout">Save time. Checkout securely. Pay 
				without sharing your financial information.</DIV>
			<asp:RadioButton id="rdoCreditCard" style="Z-INDEX: 111; LEFT: 64px; POSITION: absolute; TOP: 272px"
				runat="server" AutoPostBack="True" GroupName="PaymentMethod" tabIndex="1" />
			<asp:RadioButton id="rdoPaypal" style="Z-INDEX: 112; LEFT: 408px; POSITION: absolute; TOP: 272px"
				runat="server" AutoPostBack="True" GroupName="PaymentMethod" tabIndex="2" />
			<TABLE id="Table1" style="Z-INDEX: 113; LEFT: 32px; WIDTH: 488px; POSITION: absolute; TOP: 72px"
				cellSpacing="1" cellPadding="0" width="300" border="0" align="left">
				<TR align="left">
					<TD><STRONG>Cart</STRONG></TD>
					<TD><STRONG>Total</STRONG></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR align="left">
					<TD>All Season Jacket. (Large)</TD>
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

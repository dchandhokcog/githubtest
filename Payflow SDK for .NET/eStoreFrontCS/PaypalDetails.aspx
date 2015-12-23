<%@ Page language="c#" Codebehind="PayPalDetails.aspx.cs" AutoEventWireup="false" Inherits="eStoreFrontCS.PayPalDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Review your Shipping Information</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<HR style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 88px; BACKGROUND-COLOR: blue"
				width="92%" SIZE="8" align="left" color="#146690">
			<DIV style="DISPLAY: inline; FONT-SIZE: medium; Z-INDEX: 102; LEFT: 24px; WIDTH: 408px; FONT-FAMILY: Verdana; POSITION: absolute; TOP: 40px; HEIGHT: 24px"
				ms_positioning="FlowLayout">Review your Shipping&nbsp;Information</DIV>
			<asp:Label id="lblPaypalShippingDetails" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 128px"
				runat="server" Width="416px" Height="176px" BackColor="White" BorderStyle="None" Font-Names="Verdana">Shipping Address<br></asp:Label>
			<asp:Button id="btnContinue" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 320px"
				runat="server" Width="192px" Height="32px" BackColor="LightGray" Font-Names="Verdana" Text="Continue Checkout"
				tabIndex="2"></asp:Button>
		</form>
	</body>
</HTML>

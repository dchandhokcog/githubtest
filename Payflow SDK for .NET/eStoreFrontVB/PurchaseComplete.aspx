<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PurchaseComplete.aspx.vb" Inherits="eStoreFrontVB.eStoreFrontVB.PurchaseComplete" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Checkout completed</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblPurchaseStatus" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 96px"
				runat="server" Width="750px" Height="300px" Font-Names="Verdana" Font-Size="Small"></asp:Label>
			<HR style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 72px; BACKGROUND-COLOR: blue"
				align="left" width="92%" SIZE="8" color="#146690">
			<asp:Button id="btnReturnToCart" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 416px"
				runat="server" Font-Names="Verdana" Height="32px" Width="200px" Text="Return to Cart" Visible="False"></asp:Button>
			<asp:Label id="lblGreetings" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 16px"
				runat="server" Font-Names="Verdana" Height="40px" Width="280px"></asp:Label>
		</form>
	</body>
</HTML>

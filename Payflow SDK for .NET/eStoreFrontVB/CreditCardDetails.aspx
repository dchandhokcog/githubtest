<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CreditCardDetails.aspx.vb" Inherits="eStoreFrontVB.eStoreFrontVB.CreditCardDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Billing and Shipping Information</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblSTState" style="Z-INDEX: 140; LEFT: 48px; POSITION: absolute; TOP: 616px"
				runat="server" Font-Size="X-Small" Font-Names="Verdana" Height="16px" Width="40px">State</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 147; LEFT: 444px; POSITION: absolute; TOP: 176px" runat="server"
				Width="255px" Height="16px" Font-Names="Verdana" Font-Size="XX-Small">(Verified by Visa, SecureCard by MasterCard)</asp:Label>
			<asp:TextBox id="txtCVV2" style="Z-INDEX: 146; LEFT: 608px; POSITION: absolute; TOP: 128px" tabIndex="2"
				runat="server" Width="40px" Height="24px" Font-Names="Verdana">123</asp:TextBox>
			<asp:Label id="lblCvv2" style="Z-INDEX: 145; LEFT: 424px; POSITION: absolute; TOP: 128px" runat="server"
				Width="168px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Credit Card CVV2 value</asp:Label>
			<asp:Label id="lblSTZip" style="Z-INDEX: 139; LEFT: 248px; POSITION: absolute; TOP: 608px"
				runat="server" Font-Size="X-Small" Font-Names="Verdana" Height="16px" Width="24px">Zip</asp:Label>
			<asp:Label id="lblSTCity" style="Z-INDEX: 138; LEFT: 48px; POSITION: absolute; TOP: 584px"
				runat="server" Font-Size="X-Small" Font-Names="Verdana" Height="16px" Width="87px">City</asp:Label>
			<asp:TextBox id="txtShipToState" style="Z-INDEX: 137; LEFT: 176px; POSITION: absolute; TOP: 608px"
				runat="server" Width="32px" Height="24px" Font-Names="Verdana" MaxLength="2" tabIndex="17"></asp:TextBox>
			<asp:TextBox id="txtShipToZip" style="Z-INDEX: 136; LEFT: 296px; POSITION: absolute; TOP: 608px"
				runat="server" Width="48px" Height="24px" Font-Names="Verdana" MaxLength="5" tabIndex="18"></asp:TextBox>
			<asp:TextBox id="txtShipToCity" style="Z-INDEX: 135; LEFT: 176px; POSITION: absolute; TOP: 576px"
				runat="server" Width="168px" Height="24px" Font-Names="Verdana" tabIndex="16"></asp:TextBox>
			<asp:TextBox id="txtShipToStreet" style="Z-INDEX: 134; LEFT: 176px; POSITION: absolute; TOP: 544px"
				runat="server" Width="168px" Height="24px" Font-Names="Verdana" tabIndex="15"></asp:TextBox>
			<asp:Label id="lblSTStreet" style="Z-INDEX: 133; LEFT: 48px; POSITION: absolute; TOP: 552px"
				runat="server" Width="48px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Street</asp:Label>
			<asp:TextBox id="txtShipToLName" style="Z-INDEX: 132; LEFT: 440px; POSITION: absolute; TOP: 512px"
				runat="server" Width="162px" Height="24px" Font-Names="Verdana" tabIndex="14"></asp:TextBox>
			<asp:Label id="lblSTLName" style="Z-INDEX: 131; LEFT: 392px; POSITION: absolute; TOP: 512px"
				runat="server" Width="42px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Last</asp:Label>
			<asp:TextBox id="txtShipToFName" style="Z-INDEX: 130; LEFT: 176px; POSITION: absolute; TOP: 512px"
				runat="server" Width="170px" Height="24px" Font-Names="Verdana" tabIndex="13"></asp:TextBox>
			<asp:Label id="lblSTFName" style="Z-INDEX: 129; LEFT: 128px; POSITION: absolute; TOP: 512px"
				runat="server" Width="42px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">First</asp:Label>
			<asp:Label id="lblSTName" style="Z-INDEX: 128; LEFT: 48px; POSITION: absolute; TOP: 512px"
				runat="server" Width="42px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Name</asp:Label>
			<asp:Label id="lblShippingAddress" style="Z-INDEX: 126; LEFT: 48px; POSITION: absolute; TOP: 424px"
				runat="server" Width="200px" Height="16px" Font-Names="Verdana">Shipping Address</asp:Label>
			<asp:Label id="lblBillLastName" style="Z-INDEX: 123; LEFT: 384px; POSITION: absolute; TOP: 264px"
				runat="server" Width="42px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Last</asp:Label>
			<asp:Label id="lblBillFName" style="Z-INDEX: 122; LEFT: 136px; POSITION: absolute; TOP: 264px"
				runat="server" Width="42px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">First</asp:Label>
			<asp:TextBox id="txtState" style="Z-INDEX: 121; LEFT: 184px; POSITION: absolute; TOP: 368px"
				runat="server" Width="32px" Height="24px" Font-Names="Verdana" MaxLength="2" tabIndex="10">CA</asp:TextBox>
			<asp:Label id="lblState" style="Z-INDEX: 120; LEFT: 48px; POSITION: absolute; TOP: 368px" runat="server"
				Width="40px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">State</asp:Label>
			<asp:TextBox id="txtZip" style="Z-INDEX: 119; LEFT: 304px; POSITION: absolute; TOP: 368px" runat="server"
				Width="48px" Height="24px" Font-Names="Verdana" MaxLength="5" tabIndex="11">12345</asp:TextBox>
			<asp:TextBox id="txtCity" style="Z-INDEX: 118; LEFT: 184px; POSITION: absolute; TOP: 328px" runat="server"
				Width="168px" Height="24px" Font-Names="Verdana" tabIndex="9">San Jose</asp:TextBox>
			<asp:TextBox id="txtStreet" style="Z-INDEX: 117; LEFT: 184px; POSITION: absolute; TOP: 296px"
				runat="server" Width="168px" Height="24px" Font-Names="Verdana" tabIndex="8">123 North First Street</asp:TextBox>
			<asp:TextBox id="txtLastName" style="Z-INDEX: 116; LEFT: 440px; POSITION: absolute; TOP: 264px"
				runat="server" Width="162px" Height="24px" Font-Names="Verdana" tabIndex="7">Jackson</asp:TextBox>
			<asp:Label id="lblZip" style="Z-INDEX: 115; LEFT: 256px; POSITION: absolute; TOP: 368px" runat="server"
				Width="24px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Zip</asp:Label>
			<asp:Label id="lblCity" style="Z-INDEX: 114; LEFT: 48px; POSITION: absolute; TOP: 336px" runat="server"
				Width="168px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">City</asp:Label>
			<asp:Label id="lblStreet" style="Z-INDEX: 113; LEFT: 48px; POSITION: absolute; TOP: 304px"
				runat="server" Width="48px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Street</asp:Label>
			<asp:TextBox id="txtFirstName" style="Z-INDEX: 112; LEFT: 184px; POSITION: absolute; TOP: 264px"
				runat="server" Width="170px" Height="24px" Font-Names="Verdana" tabIndex="6">Paul</asp:TextBox>
			<asp:Label id="lblBillName" style="Z-INDEX: 111; LEFT: 48px; POSITION: absolute; TOP: 264px"
				runat="server" Width="42px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Name</asp:Label>
			<asp:TextBox id="txtCCNumber" style="Z-INDEX: 103; LEFT: 216px; POSITION: absolute; TOP: 128px"
				runat="server" Width="152px" Height="24px" Font-Names="Verdana" tabIndex="1">5105105105105100</asp:TextBox>
			<asp:Label id="lblBillingAddress" style="Z-INDEX: 110; LEFT: 40px; POSITION: absolute; TOP: 224px"
				runat="server" Width="200px" Height="16px" Font-Names="Verdana">Billing Address</asp:Label>
			<asp:DropDownList id="ddExpYear" style="Z-INDEX: 108; LEFT: 320px; POSITION: absolute; TOP: 160px"
				runat="server" Width="56px" Height="16px" Font-Names="Verdana" tabIndex="4">
				<asp:ListItem Value="07">2007</asp:ListItem>
				<asp:ListItem Value="08">2008</asp:ListItem>
				<asp:ListItem Value="09">2009</asp:ListItem>
				<asp:ListItem Value="10">2010</asp:ListItem>
				<asp:ListItem Value="11">2011</asp:ListItem>
				<asp:ListItem Value="12">2012</asp:ListItem>
			</asp:DropDownList>
			<asp:Label id="lblExDate" style="Z-INDEX: 106; LEFT: 280px; POSITION: absolute; TOP: 168px"
				runat="server" Width="32px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Year</asp:Label>
			<asp:Label id="lblExMonth" style="Z-INDEX: 105; LEFT: 160px; POSITION: absolute; TOP: 168px"
				runat="server" Width="48px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Month</asp:Label>
			<asp:Label id="lblExpDate" style="Z-INDEX: 104; LEFT: 40px; POSITION: absolute; TOP: 168px"
				runat="server" Width="80px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Expiry Date</asp:Label>
			<DIV style="DISPLAY: inline; FONT-WEIGHT: normal; FONT-SIZE: medium; Z-INDEX: 100; LEFT: 32px; WIDTH: 360px; BORDER-TOP-STYLE: none; FONT-FAMILY: Verdana; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: absolute; TOP: 16px; HEIGHT: 24px; BORDER-BOTTOM-STYLE: none"
				align="left" ms_positioning="FlowLayout">Billing and Shipping Information</DIV>
			<asp:Label id="lblCCNumber" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 128px"
				runat="server" Width="168px" Height="16px" Font-Names="Verdana" Font-Size="X-Small">Credit Card Number</asp:Label>
			<asp:DropDownList id="ddExpMonth" style="Z-INDEX: 107; LEFT: 216px; POSITION: absolute; TOP: 160px"
				runat="server" Width="56px" Height="16px" Font-Names="Verdana" tabIndex="3">
				<asp:ListItem Value="01">Jan</asp:ListItem>
				<asp:ListItem Value="02">Feb</asp:ListItem>
				<asp:ListItem Value="03">Mar</asp:ListItem>
				<asp:ListItem Value="04">Apr</asp:ListItem>
				<asp:ListItem Value="05">May</asp:ListItem>
				<asp:ListItem Value="06">Jun</asp:ListItem>
				<asp:ListItem Value="07">Jul</asp:ListItem>
				<asp:ListItem Value="08">Aug</asp:ListItem>
				<asp:ListItem Value="09">Sep</asp:ListItem>
				<asp:ListItem Value="10">Oct</asp:ListItem>
				<asp:ListItem Value="11">Nov</asp:ListItem>
				<asp:ListItem Value="12" Selected="True">Dec</asp:ListItem>
			</asp:DropDownList>
			<asp:Label id="lblCreditCard" style="Z-INDEX: 109; LEFT: 40px; POSITION: absolute; TOP: 88px"
				runat="server" Width="200px" Height="16px" Font-Names="Verdana">Credit Card</asp:Label>
			<HR style="Z-INDEX: 124; LEFT: 32px; POSITION: absolute; TOP: 400px" align="left" width="92%"
				SIZE="8" color="#146690">
			<HR style="Z-INDEX: 125; LEFT: 32px; POSITION: absolute; TOP: 200px" align="left" width="92%"
				SIZE="8" color="#146690">
			<asp:CheckBox id="chkCopyBilling" style="Z-INDEX: 127; LEFT: 48px; POSITION: absolute; TOP: 464px"
				runat="server" Width="446px" Height="32px" Font-Names="Verdana" Font-Size="X-Small" AutoPostBack="True"
				Text="Check this if your Shipping Address is same as Billing Address" tabIndex="12"></asp:CheckBox>
			<asp:Button id="btnCheckout" style="Z-INDEX: 141; LEFT: 32px; POSITION: absolute; TOP: 656px"
				runat="server" Width="106px" Height="27px" Text="Checkout" Font-Names="Verdana" tabIndex="19"></asp:Button>
			<HR style="Z-INDEX: 142; LEFT: 32px; POSITION: absolute; TOP: 640px; BACKGROUND-COLOR: blue"
				align="left" width="92%" SIZE="8" color="#146690">
			<HR style="Z-INDEX: 143; LEFT: 32px; POSITION: absolute; TOP: 48px" align="left" width="92%"
				color="#146690" SIZE="8">
			<asp:CheckBox id="chkProcessWithBuyerAuth" style="Z-INDEX: 144; LEFT: 424px; POSITION: absolute; TOP: 152px"
				tabIndex="5" runat="server" Width="336px" Height="12px" Font-Names="Verdana" Font-Size="X-Small"
				Text="Process purchase using Buyer Authentication"></asp:CheckBox>
		</form>
	</body>
</HTML>

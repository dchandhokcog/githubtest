Public Class _Default
    Inherits System.Web.UI.Page

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
        'Put user code to initialize the page here
        Response.Redirect(Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/")) + "/src/PayPal/Payments/SampleStore/VB/Aspx/SampleStore.aspx")
        'Response.Write(Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/")) + "/src/SampleStore/VB/ASPX/SampleStore.aspx")
    End Sub

End Class

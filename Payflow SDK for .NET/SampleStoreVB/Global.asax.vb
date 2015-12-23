Imports System.Web
Imports System.Web.SessionState
''' -----------------------------------------------------------------------------
''' Project	 : SampleStoreVB
''' Class	 : Global
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Global class
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[db2admin]	6/17/2005	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class [Global]
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fires when the application is started
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fires when the session is started
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fires at the beginning of each request
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fires upon attempting to authenticate the use
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fires when an error occurs
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fires when the session ends
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fires when the application ends
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[db2admin]	6/17/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class

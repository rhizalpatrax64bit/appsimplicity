Public Class SplashScreen
    Public Enum DisplayMode
        AboutBox
        SplashScreen
    End Enum

    Private _Mode As DisplayMode = DisplayMode.SplashScreen

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
        Me.Timer1.Enabled = False
    End Sub

    Private Sub SplashScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case _Mode
            Case DisplayMode.AboutBox
                Me.Timer1.Enabled = False
                Me.btnClose.Visible = True
            Case DisplayMode.SplashScreen
                Me.Timer1.Enabled = True
                Me.btnClose.Visible = False
        End Select

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub New(ByVal pMode As DisplayMode)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me._Mode = pMode
    End Sub
End Class
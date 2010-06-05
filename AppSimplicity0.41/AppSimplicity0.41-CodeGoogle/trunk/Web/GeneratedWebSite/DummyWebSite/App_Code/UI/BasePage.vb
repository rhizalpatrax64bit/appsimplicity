Imports Microsoft.VisualBasic

Namespace UI
    Public MustInherit Class BasePage
        Inherits System.Web.UI.Page

        Public Enum AlertType
            _Warning
            _Error
            _Information
        End Enum

        Public MustOverride Sub Initialize()

        ''Private Sub SetPageTitle()
        ''    Dim lPageTitle As String = "Sitio Web"
        ''    Dim lDescription As String = ""

        ''    If Not (SiteMap.CurrentNode Is Nothing) Then
        ''        lPageTitle = SiteMap.CurrentNode.Title
        ''        lDescription = String.Format("[{0}]", SiteMap.CurrentNode.Description)
        ''    End If

        ''    Me.Title = String.Format("Invercap - {0} {1}", lPageTitle, lDescription)
        ''End Sub

        'Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '    Me.SetPageTitle()
        'End Sub


        'Public Sub Alert(ByVal pMessage As String, Optional ByVal URL As String = "")
        '    Me.Alert("Information", pMessage, AlertType._Information, URL)
        'End Sub

        'Public Sub Alert(ByVal pTitle As String, ByVal pMessage As String, ByVal pType As AlertType, Optional ByVal pURL As String = "")
        '    Dim sbScript As New StringBuilder

        '    Dim AlertMSG As String = ""

        '    sbScript.Append("<script language='JavaScript' type='text/javascript'>")

        '    pMessage = pMessage.Replace("'", "-")
        '    pMessage = pMessage.Replace(vbCrLf, "-")
        '    AlertMSG = String.Format(" alert ('{0}'); ", pMessage)

        '    If (pURL <> "") Then
        '        AlertMSG = AlertMSG & String.Format(" location.href='{0}'; ", pURL)
        '    End If

        '    sbScript.Append(AlertMSG)
        '    sbScript.Append("</script>")

        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "@alertScript", sbScript.ToString(), False)
        'End Sub

        '''' <summary>
        '''' Envia un bloque de código al cliente para ejecutarse.
        '''' </summary>
        '''' <param name="pCodeBlock">Indica el código que se ejecutará en el cliente</param>
        'Public Sub RegisterClientScript(ByVal pCodeBlock As String, ByVal pClientScriptName As String)
        '    Dim sbScript As New StringBuilder

        '    sbScript.Append("<script language='JavaScript' type='text/javascript'>")

        '    sbScript.Append(pCodeBlock)

        '    sbScript.Append("</script>")

        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), pClientScriptName, sbScript.ToString(), False)
        'End Sub

        'Public Sub UnregisterClientScript(ByVal pClientScriptName As String)
        '    Dim sbScript As New StringBuilder

        '    sbScript.Append("<script language='JavaScript' type='text/javascript'>")

        '    sbScript.Append("//")

        '    sbScript.Append("</script>")

        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), pClientScriptName, sbScript.ToString, False)
        'End Sub

        '''' <summary>
        '''' Establece si se debe mostrar el mensaje de espera en peticiones largas
        '''' </summary>    
        'Protected Property DisplayOverlay() As Boolean
        '    Get
        '        Dim lControl As System.Web.UI.UserControl

        '        lControl = Me.Master.FindControl("Form1").FindControl("WaitOverlay")

        '        If Not (lControl Is Nothing) Then
        '            Return lControl.Visible
        '        End If

        '        Return False
        '    End Get
        '    Set(ByVal value As Boolean)
        '        Dim lControl As System.Web.UI.UserControl

        '        lControl = Me.Master.FindControl("Form1").FindControl("WaitOverlay")

        '        If Not (lControl Is Nothing) Then
        '            lControl.Visible = value
        '        End If
        '    End Set
        'End Property

        '''' <summary>
        '''' Deshabilita la pantalla de espera mostrada al usuario en procesos de ejecucion largos.
        '''' </summary>
        'Public Sub RemoveWaitOverlay()
        '    Me.RegisterClientScript("unblock();", "@UnBlockUI")
        'End Sub

        '''' <summary>
        '''' Muestra el diálogo de espera en el cliente.
        '''' </summary>
        '''' <remarks></remarks>
        'Public Sub ShowWaitOverlay()
        '    Me.RegisterClientScript("block();", "@BlockUI")
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not (IsPostBack) Then
                Me.Initialize()
            End If
        End Sub
    End Class
End Namespace


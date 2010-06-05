Imports Microsoft.VisualBasic

Namespace Utilities
    Public Class Web

        ''' <summary>
        ''' Agrega un mensaje de confirmación del lado del cliente al evento onclick de un control determinado.
        ''' </summary>
        ''' <param name="pControl">La instancia del control al que se desea agregar la confirmación.</param>
        ''' <param name="pConfirmationMessage">El mensaje de la confirmación.</param>
        Public Shared Sub AddConfirmation(ByVal pControl As System.Web.UI.WebControls.WebControl, ByVal pConfirmationMessage As String, Optional ByVal pDisplayWaitOverlay As Boolean = False)
            Dim lMessage As String = pConfirmationMessage.Replace("¿", "\¿")

            lMessage = lMessage.Replace("'", "\'")

            Dim lCode As String

            If (pDisplayWaitOverlay) Then
                lCode = String.Format("return raiseconfirmation('{0}', true);", lMessage)
            Else
                lCode = String.Format("return raiseconfirmation('{0}', false);", lMessage)
            End If

            pControl.Attributes.Add("onclick", lCode)
        End Sub

        ''' <summary>
        ''' Agrega a un control la habilidad de mostrar una pantalla de espera al usuario.
        ''' </summary>
        ''' <param name="pControl">La instancia del control al que se desea agregar el mensaje de usuario.</param>
        Public Shared Sub AddWaitOverlay(ByVal pControl As System.Web.UI.WebControls.WebControl)
            pControl.Attributes.Add("onclick", "return block();")
        End Sub


        ''' <summary>
        ''' Elimina los caracteres inválidos de una cadena.
        ''' </summary>
        ''' <param name="pInput">La cadena que se desea evaluar.</param>        
        Public Shared Function StripToSafeString(ByVal pInput As String) As String
            Dim lSB As New StringBuilder

            Dim lValidChars As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚáéíóú1234567890-+.@,;+$ "

            For Each lChar As Char In pInput
                Dim lInclude As Boolean = False

                For Each lValidChar As Char In lValidChars
                    If (lChar = lValidChar) Then
                        lInclude = True
                        Exit For
                    End If
                Next

                If (lInclude) Then
                    lSB.Append(lChar)
                End If
            Next

            Return lSB.ToString
        End Function

        ''' <summary>
        ''' Despliega el mensaje de acceso denegado.
        ''' </summary>
        Public Shared Sub DisplayAccessDeniedMessage()
            System.Web.HttpContext.Current.Response.Redirect("~/UI/Messages/AccessDenied.htm")
        End Sub

    End Class
End Namespace

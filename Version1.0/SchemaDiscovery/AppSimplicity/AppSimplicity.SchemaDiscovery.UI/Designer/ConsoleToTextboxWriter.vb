Imports System.IO
Imports System.Windows.Forms

Public Class ConsoleToTextboxWriter
    Inherits TextWriter

    Private _Textbox As TextBox

    Public Sub New(ByVal pTextbox As TextBox)
        _Textbox = pTextbox
    End Sub

    Public Overrides ReadOnly Property Encoding() As System.Text.Encoding
        Get
            Return System.Text.Encoding.UTF8
        End Get
    End Property

    Public Overrides Sub Write(ByVal value As Char)
        MyBase.Write(value)
        _Textbox.AppendText(value.ToString())
    End Sub
End Class

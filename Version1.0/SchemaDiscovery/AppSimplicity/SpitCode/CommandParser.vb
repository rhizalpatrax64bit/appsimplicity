Public Class CommandParser

    Public Enum Actions
        UpdateSchema
        Generate
        LaunchUI
        Undefined
    End Enum

    Private _Actions As AppSimplicity.IO.CommandArguments

    Public Sub New(commandArguments As String)
        _Actions = New AppSimplicity.IO.CommandArguments(commandArguments)
    End Sub

    Public Function ParseAction() As Actions
        Dim lReturnValue As Actions = Actions.Undefined

        If Not (String.IsNullOrEmpty(_Actions.Item("action"))) Then
            Select Case (_Actions.Item("action").ToLower())
                Case "UpdateSchema".ToLower()
                    lReturnValue = Actions.UpdateSchema
                Case "Generate".ToLower()
                    lReturnValue = Actions.Generate
                Case "LaunchUI".ToLower()
                    lReturnValue = Actions.LaunchUI
            End Select
        Else
            lReturnValue = Actions.LaunchUI
        End If

        Return lReturnValue
    End Function

    Public Function GetCommandParameter(parameterName As String) As String
        Return _Actions.Item(parameterName)
    End Function

End Class

Imports System.Diagnostics

Namespace Utilities

    ''' <summary>
    ''' Clase que expone métodos para generar registros de sucesos
    ''' </summary>
    Public Class Logging

        ''' <summary>
        ''' Escribe una entrada al registro de sucesos de windows
        ''' </summary>
        ''' <param name="Entry">Mensaje del suceso</param>
        ''' <param name="AppName">Nombre de la aplicación que genera el suceso</param>
        ''' <param name="EventType">Especifica el tipo de suceso para el registro</param>
        ''' <param name="LogName">Nombre del Log donde se desea escribir</param>
        ''' <returns>Devuelve verdadero si fue posible escribir al registro de suceso de windows</returns>
        ''' <remarks></remarks>
        Public Shared Function WriteEntry(ByVal Entry As String, Optional ByVal AppName As String = "VB.NET Application", Optional ByVal EventType As EventLogEntryType = EventLogEntryType.Information, Optional ByVal LogName As String = "Application") As Boolean
            Dim lResult As Boolean = False

            Try
                If Not (System.Diagnostics.EventLog.SourceExists(AppName)) Then
                    System.Diagnostics.EventLog.CreateEventSource(AppName, LogName)
                End If

                Dim objEventLog As New EventLog()
                objEventLog.Source = AppName

                objEventLog.WriteEntry(Entry, EventType)
                lResult = True
            Catch Ex As Exception
                lResult = False
            End Try

            Return lResult
        End Function
    End Class
End Namespace

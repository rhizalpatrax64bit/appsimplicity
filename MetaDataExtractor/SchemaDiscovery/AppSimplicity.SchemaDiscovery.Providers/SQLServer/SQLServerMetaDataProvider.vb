Public Class SQLServerMetaDataProvider
    Implements SchemaDiscovery.IMetaDataProvider

    Public Function GetCLRTargetType(sqlType As String, pType As TargetLanguages) As String Implements IMetaDataProvider.GetCLRTargetType

    End Function

    Public Function GetColumns(table As Entities.Table) As System.Collections.Generic.List(Of Entities.Column) Implements IMetaDataProvider.GetColumns

    End Function

    Public Function GetColumns(view As Entities.View) As System.Collections.Generic.List(Of Entities.Column) Implements IMetaDataProvider.GetColumns

    End Function

    Public Function GetKeys(table As Entities.Table) As System.Collections.Generic.List(Of Entities.TableKey) Implements IMetaDataProvider.GetKeys

    End Function

    Public Function GetStoredProcedureParameters(storedProcedure As Entities.StoredProcedure) As System.Collections.Generic.List(Of Entities.StoredProcedureParameter) Implements IMetaDataProvider.GetStoredProcedureParameters

    End Function

    Public Function GetStoredProcedures() As System.Collections.Generic.List(Of Entities.StoredProcedure) Implements IMetaDataProvider.GetStoredProcedures

    End Function

    Public Function GetTables() As System.Collections.Generic.List(Of Entities.Table) Implements IMetaDataProvider.GetTables

    End Function

    Public Function GetViews() As System.Collections.Generic.List(Of Entities.View) Implements IMetaDataProvider.GetViews

    End Function

    Public Sub ScriptData(table As Entities.Table, ByRef OutputStream As System.IO.Stream) Implements IMetaDataProvider.ScriptData

    End Sub

    Public Sub SetConnectionStringName(ConnectionStringName As String) Implements IMetaDataProvider.SetConnectionStringName

    End Sub
End Class

Public Enum TargetLanguages
    CSharp
    VisualBasic
End Enum

Public Interface IMetaDataProvider
    Sub SetConnectionString(ByVal ConnectionString As String)
    Function GetTables() As List(Of Entities.Table)
    Function GetViews() As List(Of Entities.View)
    Function GetColumns(ByVal table As Entities.Table) As List(Of Entities.Column)
    Function GetColumns(ByVal view As Entities.View) As List(Of Entities.Column)
    Function GetStoredProcedures() As List(Of Entities.StoredProcedure)
    Function GetStoredProcedureParameters(ByVal storedProcedure As Entities.StoredProcedure) As List(Of Entities.StoredProcedureParameter)
    Function GetKeys(table As Entities.Table) As List(Of Entities.TableKey)
    Sub ScriptData(ByVal table As Entities.Table, ByRef OutputStream As System.IO.Stream)
End Interface

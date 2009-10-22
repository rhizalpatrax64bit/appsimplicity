Namespace MetaProviders
    Public Class MetaSQLServerProvider
        Inherits DiscoveryProvider

        Public Overloads Overrides Function GetColumns(ByVal pTable As MetaTable) As System.Collections.Generic.List(Of MetaColumn)

        End Function

        Public Overloads Overrides Function GetColumns(ByVal pView As MetaView) As System.Collections.Generic.List(Of MetaColumn)

        End Function

        Public Overrides Function GetStoredProcedureParameter(ByVal pSP As MetaStoredProcedure) As System.Collections.Generic.List(Of MetaStoredProcedureParameter)

        End Function

        Public Overrides Function GetStoredProcedures() As System.Collections.Generic.List(Of MetaTable)

        End Function

        Public Overrides Function GetTables() As System.Collections.Generic.List(Of MetaTable)

        End Function

        Public Overrides Function GetViews() As System.Collections.Generic.List(Of MetaView)

        End Function

        Public Sub New(ByVal pDataSource As AppSimplicity.DataAccess.DataSource)
            MyBase.New(pDataSource)
        End Sub
    End Class
End Namespace


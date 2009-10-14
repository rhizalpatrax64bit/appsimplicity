Namespace Providers
    Public MustInherit Class DiscoveryProvider
        Private _DataSource As AppSimplicity.DataAccess.DataSource

        Private _DataProvider As AppSimplicity.DataAccess.Providers.Provider
        Public ReadOnly Property DataProvider() As AppSimplicity.DataAccess.Providers.Provider
            Get
                If _DataProvider Is Nothing Then
                    AppSimplicity.DataAccess.Providers.ProviderFactory.GetInstance(Me._DataSource)
                End If
                Return _DataProvider
            End Get
        End Property

        Public Sub New(ByVal pDataSource As AppSimplicity.DataAccess.DataSource)
            Me._DataSource = pDataSource
        End Sub

        Public MustOverride Function GetTables() As List(Of MetaTable)
        Public MustOverride Function GetColumns(ByVal pTable As MetaTable) As List(Of MetaColumn)

        Public MustOverride Function GetViews() As List(Of MetaView)
        Public MustOverride Function GetColumns(ByVal pView As MetaView) As List(Of MetaColumn)

        Public MustOverride Function GetStoredProcedures() As List(Of MetaTable)
        Public MustOverride Function GetStoredProcedureParameter(ByVal pSP As MetaStoredProcedure) As List(Of MetaStoredProcedureParameter)
    End Class
End Namespace

Imports System.Threading

Public Class ThreadableDB
    Public resetEvent As ManualResetEvent
    Public table As AppSimplicity.SchemaDiscovery.Entities.Table
    Public view As AppSimplicity.SchemaDiscovery.Entities.View
    Public sproc As AppSimplicity.SchemaDiscovery.Entities.StoredProcedure
    Public metaProvider As IMetaDataProvider

    Public Sub New(table As AppSimplicity.SchemaDiscovery.Entities.Table, metaProvider As IMetaDataProvider, resetEvent As ManualResetEvent)
        Me.table = table
        Me.metaProvider = metaProvider
        Me.resetEvent = resetEvent
    End Sub

    Public Sub New(view As AppSimplicity.SchemaDiscovery.Entities.View, metaProvider As IMetaDataProvider, resetEvent As ManualResetEvent)
        Me.view = view
        Me.metaProvider = metaProvider
        Me.resetEvent = resetEvent
    End Sub

    Public Sub New(sproc As AppSimplicity.SchemaDiscovery.Entities.StoredProcedure, metaProvider As IMetaDataProvider, resetEvent As ManualResetEvent)
        Me.sproc = sproc
        Me.metaProvider = metaProvider
        Me.resetEvent = resetEvent
    End Sub
End Class
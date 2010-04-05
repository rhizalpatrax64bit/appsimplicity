Namespace MetaDiscovery
    Public MustInherit Class DBEntity
        Private _Provider As MetaDiscovery.Provider
        <Browsable(False)> _
        Public ReadOnly Property Provider() As MetaDiscovery.Provider
            Get
                Return _Provider
            End Get
        End Property

        Public Sub New(ByVal pProvider As MetaDiscovery.Provider)
            Me._Provider = pProvider
        End Sub
    End Class
End Namespace

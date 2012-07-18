Imports System.Configuration

Public Class MetaDataProviderElement
    Inherits System.Configuration.ConfigurationElement

    <ConfigurationProperty("invariantName", Isrequired:=True)> _
    Public Property InvariantName() As String
        Get
            Return Me("invariantName")
        End Get
        Set(ByVal value As String)
            Me("invariantName") = value
        End Set
    End Property

    <ConfigurationProperty("providerType", Isrequired:=True)> _
    Public Property ProviderType() As String
        Get
            Return Me("providerType")
        End Get
        Set(ByVal value As String)
            Me("providerType") = value
        End Set
    End Property

End Class

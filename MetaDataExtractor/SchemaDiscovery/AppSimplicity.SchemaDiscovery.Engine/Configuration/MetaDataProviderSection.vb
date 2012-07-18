Imports System.Configuration

Public Class MetaDataProviderSection
    Inherits System.Configuration.ConfigurationSection

    <ConfigurationProperty("providers", IsRequired:=True)> _
    Public Property Providers() As MetaDataProviderElementCollection
        Get
            Return CType(Me("providers"), MetaDataProviderElementCollection)
        End Get
        Set(ByVal value As MetaDataProviderElementCollection)
            Me("providers") = value
        End Set
    End Property

End Class

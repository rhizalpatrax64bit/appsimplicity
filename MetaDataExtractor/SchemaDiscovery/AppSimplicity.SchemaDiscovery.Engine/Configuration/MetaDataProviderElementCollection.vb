Imports System.Configuration

Public Class MetaDataProviderElementCollection
    Inherits ConfigurationElementCollection

    Default Public Property Providers(Index As Integer) As MetaDataProviderElement
        Get
            Return MyBase.BaseGet(Index)
        End Get
        Set(value As MetaDataProviderElement)
            If Not (MyBase.BaseGet(Index) Is Nothing) Then
                MyBase.BaseRemoveAt(Index)
            End If
            MyBase.BaseAdd(Index, value)
        End Set
    End Property

    Protected Overloads Overrides Function CreateNewElement() As System.Configuration.ConfigurationElement
        Return New MetaDataProviderElement()
    End Function

    Protected Overrides Function GetElementKey(element As System.Configuration.ConfigurationElement) As Object
        Return CType(element, MetaDataProviderElement).InvariantName
    End Function
End Class

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class DataService
     Inherits System.Web.Services.WebService

    Private Function GetDataServiceInstance(ByVal pDataServiceName As String) As AppSimplicity.DataAccess.DataService
        Dim lDS As New AppSimplicity.DataAccess.DataService(pDataServiceName)
        Return lDS
    End Function

    <WebMethod()> _
    Public Function ExecuteDataSet(ByVal pDataServiceName As String, ByVal pCommand As AppSimplicity.DataAccess.DataCommand) As System.Data.DataSet
        Dim lDS As AppSimplicity.DataAccess.DataService = Me.GetDataServiceInstance(pDataServiceName)

        Return lDS.DataProvider.ExecuteDataSet(pCommand)
    End Function

    <WebMethod()> _
    Public Function ExecuteNonQuery(ByVal pDataServiceName As String, ByVal pCommand As AppSimplicity.DataAccess.DataCommand) As Integer
        Dim lDS As AppSimplicity.DataAccess.DataService = Me.GetDataServiceInstance(pDataServiceName)

        Return lDS.DataProvider.ExecuteNonQuery(pCommand)
    End Function

    <WebMethod()> _
    Public Function ExecuteScalar(ByVal pDataServiceName As String, ByVal pCommand As AppSimplicity.DataAccess.DataCommand) As Object
        Dim lDS As AppSimplicity.DataAccess.DataService = Me.GetDataServiceInstance(pDataServiceName)

        Return lDS.DataProvider.ExecuteScalar(pCommand)
    End Function

End Class

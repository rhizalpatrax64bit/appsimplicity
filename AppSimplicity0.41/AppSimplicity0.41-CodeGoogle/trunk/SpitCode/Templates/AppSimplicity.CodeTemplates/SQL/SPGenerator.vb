Imports SpitCodeEngine
Imports System.Text

Public Class SPGenerator
    Inherits CodeGeneration.CodeTemplate

    Public Enum ListType
        FieldList
        FieldListIdentityOnly
        ParameterList
        ParameterListWithType
        ParameterAssignment
        FieldAlias
    End Enum

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - SQL Server Stored Procedure Code Generator for CRUD"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.ProviderTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\SQL", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Public Overrides Function OutputFileName() As String
        Return String.Format("{0}.SQL", Me.CurrentProvider.GeneratedNamespace.ToUpper)
    End Function

    Public Function ParameterList(ByVal pTable As MetaDiscovery.Table, ByVal pIncludeIdentity As Boolean, ByVal pListType As ListType) As String
        Dim SB As New StringBuilder
        Dim lColumnString As String = String.Empty
        Dim lFirst As Boolean = True
        For Each lcolumn As MetaDiscovery.Column In pTable.Columns
            Dim lInclude As Boolean = True

            If (lcolumn.IsPrimaryKey) Then
                If (pIncludeIdentity) Then
                    lInclude = True
                Else
                    lInclude = False
                End If
            End If

            If (lInclude) Then
                Select Case (pListType)
                    Case ListType.FieldList
                        lColumnString = lcolumn.Name
                    Case ListType.ParameterList
                        lColumnString = String.Format("@{0}", lcolumn.Name)
                    Case ListType.ParameterListWithType
                        lColumnString = String.Format("@{0} AS {1}", lcolumn.Name, lcolumn.NativeParameterType)
                    Case ListType.ParameterAssignment
                        lColumnString = String.Format("{0} = @{0}", lcolumn.Name)
                    Case ListType.FieldAlias
                        lColumnString = String.Format("[{0}].[{1}] AS [{0}.{1}]", lcolumn.Table.Name, lcolumn.Name)
                End Select

                If (lFirst) Then
                    SB.AppendFormat("           {0}" & vbCrLf, lColumnString)
                    lFirst = False
                Else
                    SB.AppendFormat("          ,{0}" & vbCrLf, lColumnString)
                End If
            End If
        Next

        Return SB.ToString
    End Function

#Region "Insert"
    Private Function GetInsertCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder

        Dim lSelId As String
        Dim lIncludeId As Boolean = False

        If (pTable.PKColumn.AutoIncrement) Then
            lSelId = "        SELECT @@IDENTITY"
        Else
            lSelId = ""
            lIncludeId = True
        End If

        SB.AppendFormat(My.Resources.SPGeneratorStrings.Sp_InsertCode & vbCrLf, _
                         String.Format("{0}_SP_INSERT", pTable.Name.ToUpper), _
                         Me.ParameterList(pTable, lIncludeId, ListType.ParameterListWithType), _
                         Me.ParameterList(pTable, lIncludeId, ListType.FieldList), _
                         Me.ParameterList(pTable, lIncludeId, ListType.ParameterList), _
                         lSelId, _
                         String.Format("[dbo].[{0}]", pTable.Name))

        Return SB.ToString
    End Function

    Private Function GetInsertSPCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim SPName As String = String.Format("{0}_SP_INSERT", pTable.Name.ToUpper)

        SB.AppendFormat(My.Resources.SPGeneratorStrings.Sp_DropStatement & vbCrLf, SPName)
        SB.Append(GetSPHeader(pTable, _
                              String.Format("Insertar un registro en la tabla {0}", pTable.Name), _
                              GetInsertCode(pTable)) & vbCrLf)

        Return SB.ToString
    End Function
#End Region

#Region "Update"
    Private Function GetUpdateCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim SPName As String = String.Format("{0}_SP_UPDATE", pTable.Name.ToUpper)

        SB.AppendFormat(My.Resources.SPGeneratorStrings.Sp_UpdateCode & vbCrLf, _
                         SPName, _
                         ParameterList(pTable, True, ListType.ParameterListWithType), _
                         pTable.Name, _
                         ParameterList(pTable, False, ListType.ParameterAssignment), _
                         String.Format("        {0} = @{0}", pTable.PKColumn.Name))

        Return SB.ToString
    End Function

    Private Function GetUpdateSPCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim SPName As String = String.Format("{0}_SP_UPDATE", pTable.Name.ToUpper)

        SB.AppendFormat(My.Resources.SPGeneratorStrings.Sp_DropStatement & vbCrLf, SPName)

        SB.Append(GetSPHeader(pTable, _
                              String.Format("Actualizar un registro en la tabla {0}", pTable.Name), _
                              GetUpdateCode(pTable) & vbCrLf))

        Return SB.ToString
    End Function
#End Region

#Region "Delete"
    Private Function GetDeleteCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim SPName As String = String.Format("{0}_SP_DELETE", pTable.Name.ToUpper)

        SB.AppendFormat(My.Resources.SPGeneratorStrings.SP_Delete & vbCrLf, _
                         SPName, _
                         String.Format("           @{0} AS {1}", pTable.PKColumn.Name, pTable.PKColumn.NativeParameterType), _
                         pTable.Name, _
                         String.Format("           {0} = @{0}", pTable.PKColumn.Name))

        Return SB.ToString
    End Function

    Private Function GetDeleteSPCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim SPName As String = String.Format("{0}_SP_DELETE", pTable.Name.ToUpper)

        SB.AppendFormat(My.Resources.SPGeneratorStrings.Sp_DropStatement & vbCrLf, SPName)

        SB.Append(GetSPHeader(pTable, _
                              String.Format("Eliminar un registro de la tabla {0}", pTable.Name), _
                              GetDeleteCode(pTable) & vbCrLf))

        Return SB.ToString
    End Function
#End Region

#Region "Select"
    Private Function GetSelectCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim SPName As String = String.Format("{0}_SP_SELECT", pTable.Name.ToUpper)

        SB.AppendFormat(My.Resources.SPGeneratorStrings.SP_Select & vbCrLf, _
                         SPName, _
                         String.Format("           @{0} AS {1}", pTable.PKColumn.Name, pTable.PKColumn.NativeParameterType), _
                         ParameterList(pTable, True, ListType.FieldAlias), _
                         pTable.Name, _
                         String.Format("        {0} = @{0}", pTable.PKColumn.Name))

        Return SB.ToString
    End Function

    Private Function GetSelectSPCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim SPName As String = String.Format("{0}_SP_SELECT", pTable.Name.ToUpper)

        SB.AppendFormat(My.Resources.SPGeneratorStrings.Sp_DropStatement & vbCrLf, SPName)

        SB.Append(GetSPHeader(pTable, _
                              String.Format("Obtener un registro de la tabla {0}", pTable.Name), _
                              GetSelectCode(pTable) & vbCrLf))

        Return SB.ToString
    End Function
#End Region

    Protected Function GetCRUDSPs(ByVal pTable As MetaDiscovery.Table)
        Dim SB As New StringBuilder

        SB.Append(GetSelectSPCode(pTable))
        SB.Append(vbCrLf)

        SB.Append(GetInsertSPCode(pTable))
        SB.Append(vbCrLf)

        SB.Append(GetUpdateSPCode(pTable))
        SB.Append(vbCrLf)

        SB.Append(GetDeleteSPCode(pTable))
        SB.Append(vbCrLf)

        Return SB.ToString
    End Function

    Protected Function GetSPHeader(ByVal pTable As MetaDiscovery.Table, ByVal pDescripcion As String, ByVal pSPCode As String) As String
        Dim SB As New StringBuilder
        SB.AppendFormat(My.Resources.SPGeneratorStrings.Sp_Header, _
                            Me.CurrentProvider.Project.Name, _
                            Me.CurrentProvider.DatabaseName, _
                            pTable.Name, _
                            pDescripcion, _
                            System.Security.Principal.WindowsIdentity.GetCurrent.Name, _
                            Date.Now.ToString, _
                            pSPCode)

        Return SB.ToString
    End Function

    Protected Function GetSQLCode(ByVal pProvider As MetaDiscovery.Provider)
        Dim SB As New StringBuilder

        For Each lTable As MetaDiscovery.Table In pProvider.Tables
            Dim lGenerate As Boolean = True
            If (lTable.HasManyPrimaryKeys) Then
                lGenerate = False
            End If

            If Not (lTable.HasPrimaryKey) Then
                lGenerate = False
            End If

            If (lGenerate) Then
                SB.Append(GetCRUDSPs(lTable))
            End If
        Next

        Return SB.ToString
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Output.WriteLine(String.Format("USE {0}", Me.CurrentProvider.DatabaseName))
        Output.WriteLine("GO")
        Output.WriteLine()

        Output.Write(GetSQLCode(Me.CurrentProvider))
    End Sub
End Class

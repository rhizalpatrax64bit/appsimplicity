﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18408
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class SPGeneratorStrings
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AppSimplicity.CodeTemplates.SPGeneratorStrings", GetType(SPGeneratorStrings).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CREATE PROCEDURE [dbo].[{0}]
        '''{1}
        '''AS
        '''BEGIN
        '''	
        '''        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        '''        SET NOCOUNT ON
        '''
        '''        DELETE FROM {2} 
        '''        WHERE
        '''{3}        
        '''
        '''        SELECT @@ROWCOUNT
        '''
        '''END
        '''
        '''GO.
        '''</summary>
        Friend Shared ReadOnly Property SP_Delete() As String
            Get
                Return ResourceManager.GetString("SP_Delete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N&apos;[dbo].[{0}]&apos;) AND OBJECTPROPERTY(id,N&apos;IsProcedure&apos;) = 1) 
        '''	BEGIN		
        '''		DROP PROCEDURE [dbo].[{0}]
        '''	END
        '''
        '''GO.
        '''</summary>
        Friend Shared ReadOnly Property Sp_DropStatement() As String
            Get
                Return ResourceManager.GetString("Sp_DropStatement", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''
        '''-- ----------------------------------------------------------------------------------------------------------------      
        '''--                  Proyecto : {0}
        '''--             Base de Datos : {1}
        '''--       Tablas Involucradas : {2}
        '''--                  Objetivo : {3}
        '''--             Observaciones : ESTE PROCEDIMIENTO FUE GENERADO POR UNA HERRAMIENTA DE GENERACIÓN DE CÓDIGO
        '''--
        '''--              Generado por : {4}
        '''--       Fecha de generación : {5}        
        '''-- ---------------------------------------------- [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property Sp_Header() As String
            Get
                Return ResourceManager.GetString("Sp_Header", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CREATE PROCEDURE [dbo].[{0}]
        '''{1}
        '''AS
        '''BEGIN
        '''	
        '''        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        '''        SET NOCOUNT ON
        '''
        '''        INSERT INTO {5} (
        '''{2}
        '''        )		
        '''        VALUES (
        '''{3}
        '''        )
        '''
        '''{4}
        '''
        '''END
        '''
        '''GO.
        '''</summary>
        Friend Shared ReadOnly Property Sp_InsertCode() As String
            Get
                Return ResourceManager.GetString("Sp_InsertCode", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CREATE PROCEDURE [dbo].[{0}]
        '''{1}
        '''AS
        '''BEGIN
        '''	
        '''        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        '''        SET NOCOUNT ON
        '''
        '''        SELECT
        '''{2}        
        '''        FROM {3} 
        '''        WHERE
        '''{4}        
        '''
        '''END
        '''
        '''GO.
        '''</summary>
        Friend Shared ReadOnly Property SP_Select() As String
            Get
                Return ResourceManager.GetString("SP_Select", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CREATE PROCEDURE [dbo].[{0}]
        '''{1}
        '''AS
        '''BEGIN
        '''	
        '''        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        '''        SET NOCOUNT ON
        '''
        '''        UPDATE {2} 
        '''          SET
        '''{3}          
        '''        WHERE
        '''{4}        
        '''
        '''        SELECT @@ROWCOUNT
        '''
        '''END
        '''
        '''GO.
        '''</summary>
        Friend Shared ReadOnly Property Sp_UpdateCode() As String
            Get
                Return ResourceManager.GetString("Sp_UpdateCode", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
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
    Friend Class SQLServerExtractionScripts
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AppSimplicity.SchemaDiscovery.Providers.SQLServerExtractionScripts", GetType(SQLServerExtractionScripts).Assembly)
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
        '''  Looks up a localized string similar to SELECT 
        '''	sproc.SPECIFIC_SCHEMA,
        '''	sproc.SPECIFIC_NAME
        '''FROM INFORMATION_SCHEMA.ROUTINES sproc
        '''WHERE sproc.ROUTINE_TYPE = &apos;PROCEDURE&apos;.
        '''</summary>
        Friend Shared ReadOnly Property GET_STORED_PROCEDURES() As String
            Get
                Return ResourceManager.GetString("GET_STORED_PROCEDURES", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT 
        '''	prm.PARAMETER_NAME,
        '''	prm.DATA_TYPE,
        '''	prm.CHARACTER_MAXIMUM_LENGTH,
        '''	prm.PARAMETER_MODE,
        '''	prm.ORDINAL_POSITION
        '''FROM INFORMATION_SCHEMA.PARAMETERS prm
        '''WHERE
        '''	prm.SPECIFIC_SCHEMA = @SPECIFIC_SCHEMA
        '''AND prm.SPECIFIC_NAME = @SPECIFIC_NAME
        '''
        '''ORDER BY 
        '''	prm.ORDINAL_POSITION.
        '''</summary>
        Friend Shared ReadOnly Property GET_STOREDPROCEDURE_PARAMETERS() As String
            Get
                Return ResourceManager.GetString("GET_STOREDPROCEDURE_PARAMETERS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT 
        '''	col.COLUMN_NAME,
        '''	col.ORDINAL_POSITION,
        '''	col.IS_NULLABLE,
        '''	col.DATA_TYPE,
        '''	col.CHARACTER_MAXIMUM_LENGTH,
        '''	kcu.CONSTRAINT_NAME,
        '''	tcnt.CONSTRAINT_TYPE,
        '''	CASE tcnt.CONSTRAINT_TYPE
        '''		WHEN &apos;PRIMARY KEY&apos; THEN &apos;YES&apos;
        '''		ELSE &apos;NO&apos;
        '''	END AS IS_PRIMARY_KEY,
        '''	CASE COLUMNPROPERTY(OBJECT_ID(col.TABLE_NAME), col.COLUMN_NAME,&apos;IsIdentity&apos;)
        '''		WHEN 1 THEN &apos;YES&apos;
        '''		ELSE &apos;NO&apos;
        '''	END AS IS_IDENTITY
        '''FROM INFORMATION_SCHEMA.COLUMNS col
        '''LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
        '''	ON 
        '''		kcu.TABLE_SCHEMA [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property GET_TABLE_COLUMNS() As String
            Get
                Return ResourceManager.GetString("GET_TABLE_COLUMNS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to --DECLARE @SCHEMA_NAME VARCHAR(50)
        '''--DECLARE @TABLE_NAME VARCHAR(100)
        '''
        '''--SET @SCHEMA_NAME = &apos;dbo&apos;
        '''--SET @TABLE_NAME = &apos;Customers&apos;
        '''
        '''DECLARE @TMP_KEYS TABLE (
        '''	ID INT IDENTITY (1,1),
        '''	KEY_OBJECT_ID VARCHAR(100),
        '''	INDEX_ID VARCHAR(100),
        '''	KEY_NAME VARCHAR(250)
        ''')
        '''
        '''INSERT INTO @TMP_KEYS (KEY_OBJECT_ID, INDEX_ID, KEY_NAME)
        '''SELECT
        '''	idx.[object_id],
        '''	idx.index_id,
        '''	idx.name
        '''FROM sys.indexes idx	
        '''JOIN sys.tables tabl on idx.object_id = tabl.object_id
        '''JOIN sys.schemas schem ON tabl.schema_id = sche [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property GET_TABLE_KEYS() As String
            Get
                Return ResourceManager.GetString("GET_TABLE_KEYS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT 
        '''	TABLE_SCHEMA, 
        '''	TABLE_NAME
        '''FROM INFORMATION_SCHEMA.TABLES
        '''WHERE TABLE_TYPE = &apos;BASE TABLE&apos;
        '''ORDER BY TABLE_SCHEMA, TABLE_NAME.
        '''</summary>
        Friend Shared ReadOnly Property GET_TABLES() As String
            Get
                Return ResourceManager.GetString("GET_TABLES", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to SELECT 
        '''	TABLE_SCHEMA, 
        '''	TABLE_NAME 
        '''FROM INFORMATION_SCHEMA.VIEWS
        '''ORDER BY TABLE_SCHEMA, TABLE_NAME.
        '''</summary>
        Friend Shared ReadOnly Property GET_VIEWS() As String
            Get
                Return ResourceManager.GetString("GET_VIEWS", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3615
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
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class ClassGeneratorStrings
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AppSimplicity.CodeTemplates.ClassGeneratorStrings", GetType(ClassGeneratorStrings).Assembly)
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
        '''  Looks up a localized string similar to #Region &quot;IActiveRecordMethods&quot;
        '''
        '''#Region &quot;Get parameters&quot;
        '''        Public Function Get_DELETE_Parameters() As System.Collections.Generic.List(Of AppSimplicity.DataAccess.DataCommandParameter) Implements AppSimplicity.ActiveRecord.IActiveRecord.Get_DELETE_Parameters
        '''            Dim lParameters As New List(Of DataAccess.DataCommandParameter)
        '''
        '''{2}
        '''
        '''            Return lParameters
        '''        End Function
        '''
        '''        Public Function Get_INSERT_Parameters() As System.Collections.Generic.List(Of AppSimplicity.Da [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property ActiveRecordMethods() As String
            Get
                Return ResourceManager.GetString("ActiveRecordMethods", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to         Private _{0} As {1}.{0}
        '''        &lt;System.Xml.Serialization.XmlIgnore()&gt; _
        '''        Public Property {0}() As {1}.{0}
        '''            Get
        '''                If (_{0} Is Nothing) Then
        '''                    _{0} = {1}.{2}.FetchById(Me._{3}.Value)
        '''                End If
        '''                Return _{0}
        '''            End Get
        '''            Set(ByVal value As {1}.{0})
        '''                Me._{3}.Value = value.{4}
        '''                Me.Save()
        '''				
        '''                _{0} = value
        '''            End Set
        '''        End Property.
        '''</summary>
        Friend Shared ReadOnly Property BelongsToProperty() As String
            Get
                Return ResourceManager.GetString("BelongsToProperty", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Imports AppSimplicity
        '''
        '''Namespace {0}
        '''    &apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; {11}
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''    &lt;Serializable()&gt; _
        '''    Partial {10} Class {1}
        '''        Implements ActiveRecord.IEntityRecord, ActiveRecord.IActiveRecord, System.Runtime.Serialization.ISerializable
        '''        
        '''#Region &quot;Fields&quot;
        '''{2}
        '''#End Region
        '''
        '''#Region &quot;Properties&quot;
        '''{3}
        '''        Private _IsLoadedFromDB As Boolean = False
        '''        &apos;&apos;&apos; &lt;summary&gt;
        '''        &apos;&apos;&apos; Determines whether the instance data comes from the data source
        '''        &apos;&apos;&apos; &lt;/summary [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property ClassWrapper() As String
            Get
                Return ResourceManager.GetString("ClassWrapper", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to             lColumn = New ActiveRecord.SchemaColumn()
        '''            lColumn.ColumnName = &quot;{0}&quot;
        '''            lColumn.DataType = {1}
        '''            lColumn.MaxLength = {2}
        '''            lColumn.AutoIncrement = {3}
        '''            lColumn.IsNullable = {4}
        '''            lColumn.IsPrimaryKey = {5}
        '''            lColumn.FieldLabel = &quot;{6}&quot;
        '''            lColumn.GridCaption = &quot;{7}&quot;
        '''            lColumn.IsDescription = {8}
        '''            lSchema.AddColumn(lColumn).
        '''</summary>
        Friend Shared ReadOnly Property ColumnDefinition() As String
            Get
                Return ResourceManager.GetString("ColumnDefinition", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Imports AppSimplicity
        '''
        '''Namespace {0}
        '''    &apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; This class exposes the services to access data using the data source {0}
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''    Partial {3} Class DataContext
        '''
        '''        Private Shared WithEvents _Service As DataAccess.DataService
        '''        &apos;&apos;&apos; &lt;summary&gt;
        '''        &apos;&apos;&apos; Contains the data access service instance. Through this object is possible to run SQL commands in the data source.
        '''        &apos;&apos;&apos; &lt;/summary&gt;        
        '''        Public Shared ReadOnly Property Service() As DataAcce [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property DataContextGenerator() As String
            Get
                Return ResourceManager.GetString("DataContextGenerator", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Imports AppSimplicity
        '''
        '''Namespace {0}
        '''
        '''    Partial {2} Class DataContext
        '''
        '''#Region &quot;Stored Procedures&quot;
        '''
        '''        &apos;&apos;&apos; &lt;summary&gt;
        '''        &apos;&apos;&apos; This class exposes methods to invoke stored procedures in {1} data source.
        '''        &apos;&apos;&apos; &lt;/summary&gt;        
        '''        Partial Public Class SPs
        '''
        '''{3}
        '''
        '''        End Class
        '''
        '''#End Region
        '''
        '''    End Class
        '''
        '''End Namespace.
        '''</summary>
        Friend Shared ReadOnly Property DataContextSPFunctionsWrapper() As String
            Get
                Return ResourceManager.GetString("DataContextSPFunctionsWrapper", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to #Region &quot;IEntity Methods&quot;
        '''
        '''        Public Sub Load(ByVal pRow As System.Data.DataRow, Optional ByVal pUseQualifiedNames As Boolean = False) Implements AppSimplicity.ActiveRecord.IEntityRecord.Load
        '''            RaiseEvent OnBeforeLoad()
        '''
        '''            If (pUseQualifiedNames) Then
        '''{2}
        '''            Else
        '''{3}
        '''            End If
        '''            
        '''            _IsLoadedFromDB = True
        '''
        '''            RaiseEvent OnAfterLoad()
        '''        End Sub
        '''
        '''        Public Event OnAfterLoad() Implements AppSimplicity.ActiveRecord [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property EntityMethods() As String
            Get
                Return ResourceManager.GetString("EntityMethods", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Imports AppSimplicity
        '''
        '''Namespace {0}
        '''
        '''    Partial {1} Class {2}
        '''
        '''        &apos;TODO: Add custom logic here.
        '''
        '''    End Class
        '''
        '''{3}
        '''
        '''End Namespace.
        '''</summary>
        Friend Shared ReadOnly Property ExtendedClassGenerator() As String
            Get
                Return ResourceManager.GetString("ExtendedClassGenerator", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Imports AppSimplicity
        '''
        '''Namespace {0}
        '''    Partial {1} Class DataContext
        '''
        '''        &apos;To arbitrarily set the data source, uncomment and customize the following code:
        '''        &apos;
        '''        &apos;Private Shared Sub _Service_OnSetDataSource(ByRef pDataSource As AppSimplicity.DataAccess.DataSource) Handles _Service.OnSetDataSource
        '''        &apos;    Dim lDataSource As New DataAccess.DataSource(&quot;{2}&quot;)
        '''
        '''        &apos;    lDataSource.ConnectionString = &quot;Get Connection String from anywhere you want.&quot;
        '''        &apos;    lDataSource.Con [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property ExtendedDataContextGenerator() As String
            Get
                Return ResourceManager.GetString("ExtendedDataContextGenerator", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to     Partial {0} Class {1}
        '''
        '''        &apos;TODO: Extend with custom methods.
        '''
        '''    End Class.
        '''</summary>
        Friend Shared ReadOnly Property ExtendedPluralClassWrapper() As String
            Get
                Return ResourceManager.GetString("ExtendedPluralClassWrapper", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &apos;
        '''        {8} Shared Function Fetch{0}By{3}(ByVal p{3} As {1}.{3}) As List(Of {1}.{2})
        '''            Dim lReturnValue As List(Of {1}.{2}) = Nothing
        '''
        '''            Dim lQuery As New {1}.{5}.Query
        '''
        '''            lQuery.SelectList.SelectNone()
        '''
        '''            lQuery.Join.{4}.SelectList.SelectNone()
        '''
        '''            lQuery.Join.{0}.SelectList.AddAll()
        '''
        '''            lQuery.Where({5}.Columns.{7}).EqualsTo(p{3}.{6})
        '''            
        '''            lReturnValue = {1}.{0}.FetchList(lQuery.GetDataSet, True)            
        '''
        '''  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property FetchHasManyByMethod() As String
            Get
                Return ResourceManager.GetString("FetchHasManyByMethod", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to #Region &quot;Fetch Methods&quot;
        '''        {4} Shared Function FetchById(ByVal pId As Object) As {0}.{1}
        '''            Dim lReturnValue As {0}.{1} = Nothing
        '''
        '''            Dim lList As List(Of {0}.{1})
        '''            Dim lQuery As New {2}.Query
        '''
        '''            lQuery.Where(Columns.Id).EqualsTo(pId)
        '''
        '''            lList = lQuery.FetchList()
        '''
        '''            If (lList.Count &gt; 0) Then
        '''                lReturnValue = lList(0)
        '''            End If
        '''
        '''            Return lReturnValue
        '''        End Function
        '''
        '''        {4} Shared Fun [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property FetchMethods() As String
            Get
                Return ResourceManager.GetString("FetchMethods", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to         Private Shared _Fields As String() = -&lt; _
        '''{0}        &gt;-
        '''
        '''        Public Shared ReadOnly Property Fields() As String()
        '''            Get
        '''                Return _Fields
        '''            End Get
        '''        End Property
        '''
        '''        Public Enum Columns
        '''{1}        End Enum.
        '''</summary>
        Friend Shared ReadOnly Property FieldGenerator() As String
            Get
                Return ResourceManager.GetString("FieldGenerator", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to         Private _{0}By{3} As List(Of {1}.{2})
        '''        &lt;System.Xml.Serialization.XmlIgnore()&gt; _
        '''        Public Property {0}By{3}() As List(Of {1}.{2})
        '''            Get
        '''                If (_{0}By{3} Is Nothing) Then
        '''                    _{0}By{3} = {1}.{0}.Fetch{0}By{3}(Me)
        '''
        '''                    If (_{0}By{3} Is Nothing) Then
        '''                        _{0}By{3} = New List(Of {1}.{2})
        '''                    End If
        '''                End If
        '''
        '''                Return _{0}By{3}
        '''            End Get
        '''            Se [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property HasAndBelongsToManyProperty() As String
            Get
                Return ResourceManager.GetString("HasAndBelongsToManyProperty", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to         Private _{1} As List(Of {0})
        '''        &lt;System.Xml.Serialization.XmlIgnore()&gt; _
        '''        Public Property {1}() As List(Of {0})
        '''            Get
        '''                If (_{1} Is Nothing) Then
        '''                    Dim lQuery As New {2}.{1}.Query
        '''
        '''                    lQuery.Where({2}.{1}.Columns.{3}).EqualsTo(Me.{4})
        '''
        '''                    _{1} = lQuery.FetchList
        '''
        '''                    If (_{1} Is Nothing) Then
        '''                        _{1} = New List(Of {0})
        '''                    End If
        '''                E [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property HasManyProperty() As String
            Get
                Return ResourceManager.GetString("HasManyProperty", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to #Region &quot;Join Class&quot;
        '''            Public Class JoinList
        '''                Inherits ActiveRecord.Query.QueryProperty
        '''
        '''{0}
        '''
        '''                Public Sub New(ByVal pQuery As Query)
        '''                    MyBase.New(pQuery)
        '''                End Sub
        '''            End Class
        '''#End Region.
        '''</summary>
        Friend Shared ReadOnly Property JoinList() As String
            Get
                Return ResourceManager.GetString("JoinList", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to         
        '''                Public ReadOnly Property {0}() As {0}.Query
        '''                    Get
        '''                        If Not (Query.Joins.ContainsKey(&quot;{0}&quot;)) Then
        '''                            Query.Joins(&quot;{0}&quot;) = New ActiveRecord.Query.Join(Schema(&quot;{1}&quot;), New {0}.Query)
        '''                        End If
        '''                        Return Query.Joins(&quot;{0}&quot;).ForeignQuery
        '''                    End Get
        '''                End Property.
        '''</summary>
        Friend Shared ReadOnly Property JoinProperty() As String
            Get
                Return ResourceManager.GetString("JoinProperty", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to         &apos;&apos;&apos; &lt;summary&gt;
        '''        &apos;&apos;&apos; {2}
        '''        &apos;&apos;&apos; &lt;/summary&gt;{3}
        '''        Public Property {0}() As {1}
        '''            Get
        '''                Return _{0}.Value
        '''            End Get
        '''            Set(ByVal value As {1})
        '''                _{0}.Value = value
        '''            End Set
        '''        End Property.
        '''</summary>
        Friend Shared ReadOnly Property PropertyWrapper() As String
            Get
                Return ResourceManager.GetString("PropertyWrapper", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to #Region &quot;QueryBuilder&quot;
        '''        {5} Class Query
        '''            Inherits AppSimplicity.ActiveRecord.Query.QueryBuilder
        '''
        '''            Private _SelectList As SelectColumnList
        '''            Public ReadOnly Property SelectList() As SelectColumnList
        '''                Get
        '''                    If (_SelectList Is Nothing) Then
        '''                        _SelectList = New SelectColumnList(Me)
        '''                    End If
        '''
        '''                    Return _SelectList
        '''                End Get
        '''            End Property
        '''
        '''        [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property QueryBuilderClassWrapper() As String
            Get
                Return ResourceManager.GetString("QueryBuilderClassWrapper", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Imports AppSimplicity
        '''
        '''Namespace {0}
        '''    Partial {8} Class {1}
        '''
        '''        Private Shared _Schema As ActiveRecord.Schema
        '''        Public Shared ReadOnly Property Schema() As ActiveRecord.Schema
        '''            Get
        '''                If (_Schema Is Nothing) Then
        '''                    _Schema = GetSchema(DataContext.Service, False)
        '''                End If
        '''                Return _Schema
        '''            End Get
        '''        End Property
        '''
        '''#Region &quot;Columns&quot;
        '''
        '''{5}
        '''
        '''#End Region
        '''
        '''#Region &quot;GetSchema&quot;
        '''
        '''        Public S [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SchemaWraper() As String
            Get
                Return ResourceManager.GetString("SchemaWraper", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to #Region &quot;Column Selection Class&quot;
        '''            Public Class SelectColumnList
        '''                Inherits ActiveRecord.Query.QueryProperty
        '''
        '''                Public Sub AddAll()
        '''                    Query.ColumnsList.Clear()
        '''
        '''{1}
        '''                End Sub
        '''
        '''                Public Sub SelectNone()
        '''                    Reset()
        '''                End Sub
        '''
        '''                Public Sub Reset()
        '''                    Query.ColumnsList.Clear()
        '''                End Sub
        '''
        '''                Public Sub Add(ByVal pColumn As { [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SelectColumnsClassWrapper() As String
            Get
                Return ResourceManager.GetString("SelectColumnsClassWrapper", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to             &apos;&apos;&apos; &lt;summary&gt;
        '''            &apos;&apos;&apos; Wraps the procedure call to [{0}] in the database.
        '''            &apos;&apos;&apos; &lt;/summary&gt;        
        '''            Public Shared Function {1}({2}) As DataAccess.CommandHelper
        '''
        '''                Dim lReturnValue As DataAccess.CommandHelper
        '''                Dim lCommand As New DataAccess.DataCommand
        '''
        '''                lCommand.SQLCommand = &quot;{0}&quot;
        '''                lCommand.CommandType = CommandType.StoredProcedure
        '''
        '''{3}
        '''
        '''                lReturnValue = New DataAccess.CommandHelper( [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SPFunctionWrapper() As String
            Get
                Return ResourceManager.GetString("SPFunctionWrapper", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.239
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
    Friend Class MappingDefinitions
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AppSimplicity.SchemaDiscovery.MappingDefinitions", GetType(MappingDefinitions).Assembly)
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
        '''  Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        '''  &lt;Type From=&quot;BIT&quot; To=&quot;Boolean&quot; /&gt;
        '''  &lt;Type From=&quot;BIGINT&quot; To=&quot;long&quot; /&gt;
        '''  &lt;Type From=&quot;INT&quot; To=&quot;int&quot; /&gt;
        '''  &lt;Type From=&quot;MEDIUM&lt;Definitions&gt;INT&quot; To=&quot;int&quot; /&gt;
        '''  &lt;Type From=&quot;SMALLINT&quot; To=&quot;short&quot; /&gt;
        '''  &lt;Type From=&quot;TINYINT&quot; To=&quot;sbyte&quot; /&gt;
        '''  &lt;Type From=&quot;BIGINT UNSIGNED&quot; To=&quot;ulong&quot; /&gt;
        '''  &lt;Type From=&quot;INT UNSIGNED&quot; To=&quot;uint&quot; /&gt;
        '''  &lt;Type From=&quot;MEDIUMINT UNSIGNED&quot; To=&quot;uint&quot; /&gt;
        '''  &lt;Type From=&quot;SMALLINT UNSIGNED&quot; To=&quot;ushort&quot; /&gt;
        '''  &lt;Type From=&quot;TINYINT UNSIGNED&quot; To=&quot;byte&quot; /&gt;
        '''  &lt;Type  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property MySQL_VBNet() As String
            Get
                Return ResourceManager.GetString("MySQL_VBNet", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        '''&lt;Definitions&gt;
        '''  &lt;Type SQLType=&quot;bigint&quot; CLRTargetType=&quot;Int64&quot; /&gt;
        '''  &lt;Type SQLType=&quot;binary&quot; CLRTargetType=&quot;Object&quot; /&gt;
        '''  &lt;Type SQLType=&quot;bit&quot; CLRTargetType=&quot;Boolean&quot; /&gt;
        '''  &lt;Type SQLType=&quot;char&quot; CLRTargetType=&quot;String&quot; /&gt;
        '''  &lt;Type SQLType=&quot;datetime&quot; CLRTargetType=&quot;DateTime&quot; /&gt;
        '''  &lt;Type SQLType=&quot;decimal&quot; CLRTargetType=&quot;Decimal&quot; /&gt;
        '''  &lt;Type SQLType=&quot;float&quot; CLRTargetType=&quot;Double&quot; /&gt;
        '''  &lt;Type SQLType=&quot;image&quot; CLRTargetType=&quot;Byte()&quot; /&gt;
        '''  &lt;Type SQLType=&quot;int&quot; CLRTargetType=&quot;Inte [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property SQLServer_VBNet() As String
            Get
                Return ResourceManager.GetString("SQLServer_VBNet", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

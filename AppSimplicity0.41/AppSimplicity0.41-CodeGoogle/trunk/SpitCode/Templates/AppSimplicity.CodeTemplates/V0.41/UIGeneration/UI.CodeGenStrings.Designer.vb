﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3053
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
    Friend Class UI_CodeGenStrings
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AppSimplicity.CodeTemplates.UI.CodeGenStrings", GetType(UI_CodeGenStrings).Assembly)
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
        '''  Looks up a localized string similar to Partial Class Edit_[$ClassName]
        '''    Inherits UI.EditItemWebControl
        '''
        '''    Public Event OnCancel()
        '''
        '''    Protected Sub LayoutSelector_OnLayoutSelection(ByVal pLayout As UI.EditItemWebControl.Layout) Handles LayoutSelector.OnLayoutSelection
        '''        Me.SetLayoutMode(pLayout)
        '''    End Sub
        '''
        '''    &apos;&apos;&apos; &lt;summary&gt;
        '''    &apos;&apos;&apos; Inicializa la forma con un objeto existente previamente instanciado
        '''    &apos;&apos;&apos; &lt;/summary&gt;
        '''    &apos;&apos;&apos; &lt;param name=&quot;pItem&quot;&gt;Indica el objeto con el que se llenará la forma&lt;/param&gt;
        '''    Public Sub Fill [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property EditItem_ASCvb() As String
            Get
                Return ResourceManager.GetString("EditItem_ASCvb", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;%@ Control Language=&quot;VB&quot; AutoEventWireup=&quot;false&quot; CodeFile=&quot;Edit_[$ClassName].ascx.vb&quot; Inherits=&quot;Edit_[$ClassName]&quot; %&gt;
        '''
        '''&lt;%@ Register src=&quot;../../../WebControls/Application/Edit/TextEditControl.ascx&quot; tagname=&quot;TextEditControl&quot; tagprefix=&quot;TextEditControl&quot; %&gt;
        '''&lt;%@ Register src=&quot;../../../WebControls/Application/Edit/TextAreaEditControl.ascx&quot; tagname=&quot;TextAreaEditControl&quot; tagprefix=&quot;TextAreaEditControl&quot; %&gt;
        '''&lt;%@ Register src=&quot;../../../WebControls/Application/Edit/NumericEditControl.ascx&quot; tagname=&quot;NumericEditContr [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property EditItem_ASCX() As String
            Get
                Return ResourceManager.GetString("EditItem_ASCX", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;%@ Page Language=&quot;VB&quot; MasterPageFile=&quot;~/UI/PageThemes/Default/Layout/MasterPage.master&quot; AutoEventWireup=&quot;false&quot; CodeFile=&quot;Edit[$ClassName].aspx.vb&quot; Inherits=&quot;[$GeneratedNamespace]_[$PluralClassName]_Edit[$ClassName]&quot; title=&quot;Crear / Editar [$ClassName]&quot; %&gt;
        '''&lt;%@ OutputCache Duration=&quot;1&quot; VaryByParam=&quot;FondoId&quot; NoStore=&quot;true&quot; %&gt;
        '''
        '''&lt;%@ Register src=&quot;../../../CustomControls/[$GeneratedNamespace]/[$PluralClassName]/Edit_[$ClassName].ascx&quot; tagname=&quot;Edit_[$ClassName]&quot; tagprefix=&quot;ctrl[$ClassName]&quot; %&gt;
        '''
        '''&lt;asp:Content [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property EditItem_ASPX() As String
            Get
                Return ResourceManager.GetString("EditItem_ASPX", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Partial Class [$GeneratedNamespace]_[$PluralClassName]_Edit[$ClassName]
        '''    Inherits UI.BasePage
        '''
        '''    Public Overrides Sub Initialize()
        '''
        '''    End Sub
        '''
        '''    Protected Sub ctrl_Edit[$ClassName]_OnCancel() Handles ctrl_Edit[$ClassName].OnCancel
        '''        If (Me.ctrl_Edit[$ClassName].EditMode = UI.EditItemWebControl.EditModes.CreateNew) Then
        '''            Response.Redirect(&quot;List[$PluralClassName].aspx&quot;)
        '''        Else
        '''            Response.Redirect(&quot;View[$ClassName].aspx&quot;)
        '''        End If
        '''    End Sub
        '''End Cl [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property EditItem_ASPXvb() As String
            Get
                Return ResourceManager.GetString("EditItem_ASPXvb", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;asp:CheckBoxField DataField=&quot;[$TableName].[$ColumnName]&quot; HeaderText=&quot;[$GridCaption]&quot; SortExpression=&quot;[$TableName].[$ColumnName]&quot; &gt;
        '''    &lt;ItemStyle Width=&quot;62px&quot;  /&gt;
        '''&lt;/asp:CheckBoxField&gt;.
        '''</summary>
        Friend Shared ReadOnly Property GridColumn_Boolean() As String
            Get
                Return ResourceManager.GetString("GridColumn_Boolean", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;asp:BoundField DataField=&quot;[$TableName].[$ColumnName]&quot; HeaderText=&quot;[$GridCaption]&quot; DataFormatString=&quot;{0:dd/MMM/yyyy hh:mmt}m&quot;  SortExpression=&quot;[$TableName].[$ColumnName]&quot;  &gt;                            
        '''&lt;ItemStyle Width=&quot;160px&quot; /&gt;
        '''&lt;/asp:BoundField&gt;.
        '''</summary>
        Friend Shared ReadOnly Property GridColumn_DateTime() As String
            Get
                Return ResourceManager.GetString("GridColumn_DateTime", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;asp:BoundField DataField=&quot;[$TableName].[$ColumnName]&quot; HeaderText=&quot;[$GridCaption]&quot; SortExpression=&quot;[$TableName].[$ColumnName]&quot; DataFormatString=&quot;{0:##,##0.00}&quot; &gt;
        '''&lt;ItemStyle Width=&quot;[$Width]px&quot; Wrap=&quot;False&quot; HorizontalAlign=&quot;Left&quot; /&gt;
        '''&lt;/asp:BoundField&gt;.
        '''</summary>
        Friend Shared ReadOnly Property GridColumn_Decimal() As String
            Get
                Return ResourceManager.GetString("GridColumn_Decimal", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;asp:BoundField DataField=&quot;[$TableName].[$ColumnName]&quot; HeaderText=&quot;[$GridCaption]&quot; SortExpression=&quot;[$TableName].[$ColumnName]&quot; &gt;
        '''&lt;ItemStyle Width=&quot;[$Width]px&quot; Wrap=&quot;False&quot; HorizontalAlign=&quot;Left&quot; /&gt;
        '''&lt;/asp:BoundField&gt;.
        '''</summary>
        Friend Shared ReadOnly Property GridColumn_Numeric() As String
            Get
                Return ResourceManager.GetString("GridColumn_Numeric", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;asp:BoundField DataField=&quot;[$TableName].[$ColumnName]&quot; HeaderText=&quot;[$GridCaption]&quot; SortExpression=&quot;[$TableName].[$ColumnName]&quot;  &gt;
        '''&lt;ItemStyle Width=&quot;[$Width]px&quot; /&gt;
        '''&lt;/asp:BoundField&gt;.
        '''</summary>
        Friend Shared ReadOnly Property GridColumn_String() As String
            Get
                Return ResourceManager.GetString("GridColumn_String", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;%@ Control Language=&quot;VB&quot; AutoEventWireup=&quot;false&quot; CodeFile=&quot;GridView_[$PluralClassName].ascx.vb&quot; Inherits=&quot;[$GeneratedNamespace]_[$PluralClassName]_GridView[$ClassName]&quot; %&gt;
        '''
        '''&lt;table width=&quot;100%&quot; align=&quot;center&quot; border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; &gt;
        '''&lt;tr&gt;
        '''&lt;td valign=&quot;top&quot; &gt;
        '''    
        '''&lt;div style=&quot;width:950px;height:500px;overflow:auto;&quot; class=&quot;GridPanel&quot; id=&quot;GridPanel&quot; runat=&quot;server&quot;&gt;                  
        '''&lt;asp:UpdatePanel ID=&quot;AjaxGridViewPanel&quot; runat=&quot;server&quot;&gt;
        '''&lt;ContentTemplate&gt;
        '''&lt;asp:GridView ID=&quot;DataGrid [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property GridViewASCX() As String
            Get
                Return ResourceManager.GetString("GridViewASCX", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Partial Class [$GeneratedNamespace]_[$PluralClassName]_GridView[$ClassName]
        '''    Inherits UI.GenericGridControl
        '''
        '''End Class.
        '''</summary>
        Friend Shared ReadOnly Property GridViewASCXvb() As String
            Get
                Return ResourceManager.GetString("GridViewASCXvb", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;%@ Control Language=&quot;VB&quot; AutoEventWireup=&quot;false&quot; CodeFile=&quot;ListManager_[$PluralClassName].ascx.vb&quot; Inherits=&quot;[$GeneratedNamespace]_[$PluralClassName]_ListManager_[$PluralClassName]&quot; %&gt;
        '''
        '''&lt;%@ Register src=&quot;GridView_[$PluralClassName].ascx&quot; tagname=&quot;GridView_[$PluralClassName]&quot; tagprefix=&quot;GridView[$PluralClassName]&quot; %&gt;
        '''&lt;%@ Register src=&quot;../../../WebControls/Application/Common/InLineAlert.ascx&quot; tagname=&quot;InLineAlert&quot; tagprefix=&quot;InLineAlert&quot; %&gt;
        '''&lt;%@ Register src=&quot;../../../WebControls/Application/Filter/FindBy [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property ListManager_ASCX() As String
            Get
                Return ResourceManager.GetString("ListManager_ASCX", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to         Try
        '''            Me.{0}.ValidateInput()
        '''        Catch ex As Exception
        '''            lValidationErrors.Add(ex.Message)
        '''        End Try.
        '''</summary>
        Friend Shared ReadOnly Property RunValidationCodeBlock() As String
            Get
                Return ResourceManager.GetString("RunValidationCodeBlock", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;%@ Control Language=&quot;VB&quot; AutoEventWireup=&quot;false&quot; CodeFile=&quot;Edit_Toolbar_{0}.ascx.vb&quot; Inherits=&quot;Edit_Toolbar_{0}&quot; %&gt;
        '''
        '''&lt;div class=&quot;toolbar&quot;&gt;
        '''    &lt;table border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;5&quot; width=&quot;10&quot;&gt;
        '''        &lt;tr&gt;                
        '''            &lt;td&gt;&lt;asp:Button ID=&quot;btnSave&quot; runat=&quot;server&quot; Text=&quot;guardar&quot; /&gt;&lt;/td&gt;        
        '''            &lt;td&gt;&lt;asp:Button ID=&quot;btnSaveNew&quot; runat=&quot;server&quot; Text=&quot;guardar y crear nuevo&quot; /&gt;&lt;/td&gt;                            
        '''            &lt;td&gt;&lt;asp:Button ID=&quot;btnCancel&quot; runat=&quot;server&quot; T [rest of string was truncated]&quot;;.
        '''</summary>
        Friend Shared ReadOnly Property ToolBarASCX() As String
            Get
                Return ResourceManager.GetString("ToolBarASCX", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Partial Class Edit_Toolbar_{0}
        '''    Inherits UI.EditToolbarControl
        '''
        '''End Class.
        '''</summary>
        Friend Shared ReadOnly Property ToolBarASCXvb() As String
            Get
                Return ResourceManager.GetString("ToolBarASCXvb", resourceCulture)
            End Get
        End Property
    End Class
End Namespace

<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Edit_Sitio.ascx.vb" Inherits="UI_CustomControls_WebInternet_Sitios_Edit_Sitio" %>

<%@ Register src="../../../WebControls/Application/Edit/TextEditControl.ascx" tagname="TextEditControl" tagprefix="uc1" %>
<%@ Register src="../../../WebControls/Application/Edit/NumericEditControl.ascx" tagname="NumericEditControl" tagprefix="uc3" %>
<%@ Register src="../../../WebControls/Application/Edit/CheckBoxEditControl.ascx" tagname="CheckBoxEditControl" tagprefix="uc2" %>
<%@ Register src="../../../WebControls/Application/Edit/DatePickerEditControl.ascx" tagname="DatePickerEditControl" tagprefix="uc4" %>
<%@ Register src="../../../WebControls/Application/Edit/DDLEditControl.ascx" tagname="DDLEditControl" tagprefix="uc5" %>
<%@ Register src="../../../WebControls/Application/Form/FormLayoutSelector.ascx" tagname="FormLayoutSelector" tagprefix="uc6" %>
<%@ Register src="../../../WebControls/Application/Common/InLineAlert.ascx" tagname="InLineAlert" tagprefix="uc7" %>
<%@ Register src="Edit_Toolbar_Sitio.ascx" tagname="Edit_Toolbar_Sitio" tagprefix="uc8" %>

<table width="95%" cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td width="100%" valign="middle">
                        Crear / Editar Sitio
                    </td>
                    <td valign="middle">
                       <uc6:FormLayoutSelector ID="LayoutSelector" runat="server" />                       
                    </td>
                </tr>
            </table>
        </td>
    </tr>    
    <tr>
        <td>
            <uc8:Edit_Toolbar_Sitio ID="ToolBarTop" runat="server" />            
        </td>
    </tr>
    <tr>
        <td>            
            <uc7:InLineAlert ID="FormAlert" runat="server" />
        </td>
    </tr>
    <tr>
        <td>            
            <table border="0" width="95%" align="center" cellpadding="5" cellspacing="0">
                <tr>
                    <td valign="top">
                    
                        <div id="FormLayout" runat="server" >
                        
                            <ul class="form-layout">
                                <li>
                                    <uc1:TextEditControl ID="ctrlId" runat="server" Label="Id" Width="120" />                    
                                </li>
                                <li>
                                    <uc1:TextEditControl ID="ctrlNombre" runat="server" Label="Nombre" Width="200"/>                    
                                </li>
                                <li>
                                    <uc5:DDLEditControl ID="DDLEditControl1" runat="server" Label="Seleccione un Item:" />
                                </li>
                                <li>
                                    <uc1:TextEditControl ID="TextEditControl2" runat="server" Label="Nombre" Width="200"/>                    
                                </li>
                                <li>
                                    <uc1:TextEditControl ID="TextEditControl3" runat="server" Label="Id" Width="120" />                    
                                </li>
                                <li>
                                    <uc4:DatePickerEditControl ID="DatePickerEditControl1" runat="server" Label="DatePicker" Hint="que pasa si pones algo que sea verdaderamente largo en el hint del control." />                    
                                </li>
                                <li>
                                    <uc1:TextEditControl ID="TextEditControl5" runat="server" Label="Id" Width="120" />                    
                                </li>
                                <li>            
                                    <uc1:TextEditControl ID="TextEditControl6" runat="server" Label="Nombre" Width="400"/>                    
                                </li>
                                <li>
                                    <uc1:TextEditControl ID="TextEditControl8" runat="server" Label="Nombre" Width="300"/>                    
                                </li>
                                <li>
                                    <uc3:NumericEditControl ID="NumericEditControl1" runat="server" width="130" Label="Numeric"  />                                
                                </li>
                                <li>
                                    <uc2:CheckBoxEditControl ID="CheckBoxEditControl1" runat="server" Label="Selected" DisplayHint="true" />            
                                </li>
                            </ul>
                            
                        </div>                    
                    </td>
                </tr>
            </table>
            
        </td>
    </tr>
    <tr>
        <td>
            <uc8:Edit_Toolbar_Sitio ID="ToolBarBottom" runat="server" />                      
        </td>
    </tr>
</table>
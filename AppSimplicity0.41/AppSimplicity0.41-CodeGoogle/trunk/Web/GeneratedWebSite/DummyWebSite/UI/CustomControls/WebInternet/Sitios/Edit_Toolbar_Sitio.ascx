<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Edit_Toolbar_Sitio.ascx.vb" Inherits="UI_CustomControls_WebInternet_Sitios_Edit_Toolbar_Sitio" %>

<div class="toolbar">
    <table border="0" cellpadding="0" cellspacing="5" width="10">
        <tr>                
            <td><asp:Button ID="btnSave" runat="server" Text="guardar" /></td>        
            <td><asp:Button ID="btnSaveNew" runat="server" Text="guardar y crear nuevo" /></td>                            
            <td><asp:Button ID="btnCancel" runat="server" Text="cancelar" /></td>                            
            <td><asp:Button ID="btnDelete" runat="server" Text="eliminar" /></td>                            
            <td><asp:Button ID="btnNew" runat="server" Text="crear nuevo..." /></td>        
        </tr>
    </table>
</div>
<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FormLayoutSelector.ascx.vb" Inherits="UI_WebControls_Application_Form_FormLayoutSelector" %>

<table width="100" border="0" cellpadding="3" cellspacing="0" align="right">
    <tr>
        <td  nowrap="nowrap">
            Distribución:
        </td>
        <td>
            <asp:DropDownList ID="ddlFormLayout" runat="server" Width="80" 
                AutoPostBack="True" ></asp:DropDownList>
        </td>
    </tr>
</table>
  
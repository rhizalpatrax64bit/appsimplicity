<%@ Control Language="VB" AutoEventWireup="false" CodeFile="InLineAlert.ascx.vb" Inherits="UI_WebControls_Application_Common_InLineAlert" %>


<script type="text/javascript" language="javascript">
    
        function HideAlert () {               		    		       		    
		    $('#AlertContainer').slideToggle();
		 }    

</script>

<div id="AlertContainer" >
<table width="95%" border="0" cellspacing="0" cellpadding="10" align="center">
    <tr>
        <td>
            <div id="FormErrorMessage" class="form-alert" runat="server" >
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td class="form-alert-title">
  	            <table width="100%" cellpadding="3" border="0" cellspacing="0">
		            <tr>
			            <td>Información:</td>						
			            <td width="16"><a href="#" onclick="return HideAlert();"><img src="../../../../Assets/icons/close.gif" alt="cerrar" border="0" /></a></td>													
		            </tr>
	            </table>
              </td>
            </tr>
            <tr>
              <td><table width="100%" border="0" cellspacing="0" cellpadding="7">
                <tr>
                  <td width="16" valign="top"><img src="../../../../Assets/icons/warning.png" alt="informacion" width="16" height="16" /></td>
                  <td valign="top">Lo siguiente debe ser corregido en el formulario: <br />
                    <ul>
                      <li>uno</li>
                      <li>dos</li>
                      <li>tres</li>
                      <li>cuatro</li>
                  </ul>                            <p>verifique lo anterior y corrija. </p>
                  </td>
                </tr>
              </table></td>
            </tr>
            </table>
            </div>
        </td>
    </tr>
</table>
</div>



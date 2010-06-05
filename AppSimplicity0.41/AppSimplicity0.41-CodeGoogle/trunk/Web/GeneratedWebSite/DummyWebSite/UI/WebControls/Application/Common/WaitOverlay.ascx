<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WaitOverlay.ascx.vb" Inherits="UI_WebControls_Application_Common_WaitOverlay" %>

<script language="javascript" type="text/javascript">
    
   		 function block () {               		 
   		    setTimeout("showOverlay()", 10);		    		       		    
   		    
		    return true;
		 }
		 
		 function unblock() {		    
		    setTimeout("hideOverlay()", 250);		    		    
		    return true;
		 }
		 
		 function hideOverlay() {
		    $('#<%= MessageOverlay.ClientId %>').removeClass().addClass("WaitOverlayOff");   		 
		    $.unblockUI(); 		 
		 }
		 
		 function showOverlay () {	 
		    
		 
		    $('#<%= MessageOverlay.ClientId %>').removeClass().addClass("WaitOverlayOn");   		 		    
		    $.blockUI({ message: $('#<%= MessageOverlay.ClientId %>') }); 
		    
		    
		 }


</script>

<asp:Panel ID="MessageOverlay" runat="server" CssClass="WaitOverlayOff" >
   <table width="50" cellpadding="7"align="center" >
    <tr>
        <td width="10" nowrap="nowrap">
            <img alt="espere..." src="../../../../Assets/images/ajax-loader.gif" /></td>
        <td nowrap="nowrap">Por favor espere...</td>
    </tr>
   </table>
</asp:Panel>

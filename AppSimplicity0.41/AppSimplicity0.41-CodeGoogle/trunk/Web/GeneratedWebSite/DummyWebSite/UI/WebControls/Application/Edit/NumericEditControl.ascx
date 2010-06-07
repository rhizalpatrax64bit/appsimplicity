﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NumericEditControl.ascx.vb" Inherits="UI_WebControls_Application_Edit_NumericEditControl" %>

<script type="text/javascript" language="javascript">

    $(function(){ 						
    
			$('#<%= Me.txtText.ClientId %>').focus( function(){ 
			
			    //$('#Hint<%= Me.ClientId %>').
			    
			    //var options = {};
			    //'slide', options, 500
    
                $('#Hint<%= Me.ClientId %>').show();
			    
			    $('#<%= Me.Container.ClientId %>').removeClass('control-container-off');
			    $('#<%= Me.Container.ClientId %>').addClass('control-container-on');
				
		    }); 
		    
		    $('#<%= Me.txtText.ClientId %>').blur( function(){ 
			
			    $('#Hint<%= Me.ClientId %>').hide();
			    
			    $('#<%= Me.Container.ClientId %>').removeClass('control-container-on');
			    $('#<%= Me.Container.ClientId %>').addClass('control-container-off');
				
		    }); 			
		    		
		});			    

</script>
<div id="Container" runat="server" class="control-container-off">

<table width="98%" cellpadding="0" border="0">
    <tr>
        <td class="formlabel">
            <asp:Label ID="lblControlLabel" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtText" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr runat="server" id="ControlHint">
        <td valign="top" style="height:25px;">
            <div class="controlhint" id="Hint<%= Me.ClientId %>" style="display:none;" >
                    <asp:Label ID="lblHint" runat="server" Text=""></asp:Label>
            </div>      
        </td>
    </tr>
</table>
    
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMessageBox.ascx.cs" Inherits="Teach.UCMessageBox" %>
<asp:Literal ID="scripts" runat="server"></asp:Literal>
   <script type="text/javascript" >

		  function inicializar() {
			  $(document).ready(function () {
				  $("#<%=this.ClientID%>_dialogError").dialog({
					  modal: true
		  , height: 350
		  , width: 650
		  , buttons: {
			  Ok: function () {
				  $(this).dialog("close");
			  }
		  },

					  autoOpen: false
				  });

				  $("#botoncito").click(function () {
					  $("#<%=this.ClientID%>_dialogError").dialog("open");
					  return false;
				  });

			  });

		  }
		  function showMessage(msg, type) {

			  //document.getElementById('message').innerHTML = document.getElementById('<%=this.ClientID%>_miLiteral');
			  inicializar();
			  $(document).ready(function () {
				  $("#<%=this.ClientID%>_dialogError").dialog("open");
			  });
		  }

  </script>
 <div style="display:none">
  <input id="botoncito" value="opendialog" type="button" />
  
  <div id="dialogError" title="Mensaje" runat="server" >
	 <p>
		<span class="ui-icon ui-icon-notice" style="float:left; margin:0 7px 50px 0;"></span>
	</p>
	<div id="message">   <asp:Literal ID="miLiteral" runat="server">
	</asp:Literal></div> 
  </div>
  
  
</div>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=windows-1252" />
  <link rel="stylesheet" type="text/css" href="style/style.css" />

     <script type="text/javascript" src="style/jquery.min.js" ></script>
    <style>
        body {font-family:Arial, Helvetica, sans-serif; font-size:12px;}

        .fadein { position:relative; height:400px; width:600px; }
        .fadein img { position:absolute; left:0; top:0; }
        .auto-style1 {
            color: #99CC00;
        }
    </style>
    <script>
        $(function () {
            $('.fadein img:gt(0)').hide();
            setInterval(function () { $('.fadein :first-child').fadeOut().next('img').fadeIn().end().appendTo('.fadein'); }, 3000);
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
   <div id="main">
    <div id="header">
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
            <h1><a href="#">Personalizing Education<span class="logo_colour">Through Gamified Learning</span></a></h1>
          <h2>Login. Register. Test.</h2>
        </div>
      </div>
      <div id="menubar">
        <ul id="menu">
          <!-- put class="selected" in the li tag for the selected page - to highlight which page you're on -->
          <li class="selected"><a href="Default.aspx">Home</a></li>
         
        </ul>
      </div>
    </div>
    <div id="content_header"></div>
    <div id="site_content">
     
	  <div id="sidebar_container">
        <div class="sidebar">
          <div class="sidebar_top"></div>
          <div class="sidebar_item">
            <!-- insert your sidebar items here -->
           <div>
               <p>User Type</p>
               <asp:DropDownList ID="DropDownList1" CssClass="sinput" runat="server">
                   <asp:ListItem Value="null">admin</asp:ListItem>
                   <asp:ListItem>staff</asp:ListItem>
                   <asp:ListItem>student</asp:ListItem>
               </asp:DropDownList>
               <br /><br />
    <p>Username:</p>
        <asp:TextBox ID="txtusername" CssClass="sinput" runat="server"></asp:TextBox>
        <p>Password:</p>
        <asp:TextBox ID="txtpassword" CssClass="sinput" TextMode="Password" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="btnlogin" runat="server"  CssClass="submit" Text="Login" OnClick="btnlogin_Click" />
    </div>
              <br />
          <a href="Registration.aspx">Click for Register.</a>
          </div>
            <div class="sidebar_base"></div>
        </div>
       
       
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1>Welcome to Personalized Education and Evaluation through Gamified Learning</h1>
         <div class="fadein">
        <img alt="" src="style/sleeper4.jpg" height="400px" width="600px" />
        <img alt="" src="style/sleeper4.jpg" height="400px" width="600px" />
        <img alt="" src="style/sleeper4.jpg" height="400px" width="600px" />
        <img alt="" src="style/oe1.jpg" height="400px" width="600px" />
        <img alt="" src="style/oe2.jpg" height="400px" width="600px" />
        <img alt="" src="style/oe3.jpg" height="400px" width="600px" />
        <img alt="" src="style/oe4.jpg" height="400px" width="600px" />
           
      </div>
    </div>
         </div>
    <div id="content_footer"></div>
 
       </div>
    </form>
    <div id="footer">
        <p>Designed by <span class="auto-style1">INFT 44</span></p>
    
    </div>
 
       </body>
</html>

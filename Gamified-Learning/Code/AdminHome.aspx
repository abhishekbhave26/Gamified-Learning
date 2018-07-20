<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=windows-1252" />
  <link rel="stylesheet" type="text/css" href="style/style.css" />
    <style type="text/css">
        .auto-style1 {
            color: #99CC00;
        }
    </style>
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
          <li class="selected"><a href="AdminHome.aspx">Home</a></li>
          <li><a href="TeacherRegistration.aspx">Staff</a></li>
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
          
              <h2>Welcome: <asp:Label ID="Label1" runat="server" Text="" ForeColor="Tomato"></asp:Label></h2>
              <asp:Button ID="btnlogout" CssClass="submit" runat="server" Text="Logout" OnClick="btnlogout_Click" />

          </div>
            <div class="sidebar_base"></div>
        </div>
       
       
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1>Welcome to Personalized Education and Evaluation through Gamified Learning</h1>
          <asp:Panel ID="Panel1" runat="server">
              <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">

              </asp:GridView>
          </asp:Panel>
      </div>
    </div>
    <div id="content_footer"></div>
    <div id="footer">
         <p>Designed by <span class="auto-style1">INFT 44</span></p>
    
    </div>
  </div>

    </form>
</body>
</html>

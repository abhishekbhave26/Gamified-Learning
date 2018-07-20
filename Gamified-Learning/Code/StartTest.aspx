<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StartTest.aspx.cs" Inherits="StartTest" %>

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
          <li ><a href="StudentHome.aspx">Home</a></li>
         <li class="selected"><a href="StartTest.aspx">Test</a></li>
        </ul>
      </div>
    </div>
    <div id="content_header"></div>
    <div id="site_content">
     
	  <div id="sidebar_container">
       
       
       
          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                 Time Left : <asp:Timer runat="server" Interval="1000" OnTick="Unnamed1_Tick"></asp:Timer>
                 
                 <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                 <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
             </ContentTemplate>

          </asp:UpdatePanel>
      </div>
      <div id="content">
        <!-- insert the page content here -->
         
          <asp:Panel ID="Panel3" runat="server">
               <h2>Question : <asp:Label ID="Label7" runat="server" Text=""></asp:Label></h2>
          <h2><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h2>
               <asp:Label ID="Label10" runat="server" Text="Question ID"></asp:Label>
               <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
               <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
               </asp:RadioButtonList>
              
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnprevious" runat="server" CssClass="submit" OnClick="btnprevious_Click" Text="Previous" />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="Button1" runat="server" CssClass="submit" OnClick="Button1_Click" Text="Next" />
               <br />
               <p>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               </p>
          <asp:Panel ID="Panel1" runat="server">
          </asp:Panel>
          <br /><br />
              Questions Answered :
              <asp:Label ID="Label2" runat="server"></asp:Label>
              <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
               <asp:Label ID="Label4" runat="server"></asp:Label>
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


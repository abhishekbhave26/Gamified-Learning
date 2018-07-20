<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

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
        .auto-style2 {
            color: #FF0000;
        }
        .auto-style3 {
            font-size: small;
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
         <li class="selected"><a href="Test.aspx">Test</a></li>
            <li ><a href="studresultdis.aspx">Result</a></li>
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
           <h2>Welcome: <asp:Label ID="Label3" runat="server" Text="" ForeColor="Tomato"></asp:Label></h2>
              <asp:Button ID="btnlogout" CssClass="submit" runat="server" Text="Logout" OnClick="btnlogout_Click" />

              

          </div>
            <div class="sidebar_base"></div>
        </div>
       
      </div>
      <div id="content">
        <!-- insert the page content here -->
         
          <asp:Panel ID="Panel2" runat="server">
               <h2>
                  Branch: <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>&nbsp;
                   Sem: <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
               </h2>
               <p>
                   Select Subject</p>
               <asp:DropDownList ID="DropDownList2" CssClass="input" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                   <asp:ListItem Value="null">----Select----</asp:ListItem>
                   <asp:ListItem>spcc</asp:ListItem>
               </asp:DropDownList><br /><br />
              <h2>Your Selected Subject is: <asp:Label ID="Label1" runat="server" Text="NULL"></asp:Label></h2><span class="auto-style3"><strong>
               <br />
               </strong></span><span class="auto-style2"><span class="auto-style3">Instructions :<br /> * Once an option is selected and Next button is pressed, the answer cannot be changed.<br /> * This test is adaptive in nature with increasing level of difficulty.<br /> * A total of 10 questions are to be answered in 90 seconds ie 1 minute and 30 seconds.The timer will start as soon as you click on the below button.<br /> * For each correct answer you get 2 marks and for each wrong answer 1 mark will be deducted.<br /> </span></span><br />
               <br />
               <asp:Button ID="Button1" runat="server"  CssClass="submit" Text="Start Test Now" OnClick="Button1_Click" />
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


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

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
         
              <br />
        
          </div>
            <div class="sidebar_base"></div>
        </div>
       
       
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1>Welcome to Personalized Education and Evaluation through Gamified Learning</h1>
        <p>Name*</p><asp:TextBox CssClass="input" ID="txtname" runat="server"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="Name is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
          <br /><br />
          <p>Username*</p>  <asp:TextBox  CssClass="input" ID="txtusername" runat="server"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtusername" ErrorMessage="Username is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
          <br /><br />
          <p>Password*</p><asp:TextBox ID="txtpassword" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
          <br /><br />
          <p>Confirm Password</p><asp:TextBox ID="txtconfirmpassword" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword" ErrorMessage="Both passwords should be same" ForeColor="#CC0000"></asp:CompareValidator>
          <br /><br />
          <p>Email*</p>  <asp:TextBox ID="txtemail" CssClass="input" runat="server"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="You must enter a valid Email ID" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
          <br /><br />
          <p>Mobile*</p>  <asp:TextBox ID="txtmobile" CssClass="input" runat="server" MaxLength="10" TextMode="Phone"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtmobile" ErrorMessage="Number is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
          <br /><br />
          <p>Semester*</p>
          <asp:DropDownList ID="ddlsem" CssClass="input" runat="server"> <%--OnSelectedIndexChanged="ddlsem_SelectedIndexChanged">--%>
              <asp:ListItem Value="null">----Select----</asp:ListItem>
              <asp:ListItem Value="1">I</asp:ListItem>
              <asp:ListItem Value="2">II</asp:ListItem>
              <asp:ListItem Value="3">III</asp:ListItem>
              <asp:ListItem Value="4">IV</asp:ListItem>
              <asp:ListItem Value="5">V</asp:ListItem>
              <asp:ListItem Value="6">VI</asp:ListItem>
              <asp:ListItem Value="7">VII</asp:ListItem>
              <asp:ListItem Value="8">VIII</asp:ListItem>
          </asp:DropDownList>
          <br /><br />
          <p>Branch*</p>
          <asp:DropDownList ID="ddlbranch" CssClass="input" runat="server">
              <asp:ListItem Value="null">----Select----</asp:ListItem>
              <asp:ListItem Value="comps">Computers</asp:ListItem>
              <asp:ListItem Value="it">InformationTechnology</asp:ListItem>
          </asp:DropDownList>
          <br /><br />
          <br /><br />
             <asp:Button ID="btnsumbit" runat="server" CssClass="submit" OnClick="btnsumbit_Click" Text="Submit" />
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

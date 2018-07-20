<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherRegistration.aspx.cs" Inherits="TeacherRegistration" %>

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
          <li ><a href="AdminHome.aspx">Home</a></li>
          <li class="selected"><a href="TeacherRegistration.aspx">Staff</a></li>
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
              
          </div>
            <div class="sidebar_base"></div>
        </div>
       
       
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1>Welcome to Personalized Education and Evaluation through Gamified Learning</h1>
          <h2>Staff Registration</h2>
            <p>Name*</p>         
           <asp:TextBox ID="TextBox1" CssClass="input" runat="server"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Name is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
          <p>UserName*</p>
          <asp:TextBox ID="TextBox2" CssClass="input" runat="server"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Username is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <p>Email*</p>
          <asp:TextBox ID="TextBox4" CssClass="input" runat="server"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="Enter a valid Email ID" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
          <p>Mobile*</p>
          <asp:TextBox ID="TextBox5" CssClass="input" runat="server" MaxLength="10" TextMode="Phone" CausesValidation="True"></asp:TextBox>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox5" ErrorMessage="10 digit number is expected" ForeColor="#CC0000"></asp:RequiredFieldValidator>
          <p>Semester*</p>   <asp:DropDownList CssClass="input" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
          </asp:DropDownList>  
          <p>Branch*</p>
          <asp:DropDownList ID="DropDownList2" CssClass="input" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
          </asp:DropDownList>
          <p>Subject*</p>
          <asp:DropDownList ID="DropDownList3" CssClass="input" runat="server">
          </asp:DropDownList>
          <br />
          Password*<br />
          <br />
          
          <asp:TextBox ID="TextBox3" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>

          <br />
          Confirm Password*<br />
          <br />
          
          <asp:TextBox ID="TextBox6" CssClass="input" runat="server" TextMode="Password"></asp:TextBox>

          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox6" ErrorMessage="Password mismatch" ForeColor="#CC0000"></asp:CompareValidator>

          <br /><br />
          <asp:Button ID="Button1" CssClass="submit" runat="server" Text="Submit" OnClick="Button1_Click" />
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>OTP</p>
        <asp:TextBox ID="txtotp" runat="server"></asp:TextBox>
        <asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" />
    </div>
    </form>
</body>
</html>

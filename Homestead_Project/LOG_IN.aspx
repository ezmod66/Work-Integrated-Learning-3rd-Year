<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOG_IN.aspx.cs" Inherits="Homestead_Project.LOG_IN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="CSS_SHEET.css" type="text/css" rel="stylesheet" />
</head>
<body  style="background: url(back.jpg) fixed;">
    <div class="login-box">
        <img src="LogInAvatar.png" class="avatar"/>
            <h2>Login Here!</h2>
        <form runat="server">
            <asp:Label Text="Email:" CssClass="lblEmail" runat="server"/>
            <asp:TextBox ID="txtUsername" CssClass="txtEmail" runat="server"  />
      
            <asp:Label Text="Password:" CssClass="lblPassword" runat="server"/>
            <asp:TextBox ID="txtPassword" CssClass="txtPassword" runat="server" />
            <asp:Button ID="btnLogIn" CssClass="btnLogIn" runat="server" Text="Log In" Onclick="Log_In"/>
            
            <asp:Label ID="txtErrorMessage" runat="server" Text = "Incorrect Username or Password" Visible="False" ForeColor="Red" />
        </form>
    </div>
 
</body>
</html>



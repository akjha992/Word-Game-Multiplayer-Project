<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox">
    <h1>Lets Make Fool</h1>
        <div runat="server" id="error">
        </div>
        <asp:TextBox CssClass="mytxtid" ID="id" onfocusout="outfocus();" onfocus="this.value=''" runat="server">ID?</asp:TextBox><br />
        <asp:TextBox CssClass="mytxtpass" ID="pass" onfocusout="outfocus();" onfocus="this.value=''" runat="server">PASS?</asp:TextBox><br />
        <asp:Button  OnClientClick="return loginfun();" CssClass="chosenButton" ID="login" runat="server" Text="Login" OnClick="login_Click" /><br />
        <asp:Button OnClientClick="return signupfun();" CssClass="chosenButton" ID="signup" runat="server" Text="Sign Up" OnClick="signup_Click" />
        </div>
        
    </form>
    <script src="default.js"></script>
</body>
</html>

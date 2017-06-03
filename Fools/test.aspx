<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox ">
        <span class="code">question</span> <br /><asp:TextBox CssClass="answer" ID="question" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        <span class="code">answer</span><br /><asp:TextBox CssClass="answer" ID="answer" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        
    </div>
        <div class="mainbox"><asp:Button CssClass="chosenButton"  ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" /></div>
    </form>
</body>
</html>

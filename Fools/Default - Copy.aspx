<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default - Copy.aspx.cs" Inherits="_Default" %>

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
        <input type="submit" name="Button1" value="Create" onclick="showme(); return false;" id="Button1" class="chosenButton" /><br />
        <asp:Button CssClass="chosenButton" ID="Button2" runat="server" Text="Join" />
        <asp:Label  CssClass="labels after" ID="l2" runat="server"  Text="Enter Game Code"></asp:Label><br />
        <asp:TextBox CssClass="mytxt after" ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button CssClass="chosenButton after" ID="Button4" runat="server" Text="Join"  />
        </div>
    </form>
    <script src="master.js"></script>
</body>
</html>

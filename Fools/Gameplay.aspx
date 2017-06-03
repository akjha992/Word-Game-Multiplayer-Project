<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gameplay.aspx.cs" Inherits="Gameplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox">
    <h1 id ="question_label" runat="server">question</h1>
        <asp:TextBox ID="TextBox1" CssClass="answer" runat="server" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button CssClass="chosenButton" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"  /><br />
    </div>
    </form>
    <script src="master.js"></script>
</body>
</html>

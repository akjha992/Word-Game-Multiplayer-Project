<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox">
    <h1>Your Code is </h1>
        <asp:Label ID="Label1" CssClass="code" runat="server" Text="XYZ"></asp:Label>
        <asp:Label ID="Label2" runat="server" CssClass="count" Text="Players Joined - "></asp:Label><br />
       <div class="count"> <asp:PlaceHolder ID="PlaceHolder1"  runat="server"></asp:PlaceHolder></div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>

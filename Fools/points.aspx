<%@ Page Language="C#" AutoEventWireup="true" CodeFile="points.aspx.cs" Inherits="points" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox">
    <h1>Results</h1>
       
        <div runat="server" id="gotpsyched">
                
        </div>
         <asp:Label ID="Label2" runat="server" CssClass="count" Text="Round - "></asp:Label><br />
         <div class="count"> <asp:PlaceHolder ID="PlaceHolder1"  runat="server"></asp:PlaceHolder></div>
        <asp:Button CssClass="chosenButton " ID="Button1" runat="server" Text="Continue" OnClick="Button1_Click" />
        </div>
        
    </form>
    <script src="master.js"></script>
</body>
</html>

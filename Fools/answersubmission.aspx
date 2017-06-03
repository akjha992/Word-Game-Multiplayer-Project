<%@ Page Language="C#" AutoEventWireup="true" CodeFile="answersubmission.aspx.cs" Inherits="answersubmission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox">
        
    <h1>Choose the correct answer </h1>
        <div id="error">
            
        </div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </form>
    <script src="anssub.js"></script>
</body>
</html>
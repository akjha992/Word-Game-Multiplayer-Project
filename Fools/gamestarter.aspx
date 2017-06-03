<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gamestarter.aspx.cs" Inherits="_Default" %>

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
        <div id="error">
            
        </div>
        <div id="logo" ></div>
        <asp:Label CssClass="mytxtname" ID="username" runat="server" Text="Label"></asp:Label><br />
        <input type="submit" name="Button1" value="Create" onclick="showme(); return false;" id="Button1" class="chosenButton " /><br />
        <input type="submit" name="Button2" value="Join" onclick="showme2(); return false;" id="Button2" class="chosenButton" /><br />
        <asp:Label  CssClass="labels after" ID="l1" runat="server"  Text="No of Players"></asp:Label><br />
       
        <asp:DropDownList onchange="getcreatebutton();" CssClass="mylist after" ID="DropDownList1" runat="server">
            <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button CssClass="chosenButton after" ID="Button3" runat="server" Text="Create" OnClick="Button3_Click" /><br />

        <input type="submit" name="back" value="Back" onclick="init(); return false;" id="back1" class="backbutton1" />

         <asp:Label  CssClass="labels after2" ID="l2" runat="server"  Text="Enter Game Code"></asp:Label><br />
        <asp:TextBox CssClass="mytxt after2" ID="TextBox1" onclick="this.value=''" runat="server"></asp:TextBox>
        <br />
        <asp:Button CssClass="chosenButton after2" ID="Button4" runat="server" Text="Join" OnClick="Button4_Click"  /><br />
        
        <input type="submit" name="back" value="Back" onclick="init(); return false;" id="back2" class="backbutton2" />
        </div>
        
    </form>
    <script src="master.js"></script>
</body>
</html>

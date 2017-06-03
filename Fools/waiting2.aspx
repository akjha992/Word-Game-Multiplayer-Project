<%@ Page Language="C#" AutoEventWireup="true" CodeFile="waiting2.aspx.cs" Inherits="waiting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainbox">
    <h1 id="wait"  runat="server"> </h1>
        <div class="code">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" ViewStateMode="Enabled" runat="server">
                <ContentTemplate><asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder></ContentTemplate>
            <Triggers><asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" /></Triggers>
            </asp:UpdatePanel>
            
        </div>
        <asp:Timer ID="Timer1" runat="server" Interval="400" OnTick="Timer1_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>
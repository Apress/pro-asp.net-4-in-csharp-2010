<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageMap.aspx.cs" Inherits="ImageMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="CoverShot.png" HotSpotMode="PostBack"
            OnClick="ImageMap1_Click">
            <asp:RectangleHotSpot Top="41" Left="16" Bottom="285" Right="206" PostBackValue="Cover" />
            <asp:RectangleHotSpot Top="125" Left="475" Bottom="160" Right="659" PostBackValue="Name" />
            <asp:RectangleHotSpot Top="10" Left="222" Bottom="41" Right="671" PostBackValue="Subtitle" />
        </asp:ImageMap>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Style="font-size: x-large" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>

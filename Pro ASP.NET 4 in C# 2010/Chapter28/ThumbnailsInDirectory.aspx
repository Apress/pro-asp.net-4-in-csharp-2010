<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThumbnailsInDirectory.aspx.cs"
    Inherits="ThumbnailsInDirectory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


        <asp:Label ID="Label1" runat="server" Text="Directory:"></asp:Label>


        <asp:TextBox ID="txtDir" runat="server"></asp:TextBox>
        <br />


        <br />
        <asp:Button ID="Button1" runat="server" onclick="cmdShow_Click" 
            Text="Show Thumbnails" />
        <br />
        <asp:GridView ID="gridThumbs" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
            Font-Size="X-Small" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src='<%# GetImageUrl(Eval("FullName")) %>' />
                        <%# Eval("Name") %>
                        <hr />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>

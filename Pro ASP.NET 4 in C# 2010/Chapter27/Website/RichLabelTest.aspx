<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RichLabelTest.aspx.cs" Inherits="XmlLabelTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <apress:RichLabel ID="RichLabel1" runat="server" BackColor="#87BE00" 
            Width="778px">
            <Format HighlightTag="b" Type="Xml" />
        </apress:RichLabel>
        
        
    </div>
      
    </form>    
    </body>
</html>

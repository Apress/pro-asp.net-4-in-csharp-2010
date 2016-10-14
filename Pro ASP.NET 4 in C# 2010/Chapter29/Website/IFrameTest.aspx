<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IFrameTest.aspx.cs" Inherits="IFrameTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <iframe src="page.aspx" id="IFrame1" width="100%"
			runat="server" frameborder="yes" scrolling="no"></iframe>
    <iframe id="IFrame2" width="100%" height="300"
			src="IncrementalDownloadGrid.aspx" frameBorder="yes"
			runat="server"></iframe>	
    </div>
    </form>
</body>
</html>

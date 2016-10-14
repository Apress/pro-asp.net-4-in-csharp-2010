<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GradientTest.aspx.cs" Inherits="GradientTest" %>

<%@ Register TagPrefix="cc1" Namespace="CustomControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:GradientLabel id="GradientLabel1" runat="server" text="Test String" gradientcolorstart="MediumSpringGreen"
            gradientcolorend="RoyalBlue"></cc1:GradientLabel>
    </div>
    </form>
</body>
</html>

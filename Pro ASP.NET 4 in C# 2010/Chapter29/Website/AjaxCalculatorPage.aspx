<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxCalculatorPage.aspx.cs" Inherits="AjaxCalculatorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    var xmlRequest;
    
    function CreateXMLHttpRequest()
    {  
        try
        {
            // This works if XMLHttpRequest is part of JavaScript.
            xmlRequest = new XMLHttpRequest();
        }
        catch(err)
        {
            // Otherwise, the ActiveX object is required.
            xmlRequest = new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
    
    function CallServerForUpdate()
    {
       var txt1 = document.getElementById("txt1");
       var txt2 = document.getElementById("txt2");
    
       var url = "CalculatorCallbackHandler.ashx?value1=" + 
         txt1.value + "&value2=" + txt2.value;
       xmlRequest.open("GET", url);
       xmlRequest.onreadystatechange = ApplyUpdate;
       xmlRequest.send(null);
    }

    function ApplyUpdate()
    {
        // Check that the response was received successfully.
        if (xmlRequest.readyState == 4)
        {       
          if (xmlRequest.status == 200)
          {

            var lbl = document.getElementById("lblResponse");                 
          
            var response = xmlRequest.responseText;
 
            if (response == "-")
            {
                lbl.innerHTML = "You've entered invalid numbers.";
            }
            else
            {                
                var responseStrings = response.split(",");
                lbl.innerHTML = "The server returned the sum: " + 
                  responseStrings[0] + " at " + responseStrings[1];
            }
          }
        }
    }
</script>
</head>
<body onload="CreateXMLHttpRequest();">
    <form id="form1" runat="server">
    <div>
        <table style="width: 296px">
            <tr>
                <td style="width: 55px">
                    <img src="lava_lamp.gif" alt="Animated Lamp" /></td>
                <td style="font-size: x-small; width: 190px; font-family: Verdana">
                    This animated GIF won't pause, demonstrating that your page isn't posting back to
                    the server.</td>
            </tr>
        </table>
        <br />
        <br />
        Value 1:&nbsp;
        <asp:TextBox ID="txt1" runat="server" onKeyUp="CallServerForUpdate();"></asp:TextBox><br />
        Value 2:&nbsp;
        <asp:TextBox ID="txt2" runat="server" onKeyUp="CallServerForUpdate();"></asp:TextBox><br />
        
        <br />
        <asp:Label ID="lblResponse" runat="server" BackColor="#FFFFC0" BorderStyle="Groove"
            BorderWidth="2px" Height="8px" Style="padding-right: 10px; padding-left: 10px;
            padding-bottom: 10px; padding-top: 10px" Width="440px" Font-Bold="True" Font-Names="Verdana" Font-Size="Small">
        </asp:Label>
        </div>
    </form>
</body>
</html>

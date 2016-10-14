<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientSideBinding.aspx.cs" Inherits="ClientSideBinding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .sys-template {display:none}
    </style> 

    <script type="text/javascript">

       

        function GetSalesData() {        
            SalesDataService.GetSalesData(OnRequestComplete, OnError);
        }

        function OnRequestComplete(result) {
            
           var t= $create(Sys.UI.DataView,
           result, null, null,
           $get("productSalesTable"));
         //  t.set_data(result);
        }

        function OnTimeout(result) {
           // var lbl = document.getElementById("lblInfo");
           // lbl.innerHTML = "<b>Request timed out.</b>";
        }

        function OnError(result) {
         //   var lbl = document.getElementById("lblInfo");
          //  lbl.innerHTML = "<b>" + result.get_message() + "</b>";

        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">    
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/SalesDataService.asmx"   />
            </Services>
        </asp:ScriptManager>
    </div>
    </form>

    <table id="productSalesTable" border="1" class="sys-template">         
        <tr>
          <td>{{Product}}</td>
          <td>{{SalesTotal}}</td>
          <td>{{DateGenerated}}</td>
        </tr>        
    </table>
    <span onclick="GetSalesData()">Refresh</span>

    <script>

        var bloggers = [{ FirstName: "Piyush", LastName: "Shah", Url: "http://blogs.msdn.com/shahpiyush" },

            { FirstName: "Jon", LastName: "Gallant", Url: "http://blogs.msdn.com/jongallant" },

            { FirstName: "Scott", LastName: "Guthrie", Url: "http://webblogs.asp.com/scottgu"}]        

</script>

<div id="authorsTemplate" sys:attach="dataview" dataview:data="{{bloggers}}">

    <ul>

        <li>First Name: {{ FirstName }}</li>

        <li>Last Name: {{LastName}}</li>

        <li>Url: <a href="{{Url}}">{{Url}}</a></li>

    </ul>
</div>


</body>
</html>

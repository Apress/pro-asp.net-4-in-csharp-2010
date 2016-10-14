<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebServiceCallback.aspx.cs" Inherits="WebServiceCallback" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
<script type="text/javascript">
 
 function GetTerritories(regionID)
 {
    TerritoriesService.GetTerritoriesInRegion(regionID, 
      OnRequestComplete, OnError);
 }
 
 function OnRequestComplete(result)
 {
     var lstTerritories = document.getElementById("lstTerritories");
     lstTerritories.innerHTML = "";
     
     for (var n = 0; n < result.length; n++)
     {
         var option = document.createElement("option");
         option.value = result[n].ID;
         option.innerHTML = result[n].Description;
         lstTerritories.appendChild(option);
      }
  }

 function OnTimeout(result)
 {
     var lbl = document.getElementById("lblInfo");
     lbl.innerHTML = "<b>Request timed out.</b>";
 } 
 
 function OnError(result)
 {
     var lbl = document.getElementById("lblInfo");
     lbl.innerHTML = "<b>" + result.get_message() + "</b>";

     // Can also use this code.
     //lbl.innerHTML += result.get_stackTrace();
 } 
</script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/TerritoriesService.asmx"  />
            </Services>
        </asp:ScriptManager>
        
      <div style="font-family:Verdana;font-size:small ">
        Choose a Region, and then a Territory:<br />
        <br />
        <asp:DropDownList ID="lstRegions" Runat="server" Width="210px" DataSourceID="sourceRegions" DataTextField="RegionDescription" DataValueField="RegionID" onChange="GetTerritories(this.value);">
        </asp:DropDownList>
        <asp:DropDownList ID="lstTerritories" Runat="server" Width="275px">
        </asp:DropDownList><br />
        <br />
        <br />
        <asp:Button ID="cmdOK" Runat="server" Text="OK" Width="50px" OnClick="cmdOK_Click"  /><br />
        <br />
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
        <asp:SqlDataSource ID="sourceRegions" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT 0 As RegionID, '' AS RegionDescription UNION SELECT RegionID, RegionDescription FROM Region" ></asp:SqlDataSource>
    </div>
    </form>
 
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TwoChartAreas.aspx.cs" Inherits="Charting_TwoChartAreas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="Chart1" runat="server" Width="900px">
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" />
            </ChartAreas>
        </asp:Chart>
    </div>
    <p>
<asp:Chart ID="Chart2" runat="server" Width="900px" BackColor="Gray"
    BackSecondaryColor="WhiteSmoke" BackGradientStyle="DiagonalRight" BorderlineDashStyle="Solid"
    BorderlineColor="Gray">
    <BorderSkin SkinStyle="Emboss" />
    <Titles>
        <asp:Title Text="ASP.NET Chart" Font="Utopia,16" />
    </Titles>
    <Series>
        <asp:Series Name="ColumnSeries" ChartType="Column">
            <Points>
                <asp:DataPoint YValues="5" />
                <asp:DataPoint YValues="3" />
                <asp:DataPoint YValues="12" />
                <asp:DataPoint YValues="14" />
                <asp:DataPoint YValues="11" />
                <asp:DataPoint YValues="7" />
                <asp:DataPoint YValues="3" />
                <asp:DataPoint YValues="5" />
                <asp:DataPoint YValues="9" />
                <asp:DataPoint YValues="12" />
                <asp:DataPoint YValues="11" />
                <asp:DataPoint YValues="10" />
            </Points>
        </asp:Series>
        <asp:Series Name="SplineSeries" ChartType="Spline" BorderWidth="3" ShadowOffset="2"
            Color="PaleVioletRed" ChartArea="ChartArea2">
            <Points>
                <asp:DataPoint YValues="3" />
                <asp:DataPoint YValues="7" />
                <asp:DataPoint YValues="13" />
                <asp:DataPoint YValues="2" />
                <asp:DataPoint YValues="7" />
                <asp:DataPoint YValues="15" />
                <asp:DataPoint YValues="23" />
                <asp:DataPoint YValues="20" />
                <asp:DataPoint YValues="1" />
                <asp:DataPoint YValues="5" />
                <asp:DataPoint YValues="7" />
                <asp:DataPoint YValues="6" />
            </Points>
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BackColor="Wheat" />
        <asp:ChartArea Name="ChartArea2"/>
    </ChartAreas>
</asp:Chart>
    </p>
    </form>
</body>
</html>

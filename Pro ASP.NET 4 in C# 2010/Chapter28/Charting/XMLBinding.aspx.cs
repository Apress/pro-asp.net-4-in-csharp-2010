using System;
using System.Data;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

public partial class Charting_XMLBinding : System.Web.UI.Page {

    protected void Page_Load(object sender, EventArgs e) {

        // format the chart
        Chart1.BackColor = Color.Gray;
        Chart1.BackSecondaryColor = Color.WhiteSmoke;
        Chart1.BackGradientStyle = GradientStyle.DiagonalRight;

        Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
        Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
        Chart1.BorderlineColor = Color.Gray;

        // format the chart area
        Chart1.ChartAreas[0].BackColor = Color.Wheat;
        Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

        // add and format the title
        Chart1.Titles.Add("XML Chart");
        Chart1.Titles[0].Font = new Font("Utopia", 16);

        // format the data series
        Chart1.Series[0].ChartType = SeriesChartType.Radar;

        // define the path to the xml file
        string dataPath = MapPath(".") + "\\sampledata.xml";

        // create a DataSet and read the XML data
        DataSet dataSet = new DataSet();
        dataSet.ReadXml(dataPath);
        // create a DataView from the DataSet
        DataView dataView = new DataView(dataSet.Tables[0]);
        // bind the XML ata to the chart
        Chart1.Series[0].Points.DataBindXY(dataView, "Name", dataView, "Quantity");
    }
}
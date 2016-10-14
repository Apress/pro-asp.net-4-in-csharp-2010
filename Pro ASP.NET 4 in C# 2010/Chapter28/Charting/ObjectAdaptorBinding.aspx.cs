using System;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Charting_ObjectAdaptorBinding : System.Web.UI.Page {

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
        Chart1.Titles.Add("Table Object Adaptor Chart");
        Chart1.Titles[0].Font = new Font("Utopia", 16);

        // create the object data source
        ObjectDataSource ds = new ObjectDataSource("MyObjectDataSource", "GetData");
        // bind the source to the chart
        Chart1.DataSource = ds;
        Chart1.Series[0].XValueMember = "Name";
        Chart1.Series[0].YValueMembers = "Popularity";

        // format the series
        Chart1.Series[0].ChartType = SeriesChartType.Pie;
    }
}
using System;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

public partial class Charting_BasicChart3D : System.Web.UI.Page {

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

        // add and format the title
        Chart1.Titles.Add("ASP.NET Chart");
        Chart1.Titles[0].Font = new Font("Utopia", 16);

        Chart1.Series.Add(new Series("ColumnSeries") {
            ChartType = SeriesChartType.Column,
        });

        Chart1.Series.Add(new Series("SplineSeries") {
            ChartType = SeriesChartType.Spline,
            BorderWidth = 3,
            ShadowOffset = 2,
            Color = Color.PaleVioletRed
        });

        Chart1.Series[0].Points.DataBindY(new int[] { 5, 3, 12, 14, 11, 7, 3, 5, 9, 12, 11, 10 });
        Chart1.Series[1].Points.DataBindY(new int[] { 3, 7, 13, 2, 7, 15, 23, 20, 1, 5, 7, 6 });

        Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
    }
}
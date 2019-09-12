using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Kreap
{
    public partial class Form2 : Form
    {
        public Form2(int[] array)
        {
            InitializeComponent();
            
            chart1.Series.Clear();  //グラフ初期化
            chart1.Legends.Clear();
            chart1.ChartAreas.Clear();

            var ca = chart1.ChartAreas.Add("Bar");
            ca.AxisX.Title = "回数";  　　　// タイトル
            ca.AxisX.Minimum = 0;           // 最小値
            ca.AxisX.Maximum = 16;          // 最大値
            ca.AxisX.Interval = 1;          // 目盛りの間隔
                                            // Y軸
            ca.AxisY.Title = "作業量";
            ca.AxisY.Minimum = 0;
            ca.AxisY.Maximum = 150;
            ca.AxisY.Interval = 10;

            string[] xValues = new string[] { "1", "2", "3", "4", "5","6","7","8","9","10","11","12","13","14","15"};
            int[] yValues = array;

            var s = chart1.Series.Add("Bar");         //グラフ追加
            chart1.Series["Bar"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            chart1.Series["Bar"].LegendText = "Bar";  //凡例に表示するテキストを指定
            s.SetCustomProperty("PointWidth", "0.8");

            for (int i = yValues.Length - 1; i >= 0; i--)
            {
                //グラフに追加するデータクラスを生成
                System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                dp.SetValueXY(xValues[i], yValues[i]);  //XとYの値を設定
                dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
                chart1.Series["Bar"].Points.Add(dp);   //グラフにデータ追加
            }
        }
    }
}

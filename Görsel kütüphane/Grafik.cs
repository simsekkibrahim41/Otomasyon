using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace Görsel_kütüphane
{
    

    public partial class Grafik : Form
    {
        int ToplamKitap = 0, KiradakiKitaplar = 0, BoştakiKitaplar = 0;
        public Grafik()
        {
            InitializeComponent();
            Hesap();
            CreateGraph(zedGraphControl1);
        }

        public void Hesap()
        {
            ToplamKitap = DALKitap.kitapListele().Count;
            KiradakiKitaplar = DALKitap.kitapListele().Count;

            BoştakiKitaplar = ToplamKitap - KiradakiKitaplar;
        }

        private void CreateGraph(ZedGraphControl zg1)
        {
            GraphPane myPane = zg1.GraphPane;

            myPane.Title.Text = "Kütüphane Kontrol Grafiği";
            myPane.XAxis.Title.Text = "Kitap Durumu";
            myPane.YAxis.Title.Text = "Kitap Sayısı";

            // MessageBox.Show(totalB.ToString() + " " + rentedB.ToString() + " " + freeB.ToString());

            string[] labels = { "Toplam Kitap", "Kirada", "uygun" };
            double[] y = { ToplamKitap + 10, KiradakiKitaplar + 8, BoştakiKitaplar + 2, 0 };
            double[] y2 = { 0 };
            double[] y3 = { 0 };
            double[] y4 = { ToplamKitap + 10, KiradakiKitaplar, BoştakiKitaplar + 2, 0 };

            BarItem myBar = myPane.AddBar("Curve 1", null, y, Color.Red);

            myBar.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);




            LineItem myCurve = myPane.AddCurve("Curve 4",
                  null, y4, Color.Black, SymbolType.Circle);
            myCurve.Line.Fill = new Fill(Color.White,
                                  Color.LightSkyBlue, -45F);

            myCurve.Symbol.Size = 8.0F;
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve.Line.Width = 2.0F;

            // Draw the X tics between the labels instead of 
            // at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = labels;
            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // Fill the Axis and Pane backgrounds
            myPane.Chart.Fill = new Fill(Color.White,
                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zg1.AxisChange();
        }





        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
    }
}

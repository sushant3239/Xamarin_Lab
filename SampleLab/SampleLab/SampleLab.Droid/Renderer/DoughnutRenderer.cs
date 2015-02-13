

using Android.Graphics;
using Android.Widget;
using Com.Telerik.Widget.Chart.Engine.Databinding;
using Com.Telerik.Widget.Chart.Visualization.PieChart;
using Com.Telerik.Widget.Palettes;
using Java.Util;
using SampleLab.CustomControls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DoughnutView), typeof(SampleLab.Droid.Renderer.DoughnutRenderer))]
namespace SampleLab.Droid.Renderer
{
    public class DoughnutRenderer : ViewRenderer<DoughnutView, FrameLayout>
    {
        FrameLayout fl = new FrameLayout(Forms.Context);
        TextView txt;
        DoughnutSeries doughnutSeries;
        RadPieChartView pieChart = new RadPieChartView(Xamarin.Forms.Forms.Context);

        double progress = 30;
        double maxValue = 100;

        protected override void OnElementChanged(ElementChangedEventArgs<DoughnutView> e)
        {
            base.OnElementChanged(e);
            progress = Element.Progress;
            maxValue = Element.MaxValue;

            txt = new TextView(Forms.Context);
            txt.TextSize = (float)Element.FontSize * Resources.DisplayMetrics.Density;
            //fl.SetBackgroundColor (Android.Graphics.Color.Green); 
            txt.Gravity = Android.Views.GravityFlags.Center;
            CreateChart();
            fl.AddView(pieChart);
            fl.AddView(txt);

            SetNativeControl(fl);

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == DoughnutView.ProgressProperty.PropertyName)
            {
                progress = Element.Progress;
                doughnutSeries.Data = GetData(progress, maxValue);
            }
            else if (e.PropertyName == DoughnutView.MaxValueProperty.PropertyName)
            {
                maxValue = Element.MaxValue;
                doughnutSeries.Data = GetData(progress, maxValue);
            }
            else if (e.PropertyName == DoughnutView.FontSizeProperty.PropertyName)
            {
                txt.TextSize = (float)Element.FontSize * Resources.DisplayMetrics.Density;
            }
        }


        private void CreateChart()
        {
            pieChart.Rotation = -90;
            doughnutSeries = new DoughnutSeries();            
            doughnutSeries.ValueBinding = new ValueBinding();
            doughnutSeries.ShowLabels = false;
            doughnutSeries.Data = GetData(progress, maxValue);
            doughnutSeries.InnerRadiusFactor = 0.95f;
            pieChart.Series.Add(doughnutSeries);

            ChartPalette pl = doughnutSeries.Palette;
            PaletteEntry pe = pl.GetEntry(ChartPalette.PieFamily, 0);
            pe.Stroke = Android.Graphics.Color.Green;
            pe.Fill = Android.Graphics.Color.Green;

            pe = pl.GetEntry(ChartPalette.PieFamily, 1);
            pe.Stroke = Android.Graphics.Color.Gray;
            pe.Fill = Android.Graphics.Color.Gray;
            doughnutSeries.UpdatePalette(true);
        }
        private ArrayList GetData(double val, double maxVal)
        {
            ArrayList result = new ArrayList();

            DataEntity entity = new DataEntity();
            entity.value = (val / maxVal) * 100;
            result.Add(entity);
            txt.Text = string.Format("{0}%", Convert.ToInt32(entity.value).ToString());
            entity = new DataEntity() { value = ((maxVal - val) / maxVal) * 100 };
            result.Add(entity);

            return result;
        }
    }

    public class ValueBinding : DataPointBinding
    {
        public override Java.Lang.Object GetValue(Java.Lang.Object p0)
        {
            DataEntity entity = (DataEntity)p0;
            return entity.value;
        }

    }

    public class DataEntity : Java.Lang.Object
    {
        public double value;
    }
}
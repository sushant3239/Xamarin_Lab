
using Foundation;
using SampleLab.CustomControls;
using System.Collections.Generic;
using System.Drawing;
using TelerikUI;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(DoughnutView), typeof(SampleLab.iOS.Renderer.DoughnutRenderer))]
namespace SampleLab.iOS.Renderer
{
    public class DoughnutRenderer : ViewRenderer<DoughnutView, UIKit.UIView>
    {
        double fontSize = 20;
        double progress = 2;
        double maxValue = 100;
        UILabel lbl;
        TKChart chart;
        UIKit.UIView View;
        protected override void OnElementChanged(ElementChangedEventArgs<DoughnutView> e)
        {
            base.OnElementChanged(e);
            fontSize = Element.FontSize;
            progress = Element.Progress;
            maxValue = Element.MaxValue;
            View = new UIView();
            View.ClipsToBounds = false;
            View.BackgroundColor = UIColor.Green;
            View.Layer.BackgroundColor = UIColor.Green.CGColor;
            //chart = new TKChart (bounds);
            var bounds = View.Bounds;
            chart = new TKChart(bounds);
            chart.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            View.AddSubview(chart);
            lbl = new UILabel();
            lbl.Frame = new RectangleF(0, 0, (float)View.Bounds.Width, (float)View.Bounds.Height);
            var l = new UIFontTraits();
            lbl.MinimumScaleFactor = 70;
            //lbl.Font.FontDescriptor. = l;
            lbl.Text = "50%";
            lbl.TextColor = UIColor.Blue;
            InitialiseChart();
            View.AddSubview(lbl);
            lbl.TextAlignment = UITextAlignment.Center;
            chart.BackgroundColor = UIColor.Brown;
            View.UserInteractionEnabled = false;

            SetNativeControl(View);

        }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Height")
            {
                lbl.Frame = new RectangleF(0, 0, (float)Element.Width, (float)Element.Height);
            }
            else if (e.PropertyName == "Width")
            {
                lbl.Frame = new RectangleF(0, 0, (float)Element.Width, (float)Element.Height);
            }

        }

        void InitialiseChart()
        {

            chart.RemoveAllData();
            //var datapoints = new List<TKChartDataPoint> ();
            List<TKChartDataPoint> datapoints = new List<TKChartDataPoint>();
            datapoints.Add(new TKChartDataPoint(NSObject.FromObject(maxValue), NSObject.FromObject(50), "Google"));
            datapoints.Add(new TKChartDataPoint(NSObject.FromObject(100 - maxValue), NSObject.FromObject(50), "Yahoo"));
            var series = new TKChartDonutSeries(datapoints.ToArray());
            series.InnerRadius = 0.95f;
            //series.Style.PaletteMode = TKChartSeriesStylePaletteMode.UseItemIndex;
            series.SelectionMode = TKChartSeriesSelectionMode.None;
            series.RotationAngle = -1.57079633f; //Angle in radian (-90 degree)
            chart.AddSeries(series);
            chart.Legend.Hidden = true;
            chart.Legend.Style.Position = TKChartLegendPosition.Floating;
            chart.AllowTrackball = false;
            chart.AllowAnimations = false;

            chart.ReloadData();


        }
    }
}

using SampleLab.CustomControls.Charting;
using SampleLab.Droid.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XFBarChart), typeof(SampleLab.Droid.Renderer.BarChartRenderer))]
namespace SampleLab.Droid.Renderer
{
    public class BarChartRenderer : ViewRenderer<XFBarChart, BarChartSeries>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<XFBarChart> e)
        {
            base.OnElementChanged(e);
            var chart = new BarChartSeries(Context);
            SetNativeControl(chart);
        }
    }
}
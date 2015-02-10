
using Android.Widget;
using SampleLab.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EYLabel), typeof(SampleLab.Droid.Renderer.EYLabelRenderer))]
namespace SampleLab.Droid.Renderer
{
    public class EYLabelRenderer : ViewRenderer<EYLabel, TextView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<EYLabel> e)
        {
            base.OnElementChanged(e);
            var textView = new TextView(Context);
            SetNativeControl(textView);

            Control.Text = Element.Text;

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(Control.Width, Control.Height);
            layoutParams.SetMargins((int)Element.EYLabelMargin.Left,
                (int)Element.EYLabelMargin.Top,
                (int)Element.EYLabelMargin.Right,
                (int)Element.EYLabelMargin.Bottom);
            Control.LayoutParameters = layoutParams;

            UpdateLayout();

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case "EYLabelMargin":
                    LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(Control.Width, Control.Height);
                    layoutParams.SetMargins((int)Element.EYLabelMargin.Left,
                        (int)Element.EYLabelMargin.Top,
                        (int)Element.EYLabelMargin.Right,
                        (int)Element.EYLabelMargin.Bottom);
                    Control.LayoutParameters = layoutParams;
                    break;

                case "Text":
                    Control.Text = Element.Text;
                    break;
            }
        }
    }
}
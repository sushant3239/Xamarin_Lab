
using SampleLab.CustomControls;
using SampleLab.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MySeekBar), typeof(MySeekBarRenderer))]
namespace SampleLab.iOS.Renderer
{
    public class MySeekBarRenderer : ViewRenderer<MySeekBar, UISlider>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MySeekBar> e)
        {
            base.OnElementChanged(e);
            var slider = new UISlider();
            SetNativeControl(slider);
            Control.ValueChanged += SliderValueChanged;
        }        

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        private void SliderValueChanged(object sender, System.EventArgs e)
        {
            var slider = sender as Slider;
        }
    }
}
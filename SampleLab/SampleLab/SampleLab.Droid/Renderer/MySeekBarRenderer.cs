
using Android.Widget;
using SampleLab.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MySeekBar), typeof(SampleLab.Droid.Renderer.MySeekBarRenderer))]
namespace SampleLab.Droid.Renderer
{
    public class MySeekBarRenderer : ViewRenderer<MySeekBar, SeekBar>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MySeekBar> e)
        {
            base.OnElementChanged(e);
            var seekBar = new SeekBar(Context);
            SetNativeControl(seekBar);
            Control.ProgressChanged += SeekBarProgressChanged;
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case "MaxValue":
                    Control.Max = Element.MaxValue;
                    break;

                case "CurrentPosition":
                    Control.Progress = Element.CurrentPosition;
                    break;
            }
        }

        private void SeekBarProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            Element.RaisProgressChanged(new SeekBarValueChangedEventArgs { FromUser = e.FromUser, NewValue = e.Progress, OldValue = Control.Progress, });
        }
    }
}
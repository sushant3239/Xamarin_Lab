
using Android.App;
using Android.Widget;
using SampleLab.CustomControls;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MySeekBar), typeof(SampleLab.Droid.Renderer.MySeekBarRenderer))]
namespace SampleLab.Droid.Renderer
{
    public class MySeekBarRenderer : ViewRenderer<MySeekBar, SeekBar>
    {
        private SeekBar _seekBar;
        protected override void OnElementChanged(ElementChangedEventArgs<MySeekBar> e)
        {
            base.OnElementChanged(e);
            _seekBar = new SeekBar(Forms.Context);
            SetNativeControl(_seekBar);
            Control.Max = (int)Element.Maximum;
            Control.ProgressChanged += SeekBarProgressChanged;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "CurrentPosition")
            {
                Control.Progress = (int)Element.Value;
            }
            else if (e.PropertyName == "CanSeek")
            {

            }
            else if (e.PropertyName == "MaxValue")
            {
                Control.Max =(int) Math.Round(Element.Maximum);
            }
        }

        private void SeekBarProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            Element.RaisSeekProgressValueChanged(new SeekBarValueChangedEventArgs 
            {
                FromUser = e.FromUser,
                NewValue = e.Progress,
            });
        }
    }
}

using Android.App;
using Android.Content;
using SampleLab.Infrastructure;
using SampleLab.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SampleLab.Pages.NativeToForms), typeof(SampleLab.Droid.Renderer.NativeToFormsRenderer))]
namespace SampleLab.Droid.Renderer
{
    public class NativeToFormsRenderer : PageRenderer
    {
        Android.Views.View _nativeView;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var page = e.NewElement as NativeToForms;
            var activity = Context as Activity;

            var nativeLayoutPage = activity.LayoutInflater.Inflate(Resource.Layout.NativeAndroidLayout, this, false);
            //_nativeView = nativeLayoutPage;
            _nativeView = new SampleLab.Droid.CustomControls.BarChartSeries(Context);
            //_nativeView = new SampleLab.Droid.CustomControls.BarChart(Context) { Earnings = 100, Cost = 30 };

            AddView(_nativeView);
           // var button = FindViewById<Android.Widget.Button>(SampleLab.Droid.Resource.Id.NavigateToForms);
            //button.Click += button_Click;

            //Intent intent = new Intent(Context, typeof(SecondActivity));
            //activity.StartActivity(intent);
        }

        private void button_Click(object sender, System.EventArgs e)
        {
            Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new AudiRecorderView());

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var msw = MeasureSpec.MakeMeasureSpec(r - l, Android.Views.MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, Android.Views.MeasureSpecMode.Exactly);

            _nativeView.Measure(msw, msh);
            _nativeView.Layout(0, 0, r - l, b - t);
        }
    }
}


using Xamarin.Forms;
namespace SampleLab.CustomControls
{
    public class DoughnutView : View
    {
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create<DoughnutView, double>(p => p.FontSize, 20);
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create<DoughnutView, double>(p => p.Progress, 2);
        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public static readonly BindableProperty MaxValueProperty =
            BindableProperty.Create<DoughnutView, double>(p => p.MaxValue, 100);
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
    }
}

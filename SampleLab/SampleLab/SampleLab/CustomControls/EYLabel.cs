
using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public class EYLabel : Label
    {
        public Thickness EYLabelMargin
        {
            get
            {
                return (Thickness)GetValue(MarginProperty);
            }
            set
            {
                SetValue(MarginProperty, value);
            }

        }

        public static readonly BindableProperty MarginProperty =
            BindableProperty.Create<EYLabel, Thickness>(x => x.EYLabelMargin, default(Thickness));       
    }
}

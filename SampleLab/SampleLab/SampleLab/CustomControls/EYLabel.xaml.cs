using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public partial class EYLabel : Label
    {
        private static readonly double TOP_OFFSET = -10;
        private static readonly double BOTTOM_OFFSET = -10;

        public EYLabel()
        {
            MainLabel.BindingContext = this;
            MainLabel.SetBinding<EYLabel>(MarginProperty, x => x.Margin);
            MainLabel.SetBinding<EYLabel>(BaseLineProperty, x => x.BaseLine);
            MainLabel.SetBinding<EYLabel>(FontAttributesProperty, x => x.FontAttributes);
            MainLabel.SetBinding<EYLabel>(FontFamilyProperty, x => x.FontFamily);
            MainLabel.SetBinding<EYLabel>(FontProperty, x => x.Font);
            MainLabel.SetBinding<EYLabel>(StyleProperty, x => x.Style);
            MainLabel.SetBinding<EYLabel>(FontSizeProperty, x => x.FontSize);
        }

        public Thickness Margin
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
            BindableProperty.Create<EYLabel, Thickness>(x => x.Margin, default(Thickness));

        public BaseLine BaseLine
        {
            get { return (BaseLine)GetValue(BaseLineProperty); }
            set { SetValue(BaseLineProperty, value); }
        }

        public static readonly BindableProperty BaseLineProperty =
            BindableProperty.Create<EYLabel, BaseLine>(x => x.BaseLine, BaseLine.None, propertyChanged: BaseLineChanged);

        private static void BaseLineChanged(BindableObject bindable, BaseLine oldValue, BaseLine newValue)
        {
            var control = bindable as EYLabel;
            if (control != null)
            {
                switch (newValue)
                {
                    case BaseLine.Lower:
                        control.Margin = new Thickness
                        {
                            Bottom = BOTTOM_OFFSET,
                            Left = control.Margin.Left,
                            Top = control.Margin.Top,
                            Right = control.Margin.Right
                        };
                        break;

                    case BaseLine.Upper:
                        control.Margin = new Thickness
                        {
                            Bottom = control.Margin.Bottom,
                            Left = control.Margin.Left,
                            Top = TOP_OFFSET,
                            Right = control.Margin.Right
                        };
                        break;

                    default:
                        break;
                }
            }
        }
    }

    public enum BaseLine { None, Lower, Upper }
}

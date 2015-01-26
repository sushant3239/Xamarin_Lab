
using System;
using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public class MySeekBar : View
    {
        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        public static readonly BindableProperty MaxValueProperty =
            BindableProperty.Create<MySeekBar, int>(x => x.MaxValue, default(int));

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        public static readonly BindableProperty MinValueProperty =
            BindableProperty.Create<MySeekBar, int>(x => x.MinValue, default(int));

        public int CurrentPosition
        {
            get { return (int)GetValue(CurrentPositionProperty); }
            set { SetValue(CurrentPositionProperty, value); }
        }
        public static readonly BindableProperty CurrentPositionProperty =
            BindableProperty.Create<MySeekBar, int>(x => x.CurrentPosition, default(int));

        public bool CanSeek
        {
            get;
            set;
        }
        public static readonly BindableProperty CanSeekProperty =
            BindableProperty.Create<MySeekBar, bool>(x => x.CanSeek, default(bool));

        public event EventHandler<SeekBarValueChangedEventArgs> ProgressChanged;
        public void RaisProgressChanged(SeekBarValueChangedEventArgs args)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(this, args);
            }
        }

    }    

    public class SeekBarValueChangedEventArgs
    {
        public int NewValue { get; set; }
        public int OldValue { get; set; }
        public bool FromUser { get; set; }
    }
}

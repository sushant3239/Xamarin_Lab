
using Android.Content;
using Android.Views;
using System.Collections;

namespace SampleLab.Droid.CustomControls
{
    public class MyBarChart : View
    {
        private IEnumerable _itemsSource;

        public MyBarChart(Context context) :base(context)
        {
        }

        public IEnumerable ItemsSource
        {
            get
            {
                return _itemsSource;
            }

            set
            {
                _itemsSource = value;
            }
        }
    }
}

using System;
using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public class TapableLabel : Label
    {
        public event EventHandler Clicked;

        public TapableLabel()
        {
            GestureRecognizers.Add(new TapGestureRecognizer(OnLabelTapped));
        }

        private void OnLabelTapped(View obj)
        {
            EventHandler handler = Clicked;
            if (handler != null)
            {
                handler(this, null);
            }
        }
    }
}

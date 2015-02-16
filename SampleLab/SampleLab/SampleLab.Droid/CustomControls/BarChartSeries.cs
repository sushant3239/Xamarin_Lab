
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleLab.Droid.CustomControls
{
    public class BarChartSeries : View
    {
        private readonly float _scaleFactor;
        private List<int> _itemsSource;
        private Paint _paint;

        private readonly float _padding;

        public BarChartSeries(Context context)
            : base(context)
        {
            var metrics = Resources.DisplayMetrics;
            _scaleFactor = metrics.Density;
            _itemsSource = new List<int> { 70, 60, 30, 40, 52, 29,55,66,77,33,44,6 };

            _padding = 5 * _scaleFactor;
            _paint = new Paint();
            _paint.Color = Color.Red;
            Invalidate();
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            base.OnDraw(canvas);
            DrawBars(canvas, _itemsSource);
        }

        private void DrawBars(Canvas canvas, List<int> values)
        {
            var max = values.Max();

            var widthExcludingPadding = values.Count * _padding;
            var widthPerBar = (Width - widthExcludingPadding) / values.Count;

            var maxHeight = Height;

            float left = _padding;
            float top = 0;
            float right = widthPerBar;
            float bottom = _padding;

            foreach (var item in values)
            {
                if (item != max)
                {
                    top = ((float)item / 100) * maxHeight;
                }
                else
                {
                    top = maxHeight;
                }

                canvas.DrawRect(left, (maxHeight - top), (left + widthPerBar), (maxHeight), new Paint { Color = Color.Red });
                left = (left + widthPerBar + _padding);
            }
              //canvas.DrawRect(200,10, 200 + widthPerBar, 300, new Paint { Color = Color.Red });

        }
    }
}
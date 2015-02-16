
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
        private Dictionary<string, List<int>> _seriesItems;

        private readonly float _padding;
        private readonly float _seriesPadding;

        public BarChartSeries(Context context)
            : base(context)
        {
            var metrics = Resources.DisplayMetrics;
            _scaleFactor = metrics.Density;
            _itemsSource = new List<int> { 70, 60, 30, 40, 52, 29, 55, 66, 77, 33, 44, 6 };

            _seriesItems = new Dictionary<string, List<int>>
            {
                {"Cat1", new List<int> { 70, 50,30,55 } },

                {"Cat3", new List<int> { 70, 50,30,55 } },

                {"Cat2", new List<int> { 70, 50,30,55 } },

            };

            _padding = 5 * _scaleFactor;
            _seriesPadding = 12 * _scaleFactor;

            _paint = new Paint();
            _paint.Color = Color.Red;
            Invalidate();
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            base.OnDraw(canvas);
            float lastBarRight = 0;
            float left = 0;
            var widthPerBar = GetWidthPerBar(_seriesItems.SelectMany(x => x.Value).Count(), _seriesItems.Count);
            foreach (var item in _seriesItems)
            {
                if (lastBarRight != 0)
                {
                    left = lastBarRight + _seriesPadding;
                }
                DrawBars(canvas, item.Value, widthPerBar, out lastBarRight, left);
            }
        }

        private void DrawBars(Canvas canvas, List<int> values, float widthPerBar, out float lastBarRight, float left = 0)
        {
            var max = values.Max();

            //var widthExcludingPadding = values.Count * _padding;
            //var widthPerBar = (Width - widthExcludingPadding) / values.Count;
            var maxHeight = Height;
            float top = 0;

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

            lastBarRight = left;
        }

        private float GetWidthPerBar(int numberOfBars, int numberOfSeries)
        {
            float result = 0.0f;
            float excludePadding = (_padding * numberOfBars) + (_seriesPadding * numberOfSeries);
            result = (Width - excludePadding) / numberOfBars;
            return result;
        }
    }
}
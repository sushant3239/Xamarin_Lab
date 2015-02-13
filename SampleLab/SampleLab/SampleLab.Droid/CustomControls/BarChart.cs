
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using System;
namespace SampleLab.Droid.CustomControls
{
    public class BarChart : View
    {
        private Paint _textPaint;
        private Paint _textPaint1;
        private Paint _textPaint2;

        private Paint _linePaint;

        private Paint _boxPaint1;
        private Paint _boxPaint2;

        private float _scaleFactor;
        private double _cost;
        private double _earnings;

        public BarChart(Context context)
            : base(context)
        {
            DisplayMetrics metrics = Resources.DisplayMetrics;
            _scaleFactor = metrics.Density;

            InitBarChart();
        }

        public double Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                Invalidate();
            }
        }

        public double Earnings
        {
            get { return _earnings; }
            set
            {
                _earnings = value;
                Invalidate();
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            int fullWidth = Width;
            int fullHeight = Height;
            int padding = (int)(10 * _scaleFactor);
            int maxBarHeight = fullHeight - (5 * padding);
            float bar1Height;
            float bar2Height = 0f;

            if (Earnings > Cost)
            {
                bar2Height = (float)maxBarHeight;
                bar1Height = (float)(Cost / Earnings * maxBarHeight);
            }
            else
            {
                bar1Height = (float)maxBarHeight;
                bar1Height = (float)(Earnings / Cost * maxBarHeight);
            }

            canvas.DrawLine(padding,
                (fullHeight - (25 * _scaleFactor)),
                (fullWidth - padding),
                (fullHeight - (25 * _scaleFactor)),
                _linePaint);

            float middle = (float)(fullWidth * 0.5);
            float quarter = (float)(fullWidth * 0.25);
            float threeQuarter = (float)(fullWidth * 0.75);

            int bar1Bottom = fullHeight - padding * 3;
            float bar1Top = bar1Bottom - bar1Height;
            float val1Position = bar1Top - padding;

            canvas.DrawRect((padding * 2),
                bar1Top,
                (middle - padding),
                bar1Bottom,
                _boxPaint1);

            canvas.DrawText("Cost", (quarter - padding), (fullHeight - padding), _textPaint1);
            string bar1text = String.Format("$ {0} K", Cost / 1000);
            canvas.DrawText(bar1text, (quarter - padding), val1Position, _textPaint);

            int bar2Bottom = fullHeight - (padding * 3);
            float bar2Top = bar2Bottom - bar2Height;
            float val2Position = bar2Top - padding;

            canvas.DrawRect((middle + padding),
                bar2Top, (fullWidth - (padding * 2)),
                bar2Bottom,
                _boxPaint2);

            canvas.DrawText("Earnings", (threeQuarter - (padding * 3)), (fullHeight - padding), _textPaint2);
            canvas.DrawText(("$" + Earnings / 1000 + "K"), (threeQuarter - (padding * 2)), val2Position, _textPaint);
        }

        private void InitBarChart()
        {
            _textPaint = new Paint();
            _textPaint1 = new Paint();
            _textPaint2 = new Paint();

            _linePaint = new Paint();

            _boxPaint1 = new Paint();
            _boxPaint2 = new Paint();

            _linePaint.StrokeWidth = 1;
            //_linePaint.Color = Color.ParseColor("0xFFC5C5C5");
            _linePaint.Color = Color.Red;


           // _textPaint.Color = Color.ParseColor("0xFFC5C5C5");
            _textPaint.Color = Color.Red;
            //_textPaint1.Color = Color.ParseColor("0xFFFFBB33");
            _textPaint1.Color = Color.Yellow;
            //_textPaint2.Color = Color.ParseColor("0xFF218b21");
            _textPaint2.Color = Color.Brown;


            _textPaint.TextSize = 14 * _scaleFactor;
            _textPaint1.TextSize = 14 * _scaleFactor;
            _textPaint2.TextSize = 14 * _scaleFactor;

            //_boxPaint1.Color = Color.ParseColor("0xFFFFBB33");
            _boxPaint1.Color = Color.Yellow;
            //_boxPaint2.Color = Color.ParseColor("0xFF218b21");
            _boxPaint2.Color = Color.Brown;
        }
    }
}
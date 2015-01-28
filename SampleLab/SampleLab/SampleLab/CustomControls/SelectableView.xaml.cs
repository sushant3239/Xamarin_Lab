
using System;
using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public partial class SelectableView : Grid
    {
        public SelectableView()
        {
            InitializeComponent();

            GestureRecognizers.Add(new TapGestureRecognizer(OnElementTapped));
            PropertyChanged += SelectableViewPropertyChanged;

            ViewLabel.BindingContext = this;
            ViewLabel.SetBinding<SelectableView>(Label.TextProperty, x => x.Text);
        }        

        public static readonly BindableProperty CheckedProperty =
                   BindableProperty.Create<SelectableView, bool>(
                       p => p.Checked, false);

        /// <summary>
        /// The default text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<SelectableView, string>(
                p => p.Text, string.Empty);

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create<SelectableView, Color>(p => p.Color, Color.Red);


        /// <summary>
        /// The checked changed event.
        /// </summary>
        public EventHandler<SelectableViewArgs> CheckedChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get
            {
                return (bool)this.GetValue(CheckedProperty);
            }

            set
            {
                this.SetValue(CheckedProperty, value);               
            }
        }

        public string Text
        {
            get
            {
                return (string)this.GetValue(TextProperty);
            }

            set
            {
                this.SetValue(TextProperty, value);
            }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public int ViewId { get; set; }

        private void OnElementTapped(View obj)
        {
            if (CheckedChanged != null)
            {
                var state = !Checked;
                CheckedChanged.Invoke(this, new SelectableViewArgs { CheckedState = state });
            }
        }

        private void SelectableViewPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Color":
                    BackgroundColor = Color;
                    break;
            }
        }
    }

    public class SelectableViewArgs : EventArgs
    {
        public bool CheckedState { get; set; }
    }
}

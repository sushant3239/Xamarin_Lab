
using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public class SegmentedControlView : BoxView
    {
        /// <summary> 
        /// The selected item property 
        /// </summary> 
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create<SegmentedControlView, int>(
                p => p.SelectedItem, default(int));


        /// <summary> 
        /// Gets or sets the selected item. 
        /// </summary> 
        /// <value>The selected item.</value> 
        public int SelectedItem
        {
            get { return (int)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }


        /// <summary> 
        /// The segments itens property 
        /// </summary> 
        public static readonly BindableProperty SegmentsItensProperty =
            BindableProperty.Create<SegmentedControlView, string>(
                p => p.SegmentsItens, default(string), BindingMode.TwoWay);


        /// <summary> 
        /// Gets or sets the segments itens. 
        /// </summary> 
        /// <value>The segments itens.</value> 
        public string SegmentsItens
        {
            get { return (string)GetValue(SegmentsItensProperty); }
            set
            {
                SetValue(SegmentsItensProperty, value);
            }
        }


        /// <summary> 
        /// The tint color property 
        /// </summary> 
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create<SegmentedControlView, Color>(
                p => p.TintColor, Color.Blue);


        /// <summary> 
        /// Gets or sets the color of the tint. 
        /// </summary> 
        /// <value>The color of the tint.</value> 
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set
            {
                SetValue(TintColorProperty, value);
            }
        }

    }
}

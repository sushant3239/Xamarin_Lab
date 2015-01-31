
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace SampleLab.CustomControls
{
    public class MultiSelectList : View
    {
        public List<string> ListItems
        {
            get { return (List<string>)GetValue(ListItemsProperty); }
            set { SetValue(ListItemsProperty, value); }
        }
        public static readonly BindableProperty ListItemsProperty =
            BindableProperty.Create<MultiSelectList, List<string>>(p => p.ListItems, null);

        public List<string> SelectedListItems
        {
            get
            {
                return (List<string>)GetValue(SelectedListItemsProperty);
            }
            set
            {
                SetValue(SelectedListItemsProperty, value);
            }
        }
        public static readonly BindableProperty SelectedListItemsProperty =
            BindableProperty.Create<MultiSelectList, List<string>>(p => p.SelectedListItems, null, BindingMode.TwoWay);

        public event EventHandler<List<int>> SelectedIndexChanged;
        public void RaiseSelectedItems(List<int> items)
        {
            SelectedListItems.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                SelectedListItems.Add(ListItems.ElementAt(items[i]));
            }
            var handler = SelectedIndexChanged;
            if (handler != null)
            {
                SelectedIndexChanged(this, items);
            }
        }
    }
}

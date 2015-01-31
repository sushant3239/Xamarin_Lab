
using Android.Widget;
using SampleLab.CustomControls;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidViews = Android.Widget;
using FormViews = Xamarin.Forms;

[assembly: ExportRenderer(typeof(MultiSelectList), typeof(SampleLab.Droid.Renderer.MultiSelectListRenderer))]
namespace SampleLab.Droid.Renderer
{
    public class MultiSelectListRenderer : ViewRenderer<MultiSelectList, AndroidViews.ListView>
    {
        private List<int> _selectedIndex = new List<int>();
         
        protected override void OnElementChanged(ElementChangedEventArgs<MultiSelectList> e)
        {
            base.OnElementChanged(e);
            AndroidViews.ListView listView = new AndroidViews.ListView(Forms.Context);
            SetNativeControl(listView);            
            Control.Adapter = new ArrayAdapter<string>(Forms.Context,
                    Android.Resource.Layout.SimpleListItemMultipleChoice,
                    Element.ListItems.ToArray());
            Control.ChoiceMode = ChoiceMode.Multiple;

            Control.ItemClick += ListItemSelected;
        }

        private void ListItemSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            _selectedIndex.Clear();
            var sparseArray = Control.CheckedItemPositions;
            for (int i = 0; i < sparseArray.Size(); i++)
            {
                _selectedIndex.Add(sparseArray.KeyAt(i));
            }
            Element.RaiseSelectedItems(_selectedIndex);
        }        

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case "ListItems":
                    Control.Adapter = new ArrayAdapter<string>(Forms.Context,
                            Android.Resource.Layout.SimpleListItemMultipleChoice,
                            Element.ListItems.ToArray());
                    break;
            }
        }
    }
}
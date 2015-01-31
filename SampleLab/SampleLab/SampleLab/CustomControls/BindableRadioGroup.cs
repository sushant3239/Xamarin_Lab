

using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;
namespace SampleLab.CustomControls
{
    public class BindableRadioGroup : Grid
    {
        //public List<SelectableView> rads;

        public BindableRadioGroup()
        {
            //rads = new List<SelectableView>();
        }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindableRadioGroup, IEnumerable>(o => o.ItemsSource, default(IEnumerable), propertyChanged: OnItemsSourceChanged);


        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create<BindableRadioGroup, int>(o => o.SelectedIndex, -1, BindingMode.OneWayToSource);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }


        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public event EventHandler<int> CheckedChanged;

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            var radButtons = bindable as BindableRadioGroup;

            //radButtons.rads.Clear();
            radButtons.Children.Clear();
            if (newvalue != null)
            {

                int radIndex = 0;
                foreach (var item in newvalue)
                {
                    var rad = new SelectableView();
                    rad.Text = item.ToString();
                    rad.ViewId = radIndex;

                    rad.CheckedChanged += radButtons.OnCheckedChanged;

                    //radButtons.rads.Add(rad);
                    radButtons.ColumnDefinitions.Add(new ColumnDefinition ());
                    rad.SetValue(Grid.ColumnProperty, radIndex);
                    radButtons.Children.Add(rad);
                    radIndex++;
                }
            }
        }

        private void OnCheckedChanged(object sender, SelectableViewArgs e)
        {
            var selectedRad = sender as SelectableView;

            foreach (View view in Children)
            {
                var rad = view as SelectableView;
                if (rad != null)
                {
                    if (!selectedRad.ViewId.Equals(rad.ViewId))
                    {
                        rad.Checked = false;
                    }
                    else
                    {
                        rad.Checked = !rad.Checked;
                        if (rad.Checked)
                        {
                            SelectedIndex = rad.ViewId;
                            if (CheckedChanged != null)
                                CheckedChanged.Invoke(sender, rad.ViewId);
                        }

                    }

                    ChangeColorByState(rad);
                }
            }

        }

        private static void OnSelectedIndexChanged(BindableObject bindable, int oldvalue, int newvalue)
        {
            //if (newvalue == -1) return;

            //var bindableRadioGroup = bindable as BindableRadioGroup;


            //foreach (var rad in bindableRadioGroup.rads)
            //{
            //    if (rad.ViewId == bindableRadioGroup.SelectedIndex)
            //    {
            //        rad.Checked = true;
            //    }

            //}
        }

        private void ChangeColorByState(SelectableView view)
        {
            if (view.Checked)
            {
                view.Color = Color.FromRgb(237, 237, 237);
            }
            else
            {
                view.Color = Color.White;
            }
        }
    }
}

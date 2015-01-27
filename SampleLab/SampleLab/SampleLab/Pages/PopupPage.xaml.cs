
using SampleLab.CustomControls;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleLab.Pages
{
    public partial class PopupPage : ContentPage
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        private void OpenButtonClicked(object sender, EventArgs e)
        {
            var popupLayout = this.Content as PopupLayout;

            if (popupLayout.IsPopupActive)
            {
                popupLayout.DismissPopup();
            }
            else
            {
                var list = new ListView()
                {
                    BackgroundColor = Color.White,
                    ItemsSource = new[] { "1", "2", "3" },
                    HeightRequest = this.Height * .5,
                    WidthRequest = this.Width * .8
                };

                list.ItemSelected += (s, args) =>
                    popupLayout.DismissPopup();

                //popupLayout.ShowPopup(list);
                popupLayout.ShowPopup(new TestControl { BackgroundColor = Color.White });
            }
        }
    }
}

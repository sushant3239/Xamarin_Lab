﻿
using SampleLab.Helper;
using SampleLab.Pages;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace SampleLab.PhoneService
{
    public class NavigationService : INavigationService
    {
        private INavigation _navigation;
        
        private INavigation Navigation
        {
            get
            {
                if (_navigation == null)
                {
                    _navigation = App.Current.MainPage.Navigation;
                }
                return _navigation;
            }
        }

        public object NavigationParameters
        {
            get;
            private set;
        }

        public object BackNavigationParameters
        {
            get;
            set;
        }

        public Task NavigateToAudioRecorderAsync()
        {
            return Navigation.PushAsync(new AudiRecorderView());
        }

        public Task NavigateToHomeAsync()
        {
            return Navigation.PopToRootAsync();
        }

        public Task GoBackAsync()
        {
            return Navigation.PopAsync();
        }       

        public Task NavigateToNativePage()
        {
            return Navigation.PushAsync(new NativeToForms());
        }

        public Task NavigateToPopupPage()
        {
            return Navigation.PushAsync(new PopupPage());
        }

        public Task NavigateToFilterByEngagementsPage(object navigationParmas)
        {
            NavigationParameters = navigationParmas;
            return Navigation.PushAsync(new FilterByEngagements());
        }

        public Task NavigateToChartPage()
        {
            return Navigation.PushAsync(new ChartsTest());
        }
    }
}

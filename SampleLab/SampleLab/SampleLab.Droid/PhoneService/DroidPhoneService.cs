
using Ninject;
using SampleLab.Infrastructure;
using System;
using Xamarin.Forms;

namespace SampleLab.PhoneService
{
    public class DroidPhoneService : IPhoneService
    {
        [Inject]
        public IAlertManager AlertManager
        {
            get;
            set;
        }

        [Inject]
        public INavigationService NavigationService
        {
            get;
            set;
        }

        [Inject]
        public IMediaPlayer MediaPlayer
        {
            get;
            set;
        }
    }
}
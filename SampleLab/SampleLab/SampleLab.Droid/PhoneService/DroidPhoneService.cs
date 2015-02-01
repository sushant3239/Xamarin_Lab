
using SampleLab.Infrastructure;
using System;
using Xamarin.Forms;
using TinyIoC;

namespace SampleLab.PhoneService
{
    public class DroidPhoneService : IPhoneService
    {
        public IAlertManager AlertManager
        {
            get;
            set;
        }

        public INavigationService NavigationService
        {
            get;
            set;
        }

        public IMediaPlayer MediaPlayer
        {
            get;
            set;
        }
    }
}
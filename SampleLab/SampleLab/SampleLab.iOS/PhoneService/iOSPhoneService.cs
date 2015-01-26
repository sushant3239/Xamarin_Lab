
using SampleLab.Infrastructure;
using Xamarin.Forms;

[assembly:Dependency(typeof(SampleLab.PhoneService.iOSPhoneService))]
namespace SampleLab.PhoneService
{
    public class iOSPhoneService : IPhoneService
    {
		public iOSPhoneService(IAlertManager alertManager, INavigationService navigationService, IMediaPlayer mediaPlayer)
        {
            _alertManager = alertManager;
            _navigationService = navigationService;
            _mediaPlayer = mediaPlayer;
        }

        private IAlertManager _alertManager;
        public IAlertManager AlertManager
        {
            get { return _alertManager; }
        }

        private INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get
            {
                return _navigationService;

            }
        }

        private IMediaPlayer _mediaPlayer;
        public IMediaPlayer MediaPlayer
        {
            get
            {
                return _mediaPlayer;
            }
        }
    }
}

using SampleLab.Device;
using SampleLab.PhoneService;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;
namespace SampleLab.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IPhoneService _phoneService;
        private IDevice _device;

        private INavigationService _navigationService;
        private IAlertManager _alertManager;
        private ICameraLauncher _cameraLauncher;

        private ImageSource _capturedImage;

        public ICommand ButtonCapturePressedCommand { get; private set; }
        public ICommand ButtonRecordPressedCommand { get; private set; }
        public ICommand FormsToNativePage { get; set; }
        public ICommand NavigateToPopupPage { get; private set; }

        public ImageSource CapturedImage
        {
            get
            {
                return _capturedImage;
            }
            set
            {
                if (_capturedImage == value)
                {
                    return;
                }
                _capturedImage = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel(IPhoneService phoneService, IDevice device)
        {
            _cameraLauncher = device.CameraLauncher;
            _navigationService = phoneService.NavigationService;
            _alertManager = phoneService.AlertManager;

            ButtonCapturePressedCommand = new Command(ButtonPressed);
            ButtonRecordPressedCommand = new Command(NavigateToAudioRecorder);
            FormsToNativePage = new Command(NavigateToNative);
            NavigateToPopupPage = new Command(NavigateToPopup);
        }      

        private async void ButtonPressed()
        {
            byte[] imageArray = await _cameraLauncher.StartCapture("Test.jpg", "TestFolder");
            CapturedImage = ImageSource.FromStream(() => new MemoryStream(imageArray));
            _alertManager.Show("Captured Image", "Test", Enum.MessageBoxButton.OK);
        }

        private void NavigateToAudioRecorder()
        {
            _navigationService.NavigateToAudioRecorderAsync();
        }

        private void NavigateToNative()
        {
            _navigationService.NavigateToNativePage();
        }

        private void NavigateToPopup()
        {
            _navigationService.NavigateToPopupPage();
        }
    }
}


using System.Windows.Input;
using Xamarin.Forms;
namespace SampleLab.ViewModel
{
    public class PopupPageViewModel : ViewModelBase
    {
        private bool _showPopup = false;
        private string _popupButtonText = "Show Popup";
        private FliterViewModel _filterViewModel;

        public PopupPageViewModel(FliterViewModel filterViewModel)
        {
            _filterViewModel = filterViewModel;
            PopupButtonCommand = new Command(ShowHidePopup);
        }       

        public bool ShowPopup
        {
            get { return _showPopup; }
            set 
            {
                if (_showPopup == value)
                {
                    return;
                }
                _showPopup = value;
                OnPropertyChanged();
            }
        }

        public string PopupButtonText
        {
            get { return _popupButtonText; }
            set 
            {
                if (_popupButtonText == value)
                {
                    return;
                }
                _popupButtonText = value;
                OnPropertyChanged();
            }
        }

        public ICommand PopupButtonCommand
        {
            get;
            private set;
        }

        private void ShowHidePopup()
        {
            ShowPopup = !ShowPopup;
            PopupButtonText = ShowPopup ? "Hide Popup" : "Show Popup";
        }
    }
}

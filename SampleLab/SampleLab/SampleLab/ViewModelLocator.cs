
using SampleLab.Infrastructure;
using SampleLab.ViewModel;
using Xamarin.Forms;
using SampleLab.Device;

namespace SampleLab
{
    public class ViewModelLocator
    {
        private ITypeResolver _typeResolver;

        public ViewModelLocator()
        {
            _typeResolver = DependencyService.Get<ITypeResolver>();
        }

        private MainViewModel _mainViewModel;
        public MainViewModel MainViewModel
        {
            get
            {
                if(_mainViewModel == null)
                {
                    _mainViewModel = _typeResolver.Resolve<MainViewModel>();
                }
                return _mainViewModel;
            }
        }

        private AudioRecorderViewModel _audioRecorderViewModel;
        public AudioRecorderViewModel AudioRecorderViewModel
        {
            get
            {
                if (_audioRecorderViewModel == null)
                {
                    _audioRecorderViewModel = _typeResolver.Resolve<AudioRecorderViewModel>();
                }
                return _audioRecorderViewModel;
            }
        }
    }
}

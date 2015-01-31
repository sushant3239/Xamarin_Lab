
namespace SampleLab.ViewModel
{
    public abstract class NavigationAwareViewModel : ViewModelBase
    {
        public abstract void OnNavigatedTo();
        public abstract void OnNavigatedFrom();
    }
}

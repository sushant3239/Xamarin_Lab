
using System;
using System.Threading.Tasks;

namespace SampleLab.PhoneService
{
    public interface INavigationService
    {
        Task NavigateToAudioRecorderAsync();
        Task NavigateToHomeAsync();
        Task NavigateToNativePage();
        Task NavigateToPopupPage();
        Task GoBackAsync();
    }
}

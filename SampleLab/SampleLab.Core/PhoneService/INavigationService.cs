
using System;
using System.Threading.Tasks;

namespace SampleLab.PhoneService
{
    public interface INavigationService
    {
        Object NavigationParameters { get; }
        Object BackNavigationParameters { get; set; }

        Task NavigateToAudioRecorderAsync();
        Task NavigateToHomeAsync();
        Task NavigateToNativePage();
        Task NavigateToPopupPage();
        Task GoBackAsync();
        Task NavigateToFilterByEngagementsPage(object navigationParmas);
        Task NavigateToChartPage();
    }
}

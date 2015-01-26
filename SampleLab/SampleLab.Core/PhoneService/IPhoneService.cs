
using System;

namespace SampleLab.PhoneService
{
    public interface IPhoneService
    {
        IAlertManager AlertManager { get; }

        INavigationService NavigationService { get; }

        IMediaPlayer MediaPlayer { get; }
    }
}


using SampleLab.Enum;
using System;

namespace SampleLab.PhoneService
{
    public interface IAlertManager
    {
        void Show(string message);
        void Show(string message, string title = "Alert", MessageBoxButton buttonType = MessageBoxButton.Default, Action<bool> callback = null);
    }
}

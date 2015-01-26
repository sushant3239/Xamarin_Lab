
using Android.App;
using Android.Widget;
using SampleLab.Enum;
using System;
using Xamarin.Forms;

namespace SampleLab.PhoneService
{
    public class AlertManager : IAlertManager
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);

        public AlertManager()
        {

        }

        public void Show(string message)
        {
            
        }

        public void Show(string message, string title = "Alert", MessageBoxButton buttonType = MessageBoxButton.Default, Action<bool> callback = null)
        {
            switch (buttonType)
            {
                case MessageBoxButton.OK:
                    builder.SetPositiveButton("OK", (sender, e) => 
                    {
                        if (callback == null)
                        {
                            return;
                        }
                        callback(true); 
                    });
                    break;

                case MessageBoxButton.OKCancel:
                    builder.SetPositiveButton("OK", (sender, e) => { callback(true); });
                    builder.SetNegativeButton("Cancel", (sender, e) => { callback(false); });
                    break;

                case MessageBoxButton.YesNo:
                    builder.SetPositiveButton("Yes", (sender, e) => { callback(true); });
                    builder.SetNegativeButton("No", (sender, e) => { callback(false); });
                    break; 
                
                case MessageBoxButton.Default:
                    break;
            }

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Show();
        }
    }
}
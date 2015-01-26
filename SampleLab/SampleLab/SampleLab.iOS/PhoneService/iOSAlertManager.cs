
using SampleLab.Enum;
using System;
using Xamarin.Forms;
using UIKit;

[assembly:Dependency(typeof(SampleLab.PhoneService.iOSAlertManager))]
namespace SampleLab.PhoneService
{
    public class iOSAlertManager : IAlertManager
    {
       // AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
		UIAlertView al;
		Action<bool> _callback;
		public iOSAlertManager()
        {

        }

        public void Show(string message)
        {
			al = new UIAlertView ();
			al.Message = message;
			al.AddButton ("OK");
			al.Show ();

        }

        public void Show(string message, string title = "Alert", MessageBoxButton buttonType = MessageBoxButton.Default, Action<bool> callback = null)
        {
			al = new UIAlertView ();
			_callback = callback;
			al.Message = message;
			switch (buttonType) {
			case MessageBoxButton.YesNo:
				al.AddButton ("Yes");
				al.AddButton ("No");
				al.Dismissed += MessageClick;
				break;
			default:
				al.AddButton ("OK");
				break;
			}
//            switch (buttonType)
//            {
//                case MessageBoxButton.OK:
//                    builder.SetPositiveButton("OK", (sender, e) => 
//                    {
//                        if (callback == null)
//                        {
//                            return;
//                        }
//                        callback(true); 
//                    });
//                    break;
//
//                case MessageBoxButton.OKCancel:
//                    builder.SetPositiveButton("OK", (sender, e) => { callback(true); });
//                    builder.SetNegativeButton("Cancel", (sender, e) => { callback(false); });
//                    break;
//
//                case MessageBoxButton.YesNo:
//                    builder.SetPositiveButton("Yes", (sender, e) => { callback(true); });
//                    builder.SetNegativeButton("No", (sender, e) => { callback(false); });
//                    break; 
//                
//                case MessageBoxButton.Default:
//                    break;
//            }
//
//            builder.SetMessage(message);
//            builder.SetTitle(title);
//            builder.Show();

			al.Show ();
        }

		private void MessageClick(object sender, UIButtonEventArgs e)
		{
			_callback (e.ButtonIndex == 0 ? true : false);
		}
		public void ShowMessage(String message)
		{



		}
    }
}
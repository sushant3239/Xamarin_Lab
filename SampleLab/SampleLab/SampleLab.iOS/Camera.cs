
using MonoTouch.UIKit;
using SampleLab.Device;
using System;
using Xamarin.Forms;


[assembly: Dependency(typeof(SampleLab.iOS.Camera))]
namespace SampleLab.iOS
{
    public class Camera : ICameraLauncher
    {
        UIImagePickerController imagePicker;

        public void CaptureImage(string fileNmae = "")
        {
            imagePicker = new UIImagePickerController();
            imagePicker.FinishedPickingMedia += imagePicker_FinishedPickingMedia;
            imagePicker.SourceType = UIImagePickerControllerSourceType.Camera;

            AppDelegate.CurrentController.PresentViewControllerAsync(imagePicker, true);
        }

        private async void imagePicker_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
        {
            UIImage capturedImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
            await imagePicker.DismissViewControllerAsync(true);
        }

        public System.Threading.Tasks.Task StartCapture(string fileNmae, string folderName)
        {
            throw new NotImplementedException();
        }
    }
}

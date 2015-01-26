
using Android.App;
using Android.Content;
using Android.OS;
using SampleLab.Constants;
using SampleLab.Device;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleLab.Device
{
    public class DroidCamera  : ICameraLauncher
    {
        public static TaskCompletionSource<byte[]> _tcs;
        private Activity CurrentContext { get { return Xamarin.Forms.Forms.Context as Activity; } }

        private void CreateIntentAndStartActivity(string fileName, string folderName)
        {
            Intent i = new Intent();
            i.SetClass(CurrentContext, typeof(CameraActivity));
            i.AddFlags(ActivityFlags.NewTask);

            i.PutExtra(DroidConstants.CameraIntentFileKey, fileName);
            i.PutExtra(DroidConstants.CameraIntentFolderKey, folderName);
            CurrentContext.StartActivity(i);
        }

        public Task<byte[]> StartCapture(string fileName, string folderName)
        {
            _tcs = new TaskCompletionSource<byte[]>();
            CreateIntentAndStartActivity(fileName, folderName);
            return _tcs.Task;
        }
    }
}
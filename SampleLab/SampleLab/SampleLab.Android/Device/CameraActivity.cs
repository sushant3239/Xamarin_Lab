
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Provider;
using Java.IO;
using SampleLab.Constants;
using System;
using System.Collections.Generic;



namespace SampleLab.Device
{
    [Activity(NoHistory=true)]
    public class CameraActivity : Activity
    {
        private File _file;
        private File _dir;
        private Result _cameraResult;

        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPicture();
                TakePicture();
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(_file);
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);
                var array = GetImageArrayFromUri(contentUri);
                DroidCamera._tcs.SetResult(array);
                FinishActivity(0);
            }
           
            _cameraResult = resultCode;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            GetCapturedImageArray();
            
        }

        private void TakePicture()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, String.Format(Intent.GetStringExtra(DroidConstants.CameraIntentFileKey), DateTime.Now));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
            StartActivityForResult(intent, 0);
        }

        private void CreateDirectoryForPicture()
        {
            _dir = new File(Android.OS.Environment.
                GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),
                Intent.GetStringExtra(DroidConstants.CameraIntentFolderKey));

            if (!_dir.Exists())
            {
                _dir.Mkdir();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);

            return availableActivities != null && availableActivities.Count > 0;
        }

        private byte[] GetImageArrayFromUri(Android.Net.Uri file)
        {
            Bitmap thumb;
            thumb = MediaStore.Images.Media.GetBitmap(ContentResolver, file);
            Bitmap scaledThumb = Bitmap.CreateScaledBitmap(thumb, 300, 300, true);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            scaledThumb.Compress(Bitmap.CompressFormat.Jpeg, 50, ms);
            return ms.ToArray();
        }

        private void GetCapturedImageArray()
        {
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Android.Net.Uri contentUri = Android.Net.Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);
            var array = GetImageArrayFromUri(contentUri);
            DroidCamera._tcs.SetResult(array);
        }
    }
}
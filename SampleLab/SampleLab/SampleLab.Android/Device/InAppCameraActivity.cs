
using Android.App;
using Android.Hardware;
using Android.OS;
using Android.Views;

namespace SampleLab.Droid.Device
{
    [Activity(Label = "InAppCameraActivity")]
    public class InAppCameraActivity : Activity,
        Android.Hardware.Camera.IAutoFocusCallback,
        Android.Hardware.Camera.IPictureCallback,
        Android.Hardware.Camera.IPreviewCallback,
        Android.Hardware.Camera.IShutterCallback,
        ISurfaceHolderCallback
    {
        private Camera _camera;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SurfaceView surface = FindViewById<SurfaceView>(Resource.Id.inappCameraSurfaceView);
            var holder = surface.Holder;
            holder.AddCallback(this);
            holder.SetType(Android.Views.SurfaceType.PushBuffers);
            holder.SetFixedSize(300, 200);
            // Create your application here
        }

        public void OnAutoFocus(bool success, Android.Hardware.Camera camera)
        {
            throw new System.NotImplementedException();
        }

        public void OnPictureTaken(byte[] data, Android.Hardware.Camera camera)
        {
            throw new System.NotImplementedException();
        }

        public void OnPreviewFrame(byte[] data, Android.Hardware.Camera camera)
        {
            throw new System.NotImplementedException();
        }

        public void OnShutter()
        {
            throw new System.NotImplementedException();
        }

        public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int width, int height)
        {
            throw new System.NotImplementedException();
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            try
            {
                _camera = Camera.Open();
                Camera.Parameters cameraParameters = _camera.GetParameters();
                cameraParameters.PictureFormat = Android.Graphics.ImageFormatType.Jpeg;
                _camera.SetParameters(cameraParameters);
                _camera.AutoFocus(this);
                _camera.SetPreviewCallback(this);
                _camera.Lock();
            }
            catch
            {

            }
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            throw new System.NotImplementedException();
        }
    }
}
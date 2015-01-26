using System;
using Xamarin.Forms;

[assembly:Dependency(typeof(SampleLab.Device.iOSDevice))]
namespace SampleLab.Device
{
	public class iOSDevice : IDevice
	{
		public iOSDevice (ICameraLauncher cameraLauncher,IAudioRecorder audioRecorder)
		{
			_cameraLauncher = cameraLauncher;
			_audioRecorder = audioRecorder;
		}

		private ICameraLauncher _cameraLauncher;
		public ICameraLauncher CameraLauncher
		{
			get { return _cameraLauncher; }
		}

		private IAudioRecorder _audioRecorder;
		public IAudioRecorder AudioRecorder
		{
			get { return _audioRecorder; }
		}


	}
}


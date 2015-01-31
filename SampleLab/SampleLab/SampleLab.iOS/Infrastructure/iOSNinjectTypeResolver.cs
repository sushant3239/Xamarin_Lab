
using SampleLab.Device;
using SampleLab.PhoneService;
using Xamarin.Forms;
using SampleLab.ViewModel;
using System;

[assembly: Dependency(typeof(SampleLab.Infrastructure.iOSNinjectTypeResolver))]
namespace SampleLab.Infrastructure
{
	public class iOSNinjectTypeResolver : ITypeResolver
    {
		#region ITypeResolver implementation

		public T Resolve<T> () where T : class
		{
			return DependencyService.Get<T> ();
		}

		#endregion

		public object Get<T> () where T : class
		{
			Type t = typeof(T);
			ViewModelBase viewModel= null;
			if (t.FullName.Contains("MainViewModel"))
			{
				viewModel = new MainViewModel (new iOSPhoneService(new iOSAlertManager(),DependencyService.Get<INavigationService>(), new iOSMediaPlayer()),new iOSDevice(new iOsCamera(),new iOSAudioRecorder()));
			} 
			else if (t.FullName.Contains("AudioRecorderViewModel")) 
			{
				viewModel = new AudioRecorderViewModel (new iOSDevice(new iOsCamera(),new iOSAudioRecorder()),new iOSPhoneService(new iOSAlertManager(),DependencyService.Get<INavigationService>(), new iOSMediaPlayer()));
			}
			else if (t.FullName.Contains("CameraViewModel"))
			{
				//viewModel = new CameraViewModel (new iOSPhoneService(new iOSAlertManager(),DependencyService.Get<INavigationService>(), new iOSMediaPlayer()),new iOSDevice(new iOsCamera(),new iOSAudioRecorder()));
			} 
			return viewModel;

		}
    }
}
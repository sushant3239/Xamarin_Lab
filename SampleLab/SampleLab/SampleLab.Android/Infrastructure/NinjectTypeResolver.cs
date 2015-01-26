
using Ninject;
using Ninject.Modules;
using SampleLab.Device;
using SampleLab.PhoneService;
using Xamarin.Forms;

[assembly: Dependency(typeof(SampleLab.Infrastructure.NinjectTypeResolver))]
namespace SampleLab.Infrastructure
{
    public class NinjectTypeResolver : ITypeResolver
    {
        private IKernel _kernel;
        public NinjectTypeResolver()
        {
            _kernel = new StandardKernel(new Module());
            
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        class Module : NinjectModule
        {
            public override void Load()
            {
                Bind<ICameraLauncher>().To<DroidCamera>().InSingletonScope();
                Bind<IAlertManager>().To<AlertManager>();
                Bind<IPhoneService>().To<DroidPhoneService>();
                Bind<IDevice>().To<DroidDevice>();
                Bind<IAudioRecorder>().To<DroidAudioRecorder>();
                Bind<IMediaPlayer>().To<DroidMediaPlayer>();
                Bind<INavigationService>().To<NavigationService>();
            }
        }
    }
}
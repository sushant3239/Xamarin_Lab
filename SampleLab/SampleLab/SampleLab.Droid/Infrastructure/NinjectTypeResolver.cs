
using Ninject;
using Ninject.Modules;
using SampleLab.Device;
using SampleLab.Infrastructure;
using SampleLab.PhoneService;
using SampleLab.ViewModel;
using Xamarin.Forms;

//[assembly: Dependency(typeof(SampleLab.Infrastructure.NinjectTypeResolver))]
namespace SampleLab.Infrastructure
{
    public class NinjectTypeResolver : ITypeResolver
    {
        private IKernel _kernel;
        public NinjectTypeResolver()
        {
            _kernel = new StandardKernel(new Module());
            
        }

        public T Resolve<T>() where T :class
        {
            return _kernel.Get<T>();            
        }

        class Module : NinjectModule
        {
            public override void Load()
            {
                Bind<ICameraLauncher>().To<DroidCamera>().InSingletonScope();
                Bind<IAlertManager>().To<AlertManager>().InSingletonScope();
                Bind<IPhoneService>().To<DroidPhoneService>().InSingletonScope();
                Bind<IDevice>().To<DroidDevice>().InSingletonScope();
                Bind<IAudioRecorder>().To<DroidAudioRecorder>().InSingletonScope();
                Bind<IMediaPlayer>().To<DroidMediaPlayer>().InSingletonScope();
                Bind<INavigationService>().To<NavigationService>().InSingletonScope();
                Bind<FilterByEngagementsViewModel>().To<FilterByEngagementsViewModel>().InSingletonScope();
                Bind<FliterViewModel>().To<FliterViewModel>().InSingletonScope();
            }
        }
    }
}
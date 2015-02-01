
using SampleLab.Infrastructure;
using System;
using TinyIoC;
using Xamarin.Forms;
using System.Linq;
using SampleLab.PhoneService;
using SampleLab.Device;

[assembly: Dependency(typeof(SampleLab.Droid.Infrastructure.TinyIoCTypeResolver))]
namespace SampleLab.Droid.Infrastructure
{
    public class TinyIoCTypeResolver : ITypeResolver
    {
        private TinyIoCContainer _kernel;

        public TinyIoCTypeResolver()
        {
            _kernel = TinyIoCContainer.Current;
            LoadModule();
        }

        private void LoadModule()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var labAssemblies = assemblies.Where(a =>
                (a.GetName().Name == "SampleLab.Droid") ||
                (a.GetName().Name == "SampleLab.Core") ||
                (a.GetName().Name == "SampleLab.ViewModel")||
                (a.GetName().Name== "SampleLab")).ToList();      
     
            _kernel.AutoRegister(labAssemblies);

            _kernel.Register<IPhoneService>(IphoneServiceFactory).AsSingleton();
            _kernel.Register<IDevice>(IDeviceServiceFactory).AsSingleton();
        }

        private IDevice IDeviceServiceFactory(TinyIoCContainer arg1, NamedParameterOverloads arg2)
        {
            var device = _kernel.Resolve<DroidDevice>();
            arg1.BuildUp(device);
            return device;
        }

        private IPhoneService IphoneServiceFactory(TinyIoCContainer arg1, NamedParameterOverloads arg2)
        {
            var service = _kernel.Resolve<DroidPhoneService>();
            arg1.BuildUp(service);
            return service;
        }

        public T Resolve<T>() where T : class
        {
            return _kernel.Resolve<T>();
        }
    }
}
using System;
using TinyIoC;
using Xamarin.Forms;
using SampleLab.Device;
using SampleLab.iOS;


[assembly:Dependency(typeof(SampleLab.Infrastructure.TinyIocContainer))]
namespace SampleLab.Infrastructure
{
	public class TinyIocContainer: ITypeResolver
	{
		public TinyIocContainer ()
		{
			TinyIoC.TinyIoCContainer.Current.AutoRegister();
		}

		#region ITypeResolver implementation

		public T Resolve<T> () where T : class
		{
            return TinyIoC.TinyIoCContainer.Current.Resolve<T>();
		}


		public object Get<T> () where T : class
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}


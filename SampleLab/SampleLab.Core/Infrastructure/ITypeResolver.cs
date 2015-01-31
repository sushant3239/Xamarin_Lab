
namespace SampleLab.Infrastructure
{
    public interface ITypeResolver
    {
        T Resolve<T>() where T : class;
    }
}

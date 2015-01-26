
namespace SampleLab.Infrastructure
{
    public interface ITypeResolver
    {
        T Resolve<T>();
    }
}

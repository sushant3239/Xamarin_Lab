
namespace SampleLab.Infrastructure.Storage
{
    public interface IStorage
    {
        void Add<T>(T data);
        T Get<T>(string key);       
    }
}

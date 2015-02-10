
namespace SampleLab.Infrastructure.Storage
{
    public interface IStorage
    {
        void Add<T>(string key,T value);
        T Get<T>(string key);
        bool ContainsKey(string key);
    }
}

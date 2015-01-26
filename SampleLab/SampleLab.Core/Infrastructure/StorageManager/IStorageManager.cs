

namespace SampleLab.Infrastructure.Storage
{
    public interface IStorageManager
    {
         ISessionStorageManager SessionStorage { get; }

         IPersistentStorageManager PersistentStorage { get; }

         ICacheStorageManager CacheStorage { get; }
    }
}

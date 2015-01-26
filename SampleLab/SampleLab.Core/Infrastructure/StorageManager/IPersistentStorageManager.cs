
namespace SampleLab.Infrastructure.Storage
{
    public interface IPersistentStorageManager : IStorage
    {
        void Commit();
    }
}

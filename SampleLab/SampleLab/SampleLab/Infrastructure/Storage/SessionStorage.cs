
using System.Collections.Generic;
using System.Linq;

namespace SampleLab.Infrastructure.Storage
{
    public class SessionStorage : ISessionStorageManager
    {
        private Dictionary<string, object> _container;

        public void Add<T>(string key, T value)
        {
            object data = value;
        }

        public T Get<T>(string key)
        {
            T value = default(T);
            if (ContainsKey(key))
            {
                value = (T)_container[key];
            }
            return value;
        }

        public bool ContainsKey(string key)
        {
            return _container.ContainsKey(key);
        }
    }
}

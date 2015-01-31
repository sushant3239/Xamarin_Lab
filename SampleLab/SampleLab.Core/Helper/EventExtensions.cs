
using System;

namespace SampleLab.Core.Helper
{
    public static class EventExtensions
    {
        public static void Invoke<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
        {
            var handel = handler;
            if (handel != null)
            {
                handel(sender, new EventArgs<T>(value));
            }
        }

        public static bool TryInvoke<T>(this EventHandler<T> handler,object sender,T value) where T : EventArgs
        {
            bool result = false;
            var handle = handler;
            if (handle != null)
            {
                handle(sender, value);
                result = true;
            }
            return result;
        }
    }
}

using System.Threading.Tasks;

namespace SampleLab.Helper
{
    public static class TaskUtils
    {
        public static Task<T> TaskFromResult<T>(T result)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(result);
            return tcs.Task;
        }
    }
}

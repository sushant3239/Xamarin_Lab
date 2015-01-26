
using Android.Hardware;
using System.Threading.Tasks;

namespace SampleLab.Device
{
    public class DroidInAppCamera : ICamera
    {
        public Task<byte[]> TakePicture()
        {
            Init();
            return null;
        }

        private void Init()
        {
        }
    }
}
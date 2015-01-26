using System.Threading.Tasks;
namespace SampleLab.Device
{
    public interface ICamera
    {
        Task<byte[]> TakePicture();
    }
}


using System;
using System.Threading.Tasks;

namespace SampleLab.Device
{
    public interface ICameraLauncher
    {
        Task<byte[]> StartCapture(string fileNmae,string folderName);
    }
}

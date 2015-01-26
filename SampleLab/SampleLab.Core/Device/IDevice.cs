
using System;

namespace SampleLab.Device
{
    public interface IDevice
    {
        ICameraLauncher CameraLauncher { get; }

        IAudioRecorder AudioRecorder { get; }
    }
}

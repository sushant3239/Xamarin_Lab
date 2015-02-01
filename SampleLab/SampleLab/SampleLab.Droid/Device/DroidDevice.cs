
using Ninject;
using System;

namespace SampleLab.Device
{
    public class DroidDevice : IDevice
    {
        public ICameraLauncher CameraLauncher
        {
            get;
            set;
        }

        public IAudioRecorder AudioRecorder
        {
            get;
            set;
        }
    }
}
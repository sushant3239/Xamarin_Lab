
using Ninject;
using System;

namespace SampleLab.Device
{
    public class DroidDevice : IDevice
    {
        [Inject]
        public ICameraLauncher CameraLauncher
        {
            get;
            set;
        }

        [Inject]
        public IAudioRecorder AudioRecorder
        {
            get;
            set;
        }
    }
}
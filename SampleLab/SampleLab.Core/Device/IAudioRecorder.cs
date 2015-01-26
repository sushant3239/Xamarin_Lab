
using System;

namespace SampleLab.Device
{
    public interface IAudioRecorder
    {
        void StartRecording(string filePath);
        void StopRecording();
        void DisposeUsedResources();
    }
}

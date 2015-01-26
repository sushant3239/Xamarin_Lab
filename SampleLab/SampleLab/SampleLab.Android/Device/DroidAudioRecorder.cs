
using Android.Media;
using System;

namespace SampleLab.Device
{
    public class DroidAudioRecorder : IAudioRecorder
    {
        private MediaRecorder _recorder;
        private bool _isInitialized;

        private void Init()
        {
            _isInitialized = true;
            _recorder = new MediaRecorder();
        }

        public void StartRecording(string filePath)
        {
            if (!_isInitialized)
            {
                Init();
            }

            _recorder.SetAudioSource(AudioSource.Mic);
            _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            _recorder.SetOutputFile(filePath);
            _recorder.Prepare();
            _recorder.Start();
        }

        public void StopRecording()
        {
            _recorder.Stop();
            _recorder.Reset();
        }

        public void DisposeUsedResources()
        {
            _recorder.Reset();
            _recorder.Dispose();
            _isInitialized = false;
        }       
    }
}
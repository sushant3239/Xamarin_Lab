using SampleLab.Core.Device;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace SampleLab.ViewModel
{
    public class RawAudioRecordViewModel : ViewModelBase
    {
        private IRawAudioRecorder _recorder;
        public RawAudioRecordViewModel(IRawAudioRecorder recorder)
        {
            _recorder = recorder;

            StartRecordCommand = new Command(StartRecording);
            StopRecordCommand = new Command(StopRecord);
        }

        private void StopRecord()
        {
            _recorder.StopRecording();
        }

        public ICommand StartRecordCommand { get; private set; }
        public ICommand StopRecordCommand { get; private set; }


        private void StartRecording()
        {
            _recorder.StartAudioRecording();
        }
    }
}


using SampleLab.CustomCommand;
using SampleLab.Device;
using SampleLab.PhoneService;
using System;
using System.Windows.Input;
using Xamarin.Forms;


namespace SampleLab.ViewModel
{
    public class AudioRecorderViewModel : ViewModelBase
    {
        private IAudioRecorder _audioRecorder;
        private IMediaPlayer _mediaPlayer;
        private IAlertManager _alertManager;

        private string filePath = "/sdcard/test.3gpp";

        private string _audioPlaybackTime;
        private bool _shouldStop;
        private int _totalSeconds = 0;
        private int _currentSeekerPosition;
        private double _totalMediaDuration;
        private int _maxSeekerValue;
        private int _ratio;


        public AudioRecorderViewModel(IDevice device, IPhoneService phoneService)
        {
            _audioRecorder = device.AudioRecorder;
            _alertManager = phoneService.AlertManager;
            _mediaPlayer = phoneService.MediaPlayer;

            StartRecordingCommand = new Command(StartRecording);
            StopRecordingCommand = new Command(StopRecording);
            PlayAudioCommand = new Command(PlayRecording);
            SeekToPostionCommand = new DelegateCommand<int>(SeekToPosition);

            _mediaPlayer.OnMediaStopped += MediaStopped;
        }       

        public ICommand StartRecordingCommand { get; private set; }
        public ICommand StopRecordingCommand { get; private set; }
        public ICommand PlayAudioCommand { get; private set; }
        public ICommand SeekToPostionCommand { get; private set; }

        public string AudioPlayBackTime
        {
            get
            {
                return _audioPlaybackTime;
            }
            set
            {
                if (_audioPlaybackTime == value)
                {
                    return;
                }
                _audioPlaybackTime = value;
                OnPropertyChanged();
            }
        }

        public int MaxSeekerValue
        {
            get { return _maxSeekerValue; }
            set 
            {
                if (_maxSeekerValue == value)
                {
                    return;
                }
                _maxSeekerValue = value;
                OnPropertyChanged();
            }
        }

        public double MinSeekerValue
        {
            get
            {
                return 0;
            }
        }

        public int CurrentSeekerPosition
        {
            get { return _currentSeekerPosition; }
            set
            {
                if (_currentSeekerPosition == value)
                {
                    return;
                }
                _currentSeekerPosition = value;
                OnPropertyChanged();
            }
        }



        private void StopRecording()
        {
            _audioRecorder.StopRecording();
            _shouldStop = false;
        }

        private void StartRecording()
        {
            _audioRecorder.StartRecording(filePath);
            _shouldStop = true;
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                _totalSeconds++;
                AudioPlayBackTime = FormattedTimeSpan(_totalSeconds);
                return _shouldStop;
            });
        }

        private async void PlayRecording()
        {
            AudioPlayBackTime = FormattedTimeSpan(0);
            await _mediaPlayer.PlayAsync(filePath);
            _totalMediaDuration = TimeSpan.FromMilliseconds(_mediaPlayer.TotalPlayBackInSeconds).TotalSeconds;
            MaxSeekerValue =(int) Math.Round(_totalMediaDuration);
            CalculateRatio();
            StartTimerLoop();
        }

        private void SeekToPosition(int position)
        {
            
            _mediaPlayer.Position = position;
        }

        private bool _shouldLoop = true;
        private void StartTimerLoop()
        {
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                AudioPlayBackTime = FormattedTimeSpan(_mediaPlayer.Position);
                CurrentSeekerPosition = _mediaPlayer.Position;
                return _shouldLoop;
            });
        }

        private void CalculateRatio()
        {
            //_ratio = (MaxSeekerValue / _totalMediaDuration);
           // _ratio = 0.022;
            _ratio = 1;
        }

        private string FormattedTimeSpan(int timeInSeconds)
        {
            string result = String.Empty;
            TimeSpan t = TimeSpan.FromSeconds(timeInSeconds);
            if (t.TotalMinutes < 1.0)
            {
                result = String.Format("00:{0}", t.Seconds);
            }
            else
            {
                result = String.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
            }
            return result;
        }

        private void MediaStopped(object sender, EventArgs e)
        {
            _shouldLoop = true;
        }

    }
}

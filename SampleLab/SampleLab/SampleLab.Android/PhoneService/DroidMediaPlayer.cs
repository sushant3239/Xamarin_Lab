using Android.Media;
using System;
using System.Threading.Tasks;

namespace SampleLab.PhoneService
{
    public class DroidMediaPlayer : IMediaPlayer
    {
        private MediaPlayer _player;

        public DroidMediaPlayer()
        {
            _player = new MediaPlayer();
            _player.Prepared += PlayerPrepared;
            _player.Completion += PlayerCompletion;
        }

        public int Position
        {
            get
            {
                return _player.CurrentPosition;
            }
            set
            {
                _player.SeekTo(value);
            }
        }

        TaskCompletionSource<bool> _tcs;
        public Task<bool> PlayAsync(string filePath)
        {
            _tcs = new TaskCompletionSource<bool>();
            _player.SetDataSource(filePath);
            _player.PrepareAsync();
            return _tcs.Task;
        }

        private void PlayerPrepared(object sender, EventArgs e)
        {
            _player.Start();
            _tcs.SetResult(true);
        }

        public void Play(string filePath)
        {
            _player.SetDataSource(filePath);
            _player.Prepare();
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void Stop()
        {
            _player.Stop();
        }

        public void ReleaseMediaPlayer()
        {
            _player.Release();
            _player.Dispose();
            _player = null;
        }

        public double TotalPlayBackInSeconds
        {
            get { return _player.Duration; }
        }

        public event EventHandler OnMediaStopped;
        private void PlayerCompletion(object sender, EventArgs e)
        {
            if (OnMediaStopped != null)
            {
                OnMediaStopped(sender, e);
            }
        }
    }
}
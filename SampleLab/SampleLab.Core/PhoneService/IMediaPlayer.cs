
using System;
using System.Threading.Tasks;

namespace SampleLab.PhoneService
{
    public interface IMediaPlayer
    {
        int Position { get; set; }

        double TotalPlayBackInSeconds { get; }

        Task<bool> PlayAsync(string filePath);

        void Play(string filePath);

        void Pause();

        void Stop();

        void ReleaseMediaPlayer();

        event EventHandler OnMediaStopped;
    }
}

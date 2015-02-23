

using System;
using SampleLab.Core.Device;
using System.Threading;
using Android.Media;
using Java.IO;

namespace SampleLab.Droid.Device
{
    public class RawAudioRecorder : IRawAudioRecorder
    {
        private bool _shouldStop = false;
        private byte[] _audioBuffer;
        private System.Collections.Generic.List<byte[]> _buffers;

        public void StartAudioRecording()
        {
            ThreadPool.QueueUserWorkItem(Start);
        }

        public void StopRecording()
        {
            _shouldStop = true;
        }

        private void Start(object state)
        {
            _buffers = new System.Collections.Generic.List<byte[]>();
            int frequency = 11025;
            var channelConfig = ChannelIn.Mono;
            var audioEncoding = Encoding.Pcm16bit;

            //var buffSize = AudioRecord.GetMinBufferSize(frequency, channelConfig, audioEncoding);

            var audioRecord = new AudioRecord
            (
                AudioSource.Mic,
                frequency,
                channelConfig,
                audioEncoding,
                100000
            );

            audioRecord.StartRecording();
            while (!_shouldStop)
            {
                var audioBuffer = new byte[100000];
                audioRecord.Read(audioBuffer, 0, audioBuffer.Length);
                _buffers.Add(audioBuffer);
            }
            MergeAudio();
            PlayAudio();
        }

        private void PlayAudio()
        {
            AudioTrack audioTrack = new AudioTrack(Stream.Music,
                11025,
                ChannelConfiguration.Mono,
                Encoding.Pcm16bit,
                _audioBuffer.Length,
                AudioTrackMode.Stream);

            audioTrack.Play();
            audioTrack.Write(_audioBuffer, 0, _audioBuffer.Length);

        }

        private void MergeAudio()
        {
            _audioBuffer = new byte[GetTargetBufferSize()];
            int offset = 0;
            foreach (var buffer in _buffers)
            {
                AppendBuffers(buffer, offset);
                offset += buffer.Length;
            }
        }

        private void AppendBuffers(byte[] buffer, int offset)
        {
            int size = buffer.Length;
            int copyTil = size + offset;
            for (int i = offset; i < copyTil; i++)
            {
                _audioBuffer[i] = buffer[i - offset];
            }
        }

        private int GetTargetBufferSize()
        {
            int result = 0;
            foreach (var buffer in _buffers)
            {
                result += buffer.Length;
            }
            return result;
        }
    }
}
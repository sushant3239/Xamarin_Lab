
using System;

namespace SampleLab.ViewModel
{
    public class AudioPlayerViewModel : ViewModelBase
    {
        private int _position;
        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }
    }
}

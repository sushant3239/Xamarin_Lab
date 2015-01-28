
namespace SampleLab.ViewModel
{
    public class FliterViewModel : ViewModelBase
    {
        private int _dueDateGroupSelectedIndex;
        private int _reviewNoteSelectedIndex;
        private int _auditPhaseSelectedIndex;
        public FliterViewModel()
        {

        }

        public int DueDateGroupSelectedIndex
        {
            get { return _dueDateGroupSelectedIndex; }
            set
            {
                if (_dueDateGroupSelectedIndex == value)
                {
                    return;
                }
                _dueDateGroupSelectedIndex = value;
                OnPropertyChanged();
            }
        }
        public int ReviewNoteSelectedIndex
        {
            get { return _reviewNoteSelectedIndex; }
            set 
            {
                if (_reviewNoteSelectedIndex == value)
                {
                    return;
                }
                _reviewNoteSelectedIndex = value;
                OnPropertyChanged();
            }
        }
        public int AuditPhaseSelectedIndex
        {
            get { return _auditPhaseSelectedIndex; }
            set 
            {
                if (_auditPhaseSelectedIndex == value)
                {
                    return;
                }
                _auditPhaseSelectedIndex = value;
                OnPropertyChanged();
            }
        }
    }
}

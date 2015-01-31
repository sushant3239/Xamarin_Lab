
namespace SampleLab.Model
{
    public class Evidence : AssuranceBaseModel
    {
        private string _type;
        private string _status;
        private string _preparer;
        private string _reviewer;
        private bool _new;
        private int _reviewNoteCount;

        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public string Preparer
        {
            get { return _preparer; }
            set { SetProperty(ref _preparer, value); }
        }

        public string Reviewer
        {
            get { return _reviewer; }
            set { SetProperty(ref _reviewer, value); }
        }

        public bool New
        {
            get { return _new; }
            set { SetProperty(ref _new, value); }
        }

        public int ReviewNoteCount
        {
            get { return _reviewNoteCount; }
            set { SetProperty(ref _reviewNoteCount, value); }
        }
    }
}

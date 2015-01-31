
using System;
using System.Collections.Generic;
namespace SampleLab.Model
{
    public class EngagementTask : AssuranceBaseModel
    {
        private string _type;
        private DateTime _dueDate;
        private int _status;
        private string _execution;
        private bool _new;
        private List<Evidence> _evidences;
        private string _phase;

        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { SetProperty(ref _dueDate, value); }
        }

        public int Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public bool New
        {
            get { return _new; }
            set { SetProperty(ref _new, value); }
        }

        public string Execution
        {
            get { return _execution; }
            set { SetProperty(ref _execution, value); }
        }

        public string Phase
        {
            get { return _phase; }
            set { SetProperty(ref _phase, value); }
        }

        public List<Evidence> Evidences
        {
            get { return _evidences; }
            set { SetProperty(ref _evidences, value); }
        }
    }
}

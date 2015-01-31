
using System.Collections.Generic;
namespace SampleLab.Model
{
    public class Engagement : AssuranceBaseModel
    {
        private string _workspaceName;
        private string _clientName;
        private int _myTaskCount;
        private int _completedTaskCount;
        private List<EngagementTask> _tasks;
        private int _forReviewTaskCount;

        public string ClientName
        {
            get { return _clientName; }
            set { SetProperty(ref _clientName, value); }
        }

        public string WorkspaceName
        {
            get { return _workspaceName; }
            set { SetProperty(ref _workspaceName, value); }
        }

        public int MyTaskCount
        {
            get { return _myTaskCount; }
            set { SetProperty(ref _myTaskCount, value); }
        }
        public int ForReviewTaskCount
        {
            get { return _forReviewTaskCount; }
            set { SetProperty(ref _forReviewTaskCount, value); }
        }

        public int CompletedTaskCount
        {
            get { return _completedTaskCount; }
            set { SetProperty(ref _completedTaskCount, value); }
        }

        public List<EngagementTask> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }
    }
}

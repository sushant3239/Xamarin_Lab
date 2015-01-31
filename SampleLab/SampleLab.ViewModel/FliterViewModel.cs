
using SampleLab.Model;
using SampleLab.PhoneService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleLab.ViewModel
{
    public class FliterViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private int _dueDateGroupSelectedIndex = -1;
        private int _reviewNoteSelectedIndex = -1;
        private int _auditPhaseSelectedIndex = -1;

        private List<Engagement> _engagementsByDueDate;
        private List<Engagement> _engagementsByReviewNotes;
        private List<Engagement> _engagementsByAuditPhase;        
        private List<Engagement> _engagements;

        public FliterViewModel(IPhoneService phoneService)
        {
            _engagements = DummyData.GetDummyData();
            _navigationService = phoneService.NavigationService;
        }

        public int DueDateGroupSelectedIndex
        {
            get { return _dueDateGroupSelectedIndex; }
            set
            {
                _dueDateGroupSelectedIndex = value;
                FilterByDueDate((ByDueDate)_dueDateGroupSelectedIndex);
            }
        }

        public int ReviewNoteSelectedIndex
        {
            get { return _reviewNoteSelectedIndex; }
            set
            {
                _reviewNoteSelectedIndex = value;
                FilterByReviewNote((ByReviewNotes)_reviewNoteSelectedIndex);
            }
        }

        public int AuditPhaseSelectedIndex
        {
            get { return _auditPhaseSelectedIndex; }
            set
            {

                _auditPhaseSelectedIndex = value;
                FilterByAuditPhase((ByAuditPhase)_auditPhaseSelectedIndex);
            }
        }

        public List<Engagement> EnagementsByEngagementNames { get; set; }

        #region"By Due Date"

        private void FilterByDueDate(ByDueDate option)
        {
            switch (option)
            {
                case ByDueDate.DueInWeek:
                    _engagementsByDueDate = _engagements.Where(e => e.Tasks.Any(t => GetNumberOfWeeksFromNow(t.DueDate) < 1)).ToList();
                    break;

                case ByDueDate.New:
                    _engagementsByDueDate = _engagements.Where(e => e.Tasks.Any(t => t.New == true)).ToList();
                    break;

                case ByDueDate.OverDue:
                    _engagementsByDueDate = _engagements.Where(e => e.Tasks.Any(t => t.DueDate <= DateTime.Now)).ToList();
                    break;
            }
        }

        private double GetNumberOfWeeksFromNow(DateTime date)
        {
            return (date - DateTime.Now).TotalDays / 7;
        }

        #endregion

        #region "By Review Notes"

        private void FilterByReviewNote(ByReviewNotes option)
        {
            switch (option)
            {
                case ByReviewNotes.ForMe:
                    break;

                case ByReviewNotes.ByMe:
                    break;
            }
        }

        #endregion

        #region "By Audit Phase"

        private void FilterByAuditPhase(ByAuditPhase option)
        {
            switch (option)
            {
                case ByAuditPhase.ScopeAndStrategy:
                    _engagementsByAuditPhase = _engagements.Where(e => e.Tasks.Any(t => (!String.IsNullOrEmpty(t.Phase) && t.Phase.Equals("1")))).ToList();
                    break;
            }
        }

        #endregion

        private enum ByDueDate
        {
            New, OverDue, DueInWeek
        }

        private enum ByReviewNotes
        {
            ForMe, ByMe
        }

        private enum ByAuditPhase
        {
            ScopeAndStrategy, Execution, Conclusion
        }

        public void NavigateToEngagementsPage()
        {
            _navigationService.NavigateToFilterByEngagementsPage(_engagements);
        }
    }
}

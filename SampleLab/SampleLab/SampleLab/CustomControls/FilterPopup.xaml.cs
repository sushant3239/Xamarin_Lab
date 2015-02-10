
using SampleLab.ViewModel;
using System.Collections.Generic;
using Xamarin.Behaviors;
using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public partial class FilterPopup : Grid
    {
        public FilterPopup()
        {
            InitializeComponent();

            GroupDueDate.AddSegment("New");
            GroupDueDate.AddSegment("Overdue");
            GroupDueDate.AddSegment("Due in a Week");

            GroupReviewNote.AddSegment("With Review Notes for Me");
            GroupReviewNote.AddSegment("With Review Notes by Me");

            GroupAuditPhase.AddSegment("Scope & Strategy");
            GroupAuditPhase.AddSegment("Execution");
            GroupAuditPhase.AddSegment("Conclusion");

            LabelEngagement.Clicked += LabelEngagementClicked;
        }

        private void LabelEngagementClicked(object sender, System.EventArgs e)
        {
            var viewModel = RootLayout.BindingContext as FliterViewModel;
            if (viewModel != null)
            {
                viewModel.NavigateToEngagementsPage();
            }
        }
    }
}

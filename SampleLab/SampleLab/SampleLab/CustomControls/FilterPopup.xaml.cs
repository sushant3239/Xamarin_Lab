
using SampleLab.ViewModel;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleLab.CustomControls
{
    public partial class FilterPopup : Grid
    {
        public FilterPopup()
        {
            InitializeComponent();

            GroupDueDate.ItemsSource = new List<string> { "New", "Overdue", "Due in a Week" };
            GroupReviewNote.ItemsSource = new List<string> { "With Review Notes for Me", "With Review Notes by Me" };
            GroupAuditPhase.ItemsSource = new List<string> { "Scope & Strategy", "Execution", "Conclusion" };
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

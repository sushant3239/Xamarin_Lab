
using SampleLab.Infrastructure.Storage;
using SampleLab.Model;
using SampleLab.PhoneService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleLab.ViewModel
{
    public class FilterByEngagementsViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private ISessionStorageManager _sessionStorage;

        private List<string> _listItems;
        private List<string> _selectedListItems;
        private FliterViewModel _filterViewModel;
        private List<Engagement> _engagements;

        public FilterByEngagementsViewModel(IPhoneService phoneService, FliterViewModel filterViewModel, ISessionStorageManager sessionStorage)
        {
            _navigationService = phoneService.NavigationService;
            _sessionStorage = sessionStorage;
            _filterViewModel = filterViewModel;

            SelectedListItems = new List<string>();
            DoneCommand = new Command(SelctionComplete);

            _engagements = _navigationService.NavigationParameters as List<Engagement>;
            if (_engagements != null)
            {
                InItList(_engagements);
            }

        }

        private void SelctionComplete()
        {
            var result = (from e in _engagements
                          join se in SelectedListItems
                          on e.Name equals se
                          select e).ToList<Engagement>();

            _filterViewModel.EnagementsByEngagementNames = result;
        }

        public ICommand DoneCommand { get; private set; }

        public List<string> ListItems
        {
            get { return _listItems; }
            set
            {
                if (_listItems == value)
                {
                    return;
                }
                _listItems = value;
                OnPropertyChanged();
            }
        }

        public List<string> SelectedListItems
        {
            get { return _selectedListItems; }
            set
            {
                _selectedListItems = value;
                OnPropertyChanged();
            }
        }

        private void InItList(List<Engagement> engagements)
        {
            ListItems = engagements.Select(e => e.Name).ToList();
        }
    }
}

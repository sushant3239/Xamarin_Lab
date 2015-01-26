
using SampleLab.ViewModel;
using System;

namespace SampleLab
{
    public static class AppResources
    {
        private static ViewModelLocator _viewModelLocator;
        public static ViewModelLocator ViewModelLocator
        {
            get
            {
                if (_viewModelLocator == null)
                {
                    _viewModelLocator = new ViewModelLocator();
                }
                return _viewModelLocator;
            }
        }
    }
}

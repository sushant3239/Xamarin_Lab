using SampleLab.CustomControls;
using SampleLab.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleLab.Pages
{
    public partial class AudiRecorderView : ContentPage
    {
        public AudiRecorderView()
        {
            InitializeComponent();
            PlayerSlider.ProgressChanged += PlayerSliderProgressChanged;            
        }

        private void PlayerSliderProgressChanged(object sender, SeekBarValueChangedEventArgs e)
        {
            if (e.FromUser)
            {
                var viewModel = AudioRecorderRoot.BindingContext as AudioRecorderViewModel;
                if (viewModel != null)
                {
                    viewModel.SeekToPostionCommand.Execute(e.NewValue);
                }
            }
        }
    }
}

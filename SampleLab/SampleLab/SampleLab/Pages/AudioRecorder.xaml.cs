using SampleLab.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleLab.Pages
{
    public partial class AudioRecorder
    {
        public AudioRecorder()
        {
            InitializeComponent();
            var dataContext = AudioRecorderRoot.BindingContext as AudioRecorderViewModel;
            
            PlayerSlider.ValueChanged +=(sender,e) =>
            {
                dataContext.SeekerPositionChangedCommnad.Execute(null);
            };     
        }
    }
}

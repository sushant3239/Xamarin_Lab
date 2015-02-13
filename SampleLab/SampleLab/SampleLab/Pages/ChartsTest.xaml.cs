using SampleLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleLab.Pages
{
    public partial class ChartsTest : TabbedPage
    {
        public ChartsTest()
        {
            InitializeComponent();

            FormattedString fs = new FormattedString();
            fs.Spans.Add(new Span { Text= "SampleSpa" });
        }

        
    }  
}

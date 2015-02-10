using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleLab.Pages
{
    public partial class ChartsTest : ContentPage
    {
        private static string[] Categories = new string[] { "Greenings", "Perfecto", "NearBy", "Family", "Fresh" };
        private static Random random = new Random();

        public ChartsTest()
        {
            InitializeComponent();
            series1.ItemsSource = GetCategoricalData();
            series2.ItemsSource = GetCategoricalData();        
        }

        public static List<CategoricalData> GetCategoricalData()
        {
            List<CategoricalData> data = new List<CategoricalData>();
            for (int i = 0; i < Categories.Length; i++)
            {
                data.Add(new CategoricalData() { Value = random.Next(50, 100), Category = Categories[i] });
            }

            return data;
        }
    }

    public class CategoricalData
    {
        public object Category
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
    }
}

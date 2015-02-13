
using SampleLab.Model;
using System;
using System.Collections.Generic;
namespace SampleLab.ViewModel
{
    public class ChartViewModel
    {
        private string[] Categories = new string[] { "SCOPE & STRATEGY", "EXECUTION", "CONCLUSION" };
        private Random random = new Random();

        public List<CategoricalData> GetCategoricalData()
        {
            List<CategoricalData> data = new List<CategoricalData>();
            for (int i = 0; i < Categories.Length; i++)
            {
                data.Add(new CategoricalData() { Value = random.Next(50, 100), Category = Categories[i] });
            }

            return data;
        }

        public List<CategoricalData> Series1 { get { return GetCategoricalData(); } }
        public List<CategoricalData> Series2 { get { return GetCategoricalData(); } }
        public List<CategoricalData> Series3 { get { return GetCategoricalData(); } }
        public List<CategoricalData> Series4 { get { return GetCategoricalData(); } }
    }
}

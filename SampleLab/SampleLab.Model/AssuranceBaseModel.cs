﻿

namespace SampleLab.Model
{
    public class AssuranceBaseModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}

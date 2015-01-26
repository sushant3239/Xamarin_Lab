
using System;
namespace SampleLab.Helper
{
    public class ClassHelper
    {
        private static ClassHelper _classHelper;

        private ClassHelper()
        {

        }

        public static ClassHelper ClassHelperInstance
        {
            get
            {
                if (_classHelper == null)
                {
                    _classHelper = new ClassHelper();
                }
                return _classHelper;
            }
        }

        public Type GetTypeByName(string nameSpace, string typeName)
        {
            return Type.GetType(String.Format("{0}.{1}", nameSpace, typeName));
        }


    }
}

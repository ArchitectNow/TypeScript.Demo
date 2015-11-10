using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectNow.Framework.Utilities
{
    public static class SettingsUtilities
    {
        public static string GetSetting(string Key)
        {
            //try
            //{
            //    if (RoleEnvironment.IsAvailable)
            //    {
            //        var _value = CloudConfigurationManager.GetSetting(Key);

            //        if (!string.IsNullOrEmpty(_value))
            //        {
            //            return _value;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}

            return System.Configuration.ConfigurationManager.AppSettings[Key];
        }
    }
}

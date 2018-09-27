using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WordPuzzleAPI.Utils
{
    public class ConfigurationManagerHelper
    {
        public static string GetKey(string keyName)
        {
            return WebConfigurationManager.AppSettings[keyName];
        }
    }
}
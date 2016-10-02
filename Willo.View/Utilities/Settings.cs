using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;
using Windows.Storage;

namespace Willo.View.Utilities
{
    public class Settings
    {
        private ApplicationDataContainer settings;

        public Settings()
        {
            settings = ApplicationData.Current.LocalSettings;
        }

        public AuthorizationToken? AuthorizationToken
        {
            get { return (AuthorizationToken?)settings.Values["AuthorizationToken"]; }
            set { settings.Values["AuthorizationToken"] = (string)value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop.Services.Settings
{
    public class SettingsService: ISettingsService
    {
        public string AccessToken
        {
            get => Preferences.Get("access_token", string.Empty);
            set => Preferences.Set("access_token", value);
        }

        public string RefreshToken
        {
            get => Preferences.Get("refresh_token", string.Empty);
            set => Preferences.Set("refresh_token", value);
        }
    }
}

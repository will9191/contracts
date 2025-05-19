using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop.Services.Settings
{
    public interface ISettingsService
    {
        string AccessToken { get; set; }
        string RefreshToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interface
{

    public interface IDeviceInfo
    {
        string GetDeviceID();
        double GetWindowHeight();
        double GetWindowWidth();
        string GetOSVersion();
    }
}

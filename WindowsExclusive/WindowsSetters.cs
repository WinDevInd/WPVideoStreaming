using SharedLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsExclusive.Utils;

namespace WindowsExclusive
{
    public class WindowsSetters : IEssentialsSetter
    {
        IDeviceInfo IEssentialsSetter.DeviceInfoSetters()
        {
            return new DeviceInfo();
        }
    }
}

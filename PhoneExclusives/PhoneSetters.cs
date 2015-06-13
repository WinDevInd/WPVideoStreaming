using PhoneExclusives.Utils;
using SharedLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneExclusives
{
    public class PhoneSetters : IEssentialsSetter
    {
        IDeviceInfo IEssentialsSetter.DeviceInfoSetters()
        {
            return new DeviceInfo();
        }
    }
}

using SharedLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Essentials
    {
        public static Essentials Instance;

        public IDeviceInfo DeviceInfo { get; private set; }

        public Essentials(IEssentialsSetter setter)
        {
            DeviceInfo = setter.DeviceInfoSetters();
        }
    }
}

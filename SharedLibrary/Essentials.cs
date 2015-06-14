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
        public IDispatcher UIDispatcher { get; private set; }
        public IStorageManager StorageManager { get; private set; }

        public Essentials(IEssentialsSetter setter)
        {
            DeviceInfo = setter.DeviceInfoSetters();
            UIDispatcher = setter.SetUIDispatcher();
            StorageManager = setter.SetUpStorageManager();
        }
    }
}

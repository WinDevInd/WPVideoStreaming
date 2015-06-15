namespace WindowsExclusive
{
    using PortableEssentials.Utils;
    using SharedLibrary.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WindowsSetters : IEssentialsSetter
    {

        IDeviceInfo IEssentialsSetter.DeviceInfoSetters()
        {
            return new DeviceInfo();
        }

        public IDispatcher SetUIDispatcher()
        {
            return new UIDispatcher();
        }

        IDispatcher IEssentialsSetter.SetUIDispatcher()
        {
            return new UIDispatcher();
        }

        IStorageManager IEssentialsSetter.SetUpStorageManager()
        {
            return new StorageManager();
        }
    }
}

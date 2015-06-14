namespace PhoneExclusives.Common
{
    using PortableEssentials.Utils;
    using SharedLibrary.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PhoneSetters : IEssentialsSetter
    {

        IDeviceInfo IEssentialsSetter.DeviceInfoSetters()
        {
            return new DeviceInfo();
        }


        IDispatcher IEssentialsSetter.SetUIDispatcher()
        {
            return new UIDispatcher();
        }


        public IStorageManager SetUpStorageManager()
        {
            return new StorageManager();
        }
    }
}

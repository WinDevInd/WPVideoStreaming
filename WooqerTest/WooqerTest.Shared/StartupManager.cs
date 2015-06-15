namespace WooqerTest.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Windows.ApplicationModel.Activation;

    public class StartupManager
    {
        /// <summary>
        /// Initialize all the Essentials Setters here
        /// </summary>
        /// <param name="PreviousExecutionState">last ApplicationExecutionState <see cref="Windows.ApplicationModel.Activation.ApplicationExecutionState"/></param>
        public static void BootupApplication(ApplicationExecutionState PreviousExecutionState)
        {
            if (PreviousExecutionState != ApplicationExecutionState.Running)
            {
#if WINDOWS_PHONE_APP
                //// Init all phone setters here
                SharedLibrary.Essentials.Instance = new SharedLibrary.Essentials(new PhoneExclusives.Common.PhoneSetters());
#elif WINDOWS_APP
                SharedLibrary.Essentials.Instance = new SharedLibrary.Essentials(new WindowsExclusive.WindowsSetters());

#endif
            }
        }
    }
}

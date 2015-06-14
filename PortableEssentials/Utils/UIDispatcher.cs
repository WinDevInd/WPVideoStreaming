namespace PortableEssentials.Utils
{
    using SharedLibrary.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;

    public class UIDispatcher : IDispatcher
    {
        private static UIDispatcher Instance = new UIDispatcher();
        private CoreDispatcher Dispatcher = InitializeCD();

        private static CoreDispatcher InitializeCD()
        {
            return CoreApplication.MainView.CoreWindow.Dispatcher;
        }

        public async Task RunAsync(UIThreadPriority Priority, Action TaskRef)
        {
            CoreDispatcherPriority priority = CoreDispatcherPriority.Low;
            switch (Priority)
            {
                case UIThreadPriority.High:
                case UIThreadPriority.Normal:
                    priority = CoreDispatcherPriority.Normal;
                    break;
                case UIThreadPriority.Low:
                    priority = CoreDispatcherPriority.Low;
                    break;
                case UIThreadPriority.Idle:
                    priority = CoreDispatcherPriority.Idle;
                    break;
            }
            await Dispatcher.RunAsync(priority, () => TaskRef.Invoke());
        }

        public static async Task RunOnUIThreadAsync(UIThreadPriority Priority, Action TaskRef)
        {
            await Instance.RunAsync(Priority, TaskRef);
        }
    }
}

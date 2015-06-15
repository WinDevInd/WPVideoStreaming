using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Interface
{

    public enum UIThreadPriority
    {
        High, Normal, Low, Idle
    }

    public interface IDispatcher
    {
        Task RunAsync(UIThreadPriority Priority, Action TaskRef);
    }

}

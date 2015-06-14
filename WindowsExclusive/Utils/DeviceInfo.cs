//----------------------------------------------------------------------------------------------
// <copyright file="DeviceInfo.cs" company="JISoft">
// Copyright (c) JISoft.  All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------
namespace WindowsExclusive.Utils
{
    using SharedLibrary.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Windows.Security.ExchangeActiveSyncProvisioning;
    using Windows.UI.Xaml;



    public class DeviceInfo : IDeviceInfo
    {
        private string DeviceId, OSVersion;
        private double Width, Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInfo"/> class.
        /// </summary>
        public DeviceInfo()
        {
            Width = Window.Current.Bounds.Width;
            Height = Window.Current.Bounds.Height;
            EasClientDeviceInformation deviceInfo = new EasClientDeviceInformation();
            OSVersion = deviceInfo.OperatingSystem;
        }

        /// <summary>
        /// Return the Device id
        /// </summary>
        /// <returns></returns>
        public string GetDeviceID()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Return Height of device
        /// </summary>
        /// <returns></returns>
        public double GetWindowHeight()
        {
            return Height;
        }

        /// <summary>
        /// Return width of window
        /// </summary>
        /// <returns></returns>
        public double GetWindowWidth()
        {
            return Width;
        }

        /// <summary>
        /// return OS version
        /// </summary>
        /// <returns></returns>
        public string GetOSVersion()
        {
            return OSVersion;
        }
    }
}

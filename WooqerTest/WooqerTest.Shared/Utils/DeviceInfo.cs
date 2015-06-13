//----------------------------------------------------------------------------------------------
// <copyright file="DeviceInfo.cs" company="JISoft">
// Copyright (c) JISoft.  All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------
namespace WooqerTest.Utils
{
    using SharedLibrary.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Windows.Security.ExchangeActiveSyncProvisioning;
    using Windows.UI.Xaml;


    public class DeviceInfo : IDeviceInfo
    {
        private string deviceId, osVersion;
        private double width, height;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInfo"/> class.
        /// </summary>
        public DeviceInfo()
        {
            deviceId = Guid.NewGuid().ToString();
            width = Window.Current.Bounds.Width;
            height = Window.Current.Bounds.Height;
            EasClientDeviceInformation deviceInfo = new EasClientDeviceInformation();
            osVersion = deviceInfo.OperatingSystem;
        }

        /// <summary>
        /// Return the Device id
        /// </summary>
        /// <returns></returns>
        public string GetDeviceID()
        {
            return deviceId;
        }

        /// <summary>
        /// Return Height of device
        /// </summary>
        /// <returns></returns>
        public double GetWindowHeight()
        {
            return height;
        }

        /// <summary>
        /// Return width of window
        /// </summary>
        /// <returns></returns>
        public double GetWindowWidth()
        {
            return width;
        }

        /// <summary>
        /// return OS version
        /// </summary>
        /// <returns></returns>
        public string GetOSVersion()
        {
            return osVersion;
        }
    }
}

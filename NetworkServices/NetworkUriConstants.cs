//----------------------------------------------------------------------------------------------
// <copyright file="NetworkUriConstants.cs" company="JISoft">
// Copyright (c) JISoft  All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------
namespace JISoft.NetoworkUtil
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// All the Base URL
    /// </summary>
    public class NetworkUriConstants
    {
        /// <summary>
        /// Base URL
        /// </summary>
        private const string APIBASEURL = "REPLACE_BASE_URL";

        /// <summary>
        /// API Version
        /// </summary>
        private const string APIVERSION = "v1/";

        /// <summary>
        /// Protocol prefix string
        /// </summary>
        private const string HTTP = @"http://";

        /// <summary>
        /// Secure protocol prefix string
        /// </summary>
        private const string HTTPS = @"https://";

        /// <summary>
        /// Gets Combine protocol prefix, base url in form of URL
        /// </summary>
        public static string BASEURL
        {
            get
            {
                return HTTP + APIBASEURL;
            }
        }

        /// <summary>
        /// Gets Combine secure protocol prefix, base url in form of URL
        /// </summary>
        public static string BASEURLSECURE
        {
            get
            {
                return HTTPS + APIBASEURL;
            }
        }

        /// <summary>
        /// Gets Accept JSON Type string
        /// </summary>
        public static string JSONAPPTYPE
        {
            get
            {
                return "application/json";
            }
        }

        /// <summary>
        /// Gets Accept XML Type string
        /// </summary>
        public static string XMLAPPTYPE
        {
            get
            {
                return "application/xml";
            }
        }

        /// <summary>
        /// Gets Header string for From post
        /// </summary>
        public static string FORMPOSTTYPE
        {
            get
            {
                return "application/x-www-form-urlencoded";
            }
        }
    }
}

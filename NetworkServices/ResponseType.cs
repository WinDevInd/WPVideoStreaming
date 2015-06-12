//----------------------------------------------------------------------------------------------
// <copyright file="ResponseType.cs" company="JISoft">
// Copyright (c) JISoft  All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace JISoft.NetoworkUtil
{
    public class ApiResponse<T>
    {
        public int Id
        {
            get;
            set;
        }

        public T value
        {
            get;
            set;
        }
    }   
}

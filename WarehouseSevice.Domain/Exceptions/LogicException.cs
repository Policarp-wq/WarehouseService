﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSevice.Domain.Exceptions
{
    public  class LogicException : Exception
    {
        public LogicException(string message) : base(message) { }
    }
}

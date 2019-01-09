﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.Model
{
    public class DatabaseLogs
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Level { get; set; }
    }
}

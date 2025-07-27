﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelematicsSystem.Common.AppSettings
{
    public class RabbitMqSettings
    {
        public string Host { get; set; } 
        public ushort Port { get; set; }
        public string VirtualHost { get; set; } 
        public string Username { get; set; }  
        public string Password { get; set; }  
    }
}

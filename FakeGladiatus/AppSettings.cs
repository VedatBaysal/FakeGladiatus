using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeGladiatus
{
    public class AppSettings
    {
        public string DatabaseConnectionString { get; set; }
        public ConnectionSettings ConnectionSettings { get; set; }
        public string AuthorizationAddress { get; set; }
    }
    public class ConnectionSettings
    {
        public string Address { get; set; }
        public int Port { get; set; }
    }
}

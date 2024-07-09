using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.Config
{
    public static class ServiceConfiguration
    {
        public static string Host;
        public static int Port;
        public static string DefaultUser;
        public static string DefaultPassword;

        public static ILoggerFactory LoggerFactory { get; set; }
    }

}

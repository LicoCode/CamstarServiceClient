using CamstarService.Config;
using CamstarService.ServiceContent;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.Client
{
    public static class LogHelper
    {
        private static readonly ILogger logger = ServiceConfiguration.LoggerFactory.CreateLogger("CamstarService");

        private static readonly JsonSerializerSettings setting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        public static void Success(Service service, string message)
        {
            var jsonStr = JsonConvert.SerializeObject(service,Formatting.Indented, setting);
            logger.LogInformation("Execute Service: {}, Request: {}, result: {}" , service.GetType().Name, jsonStr, message);
        }

        public static void Fail(Service service, string failMessage)
        {
            var jsonStr = JsonConvert.SerializeObject(service, Formatting.Indented, setting);
            logger.LogError("Execute Service: {}, Request: {}, result: {}", service.GetType().Name, jsonStr, failMessage);
        }

        public static void Exception(Service service, Exception ex)
        {
            var jsonStr = JsonConvert.SerializeObject(service, Formatting.Indented, setting);
            logger.LogError(ex, "Execute Service: {}, Request: {}", service.GetType().Name , jsonStr);
        }

        public static void Info(string message)
        {
            logger.LogInformation(message);
        }

        public static void Error(string message)
        {
            logger.LogError(message);
        }

        public static void Exception(string message, Exception exception)
        {
            logger.LogError(message, exception);
        }
    }
}

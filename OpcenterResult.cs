using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient
{
    /// <summary>
    /// 执行Camstar服务的返回值
    /// </summary>
    public  class OpcenterResult
    {
        public bool status {  get; set; }
        public string? message {  get; set; }
        public Object? data { get; set; }
        public static OpcenterResult Success(string message) { 
            return new OpcenterResult() {  status = true, message = message };
        }
        public static OpcenterResult Success(string message, Object data)
        {
            return new OpcenterResult() { status = true, message = message, data = data };
        }
        public static OpcenterResult Success(Object data)
        {
            return new OpcenterResult() { status = true, data = data };
        }
        public static OpcenterResult Fail(string message)
        {
            return new OpcenterResult() { status = false, message = message };
        }
    }
}

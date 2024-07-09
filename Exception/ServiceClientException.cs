using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService
{
    internal class ServiceClientException : Exception
    {
        public ServiceClientException(string message) : base(message){
            
        }
    }
}

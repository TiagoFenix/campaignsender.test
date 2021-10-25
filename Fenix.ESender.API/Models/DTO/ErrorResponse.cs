using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Models
{
    public class ErrorResponse 
    {
        public string Message;
        public ErrorResponse(string message)
        {
            this.Message = message;
        }
    }
}

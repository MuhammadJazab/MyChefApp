using System;
using System.Collections.Generic;
using System.Text;

namespace MyChefApp.Models
{
    public class Response
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public object ResultData { get; set; }
    }
}

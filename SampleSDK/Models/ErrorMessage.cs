using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSDK.Models
{
    public class ErrorMessage
    {
        public string ErrorString { get; set; }
        public string StackTrace { get; set; }
        public int ErrorCode { get; set; }
    }
}

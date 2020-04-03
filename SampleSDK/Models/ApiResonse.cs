using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSDK.Models
{
    public class ApiResonse<T> : IEntityResponse<T>
    {
        public IEnumerable<ErrorMessage> Errors { get; set; }
        public Guid ResponseId => Guid.NewGuid();
        public T ResponseObject { get; set; }

        public string ToJsonString()
        {
            if (ResponseObject != null)
                return JsonConvert.SerializeObject(ResponseObject);
            else
                return string.Empty;
        }
    }
}

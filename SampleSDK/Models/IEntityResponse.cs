using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSDK.Models
{
    public interface IEntityResponse<T>
    {
      Guid ResponseId { get; }
      T ResponseObject { get; set; }
      IEnumerable<ErrorMessage> Errors { get; set; }
      string ToJsonString();
    }
}

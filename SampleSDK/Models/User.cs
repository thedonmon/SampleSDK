using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSDK.Models
{
    public class User : IEntity
    {
        public string UserName { get; set; }
        public string AvatarUrl { get; set; }
    }
}

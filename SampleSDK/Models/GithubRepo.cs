using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSDK.Models
{
    public class GithubRepo : IEntity
    {
        public string RepoName { get; set; }
        public string RepoLink { get; set; }
        public int SubscriberCount { get; set; }
        public int StarCount { get; set; }
        public User UserInfo { get; set; }
    }
}

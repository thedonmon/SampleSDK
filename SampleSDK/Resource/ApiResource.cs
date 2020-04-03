using Newtonsoft.Json;
using SampleSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleSDK.Resource
{
    public static class ApiResource
    {
        private readonly static HttpClient _client;
        static ApiResource()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.github.com/");
            _client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            _client.DefaultRequestHeaders.Add("User-Agent", "SampleSDK");
        }
        public async static Task<IEntityResponse<IEnumerable<IEntity>>> GetByUser(string user)
        {
            HttpResponseMessage message = null;
            var response = await _client.GetAsync($"users/{user}/repos");
            try
            {
                message = response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<IEnumerable<GitHubResponseModel>>(responseString);
                if (model.Any())
                {
                    var data = model.Select(x => new GithubRepo
                    {
                        RepoName = x.name,
                        StarCount = x.stargazers_count,
                        SubscriberCount = x.watchers_count,
                        UserInfo = new User
                        {
                            UserName = user,
                            AvatarUrl = x.owner?.avatar_url ?? string.Empty
                        }
                    });
                    return new ApiResonse<IEnumerable<IEntity>>
                    {
                        ResponseObject = data,
                        
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResonse<IEnumerable<IEntity>>
                {
                    Errors = new List<ErrorMessage>
                    {
                        new ErrorMessage
                        {
                           ErrorString = $"{ex.Message} {ex.InnerException?.Message ?? string.Empty}",
                           StackTrace = ex.StackTrace,
                           ErrorCode = message != null ? (int)message.StatusCode : 500
                        }
                    }
                };
            }
            return new ApiResonse<IEnumerable<IEntity>>();
        }
    }
    public class GitHubResponseModel
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public int stargazers_count { get; set; }
        public int watchers_count { get; set; }
        public GitHubUserModel owner { get; set; }
    }
    public class GitHubUserModel
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
    }
}

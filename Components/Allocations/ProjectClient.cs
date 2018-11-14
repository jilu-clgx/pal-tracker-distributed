using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Allocations
{
    public class ProjectClient : IProjectClient
    {
        private readonly HttpClient _client;
        private ILogger _log;

        public ProjectClient(HttpClient client, ILogger log)
        {
            _client = client;
            _log = log;
        }

        public async Task<ProjectInfo> Get(long projectId)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _log.LogInformation(_client.BaseAddress.ToString() );
            var streamTask = _client.GetStreamAsync($"project?projectId={projectId}");
            var serializer = new DataContractJsonSerializer(typeof(ProjectInfo));
            return serializer.ReadObject(await streamTask) as ProjectInfo;
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftAPI
{
    [JsonObject]
    public class MinecraftServer
    {
        private static readonly HttpClient _client = new HttpClient(new HttpClientHandler
        { ServerCertificateCustomValidationCallback = (____, ___, __, _) => true });

        public static async Task<MinecraftServer> GetServer(string ip_port)
        {
            string ip = $"https://api.mcsrvstat.us/2/{ip_port}";
            //var html = new HtmlAgilityPack.HtmlWeb().Load(ip);            
         
            var response = await _client.GetAsync(ip).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<MinecraftServer>(responseBody);
              
        }

        public MinecraftServer()
    
        {

        }
        [JsonProperty("online")]
        public bool Online { get; set; }
        [JsonProperty("ip")]
        public string IP { get; set; }
        [JsonProperty("port")]
        public int Port { get; set; }
        [JsonProperty("players")]
        public MinecraftPlayersDetail PlayersDetail { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftTest.MinecraftAPI
{
    [JsonObject]
    public class MinecraftServer
    {
        
        public static async Task<MinecraftServer> GetServer(string ip_port)
        {
            string ip = $"https://api.mcsrvstat.us/2/{ip_port}";
            //var html = new HtmlAgilityPack.HtmlWeb().Load(ip);            
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true;
                };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var response = await client.GetAsync(ip);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<MinecraftServer>(responseBody);
                }
            }
            
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

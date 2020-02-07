using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftTest.MinecraftAPI
{
    [JsonObject]
    public class MinecraftPlayersDetail
    {
        [JsonProperty("online")]
        public int Online { get; set; }
        [JsonProperty("max")]
        public int MaxMembers { get; set; }
        [JsonProperty("list")]
        public List<string> MembersName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AMP.Net.Models
{
    public class LoginResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("result")]
        public int Result { get; set; }

        [JsonPropertyName("permissions")]
        public IList<string> Permissions { get; set; }

        [JsonPropertyName("sessionID")]
        public Guid SessionId { get; set; }

        [JsonPropertyName("rememberMeToken")]
        public string RememberMeToken { get; set; }

        [JsonPropertyName("userInfo")]
        public UserInfo UserInfo { get; set; }
    }
}

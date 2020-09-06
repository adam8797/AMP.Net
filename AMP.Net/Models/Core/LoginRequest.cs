using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AMP.Net.Models
{
    public class LoginRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("rememberMe")]
        public bool RememberMe { get; set; }
    }
}

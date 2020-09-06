using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AMP.Net.Models
{
    public class AuthenticatedRequest
    {
        [JsonPropertyName("SESSIONID")]
        public string SessionId { get; set; }
    }
}

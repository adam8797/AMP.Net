using System;
using System.Text.Json.Serialization;

namespace AMP.Net.Models
{
    public class UserInfo
    {
        [JsonPropertyName("ID")]
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public bool IsTwoFactorEnabled { get; set; }

        public bool Disabled { get; set; }

        [JsonConverter(typeof(MicrosoftJsonDateConverter))]
        public DateTime LastLogin { get; set; }

        public string GravatarHash { get; set; }
    }
}
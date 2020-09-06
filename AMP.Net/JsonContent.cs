using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AMP.Net
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) : base(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json")
        {}
    }
}

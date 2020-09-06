using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AMP.Net.Models
{
    public class WrappedResult<T>
    {
        [JsonPropertyName("result")]
        public IList<T> Results { get; set; }
    }
}

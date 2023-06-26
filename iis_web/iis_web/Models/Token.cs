using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iis_web.Models
{
    public class Token
    {
        [JsonProperty("token")]
        public string Value { get; set; }
    }
}
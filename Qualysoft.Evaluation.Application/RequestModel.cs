namespace Qualysoft.Evaluation.Application
{
    using Newtonsoft.Json;
    using System;

    /// <summary>post data request dto</summary>
    public class RequestModel
    {
        /// <summary>index</summary>
        [JsonProperty("ix", Order = 1, Required = Required.Always)]
        public int Index { get; set; }

        /// <summary>name</summary>
        [JsonProperty("name", Order = 2, Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>#no visits</summary>
        [JsonProperty("visits", Order = 3, Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int? Visits { get; set; }

        /// <summary>date time</summary>
        [JsonProperty("date", Order = 4, Required = Required.Always)]
        public DateTime Date { get; set; }
    }
}

namespace Qualysoft.Evaluation.Application
{
    using Newtonsoft.Json;
    using ProtoBuf;
    using System;

    /// <summary>post data request dto</summary>
    [Serializable]
    [ProtoContract]
    public class RequestModel
    {
        /// <summary>index</summary>
        [JsonProperty("ix", Order = 1, Required = Required.Always)]
        [ProtoMember(1)]
        public int Index { get; set; }

        /// <summary>name</summary>
        [JsonProperty("name", Order = 2, Required = Required.Always)]
        [ProtoMember(2)]
        public string Name { get; set; }

        /// <summary>#no visits</summary>
        [JsonProperty("visits", Order = 3, Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        [ProtoMember(3)]
        public int? Visits { get; set; }

        /// <summary>date time</summary>
        [JsonProperty("date", Order = 4, Required = Required.Always)]
        [ProtoMember(4)]
        public DateTime Date { get; set; }
    }
}

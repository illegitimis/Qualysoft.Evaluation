namespace Qualysoft.Evaluation.Application
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Dto for POST /api/data response
    /// </summary>
    public class RequestPostResponse
    {
        public RequestPostResponse(int a = 0, int u = 0)
        {
            Added = a;
            Updated = u;
        }

        public static RequestPostResponse None { get => new RequestPostResponse(); }

        /// <summary>index</summary>
        [JsonProperty("added", Order = 1, Required = Required.Always)]
        public int Added { get; set; }

        /// <summary>name</summary>
        [JsonProperty("updated", Order = 2, Required = Required.Always)]
        public int Updated { get; set; }

        internal RequestPostResponse AddTuple((int, int) result)
        {
            this.Added += result.Item1;
            this.Updated += result.Item2;
            return this;
        }
    }
}

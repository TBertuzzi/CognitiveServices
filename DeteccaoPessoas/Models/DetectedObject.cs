using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DeteccaoPessoas.Models
{
    public partial class DetectedObject
    {
        [JsonProperty("objects")]
        public Object[] Objects { get; set; }

        [JsonProperty("requestId")]
        public Guid RequestId { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
        
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class Metadata
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
    }

    public partial class Object
    {
        [JsonProperty("rectangle")]
        public Rectangle Rectangle { get; set; }

        [JsonProperty("object")]
        public string ObjectObject { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public partial class Rectangle
    {
        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }
    }
}
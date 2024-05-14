﻿using Newtonsoft.Json;

namespace CPOnboardingAPI.Models
{
    public class BaseEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsInternal { get; set; }
        public bool IsVisible { get; set; }
    }
}

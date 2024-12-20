﻿using Newtonsoft.Json;

namespace EnergyTech_NET.DTOs
{
    public class FirebaseLoginResponse
    {
        [JsonProperty("idToken")]
        public string IdToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }

        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; set; }

        [JsonProperty("localId")]
        public string LocalId { get; set; }
    }
}

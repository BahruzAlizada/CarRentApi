﻿using System;

namespace CoreLayer.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; } // Bitiş tarixi
    }
}

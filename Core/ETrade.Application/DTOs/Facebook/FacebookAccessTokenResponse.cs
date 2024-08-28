﻿using System.Text.Json.Serialization;

namespace ETrade.Application.DTOs.Facebook;

public class FacebookAccessTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
}
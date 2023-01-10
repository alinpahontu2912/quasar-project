
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace StoreFunctions
{
  public class ValidateJWT
  {
    public bool IsValid { get; }
    public string Username { get; }
    public string RefreshToken { get; }
    public ValidateJWT(HttpRequest request)
    {
      // Check if we have a header.
      if (!request.Headers.ContainsKey("Authorization"))
      {
        return;
      }
      string authorizationHeader = request.Headers["Authorization"];
      // Check if the value is empty.
      if (string.IsNullOrEmpty(authorizationHeader))
      {
        return;
      }
      // Check if we can decode the header.
      IDictionary<string, object> claims = null;
      try
      {
        if (authorizationHeader.StartsWith("Bearer"))
        {
          authorizationHeader = authorizationHeader.Substring(7);
        }
        // Validate the token and decode the claims.
        claims = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm())
          .WithSecret(Environment.GetEnvironmentVariable($"ConnectionStrings:jwtKey", EnvironmentVariableTarget.Process))
          .MustVerifySignature().Decode<IDictionary<string, object>>(authorizationHeader);
      }
      catch (Exception exception)
      {
        return;
      }
      // Check if we have user claim.
      if (!claims.ContainsKey("username"))
      {
        return;
      }
      if (!claims.ContainsKey("refreshToken"))
      {
        return;
      }
      IsValid = true;
      Username = Convert.ToString(claims["username"]);
      RefreshToken = Convert.ToString(claims["refreshToken"]);
    }
  }
}

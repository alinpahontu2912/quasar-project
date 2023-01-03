
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace StoreFunctions
{
  public static class Utils
  {
    private static JWTGenerator JWTgenerator = new();

    public static string getJWTToken(string userMail)
    {
      return JWTgenerator.IssuingJWT(userMail);
    }

    public static ValidateJWT verifyJWTToken(HttpRequest req) {
      return new ValidateJWT(req);
    }

  }
}





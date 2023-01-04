
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using XAct;

using XSystem.Security.Cryptography;

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

    public static string hashPassword(string password)
    {
      var md5 = new MD5CryptoServiceProvider();
      var md5data = md5.ComputeHash(password.ToByteArray());
      Console.WriteLine(Encoding.UTF8.GetString(md5data));
      return Encoding.UTF8.GetString(md5data);
    }

  }
}





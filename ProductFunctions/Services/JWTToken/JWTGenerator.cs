using JWT.Algorithms;
using JWT.Serializers;
using JWT;

namespace StoreFunctions
{
  public class JWTGenerator
  {
    private readonly IJwtAlgorithm _algorithm;
    private readonly IJsonSerializer _serializer;
    private readonly IBase64UrlEncoder _base64Encoder;
    private readonly IJwtEncoder _jwtEncoder;
    public JWTGenerator()
    {
      // JWT specific initialization.
      _algorithm = new HMACSHA256Algorithm();
      _serializer = new JsonNetSerializer();
      _base64Encoder = new JwtBase64UrlEncoder();
      _jwtEncoder = new JwtEncoder(_algorithm, _serializer, _base64Encoder);
    }
    public string IssuingJWT(string email)
    {
      Dictionary<string, object> claims = new Dictionary<string, object> {
                // JSON representation of the email Reference with ID and display name
                {
                    "username",
                    email
                },
                {
                    "role",
                    "admin"
                }
            };
      string token = _jwtEncoder.Encode(claims, "Your Secret Securtity key string"); // Put this key in config
      return token;
    }
  }
}

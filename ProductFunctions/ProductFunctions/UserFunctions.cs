using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StoreFunctions
{
  public static class UserFunctions
  {

    static UserService userService = new();

    [FunctionName("users")]
    public static async Task<IActionResult> GetUser(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
      string email = req.Query["user"];
      string password = req.Query["pswd"];
      bool successfull = userService.FindUser(email, password) != null;
      return successfull ? new OkObjectResult(Utils.getJWTToken(email))
      : new BadRequestObjectResult("Credentials are not correct");
    }

    [FunctionName("createUsers")]
    public static async Task<IActionResult> CreateUser(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users/add/")] HttpRequest req,
        ILogger log)
    {
      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      User newUser = JsonConvert.DeserializeObject<User>(requestBody);
      bool succesfull = await userService.AddNewUser(newUser);
      return succesfull ? new OkObjectResult(Utils.getJWTToken(newUser.Email))
        : new BadRequestObjectResult("Not a valid user");
    }

    [FunctionName("usersTest")]
    public static async Task<IActionResult> TestAuth(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
      ValidateJWT auth = new ValidateJWT(req);
      if (!auth.IsValid)
      {
        return new UnauthorizedResult();
      }
      return new OkObjectResult("Merge!");
    }
  }
}

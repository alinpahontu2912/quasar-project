using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct;
using XSystem.Security.Cryptography;

namespace StoreFunctions
{
  internal class UserService
  {


    public string hashPassword(string password) {
      var md5 = new MD5CryptoServiceProvider();
      var md5data = md5.ComputeHash(password.ToByteArray());
      return Encoding.UTF8.GetString(md5data);
    }


    public List<User> GetAllUsers()
    {

      List<User> allUsers = new();
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          allUsers = dataBase.Users.Select(user => user).ToList();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return allUsers;
    }

    public User FindUser(string email) {
      User wantedUser = null;
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          wantedUser = (User)dataBase.Users.Where(user => user.Email == email);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return wantedUser;
    }

    public async Task<bool> AddNewUser(User newUser)
    {
      try
      {
        using (var dataBase = new TrainingAlinContext())
        {
          Console.Write(newUser.Email);
          Console.Write(newUser.FullName);
          Console.Write(newUser.Phone);
          dataBase.Users.Add(newUser);
          await dataBase.SaveChangesAsync();
          return true;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return false;
      }

    }


  }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFunctions
{
  internal class UserService
  {
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

    public async Task<User> FindUser(string email, string password)
    {
      User wantedUser = null;
      using (var dataBase = new TrainingAlinContext())
      {
        wantedUser = await dataBase.Users.Where(user => user.Email == email).FirstAsync();
        if (wantedUser.HashPass == Utils.hashPassword(password))
        {
          return wantedUser;
        }
      }
      return null;
    }

    public async Task<bool> AddNewUser(User newUser)
    {
      using (var dataBase = new TrainingAlinContext())
      {
        try
        {
          newUser.HashPass = Utils.hashPassword(newUser.HashPass);
          dataBase.Users.Add(newUser);
          await dataBase.SaveChangesAsync();
          return true;
        }
        catch (Exception ex)
        {
          return false;
        }
      }


    }


  }
}

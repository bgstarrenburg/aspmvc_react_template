using aspmvc_react.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using aspmvc_react.Helpers;

namespace aspmvc_react.Services
{
  public class UserService
  {
    private DBContextModel context { get; set; }
    private string cookieName = "UserLogin";
    private AuthenticationHelpers authenticationHelpers { get; set; }

    public UserService(DBContextModel context, AuthenticationHelpers authenticationHelpers)
    {
      this.context = context;
      this.authenticationHelpers = authenticationHelpers;
    }

    public async Task<User> CreateUser(RegistrationRequest request)
    {
      try
      {
        string username = request.UserName, email = request.EmailAdress, password = request.Password;
        if (UserExists(username, email)) return null; //this should never happen
        string passwordHash = HashPassword(password);
        var user = new User() {Id = new Guid(), EmailAdress = email, PaswordHash = password, UserName = username };
        var isLoggedIn = authenticationHelpers.IsSessionValid(cookieName);
        context.Users.Add(user);
        await context.SaveChangesAsync();
        authenticationHelpers.LoginUser(user, cookieName);
        isLoggedIn = authenticationHelpers.IsSessionValid(cookieName);
        return user;
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        return null;
      }
    }

    public User LoginUser(LoginRequest request)
    {
      try
      {
        string email = request.EmailAdress, password = request.Password;
        string passwordHash = HashPassword(password);
        var user = context.Users.FirstOrDefault(u => u.EmailAdress == email && u.PaswordHash == passwordHash);
        if (user == null) return null;
        authenticationHelpers.LoginUser(user, cookieName);
        return user;
      }
      catch (System.Exception e)
      {
        System.Console.WriteLine(e.Message);
        return null;
      }
    }

    public string HashPassword(string password) {
      byte[] salt = new byte[16];
      using (var rng = RandomNumberGenerator.Create())
      {
          rng.GetNonZeroBytes(salt);
      }
      string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 16));
      return hashed;
    }
    public bool UserExists(string userName, string email) {
      var user = context.Users.FirstOrDefault(u => u.UserName == userName || u.EmailAdress == email);
      return user != null;
    }
    public bool UserNameExists(string userName) {
      var user = context.Users.FirstOrDefault(u => u.UserName == userName);
      return user != null;
    }
    public bool EmailAdressExists(string email) {
      var user = context.Users.FirstOrDefault(u => u.EmailAdress == email);
      return user != null;
    }
  }
}

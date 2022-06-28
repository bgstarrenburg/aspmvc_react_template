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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace aspmvc_react.Helpers
{
  public class AuthenticationHelpers
  {
    private ISession session { get; set; }
    public AuthenticationHelpers(IHttpContextAccessor httpContextAccessor)
    {
      this.session = httpContextAccessor.HttpContext.Session;
    }

    public bool IsSessionValid(string cookieName) {
      var sessionsCookie = session.Get(cookieName);
      if (sessionsCookie == null) return false;
      return true;
    } 

    public void LoginUser(User user, string cookieName) {
      var userAsBytes = ObjectToByteArray(user);
      session.Set(cookieName, userAsBytes); 
    }
    public static byte[] ObjectToByteArray(Object obj)
{
    BinaryFormatter bf = new BinaryFormatter();
    using (var ms = new MemoryStream())
    {
        bf.Serialize(ms, obj);
        return ms.ToArray();
    }
}
  }
}

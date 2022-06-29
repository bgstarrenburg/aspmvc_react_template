using aspmvc_react.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;

namespace aspmvc_react.Helpers
{
  public class AuthenticationHelpers
  {
    private ISession session { get; set; }
    public AuthenticationHelpers(IHttpContextAccessor httpContextAccessor)
    {
      this.session = httpContextAccessor.HttpContext.Session;
    }

    public bool IsSessionValid(string cookieName)
    {
      try
      {
        var sessionsCookie = session.Get(cookieName);
        if (sessionsCookie == null) return false;
        var user = ByteArrayToObject<User>(sessionsCookie);
        if (user != null) return true;
        return false;
      } catch
      {
        return false;
      }
    }

    public void LoginUser(User user, string cookieName)
    {
      var userAsBytes = ObjectToByteArray(user);
      session.Set(cookieName, userAsBytes);
    }

    public byte[] ObjectToByteArray(object obj)
    {
      using (MemoryStream m = new MemoryStream())
      {
        using (BinaryWriter writer = new BinaryWriter(m))
        {
          var serialized = JsonSerializer.Serialize(obj);
          writer.Write(serialized);
        }
        return m.ToArray();
      }
    }

    public object ByteArrayToObject<T>(byte[] data)
    {
      T result = default(T);
      using (MemoryStream m = new MemoryStream(data))
      {
        using (BinaryReader reader = new BinaryReader(m))
        {
          var jsonString = reader.ReadString();
          result = JsonSerializer.Deserialize<T>(jsonString);
        }
      }
      return result;
    }
  }
}

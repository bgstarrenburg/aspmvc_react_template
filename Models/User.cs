using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace aspmvc_react.Models
{
  public class User
  {
    [Key]
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string PaswordHash { get; set; }
    public string EmailAdress { get; set; }
  }

  public class UserResponse
  {
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string EmailAdress { get; set; }
  }

  public class RegistrationRequest
  {
    [JsonPropertyName("username")]
    [Required]
    [MinLength(3)]
    public string UserName { get; set; }
    [JsonPropertyName("password")]
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    [JsonPropertyName("email")]
    [Required]
    [EmailAddress]
    public string EmailAdress { get; set; }
  }

  public class LoginRequest
  {
    [JsonPropertyName("password")]
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    [JsonPropertyName("email")]
    [Required]
    [EmailAddress]
    public string EmailAdress { get; set; }
  }
}

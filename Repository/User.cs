
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class User : IUser
{

    private readonly IConfiguration _configuration;

    public User(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(string Email)
    {
        var audienceConfig = _configuration.GetSection("Audience");
        var Secret = audienceConfig["Secret"] ?? "";
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim("Name", "Md. Bulbul")
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<string> CreateUser()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (System.Exception)
        {

            throw;
        }
    }


    public async Task<string> LoginUser(LoginUserDTO obj)
    {
        try
        {
            if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrEmpty(obj.Password))
            {
                throw new Exception("Invalid Input");
            }

            var token = GenerateJwtToken(obj.Email);

            return token;

        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
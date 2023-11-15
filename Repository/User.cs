
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;


public class User : IUser
{
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
            if(string.IsNullOrEmpty(obj.Email) || string.IsNullOrEmpty(obj.Password))
            {
                throw new Exception("Invalid Input");
            }
            return default;
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
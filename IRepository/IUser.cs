
using Microsoft.AspNetCore.Mvc;

public interface IUser
{
    public Task<string> CreateUser();
    public Task<string> LoginUser(LoginUserDTO obj);
}
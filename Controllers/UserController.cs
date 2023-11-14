using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("crm/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUser _IUser;

    public UserController(IUser iUser)
    {
        _IUser = iUser;
    }

    [HttpGet("CreateUser")]
    public async Task<IActionResult> CreateUser()
    {
        var result = await _IUser.CreateUser();
        return Ok(result);
    }

    [HttpPost("LoginUser")]
    public async Task<IActionResult> LoginUser(LoginUserDTO obj)
    {
        var result = await _IUser.LoginUser(obj);
        return Ok(result);
    }
}

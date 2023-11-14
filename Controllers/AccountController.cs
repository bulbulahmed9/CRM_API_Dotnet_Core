using Microsoft.AspNetCore.Mvc;

public class PriceDTO
{
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public decimal Total => Price * Quantity;
}

[ApiController]
[Route("crm/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccount _IAccount;

    public AccountController(IAccount iAccount)
    {
        _IAccount = iAccount;
    }

    [HttpGet("GetPrice")]
    public async Task<IActionResult> GetPrice()
    {
        var result = await _IAccount.CreateAccount();
        return Ok(result);
    }
}

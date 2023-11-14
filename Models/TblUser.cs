using System;
using System.Collections.Generic;

namespace my_crm.Models;

public partial class TblUser
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long AccountId { get; set; }

    public long BranchId { get; set; }

    public DateTime ActionDateTime { get; set; }

    public bool IsActive { get; set; }
}

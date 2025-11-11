using System;
using System.Collections.Generic;

namespace StolyarovaDemo.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> UserRoles { get; set; } = new List<User>();

    public virtual ICollection<User> UserUroles { get; set; } = new List<User>();
}

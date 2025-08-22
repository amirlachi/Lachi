﻿using Microsoft.AspNetCore.Identity;

namespace Lachi.Data.Entities.UserStuff
{
    public class Role:IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}

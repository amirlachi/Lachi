﻿namespace Lachi.Data.Users
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
